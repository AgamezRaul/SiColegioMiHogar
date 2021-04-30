using BackEnd;
using BackEnd.Base;
using BackEnd.NotaPeriodo.Aplicacion.Request;
using BackEnd.NotaPeriodo.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public class ActualizarNotaPeriodoAllTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarNotaPeriodoService _NotaPeriodoService;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsNotaPeriodo")]
        public void EditarNotaPeriodo(ActualizarNotaPeriodoRequest request, string expected)
        {
            _NotaPeriodoService = new ActualizarNotaPeriodoService(_unitOfWork);
            var response = _NotaPeriodoService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsNotaPeriodo()
        {
            yield return new TestCaseData(
                new ActualizarNotaPeriodoRequest
                {
                    id = 1,
                    nota = 4.0,
                    observacion = "Buen estudiante",
                    idPeriodo = 1,
                    idMateria = 1
                },
                "Nota Periodo Actualizada Exitosamente"
                ).SetName("Nota Periodo Actualizada Exitosamente");
        }
    }
}