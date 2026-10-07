using CIWithJenkins.Enums;

namespace CIWithJenkins.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public User User { get; set; }
        public Client Client { get; set; }
        // A sale has many sale details
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
