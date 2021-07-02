using BackEnd;
using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using BackEnd.Docente.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    class ActualizarDocenteTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarDocenteService _Docenteservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsDocente")]
        public void ActualizarDocente(ActualizarDocenteRequest DocenteRequest, string expected)
        {
            _Docenteservice = new ActualizarDocenteService(_unitOfWork);
            var response = _Docenteservice.Ejecutar(DocenteRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsDocente()
        {
            yield return new TestCaseData(
                new ActualizarDocenteRequest
                {
                    NombreCompleto = "Juan Meza",
                    NumTarjetaProf = "12435",
                    Cedula = "1002345467",
                    Celular = "3213456574",
                    Correo = "Juan@gmail.com",
                    Direccion = "Calle 5 No 30-21 Sabanas",
                    id = 1
                },
                "Docente no existe"
                ).SetName("Docente Actualizado Correctamente");
        }
    }
}
