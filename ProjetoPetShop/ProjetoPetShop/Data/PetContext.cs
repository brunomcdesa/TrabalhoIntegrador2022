using Microsoft.EntityFrameworkCore;
using ProjetoPetShop.Model;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Servico> Servicos { get; set; }
        public PetContext(DbContextOptions<PetContext> opt) : base(opt) 
        {

        }
       
    }
}
