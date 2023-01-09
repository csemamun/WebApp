using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
     public   DbSet<Registration>Registrations { get; set; }

    }
}
