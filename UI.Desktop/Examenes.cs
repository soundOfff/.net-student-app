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
    public partial class Examenes : Form
    {
        private Persona _personaRegistrada;
        private Examen _examenActual;
        public Persona PersonaRegistrada { get { return _personaRegistrada; } set { _personaRegistrada = value; } }

        public Examenes(Persona per)
        {
            InitializeComponent();
           // this.dgvExamenes.AutoGenerateColumns = false;
            _personaRegistrada = per;
        }

        public void Listar()
        {
            ExamenesLogic ins = new ExamenesLogic();
            try
            {   if (_personaRegistrada.TipoPersona == 1 || _personaRegistrada.TipoPersona == 2)
                {
                    if(_personaRegistrada.TipoPersona == 1)
                    {
                        dgvExamenes.AutoGenerateColumns = false;
                        this.dgvExamenes.DataSource = ins.GetAll(PersonaRegistrada);
                    }
                    else
                    {
                        dgvExamenes.AutoGenerateColumns = true;
                        this.dgvExamenes.DataSource = ins.GetAll(PersonaRegistrada);
                    }
                }
                else
                {
                    dgvExamenes.AutoGenerateColumns = true;
                    this.dgvExamenes.DataSource = ins.GetAll();
                }
                
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al obtener todos las inscripciones");
                MessageBox.Show("Codigo de error: #404", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Examenes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            ExamenesABM formTest = new ExamenesABM(_personaRegistrada, ApplicationForm.ModoForm.Alta);
            formTest.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(dgvExamenes.SelectedRows.Count == 0) 
            {

                MessageBox.Show("Seleccione ID");
            }
            else
            {
                _examenActual = ((Examen)this.dgvExamenes.SelectedRows[0].DataBoundItem);
                
                ExamenesABM formTest = new ExamenesABM(_personaRegistrada, _examenActual, ApplicationForm.ModoForm.Modificacion);
                formTest.ShowDialog();
            }

        }

        private void dgvExamenes_CellClick(object sender, DataGridViewCellEventArgs e) // Se puede cambiar para que selecion e la fila
        {

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if(dgvExamenes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione ID");
            }
            else
            {
                _examenActual = ((Examen)dgvExamenes.SelectedRows[0].DataBoundItem);

                ExamenesABM formtest = new ExamenesABM(_personaRegistrada, _examenActual, ApplicationForm.ModoForm.Baja);
                formtest.ShowDialog();
            }
        }
    }
}
