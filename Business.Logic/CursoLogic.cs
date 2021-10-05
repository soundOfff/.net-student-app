using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Data;
 

namespace Business.Logic
{
   public class CursoLogic
    {
        private CursoAdapter _cursoData;

        public CursoAdapter CursoData { get { return _cursoData; } set { _cursoData = value; } }

        public CursoLogic()
        {
            _cursoData = new CursoAdapter();
        }

        public List<Curso> GetAll()
        {
          return _cursoData.GetAll();
        }

        public List<int> CursosProfesor(int idProfesor)
        {
            return _cursoData.CursosProfesor(idProfesor);
        }
        public List<Curso> GetAll(int idMateria)
        {
            return _cursoData.GetAll(idMateria);
        }

        public  Curso GetOne(int idCurso)
        {
            return _cursoData.GetOne(idCurso);

        }
        public void Delete(int idCurso)
        {
            _cursoData.Delete(idCurso);

        }

        public void Save(Curso curso)
        {
            _cursoData.Save(curso);
        }
    }
}
