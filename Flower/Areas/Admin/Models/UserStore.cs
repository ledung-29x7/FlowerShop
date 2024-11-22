namespace Flower.Areas.Admin.Models
{
    public class UserStore
    {
        private int user_store_id;
        private int user_id;
        private int store_id;

        public int User_store_id { get => user_store_id; set => user_store_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public int Store_id { get => store_id; set => store_id = value; }
    }
}
