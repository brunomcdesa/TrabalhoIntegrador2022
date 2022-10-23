using Microsoft.EntityFrameworkCore;
using ProjetoPetShop.Model;
using System.Collections.Generic;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public PetContext(DbContextOptions<PetContext> opt) : base(opt)
        {

        }
    }
}
