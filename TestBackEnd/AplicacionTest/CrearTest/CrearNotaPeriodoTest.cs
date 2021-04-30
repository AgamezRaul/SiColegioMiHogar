using BackEnd;
using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;
using BackEnd.NotaPeriodo.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
                    nota = 5.0,
                    observacion = "Muy buen estudiante",
                    idPeriodo = 1,
                    idMateria = 1
                },
                "Nota Periodo Creado Exitosamente"
                ).SetName("Crear Nota Periodo Correctamente");
        }
    }
}
