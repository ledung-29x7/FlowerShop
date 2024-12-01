namespace Flower.Areas.Manager.Models
{
    public class Notification
    {
        private int notification_id;
        private int user_id;
        private int order_id;
        private int store_id;
        private string message;
        private bool is_read;
        private DateTime create_at;

        public int Notification_id { get => notification_id; set => notification_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Store_id { get => store_id; set => store_id = value; }
        public string Message { get => message; set => message = value; }
        public bool Is_read { get => is_read; set => is_read = value; }
        public DateTime Create_at { get => create_at; set => create_at = value; }
    }
}
