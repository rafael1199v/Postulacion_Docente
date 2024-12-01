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

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<Docente> Docente { get; set; }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<JefeCarrera> JefeCarrera { get; set; }

    public virtual DbSet<MateriaCarrera> MateriaCarrera { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Postulacion> Postulacion { get; set; }

    public virtual DbSet<PostulacionVacante> PostulacionVacante { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vacante> Vacante { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__Carrera__3E43B1A1BB6362A8");

            entity.ToTable("Carrera");

            entity.HasIndex(e => e.Sigla, "UQ__Carrera__3199C5ED8F4D4A49").IsUnique();

            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.DocenteId).HasName("PK__Docente__9CB7A961AC4AE438");

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
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B000A011EBC");

            entity.ToTable("Estado");

            entity.Property(e => e.Mensaje)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JefeCarrera>(entity =>
        {
            entity.HasKey(e => e.JefeCarreraId).HasName("PK__JefeCarr__3D87A0162EAD0414");

            entity.ToTable("JefeCarrera");
        });

        modelBuilder.Entity<MateriaCarrera>(entity =>
        {
            entity.HasKey(e => e.MateriaCarreraId).HasName("PK__MateriaC__DB6CB49DF566533D");

            entity.ToTable("MateriaCarrera");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE155D04ECE");

            entity.HasIndex(e => e.Sigla, "UQ__Materia__3199C5ED9F6EE1E6").IsUnique();

            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Postulacion>(entity =>
        {
            entity.HasKey(e => e.PostulacionId).HasName("PK__Postulac__5F6D89A983A935DF");

            entity.ToTable("Postulacion");
        });

        modelBuilder.Entity<PostulacionVacante>(entity =>
        {
            entity.HasKey(e => e.PostulacionVacanteId).HasName("PK__Postulac__A0FB21C6D16DA563");

            entity.ToTable("PostulacionVacante");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B89CC8FE47");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NumeroTelefono, "UQ__Usuario__0DC3DBF549B1D57D").IsUnique();

            entity.HasIndex(e => e.Ci, "UQ__Usuario__32149A7AAEEB8B8E").IsUnique();

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A190AC89888").IsUnique();

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
            entity.HasKey(e => e.VacanteId).HasName("PK__Vacante__4CFFE269761F2EF0");

            entity.ToTable("Vacante");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.NombreVacante)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
