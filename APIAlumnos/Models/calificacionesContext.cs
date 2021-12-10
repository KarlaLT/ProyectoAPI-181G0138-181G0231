using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIAlumnos.Models
{
    public partial class calificacionesContext : DbContext
    {
        public calificacionesContext()
        {
        }

        public calificacionesContext(DbContextOptions<calificacionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Cnev1)
                    .HasColumnName("CNEv1")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cnev2)
                    .HasColumnName("CNEv2")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cnev3)
                    .HasColumnName("CNEv3")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EspanolEv1).HasDefaultValueSql("'0'");

                entity.Property(e => e.EspanolEv2).HasDefaultValueSql("'0'");

                entity.Property(e => e.EspanolEv3).HasDefaultValueSql("'0'");

                entity.Property(e => e.MatematicasEv1).HasDefaultValueSql("'0'");

                entity.Property(e => e.MatematicasEv2).HasDefaultValueSql("'0'");

                entity.Property(e => e.MatematicasEv3).HasDefaultValueSql("'0'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PromCn)
                    .HasColumnName("PromCN")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PromEspanol).HasDefaultValueSql("'0'");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
