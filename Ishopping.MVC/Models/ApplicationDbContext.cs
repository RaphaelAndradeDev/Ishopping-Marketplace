using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Ishopping.MVC.Models
{
 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IShoppingIdentity")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Claims> Claims { get; set; }                 
    }
}