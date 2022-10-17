using AccesoNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionTickets
{
    public partial class Reportes_Detalle_FR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            return ConvertDataTabletoString(gestionOT.Reporte_TotalTiempo_Acumulado_Semanal());
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