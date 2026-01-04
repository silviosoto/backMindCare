using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixFacturaDetalleRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "datos_personales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    tipo_id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    numero_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    municipios_id = table.Column<int>(type: "int", nullable: true),
                    ImagePerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__datos_pe__3213E83F9EE094A3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "especialidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    validado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__especial__3213E83F6D6BED28", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "idioma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__idiomas__3213E83F25844C9A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    departamento_id = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__municipi__01C9EB99A83DE567", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PayUConfirmations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    merchantid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statepol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responsecodepol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentmethodtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referencesale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rawBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayUConfirmations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__servicio__3214EC07DF33398E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<bool>(type: "bit", unicode: false, maxLength: 100, nullable: true),
                    id_datos_personales = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paciente__3213E83FA85C8254", x => x.id);
                    table.ForeignKey(
                        name: "FK_paciente_datos_personales",
                        column: x => x.id_datos_personales,
                        principalTable: "datos_personales",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "psicologo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    validado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sugerencias = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    id_datos_personales = table.Column<int>(type: "int", nullable: false),
                    experiencia = table.Column<int>(type: "int", nullable: true),
                    file_cv = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    ImagePerfil = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    estado = table.Column<bool>(type: "bit", unicode: false, maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__psicolog__3213E83FD1565457", x => x.id);
                    table.ForeignKey(
                        name: "FK_psicologo_datos_personales",
                        column: x => x.id_datos_personales,
                        principalTable: "datos_personales",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    id_datos_personales = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3213E83FFA64AA69", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_persona",
                        column: x => x.id_datos_personales,
                        principalTable: "datos_personales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Cufe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonDian = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idpsicologo = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    mes = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agenda__3214EC07EFBA9345", x => x.id);
                    table.ForeignKey(
                        name: "FK_agenda_psicologo",
                        column: x => x.Idpsicologo,
                        principalTable: "psicologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idpsicologo = table.Column<int>(type: "int", nullable: false),
                    Idpaciente = table.Column<int>(type: "int", nullable: false),
                    Idterapia = table.Column<int>(type: "int", nullable: false),
                    Idservicio = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    pagado = table.Column<bool>(type: "bit", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cita__3214EC07E7201A27", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cita_psicologo_Idpsicologo",
                        column: x => x.Idpsicologo,
                        principalTable: "psicologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_servicios_Idservicio",
                        column: x => x.Idservicio,
                        principalTable: "servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "psicologo_especialidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_psicologo = table.Column<int>(type: "int", nullable: true),
                    id_especialidad = table.Column<int>(type: "int", nullable: true),
                    validado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__psicolog__3213E83F1D5424A2", x => x.id);
                    table.ForeignKey(
                        name: "FK_psicologo_especialidad_especialidad",
                        column: x => x.id_especialidad,
                        principalTable: "especialidad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_psicologo_especialidad_psicologo",
                        column: x => x.id_psicologo,
                        principalTable: "psicologo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "psicologo_idioma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_idioma = table.Column<int>(type: "int", nullable: false),
                    id_psicologo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__psicolog__3214EC07431E6529", x => x.Id);
                    table.ForeignKey(
                        name: "FK_psicologo_idioma_idioma",
                        column: x => x.id_idioma,
                        principalTable: "idioma",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_psicologo_idioma_psicologo",
                        column: x => x.id_psicologo,
                        principalTable: "psicologo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "psicologo_servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_servicio = table.Column<int>(type: "int", nullable: false),
                    id_psicologo = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__psicolog__3214EC07EB7DAE71", x => x.Id);
                    table.ForeignKey(
                        name: "FK_psicologo_servicios_psicologo",
                        column: x => x.id_psicologo,
                        principalTable: "psicologo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_psicologo_servicios_servicio",
                        column: x => x.id_servicio,
                        principalTable: "servicios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Terapia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    Idpsicologo = table.Column<int>(type: "int", nullable: false),
                    Idservicio = table.Column<int>(type: "int", nullable: false),
                    NumeroSesiones = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    espaquete = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terapia_paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terapia_psicologo_Idpsicologo",
                        column: x => x.Idpsicologo,
                        principalTable: "psicologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terapia_servicios_Idservicio",
                        column: x => x.Idservicio,
                        principalTable: "servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carrito_de_compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPsicologo = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    Es_Paquete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ValorServicio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Numero_Sesiones = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrito_de_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carrito_de_compra_User_IdUsuarioActualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_carrito_de_compra_paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carrito_de_compra_psicologo_IdPsicologo",
                        column: x => x.IdPsicologo,
                        principalTable: "psicologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carrito_de_compra_servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORIA_CLINICA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORIA_CLINICA", x => x.id);
                    table.ForeignKey(
                        name: "FK_HISTORIA_CLINICA_paciente",
                        column: x => x.IdPaciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HISTORIA_CLINICA_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HISTORIA_CLINICA_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    iddatospersonales = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hobbies__3213E83FAE9B75BC", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hobbies_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hobbies_datospersonales",
                        column: x => x.iddatospersonales,
                        principalTable: "datos_personales",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsicologoId = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: true),
                    NumeroSesion = table.Column<int>(type: "int", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_psicologo_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "psicologo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    urlhost = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    tokenHost = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    urlhuesped = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    tokenHuesped = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fechahora = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sala__3214EC0779310298", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sala_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdTerapia = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    ispackage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Factura_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Terapia_IdTerapia",
                        column: x => x.IdTerapia,
                        principalTable: "Terapia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONCEPTO_PSICOLOGICO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    DIAGNOSTICO_PRINCIPAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DIAGNOSTICO_RELACIONADO_1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DIAGNOSTICO_RELACIONADO_2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PLAN_DE_TRATAMIENTO = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OBJETIVOS = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RECOMENDACIONES = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    COMPROMISOS = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONCEPTO_PSICOLOGICO", x => x.id);
                    table.ForeignKey(
                        name: "FK_CONCEPTO_PSICOLOGICO_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONCEPTO_PSICOLOGICO_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONCEPTO_PSICOLOGICO_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESARROLLO_PSICOSEXUAL",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    EDAD_DE_DESARROLLO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDENTIDAD_SEXUAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ORIENTACION_SEXUAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EDAD_DE_INICIO_DE_RELACIONES_SEXUALES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    USO_DE_METODOS_DE_PLANIFICACION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HA_SIDO_VICTIMA_DE_ABUSO_SEXUAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ENFERMEDADES_DE_TRANSMISION_SEXUAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MADRE_O_PADRE_ADOLESCENTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESARROLLO_PSICOSEXUAL", x => x.id);
                    table.ForeignKey(
                        name: "FK_DESARROLLO_PSICOSEXUAL_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DESARROLLO_PSICOSEXUAL_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DESARROLLO_PSICOSEXUAL_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXAMEN_DE_ESTADO_MENTAL",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    NIVEL_DE_CONCIENCIA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ATENCION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SENSOPERCEPCION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AFECTO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LENGUAJE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ORIENTACION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SUENO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PENSAMIENTO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONDUCTA_MOTORA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MEMORIA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PATRON_DE_ALIMENTACION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    INTELIGENCIA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NIVEL_DE_RAZONAMIENTO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PORTE_Y_ACTITUD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAMEN_DE_ESTADO_MENTAL", x => x.id);
                    table.ForeignKey(
                        name: "FK_EXAMEN_DE_ESTADO_MENTAL_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAMEN_DE_ESTADO_MENTAL_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXAMEN_DE_ESTADO_MENTAL_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HISTORIA_ACADEMICA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    EDAD_DE_INGRESO_A_LA_ESCUELA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADAPTACION_INICIAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DESEMPENO_ACADEMICO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ANOS_PERDIDOS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CURSO_ACTUAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MATERIA_QUE_SE_FACILITA_Y_LA_QUE_SE_DIFICULTA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TIEMPO_DIARIO_DE_ESTUDIO_HORAS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORIA_ACADEMICA", x => x.id);
                    table.ForeignKey(
                        name: "FK_HISTORIA_ACADEMICA_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORIA_ACADEMICA_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HISTORIA_ACADEMICA_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MENTAL_PERSONAL",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    DISCAPACIDAD_COGNITIVA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EPILEPSIA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ENFERMEDADES_FAMILIARES_HEREDABLES = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONSUMO_DE_SUSTANCIAS_PSICOACTIVAS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CONSUMO_DE_ALCOHOL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DX_DE_SALUD_MENTAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    INTENTO_DE_SUICIDIO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EVENTOS_TRAUMATICOS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SE_ENCUENTRA_MEDICADO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ANTECEDENTES_DE_AUTOLESION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    INTERNACIONES_EN_CENTROS_PSIQUIATRICOS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OBSERVACIONES = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENTAL_PERSONAL", x => x.id);
                    table.ForeignKey(
                        name: "FK_MENTAL_PERSONAL_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MENTAL_PERSONAL_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MENTAL_PERSONAL_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RAZONES_DE_SINTOMAS_CONDUCTA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    RELACIONADOS_AMBIENTES_FAMILIARES = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RELACIONADOS_AMBIENTE_SOCIAL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RELACIONADOS_AMBIENTES_ACADEMICOS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RELACIONADOS_CARACTERISTICAS_DEL_INDIVIDUO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAZONES_DE_SINTOMAS_CONDUCTA", x => x.id);
                    table.ForeignKey(
                        name: "FK_RAZONES_DE_SINTOMAS_CONDUCTA_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RAZONES_DE_SINTOMAS_CONDUCTA_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SIGNOS_FISICOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historia_clinica = table.Column<int>(type: "int", nullable: false),
                    LACERACIONES = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HEMATOMA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QUEMADURAS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CICATRICES = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FRACTURAS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OBSERVACIONES = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioActualizacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIGNOS_FISICOS", x => x.id);
                    table.ForeignKey(
                        name: "FK_SIGNOS_FISICOS_HISTORIA_CLINICA_id_historia_clinica",
                        column: x => x.id_historia_clinica,
                        principalTable: "HISTORIA_CLINICA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIGNOS_FISICOS_usario_actualizacion",
                        column: x => x.IdUsuarioActualizacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SIGNOS_FISICOS_usario_creacion",
                        column: x => x.IdUsuarioCreacion,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Idpsicologo",
                table: "Agenda",
                column: "Idpsicologo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_carrito_de_compra_IdPaciente",
                table: "carrito_de_compra",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_carrito_de_compra_IdPsicologo",
                table: "carrito_de_compra",
                column: "IdPsicologo");

            migrationBuilder.CreateIndex(
                name: "IX_carrito_de_compra_IdServicio",
                table: "carrito_de_compra",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_carrito_de_compra_IdUsuarioActualizacion",
                table: "carrito_de_compra",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Idpsicologo",
                table: "Cita",
                column: "Idpsicologo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Idservicio",
                table: "Cita",
                column: "Idservicio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONCEPTO_PSICOLOGICO_id_historia_clinica",
                table: "CONCEPTO_PSICOLOGICO",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_CONCEPTO_PSICOLOGICO_IdUsuarioActualizacion",
                table: "CONCEPTO_PSICOLOGICO",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_CONCEPTO_PSICOLOGICO_IdUsuarioCreacion",
                table: "CONCEPTO_PSICOLOGICO",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_DESARROLLO_PSICOSEXUAL_id_historia_clinica",
                table: "DESARROLLO_PSICOSEXUAL",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_DESARROLLO_PSICOSEXUAL_IdUsuarioActualizacion",
                table: "DESARROLLO_PSICOSEXUAL",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_DESARROLLO_PSICOSEXUAL_IdUsuarioCreacion",
                table: "DESARROLLO_PSICOSEXUAL",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_EXAMEN_DE_ESTADO_MENTAL_id_historia_clinica",
                table: "EXAMEN_DE_ESTADO_MENTAL",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_EXAMEN_DE_ESTADO_MENTAL_IdUsuarioActualizacion",
                table: "EXAMEN_DE_ESTADO_MENTAL",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_EXAMEN_DE_ESTADO_MENTAL_IdUsuarioCreacion",
                table: "EXAMEN_DE_ESTADO_MENTAL",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_idPaciente",
                table: "Factura",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdFactura",
                table: "FacturaDetalles",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdServicio",
                table: "FacturaDetalles",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdTerapia",
                table: "FacturaDetalles",
                column: "IdTerapia");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_ACADEMICA_id_historia_clinica",
                table: "HISTORIA_ACADEMICA",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_ACADEMICA_IdUsuarioActualizacion",
                table: "HISTORIA_ACADEMICA",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_ACADEMICA_IdUsuarioCreacion",
                table: "HISTORIA_ACADEMICA",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_CLINICA_IdPaciente",
                table: "HISTORIA_CLINICA",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_CLINICA_IdUsuarioActualizacion",
                table: "HISTORIA_CLINICA",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORIA_CLINICA_IdUsuarioCreacion",
                table: "HISTORIA_CLINICA",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_iddatospersonales",
                table: "Hobbies",
                column: "iddatospersonales");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_IdUser",
                table: "Hobbies",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENTAL_PERSONAL_id_historia_clinica",
                table: "MENTAL_PERSONAL",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_MENTAL_PERSONAL_IdUsuarioActualizacion",
                table: "MENTAL_PERSONAL",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_MENTAL_PERSONAL_IdUsuarioCreacion",
                table: "MENTAL_PERSONAL",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_id_datos_personales",
                table: "paciente",
                column: "id_datos_personales",
                unique: true,
                filter: "[id_datos_personales] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_FacturaId",
                table: "Pagos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PsicologoId",
                table: "Pagos",
                column: "PsicologoId");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_id_datos_personales",
                table: "psicologo",
                column: "id_datos_personales");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_especialidad_id_especialidad",
                table: "psicologo_especialidad",
                column: "id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_especialidad_id_psicologo",
                table: "psicologo_especialidad",
                column: "id_psicologo");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_idioma_id_idioma",
                table: "psicologo_idioma",
                column: "id_idioma");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_idioma_id_psicologo",
                table: "psicologo_idioma",
                column: "id_psicologo");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_servicios_id_psicologo",
                table: "psicologo_servicios",
                column: "id_psicologo");

            migrationBuilder.CreateIndex(
                name: "IX_psicologo_servicios_id_servicio",
                table: "psicologo_servicios",
                column: "id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_RAZONES_DE_SINTOMAS_CONDUCTA_id_historia_clinica",
                table: "RAZONES_DE_SINTOMAS_CONDUCTA",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_RAZONES_DE_SINTOMAS_CONDUCTA_IdUsuarioActualizacion",
                table: "RAZONES_DE_SINTOMAS_CONDUCTA",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_RAZONES_DE_SINTOMAS_CONDUCTA_IdUsuarioCreacion",
                table: "RAZONES_DE_SINTOMAS_CONDUCTA",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdCita",
                table: "Sala",
                column: "IdCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIGNOS_FISICOS_id_historia_clinica",
                table: "SIGNOS_FISICOS",
                column: "id_historia_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_SIGNOS_FISICOS_IdUsuarioActualizacion",
                table: "SIGNOS_FISICOS",
                column: "IdUsuarioActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_SIGNOS_FISICOS_IdUsuarioCreacion",
                table: "SIGNOS_FISICOS",
                column: "IdUsuarioCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Terapia_idPaciente",
                table: "Terapia",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Terapia_Idpsicologo",
                table: "Terapia",
                column: "Idpsicologo");

            migrationBuilder.CreateIndex(
                name: "IX_Terapia_Idservicio",
                table: "Terapia",
                column: "Idservicio");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_datos_personales",
                table: "User",
                column: "id_datos_personales",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_id_perfil",
                table: "User",
                column: "id_perfil",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "carrito_de_compra");

            migrationBuilder.DropTable(
                name: "CONCEPTO_PSICOLOGICO");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "DESARROLLO_PSICOSEXUAL");

            migrationBuilder.DropTable(
                name: "EXAMEN_DE_ESTADO_MENTAL");

            migrationBuilder.DropTable(
                name: "FacturaDetalles");

            migrationBuilder.DropTable(
                name: "HISTORIA_ACADEMICA");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "MENTAL_PERSONAL");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PayUConfirmations");

            migrationBuilder.DropTable(
                name: "psicologo_especialidad");

            migrationBuilder.DropTable(
                name: "psicologo_idioma");

            migrationBuilder.DropTable(
                name: "psicologo_servicios");

            migrationBuilder.DropTable(
                name: "RAZONES_DE_SINTOMAS_CONDUCTA");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "SIGNOS_FISICOS");

            migrationBuilder.DropTable(
                name: "Terapia");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "especialidad");

            migrationBuilder.DropTable(
                name: "idioma");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "HISTORIA_CLINICA");

            migrationBuilder.DropTable(
                name: "psicologo");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "datos_personales");
        }
    }
}
