using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _descMateria;
        private int _hsTotales;
        private int _hsSemanales;

        public string DescMateria { get { return _descMateria; } set { _descMateria = value; } }
        
        public int HsTotales { get { return _hsTotales; } set { _hsTotales = value; } }

        public int HsSemanales { get { return _hsSemanales; } set { _hsSemanales = value; } }



    }
}
