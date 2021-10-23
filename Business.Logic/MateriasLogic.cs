using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriasLogic : BusinessLogic
    {
        private MateriaAdapter _materiasData;

        public MateriaAdapter MateriaData { get { return _materiasData; } set { _materiasData = value; } }

        public MateriasLogic()
        {
            _materiasData = new MateriaAdapter(); // here
        }


        public List<Materia> GetAll()
        {
            return _materiasData.GetAll();
        }
        public List<Materia> GetAll(int idPlan)
        {
            return _materiasData.GetAll(idPlan);
        }
        public Materia GetOne(int idMateria)
        {
            return _materiasData.GetOne(idMateria);
        }


        public ArrayList getDatosInscripcion(int idPlan)
        {
            return _materiasData.getDatosInscripcion(idPlan);
        }

        public void Delete(int idMateria)
        {
            _materiasData.Delete(idMateria);
        }

        public void Save(Materia materia)
        {
            _materiasData.Save(materia);
        }

    }
}
