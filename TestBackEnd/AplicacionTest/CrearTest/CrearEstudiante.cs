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
        public class CrearEstudiante
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

            [TestCaseSource("CreationsEmpleado")]
            public void CrearEmpleado(CrearEstudianteRequest EstudianteRequest, string expected)
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
                        IdeEstudiante = "Agamez Rapalino",
                        NomEstudiante = "Cajero",
                        FecNacimiento = DateTime.Now,
                        LugNacimiento = "raagamez@unicesar.edu.co",
                        LugExpedicion = "Calle 22C #21-61",
                        InsProcedencia = "Educativa",
                        DirResidencia = "Calle 40",
                        CelEstudiante = 123123,
                        TipSangre = "o+",
                        GradoEstudiante = "primero",
                        Eps = "sanitas",
                        Correo = "raul@unicesar.edu.co",
                        Sexo = "Masculino"

                    },
                    "Estudiante Creado Exitosamente"
                    ).SetName("Crear Estudiante Correctamente");
            }
        }
    }


