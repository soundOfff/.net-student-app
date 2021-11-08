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
    public partial class Especialidades : System.Web.UI.Page
    {
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

        private Especialidad Entity
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


        EspecialidadLogic _logic;
        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
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
            }
        }
         private void LoadForm(int id)
         {
             this.Entity = this.Logic.GetOne(id);
             this.descripcionTextBox.Text = this.Entity.DescEspecialidad;

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

         private void LoadEntity(Especialidad especialidad)
         {
            especialidad.DescEspecialidad = this.descripcionTextBox.Text;
        }

         private void SaveEntity(Especialidad especialidad)
         {
             this.Logic.Save(especialidad);
         }

         protected void aceptarLinkButton_Click(object sender, EventArgs e)
        { 
             int numModo = (int)this.ModoForm;
             switch (numModo)
             {
                 case 0:
                     this.Entity = new Especialidad();
                     this.LoadEntity(Entity);
                     this.SaveEntity(Entity);
                     break;
                 case 1:
                     this.Entity = new Especialidad();
                     this.LoadEntity(Entity);
                     this.Entity.State = BusinessEntity.States.Deleted;
                     this.DeleteEntity(IDseleccionado);
                     break;
                 case 2:
                     this.Entity = new Especialidad();
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
             this.descripcionTextBox.Enabled = enable;
             this.idTxt.Enabled = enable;
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
             this.descripcionTextBox.Text = string.Empty;
             this.idTxt.Text = string.Empty;

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