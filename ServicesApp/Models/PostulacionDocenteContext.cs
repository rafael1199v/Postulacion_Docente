using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostulacionDocente.ServicesApp.Models;

public partial class PostulacionDocenteContext : DbContext
{
    // public PostulacionDocenteContext()
    // {
    // }

    public PostulacionDocenteContext(DbContextOptions<PostulacionDocenteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<JefeCarrera> JefeCarreras { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Postulacion> Postulacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vacante> Vacantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__Carrera__3E43B1A132BE7DDB");

            entity.ToTable("Carrera");

            entity.HasIndex(e => e.Sigla, "UQ__Carrera__3199C5EDB7DEF867").IsUnique();

            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.JefeCarrera).WithMany(p => p.Carreras)
                .HasForeignKey(d => d.JefeCarreraId)
                .HasConstraintName("FK_JefeCarrera_Carrera");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.DocenteId).HasName("PK__Docente__9CB7A961BE7B20A5");

            entity.ToTable("Docente");

            entity.Property(e => e.DescripcionPersonal)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Grado)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Docente");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B00032FE955");

            entity.ToTable("Estado");

            entity.Property(e => e.Mensaje)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JefeCarrera>(entity =>
        {
            entity.HasKey(e => e.JefeCarreraId).HasName("PK__JefeCarr__3D87A0166D6D2996");

            entity.ToTable("JefeCarrera");

            entity.HasOne(d => d.Usuario).WithMany(p => p.JefeCarreras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_JefeCarrera");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE1DC16A541");

            entity.HasIndex(e => e.Sigla, "UQ__Materia__3199C5ED98297A51").IsUnique();

            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasMany(d => d.Carreras).WithMany(p => p.Materia)
                .UsingEntity<Dictionary<string, object>>(
                    "MateriaCarrera",
                    r => r.HasOne<Carrera>().WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Carrera_MateriaCarrera"),
                    l => l.HasOne<Materium>().WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Materia_MateriaCarrera"),
                    j =>
                    {
                        j.HasKey("MateriaId", "CarreraId");
                        j.ToTable("MateriaCarrera");
                    });
        });

        modelBuilder.Entity<Postulacion>(entity =>
        {
            entity.HasKey(e => e.PostulacionId).HasName("PK__Postulac__5F6D89A99839CCC3");

            entity.ToTable("Postulacion");

            entity.HasOne(d => d.Docente).WithMany(p => p.Postulacions)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Docente_Postulacion");

            entity.HasOne(d => d.Estado).WithMany(p => p.Postulacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estado_Postulacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B89D9A9288");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NumeroTelefono, "UQ__Usuario__0DC3DBF5C975F673").IsUnique();

            entity.HasIndex(e => e.Ci, "UQ__Usuario__32149A7A63B9DC5A").IsUnique();

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A191AD0A70A").IsUnique();

            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.Contrasenha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vacante>(entity =>
        {
            entity.HasKey(e => e.VacanteId).HasName("PK__Vacante__4CFFE26953C94367");

            entity.ToTable("Vacante");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.NombreVacante)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Materia).WithMany(p => p.Vacantes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materia_Vacante");

            entity.HasMany(d => d.Postulacions).WithMany(p => p.Vacantes)
                .UsingEntity<Dictionary<string, object>>(
                    "PostulacionVacante",
                    r => r.HasOne<Postulacion>().WithMany()
                        .HasForeignKey("PostulacionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Postulacion_PostulacionVacante"),
                    l => l.HasOne<Vacante>().WithMany()
                        .HasForeignKey("VacanteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Vacante_PostulacionVacante"),
                    j =>
                    {
                        j.HasKey("VacanteId", "PostulacionId");
                        j.ToTable("PostulacionVacante");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
