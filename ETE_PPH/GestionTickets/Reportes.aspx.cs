using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccesoNegocio;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionTickets
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public static string GetData(string FechaInicial, string FechaFinal, string ID_Linea, string ID_Celda)
            {           
                AN_GestionOT gestionOT = new AN_GestionOT();
                 
                return ConvertDataTabletoString(gestionOT.Top5_Fallas(FechaInicial,  FechaFinal, ID_Linea, ID_Celda));             
            }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetData_Tiempos(string FechaInicial, string FechaFinal,string ID_Linea, string ID_Celda)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            return ConvertDataTabletoString(gestionOT.Top5_Fallas_MayorTiempoParoLinea( FechaInicial,  FechaFinal, ID_Linea, ID_Celda));
        }
        [WebMethod]
        [ScriptMethod( ResponseFormat = ResponseFormat.Json)]
        public static string GetData_MTTR(string FechaInicial, string FechaFinal, string ID_Linea)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            return ConvertDataTabletoString(gestionOT.Fallas_MTTR( FechaInicial,  FechaFinal,ID_Linea));
        }
        [WebMethod]
        
        public static string GetLineas()
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            DataTable lineas = new DataTable();
            lineas = gestionOT.Get_Lineas();
            lineas.Rows.Add(11111, "TODAS");
            lineas.DefaultView.Sort = "ID_Linea DESC";
            return ConvertDataTabletoString(lineas.DefaultView.ToTable());
            
        }
        [WebMethod]
        
        public static string GetCeldas(string ID_Linea)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            DataTable celdas = new DataTable();
            celdas=gestionOT.Get_Celdas_ByLinea(Convert.ToInt32(ID_Linea));
            celdas.Rows.Add(11111, "TODAS");
            celdas.DefaultView.Sort = "ID_Celda DESC";
            return ConvertDataTabletoString(celdas.DefaultView.ToTable());
        }
        [WebMethod]
        public static string GetParosTotales(string Mes, string Periodo)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            return ConvertDataTabletoString(gestionOT.Get_Paros_Totales_DeLinea(Mes,Periodo));
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetData_Top_Minutos_Mensual()
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            return ConvertDataTabletoString(gestionOT.Reporte_TotalTiempo_Acumulado_Mensual());
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetData_Top_Minutos_Semanal()
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            return ConvertDataTabletoString(gestionOT.Reporte_TotalTiempo_Acumulado_Semanal( ));
        }

        public static string ConvertDataTabletoString(DataTable dt)
        {         
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);               
        }

    }
}