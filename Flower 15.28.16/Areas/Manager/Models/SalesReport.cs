namespace Flower.Areas.Manager.Models
{
    public class SalesReport
    {
        private int report_id;
        private int store_id;
        private DateTime report_date;
        private decimal daily_sales;

        public int Report_id { get => report_id; set => report_id = value; }
        public int Store_id { get => store_id; set => store_id = value; }
        public DateTime Report_date { get => report_date; set => report_date = value; }
        public decimal Daily_sales { get => daily_sales; set => daily_sales = value; }
    }
}
