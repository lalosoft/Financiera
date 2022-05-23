using System;
using AppFinanciera.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppFinanciera.API.Model
{
    public partial class FinancieraContext : DbContext
    {
        public FinancieraContext()
        {
        }

        public FinancieraContext(DbContextOptions<FinancieraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CuentaAhorro> CuentaAhorros { get; set; }
        public virtual DbSet<CuentaCliente> CuentaClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ContextConfiguration.ConecctionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CuentaAhorro>(entity =>
            {
                entity.ToTable("CuentaAhorro");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CuentaAhorros)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cta_Ahorro_Cte");
            });

            modelBuilder.Entity<CuentaCliente>(entity =>
            {
                entity.ToTable("CuentaCliente");

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CuentaClientes)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cte_Cta");

                entity.HasOne(d => d.CuentaNavigation)
                    .WithMany(p => p.CuentaClientes)
                    .HasForeignKey(d => d.Cuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cta_Ahorro_Cta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
