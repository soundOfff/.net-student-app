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
    public partial class ExamenesABM : ApplicationForm
    {
        Persona _personaRegistrada = new Persona();
        private int btonClick;
        private int idSiguiente;
        private string datoAdd;
        public ExamenesABM(Persona per)
        {
            InitializeComponent();

            _personaRegistrada = per;
        }

        

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            btonClick++;

            if(this.dgvDatosExamenes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Fila");
            }
            else
            {
                switch (btonClick)
                {
                    case 1:
                        idSiguiente = ((Business.Entities.Especialidad)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).ID;
                        MessageBox.Show("El id elegido es " + idSiguiente.ToString());
                        datoAdd = ((Especialidad)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).DescEspecialidad;
                        txtEspecialidadDesc.Text = datoAdd;
                        ListarPlan(idSiguiente);
                        break;
                    case 2:
                        idSiguiente = ((Plan)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).ID;
                        MessageBox.Show("El id elegido es " + idSiguiente.ToString());
                        datoAdd = ((Plan)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).DescPlan;
                        txtPlanDesc.Text = datoAdd;
                        ListarMaterias(idSiguiente);
                        break;
                    case 3:
                        idSiguiente = ((Materia)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).ID;
                        MessageBox.Show("El id elegido es " + idSiguiente.ToString());
                        datoAdd = ((Materia)this.dgvDatosExamenes.SelectedRows[0].DataBoundItem).DescMateria;
                        txtDescMateria.Text = datoAdd;
                        ListarCursos(idSiguiente);
                        break;
                   
                }
            }
        }

        private void ExamenesABM_Load(object sender, EventArgs e)
        {
            EspecialidadLogic esp = new EspecialidadLogic();

            this.dgvDatosExamenes.DataSource = esp.GetAll();

            btonClick = 0;
        }

        public void ListarPlan(int idEspecialidad)
        {
            PlanLogic plan = new PlanLogic();
            dgvDatosExamenes.DataSource = null;
            dgvDatosExamenes.Rows.Clear();
            dgvDatosExamenes.DataSource = plan.GetAll(idEspecialidad);
        }

        public void ListarMaterias(int idPlan)
        {
            MateriasLogic materia = new MateriasLogic();
            dgvDatosExamenes.DataSource = null;
            dgvDatosExamenes.Rows.Clear();
            dgvDatosExamenes.DataSource = materia.GetAll(idPlan);
        }


        public void ListarCursos(int idMateria)
        {
            CursoLogic curso = new CursoLogic();
            dgvDatosExamenes.DataSource = null;
            dgvDatosExamenes.Rows.Clear();
            dgvDatosExamenes.DataSource = curso.GetAll(idMateria);
        }

        public void GuardarNuevoExamen()
        {   
            // if => No es admin
                // if => Si el curso le pertenece al profesor
                //      Guardar id_curso, Nota( n >= 6 = Aprobada), y por legajo buscar y luego guardar el id_Alumno
                  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
