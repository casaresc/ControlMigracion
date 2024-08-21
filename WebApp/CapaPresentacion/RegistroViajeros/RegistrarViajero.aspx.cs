using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.CapaDatos;
using WebApp.CapaLogica;

namespace WebApp.CapaPresentacion.RegistroViajeros
{
    public partial class RegistrarViajero : System.Web.UI.Page
    {
        private ClassViajeroLogica viajerosLogica = new ClassViajeroLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarViajeros();
        }

        private void MostrarViajeros()
        {
            List<Viajero> lista = viajerosLogica.ListarViajeros();
            gvViajeros.DataSource = lista;
            gvViajeros.DataBind();

            gvViajeros.UseAccessibleHeader = true;
            if (gvViajeros.HeaderRow != null)
            {
                gvViajeros.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvViajeros.FooterRow != null)
            {
                gvViajeros.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CapaPresentacion/RegistroViajeros/Crear.aspx?IDViajero=0");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string IDViajero = btn.CommandArgument;
            Response.Redirect($"~/CapaPresentacion/RegistroViajeros/Editar.aspx?IDViajero={IDViajero}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int IDViajero = Convert.ToInt32(btn.CommandArgument);
            bool respuesta = viajerosLogica.EliminarViajero(IDViajero);
            if (respuesta)
            {
                Alertas("El viajero ha sido eliminado con éxito");
                MostrarViajeros();
            }
            else
            {
                Alertas("Error: Para eliminar a este viajero se debe de borrar su registro Entrada/Salida");
            }
        }
    }
}