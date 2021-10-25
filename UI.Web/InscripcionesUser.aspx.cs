using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class InscripcionesUser : System.Web.UI.Page
    {
        private Inscripcion _insActual = new Inscripcion();
        InscripcionLogic _inscLogic = new InscripcionLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                Listar();
            }

        }

        public void Listar()
        { 
            MateriasLogic ml = new MateriasLogic();

            try
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Convert.ToString(_perTest.IDPlan) + "');", true
                this.grdInscripciones.DataSource = ml.getDatosInscripcion(Login._personaRegistrada.IDPlan);
                this.grdInscripciones.DataBind();
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al obtener todos las materias para inscripcion");
            }
        }

        private void LoadForm()
        {
            txtMat.Text = this.grdInscripciones.SelectedRow.Cells[2].Text;
            txtCom.Text = this.grdInscripciones.SelectedRow.Cells[6].Text;
            txtPlan.Text = this.grdInscripciones.SelectedRow.Cells[5].Text;
            txtHsSem.Text = this.grdInscripciones.SelectedRow.Cells[3].Text;
            txtHsTot.Text = this.grdInscripciones.SelectedRow.Cells[4].Text;
        }

        private void EnableForm(bool enable)
        {
            this.btnInscripcion.Visible = enable;
            this.btnCancel.Visible = enable;
            this.Panel1.Visible = enable;
        }
        private void MapearDatos()
        {
            _insActual.IdCurso = Convert.ToInt16(this.grdInscripciones.SelectedRow.Cells[5].Text);
            _insActual.Condicion = "Inscripto";
            _insActual.IdAlumno = Login._personaRegistrada.ID;
        }


        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            
            try
            {
                MapearDatos();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Inscripcion en proceso" + "');", true);
                _inscLogic.Save(_insActual);
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al inscribirse");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error" + "');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EnableForm(false);
        }

        protected void grdInscripciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inscLogic.getUserAlreadyInscript(Convert.ToInt16(this.grdInscripciones.SelectedRow.Cells[5].Text), Login._personaRegistrada.ID))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ya te encuentras registrado" + "');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Perfecto no estas inscripto" + "');", true);
                this.EnableForm(true);
                this.LoadForm();
            }
          
        }
    }
}