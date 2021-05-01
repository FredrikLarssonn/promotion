namespace Models
{
    public class LineItem
    {
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
        public int NumberOfDiscounts { get; set; }
        public int Quantity { get; set; }
    }
}