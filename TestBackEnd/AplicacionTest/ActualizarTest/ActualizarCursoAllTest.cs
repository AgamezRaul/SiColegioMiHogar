using BackEnd;
using BackEnd.Base;
using BackEnd.Curso.Aplicacion.Request;
using BackEnd.Curso.Aplicacion.Service.Actualizar;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.ActualizarTest
{
    [TestFixture]
    public class ActualizarCursoAllTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        ActualizarCursoService _CursoService;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("MiHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("EditionsCurso")]
        public void EditarCurso(ActualizarCursoRequest request, string expected)
        {
            _CursoService = new ActualizarCursoService(_unitOfWork);
            var response = _CursoService.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> EditionsCurso()
        {
            yield return new TestCaseData(
                new ActualizarCursoRequest
                {
                    id = 1,
                    nombre = "Primero A",
                    maxEstudiantes = 20,
                    idDirectorDocente = 8
                },
                "Curso no existe"
                ).SetName("Curso Actualizada Exitosamente");
        }

    }
    }
