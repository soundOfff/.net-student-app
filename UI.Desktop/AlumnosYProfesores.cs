using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UI.Desktop.ApplicationForm;

namespace UI.Desktop
{
    public partial class AlumnosYProfesores : Form
    {
        PersonaLogic pl = new PersonaLogic();
        public AlumnosYProfesores()
        {
            InitializeComponent();
            dgvAlPro.AutoGenerateColumns = false;
        }

        private void AlumnosYProfesores_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            dgvAlPro.DataSource = pl.GetAll();
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
            NuevoAlumnoOProfe nap = new NuevoAlumnoOProfe();
            nap.ShowDialog();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlPro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            else
            {
                int ID = ((Business.Entities.Persona)this.dgvAlPro.SelectedRows[0].DataBoundItem).ID;
                NuevoAlumnoOProfe formTest = new NuevoAlumnoOProfe(ID, ModoForm.Baja);
                formTest.ShowDialog();
                Listar();
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvAlPro.SelectedRows[0].DataBoundItem).ID;
            NuevoAlumnoOProfe formTest = new NuevoAlumnoOProfe(ID, ModoForm.Modificacion);
            formTest.ShowDialog();
            Listar();
        }
    }
}
