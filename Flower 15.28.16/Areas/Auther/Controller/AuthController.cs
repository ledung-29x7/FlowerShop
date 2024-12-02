using AutoMapper;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Flower.Areas.Auther.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenBlacklistRepository _tokenBlacklist;

        public AuthController(IUserRepository userRepository, IAuthService authService, IMapper mapper, IRoleRepository roleRepository, ITokenBlacklistRepository tokenBlacklist) 
        {
            _repository = userRepository;
            _tokenBlacklist = tokenBlacklist;
            _authService = authService;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var existingUser = await _repository.GetUserByEmail(registerDto.email);
            if (existingUser != null)
                return BadRequest("Email is already registered.");

            var user = _mapper.Map<User>(registerDto);
            user.Password_hash = BCrypt.Net.BCrypt.HashPassword(registerDto.password_hash);
            await _repository.RegisterUser(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _repository.GetUserByEmail(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password_hash))
                return Unauthorized("Invalid credentials.");

            var role = await _roleRepository.GetRoleById(user.Role_id);
            var roleName = role.Name;
            var token = _authService.GenerateJwtToken(user, roleName);
            return Ok(new
            {
                UserName = user.Full_name,
                Role = role.Name,
                token
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token not provided");

            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var expiration = jwtToken.ValidTo;

            // Thêm token vào Redis blacklist với thời gian hết hạn
            await _tokenBlacklist.AddTokenToBlacklistAsync(token, expiration);

            return Ok(new { message = "Logged out successfully" });
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("update-role")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateRoleDto request)
        {
            await _repository.UpdateUserRoleAsync(request.UserId, request.RoleId);
            return Ok("Role updated successfully");
        }






    }
}
