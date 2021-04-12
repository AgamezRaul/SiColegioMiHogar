using BackEnd;
using BackEnd.Base;
using BackEnd.Docente.Aplicacion.Request;
using BackEnd.Docente.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearDocenteTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearDocenteService _Docenteservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsDocente")]
        public void CrearDocente(CrearDocenteRequest DocenteRequest, string expected)
        {
            _Docenteservice = new CrearDocenteService(_unitOfWork);
            var response = _Docenteservice.Ejecutar(DocenteRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsDocente()
        {
            yield return new TestCaseData(
                new CrearDocenteRequest
                {
                    NombreCompleto = "Juan Meza",
                    NumTarjetaProf = "12435",
                    Cedula = "1002345467",
                    Celular = "3213456574",
                    Correo = "Juan@gmail.com",
                    Direccion = "Calle 5 No 30-21 Sabanas"
                },
                "Docente Creado Exitosamente"
                ).SetName("Crear Docente Correctamente");
        }
    }
}
