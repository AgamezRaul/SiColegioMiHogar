﻿using BackEnd;
using BackEnd.Base;
using BackEnd.Matricula.Aplicacion.Request;
using BackEnd.Matricula.Aplicacion.Service.Crear;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEnd.AplicacionTest.CrearTest
{
    [TestFixture]
    public class CrearMatriculaTest
    {
        MiHogarContextTest _context;
        UnitOfWork _unitOfWork;
        CrearMatriculaService _service;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<MiHogarContextTest>().UseInMemoryDatabase("miHogar").Options;
            _context = new MiHogarContextTest(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsCurso")]
        public void CrearCurso(CrearMatriculaRequest request, string expected)
        {
            _service = new CrearMatriculaService(_unitOfWork);
            var response = _service.Ejecutar(request);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsCurso()
        {
            yield return new TestCaseData(
                new CrearMatriculaRequest
                {
                    IdPreMatricula = 1,
                },
                "Matricula Creada Exitosamente"
                ).SetName("Crear Matricula Correctamente");
        }
    }
}