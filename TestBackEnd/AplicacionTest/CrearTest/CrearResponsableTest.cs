using BackEnd;
using BackEnd.Base;
using BackEnd.Responsable.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Services.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void CrearEstudiante(CrearResponsableRequest request, string expected)
        {
            _service = new CrearResponsableService(_unitOfWork);
            var response = _service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsEstudiante()
        {
            yield return new TestCaseData(
                new CrearResponsableRequest
                {
                    IdeResponsable = "1234567",
                    NomResponsable = "Raul",
                    FecNacimiento = DateTime.Now.Date,
                    LugNacimiento = "Valledupar",
                    LugExpedicion = "Valledupar",
                    TipDocumento = "Cedula",
                    CelResponsable = "123456789",
                    ProfResponsable = "Estudiante",
                    OcuResponsable = "Estudiante",
                    EntResponsable = "UPC",
                    CelEmpresa = "12345678",
                    TipoResponsable = "Padre",
                    Correo = "raagamez@unicesar.edu.co",
                    Acudiente = "Si",
                    IdUsuario = 1
    },
                "Responsable Creado Exitosamente"
            ).SetName("Crear Responsable Correctamente");
        }
    }
}
