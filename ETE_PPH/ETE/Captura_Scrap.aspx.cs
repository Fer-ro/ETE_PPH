using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocio;

namespace ETE_PPH.ETE
{
    public partial class Captura_Scrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                AN_Login login = new AN_Login();
                if (!login.ValidarPermiso_Pagina(4, user.ID_Usuario))
                {
                    Response.Redirect("~/Error404.aspx");
                }
                AN_ETE ete = new AN_ETE();
                SetearDropDownList(DDL_CatalogoScrap, ete.CatalogoCausasScrap(), "Codigo", "ID_Catalogo_Scrap");
                SetearDropDownList(DDL_Linea, ete.CatalogoLineas(), "Nombre", "ID_Linea");
                SetearDropDownList(DDL_Lado, ete.CatalogoLado(), "Lado", "ID_Lado");
                HttpContext.Current.Session["Fecha_Scrap"] = DateTime.Now.ToString("yyyy-MM-dd");
                HttpContext.Current.Session["HoraI_Scrap"] = "00:00:00";
                TXT_Scrap.Text = "0";
            }
        }
        void SetearDropDownList(DropDownList downList, DataTable sourceDT, string ColumnaTexto, string ColumnaValor)
        {
            downList.DataSource = sourceDT;
            downList.DataTextField = ColumnaTexto;
            downList.DataValueField = ColumnaValor;
            downList.DataBind();
        }
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_Fecha(string fecha)
        {
            string Fecha = Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
            HttpContext.Current.Session["Fecha_Scrap"] = Fecha;
            return "";
        }
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_HoraI(string HoraI)
        {
            string Hora = Convert.ToDateTime(HoraI).ToString("HH:mm:ss");
            HttpContext.Current.Session["HoraI_Scrap"] = Hora;
            return "";
        }

        protected void DDL_Linea_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void BTN_GuardarRegistroScrap_Click(object sender, EventArgs e)
        {
            string FechaOcurrencia = HttpContext.Current.Session["Fecha_Scrap"] + " " + HttpContext.Current.Session["HoraI_Scrap"];
            AN_ETE ete = new AN_ETE();
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            ete.Guardar_Nuevo_RegistroScrap(user.ID_Usuario, Convert.ToInt32(DDL_CatalogoScrap.SelectedValue), Convert.ToInt32(TXT_Scrap.Text), FechaOcurrencia, TXT_Comentarios.Text, DDL_Lado.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exito!. Se guardaron los datos correctamente.')", true);
            TXT_Comentarios.Text = "";
            TXT_Scrap.Text = "0";
        }
    }
}