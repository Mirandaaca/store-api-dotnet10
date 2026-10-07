namespace CIWithJenkins.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // A client is in many sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
