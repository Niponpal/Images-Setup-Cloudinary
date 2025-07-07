using ImagesSetup.Models;
using Microsoft.EntityFrameworkCore;

namespace ImagesSetup.Data
{
    public class ApplicatinDbContext:DbContext
    {
        public ApplicatinDbContext(DbContextOptions<ApplicatinDbContext> options) : base(options) 
        {

        }
        public DbSet<Customer> Customers { get; set; }
        
    }
}
