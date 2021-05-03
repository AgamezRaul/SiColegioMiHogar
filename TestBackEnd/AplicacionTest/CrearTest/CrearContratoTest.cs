using BackEnd;
using BackEnd.Base;
using BackEnd.Contrato.Aplicacion.Request;
using BackEnd.Contrato.Aplicacion.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearContratoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearContratoService _crearContratoService;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsContrato")]
        public void CrearContrato(CrearContratoRequest request, string expected)
        {
            _crearContratoService = new CrearContratoService(_unitOfWork);
            var response = _crearContratoService.EjecutarCrearContrato(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsContrato()
        {
            yield return new TestCaseData(
                new CrearContratoRequest
                {
                    FechaInicio = DateTime.Now.Date,
                    FechaFin = DateTime.Now.Date.AddDays(1),
                    Sueldo = 1400000,
                    IdDocente = 1
                },
                "Contrato Creado Exitosamente"
            ).SetName("Crear Contrato Correctamente");
        }
    }
}
