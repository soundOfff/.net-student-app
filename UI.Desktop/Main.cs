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

namespace UI.Desktop
{
    public partial class Main : Form
    {
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
            if(this.pnlContenedor.Controls.Count > 0)
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
            if(this.pnlVertical.Width == 200)
            {
                this.pnlVertical.Width = 55;
            }
            else
            {
                this.pnlVertical.Width = 200;
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

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Examenes());
        }
    }
}
