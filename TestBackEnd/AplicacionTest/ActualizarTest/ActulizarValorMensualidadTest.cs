using BackEnd;
using BackEnd.Base;
using BackEnd.ValorMensualidad.Aplicacion.Request;
using BackEnd.ValorMensualidad.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
   public class ActulizarValorMensualidadTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarValorMensualidadService _ValorMensualidadService;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsValorMensualidad")]
        public void EditarValorMensualidad(ActualizarValorMensualidadRequest request, string expected)
        {
            _ValorMensualidadService = new ActualizarValorMensualidadService(_unitOfWork);
            var response = _ValorMensualidadService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsMensualidad()
        {
            yield return new TestCaseData(
                new ActualizarValorMensualidadRequest
                {
                    Fecha = DateTime.Now,
                    PrecioMensualidad = 300.000,
                    id = 001
                },
                "Valor Mensualidad Actualizada Exitosamente"
            ).SetName("Valor Mensualidad Actualizada Exitosamente");
        }
    }
}
