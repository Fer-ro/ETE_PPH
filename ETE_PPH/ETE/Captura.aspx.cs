using AccesoNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETE_PPH.ETE
{
    public partial class Captura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                    OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                    AN_Login login = new AN_Login();
                    if (!login.ValidarPermiso_Pagina(1, user.ID_Usuario))
                    {
                        Response.Redirect("~/Error404.aspx");
                    }
                    AN_ETE ete = new AN_ETE();
                    SetearDropDownList(DDL_Linea, ete.CatalogoLineas(), "Nombre", "ID_Linea");
                    SetearDropDownList(DDL_CausaParo, ete.CatalogoCausasParos(), "Codigo", "ID_Codigo");
                    SetearDropDownList(DDL_AtendidoPor, ete.CatalogoTecnicos(), "Nom_Tecnico", "ID_Tecnico");
                

                
                
            }
        }
       
        void SetearDropDownList(DropDownList downList, DataTable sourceDT,  string ColumnaTexto,string ColumnaValor)
        {
            downList.DataSource = sourceDT;
            downList.DataTextField = ColumnaTexto;
            downList.DataValueField = ColumnaValor;
            downList.DataBind();
        }

        protected void DDL_Linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AN_ETE ete = new AN_ETE();
            SetearDropDownList(DDL_Celda, ete.CatalogoCeldas(Convert.ToInt32(DDL_Linea.SelectedValue)), "Nom_Celda", "ID_Celda");
        }

        
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_Fecha(string fecha)
        {
            string Fecha = Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
            HttpContext.Current.Session["FechaParo"]= Fecha;      
            return "";
        }
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_HoraI(string HoraI)
        {
            string  Hora= Convert.ToDateTime(HoraI).ToString("HH:mm:ss");
            HttpContext.Current.Session["HoraI"] = Hora;
            return "";
        }
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_HoraF(string HoraF)
        {
            string Hora = Convert.ToDateTime(HoraF).ToString("HH:mm:ss");
            HttpContext.Current.Session["HoraF"] = Hora;
            return "";
        }

        protected void BNT_GuardarRegistro_Click(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            AN_ETE ete = new AN_ETE();
            int ID_Usuario=user.ID_Usuario;
            int ID_Tipo_Paro=Convert.ToInt32(DDL_CausaParo.SelectedValue);
            int ID_Celda=Convert.ToInt32(DDL_Celda.SelectedValue);
            int ID_Atendio= Convert.ToInt32(DDL_AtendidoPor.SelectedValue);
            string Fechainicio = (string)HttpContext.Current.Session["FechaParo"] + " "+  HttpContext.Current.Session["HoraI"];
            string Fechafin= (string)HttpContext.Current.Session["FechaParo"] + " " + HttpContext.Current.Session["HoraF"]; ;
            string Folio= TXT_OrdenDeTrabajo.Text;
            string Comentario = TXT_Comentarios.Text;
            ete.Guardar_Nuevo_Registro(ID_Usuario,ID_Tipo_Paro,ID_Celda,ID_Atendio, Fechainicio, Fechafin, Folio,Comentario);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exito!:Se guardaron los datos correctamente.')", true);
            Limpiar_Controles();
            UpdatePanel1.Update();
        }
        private void Limpiar_Controles()
        {
            TXT_OrdenDeTrabajo.Text = "";
            TXT_Comentarios.Text = "";       
        }
    }
}