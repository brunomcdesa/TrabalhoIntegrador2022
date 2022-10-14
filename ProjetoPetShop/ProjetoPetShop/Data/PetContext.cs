using Microsoft.EntityFrameworkCore;

namespace ProjetoPetShop.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> opt) : base(opt)
        {

        }
    }
}
