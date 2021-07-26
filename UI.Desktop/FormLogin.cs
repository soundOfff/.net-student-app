using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        UsuarioLogic ul = new UsuarioLogic();
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                try
                {
                    Usuario usr = ul.GetOne(txtUsuario.Text, txtPass.Text);
                    if (!String.IsNullOrEmpty(usr.NombreUsuario) )
                    { 
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Codigo de error: #sosUnburro", "Contrasenia/Usuario incorrectos, revise!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    Exception ExepcionManejada = new Exception("Error al obtener usuario");
                    MessageBox.Show("Codigo de error: #505", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
