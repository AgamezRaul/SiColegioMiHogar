using BackEnd;
using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using BackEnd.Curso.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearCursoTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearCursoService _Cursoservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsCurso")]
        public void CrearCurso(CrearCursoRequest CursoRequest, string expected)
        {
            _Cursoservice = new CrearCursoService(_unitOfWork);
            var response = _Cursoservice.Ejecutar(CursoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsCurso()
        {
            yield return new TestCaseData(
                new CrearCursoRequest
                {
                    nombre = "Raul",
                    maxEstudiantes = 30,
                    idDirectorDocente = 8
                },
                "Curso Creado Exitosamente"
                ).SetName("Crear Curso Correctamente");
        }
    }
}
