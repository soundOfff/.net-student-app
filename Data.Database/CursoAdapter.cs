using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
   public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();


            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos ", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];



                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Cursos", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<Curso> GetAll(int idMateria)
        {
            List<Curso> cursos = new List<Curso>();


            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos " +
                    "WHERE id_materia = @idMateria", SqlConn);
                cmdCursos.Parameters.Add("idMateria", SqlDbType.Int).Value = idMateria;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cursos.Add(cur);


                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Cursos", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<int> CursosProfesor(int idProfesor)
        {
            List<int> idCursos = new List<int>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdIdCursos = new SqlCommand("SELECT id_curso FROM docentes_cursos " +
                    "WHERE id_docente = @idProfesor", SqlConn);
                cmdIdCursos.Parameters.Add("idProfesor", SqlDbType.Int).Value = idProfesor;
                SqlDataReader drIdCursos = cmdIdCursos.ExecuteReader();
                while (drIdCursos.Read())
                {
                    
                   int idCurso = (int)drIdCursos["id_curso"];
                    
                    idCursos.Add(idCurso);


                }
                drIdCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Cursos", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }

            return idCursos;
        }


        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                }
                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id ", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elminiar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }


        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into cursos(id_materia, id_comision, anio_calendario, cupo) " +
                     "values(@id_materia, @id_comision, @anio_calendario, @cupo) " +
                     "select @@identity", SqlConn);


                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Curso", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }


        }


        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Update cursos SET id_materia = @id_materia, " +
                    "id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo " +
                    "where id_curso = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del Curso", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Curso> GetAllDGV()
        {
            List<Curso> cursos = new List<Curso>();


            try
            {
                

               string query = "select c.id_curso, c.anio_calendario, c.cupo, m.id_materia, m.desc_materia, co.id_comision, co.desc_comision, co.anio_especialidad, p.id_plan, p.desc_plan, e.id_especialidad, e.desc_especialidad from cursos c " +
                "INNER JOIN materias m " +
                    "ON m.id_materia = c.id_materia " +
                "INNER JOIN comisiones co " +
                    "ON co.id_comision = c.id_comision " +
                "INNER JOIN planes p " +
                    "ON p.id_plan = co.id_plan " +
                    "AND p.id_plan = m.id_plan " +
                "INNER JOIN especialidades e " +
                    "ON e.id_especialidad = p.id_especialidad ";

                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(query, SqlConn);



                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.DescMateria = (string)drCursos["desc_materia"];
                    cur.DescComision = (string)drCursos["desc_comision"];
                    cur.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.IdPlan = (int)drCursos["id_plan"];
                    cur.DescPlan = (string)drCursos["desc_plan"];
                    cur.DescEspecialidad = (string)drCursos["desc_especialidad"];
                    cur.IdEspecialidad = (int)drCursos["id_especialidad"];

                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Cursos", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }


    }
}
