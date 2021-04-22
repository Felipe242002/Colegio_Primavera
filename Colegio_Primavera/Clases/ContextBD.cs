using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Colegio_Primavera.Clases
{
    public partial class ContextBD : DbContext
    {
        public ContextBD()
            : base("name=ContextBD")
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cursos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.Alumnos)
                .WithRequired(e => e.Cursos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .HasMany(e => e.Cursos)
                .WithRequired(e => e.Profesores)
                .WillCascadeOnDelete(false);
        }
    }
}
