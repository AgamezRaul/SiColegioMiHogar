using BackEnd;
using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;
using BackEnd.Grado.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearGradoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearGradoService _Gradoservice;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsGrado")]
        public void CrearGrado(CrearGradoRequest GradoRequest, string expected)
        {
            _Gradoservice = new CrearGradoService(_unitOfWork);
            var response = _Gradoservice.Ejecutar(GradoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsGrado()
        {
            yield return new TestCaseData(
                new CrearGradoRequest
                {
                    Nombre = "Jardin"
                },
                "Grado Creado Exitosamente"
                ).SetName("Crear Grado Correctamente");
        }
    }
}
