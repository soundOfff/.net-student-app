using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Examen:BusinessEntity
    {
        private string _descEspecialidad;
        private string _descMateria;
        private string _descPlan;
        private int _nota;
        private int _legajo;
        private int _idCurso;


        public string DescEspecialidad { get { return _descEspecialidad; } set { _descEspecialidad = value; } }
        public string DescMateria { get { return _descMateria; } set { _descMateria = value; } }
        public string DescPlan { get { return _descPlan; } set { _descPlan = value; } }
        public int Nota { get { return _nota; } set { _nota = value; } }
        public int Legajo { get { return _legajo; } set { _legajo = value; } }
        public int IdCurso { get { return _idCurso; } set { _idCurso = value; } }
    }
}
