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
        private string _descMateria;
        private int _idPlan;
        private string _descComision;
        private int anio_especialidad;
        private string _descPlan;
        private string _descEspecialidad;
        private int _idEspecialidad;


        public int IdMateria { get { return _idMateria; } set { _idMateria = value; } }
        public int IdComision { get { return _idComision; } set { _idComision = value; } }
        public int AnioCalendario { get { return _anioCalendario; } set { _anioCalendario = value; } }
        public int Cupo { get { return _cupo; } set { _cupo = value; } }

        public string DescMateria { get { return _descMateria; } set { _descMateria = value; } }
        public string DescComision { get { return _descComision; } set { _descComision = value; } }
        public string DescPlan { get { return _descPlan; } set { _descPlan = value; } }
        public string DescEspecialidad { get { return _descEspecialidad; } set { _descEspecialidad = value; } }
        public int IdPlan { get { return _idPlan; } set { _idPlan = value; } }
        public int AnioEspecialidad { get { return anio_especialidad; } set { anio_especialidad = value; } }
        public int IdEspecialidad { get { return _idEspecialidad; } set { _idEspecialidad = value; } }






    }
}
