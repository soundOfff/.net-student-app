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
    public partial class Inscripciones : Form
    {


        public Inscripciones()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = true;
        }

        public void Listar()
        {
            MateriasLogic ml = new MateriasLogic();
            try
            { 
                this.dgvInscripciones.DataSource = ml.getDatosInscripcion();
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al obtener todos las materias para inscripcion");
                MessageBox.Show("Codigo de error: #404", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.dgvInscripciones.SelectedRows.Count == 0)
           {
               MessageBox.Show("Debe seleccionar un usuario");
           }
           else
           {
                int ID = Convert.ToInt32(this.dgvInscripciones.SelectedRows[0].Cells[0].Value);
                string DescPlan = Convert.ToString(this.dgvInscripciones.SelectedRows[0].Cells[5].Value);
                string DescComision = Convert.ToString(this.dgvInscripciones.SelectedRows[0].Cells[6].Value);
                int IDcur = Convert.ToInt32(this.dgvInscripciones.SelectedRows[0].Cells[4].Value);
                InscripcionesDesktop formTest = new InscripcionesDesktop(ID, DescPlan, DescComision, IDcur);
                formTest.ShowDialog();
                Listar();
            }
        }

        private void dgvInscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Inscripciones_Shown(object sender, EventArgs e)
        {
            formLogin fLogin = new formLogin();

            if (fLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}