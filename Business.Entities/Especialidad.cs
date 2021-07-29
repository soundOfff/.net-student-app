using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidad: BusinessEntity
    {
        private string _descEspecialidad;

        public string DescEspecialidad { get { return _descEspecialidad; } set { _descEspecialidad = value; }}
    }
}
