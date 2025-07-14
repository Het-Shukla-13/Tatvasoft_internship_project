using Microsoft.EntityFrameworkCore;
using MyProject.Entities.Models;

namespace MyProject.Entities
{
    public class MyProjectDbContext : DbContext
    {
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
