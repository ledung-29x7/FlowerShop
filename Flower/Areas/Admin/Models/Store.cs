namespace Flower.Areas.Admin.Models
{
    public class Store
    {
        private int store_id;
        private string store_name;
        private string address ;
        private string phone_number ;
        private string email;
        private DateTime? created_at;

        public int Store_id { get => store_id; set => store_id = value; }
        public string Store_name { get => store_name; set => store_name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public DateTime? Created_at { get => created_at; set => created_at = value; }
    }
}
