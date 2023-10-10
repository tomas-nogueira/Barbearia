using Microsoft.EntityFrameworkCore;

namespace Barbearia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        { 
            
        }
    }
}
