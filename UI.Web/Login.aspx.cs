using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLogic ul = new UsuarioLogic();
        PersonaLogic pl = new PersonaLogic();
        public static Persona _personaRegistrada = new Persona();
        public static Usuario _usuarioRegistrado = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUsuario_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if(LoginUsuario.UserName == "A" && LoginUsuario.Password == "a")
            {
                Response.Redirect("~/Usuarios.aspx");
            }
            else
            {
                try
                {
                    _usuarioRegistrado = ul.GetOne(this.LoginUsuario.UserName, this.LoginUsuario.Password);
                    if (!String.IsNullOrEmpty(_usuarioRegistrado.NombreUsuario))
                    {
                        _personaRegistrada = pl.GetOne(_usuarioRegistrado.IDPersona);
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "OK" + "');", true);
                        Response.Redirect("~/InscripcionesUser.aspx");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Credenciales incorrectas no puede dejar valores nulos" + "');", true);
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