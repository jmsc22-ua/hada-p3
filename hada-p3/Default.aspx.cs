using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace hada_p3
{
	public partial class Default : System.Web.UI.Page
	{
        ENProduct productoActual;
        protected void Page_Load(object sender, EventArgs e)
		{
            amount.Attributes.Add("type", "number");
            amount.Attributes.Add("min", "0");

            creationDate.Attributes.Add("type", "date");
        }

        protected void create_Click(object sender, EventArgs e)
        {
            panelProducto.Visible = false;
            lblError.ForeColor = System.Drawing.Color.Red;
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
                lblError.Text = "El precio debe estar entre 0 y 9999.99";
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
            panelProducto.Visible = false;
            lblError.ForeColor = System.Drawing.Color.Red;
            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                lblError.Text = "El código es incorrecto.";
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
            lblError.ForeColor = System.Drawing.Color.Red;
            panelProducto.Visible = false;

            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                lblError.Text = "El código es incorrecto.";
                return;
            }

            ENProduct producto = new ENProduct { Code = code.Text };
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
            lblError.ForeColor = System.Drawing.Color.Red;
            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                lblError.Text = "El código es incorrecto.";
                return;
            }

            ENProduct producto = new ENProduct { Code = code.Text };

            if (producto.Read())
            {
                panelProducto.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                lblCode.Text = "Código: " + producto.Code;
                lblName.Text = "Nombre: " + producto.Name;
                lblAmount.Text = "Cantidad: " + producto.Amount.ToString();
                lblPrice.Text = "Precio: " + producto.Price.ToString("0.00") + " €";
                lblCategory.Text = "Categoría: " + producto.Category.ToString();
                lblDate.Text = "Fecha: " + producto.CreationDate.ToShortDateString();
                Session["productoActual"] = producto;
            }
            else
            {
                lblError.Text = "Error al leer el producto.";
            }
        }

        protected void readFirst_Click(object sender, EventArgs e)
        {
            ENProduct producto = new ENProduct();

            if (producto.ReadFirst())
            {
                panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                lblCode.Text = "Código: " + producto.Code;
                lblName.Text = "Nombre: " + producto.Name;
                lblAmount.Text = "Cantidad: " + producto.Amount.ToString();
                lblPrice.Text = "Precio: " + producto.Price.ToString("0.00") + " €";
                lblCategory.Text = "Categoría: " + producto.Category.ToString();
                lblDate.Text = "Fecha: " + producto.CreationDate.ToShortDateString();
                Session["productoActual"] = producto;
            }
            else
            {
                lblError.Text = "Error al leer el producto.";
            }
        }

        protected void readPrev_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Red;

            ENProduct producto = Session["productoActual"] as ENProduct;

            if (producto == null)
            {
                lblError.Text = "No hay producto cargado. Usa primero 'ReadFirst'";
                return;
            }

            if (producto.ReadPrev())
            {
                Session["productoActual"] = producto;

                panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leído correctamente.";
                lblCode.Text = "Código: " + productoActual.Code;
                lblName.Text = "Nombre: " + productoActual.Name;
                lblAmount.Text = "Cantidad: " + productoActual.Amount.ToString();
                lblPrice.Text = "Precio: " + productoActual.Price.ToString("0.00") + " €";
                lblCategory.Text = "Categoría: " + productoActual.Category.ToString();
                lblDate.Text = "Fecha: " + productoActual.CreationDate.ToShortDateString();
            }
            else
            {
                lblError.Text = "Error al leer el siguiente producto.";
            }
        }

        protected void readNext_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Red;

            ENProduct productoActual = Session["productoActual"] as ENProduct;

            if (productoActual == null)
            {
                lblError.Text = "No hay producto cargado. Usa primero 'Leer primero'.";
                return;
            }

            if (productoActual.ReadNext())
            {
                Session["productoActual"] = productoActual;

                panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leído correctamente.";
                lblCode.Text = "Código: " + productoActual.Code;
                lblName.Text = "Nombre: " + productoActual.Name;
                lblAmount.Text = "Cantidad: " + productoActual.Amount.ToString();
                lblPrice.Text = "Precio: " + productoActual.Price.ToString("0.00") + " €";
                lblCategory.Text = "Categoría: " + productoActual.Category.ToString();
                lblDate.Text = "Fecha: " + productoActual.CreationDate.ToShortDateString();
            }
            else
            {
                lblError.Text = "Error al leer el siguiente producto.";
            }
        }
    }
}