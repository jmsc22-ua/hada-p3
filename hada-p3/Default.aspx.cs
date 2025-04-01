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

            if (!int.TryParse(amount.Text, out int cantidad) || cantidad < 0 || cantidad > 9999)
            {
                lblError.Text = "La cantidad debe ser un número entero positivo.";
                return;
            }

            if (!float.TryParse(amount.Text, out float precio) || precio < 0 || precio > 9999.99)
            {
                lblError.Text = "La cantidad debe ser un número entero positivo.";
                return;
            }

            if (!DateTime.TryParse(creationDate.Text, out DateTime fecha))
            {
                lblError.Text = "La fecha no es válida. Usa el formato correcto (dd/mm/aaaa).";
                return;
            }

            int cat;
            switch (category.SelectedValue)
            {
                case "Computing": 
                    cat = 0;
                    break;
                case "Telephony":
                    cat = 1;
                    break;
                case "Gaming":
                    cat = 2;
                    break;
                case "Home appliances":
                    cat = 3;
                    break;
            }

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Producto creado correctamente.";

        }

        protected void update_Click(object sender, EventArgs e)
        {
            
        }
    }
}