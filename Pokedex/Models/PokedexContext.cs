using Microsoft.EntityFrameworkCore;

namespace PokedexApi.Models
{
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonItem> PokemonItems { get; set; }
    }
}