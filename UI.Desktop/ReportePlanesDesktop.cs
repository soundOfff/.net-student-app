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
    public partial class ReportePlanesDesktop : Form
    {
        public PlanLogic pl = new PlanLogic();
        public ReportePlanesDesktop()
        {
            InitializeComponent();
            cbPlanes.DataSource = pl.GetAll();
            cbPlanes.DisplayMember = "Informacion";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ReportePlanes.plan = (Business.Entities.Plan)cbPlanes.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
