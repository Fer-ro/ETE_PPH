using System;
using System.Collections.Generic;
using System.Linq;
using AccesoDatos;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.DirectoryServices;

namespace AccesoNegocio
{
    public class AN_Login:ConexionSQL
    {
        public bool ValidarLogin(string Nomina,string Password)
        {
            Nomina = Nomina.Replace(" ", String.Empty);
            Password = Password.Replace(" ", String.Empty);
            string Usuario_SQL = connectionSQL().SLQ_Valores_DataReader_query("Select Nombre_Usuario from [FYP_Soldadura_ETE].[dbo].[Usuarios] where  Nomina='" + Nomina + "' and Password='"+Password+"'")[0].ToString();
            bool authentic = false;
            if (Usuario_SQL != "" && Usuario_SQL!=null)
            {               
                    authentic = true;              
            }  
            return authentic;
        }
        public string GetUsuario(string Nomina)
        {
            string Usuario_SQL = connectionSQL().SLQ_Valores_DataReader_query("Select Nombre_Usuario from [FYP_Soldadura_ETE].[dbo].[Usuarios] where  Nomina='" + Nomina + "'")[0].ToString();
            string authentic = "";
            if (Usuario_SQL != "" || Usuario_SQL != null)
            {
               return Usuario_SQL;
            }
            return authentic;
        }

        public string Rango_De_Usuario(string ID_Usuario)
        {
           return connectionSQL().SLQ_Valores_DataReader_query("Select [FK_ID_Nivel_Rango] from [FYP_Soldadura_ETE].[dbo].[Usuarios] where  ID_Usuario='" + ID_Usuario + "'")[0].ToString();
           
        }
        public string Puesto_Usuario(int ID_Usuario)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [FK_ID_Puesto] from [FYP_Soldadura_ETE].[dbo].[Usuarios] where  ID_Usuario=" + ID_Usuario + "")[0].ToString();

        }
        public int ID_De_Usuario(string Nomina)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("Select [ID_Usuario] from [FYP_Soldadura_ETE].[dbo].[Usuarios] where  Nomina='" + Nomina + "'")[0]);

        }
        public int Get_NominaUSer(int ID_Usuario)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("Select Nomina FROM [FYP_Soldadura_ETE].[dbo].[Usuarios] where  ID_Usuario=" + ID_Usuario + "")[0]);

        }

        public string Departamento_Usuario(int ID_Usuario)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("select DP.Departamento FROM [FYP_Soldadura_ETE].[dbo].[Usuarios] USR inner join [FYP_Soldadura_ETE].[dbo].Departamentos DP on USR.FK_ID_Departamento=DP.ID_Departamento where ID_Usuario="+ ID_Usuario + "")[0].ToString();
        }

        private string Get_Menus(int ID_Menu)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Codigo_Menu] from [FYP_Soldadura_ETE].[dbo].[Menus] where [ID_Menu]=" + ID_Menu + "")[0].ToString();
        }

        private string Get_OrdenPagina(int ID_Pagina)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Orden_En_Menu] from [FYP_Soldadura_ETE].[dbo].[Paginas] where [ID_Paginas]=" + ID_Pagina + "")[0].ToString();
        }
        private string Get_Paginas(int ID_Menu)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Nombre_Pagina] from [FYP_Soldadura_ETE].[dbo].[Paginas]  where [ID_Paginas]=" + ID_Menu + "")[0].ToString();
        }

        private string Get_Direccion_De_Paginas(int ID_Menu)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Direccion_Sitio] from [FYP_Soldadura_ETE].[dbo].[Paginas]  where [ID_Paginas]=" + ID_Menu + "")[0].ToString();
        }

        private string Get_Icono_Pagina(int ID_Menu)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Clase_Icono] from [FYP_Soldadura_ETE].[dbo].[Paginas]  where [ID_Paginas]=" + ID_Menu + "")[0].ToString();
        }

        private string Get_Nombre_De_Paginas(int ID_Menu)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("Select [Nombre_En_Menu] from [FYP_Soldadura_ETE].[dbo].[Paginas]  where [ID_Paginas]=" + ID_Menu + "")[0].ToString();
        }
      
        public List<string[]> Paginas_Permitidos_Usuario(int Usuario)
        {
            DataTable data = connectionSQL().SLQ_Traer_DataTable(new StringBuilder( "Select  [FK_ID_Pagina], ps.Nombre_Pagina from [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] as rap inner join Paginas PS on rap.FK_ID_Pagina=ps.ID_Paginas  where  [FK_ID_TipoAcceso]=1 and FK_ID_Usuario='" + Usuario + "' "));           
            List<string[]> ListaMenus = new List<string []>();
            foreach (DataRow i in data.Rows)
                {               
                    ListaMenus.Add( new string[] { i[0].ToString(),i[1].ToString() });
                }             
            
            return ListaMenus;
        }
      
        public List<string[]> Paginas_Permitidos_ALL()
        {
            DataTable data = connectionSQL().SLQ_Traer_DataTable(new StringBuilder("Select [ID_Paginas],[Nombre_Pagina] FROM [FYP_Soldadura_ETE].[dbo].[Paginas] WHERE  [NivelAcceso_Default]=1 "));
            List<string[]> ListaMenus = new List<string[]>();
            foreach (DataRow i in data.Rows)
            {
                ListaMenus.Add(new string[] { i[0].ToString(), i[1].ToString() });
            }

            return ListaMenus;
        }

        public List<string []> Direcciones_De_Paginas(int Usuario)
        {
            object[] retornoSQL = connectionSQL().SLQ_Valores_DataReader_query("Select [FK_ID_Pagina] from [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] RAP inner join Paginas PS on RAP.FK_ID_Pagina=PS.ID_Paginas where  [FK_ID_TipoAcceso]=1 AND ps.NivelAcceso_Default=1 and FK_ID_Usuario='" + Usuario + "' order by Orden_En_Menu");
            List<string []> Direcicones = new List<string []>();
            foreach (var i in retornoSQL)
            {
                if (i.ToString() != ""&& i!=null)
                {                    
                    Direcicones.Add(new string [] { Get_Direccion_De_Paginas(Convert.ToInt32(i)), Get_Nombre_De_Paginas(Convert.ToInt32(i)), Get_OrdenPagina(Convert.ToInt32(i)), Get_Icono_Pagina(Convert.ToInt32(i)) });
                }
            }
            return Direcicones;
        }

        public bool ValidarPermiso_Pagina(int Pagina, int ID_Usuario)
        {
            object[] retornoSQL = connectionSQL().SLQ_Valores_DataReader_query("Select [FK_ID_TipoAcceso] from [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] where [FK_ID_Pagina]="+Pagina+" and   [FK_ID_TipoAcceso]=1 and FK_ID_Usuario='" + ID_Usuario + "' ");
            if (retornoSQL.Length>0)
            {
                if (retornoSQL[0].ToString()=="1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }
    }
}
