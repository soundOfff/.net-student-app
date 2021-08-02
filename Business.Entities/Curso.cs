using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Curso: BusinessEntity
    {
        private int _idMateria;
        private int _idComision;
        private int _anioCalendario;
        private int _cupo;

        public int IdMateria { get { return _idMateria; } set { _idMateria = value; } }
        public int IdComision { get { return _idComision; } set { _idComision = value; } }
        public int AnioCalendario { get { return _anioCalendario; } set { _anioCalendario = value; } }
        public int Cupo { get { return _cupo; } set { _cupo = value; } }



    }
}
