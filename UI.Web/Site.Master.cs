using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
	public partial class Site : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Usuarios.aspx");
        }

        protected void btonExamenes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Examenes.aspx");
        }

        protected void btonUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }
    }
}