using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class TestInscDesktopUser : ApplicationForm
    {
        // Para mostrar datos de la materia
        private Business.Entities.Materia _matActual;
        // Para crear la instancia inscripcion cuando se confirme
        private Business.Entities.Inscripcion _insActual = new Inscripcion();

        private string _descComision;
        private int _idCurso;
        private string _descPlan;

        public Business.Entities.Materia MateriaActual { get { return _matActual; } set { _matActual = value; } }

        public Business.Entities.Inscripcion InsActual { get { return _insActual; } set { _insActual = value; } }

        public TestInscDesktopUser(int ID, string descPlan, string DescComision, int IDcurso) : this()
        {
            MateriasLogic ml = new MateriasLogic();
            InscripcionLogic il = new InscripcionLogic();
            _matActual = ml.GetOne(ID);
            _idCurso = IDcurso;
            _descComision = DescComision;
            _descPlan = descPlan;
            MapearDeDatos();
        }

        public TestInscDesktopUser()
        {
            InitializeComponent();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtMat.Text = this.MateriaActual.DescMateria;
            this.txtHT.Text = Convert.ToString(this.MateriaActual.HsTotales);
            this.txtHS.Text = Convert.ToString(this.MateriaActual.HsSemanales);
            this.txtPlan.Text = _descPlan;
            this.txtCom.Text = _descComision;
        }


        public override void GuardarCambios()
        {
            InscripcionLogic _inscLogic = new InscripcionLogic();
            MapearUsuario();
            try
            {
                _insActual.IdCurso = _idCurso;
                _insActual.Condicion = "Inscripto";
                _insActual.IdAlumno = formLogin.UsuarioActual.IDpersona;
                DialogResult resultado = MessageBox.Show("Estas seguro de querer inscribirte a la materia? ");
                if (resultado == DialogResult.OK)
                {
                    MessageBox.Show("Entro");
                    _inscLogic.Save(InsActual);
                }
                
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al inscribirse");
                MessageBox.Show("Codigo de error: #347", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapearUsuario()
        {
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(titulo, mensaje, botones, icono);
        }

        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(this.Text, mensaje, botones, icono);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnAceptar_MouseHover(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(124, 159, 144);
            
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(127, 200, 169);
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(143, 59, 59);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(189, 75, 75);
        }
    }
}
