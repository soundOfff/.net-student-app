using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Business.Entities;
using System.IO;

namespace UI.Desktop
{
    public partial class Main : Form
    {
        //static public Persona _personaRegistrada = new Persona();
        public Usuario _user;
        private Point _posAntImg;
        private Point _posAntNom;
        private Point _posAntTipo;


        //public Persona PersonaRegistrada { get { return _personaRegistrada; } set { _personaRegistrada = value; } }

        public Main()
        {
            InitializeComponent();

        }


        //Se usa para permitir que el mouse arrastre la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wasg, int wparam, int lparam);




        private void AbrirFormInPanel(Form FormHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.RemoveAt(0);
            }
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(FormHijo);
            this.pnlContenedor.Tag = FormHijo;
            FormHijo.Show();
        }



        private void pctrMenu_Click(object sender, EventArgs e)
        {

            if (this.pnlVertical.Width == 200)
            {
                this.pnlVertical.Width = 60;
                this.lblNombrePersona.Location = new Point(
                    this.lblPosNombre.Location.X,
                    this.lblPosNombre.Location.Y
                    );
                this.lblTipoPersona.Location = new Point(
                    this.lblPosTipo.Location.X,
                    this.lblPosTipo.Location.Y
                    );
                this.cirPicImg.Location = new Point(
                    this.lblPosImg.Location.X,
                    this.lblPosImg.Location.Y
                    );
                this.cirPicImg.Height = 45;
                this.cirPicImg.Width = 45;
            }
            else
            {
                this.pnlVertical.Width = 200;
                this.lblTipoPersona.Location = _posAntTipo;
                this.lblNombrePersona.Location = _posAntNom;
                this.cirPicImg.Location = _posAntImg;
                this.cirPicImg.Height = 75;
                this.cirPicImg.Width= 75;
            }

        }

        private void pctrSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctrMaximizar_Click(object sender, EventArgs e)
        {

            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else { this.WindowState = FormWindowState.Maximized; }
        }

        private void pctrMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Usuarios());
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            formLogin fLogin = new formLogin();
            if (fLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            
            if (!(formLogin._usuarioRegistrado.Imagen is null))
            {
                var ms = new MemoryStream(formLogin._usuarioRegistrado.Imagen);
                cirPicImg.Image = Image.FromStream(ms);
            }

            fLogin.Dispose();

            lblNombrePersona.Text = formLogin._personaRegistrada.Nombre;
            switch (formLogin._personaRegistrada.TipoPersona)
            {
                case 1:
                    lblTipoPersona.Text = "Alumno";
                    btnUsuarios.Visible = false;
                    break;
                case 2:
                    lblTipoPersona.Text = "Docente";
                    btnUsuarios.Visible = false;
                    break;
                case 3:
                    lblTipoPersona.Text = "Directivo";
                    btnUsuarios.Visible = true;

                    break;
                default:
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
           
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new Examenes(formLogin._personaRegistrada));
            AbrirFormInPanel(new Cursos());
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new TestDiseñoInscripcionUser());
        }

        private void btnReportePlanes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ReportePlanes());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _posAntImg = this.cirPicImg.Location;
            _posAntNom = this.lblNombrePersona.Location;
            _posAntTipo = this.lblTipoPersona.Location;
        }

    }
}
