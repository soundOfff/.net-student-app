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
    public partial class Especialidades: Form
    {
        private Persona _personaRegistrada;
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }
        public Especialidades(Persona per)
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
            _personaRegistrada = per;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            if (_personaRegistrada == null)
            {
                Listar();
            }
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
            if (_personaRegistrada == null)
            {
                EspecialidadesDesktop formTest = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
                formTest.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (_personaRegistrada == null)
            {
                if (this.dgvEspecialidades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una especialidad");
                }
                else
                {
                    int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                    EspecialidadesDesktop formTest = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formTest.ShowDialog();
                    Listar();
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_personaRegistrada == null)
            {
                if (this.dgvEspecialidades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una especialidad");
                }
                else
                {
                    int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                    EspecialidadesDesktop formTest = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formTest.ShowDialog();
                    Listar();
                }
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

        private void tlEspecialidades_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
