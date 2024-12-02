namespace Flower.Areas.Dtos
{
    public class RegisterDto
    {
        public string full_name { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }
}
