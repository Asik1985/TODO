using Microsoft.EntityFrameworkCore;
using TODO.Web.Models;

namespace TODO.Web.Data;


public class TODOContext : DbContext
{
    public TODOContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<System.Threading.Tasks.Task> Tasks { get; set; }

    public DbSet<Priority> Priorities { get; set; }
}