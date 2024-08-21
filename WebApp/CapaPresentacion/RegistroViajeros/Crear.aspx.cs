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
    public partial class Crear : System.Web.UI.Page
    {
        private static int IDViajero = 0;
        ClassViajeroLogica viajerosLogica = new ClassViajeroLogica();
        ClassPaisesLogica pais = new ClassPaisesLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarNacionalidades();
            }
        }

        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }

        protected void CargarNacionalidades()
        {
            List<Pais> lista = pais.ListarPaises();
            ddlNacionalidad.DataTextField = "NombrePais";
            ddlNacionalidad.DataValueField = "IDPais";
            ddlNacionalidad.DataSource = lista;
            ddlNacionalidad.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNroPasaporte.Text) ||
                string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
                string.IsNullOrWhiteSpace(ddlNacionalidad.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                Viajero viajero = new Viajero()
                {
                    IDViajero = IDViajero,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    NroPasaporte = txtNroPasaporte.Text,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    Nacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue)
                };

                if (IDViajero == 0)
                {
                    int resultado = viajerosLogica.InsertarViajero(viajero);
                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/CapaPresentacion/RegistroViajeros/RegistrarViajero.aspx");
                        string script = $"alert('Viajero ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar viajero");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Alertas("Ocurrió un error al procesar la solicitud: " + ex.Message);
            }
        }
    }
}