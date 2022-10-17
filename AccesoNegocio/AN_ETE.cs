using System;
using System.Collections.Generic;
using System.Linq;
using AccesoDatos;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AccesoNegocio
{
    public class AN_ETE:ConexionSQL
    {
        public DataTable CatalogoLineas()
        {
            
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Linea],[Nombre] FROM [FYP_Soldadura_ETE].[dbo].[Lineas] "));
        }
        public DataTable CatalogoLado()
        {
            DataTable lado = new DataTable();
            lado.Columns.Add("ID_Lado");
            lado.Columns.Add("Lado");
            //
            DataRow row = lado.NewRow();
            row["ID_Lado"] = "NA";
            row["Lado"] = "NA";
            lado.Rows.Add(row);
            //--
            //
            DataRow row1 = lado.NewRow();
            row1["ID_Lado"]= "RH";
            row1["Lado"] = "RH";
            lado.Rows.Add(row1);
            //--
            DataRow row2 = lado.NewRow();
            row2["ID_Lado"] = "LH";
            row2["Lado"] = "LH";
            lado.Rows.Add(row2);
            return lado;          
        }
        public DataTable CatalogoCeldas(int ID_Linea)
        {
          
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("Select [ID_Celda],[Nom_Celda] FROM [FYP_Soldadura_ETE].[dbo].[Celdas] where [FK_ID_Linea]="+ID_Linea+""));
        }
        public DataTable CatalogoCausasParos()
        {
            
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Codigo], concat([Codigo],' - ',[Descripcion]) as Codigo FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] where [FK_ID_TipoParo]=4"));
        }
        public DataTable CatalogoCausasScrap()
        {
           
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Catalogo_Scrap],concat( [Codigo_Defecto] ,' - ',[Descripcion_defecto]) as Codigo FROM [FYP_Soldadura_ETE].[dbo].[Catalogo_Codigos_Scrap]"));
        }
        public DataTable CatalogoTecnicos()
        {            
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Tecnico],[Nom_Tecnico] FROM [FYP_Soldadura_ETE].[dbo].[Tecnicos]"));
        }
        /// <summary>
        /// Guarda un nuevo registro de paro de linea
        /// </summary>
        /// <param name="ID_Usuario"></param>
        /// <param name="ID_TipoParo"></param>
        /// <param name="ID_Celda"></param>
        /// <param name="ID_Atendio"></param>
        /// <param name="FechaInicioParo"></param>
        /// <param name="FechaFinParo"></param>
        /// <param name="Folio"></param>
        /// <param name="Comentario"></param>
        /// <returns>true si se guardo correctamente</returns>
        public bool Guardar_Nuevo_Registro(int ID_Usuario, int ID_TipoParo, int ID_Celda, int ID_Atendio, string FechaInicioParo, string FechaFinParo, string Folio ,string Comentario)
        {
            return connectionSQL().EjecutarQuerySQL("INSERT INTO [FYP_Soldadura_ETE].[dbo].[RegistrosETE] VALUES("+ID_Usuario+ "," + ID_TipoParo + "," + ID_Celda + "," + ID_Atendio + ",'" + FechaInicioParo + "','" + FechaFinParo + "','" + Folio + "','"+DateTime.Now.ToString()+"','" + Comentario + "')");
        }
        public bool Guardar_Nuevo_RegistroScrap(int ID_Usuario,int ID_CodigoScrap,int CantidadPiezas, string FechaIncidencia, string Comentario, string Lado)
        {
            return connectionSQL().EjecutarQuerySQL("INSERT INTO  [FYP_Soldadura_ETE].[dbo].[Registros_Scrap] VALUES(" + CantidadPiezas + ",'" + FechaIncidencia + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + ID_CodigoScrap + ",'" + Lado + "','" + Comentario + "', "+ID_Usuario+") ");
        }
        public DataTable CatalogoTipoParo()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  [ID_AreaFalla],[Area_Falla]  FROM [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas]"));
        }

    }
}
