using BackEnd;
using BackEnd.Base;
using BackEnd.ValorMensualidad.Aplicacion.Request;
using BackEnd.ValorMensualidad.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearValorMensualidadTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearValorMensualidadService _ValorMensualidadservice;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsValorMensualidad")]
        public void CrearValorMensualidad(CrearValorMensualidadRequest ValorMensualidadRequest, string expected)
        {
            _ValorMensualidadservice = new CrearValorMensualidadService(_unitOfWork);
            var response = _ValorMensualidadservice.Ejecutar(ValorMensualidadRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsValorMensualidad()
        {
            yield return new TestCaseData(
                new CrearValorMensualidadRequest
                {
                    Fecha = DateTime.Now,
                    PrecioMensualidad = 300.000,
                    IdGrado = 001

                },
                "Valor Mensualidad Creado Exitosamente"
                ).SetName("Crear Valor Mensualidad Correctamente");
        }
    }
}
