using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ETE_PPH
{
    public class Utilidades
    {
       
        public void SetearDropDownList(DropDownList downList, DataTable sourceDT, string ColumnaTexto, string ColumnaValor)
        {
            downList.DataSource = sourceDT;
            downList.DataTextField = ColumnaTexto;
            downList.DataValueField = ColumnaValor;
            downList.DataBind();
        }

    }
}