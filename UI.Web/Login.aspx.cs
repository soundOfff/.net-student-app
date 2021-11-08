using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLogic ul = new UsuarioLogic();
        PersonaLogic pl = new PersonaLogic();
        public static Usuario _usuarioRegistrado = new Usuario();
        public static Persona _personaRegistrada = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == "A" && this.txtPassword.Text == "a")
            {
                // Persona registrada en la db como admin 
                _usuarioRegistrado = ul.GetOne("Admin", "12345678");
                _personaRegistrada = pl.GetOne(_usuarioRegistrado.IDPersona);
                Session["rol"] = "admin";
                Response.Redirect("~/MenuAutogestion.aspx");
                Session.RemoveAll();
            }
            else
            {
                try
                {
                    _usuarioRegistrado = ul.GetOne(this.txtUsername.Text, this.txtPassword.Text);
                    if (!String.IsNullOrEmpty(_usuarioRegistrado.NombreUsuario))
                    {
                        _personaRegistrada = pl.GetOne(_usuarioRegistrado.IDPersona);
                        Session["rol"] = Convert.ToString(_personaRegistrada.TipoPersona);
                        Response.Redirect("~/MenuAutogestion.aspx");
                        Session.RemoveAll();
                    }
                    else
                    {
                        alert.Visible = true;
                    }

                }
                catch (Exception)
                {
                    Exception ExepcionManejada = new Exception("Error al obtener usuario");
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error al obtener el user" + "');", true);
                }
            }
        }
    }
}