using Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.DescMateria = (string)drMaterias["desc_materia"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetAll(int idPlan)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias " +
                    "WHERE id_plan = @idPlan", SqlConn);
                cmdMaterias.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.DescMateria = (string)drMaterias["desc_materia"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    // Foregin key ?
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public ArrayList getDatosInscripcion(int idPlan)
        {

            ArrayList datosInscripcion = new ArrayList();

            try
            {

                this.OpenConnection();
                string query = @"SELECT	materias.desc_materia,
		                        materias.hs_totales, materias.hs_semanales, materias.id_materia,
		                        comisiones.desc_comision, cursos.id_curso, planes.desc_plan
                                FROM materias
                                INNER JOIN cursos
	                                ON cursos.id_materia = materias.id_materia
                                INNER JOIN comisiones
	                                ON cursos.id_comision = comisiones.id_comision
                                INNER JOIN planes 
                                    ON planes.id_plan = materias.id_plan
                                WHERE materias.id_plan = @idPlan";

                SqlCommand cmdInscripciones = new SqlCommand(query, SqlConn);
                cmdInscripciones.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    datosInscripcion.Add(new
                    {
                        IDMateria = (int)drInscripciones["id_materia"],
                        DescMateria = (string)drInscripciones["desc_materia"],
                        HsSemanales = (int)drInscripciones["hs_semanales"],
                        HsTotales = (int)drInscripciones["hs_totales"],
                        IDcurso = (int)drInscripciones["id_curso"],
                        DescPlan = (string)drInscripciones["desc_plan"],
                        DescComision = (string)drInscripciones["desc_comision"],
                    });
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return datosInscripcion;
        }



        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia = @id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.DescMateria = (string)drMaterias["desc_materia"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elminiar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_materia = @desc_materia," +
                    " hs_totales = @hs_totales, hs_semanales = @hs_semanales," +
                    " WHERE id_materia = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                // Ver foreign keys
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into materias(desc_materia, hs_totales, hs_semanales) " +
                    "values(@desc_materia, @hs_totales, @hs_semanales) " +
                    "select @@identity", SqlConn);
                // Esta linea es para recuperar el id que asigno el sql automaticamente

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


    }
}
