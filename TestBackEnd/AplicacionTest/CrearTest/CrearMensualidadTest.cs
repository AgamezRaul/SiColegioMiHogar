using BackEnd;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{

    [TestFixture]
    public class CrearMensualidadTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearMensualidadService _Mensualidadservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsMensualidad")]
        public void CrearMensualidad(CrearMensualidadRequest MensualidadRequest, string expected)
        {
            _Mensualidadservice = new CrearMensualidadService(_unitOfWork);
            var response = _Mensualidadservice.Ejecutar(MensualidadRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsMensualidad()
        {
            yield return new TestCaseData(
                new CrearMensualidadRequest
                {
                    Mes = "Marzo",
                    Deuda = 5000,
                    IdMatricula = 001
                },
                "Mensualidad Creada Exitosamente"
                ).SetName("Crear Mensualidad Correctamente");
        }
    }
}
