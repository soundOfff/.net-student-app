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

        public ArrayList GetAll()
        {
            return _inscripcionData.GetAll();
        }

        public ArrayList GetAll(Persona per)
        {
            return _inscripcionData.GetAll(per);
        }

        public Inscripcion GetOne(int idInscripcion)
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
