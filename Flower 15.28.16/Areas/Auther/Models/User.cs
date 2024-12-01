using System.ComponentModel.DataAnnotations;

namespace Flower.Areas.Auther.Models
{
    public class User
    {
       private int user_id;
       private string full_name;
       private string email;
       private string password_hash;
       private string phone_number;
       private string address;
       private int role_id;
       private DateTime? created_at;
       private DateTime? update_at;

        [Key]
        public int User_id { get => user_id; set => user_id = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public string Email { get => email; set => email = value; }
        public string Password_hash { get => password_hash; set => password_hash = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Address { get => address; set => address = value; }
        public int Role_id { get => role_id; set => role_id = value; }
        public DateTime? Created_at { get => created_at; set => created_at = value; }
        public DateTime? Update_at { get => update_at; set => update_at = value; }
    }
}
