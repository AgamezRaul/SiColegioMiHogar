using BackEnd.Base;
using BackEnd.Nota.Aplicacion.Request;
using BackEnd.materias.Aplicacion;
using BackEnd.Periodo.Aplicacion.Request;
using BackEnd.Estudiante.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Nota.Aplicacion.Services
{
    public class ConsultarNotaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarNotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<NotaResponseConsult> GetAll()
        {
            Estudiante.Dominio.Estudiante estudiante;
            materias.Dominio.Entidades.Materias materia;
            Periodo.Dominio.Periodo periodo;

            var res = _unitOfWork.NotaServiceRepository.FindBy().ToList();

            List<NotaResponseConsult> response = new List<NotaResponseConsult>();

            foreach (var item in res)
            {
                NotaResponseConsult r = new NotaResponseConsult();
                estudiante = new Estudiante.Dominio.Estudiante();
                materia = new materias.Dominio.Entidades.Materias();
                periodo = new Periodo.Dominio.Periodo();

                estudiante = _unitOfWork.EstudianteServiceRepository.FindFirstOrDefault(x => x.IdeEstudiante == item.IdEstudiante.ToString());
                materia = _unitOfWork.MateriaServiceRepository.FindFirstOrDefault(x => x.idMateria == item.IdMateria);
                periodo = _unitOfWork.PeriodoServiceRepository.FindFirstOrDefault(x => x.Id == item.IdPeriodo);
		
		r.Id = item.Id;
                r.Estudiante = estudiante.NomEstudiante;
                r.Materia = materia.NombreMateria;
                r.Periodo = periodo.NombrePeriodo+" "+periodo.FechaInicio.ToString().Split('-')[0];
                r.NotaAlumno = item.NotaAlumno;
                r.FechaNota = item.FechaNota;
                r.Descripcion = item.Descripcion;

                response.Add(r);
            }

            _unitOfWork.Dispose();
            return response;
        }

        public Dominio.Entidades.Nota GetId(int id)
        {
            var ConsultarID = _unitOfWork.NotaServiceRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }

    public class NotaResponseConsult
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double NotaAlumno { get; set; }
        public DateTime FechaNota { get; set; }
        public string Estudiante { get; set; }
        public string Materia { get; set; }
        public string Periodo { get; set; }
    }
}
