using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Connection
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
        }

        public DbSet<UserModel> user { get; set; }
    }
}
