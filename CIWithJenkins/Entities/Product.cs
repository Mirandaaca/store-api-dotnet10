namespace CIWithJenkins.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Available stock of the product
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        // A product is in many sale details
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
