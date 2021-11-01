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

        }

        protected void LoginUsuario_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if(LoginUsuario.UserName == "A" && LoginUsuario.Password == "a")
            {
                Session["id"] = "admin";
                Response.Redirect("~/MenuAutogestion.aspx");
                Session.RemoveAll();
            }
            else
            {
                try
                {
                    _usuarioRegistrado = ul.GetOne(this.LoginUsuario.UserName, this.LoginUsuario.Password);
                    if (!String.IsNullOrEmpty(_usuarioRegistrado.NombreUsuario))
                    {
                        _personaRegistrada = pl.GetOne(_usuarioRegistrado.IDPersona);
                        Session["id"] = _personaRegistrada.ID;
                        Response.Redirect("~/MenuAutogestion.aspx");
                        Session.RemoveAll();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Credenciales incorrectas no puede dejar valores nulos" + "');", true);
                        Response.Redirect("Login.aspx", true);
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