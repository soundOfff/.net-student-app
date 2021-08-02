using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

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

        public List<Inscripcion> GetAll()
        {
            return _inscripcionData.GetAll();
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
