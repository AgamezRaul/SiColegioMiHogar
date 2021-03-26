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
    [Migration("20210326020246_tablasSprint1")]
    partial class tablasSprint1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Estudiante.Dominio.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CelEstudiante")
                        .HasColumnType("float");

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

                    b.Property<int>("IdResponsable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PreMatricula");
                });

            modelBuilder.Entity("BackEnd.RelacionUR.Dominio.RelacionUR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdResponsable")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RelacionUR");
                });

            modelBuilder.Entity("BackEnd.Responsable.Dominio.Responsable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acudiente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CelEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("CelResponsable")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FecNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstudiante")
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

                    b.Property<string>("ProfResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoResponsable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<string>("NomUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
