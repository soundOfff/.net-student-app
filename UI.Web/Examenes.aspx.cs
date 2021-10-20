﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
namespace UI.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public enum ModosForm
        {
            Alta,
            Baja,
            Modificacion
        }

        public ModosForm ModoForm
        {
            get { return (ModosForm)this.ViewState["ModoForm"]; }
            set { this.ViewState["ModoForm"] = value; }
        }

        private ExamenesLogic _examenActual;
        private int IDseleccionado
        {
            get
            {
                if (this.ViewState["IDseleccionado"] != null)
                {
                    return (int)this.ViewState["IDseleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["IDseleccionado"] = value;
            }
        }

        private ExamenesLogic Logic
        {
            get
            {
                if (_examenActual == null)
                {
                    _examenActual = new ExamenesLogic();
                }
                return _examenActual;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            dgvExamenes.AutoGenerateColumns = false;
            Listar();

        }

        public void Listar()
        {
            ExamenesLogic exam = new ExamenesLogic();
            dgvExamenes.DataSource = exam.GetAll();
            dgvExamenes.DataBind();

        }

        protected void btonEditar_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Modificacion;
            EnableForm(true);
            ClearForm();
            // _examenActual = ((Examen)this.dgvExamenes.SelectedRow.DataItem);
            Examen exa = Logic.GetOne(this.IDseleccionado);
            loadForm(exa);

        }

        protected void btonNuevo_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Alta;
            EnableForm(true);
            ClearForm();

        }

        protected void btonEliminar_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            this.ModoForm = ModosForm.Baja;
            EnableForm(false);
            ClearForm();
            Examen exa = Logic.GetOne(this.IDseleccionado);
            loadForm(exa);
        }

        protected void dgvExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IdSeleccinado = ((int)this.dgvExamenes.SelectedRow.DataItem);
            this.IDseleccionado = ((int)this.dgvExamenes.SelectedValue);
        }

        protected void btonAceptar_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void loadForm(Examen exa)
        {
            txtIdCurso.Text = exa.IdCurso.ToString();
            txtIdInscripcion.Text = exa.ID.ToString();
            txtLegajoAlumno.Text = exa.Legajo.ToString();
            txtNota.Text = exa.Nota.ToString();

        }
        private void loadEntity(Examen exa)
        {
            exa.IdCurso = Int32.Parse(txtIdCurso.Text);
            exa.Legajo = Int32.Parse(txtLegajoAlumno.Text);
            exa.Nota = Int32.Parse(txtNota.Text);
        }

        private void EnableForm(bool enable)
        {
            txtIdCurso.Enabled = enable;
            txtIdInscripcion.Enabled = false;
            txtLegajoAlumno.Enabled = enable;
            txtNota.Enabled = enable;
        }

        private void Save()
        {
            PersonaLogic per = new PersonaLogic();
            Inscripcion insc = new Inscripcion();
            
            int idPersona = per.GetIdPersona(Int32.Parse(txtLegajoAlumno.Text));

            insc.IdCurso = (Int32.Parse(txtIdCurso.Text));
            insc.Nota = Int32.Parse(txtNota.Text);
            if (Int32.Parse(txtNota.Text) < 6)
            {
                insc.Condicion = "Reprobado";
            }
            else
            {
                insc.Condicion = "Aprobado";
            }

            insc.IdAlumno = idPersona;


            int numModo = (int)this.ModoForm;
            switch (numModo)
            {
                case 0:
                    insc.State = BusinessEntity.States.New;
                    break;
                case 1:
                    insc.State = BusinessEntity.States.Deleted;
                    insc.ID = Int32.Parse(txtIdInscripcion.Text);
                    break;
                case 2:
                    insc.State = BusinessEntity.States.Modified;
                    insc.ID = Int32.Parse(txtIdInscripcion.Text);
                    break;
                default:
                    break;
            }



            ExamenesLogic inscLogic = new ExamenesLogic();


            inscLogic.Save(insc);
            Listar();

        }

        private void ClearForm()
        {
            txtIdCurso.Text = "";
            txtIdInscripcion.Text = "";
            txtLegajoAlumno.Text = "";
            txtNota.Text = "";

        }


    }
}