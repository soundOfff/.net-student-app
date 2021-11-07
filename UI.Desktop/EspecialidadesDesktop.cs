using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        private Especialidad _especialidadActual;

        public Especialidad EspecialidadActual { get { return _especialidadActual; } set { _especialidadActual = value; } }


        public EspecialidadesDesktop(ModoForm modo) : this()
        {
            this.txtDescripcion.Enabled = true;
            _modo = modo;
        }

        public EspecialidadesDesktop(int ID, ModoForm modo) : this()
        {
            this.txtDescripcion.Enabled = true;
            EspecialidadLogic el = new EspecialidadLogic();
            _especialidadActual = el.GetOne(ID);
            _modo = modo;
            MapearDeDatos();
        }

        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }
        public override  void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.DescEspecialidad;


            switch (_modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }

        }
        public override void MapearADatos()
        {
            if (_modo == ModoForm.Alta)
            {
                _especialidadActual = new Especialidad();
                _especialidadActual.State = BusinessEntity.States.New;

            }
            else if (_modo == ModoForm.Modificacion)
            {
                _especialidadActual.State = BusinessEntity.States.Modified;
               
            }


            
            _especialidadActual.DescEspecialidad = this.txtDescripcion.Text;

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic _especialidadLogic = new EspecialidadLogic();
            if (_modo == ModoForm.Alta || _modo == ModoForm.Modificacion)
            {
                try
                { 
                    _especialidadLogic.Save(_especialidadActual);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al guardar la especialidad");
                    MessageBox.Show("Codigo de error: #347", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_modo == ModoForm.Baja)
            {
                try
                {
                    _especialidadLogic.Delete(_especialidadActual.ID);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al eliminar la especialidad, burro!");
                    MessageBox.Show("Codigo de error: #505", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar()
        {
            
            if ( String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                Notificar("Error numero: #777", "Hay casillas que estan vacias, por favor complete todos los datos!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
            return true;
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
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
            else
            {
                MessageBox.Show("Burro!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
