using Microsoft.EntityFrameworkCore;
using The_Sims_2_SimsExplorer.Models;

namespace The_Sims_2_SimsExplorer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sim> Sims { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
