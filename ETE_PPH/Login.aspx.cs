using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocio;

namespace ETE_PPH
{
    public partial class Login : System.Web.UI.Page
    {
        int TiempoBloqueo_segundos = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                Session["login_bloqueado"] = false;                
                Session["intentos_logueo"] = 0;           
                Session["milisegundos_espera"] = 0;
                Session["maximo_intentos_logueo"] = 7;
            }           
        }

        protected void BTN_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)Session["login_bloqueado"])
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingreso bloqueado, intente en " + (TiempoBloqueo_segundos - (int)Session["milisegundos_espera"]) + " segundos.')", true);
                }
                else
                {
                    AccesoNegocio.AN_Login login = new AN_Login();
                    if (login.ValidarLogin(loginNomina_.Text, TXT_Pass.Text))
                    {
                        Session["milisegundos_espera"] = 0;
                        Session["login_bloqueado"] = false;
                        Session["intentos_logueo"] = 0;
                        AccesoNegocio.OBJ_Usuario user = new OBJ_Usuario();
                        user.Username = login.GetUsuario(loginNomina_.Text);
                        user.ID_Usuario = login.ID_De_Usuario(loginNomina_.Text);
                        user.Rango =Convert.ToInt32(login.Rango_De_Usuario(user.ID_Usuario.ToString()));
                        user.Departamento = login.Departamento_Usuario(user.ID_Usuario);
                        user.Puesto = Convert.ToInt32(login.Puesto_Usuario(user.ID_Usuario));
                        user.Nomina = login.Get_NominaUSer(user.ID_Usuario);

                        Session["sesion_usuario"] = user;
                        if (user.Rango == 3)
                        {
                            Response.Redirect("~/GestionUsuarios/GestionUsuarios.aspx");
                        }
                        if (user.Puesto == 1)
                        {
                            Response.Redirect("~/GestionTickets/NuevoRequerimiento.aspx");
                        }
                        if (user.Puesto == 2 || user.Puesto == 3)
                        {
                            Response.Redirect("~/GestionTickets/VistaUsuarioTickets.aspx");
                        }
                    }
                    else
                    {
                        Session["intentos_logueo"] = (int)Session["intentos_logueo"] + 1;
                        if ((int)Session["intentos_logueo"] >= (int)Session["maximo_intentos_logueo"])
                        {  //Si supera el maximo intentos de logueo, el sistema lo bloqueara
                            Session["login_bloqueado"] = true;
                        }
                        if ((bool)Session["login_bloqueado"])
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingreso bloqueado, intente en " + (TiempoBloqueo_segundos - (int)Session["milisegundos_espera"]) + " segundos.')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Debe de ingresar un usuario y una contraseña validos, le quedan " + ((int)Session["maximo_intentos_logueo"] - (int)Session["intentos_logueo"]) + " intentos')", true);
                        }
                    }

                }
            }
            catch {
            
            }
                           
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {         
            if ((bool)Session["login_bloqueado"])
            {
                Session["milisegundos_espera"] = (int)Session["milisegundos_espera"] + 1;
                if ((int)Session["milisegundos_espera"] >= TiempoBloqueo_segundos)
                {
                    Session["milisegundos_espera"] = 0;
                    Session["login_bloqueado"] = false;
                    Session["intentos_logueo"] = 0;
                }
            }
                            
        }
    }
}