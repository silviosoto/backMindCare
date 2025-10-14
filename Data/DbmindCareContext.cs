using Azure;
using Data.Models;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

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
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Perfil> Perfil { get; set; }
    public virtual DbSet<Hobbies> Hobbies { get; set; }
    public virtual DbSet<Agenda> Agenda { get; set; }
    public virtual DbSet<Cita> Cita { get; set; }
    public virtual DbSet<Sala> Sala { get; set; }
    public virtual DbSet<PayUConfirmation> PayUConfirmation { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    public DbSet<Pagos> Pagos { get; set; }
    public DbSet<Terapia> Terapia { get; set; }
    public DbSet<carrito_de_compra> carrito_de_compra { get; set; }

    public DbSet<HistoriaClinica> HistoriaClinica { get; set; }
    public DbSet<SignosFisicos> SignosFisicos { get; set; }
    public DbSet<MentalPersonal> MentalPersonal { get; set; }
    public DbSet<HistoriaAcademica> HistoriaAcademica { get; set; }
    public DbSet<RazonesSintomasConducta> RazonesSintomasConducta { get; set; }
    public DbSet<DesarrolloPsicosexual> DesarrolloPsicosexual { get; set; }
    public DbSet<ExamenEstadoMental> ExamenEstadoMental { get; set; }
    public DbSet<ConceptoPsicologico> ConceptoPsicologico { get; set; }

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


        modelBuilder.Entity<PayUConfirmation>(entity =>
        {
            //entity.HasKey(e => e.Id).HasName("PK__Agenda__3214EC07EFBA9345");

            entity.ToTable("PayUConfirmations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MerchantId).HasColumnName("merchantid");
            entity.Property(e => e.StatePol).HasColumnName("statepol");
            entity.Property(e => e.ResponseCodePol).HasColumnName("responsecodepol");
            entity.Property(e => e.PaymentMethodType).HasColumnName("paymentmethodtype");
            //entity.Property(e => e.Value).HasPrecision(18, 2);
            entity.Property(e => e.Currency).HasColumnName("currency");
            entity.Property(e => e.ReferenceSale).HasColumnName("referencesale");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.RawBody).HasColumnName("rawBody");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

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
            entity.HasOne(e => e.DatosPersonale)
                .WithOne(e => e.Paciente)
                .HasForeignKey<Paciente>(d => d.IdDatosPersonales )
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
            entity.Property(e => e.ImagePerfil)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ImagePerfil");

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
            entity.Property(e => e.Valor).HasColumnName("valor");

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


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FFA64AA69");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.IdDatosPersonales).HasColumnName("id_datos_personales");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.HasOne(d => d.IdDatosPersonalesNavigation)
                .WithOne(p => p.User)
                .HasForeignKey<User>(d => d.IdDatosPersonales)
                .HasConstraintName("FK_user_persona");
            
            entity.Property(e => e.idPerfil).HasColumnName("id_perfil");
            modelBuilder.Entity<User>()
            .HasOne(u => u.Perfil)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.idPerfil); // Clave foránea

        });

        modelBuilder.Entity<Hobbies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hobbies__3213E83FAE9B75BC");

            entity.ToTable("Hobbies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(u => u.User) // Un User tiene un UserProfile
            .WithOne(up => up.Hobbies) // Un UserProfile tiene un User
            .HasForeignKey<Hobbies>(up => up.IdUser);
            
            entity.Property(e => e.IdDatosPersonales).HasColumnName("iddatospersonales");
            //entity.HasOne(d => d.IdDatosPersonalesNavigation)
            //    .WithMany(p => p.Hobbies)
            //    .HasForeignKey<Hobbies>(d => d.IdDatosPersonales)
            //    .HasConstraintName("FK_hobbies_datospersonales");


            entity.HasOne(d => d.IdDatosPersonalesNavigation).WithMany(p => p.Hobbies)
                .HasForeignKey(d => d.IdDatosPersonales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hobbies_datospersonales");
        });


        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agenda__3214EC07EFBA9345");

            entity.ToTable("Agenda");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaSemana).HasColumnName("DiaSemana");
    
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.Idpsicologo).HasColumnName("Idpsicologo");
            entity.HasOne(d => d.IdPsicologoNavigation)
                .WithOne(p => p.Agenda)
                .HasForeignKey<Agenda>(d => d.Idpsicologo)
                .HasConstraintName("FK_agenda_psicologo");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cita__3214EC07E7201A27");

            entity.ToTable("Cita");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idpaciente).HasColumnName("Idpaciente");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.Idpsicologo).HasColumnName("Idpsicologo");
            
            modelBuilder.Entity<Cita>()
                .HasOne(u => u.psicologo)  
                .WithOne(p => p.cita)  
                .HasForeignKey<Cita>(p => p.Idpsicologo); // Clave foránea
           
            entity.Property(e => e.Idservicio).HasColumnName("Idservicio");
            modelBuilder.Entity<Cita>()
                .HasOne(u => u.servicio)
                .WithOne(p => p.cita)
                .HasForeignKey<Cita>(p => p.Idservicio); // Clave foránea

            entity.Property(e => e.Idterapia).HasColumnName("Idterapia");
             

        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sala__3214EC0779310298");

            entity.ToTable("Sala");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.fechahora).HasColumnType("datetime");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.UrlHost)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("urlhost");
            entity.Property(e => e.TokenHost)
                .IsUnicode(false)
                .HasColumnName("tokenHost");
            entity.Property(e => e.UrlHuesped)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("urlhuesped");
            entity.Property(e => e.TokenHuesped)
                .IsUnicode(false)
                .HasColumnName("tokenHuesped");
            entity.Property(e => e.IdCita).HasColumnName("IdCita");
            modelBuilder.Entity<Sala>()
            .HasOne(u => u.cita)  
            .WithOne(p => p.sala) 
            .HasForeignKey<Sala>(p => p.IdCita); // Clave foránea


        });


        modelBuilder.Entity<Factura>(entity =>
        {
            entity.ToTable("Factura");

            entity.HasKey(f => f.Id);
            entity.Property(f => f.NumeroFactura)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.Property(f => f.FechaEmision)
                  .IsRequired();

            entity.Property(f => f.Subtotal)
                  .HasColumnType("decimal(18,2)");

            entity.Property(f => f.Iva)
                  .HasColumnType("decimal(18,2)");

            entity.Property(f => f.Total)
                  .HasColumnType("decimal(18,2)");

            entity.Property(f => f.Estado)
                  .IsRequired();

            // Relaciones
            entity.HasOne(f => f.Paciente)
                  .WithMany()
                  .HasForeignKey(f => f.idPaciente);

            entity.HasMany(f => f.FacturaDetalle)
                  .WithOne(d => d.Factura)
                  .HasForeignKey(d => d.IdFactura);
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Descripcion)
                  .HasMaxLength(100);

            entity.Property(d => d.ValorUnitario)
                  .HasColumnType("decimal(18,2)");

            entity.Property(d => d.Iva)
                  .HasColumnType("decimal(18,2)");

            entity.Property(d => d.Total)
                  .HasColumnType("decimal(18,2)");

            // Relación con Servicio
            entity.HasOne(d => d.Servicio)
                  .WithMany(s => s.FacturaDetalles)
                  .HasForeignKey(d => d.IdServicio);  // No eliminar servicios usados en facturas
           
            entity.HasOne(d => d.Terapia)
                  .WithMany()
                  .HasForeignKey(d => d.IdTerapia);

            entity.Property(e => e.ispackage).HasColumnName("ispackage");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.TipoPago)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.Property(p => p.Monto)
                  .HasColumnType("decimal(18,2)");

            entity.Property(p => p.FechaPago)
                  .IsRequired();

            entity.Property(p => p.Estado)
                  .IsRequired()
                  .HasMaxLength(20);

            // Relaciones
            entity.HasOne(p => p.Psicologo)
                  .WithMany()
                  .HasForeignKey(p => p.PsicologoId);

            entity.HasOne(p => p.Factura)
                  .WithMany()
                  .HasForeignKey(p => p.FacturaId);
                  

        });

        modelBuilder.Entity<Terapia>(entity =>
        {
            entity.ToTable("Terapia");

            entity.HasKey(f => f.Id);
            // Relaciones
            entity.HasOne(f => f.Paciente)
                  .WithMany()
                  .HasForeignKey(f => f.idPaciente);
            
            entity.HasOne(f => f.Psicologo)
                  .WithMany()
                  .HasForeignKey(f => f.Idpsicologo);

            entity.HasOne(f => f.Servicio)
              .WithMany()
              .HasForeignKey(f => f.Idservicio);

            entity.Property(f => f.valor)
                  .HasColumnType("decimal(18,2)");
            
            entity.Property(f => f.NumeroSesiones)
                  .HasColumnName("NumeroSesiones")
                  .IsRequired();
            
            entity.Property(f => f.IdUsuarioCreacion)
                  .HasColumnName("IdUsuarioCreacion")
                  .IsRequired();

            entity.Property(f => f.FechaCreacion)
                  .HasColumnName("FechaCreacion")
                  .HasColumnType("datetime");
                  //.IsRequired();

            entity.Property(f => f.FechaActualizacion)
                  .HasColumnName("FechaActualizacion");
                  //.IsRequired();

            entity.Property(f => f.IdUsuarioActualizacion)
                    .HasColumnName("IdUsuarioActualizacion")
                    .IsRequired();

            entity.Property(f => f.Estado)
                  .IsRequired();
        });

        modelBuilder.Entity<carrito_de_compra>(entity =>
        {
            entity.ToTable("carrito_de_compra"); 

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("Id");

            entity.HasOne(f => f.Psicologo)
                .WithMany()
                .HasForeignKey(f => f.IdPsicologo);

            entity.HasOne(f => f.Paciente)
                .WithMany()
                .HasForeignKey(f => f.IdPaciente);

            entity.HasOne(f => f.Servicio)
                .WithMany()
                .HasForeignKey(f => f.IdServicio);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Hora).HasColumnType("time");

            entity.Property(e => e.EsPaquete)
                .HasColumnName("Es_Paquete")
                .HasDefaultValue(false);

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.ValorServicio)
                .HasColumnName("ValorServicio")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.NumeroSesiones)
                .HasColumnName("Numero_Sesiones");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");
             
            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.IdUsuarioCreacion);

            entity.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.IdUsuarioActualizacion);
        });

        modelBuilder.Entity<HistoriaClinica>(entity =>
        {
            entity.ToTable("HISTORIA_CLINICA");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Estado)
                .HasColumnName("estado")
                .IsRequired();

            entity.Property(e => e.IdPaciente)
                .HasColumnName("IdPaciente");

            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HISTORIA_CLINICA_paciente");

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HISTORIA_CLINICA_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HISTORIA_CLINICA_usario_actualizacion");
        });

        // Configuración para SignosFisicos
        modelBuilder.Entity<SignosFisicos>(entity =>
        {
            entity.ToTable("SIGNOS_FISICOS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.Laceraciones)
                .HasColumnName("LACERACIONES")
                .HasMaxLength(500);

            entity.Property(e => e.Hematoma)
                .HasColumnName("HEMATOMA")
                .HasMaxLength(500);

            entity.Property(e => e.Quemaduras)
                .HasColumnName("QUEMADURAS")
                .HasMaxLength(500);

            entity.Property(e => e.Cicatrices)
                .HasColumnName("CICATRICES")
                .HasMaxLength(500);

            entity.Property(e => e.Fracturas)
                .HasColumnName("FRACTURAS")
                .HasMaxLength(500);

            entity.Property(e => e.Observaciones)
                .HasColumnName("OBSERVACIONES")
                .HasMaxLength(1000);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.SignosFisicos)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SIGNOS_FISICOS_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SIGNOS_FISICOS_usario_actualizacion");
        });

        // Configuración para MentalPersonal
        modelBuilder.Entity<MentalPersonal>(entity =>
        {
            entity.ToTable("MENTAL_PERSONAL");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.DiscapacidadCognitiva)
                .HasColumnName("DISCAPACIDAD_COGNITIVA")
                .HasMaxLength(500);

            entity.Property(e => e.Epilepsia)
                .HasColumnName("EPILEPSIA")
                .HasMaxLength(500);

            entity.Property(e => e.EnfermedadesFamiliaresHeredables)
                .HasColumnName("ENFERMEDADES_FAMILIARES_HEREDABLES")
                .HasMaxLength(500);

            entity.Property(e => e.ConsumoDeSustanciasPsicoactivas)
                .HasColumnName("CONSUMO_DE_SUSTANCIAS_PSICOACTIVAS")
                .HasMaxLength(500);

            entity.Property(e => e.ConsumoDeAlcohol)
                .HasColumnName("CONSUMO_DE_ALCOHOL")
                .HasMaxLength(500);

            entity.Property(e => e.DxDeSaludMental)
                .HasColumnName("DX_DE_SALUD_MENTAL")
                .HasMaxLength(500);

            entity.Property(e => e.IntentoDeSuicidio)
                .HasColumnName("INTENTO_DE_SUICIDIO")
                .HasMaxLength(500);

            entity.Property(e => e.EventosTraumaticos)
                .HasColumnName("EVENTOS_TRAUMATICOS")
                .HasMaxLength(500);

            entity.Property(e => e.SeEncuentraMedicado)
                .HasColumnName("SE_ENCUENTRA_MEDICADO")
                .HasMaxLength(500);

            entity.Property(e => e.AntecedentesDeAutolesion)
                .HasColumnName("ANTECEDENTES_DE_AUTOLESION")
                .HasMaxLength(500);

            entity.Property(e => e.InternacionesEnCentrosPsiquiatricos)
                .HasColumnName("INTERNACIONES_EN_CENTROS_PSIQUIATRICOS")
                .HasMaxLength(500);

            entity.Property(e => e.Observaciones)
                .HasColumnName("OBSERVACIONES")
                .HasMaxLength(1000);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.MentalPersonal)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MENTAL_PERSONAL_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MENTAL_PERSONAL_usario_actualizacion");
        });

        // Configuración para HistoriaAcademica
        modelBuilder.Entity<HistoriaAcademica>(entity =>
        {
            entity.ToTable("HISTORIA_ACADEMICA");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.EdadDeIngresoALaEscuela)
                .HasColumnName("EDAD_DE_INGRESO_A_LA_ESCUELA")
                .HasMaxLength(100);

            entity.Property(e => e.AdaptacionInicial)
                .HasColumnName("ADAPTACION_INICIAL")
                .HasMaxLength(500);

            entity.Property(e => e.DesempenoAcademico)
                .HasColumnName("DESEMPENO_ACADEMICO")
                .HasMaxLength(500);

            entity.Property(e => e.AnosPerdidos)
                .HasColumnName("ANOS_PERDIDOS")
                .HasMaxLength(100);

            entity.Property(e => e.CursoActual)
                .HasColumnName("CURSO_ACTUAL")
                .HasMaxLength(100);

            entity.Property(e => e.MateriaQueSeFacilitaYLaQueSeDificulta)
                .HasColumnName("MATERIA_QUE_SE_FACILITA_Y_LA_QUE_SE_DIFICULTA")
                .HasMaxLength(500);

            entity.Property(e => e.TiempoDiarioDeEstudioHoras)
                .HasColumnName("TIEMPO_DIARIO_DE_ESTUDIO_HORAS")
                .HasMaxLength(100);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.HistoriaAcademica)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HISTORIA_ACADEMICA_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HISTORIA_ACADEMICA_usario_actualizacion");
        });

        // Configuración para RazonesSintomasConducta
        modelBuilder.Entity<RazonesSintomasConducta>(entity =>
        {
            entity.ToTable("RAZONES_DE_SINTOMAS_CONDUCTA");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.RelacionadosAmbientesFamiliares)
                .HasColumnName("RELACIONADOS_AMBIENTES_FAMILIARES")
                .HasMaxLength(500);

            entity.Property(e => e.RelacionadosAmbienteSocial)
                .HasColumnName("RELACIONADOS_AMBIENTE_SOCIAL")
                .HasMaxLength(500);

            entity.Property(e => e.RelacionadosAmbientesAcademicos)
                .HasColumnName("RELACIONADOS_AMBIENTES_ACADEMICOS")
                .HasMaxLength(500);

            entity.Property(e => e.RelacionadosCaracteristicasDelIndividuo)
                .HasColumnName("RELACIONADOS_CARACTERISTICAS_DEL_INDIVIDUO")
                .HasMaxLength(500);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.RazonesSintomasConducta)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_actualizacion");
        });

        // Configuración para DesarrolloPsicosexual
        modelBuilder.Entity<DesarrolloPsicosexual>(entity =>
        {
            entity.ToTable("DESARROLLO_PSICOSEXUAL");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.EdadDeDesarrollo)
                .HasColumnName("EDAD_DE_DESARROLLO")
                .HasMaxLength(100);

            entity.Property(e => e.IdentidadSexual)
                .HasColumnName("IDENTIDAD_SEXUAL")
                .HasMaxLength(100);

            entity.Property(e => e.OrientacionSexual)
                .HasColumnName("ORIENTACION_SEXUAL")
                .HasMaxLength(100);

            entity.Property(e => e.EdadDeInicioDeRelacionesSexuales)
                .HasColumnName("EDAD_DE_INICIO_DE_RELACIONES_SEXUALES")
                .HasMaxLength(100);

            entity.Property(e => e.UsoDeMetodosDePlanificacion)
                .HasColumnName("USO_DE_METODOS_DE_PLANIFICACION")
                .HasMaxLength(100);

            entity.Property(e => e.HaSidoVictimaDeAbusoSexual)
                .HasColumnName("HA_SIDO_VICTIMA_DE_ABUSO_SEXUAL")
                .HasMaxLength(100);

            entity.Property(e => e.EnfermedadesDeTransmisionSexual)
                .HasColumnName("ENFERMEDADES_DE_TRANSMISION_SEXUAL")
                .HasMaxLength(500);

            entity.Property(e => e.MadreOPadreAdolescente)
                .HasColumnName("MADRE_O_PADRE_ADOLESCENTE")
                .HasMaxLength(100);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.DesarrolloPsicosexual)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DESARROLLO_PSICOSEXUAL_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DESARROLLO_PSICOSEXUAL_usario_actualizacion");
        });

        // Configuración para ExamenEstadoMental
        modelBuilder.Entity<ExamenEstadoMental>(entity =>
        {
            entity.ToTable("EXAMEN_DE_ESTADO_MENTAL");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.NivelDeConciencia)
                .HasColumnName("NIVEL_DE_CONCIENCIA")
                .HasMaxLength(500);

            entity.Property(e => e.Atencion)
                .HasColumnName("ATENCION")
                .HasMaxLength(500);

            entity.Property(e => e.Sensopercepcion)
                .HasColumnName("SENSOPERCEPCION")
                .HasMaxLength(500);

            entity.Property(e => e.Afecto)
                .HasColumnName("AFECTO")
                .HasMaxLength(500);

            entity.Property(e => e.Lenguaje)
                .HasColumnName("LENGUAJE")
                .HasMaxLength(500);

            entity.Property(e => e.Orientacion)
                .HasColumnName("ORIENTACION")
                .HasMaxLength(500);

            entity.Property(e => e.Sueno)
                .HasColumnName("SUENO")
                .HasMaxLength(500);

            entity.Property(e => e.Pensamiento)
                .HasColumnName("PENSAMIENTO")
                .HasMaxLength(500);

            entity.Property(e => e.ConductaMotora)
                .HasColumnName("CONDUCTA_MOTORA")
                .HasMaxLength(500);

            entity.Property(e => e.Memoria)
                .HasColumnName("MEMORIA")
                .HasMaxLength(500);

            entity.Property(e => e.PatronDeAlimentacion)
                .HasColumnName("PATRON_DE_ALIMENTACION")
                .HasMaxLength(500);

            entity.Property(e => e.Inteligencia)
                .HasColumnName("INTELIGENCIA")
                .HasMaxLength(500);

            entity.Property(e => e.NivelDeRazonamiento)
                .HasColumnName("NIVEL_DE_RAZONAMIENTO")
                .HasMaxLength(500);

            entity.Property(e => e.PorteYActitud)
                .HasColumnName("PORTE_Y_ACTITUD")
                .HasMaxLength(500);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.ExamenEstadoMental)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EXAMEN_DE_ESTADO_MENTAL_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EXAMEN_DE_ESTADO_MENTAL_usario_actualizacion");
        });

        // Configuración para ConceptoPsicologico
        modelBuilder.Entity<ConceptoPsicologico>(entity =>
        {
            entity.ToTable("CONCEPTO_PSICOLOGICO");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.IdHistoriaClinica)
                .HasColumnName("id_historia_clinica")
                .IsRequired();

            entity.Property(e => e.DiagnosticoPrincipal)
                .HasColumnName("DIAGNOSTICO_PRINCIPAL")
                .HasMaxLength(500);

            entity.Property(e => e.DiagnosticoRelacionado1)
                .HasColumnName("DIAGNOSTICO_RELACIONADO_1")
                .HasMaxLength(500);

            entity.Property(e => e.DiagnosticoRelacionado2)
                .HasColumnName("DIAGNOSTICO_RELACIONADO_2")
                .HasMaxLength(500);

            entity.Property(e => e.PlanDeTratamiento)
                .HasColumnName("PLAN_DE_TRATAMIENTO")
                .HasMaxLength(1000);

            entity.Property(e => e.Objetivos)
                .HasColumnName("OBJETIVOS")
                .HasMaxLength(1000);

            entity.Property(e => e.Recomendaciones)
                .HasColumnName("RECOMENDACIONES")
                .HasMaxLength(1000);

            entity.Property(e => e.Compromisos)
                .HasColumnName("COMPROMISOS")
                .HasMaxLength(1000);

            // Campos de auditoría
            entity.Property(e => e.IdUsuarioCreacion)
                .HasColumnName("IdUsuarioCreacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime");

            entity.Property(e => e.IdUsuarioActualizacion)
                .HasColumnName("IdUsuarioActualizacion");

            // Relaciones
            entity.HasOne(e => e.HistoriaClinica)
                .WithMany(hc => hc.ConceptoPsicologico)
                .HasForeignKey(e => e.IdHistoriaClinica)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            entity.HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CONCEPTO_PSICOLOGICO_usario_creacion");

            entity.HasOne(e => e.UsuarioActualizacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CONCEPTO_PSICOLOGICO_usario_actualizacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
