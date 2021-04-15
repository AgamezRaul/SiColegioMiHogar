﻿using BackEnd.Base;
using BackEnd.Periodo.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Periodo.Aplicacion.Services
{
    public class CrearPeriodoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PeriodoResponse CrearPerido(PeriodoRequest request)
        {
            var matricula = _unitOfWork.PeriodoServiceRepository.FindFirstOrDefault(t => t.NumeroPeriodo == request.NumeroPeriodo);
            if (matricula == null)
            {
                Dominio.Periodo newPeriodo = new Dominio.Periodo(request.NumeroPeriodo, request.NombrePeriodo, request.FechaInicio, request.FechaFin);

                IReadOnlyList<string> errors = newPeriodo.CanCrear(newPeriodo);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new PeriodoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.PeriodoServiceRepository.Add(newPeriodo);
                    _unitOfWork.Commit();
                    return new PeriodoResponse() { Message = $"Periodo Registrado Exitosamente" };
                }
            }
            else
            {
                return new PeriodoResponse() { Message = $"Este periodo ya existe" };
            }
        }
    }
}