using BackEnd;
using BackEnd.Base;
using BackEnd.Materia.Aplicacion.Request;
using BackEnd.Materia.Aplicacion.Services.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearMateriaTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearMateriaService _Materiaservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsMateria")]
        public void CrearMateria(CrearMateriaRequest MateriaRequest, string expected)
        {
            _Materiaservice = new CrearMateriaService(_unitOfWork);
            var response = _Materiaservice.Ejecutar(MateriaRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsMateria()
        {
            yield return new TestCaseData(
                new CrearMateriaRequest
                {
                    Id = 2324,
                    NombreMateria = "Español",
                    IdDocente = 1312,
                    IdCurso = 501
                },
                "Materia creada exitosamente"
            ).SetName("Crear Materia Correctamente");
        }
    }
}
