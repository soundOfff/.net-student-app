using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic: BusinessLogic
    {
        private EspecialidadAdapter _especialidadData;

        public EspecialidadAdapter EspecialidadData { get { return _especialidadData; } set { _especialidadData = value; } }

        public EspecialidadLogic()
        {
            _especialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return _especialidadData.GetAll();
        }

        public Especialidad GetOne(int idEspecialidad)
        {
            return _especialidadData.GetOne(idEspecialidad);
        }

        public void Delete(int idEspecialidad)
        {
            _especialidadData.Delete(idEspecialidad);
        }

        public void Save(Especialidad especialidad)
        {
            _especialidadData.Save(especialidad);
        }

    }
}
