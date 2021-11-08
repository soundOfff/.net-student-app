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
    public partial class CursosABM : ApplicationForm
    {
        private Curso _cursoActual;
        public CursosABM(ModoForm modo)
        {
            InitializeComponent();

            _modo = modo;
        }

        public CursosABM( Curso curso, ModoForm modo)
        {
            InitializeComponent();


            _cursoActual = curso;
            _modo = modo;


        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CursosABM_Load(object sender, EventArgs e)
        {
            if (!(_modo == ModoForm.Baja))
            {
                btonAceptar.Text = "Crear";
                nudCupo.Enabled = true;
                txtAnioCalendario.Enabled = true;

                
                if (_modo == ModoForm.Modificacion)
                {
                    btonAceptar.Text = "Editar";
                    txtIdComision.Text = _cursoActual.IdComision.ToString();
                    txtIdCurso.Text = _cursoActual.ID.ToString();
                    txtIdMateria.Text = _cursoActual.IdMateria.ToString();
                    nudCupo.Value = _cursoActual.Cupo;
                    txtAnioCalendario.Text = _cursoActual.AnioCalendario.ToString();

                    

                }
                MateriasLogic mat = new MateriasLogic();
                dgvMateria.DataSource = mat.GetAll();
                ComisionesLogic com = new ComisionesLogic();
                dgvComision.DataSource = com.GetAll();

            }
            else
            {
                btonAceptar.Text = "Eliminar";
                nudCupo.Enabled = false;
                txtAnioCalendario.Enabled = false;
                
                txtIdComision.Text = _cursoActual.IdComision.ToString();
                txtIdCurso.Text = _cursoActual.ID.ToString();
                txtIdMateria.Text = _cursoActual.IdMateria.ToString();
                nudCupo.Value = _cursoActual.Cupo;
                txtAnioCalendario.Text = _cursoActual.AnioCalendario.ToString();

            }





        }

        private void btonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Curso cur = new Curso();
                CursoLogic cl = new CursoLogic();

                cur.IdComision = Int32.Parse(txtIdComision.Text);
                cur.IdMateria = Int32.Parse(txtIdMateria.Text);
                cur.Cupo = Int32.Parse(nudCupo.Value.ToString());
                cur.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);

                if (_modo == ModoForm.Modificacion)
                {
                    cur.State = BusinessEntity.States.Modified;
                    cur.ID = Int32.Parse(txtIdCurso.Text);
                }
                else if (_modo == ModoForm.Alta)
                {
                    cur.State = BusinessEntity.States.New;
                }
                else
                {
                    cur.State = BusinessEntity.States.Deleted;
                    cur.ID = Int32.Parse(txtIdCurso.Text);
                }

                cl.Save(cur);

                this.Dispose();

            }
            catch(Exception ex)
            {
                Exception ExepcionManejada = new Exception("Error al " + btonAceptar.Text + " Curso");
                MessageBox.Show("Codigo de error: #404", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvMateria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvMateria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtIdMateria.Text = dgvMateria.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }*/
        }

        private void dgvComision_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvComision.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtIdComision.Text = dgvComision.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }*/
        }

        private void dgvMateria_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdMateria.Text = ((Materia)dgvMateria.SelectedRows[0].DataBoundItem).ID.ToString();
        }

        private void dgvComision_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdComision.Text = ((Comision)dgvComision.SelectedRows[0].DataBoundItem).ID.ToString();
        }
    }
}
