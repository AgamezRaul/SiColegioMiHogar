using BackEnd;
using BackEnd.Base;
using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Services.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{

        [TestFixture]
        public class CrearEstudianteTest
        {
            MiHogarContextTest _context;
            UnitOfWork _unitOfWork;
            CrearEstudianteService _Estudianteservice;

            [SetUp]
            public void Setup()
            {
                var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
                _context = new MiHogarContextTest(optionsInMemory);
                _unitOfWork = new UnitOfWork(_context);
            }

            [TestCaseSource("CreationsEstudiante")]
            public void CrearEstudiante(CrearEstudianteRequest EstudianteRequest, string expected)
            {
                _Estudianteservice = new CrearEstudianteService(_unitOfWork);
                var response = _Estudianteservice.Ejecutar(EstudianteRequest);
                Assert.AreEqual(expected, response.Message);
            }
            private static IEnumerable<TestCaseData> CreationsEstudiante()
            {
                yield return new TestCaseData(
                    new CrearEstudianteRequest
                    {
                        IdeEstudiante = "1065",
                        NomEstudiante = "Raul",
                        FecNacimiento = DateTime.Now,
                        LugNacimiento = "Valledupar",
                        LugExpedicion = "Valledupar",
                        InsProcedencia = "Valledupar",
                        DirResidencia = "Valledupar",
                        CelEstudiante = 123456,
                        TipSangre = "O+",
                        GradoEstudiante = "6",
                        Eps = "NO C",
                        Correo = "raagamez@gmail.com",
                        Sexo = "Masculino",
                        TipoDocumento = "Cedula",
                        TelEstudiante = "1234567",
                        IdUsuario = 1
                    },
                    "Estudiante Creado Exitosamente"
                ).SetName("Crear Estudiante Correctamente");
            }
        }
    }


