using Microsoft.EntityFrameworkCore;

namespace Checkpoint2Humberto.Models
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }
    }
}
