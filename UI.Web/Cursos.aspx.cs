using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Cursos : System.Web.UI.Page
    {
        public enum ModosForm
        {
            Alta,
            Baja,
            Modificacion
        }

        public ModosForm ModoForm
        {
            get { return (ModosForm)this.ViewState["ModoForm"]; }
            set { this.ViewState["ModoForm"] = value; }
        }

        private CursoLogic _cursoActual;

        private int IDseleccionado
        {
            get
            {
                if (this.ViewState["IDseleccionado"] != null)
                {
                    return (int)this.ViewState["IDseleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["IDseleccionado"] = value;
            }
        }
        private CursoLogic Logic
        {
            get
            {
                if (_cursoActual == null)
                {
                    _cursoActual = new CursoLogic();
                }
                return _cursoActual;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if ((string)Session["rol"] != "admin")
            {
                Response.Redirect("MenuAutogestion.aspx");
            }
            else
            {
                Panel3.Visible = false;
                dgvCursos.AutoGenerateColumns = false;
                Listar();
            }

        }
        public void Listar()
        {
            CursoLogic exam = new CursoLogic();
            dgvCursos.DataSource = exam.GetAllDGV();
            dgvCursos.DataBind();

        }

        protected void btonEditar_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Modificacion;
            EnableForm(true);
            ClearForm();
            // _examenActual = ((Examen)this.dgvExamenes.SelectedRow.DataItem);
            Curso exa = Logic.GetOne(this.IDseleccionado);
            loadForm(exa);

        }

        protected void btonNuevo_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Alta;
            EnableForm(true);
            ClearForm();

        }


        protected void btonEliminar_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Baja;
            EnableForm(false);
            ClearForm();
            Curso exa = Logic.GetOne(this.IDseleccionado);
            loadForm(exa);
        }

        protected void dgvExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IdSeleccinado = ((int)this.dgvExamenes.SelectedRow.DataItem);
            this.IDseleccionado = ((int)this.dgvCursos.SelectedValue);
        }

        protected void btonAceptar_Click(object sender, EventArgs e)
        {
            this.Save();
        }


        private void loadForm(Curso exa)
        {
            txtIdCurso.Text = exa.ID.ToString();
            txtIdMateria.Text = exa.IdMateria.ToString();
            txtIdComision.Text = exa.IdComision.ToString();
            txtAnioCalendario.Text = exa.AnioCalendario.ToString();
            txtCupo.Text = exa.Cupo.ToString();

        }
        private void EnableForm(bool enable)
        {
            txtIdCurso.Enabled = false;
            txtIdMateria.Enabled = enable;
            txtIdComision.Enabled = enable;
            txtAnioCalendario.Enabled = enable;
            txtCupo.Enabled = enable;
        }


        private void ClearForm()
        {
            txtIdCurso.Text = "";
            txtIdMateria.Text = "";
            txtIdComision.Text = "";
            txtAnioCalendario.Text = "";
            txtCupo.Text = "";

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAutogestion.aspx");
        }

        private void Save()
        {
            
            Curso insc = new Curso();

            

            insc.IdMateria = (Int32.Parse(txtIdMateria.Text));
            insc.IdComision = Int32.Parse(txtIdComision.Text);
            insc.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);
            insc.Cupo = Int32.Parse(txtCupo.Text);
           


            int numModo = (int)this.ModoForm;
            switch (numModo)
            {
                case 0:
                    insc.State = BusinessEntity.States.New;
                    break;
                case 1:
                    insc.State = BusinessEntity.States.Deleted;
                    insc.ID = Int32.Parse(txtIdCurso.Text);
                    break;
                case 2:
                    insc.State = BusinessEntity.States.Modified;
                    insc.ID = Int32.Parse(txtIdCurso.Text);
                    break;
                default:
                    break;
            }



            CursoLogic inscLogic = new CursoLogic();


            inscLogic.Save(insc);
            Listar();

        }





    }
}