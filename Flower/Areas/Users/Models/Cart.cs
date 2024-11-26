namespace Flower.Areas.Users.Models
{
    public class Cart
    {
        private int cart_id;
        private int user_id;
        private Guid session_id;
        private DateTime created_at;

        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public Guid Session_id { get => session_id; set => session_id = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
    }
}
