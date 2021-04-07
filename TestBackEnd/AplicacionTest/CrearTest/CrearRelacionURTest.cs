using BackEnd;
using BackEnd.Base;
using BackEnd.RelacionUR.Aplicacion.Request;
using BackEnd.RelacionUR.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearRelacionURTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearRelacionURService _RelacionURService;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsRelacionUR")]
        public void CrearRelacionUR(CrearRelacionURRequest relacionURRequest, string expected)
        {
            _RelacionURService = new CrearRelacionURService(_unitOfWork);
            var response = _RelacionURService.Ejecutar(relacionURRequest);
            Assert.AreEqual(expected, response.Message);
        }

        private static IEnumerable<TestCaseData> CreationsRelacionUR()
        {
            yield return new TestCaseData(
                new CrearRelacionURRequest
                {
                    IdResponsable=1,
                    IdUsuario=1
                },
                "Relacion Usuario Responsable Creada Exitosamente"
            ).SetName("Crear RelacionUR Correctamente");
        }
    }
}
