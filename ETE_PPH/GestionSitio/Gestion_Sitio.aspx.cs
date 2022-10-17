using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using AccesoNegocio;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionSitio
{
    public partial class Gestion_Sitio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AN_GestionSitio gestionSitio = new AN_GestionSitio();
                GV_Paginas.DataSource = gestionSitio.Paginas();
                GV_Paginas.DataBind();
            }
        }

        protected void BTN_GuardarPagina_Click(object sender, EventArgs e)
        {
            AN_GestionSitio gestionSitio = new AN_GestionSitio();
            gestionSitio.Guardar_Nueva_Pagina(TXT_NombrePagina.Text, 1,TXT_Direccion.Text,TXT_NombrePagina.Text, 8);
        }
    }
}