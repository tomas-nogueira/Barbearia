
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Salao> Salao { get; set; }
        public DbSet<ServiceSalao> ServiceSalao { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set;}
        
    }
}