using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using System.Collections;

namespace Business.Logic
{
    public class InscripcionLogic: BusinessLogic
    {
        private InscripcionAdapter _inscripcionData;

        public InscripcionAdapter InscripcionData { get { return _inscripcionData; } set { _inscripcionData = value; } }
        
        public InscripcionLogic()
        {
            _inscripcionData = new InscripcionAdapter();
        }

        public bool getUserAlreadyInscript(int idCurso, int idAlu)
        {
            return _inscripcionData.getUserAlreadyInscript(idCurso, idAlu);
        }


        public List<Inscripcion> GetAll()
        {
            return _inscripcionData.GetAll();
        }
        public ArrayList GetAllMateriasInscripcion()
        {
            return _inscripcionData.getAllMateriasInscripcion();
        }

        public Inscripcion GetOne(int idExamen)
        {
            return _inscripcionData.GetOne(idExamen);
        }

        public void Delete(int idInscripcion)
        {
            _inscripcionData.Delete(idInscripcion);
        }

        public void Save(Inscripcion inscripcion)
        {
            _inscripcionData.Save(inscripcion);
        }

        public List<Persona> getAlumnoCurso(int idCurso)
        {
            return _inscripcionData.getAlumnosCurso(idCurso);
        }


    }
}
