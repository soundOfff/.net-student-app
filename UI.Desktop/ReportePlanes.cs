using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReportePlanes : Form
    {
        public static Plan plan;

        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            MateriasLogic ml = new MateriasLogic();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";
            ReportePlanesDesktop reportePlanesDesktop = new ReportePlanesDesktop();
            reportePlanesDesktop.ShowDialog();
           
            
            if(reportePlanesDesktop.DialogResult != DialogResult.Cancel)
            {
                try
                {
                    ReportDataSource rds1 = new ReportDataSource("Materias", ml.GetAll(plan.ID));
                    this.reportViewer1.LocalReport.DataSources.Add(rds1);
                }
                catch (Exception Ex)
                {
                    Exception ExepcionManejada = new Exception("Error al obtener todos las materias para inscripcion");
                    MessageBox.Show("Codigo de error: #404", ExepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.reportViewer1.RefreshReport();
            }
            

          
            
        }
    }
}
