using System;
using System.Collections.Generic;
using System.Configuration;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class DbmindCareContext : DbContext
{
    public DbmindCareContext()
    {
    }

    public DbmindCareContext(DbContextOptions<DbmindCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Psicologo> Psicologos { get; set; }

    public virtual DbSet<PsicologoEspecialidad> PsicologoEspecialidads { get; set; }

    public virtual DbSet<PsicologoServicio> PsicologoServicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosPersonale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__datos_pe__3213E83F9EE094A3");

            entity.ToTable("datos_personales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.MunicipiosId).HasColumnName("municipios_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("telefono");
            entity.Property(e => e.TipoId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipo_id");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_departamento");

            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__especial__3213E83F6D6BED28");

            entity.ToTable("especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Validado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("validado");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__idiomas__3213E83F25844C9A");

            entity.ToTable("idioma");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__municipi__01C9EB99A83DE567");

            entity.ToTable("municipio");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__paciente__3213E83FA85C8254");

            entity.ToTable("paciente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdDatosPersonales).HasColumnName("id_datos_personales");

            entity.HasOne(d => d.IdDatosPersonalesNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDatosPersonales)
                .HasConstraintName("FK_paciente_datos_personales");
        });

        modelBuilder.Entity<Psicologo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__psicolog__3213E83FD1565457");

            entity.ToTable("psicologo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Experiencia).HasColumnName("experiencia");
            entity.Property(e => e.File_cv)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("file_cv");
        
            entity.Property(e => e.IdDatosPersonales).HasColumnName("id_datos_personales");
            entity.Property(e => e.sugerencias)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("sugerencias");
            entity.Property(e => e.Validado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("validado");

            entity.HasOne(d => d.IdDatosPersonalesNavigation).WithMany(p => p.Psicologos)
                .HasForeignKey(d => d.IdDatosPersonales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psicologo_datos_personales");

    
        });

        modelBuilder.Entity<PsicologoEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__psicolog__3213E83F1D5424A2");

            entity.ToTable("psicologo_especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.IdPsicologo).HasColumnName("id_psicologo");
            entity.Property(e => e.Validado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("validado");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.PsicologoEspecialidads)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK_psicologo_especialidad_especialidad");

            entity.HasOne(d => d.IdPsicologoNavigation).WithMany(p => p.PsicologoEspecialidads)
                .HasForeignKey(d => d.IdPsicologo)
                .HasConstraintName("FK_psicologo_especialidad_psicologo");
        });

        modelBuilder.Entity<PsicologoServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__psicolog__3214EC07EB7DAE71");

            entity.ToTable("psicologo_servicios");

            entity.Property(e => e.IdPsicologo).HasColumnName("id_psicologo");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

            entity.HasOne(d => d.IdPsicologoNavigation).WithMany(p => p.PsicologoServicios)
                .HasForeignKey(d => d.IdPsicologo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psicologo_servicios_psicologo");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.PsicologoServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psicologo_servicios_servicio");
        });
        modelBuilder.Entity<PsicologoIdioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__psicolog__3214EC07431E6529");

            entity.ToTable("psicologo_idioma");

            entity.Property(e => e.IdPsicologo).HasColumnName("id_psicologo");
            entity.Property(e => e.IdIdioma).HasColumnName("id_idioma");

            entity.HasOne(d => d.IdPsicologoNavigation).WithMany(p => p.PsicologoIdiomas)
                .HasForeignKey(d => d.IdPsicologo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psicologo_idioma_psicologo");

            entity.HasOne(d => d.IdIdiomaNavigation).WithMany(p => p.PsicologoIdiomas)
                .HasForeignKey(d => d.IdIdioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_psicologo_idioma_idioma");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__servicio__3214EC07DF33398E");

            entity.ToTable("servicios");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
