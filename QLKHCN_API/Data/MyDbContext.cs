using Microsoft.EntityFrameworkCore;

namespace QLKHCN_API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DataCSV> DataCSVs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DataCSVTem> DataCSVTems { get; set;}
    }
}
