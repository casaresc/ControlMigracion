using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.CapaDatos;
using WebApp.CapaLogica;

namespace WebApp.CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClassLoginLogica login = new ClassLoginLogica();
            Usuario usuario = login.ValidarLogin(txtEmail.Text, txtPasword.Text);
            if (usuario != null)
            {
                Session["IDUsuario"] = usuario.IDUsuario;
                Session["CorreoElectronico"] = usuario.CorreoElectronico;
                Session["Rol"] = usuario.Rol;
                Response.Redirect("~/CapaPresentacion/Inicio.aspx");
            }
            else
            {
                alertLabel.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                alertLabel.Visible = true;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
    }
}