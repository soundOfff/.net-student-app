using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan: BusinessEntity
    {
        private string _descPlan;
        private int _IDEspecialidad;

        public string DescPlan { get { return _descPlan; } set{ _descPlan = value; } }
        public int IDEspecialidad { get{ return _IDEspecialidad; } set { _IDEspecialidad = value; } }
        public string Informacion { get { return IDEspecialidad + " " + DescPlan; } }
    }
}
