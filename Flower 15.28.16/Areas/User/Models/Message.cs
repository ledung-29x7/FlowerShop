namespace Flower.Areas.User.Models
{
    public class Message
    {
        private int message_id;
        private int occasion_id;
        private string message_text;

        public int Message_id { get => message_id; set => message_id = value; }
        public int Occasion_id { get => occasion_id; set => occasion_id = value; }
        public string Message_text { get => message_text; set => message_text = value; }
    }
}
