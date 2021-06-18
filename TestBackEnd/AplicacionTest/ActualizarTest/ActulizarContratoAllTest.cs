using BackEnd;
using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using BackEnd.Contrato.Aplicacion.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public class ActulizarContratoAllTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarContratoService _ContratoService;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsContrato")]
        public void ActualizarContrato(ActualizarContratoRequest ContratoRequest, string expected)
        {
            _ContratoService = new ActualizarContratoService(_unitOfWork);
            var response = _ContratoService.EjecutarActualizarContrato(ContratoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsContrato()
        {
            yield return new TestCaseData(
                new ActualizarContratoRequest
                {
                    FechaInicio=System.DateTime.Now,
                    FechaFin= System.DateTime.Now.AddDays(365),
                    Sueldo= 2000000,
                    IdDocente=1
                   
                },
                "El  contrato del docente no existe"
                ).SetName("Contrato Actualizado Correctamente");
        }
    }
}
