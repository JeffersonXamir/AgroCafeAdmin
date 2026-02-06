using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Inventario;
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

        #region DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Finca> Fincas { get; set; }
        public DbSet<Variedad> Variedad { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Labor> Labores { get; set; }
        public DbSet<Plaga> Plagas { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Calidad> Calidad { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Table Name

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

            modelBuilder.Entity<Labor>(entity =>
            {
                entity.ToTable("BIT_Labores");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Plaga>(entity =>
            {
                entity.ToTable("BIT_Plagas");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.ToTable("BIT_Bitacoras");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Calidad>(entity =>
            {
                entity.ToTable("INV_Calidades");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.ToTable("INV_Unidades");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.ToTable("INV_Lotes");
                entity.HasKey(u => u.Id);

            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("INV_Movimientos");
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

            // Seed Labores
            modelBuilder.Entity<Labor>().HasData(
                new Labor { Id = 1, Nombre = "Siembra" },
                new Labor { Id = 2, Nombre = "Fertilización" },
                new Labor { Id = 3, Nombre = "Poda" },
                new Labor { Id = 4, Nombre = "Deshierbe" },
                new Labor { Id = 5, Nombre = "Cosecha" }
            );

            // Seed Plagas
            modelBuilder.Entity<Plaga>().HasData(
                new Plaga { Id = 1, Nombre = "Roya" },
                new Plaga { Id = 2, Nombre = "Broca" },
                new Plaga { Id = 3, Nombre = "Ojo de Gallo" },
                new Plaga { Id = 4, Nombre = "Minador" }
            );

            // En OnModelCreating:
            modelBuilder.Entity<Calidad>().HasData(
                new Calidad { Id = 1, Nombre = "Primera" },
                new Calidad { Id = 2, Nombre = "Segunda" },
                new Calidad { Id = 3, Nombre = "Descarte" }
            );

            modelBuilder.Entity<Unidad>().HasData(
                new Unidad { Id = 1, Codigo = "qq", Nombre = "Quintales" },
                new Unidad { Id = 2, Codigo = "kg", Nombre = "Kilos" },
                new Unidad { Id = 3, Codigo = "lb", Nombre = "Libras" }
            );

            #endregion
        }
    }
}
