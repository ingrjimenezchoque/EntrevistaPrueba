#region Imports
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#endregion

namespace Prueba_HPTP.Models
{
    public partial class PruebaContext : DbContext
    {
        public virtual DbSet<Employe> Employe { get; set; }

        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>(entity =>
            {
                entity.Property(e => e.Adicional1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adicional2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNumber)
                    .HasColumnName("Document_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Profile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 2)");
            });
        }
    }
}
