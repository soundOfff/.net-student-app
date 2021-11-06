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
    public partial class Personas : System.Web.UI.Page
    {
        private PlanLogic pl = new PlanLogic();
        private EspecialidadLogic el = new EspecialidadLogic();
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

        private Persona Entity
        {
            get;
            set;
        }

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

        private bool EntidadSeleccionada
        {
            get
            {
                return (this.IDseleccionado != 0);
            }
        }


        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
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
                LoadGrid();
                if (!this.IsPostBack)
                {
                    LlenarDropDown();
                }
            }
        }
         private void LoadForm(int id)
         {
             this.Entity = this.Logic.GetOne(id);
             this.nombreTextBox.Text = this.Entity.Nombre;
             this.apellidoTextBox.Text = this.Entity.Apellido;
             this.emailTextBox.Text = this.Entity.EMail;
             this.direccionTxt.Text = this.Entity.Direccion;
             this.fechaTxt.Text = this.Entity.FechaNac.ToString();
             this.legajoTxt.Text = this.Entity.Legajo.ToString();
             this.telTxt.Text = this.Entity.Telefono;
             if (Entity.TipoPersona == 1)
            {
                this.dropTipo.Text = "Alumno";
            }
             else
            {
                this.dropTipo.Text = "Profesor";
            }

            var plan = pl.GetOne(Entity.IDPlan);
            var esp = el.GetOne(plan.IDEspecialidad);

            this.dropPlan.Text = plan.DescPlan;
            this.dropEsp.Text = esp.DescEspecialidad;
        }

         protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
         {
             this.IDseleccionado = (int)this.gridView.SelectedValue;
         }

         protected void editarLinkButton_Click(object sender, EventArgs e)
         {
             if (this.EntidadSeleccionada)
             {
                 this.formPanel.Visible = true;
                 this.ModoForm = ModosForm.Modificacion;
                 this.EnableForm(true);
                 this.LoadForm(this.IDseleccionado);
             }
         }

         private void LoadEntity(Persona persona)
         {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.EMail = this.emailTextBox.Text;
            persona.Direccion = this.direccionTxt.Text;
            persona.Legajo = Convert.ToInt32(this.legajoTxt.Text);
            persona.FechaNac = Convert.ToDateTime(this.fechaTxt.Text);
            persona.Telefono = this.telTxt.Text;
            persona.IDPlan = pl.GetOne(this.dropPlan.Text, this.dropEsp.Text);
            persona.TipoPersona = dropTipo.SelectedIndex + 1;
        }

         private void SaveEntity(Persona persona)
         {
             this.Logic.Save(persona);
         }

         protected void aceptarLinkButton_Click(object sender, EventArgs e)
        { 
             int numModo = (int)this.ModoForm;
             switch (numModo)
             {
                 case 0:
                     this.Entity = new Persona();
                     this.LoadEntity(Entity);
                     this.SaveEntity(Entity);
                     break;
                 case 1:
                     this.Entity = new Persona();
                     this.LoadEntity(Entity);
                     this.Entity.State = BusinessEntity.States.Deleted;
                     this.DeleteEntity(IDseleccionado);
                     break;
                 case 2:
                     this.Entity = new Persona();
                     this.Entity.ID = this.IDseleccionado;
                     this.LoadEntity(Entity);
                     this.Entity.State = BusinessEntity.States.Modified;
                     this.LoadEntity(Entity);
                     this.SaveEntity(Entity);
                     break;
                 default:
                     break;
             }
             
             this.LoadGrid();

             this.formPanel.Visible = false;

         }

         private void EnableForm(bool enable)
         {
             this.nombreTextBox.Enabled = enable;
             this.apellidoTextBox.Enabled = enable;
             this.emailTextBox.Enabled = enable;
             this.direccionTxt.Enabled = enable;
             this.dropTipo.Visible = enable;
             this.fechaTxt.Visible = enable;
             this.legajoTxt.Visible = enable;
             this.dropPlan.Visible = enable;
             
        }


        protected void LlenarDropDown()
        {
            var descPlanes = pl.GetAllDistinct();
            var especialidades = el.GetAll();
            foreach (string plan in descPlanes)
            {
                this.dropPlan.Items.Add(plan);

            }
            foreach (var item in especialidades)
            {
                this.dropEsp.Items.Add(item.DescEspecialidad);
            }
            this.dropTipo.Items.Add("Alumno");
            this.dropTipo.Items.Add("Profesor");
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
         {
             if (this.EntidadSeleccionada)
             {
                 this.formPanel.Visible = true;
                 this.ModoForm = ModosForm.Baja;
                 this.EnableForm(false);
                 this.LoadForm(this.IDseleccionado);

             }
         }

         private void DeleteEntity(int id)
         {
             this.Logic.Delete(id);
         }

         protected void nuevoLinkButton_Click(object sender, EventArgs e)
         {
             this.formPanel.Visible = true;
             this.ModoForm = ModosForm.Alta;
             this.ClearForm();
             this.EnableForm(true);

         }

         private void ClearForm()
         {
             this.nombreTextBox.Text = string.Empty;
             this.apellidoTextBox.Text = string.Empty;
             this.emailTextBox.Text = string.Empty;
             this.direccionTxt.Text = string.Empty;
             this.fechaTxt.Text = string.Empty;
             this.legajoTxt.Text = string.Empty;
             this.telTxt.Text = string.Empty;
        }

         protected void cancelarLinkButton_Click(object sender, EventArgs e)
         {
             this.LoadGrid();
             this.formPanel.Visible = false;
         }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAutogestion.aspx");
        }
    }
    
}