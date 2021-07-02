using BackEnd;
using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;
using BackEnd.NotaPeriodo.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearNotaPeriodoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearNotaPeriodoService _NotaPeriodoservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsNotaPeriodo")]
        public void CrearNotaPeriodo(CrearNotaPeriodoRequest NotaPeriodoRequest, string expected)
        {
            _NotaPeriodoservice = new CrearNotaPeriodoService(_unitOfWork);
            var response = _NotaPeriodoservice.Ejecutar(NotaPeriodoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsNotaPeriodo()
        {
            yield return new TestCaseData(
                new CrearNotaPeriodoRequest
                {
                    Nota = 5.0,
                    Observacion = "Muy buen estudiante",
                    IdPeriodo = 1,
                    IdMateria = 1
                },
                "Nota Periodo Creado Exitosamente"
                ).SetName("Crear Nota Periodo Correctamente");
        }
    }
}
