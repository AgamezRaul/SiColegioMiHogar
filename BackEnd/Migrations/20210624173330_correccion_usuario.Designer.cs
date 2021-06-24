﻿// <auto-generated />
using System;
using BackEnd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(MiHogarContext))]
    [Migration("20210624173330_correccion_usuario")]
    partial class correccion_usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Actividad.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<double>("Porcentaje")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Actividad");
                });

            modelBuilder.Entity("BackEnd.Contrato.Dominio.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<double>("Sueldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("BackEnd.Curso.Dominio.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDirectorDocente")
                        .HasColumnType("int");

                    b.Property<int>("MaxEstudiantes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("BackEnd.Docente.Dominio.Docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTarjetaProf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Docente");
                });

            modelBuilder.Entity("BackEnd.Estudiante.Dominio.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CelEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FecNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("GradoEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("IdeEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsProcedencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugExpedicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipSangre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("BackEnd.Materia.Dominio.Entidades.Materias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<string>("NombreMateria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("BackEnd.Matricula.Dominio.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FecConfirmacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdePreMatricula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("BackEnd.Mensualidad.Dominio.Mensualidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Abono")
                        .HasColumnType("float");

                    b.Property<double>("DescuentoMensualidad")
                        .HasColumnType("float");

                    b.Property<double>("Deuda")
                        .HasColumnType("float");

                    b.Property<int>("DiaPago")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMatricula")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<double>("TotalMensualidad")
                        .HasColumnType("float");

                    b.Property<double>("ValorMensualidad")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Mensualidad");
                });

            modelBuilder.Entity("BackEnd.Nota.Dominio.Entidades.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaNota")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<double>("NotaAlumno")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("BackEnd.NotaPeriodo.Dominio.NotaPeriodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotaPeriodo");
                });

            modelBuilder.Entity("BackEnd.Periodo.Dominio.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePeriodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroPeriodo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Periodo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaFin = new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            NombrePeriodo = "Primer Periodo",
                            NumeroPeriodo = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaFin = new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            NombrePeriodo = "Segundo Periodo",
                            NumeroPeriodo = 2
                        },
                        new
                        {
                            Id = 3,
                            FechaFin = new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            NombrePeriodo = "Tercer Periodo",
                            NumeroPeriodo = 3
                        },
                        new
                        {
                            Id = 4,
                            FechaFin = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            NombrePeriodo = "Cuarto Periodo",
                            NumeroPeriodo = 4
                        });
                });

            modelBuilder.Entity("BackEnd.PreMatricula.Dominio.PreMatricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FecPrematricula")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("estudianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("estudianteId");

                    b.ToTable("PreMatricula");
                });

            modelBuilder.Entity("BackEnd.Responsable.Dominio.Responsable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acudiente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FecNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("IdeResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugExpedicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OcuResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreMatriculaId")
                        .HasColumnType("int");

                    b.Property<string>("ProfResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PreMatriculaId");

                    b.ToTable("Responsable");
                });

            modelBuilder.Entity("BackEnd.Usuario.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEnd.PreMatricula.Dominio.PreMatricula", b =>
                {
                    b.HasOne("BackEnd.Estudiante.Dominio.Estudiante", "estudiante")
                        .WithMany()
                        .HasForeignKey("estudianteId");

                    b.Navigation("estudiante");
                });

            modelBuilder.Entity("BackEnd.Responsable.Dominio.Responsable", b =>
                {
                    b.HasOne("BackEnd.PreMatricula.Dominio.PreMatricula", null)
                        .WithMany("Responsables")
                        .HasForeignKey("PreMatriculaId");
                });

            modelBuilder.Entity("BackEnd.PreMatricula.Dominio.PreMatricula", b =>
                {
                    b.Navigation("Responsables");
                });
#pragma warning restore 612, 618
        }
    }
}
