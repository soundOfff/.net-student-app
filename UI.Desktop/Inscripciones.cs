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
    public partial class Inscripciones : Form
    {
        public Inscripciones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            InscripcionLogic ins = new InscripcionLogic();
            try
            {
                this.dgvInscripciones.DataSource = ins.GetAll();
                
            }
            catch (Exception Ex)
            {
                Exception ExepcionManejada = new Exception("Error al obtener todos las inscripciones");
                MessageBox.Show("Codigo de error: #404", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
