using Microsoft.AspNetCore.Identity;


namespace BusinessObject
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
