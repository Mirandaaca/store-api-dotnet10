namespace CIWithJenkins.Entities
{
    public class SaleDetail
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        // Price the product had when this sale was registered
        public decimal UnitPrice { get; set; }
        // Units of the product sold in this sale
        public int Quantity { get; set; }
        // Generated column: the database keeps it as UnitPrice * Quantity
        public decimal Subtotal { get; private set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
