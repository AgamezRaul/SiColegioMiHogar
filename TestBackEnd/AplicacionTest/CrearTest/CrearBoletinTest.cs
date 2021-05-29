using BackEnd;
using BackEnd.Base;
using BackEnd.Boletin.Aplicacion.Request;
using BackEnd.Boletin.Aplicacion.Services.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    class CrearBoletinTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearBoletinService _Boletinservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsBoletin")]
        public void CrearBoletin(CrearBoletinRequest BoletinRequest, string expected)
        {
            _Boletinservice = new CrearBoletinService(_unitOfWork);
            var response = _Boletinservice.Ejecutar(BoletinRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsBoletin()
        {
            yield return new TestCaseData(
                new CrearBoletinRequest
                {
                    id = 1,
                    FechaGeneracion =DateTime.Now ,
                    IdPeriodo = 1,
                    IdEstudiante = 1
                },
                "Nota Boletin Exitosamente"
                ).SetName("Crear Boletin Correctamente");
        }

    }
}
