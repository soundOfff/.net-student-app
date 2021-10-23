using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuariosDesktop : ApplicationForm
    {
        private Business.Entities.Usuario _usuarioActual;
        private byte[] imgTemp;

        public Business.Entities.Usuario UsuarioActual { get { return _usuarioActual; } set { _usuarioActual = value; } }


        public UsuariosDesktop(ModoForm modo) : this()
        {
            txtApellido.Text = FormLegajo._personaAinscribirse.Apellido;
            txtNombre.Text = FormLegajo._personaAinscribirse.Nombre;
            _modo = modo;
        }

        public UsuariosDesktop(int ID, ModoForm modo) : this()
        {
            this.txtApellido.Enabled = true;
            this.txtNombre.Enabled = true;
            UsuarioLogic ul = new UsuarioLogic();
            _usuarioActual = ul.GetOne(ID);
            _modo = modo;
            MapearDeDatos();
            var ms = new MemoryStream(_usuarioActual.Imagen);
            pictureBox1.Image = Image.FromStream(ms);
        }

        public UsuariosDesktop()
        {
            InitializeComponent();
        }
        public override  void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

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
                _usuarioActual = new Business.Entities.Usuario();
                _usuarioActual.State = BusinessEntity.States.New;
                UsuarioActual.IDPersona = FormLegajo._personaAinscribirse.ID;

            }
            else if (_modo == ModoForm.Modificacion)
            {
                _usuarioActual.State = BusinessEntity.States.Modified;
               
            }

            UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            
            UsuarioActual.Nombre = this.txtNombre.Text;

            UsuarioActual.Apellido = this.txtApellido.Text;

            UsuarioActual.NombreUsuario = this.txtUsuario.Text;

            UsuarioActual.EMail = this.txtEmail.Text;

            UsuarioActual.Clave = this.txtClave.Text;

            UsuarioActual.Clave = this.txtConfirmarClave.Text;

            // Si tiene img que no la cambie
            UsuarioActual.Imagen = imgTemp;
            
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic _usuarioLogic = new UsuarioLogic();
            if (_modo == ModoForm.Alta || _modo == ModoForm.Modificacion)
            {
                try
                { 
                    _usuarioLogic.Save(_usuarioActual);
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
                    _usuarioLogic.Delete(_usuarioActual.ID);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al eliminar el usuario, burro!");
                    MessageBox.Show("Codigo de error: #505", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar()
        {
            // Mail, contraseñas coincidencia / 8 caracteres, nada vacio 
            
            //String.IsNullOrEmpty(this.txtNombre.Text.Trim()) Cambiar
            
            if ( String.IsNullOrEmpty(this.txtNombre.Text.Trim()) || String.IsNullOrEmpty(this.txtApellido.Text.Trim()) || String.IsNullOrEmpty(this.txtEmail.Text.Trim()) 
                || String.IsNullOrEmpty(this.txtUsuario.Text.Trim()) || String.IsNullOrEmpty(this.txtClave.Text.Trim()) || String.IsNullOrEmpty(this.txtConfirmarClave.Text))
            {
                Notificar("Error numero: #777", "Hay casillas que estan vacias, por favor complete todos los datos!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
            else
            {
                if (this.txtClave.Text.Trim().Length < 8)
                {
                    Notificar("Error numero: #000", "La contrasenia debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (this.txtClave.Text.Trim() != this.txtConfirmarClave.Text.Trim())
                {
                    Notificar("Error numero: #111", "Las contrasenias son diferentes, por favor vuelva a ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return false;
                }
                if (!Validaciones.IsValidEmail(txtEmail.Text.Trim()))
                {
                    Notificar("Error numero: #333", "Mail invalido, por favor reviselo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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

        private void btnInputImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = "C:\\";
            getImage.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
            if (getImage.ShowDialog() == DialogResult.OK)
            {
                // Para leer la img y convertirla a un array de bytes
                imgTemp = File.ReadAllBytes(getImage.FileName);
                var ms = new MemoryStream(imgTemp);
                pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                MessageBox.Show("No se selecciono una imagen");
            }
            
        }
    }
}
