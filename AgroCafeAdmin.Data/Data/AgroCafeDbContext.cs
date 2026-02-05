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
        public DbSet<Variedad> Variedad { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region DbSet

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

            modelBuilder.Entity<Variedad>(entity =>
            {
                entity.ToTable("PRO_Variedades");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.ToTable("PRO_Parcelas");
                entity.HasKey(u => u.Id);

            });
            #endregion

            #region Semillas
            // Datos semilla (seed data)
            modelBuilder.Entity<Variedad>().HasData(
                new Variedad { Id = 1, Nombre = "Arábica", Anulado = false },
                new Variedad { Id = 2, Nombre = "Robusta", Anulado = false },
                new Variedad { Id = 3, Nombre = "Caturra", Anulado = false },
                new Variedad { Id = 4, Nombre = "Borbón", Anulado = false },
                new Variedad { Id = 5, Nombre = "Típica", Anulado = false }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Codigo = "0001", Nombre = "Administrador", Anulado = false },
                new Roles { Id = 2, Codigo = "0002", Nombre = "Productor", Anulado = false },
                new Roles { Id = 3, Codigo = "0003", Nombre = "Cliente", Anulado = false }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Codigo = "Admin", Nombre = "Administrador", Apellido = "Sistemas", Email = "AgroCafe@gmail.com", Cedula = "0924876014001", Contrasenia = "123456", RolId = 1, Anulado = false, FechaCreacion = DateTime.Parse("2026/02/04"), FechaActualizacion = DateTime.Parse("2026/02/04") }
            );


            #endregion
        }
    }
}
