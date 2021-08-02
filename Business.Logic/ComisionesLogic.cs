using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionesLogic : BusinessLogic
    {
        private ComisionAdapter _comisionesAdapter;

        public ComisionAdapter UsuarioData { get { return _comisionesAdapter; } set { _comisionesAdapter = value; } }

        public ComisionesLogic()
        {
            _comisionesAdapter = new ComisionAdapter(); // here
        }


        public List<Comision> GetAll()
        {
            return _comisionesAdapter.GetAll();
        }

        public Comision GetOne(int idComision)
        {
            return _comisionesAdapter.GetOne(idComision);
        }

        public void Delete(int idComision)
        {
            _comisionesAdapter.Delete(idComision);
        }

        public void Save(Comision comision)
        {
            _comisionesAdapter.Save(comision);
        }

    }
}
