using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class NuevoAlumnoOProfe : ApplicationForm
    {
        private Persona perActual = new Persona();
        private PlanLogic pl = new PlanLogic();
        private EspecialidadLogic el = new EspecialidadLogic();
        private PersonaLogic perL = new PersonaLogic();
        public NuevoAlumnoOProfe()
        {
            InitializeComponent();
        }

        public NuevoAlumnoOProfe(int idPlan)
        {

        }
        public NuevoAlumnoOProfe(int idPer, ModoForm modo) : this()
        {
            perActual = perL.GetOne(idPer);
            _modo = modo;
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            txtApellido.Text = perActual.Apellido;
            txtNombre.Text = perActual.Nombre;
            txtDireccion.Text = perActual.Direccion;
            txtEmail.Text = perActual.EMail;
            txtTel.Text = perActual.Telefono;
            dtpFecha.Value = perActual.FechaNac;
            txtLegajo.Text = perActual.Legajo.ToString();
            if (perActual.TipoPersona == 1)
            {
                cboxTipo.Text = "Alumno";
            }
            else
            {
                cboxTipo.Text= "Profesor";
            }
            var plan = pl.GetOne(perActual.IDPlan);
            var esp = el.GetOne(plan.IDEspecialidad);
            cBoxPlan.Text = plan.DescPlan;
            cboxEsp.Text = esp.DescEspecialidad;


            switch (_modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    btnInsc.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnInsc.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnInsc.Text = "Aceptar";
                    break;
                default:
                    break;
            }

        }

        public override void MapearADatos()
        {
         
            if (_modo == ModoForm.Modificacion)
            {
                perActual.State = BusinessEntity.States.Modified;
            }

            perActual.Apellido = txtApellido.Text;
            perActual.Nombre = txtNombre.Text;
            perActual.Legajo = Convert.ToInt32(txtLegajo.Text);
            perActual.Telefono = txtTel.Text;
            perActual.Direccion = txtDireccion.Text;
            perActual.FechaNac = dtpFecha.Value;
            perActual.EMail = txtEmail.Text;
            // Alumno es el indice 0 en el comboBox y profesor el 1, como en la db el tipo 1 corresponde
            // a alumno se le suma uno
            perActual.TipoPersona = cboxTipo.SelectedIndex + 1;
            perActual.IDPlan = pl.GetOne(cBoxPlan.Text, cboxEsp.Text);

        }
        
        public override void GuardarCambios()
        {
            MapearADatos();
            if (_modo == ModoForm.Alta || _modo == ModoForm.Modificacion)
            {
                try
                {
                    perL.Save(perActual);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al guardar el usuario");
                    MessageBox.Show("Codigo de error: #347", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_modo == ModoForm.Baja)
            {
                try
                {
                    perL.Delete(perActual.ID);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al eliminar el usuario, burro!");
                    MessageBox.Show("Codigo de error: #505", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NuevoAlumnoOProfe_Load(object sender, EventArgs e)
        {
            cboxTipo.Items.Add("Alumno");
            cboxTipo.Items.Add("Profesor");
            var especialidades = el.GetAll();
            var descPlanes = pl.GetAllDistinct();
            
            foreach (var esp in especialidades)
            {
                // falta que aparezcan solo una vez los años
                cboxEsp.Items.Add(esp.DescEspecialidad);
            }

            foreach (string desc in descPlanes)
            {
                cBoxPlan.Items.Add(desc);
            }

        }

        private void btnInsc_Click(object sender, EventArgs e)
        {
           
            
            if (!String.IsNullOrEmpty(txtApellido.Text) &&
                !String.IsNullOrEmpty(txtNombre.Text) &&
                !String.IsNullOrEmpty(txtDireccion.Text) &&
                Validaciones.IsValidEmail(txtEmail.Text) &&
                !String.IsNullOrEmpty(txtLegajo.Text) &&
                !String.IsNullOrEmpty(txtTel.Text))
            {
                GuardarCambios();
                MessageBox.Show("Se ha registrado la operacion con exito! ");
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos ingresados incorrectos o nulos! ");
            }
        }
    }
}
