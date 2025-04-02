using library;
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

            if (!float.TryParse(price.Text, out float precio) || precio < 0 || precio > 9999.99)
            {
                lblError.Text = "La cantidad debe ser un número entero positivo.";
                return;
            }

            if (!DateTime.TryParse(creationDate.Text, out DateTime fecha))
            {
                lblError.Text = "La fecha no es válida. Usa el formato correcto (dd/mm/aaaa).";
                return;
            }

            lblError.Text = "El valor es: " + fecha;

            int categoriaId;
            if (!int.TryParse(category.SelectedValue?.ToString(), out categoriaId))
            {
                lblError.Text = "Debe seleccionar una categoría válida.";
                return;
            }

            ENProduct producto = new ENProduct(code.Text, name.Text, cantidad, precio, categoriaId, fecha);

            if (producto.Create())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto creado correctamente.";
            }
            else
            {
                lblError.Text = "Error al crear el producto.";
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
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

            ENProduct producto = new ENProduct(code.Text, name.Text, cantidad, precio, int.Parse(category.SelectedValue), fecha);

            if (producto.Update())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto actualizado correctamente.";
            }
            else
            {
                lblError.Text = "Error al actualizar el producto.";
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2020,1,1);
            ENProduct producto = new ENProduct(code.Text, name.Text,0, 0, int.Parse(category.SelectedValue), fecha);

            if (producto.Delete())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto borrado correctamente.";
            }
            else
            {
                lblError.Text = "Error al borrar el producto.";
            }
        }

        protected void read_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            ENProduct producto = new ENProduct(code.Text, name.Text, 0, 0, int.Parse(category.SelectedValue), fecha);

            if (producto.Read())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto borrado correctamente.";
            }
            else
            {
                lblError.Text = "Error al borrar el producto.";
            }
        }

        protected void readFirst_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            ENProduct producto = new ENProduct(code.Text, name.Text, 0, 0, int.Parse(category.SelectedValue), fecha);

            if (producto.Read())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto borrado correctamente.";
            }
            else
            {
                lblError.Text = "Error al borrar el producto.";
            }
        }

        protected void readPrev_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            ENProduct producto = new ENProduct(code.Text, name.Text, 0, 0, int.Parse(category.SelectedValue), fecha);

            if (producto.Read())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto borrado correctamente.";
            }
            else
            {
                lblError.Text = "Error al borrar el producto.";
            }
        }

        protected void readNext_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            ENProduct producto = new ENProduct(code.Text, name.Text, 0, 0, int.Parse(category.SelectedValue), fecha);

            if (producto.Read())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto borrado correctamente.";
            }
            else
            {
                lblError.Text = "Error al borrar el producto.";
            }
        }
    }
}