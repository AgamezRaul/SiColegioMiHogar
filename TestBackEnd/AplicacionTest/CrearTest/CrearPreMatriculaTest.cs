using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Request;
using BackEnd.PreMatricula.Aplicacion.Service.Crear;
using BackEnd.Responsable.Aplicacion.Request;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearPreMatriculaTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearPreMatriculaService _crearPreMatriculaService;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsPreMatricula")]
        public void CrearPreMatricula(CrearPreMatriculaRequest preMatriculaRequest, string expected)
        {
            _crearPreMatriculaService = new CrearPreMatriculaService(_unitOfWork);
            var response = _crearPreMatriculaService.EjecutarCrearPreMatricula(preMatriculaRequest);

            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsPreMatricula()
        {
            yield return new TestCaseData(
                new CrearPreMatriculaRequest
                {
                    Responsables = new List<CrearResponsableRequest> {
                        new CrearResponsableRequest {
                            IdeResponsable = "1234567",
                            NomResponsable = "Raul",
                            FecNacimiento = DateTime.Now.Date,
                            LugNacimiento = "Valledupar",
                            LugExpedicion = "Valledupar",
                            TipDocumento = "Cedula",
                            CelResponsable = "1234567",
                            ProfResponsable = "Estudiante",
                            OcuResponsable = "Estudiante",
                            EntResponsable = "UPC",
                            CelEmpresa = "1234567",
                            TipoResponsable = "Padre",
                            Correo = "raagamez@gmail.com",
                            Acudiente = "No",
                            IdUsuario = 1
                        },
                        new CrearResponsableRequest
                        {
                            IdeResponsable = "89101112",
                            NomResponsable = "Andres",
                            FecNacimiento = DateTime.Now,
                            LugNacimiento = "Valledupar",
                            LugExpedicion = "Valledupar",
                            TipDocumento = "Cedula",
                            CelResponsable = "1234567",
                            ProfResponsable = "Estudiante",
                            OcuResponsable = "Estudiante",
                            EntResponsable = "UPC",
                            CelEmpresa = "1234567",
                            TipoResponsable = "Madre",
                            Correo = "raagamez@gmail.com",
                            Acudiente = "No",
                            IdUsuario = 1
                        },
                        new CrearResponsableRequest
                        {
                            IdeResponsable = "13141516",
                            NomResponsable = "Agamez",
                            FecNacimiento = DateTime.Now,
                            LugNacimiento = "Valledupar",
                            LugExpedicion = "Valledupar",
                            TipDocumento = "Cedula",
                            CelResponsable = "1234567",
                            ProfResponsable = "Estudiante",
                            OcuResponsable = "Estudiante",
                            EntResponsable = "UPC",
                            CelEmpresa = "1234567",
                            TipoResponsable = "Padre",
                            Correo = "raagamez@gmail.com",
                            Acudiente = "Si",
                            IdUsuario = 1
                        } },
                    Estudiante = new CrearEstudianteRequest
                    {
                        IdeEstudiante = "1234567",
                        NomEstudiante = "Raul",
                        FecNacimiento = DateTime.Now,
                        LugNacimiento = "Valledupar",
                        LugExpedicion = "Valledupar",
                        InsProcedencia = "Valledupar",
                        DirResidencia = "Calle 22C",
                        CelEstudiante = "123455",
                        TipSangre = "O+",
                        GradoEstudiante = "Sexto",
                        Eps = "No se",
                        Correo = "raagamez@gmail.com",
                        Sexo = "Masculino",
                        TipoDocumento = "Cedula",
                        TelEstudiante = "1234567",
                        IdUsuario = 1
                    },
                    IdUsuario = 1,
                },
                "PreMatricula Creada Exitosamente"
            ).SetName("Crear PreMatricula Correctamente");
        }
    }
}
