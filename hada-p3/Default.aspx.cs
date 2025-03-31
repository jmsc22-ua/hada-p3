using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hada_p3
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void create_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                lblError.Text = "El código debe tener entre 1 y 16 caracteres.";
                return;
            }

            if (string.IsNullOrWhiteSpace(name.Text) || name.Text.Length > 32)
            {
                lblError.Text = "El nombre no puede estar vacío ni superar los 32 caracteres.";
                return;
            }



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}