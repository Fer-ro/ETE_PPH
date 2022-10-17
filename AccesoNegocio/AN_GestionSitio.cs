using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoNegocio
{
    public class AN_GestionSitio:ConexionSQL
    {
        public bool Guardar_Nueva_Pagina(string NombrePagina, int NivelAcceso, string DireciconSitio, string NombreEnMenu,int OrdenEnMenu)
        {          
            return connectionSQL().EjecutarQuerySQL("INSERT INTO [FYP_Soldadura_ETE].[dbo].[Paginas] ([Nombre_Pagina],[NivelAcceso_Default],[Direccion_Sitio],[Nombre_En_Menu],[Orden_En_Menu])  VALUES('" + NombrePagina + "'," + NivelAcceso + ",'" + DireciconSitio+ "','" + NombreEnMenu + "'," + OrdenEnMenu + " ) ");
        }
        public DataTable Paginas()
        {
            
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("Select * FROM [FYP_Soldadura_ETE].[dbo].[Paginas]"));
        }
       
    }
}
