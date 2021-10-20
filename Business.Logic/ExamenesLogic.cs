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
    public class ExamenesLogic: BusinessLogic
    {
        private ExamenesAdapter _inscripcionData;

        public ExamenesAdapter InscripcionData { get { return _inscripcionData; } set { _inscripcionData = value; } }
        
        public ExamenesLogic()
        {
            _inscripcionData = new ExamenesAdapter();
        }

        public List<Examen> GetAll()
        {
            return _inscripcionData.GetAll();
        }

        public List<Examen> GetAll(Persona per)
        {
            return _inscripcionData.GetAll(per);
        }

        public ArrayList GetEP(List<int> idCursos)
        {
            return _inscripcionData.GetEP(idCursos);
        }

        public Examen GetOne(int idInscripcion)
        {
            return _inscripcionData.GetOne(idInscripcion);
        }

        public void Delete(int idInscripcion)
        {
            _inscripcionData.Delete(idInscripcion);
        }

        public void Save(Inscripcion inscripcion)
        {
            _inscripcionData.Save(inscripcion);
        }


    }
}
