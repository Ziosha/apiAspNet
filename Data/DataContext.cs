using apiprueba.Models;
using Microsoft.EntityFrameworkCore;


namespace apiprueba.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Nacimiento> Nacimientos { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserRol> UserRols { get; set; }

       


        
    }
}