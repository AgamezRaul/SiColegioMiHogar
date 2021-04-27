using BackEnd;
using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearResponsableTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearResponsableService _service;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsEstudiante")]
        public void CrearEstudiante(List<CrearResponsableRequest> request, string expected)
        {
            _service = new CrearResponsableService(_unitOfWork);
            var response = _service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsEstudiante()
        {
            yield return new TestCaseData(
                new List<CrearResponsableRequest>
                {
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
                    }
                },
                "Responsables Creados Exitosamente"
            ).SetName("Crear Responsable Correctamente");
        }
    }
}
