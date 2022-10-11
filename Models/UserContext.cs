using Microsoft.EntityFrameworkCore;

namespace AdminRegister.Models
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> AdminUser { get; set; }
    }
}
