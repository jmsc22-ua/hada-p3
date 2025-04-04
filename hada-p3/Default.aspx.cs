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
        protected void Page_Load(object sender, EventArgs e)
		{
            amount.Attributes.Add("type", "number");
            amount.Attributes.Add("min", "0");

            creationDate.Attributes.Add("type", "datetime-local");

            if (!IsPostBack)
            {
                ENCategory cad = new ENCategory();
                List<ENCategory> categorias = cad.ReadAll();

                category.DataSource = categorias;
                category.DataTextField = "Name";
                category.DataValueField = "Id";
                category.DataBind();

                category.Items.Insert(0, new ListItem("Selecciona una categoría", "-1"));
            }

        }

        protected void create_Click(object sender, EventArgs e)
        {
            bool error = false; 
            //panelProducto.Visible = false;
            errorCode.Visible = false;
            errorName.Visible = false;
            errorAmount.Visible = false;
            errorCategory.Visible = false;
            errorPrice.Visible = false;
            errorDate.Visible = false;

            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                errorCode.ForeColor = System.Drawing.Color.Red;
                errorCode.Text = "*El código debe tener entre 1 y 16 caracteres."; 
                errorCode.Visible = true;
                error = true;
            }

            if (string.IsNullOrWhiteSpace(name.Text) || name.Text.Length > 32)
            {
                errorName.ForeColor = System.Drawing.Color.Red;
                errorName.Text = "*El nombre no puede estar vacío ni superar los 32 caracteres.";
                errorName.Visible = true;
                error = true;
            }

            if (!int.TryParse(amount.Text, out int cantidad) || cantidad < 0 || cantidad > 9999)
            {
                errorAmount.ForeColor = System.Drawing.Color.Red;
                errorAmount.Text = "*La cantidad debe ser un número entero positivo.";
                errorAmount.Visible = true;
                error = true;
            }
            

            if (!float.TryParse(price.Text, out float precio) || precio < 0 || precio > 9999.99)
            {
                errorPrice.ForeColor = System.Drawing.Color.Red;
                errorPrice.Text = "*El precio debe estar entre 0 y 9999,99.";
                errorPrice.Visible = true;
                error = true;
            }

            if (!DateTime.TryParse(creationDate.Text, out DateTime fecha))
            {
                errorDate.ForeColor = System.Drawing.Color.Red;
                errorDate.Text = "*La fecha no es válida. Usa el formato correcto (dd/mm/aaaa).";
                errorDate.Visible = true;
                error = true;
            }

            int categoriaId;
            if (!int.TryParse(category.SelectedValue?.ToString(), out categoriaId) || categoriaId == -1)
            {
                errorCategory.ForeColor = System.Drawing.Color.Red;
                errorCategory.Text = "*Debe seleccionar una categoría válida.";
                errorCategory.Visible = true;
                error = true;
            }

            if (error)
            {
                return;
            }

            ENProduct producto = new ENProduct(code.Text, name.Text, cantidad, precio, categoriaId, fecha);

            try
            {
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
            catch(Exception ex)
            {
                lblError.Text = "Error al crear el producto: " + ex.Message;
            }
            
        }

        protected void update_Click(object sender, EventArgs e)
        {
            bool error = false;
            //panelProducto.Visible = false;
            errorCode.Visible = false;
            errorName.Visible = false;
            errorAmount.Visible = false;
            errorCategory.Visible = false;
            errorPrice.Visible = false;
            errorDate.Visible = false;

            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(code.Text) || code.Text.Length > 16)
            {
                errorCode.ForeColor = System.Drawing.Color.Red;
                errorCode.Text = "*El código debe tener entre 1 y 16 caracteres.";
                errorCode.Visible = true;
                error = true;
            }

            if (string.IsNullOrWhiteSpace(name.Text) || name.Text.Length > 32)
            {
                errorName.ForeColor = System.Drawing.Color.Red;
                errorName.Text = "*El nombre no puede estar vacío ni superar los 32 caracteres.";
                errorName.Visible = true;
                error = true;
            }

            if (!int.TryParse(amount.Text, out int cantidad) || cantidad < 0 || cantidad > 9999)
            {
                errorAmount.ForeColor = System.Drawing.Color.Red;
                errorAmount.Text = "*La cantidad debe ser un número entero positivo.";
                errorAmount.Visible = true;
                error = true;
            }


            if (!float.TryParse(price.Text, out float precio) || precio < 0 || precio > 9999.99)
            {
                errorPrice.ForeColor = System.Drawing.Color.Red;
                errorPrice.Text = "*El precio debe estar entre 0 y 9999,99.";
                errorPrice.Visible = true;
                error = true;
            }

            if (!DateTime.TryParse(creationDate.Text, out DateTime fecha))
            {
                errorDate.ForeColor = System.Drawing.Color.Red;
                errorDate.Text = "*La fecha no es válida. Usa el formato correcto (dd/mm/aaaa).";
                errorDate.Visible = true;
                error = true;
            }

            int categoriaId;
            if (!int.TryParse(category.SelectedValue?.ToString(), out categoriaId) || categoriaId == -1)
            {
                errorCategory.ForeColor = System.Drawing.Color.Red;
                errorCategory.Text = "*Debe seleccionar una categoría válida.";
                errorCategory.Visible = true;
                error = true;
            }

            if (error)
            {
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
            //panelProducto.Visible = false;

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
                //panelProducto.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                code.Text = producto.Code;
                name.Text = producto.Name;
                amount.Text = producto.Amount.ToString();
                price.Text = producto.Price.ToString("0.00");
                category.SelectedValue = (producto.Category).ToString();
                creationDate.Text = producto.CreationDate.ToString("yyyy-MM-ddTHH:mm");
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
                //panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                code.Text = producto.Code;
                name.Text = producto.Name;
                amount.Text = producto.Amount.ToString();
                price.Text = producto.Price.ToString("0.00");
                category.SelectedValue = (producto.Category).ToString();
                creationDate.Text = producto.CreationDate.ToString("yyyy-MM-ddTHH:mm");
            }
            else
            {
                lblError.Text = "Error al leer el producto.";
            }
        }

        protected void readPrev_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Red;

            ENProduct producto = new ENProduct { Code = code.Text };

            if (producto == null)
            {
                lblError.Text = "No hay producto cargado. Usa primero 'ReadFirst'";
                return;
            }

            if (producto.ReadPrev())
            {

                //panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                code.Text = producto.Code;
                name.Text = producto.Name;
                amount.Text = producto.Amount.ToString();
                price.Text = producto.Price.ToString("0.00");
                category.SelectedValue = (producto.Category).ToString();
                creationDate.Text = producto.CreationDate.ToString("yyyy-MM-ddTHH:mm");
            }
            else
            {
                lblError.Text = "Error al leer el producto anterior.";
            }
        }

        protected void readNext_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Red;

            ENProduct producto = new ENProduct { Code = code.Text };

            if (producto == null)
            {
                lblError.Text = "No hay producto cargado. Usa primero 'ReadFirst' o 'Read'";
                return;
            }

            if (producto.ReadNext())
            {

                //panelProducto.Visible = true;

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto leido correctamente.";
                code.Text = producto.Code;
                name.Text = producto.Name;
                amount.Text = producto.Amount.ToString();
                price.Text = producto.Price.ToString("0.00");
                category.SelectedValue = (producto.Category).ToString();
                creationDate.Text = producto.CreationDate.ToString("yyyy-MM-ddTHH:mm");
            }
            else
            {
                lblError.Text = "Error al leer el siguiente producto.";
            }
        }
    }
}