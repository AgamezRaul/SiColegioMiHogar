using BackEnd;
using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Abono.Aplicacion.Service.Crear;
using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearAbonoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearAbonoService _AbonoService;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsAbono")]
        public void CrearAbono(CrearAbonoRequest AbonoRequest, string expected)
        {
            _AbonoService = new CrearAbonoService(_unitOfWork);
            var response = _AbonoService.Ejecutar(AbonoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsAbono()
        {
            yield return new TestCaseData(
                new CrearAbonoRequest
                {
                    ValorAbono = 100000,
                    IdMensualidad = 001
                },
                "Mensualidad No existe"
                ).SetName("Crear Abono Correctamente");
        }
    }
}
