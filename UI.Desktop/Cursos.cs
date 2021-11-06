using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        private Curso _cursoActual;

        public Cursos()
        {
            InitializeComponent();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            CursoLogic cl = new CursoLogic();

            dgvCursos.DataSource = cl.GetAllDGV();

        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            CursosABM formTest = new CursosABM(ApplicationForm.ModoForm.Alta);
            formTest.ShowDialog();
            Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Curso");
            }
            else
            {
                _cursoActual = (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
                CursosABM formTest = new CursosABM(_cursoActual, ApplicationForm.ModoForm.Modificacion);
                formTest.ShowDialog();
                
            }

            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Curso");
            }
            else
            {
                _cursoActual = (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
                CursosABM formTest = new CursosABM(_cursoActual, ApplicationForm.ModoForm.Baja);
                formTest.ShowDialog();

            }

            Listar();
        }
    }
}
