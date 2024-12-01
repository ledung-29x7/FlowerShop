using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Flower.DAL.Repositorys
{
    public class ImageRepository : IImageRepository
    {
        private readonly FlowerDbContext _context;
        public ImageRepository(FlowerDbContext context)
        {
            _context = context;
        }
        public async Task AddImages(List<Image> images)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                // Tạo DataTable từ danh sách ảnh
                var table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("ImageBase64", typeof(string));
                table.Columns.Add("FlowerId", typeof(int));

                foreach (var image in images)
                {
                    table.Rows.Add(image.Name, image.Imagebase64, image.Flower_id);
                }

                // Tham số SqlParameter cho bảng dữ liệu
                var param = new SqlParameter
                {
                    ParameterName = "@ImageList",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "ImageTableType",
                    Value = table
                };

                // Gọi stored procedure
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "AddImages";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(param);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteImageByFlowerId(int flower_id)
        {
            var id_Param = new SqlParameter("@Flower_id", flower_id);
            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.DeleteImageByFlowerId @Flower_id", id_Param);
        }

        public async Task<List<Image>> GetImageByFlowerId(int flower_id)
        {
            var flower_id_param = new SqlParameter("@FlowerId", flower_id);
            return await Task.FromResult(_context.images.FromSqlRaw("EXECUTE dbo.GetImageByFlowerId @FlowerId", flower_id_param).ToList());
        }
    }
}
