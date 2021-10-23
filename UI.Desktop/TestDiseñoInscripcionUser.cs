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
    public partial class TestDiseñoInscripcionUser : Form
    {


        public TestDiseñoInscripcionUser()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = true;
          
        }

        public void Listar()
        {
            MateriasLogic ml = new MateriasLogic();
            try
            {
                
                this.dgvInscripciones.DataSource = ml.getDatosInscripcion(formLogin._personaRegistrada.IDPlan);
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

                InscripcionLogic il = new InscripcionLogic();

                //var regis = il.getUserAlreadyInscript(IDcur, formLogin.UsuarioActual.IDpersona);
                // Validar que el usuario no este inscripto en el curso

                if (il.getUserAlreadyInscript(IDcur, formLogin._personaRegistrada.ID))
                {
                    MessageBox.Show("Ya te registrarste! ");
                }
                else
                {
                    MessageBox.Show("Perfecto no estas inscripto");
                    TestInscDesktopUser formTest = new TestInscDesktopUser(ID, DescPlan, DescComision, IDcur);
                    formTest.ShowDialog();
                }
                
            }
        }

     
        private void TestDiseñoInscripcion_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestDiseñoInscripcionUser_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
