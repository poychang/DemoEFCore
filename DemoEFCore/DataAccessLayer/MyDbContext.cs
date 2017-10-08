using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.DataAccessLayer
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
    }
}
