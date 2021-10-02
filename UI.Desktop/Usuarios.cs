using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            
                this.dgvUsuarios.DataSource = ul.GetAll();
            
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuariosDesktop formTest = new UsuariosDesktop(ApplicationForm.ModoForm.Alta);
            formTest.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            else
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuariosDesktop formTest = new UsuariosDesktop( ID, ApplicationForm.ModoForm.Baja);
                formTest.ShowDialog();
                Listar();
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            else { 
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuariosDesktop formTest = new UsuariosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formTest.ShowDialog();
                Listar();
            }
        }

        private void Usuarios_Shown(object sender, EventArgs e)
        {
            formLogin fLogin = new formLogin();
            if (fLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
