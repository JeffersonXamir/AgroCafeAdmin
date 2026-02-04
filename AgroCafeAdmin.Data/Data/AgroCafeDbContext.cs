using AgroCafeAdmin.Core.Models.Productores;
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
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Finca> Fincas { get; set; }

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

            modelBuilder.Entity<Productor>(entity =>
            {
                entity.ToTable("PRO_Productores");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Finca>(entity =>
            {
                entity.ToTable("PRO_Fincas");
                entity.HasKey(u => u.Id);

            });
        }
    }
}
