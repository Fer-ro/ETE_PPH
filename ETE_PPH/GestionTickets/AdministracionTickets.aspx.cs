using AccesoNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionTickets
{
    public partial class AdministracionTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            AN_Login login = new AN_Login();
            CrearTicket();
           
        }
        void CrearTicket()
        {
            AN_GestionUsuarios gestionUsuarios = new AN_GestionUsuarios();
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            AN_Login login = new AN_Login();
            List<int> Permisos =  gestionUsuarios.Permisos_De_Usuario(user.ID_Usuario);
            if (IsPermisoUsuario(Permisos))
            {

            }
        }
        bool IsPermisoUsuario(List<int>listaPermisos)
        {
            foreach (int a in listaPermisos)
            {
                if (a == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}