using AgroCafeAdmin.Core.Models.Seguridad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Data.Data
{
    public class AgroCafeDbContext : DbContext
    {
        public AgroCafeDbContext(DbContextOptions<AgroCafeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Usuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("SEC_Usuarios");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("SEC_Roles");
                entity.HasKey(u => u.Id);

            });
        }
    }
}
