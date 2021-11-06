using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class MenuAutogestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                lblUsuario.InnerText = "Nombre de Usuario: " + Login._usuarioRegistrado.NombreUsuario + ".";

                //string strBase64 = Convert.ToBase64String(Login._usuarioRegistrado.Imagen);

                //userImage.ImageUrl = "data:Image/png;base64," + strBase64;

               if ( (string)Session["rol"] == "1" )
                {
                    lblTipo.InnerText = "Tipo de Usuario: Alumno.";
                }
                else
                {
                    lblTipo.InnerText = "Tipo de Usuario: Profesor.";
                }
               
            }
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Session["rol"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}