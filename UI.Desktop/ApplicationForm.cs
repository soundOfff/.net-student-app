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
    public partial class ApplicationForm : Form
    {
        public ModoForm _modo;
        public ModoForm Modo { get { return _modo; } set { _modo = value; } }
        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        public virtual void MapearDeDatos()
        {

        }
        public virtual void MapearADatos()
        {

        }
        public virtual void GuardarCambios()
        {

        }

        public virtual bool Validar()
        {
            return false;
        }

        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(titulo, mensaje, botones, icono);
        }

        public virtual void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(this.Text, mensaje, botones, icono);
        }

        public ApplicationForm()
        {
            InitializeComponent();
        }






    }
}
