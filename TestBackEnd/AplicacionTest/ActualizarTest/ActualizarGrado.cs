using BackEnd;
using BackEnd.Base;
using BackEnd.Grado.Aplicacion.Request;
using BackEnd.Grado.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public  class ActualizarGrado
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarGradoService _GradoService;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsGrado")]
        public void EditarGrado(ActualizarGradoRequest request, string expected)
        {
            _GradoService = new ActualizarGradoService(_unitOfWork);
            var response = _GradoService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsGrado()
        {
            yield return new TestCaseData(
                new ActualizarGradoRequest
                {
                    Nombre="Pre-Jardin",
                    id = 1
                },
                "Grado Actualizado Exitosamente"
            ).SetName("Grado Actualizado Exitosamente");
        }
    }
}
