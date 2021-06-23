using BackEnd;
using BackEnd.Abono.Aplicacion.Request;
using BackEnd.Abono.Aplicacion.Service.Actualizar;
using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public class ActualizarAbonoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarAbonoService _AbonoService;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsAbono")]
        public void EditarAbono(ActualizarAbonoRequest request, string expected)
        {
            _AbonoService = new ActualizarAbonoService(_unitOfWork);
            var response = _AbonoService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsGrado()
        {
            yield return new TestCaseData(
                new ActualizarAbonoRequest
                {
                    ValorAbono = 500000,
                    id = 001
                },
                "Abono Actualizado Exitosamente"
            ).SetName("Abono Actualizado Exitosamente");
        }
    }
}
