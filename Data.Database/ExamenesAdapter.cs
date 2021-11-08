using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Data.Database
{
    public class ExamenesAdapter: Adapter
    {
        public List<Examen> GetAll()
        {

            List<Examen> examenes = new List<Examen>();

            try
            {       //ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    // ins.IdCurso = (int)drInscripciones["id_curso"];

                string query = @"SELECT distinct alumnos_inscripciones.id_inscripcion, materias.desc_materia, alumnos_inscripciones.nota, especialidades.desc_especialidad, planes.desc_plan, personas.legajo, cursos.id_curso
                            FROM alumnos_inscripciones                          
                            INNER JOIN personas
	                            ON alumnos_inscripciones.id_alumno = personas.id_persona
                            INNER JOIN cursos 
	                            ON cursos.id_curso = alumnos_inscripciones.id_curso
                            INNER JOIN materias
	                            ON materias.id_materia = cursos.id_materia
                            INNER JOIN planes
	                              ON planes.id_plan = materias.id_plan
                            INNER JOIN especialidades
	                             ON especialidades.id_especialidad = planes.id_especialidad";
                // INNER JOIN alumnos_inscripciones
                // ON docentes_cursos.id_curso = alumnos_inscripciones.id_curso

                this.OpenConnection();
                SqlCommand cmdExamenes = new SqlCommand(query, SqlConn);
                SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
                while (drExamenes.Read())
                {
                    Examen exa = new Examen();

                    exa.DescMateria = (string)drExamenes["desc_materia"];
                    exa.Nota = (int)drExamenes["nota"];
                    exa.DescEspecialidad = (string)drExamenes["desc_especialidad"];
                    exa.DescPlan = (string)drExamenes["desc_plan"];
                    exa.ID = (int)drExamenes["id_inscripcion"];
                    exa.Legajo = (int)drExamenes["legajo"];
                    exa.IdCurso = (int)drExamenes["id_curso"];
                    examenes.Add(exa);
                }

                drExamenes.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return examenes;
        }


        public List<Examen> GetEP(List<int> idCursos)
        {
            List<Examen> infoExamenes = new List<Examen>();
            foreach (int idCurso in idCursos)
            {
                try
                {


                    string query = @"SELECT distinct materias.desc_materia, especialidades.desc_especialidad, planes.desc_plan, alumnos_inscripciones.id_curso
                                FROM alumnos_inscripciones 
                                INNER JOIN cursos 
	                                ON cursos.id_curso = alumnos_inscripciones.id_curso
                                INNER JOIN materias
	                                ON materias.id_materia = cursos.id_materia
                                INNER JOIN planes
	                                ON planes.id_plan = materias.id_plan
                                INNER JOIN especialidades
	                                ON especialidades.id_especialidad = planes.id_especialidad
                                WHERE alumnos_inscripciones.id_curso = @idCurso";


                    this.OpenConnection();
                    SqlCommand cmdExamenes = new SqlCommand(query, SqlConn);
                    cmdExamenes.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                    SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
                    while (drExamenes.Read())
                    {
                       /* infoExamenes.Add(new
                        {   id_curso = (int)drExamenes["id_curso"],
                            DescMateria = (string)drExamenes["desc_materia"],
                            DescEspecialidad = (string)drExamenes["desc_especialidad"],
                            DescPlan = (string)drExamenes["desc_plan"]
                        });*/
                        Examen ex = new Examen();
                        ex.IdCurso = (int)drExamenes["id_curso"];
                        ex.DescMateria = (string)drExamenes["desc_materia"];
                        ex.DescEspecialidad = (string)drExamenes["desc_especialidad"];
                        ex.DescPlan = (string)drExamenes["desc_plan"];
                        infoExamenes.Add(ex);
                        

                    }

                    drExamenes.Close();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                    throw ExcepcionManejada;


                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return infoExamenes;


        
        }

        public List<Examen> GetAll(Persona per)
        {
            List<Examen> infoExamenes = new List<Examen>();
            //string query = "";
            // Usuario usr = new Usuario();

            try
            {       //ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    // ins.IdCurso = (int)drInscripciones["id_curso"];
                if(per.TipoPersona == 2)
                {
                    infoExamenes = GetProfesor(per);
                }
                else
                {
                    infoExamenes = GetAlumno(per);
                }

   
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                throw ExcepcionManejada;


            }
            finally
            {
                this.CloseConnection();
            }
            return infoExamenes;


        }

        public Examen GetOne(int ID)
        {
            Examen ins = new Examen();

            try
            {
                string query = @"SELECT distinct alumnos_inscripciones.id_inscripcion, materias.desc_materia, alumnos_inscripciones.nota, especialidades.desc_especialidad, planes.desc_plan, personas.legajo, alumnos_inscripciones.id_curso
                            FROM alumnos_inscripciones
                            INNER JOIN personas
                                ON alumnos_inscripciones.id_alumno = personas.id_persona
                            INNER JOIN cursos
                                ON cursos.id_curso = alumnos_inscripciones.id_curso
                            INNER JOIN materias
                                ON materias.id_materia = cursos.id_materia
                            INNER JOIN planes
                                  ON planes.id_plan = materias.id_plan
                            INNER JOIN especialidades
                                 ON especialidades.id_especialidad = planes.id_especialidad
                        where alumnos_inscripciones.id_inscripcion = @id";
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand(query, SqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Legajo = (int)drInscripciones["legajo"];
                    ins.IdCurso = (int)drInscripciones["id_curso"];
                    ins.Nota = (int)drInscripciones["nota"];

                }
                drInscripciones.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            
            return ins;


        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id ", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elminiar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Inscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }

        protected void Insert(Inscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota) " +
                     "values(@id_alumno, @id_curso, @condicion, @nota) " + 
                     "select @@identity", SqlConn);

                
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }


        }

        protected void Update(Inscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Update alumnos_inscripciones SET id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, condicion = @condicion, nota = @nota " + 
                    "Where id_inscripcion = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }



        private List<Examen> GetAlumno(Persona per)
        {
            List<Examen> Examenes = new List<Examen>();

            string query = @"SELECT materias.desc_materia, alumnos_inscripciones.nota, especialidades.desc_especialidad, planes.desc_plan
                                FROM alumnos_inscripciones 
                                INNER JOIN cursos 
	                                ON cursos.id_curso = alumnos_inscripciones.id_curso
                                INNER JOIN materias
	                                ON materias.id_materia = cursos.id_materia
                                INNER JOIN planes
	                                ON planes.id_plan = materias.id_plan
                                INNER JOIN especialidades
	                                ON especialidades.id_especialidad = planes.id_especialidad
                                WHERE alumnos_inscripciones.id_alumno = @id_persona"; // , cursos.id_curso, materias.id_materia, planes.id_plan, especialidades.id_especialidad

            this.OpenConnection();
            SqlCommand cmdExamenes = new SqlCommand(query, SqlConn);
            cmdExamenes.Parameters.Add("@id_persona", SqlDbType.Int).Value = per.ID;
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            while (drExamenes.Read())
            {
                Examen exa = new Examen();

                exa.DescEspecialidad = (string)drExamenes["desc_especialidad"];
                exa.Nota = (int)drExamenes["nota"];
                exa.DescMateria = (string)drExamenes["desc_materia"];
                exa.DescPlan = (string)drExamenes["desc_plan"];

                Examenes.Add(exa);

            }

            drExamenes.Close();

            return Examenes;
        }


        private List<Examen> GetProfesor(Persona per)
        {
            List<Examen> Examenes = new List<Examen>();

            string query = @"SELECT distinct alumnos_inscripciones.id_inscripcion, materias.desc_materia, alumnos_inscripciones.nota, especialidades.desc_especialidad, planes.desc_plan, personas.legajo, docentes_cursos.id_curso
                            FROM docentes_cursos 
                            INNER JOIN alumnos_inscripciones
	                            ON docentes_cursos.id_curso = alumnos_inscripciones.id_curso
                            INNER JOIN personas
	                            ON alumnos_inscripciones.id_alumno = personas.id_persona
                            INNER JOIN cursos 
	                            ON cursos.id_curso = alumnos_inscripciones.id_curso
                            INNER JOIN materias
	                            ON materias.id_materia = cursos.id_materia
                            INNER JOIN planes
	                              ON planes.id_plan = materias.id_plan
                            INNER JOIN especialidades
	                             ON especialidades.id_especialidad = planes.id_especialidad
                            WHERE docentes_cursos.id_docente = @id_persona"; // , cursos.id_curso, materias.id_materia, planes.id_plan, especialidades.id_especialidad

            this.OpenConnection();
            SqlCommand cmdExamenes = new SqlCommand(query, SqlConn);
            cmdExamenes.Parameters.Add("@id_persona", SqlDbType.Int).Value = per.ID;
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            while (drExamenes.Read())
            {
                Examen exa = new Examen();

                exa.DescEspecialidad = (string)drExamenes["desc_especialidad"];
                exa.Nota = (int)drExamenes["nota"];
                exa.DescMateria = (string)drExamenes["desc_materia"];
                exa.DescPlan = (string)drExamenes["desc_plan"];
                exa.Legajo = (int)drExamenes["legajo"];
                exa.ID = (int)drExamenes["id_inscripcion"];
                exa.IdCurso = (int)drExamenes["id_curso"];

                Examenes.Add(exa);


            }

            drExamenes.Close();


            return Examenes;
        }

    }
}
