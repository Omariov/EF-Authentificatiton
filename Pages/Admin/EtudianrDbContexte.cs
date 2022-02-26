using Microsoft.EntityFrameworkCore;

namespace test.Pages.Admin
{
    public class EtudianrDbContexte : DbContext
    {
        public EtudianrDbContexte(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Etudiant> etudiants { get; set; }


     }
}
