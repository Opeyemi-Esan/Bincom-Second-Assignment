using BincomSecondAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace BincomSecondAssignment
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Gallery> Galleries { get; set; }
    }
}
