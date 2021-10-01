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
                
            }
        }
    }
}