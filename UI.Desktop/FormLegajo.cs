using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormLegajo : Form
    {
        public static Business.Entities.Persona _personaAinscribirse;
        public FormLegajo()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLegajo.Text, "[^0-9]"))
            {
                _personaAinscribirse = pl.GetOneLegajo(Convert.ToInt32(txtLegajo.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe ingresar numeros!");
            }
        }
    }
}
