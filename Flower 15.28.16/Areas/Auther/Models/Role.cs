using System.ComponentModel.DataAnnotations;

namespace Flower.Areas.Auther.Models
{
    public class Role
    {
        private int role_id;
        private string name;

        [Key]
        public int Role_id { get => role_id; set => role_id = value; }
        public string Name { get => name; set => name = value; }
    }
}
