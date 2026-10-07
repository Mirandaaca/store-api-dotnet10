namespace CIWithJenkins.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // A user is in many sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public Role Role { get; set; }
    }
}
