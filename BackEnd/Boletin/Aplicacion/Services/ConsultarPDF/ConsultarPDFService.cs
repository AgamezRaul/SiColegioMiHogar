using BackEnd.Base;
using BackEnd.Boletin.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Boletin.Aplicacion.Services
{
    public class ConsultarPDFService
    {
        readonly MiHogarContext _context;
        readonly ConsultarPDFRequest consultarPDFRequest;
        public ConsultarPDFService(MiHogarContext context)
        {
            _context = context;
            consultarPDFRequest = new ConsultarPDFRequest();
        }
        public ConsultarPDFRequest Ejecutar(){
            var listaBoletin = new List<CrearBoletinRequest>();
            var rta = _context.Boletin.ToList();
            foreach (var item in rta)
            {
                var boletin = new CrearBoletinRequest();
                boletin.IdEstudiante= item.IdEstudiante;
                boletin.IdPeriodo = item.IdPeriodo;
                boletin.FechaGeneracion = item.FechaGeneracion;
                listaBoletin.Add(boletin);
            }
            consultarPDFRequest.BoletinesPDF = listaBoletin;
            return consultarPDFRequest;
        }
    }
}
