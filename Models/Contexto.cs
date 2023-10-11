
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Models
{
    public class Contexto : DbContext
    {
<<<<<<< HEAD
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        { 
        
        }
        public DbSet<Agendamento> Agendamento { get; set;}
        public DbSet<Salao> Salao { get; set;}  
        public DbSet<ServiceSalao> ServiceSalao { get; set;}
        public DbSet<TypeService> TypeService { get; set;}
        public DbSet<TypeUser> TypeUser { get; set;}
        public DbSet<User> User { get; set; }
=======
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Salao> Salao { get; set; }
        public DbSet<ServiceSalao> ServiceSalao { get; set; }
        public DbSet<TypeService> TypeService { get; set; }
        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<User> User { get; set; }
        
>>>>>>> 944d1af4c2cbf5fc84c03b032d9a853b0e168d82
    }
}