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
    public partial class Usuarios : System.Web.UI.Page
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

        private Usuario Entity
        {
            get;
            set;
        }

        private int IDseleccionado
        {
            get
            {
                if(this.ViewState["IDseleccionado"] != null)
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


        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
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
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                LoadGrid();
            }
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.EMail;
            this.habilitadoChechBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;

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

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.EMail = this.emailTextBox.Text;
            usuario.Habilitado = this.habilitadoChechBox.Checked;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;


        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            
            int numModo = (int)this.ModoForm;
            switch (numModo)
            {
                case 0:
                    this.Entity = new Usuario();
                    this.LoadEntity(Entity);
                    this.SaveEntity(Entity);
                    break;
                case 1:
                    this.Entity.State = BusinessEntity.States.Deleted;
                    this.DeleteEntity(IDseleccionado);
                    break;
                case 2:
                    this.Entity = new Usuario();
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
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
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
            this.habilitadoChechBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

            this.LoadGrid();

            this.formPanel.Visible = false;
        }
    }
}