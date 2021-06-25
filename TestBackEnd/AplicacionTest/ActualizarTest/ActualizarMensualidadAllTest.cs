using BackEnd;
using BackEnd.Base;
using BackEnd.Mensualidad.Aplicacion.Request;
using BackEnd.Mensualidad.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public class ActualizarMensualidadAllTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarMensualidadService _MensualidadService;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsMensualidad")]
        public void EditarMensualidad(ActualizarMensualidadRequest request, string expected)
        {
            _MensualidadService = new ActualizarMensualidadService(_unitOfWork);
            var response = _MensualidadService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsMensualidad()
        {
            yield return new TestCaseData(
                new ActualizarMensualidadRequest
                {
                    Deuda = 2000,
                    id = 1
                },
                "Mensualidad Actualizada Exitosamente"
            ).SetName("Mensualidad Actualizada Exitosamente");
        }
    }
}
