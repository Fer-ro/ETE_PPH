using AccesoNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ETE_PPH
{
    public partial class MasterSite : System.Web.UI.MasterPage
    {
        public string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AN_Login login = new AN_Login();
                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                BTN_Logout.Text = user.Username + " - " + "Cerrar sesion";
                //Menu ETE TEST
                ETE.Visible = false;
                //Menu Gestion usuarios TEST
                Usuarios.Visible = false;
                //Visualizamos Paginas a los que tenga permiso el usuario
                List<string[]> CatalogoPermisos_Paginas = login.Direcciones_De_Paginas(user.ID_Usuario);
                //Ordenamos las paginas en el menu
                var ListaOrdenada =  CatalogoPermisos_Paginas;
                List<string[]> Catalogo_Paginas = new List<string[]>();
                foreach (string [] a in ListaOrdenada)
                {
                    Catalogo_Paginas.Add(a);
                }
                Visualizar_PaginasConPermiso(Catalogo_Paginas);
            }
           
        }

        

        protected void BTN_Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("sesion_usuario");
            Response.Redirect("~/Login.aspx");
        }

      
        private void Visualizar_PaginasConPermiso(List<string [] >  PaginasPermitidas)
        {
            foreach (string [] a in PaginasPermitidas)
            {
                if (a[0] != "")
                {
                    // this line is fine
                    string url = ResolveClientUrl(a[0]);
                    // this line is quite ugly, but should work
                    var lit = new Literal { Text = "<a href='" + url + "'  class='" + "list-group-item list-group-item-action text-dark border-right "+a[3]+" border-bottom-0 bg-light" + "'  >"+" " +a[1]+"</a>" };
                    // add it the page/control's control hierarchy
                    Lista_Menu.Controls.Add(lit);
                }                               
            }
            this.Page.DataBind();
        }
    }
}   