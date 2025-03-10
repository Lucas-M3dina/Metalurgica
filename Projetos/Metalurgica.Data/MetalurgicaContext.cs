using Metalurgica.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Metalurgica.Data
{
    public class MetalurgicaContext(DbContextOptions<MetalurgicaContext> options) : DbContext(options)
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Embalagem> Embalagem { get; set; }
        public DbSet<ProdutoEmbalagem> ProdutoEmbalagem { get; set; }
        public DbSet<Quesito> Quesito { get; set; }
        public DbSet<ProdutoQuesito> ProdutoQuesito { get; set; }

    }
}
