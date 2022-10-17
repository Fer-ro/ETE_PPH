using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Threading.Tasks;
using System.Data;

namespace AccesoNegocio
{
    public class AN_GestionUsuarios:ConexionSQL
    {
        public DataTable UsuariosActivos()
        {              
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("Select [ID_Usuario],[Usuario],[Nombre_Usuario],Nomina, FK_ID_Puesto, Password from [FYP_Soldadura_ETE].[dbo].[Usuarios] where [FK_ID_Estatus]=1"));
        }
     
        public void Asignar_Permiso_Usuario(int ID_Pagina_Permiso, int ID_Usuario)
        {
           AccesoDatos.SQLDatos datos = new SQLDatos("prensas", "Fypprensas", "FYP_Soldadura_ETE", "172.25.10.90\\FYPAPP");
           datos.EjecutarQuerySQL(" If Not Exists ( SELECT [FK_ID_Pagina] FROM [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] WHERE FK_ID_Usuario=" + ID_Usuario + " and FK_ID_Pagina=" + ID_Pagina_Permiso + ") Begin INSERT INTO  [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] ([FK_ID_Pagina], [FK_ID_Usuario], [FK_ID_TipoAcceso]) values (" + ID_Pagina_Permiso+","+ID_Usuario+ ",1) end" +
               " ELSE BEGIN If Exists ( SELECT [FK_ID_Pagina] FROM [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] WHERE FK_ID_Usuario=" + ID_Usuario + " and [FK_ID_TipoAcceso]=0 and FK_ID_Pagina=" + ID_Pagina_Permiso + ") Begin UPDATE [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] set [FK_ID_TipoAcceso]=1 where FK_ID_Pagina=" + ID_Pagina_Permiso + " and FK_ID_Usuario=" + ID_Usuario + " end  END ");
        }
        public void Editar_Usuario(int Puesto, int Nomina,int Pass, string Nombre, int ID)
        {
            connectionSQL().EjecutarQuerySQL("   update [FYP_Soldadura_ETE].[dbo].[Usuarios] set [Usuario]='"+Nombre+"', [FK_ID_Puesto]="+Puesto+",[Nomina]="+Nomina+",[Password]="+Pass+", Nombre_Usuario='"+Nombre+ "' WHERE [ID_Usuario]="+ID+" ");
        }
        public void Quitar_Permiso_Usuario(int ID_Pagina_Permiso, int ID_Usuario)
        {
            connectionSQL().EjecutarQuerySQL(" If Exists ( SELECT [FK_ID_Pagina] FROM [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] WHERE FK_ID_Usuario=" + ID_Usuario + " and [FK_ID_TipoAcceso]=1 and FK_ID_Pagina="+ ID_Pagina_Permiso + ") Begin UPDATE [FYP_Soldadura_ETE].[dbo].[Registros_Acceso_Paginas] set [FK_ID_TipoAcceso]=0 where FK_ID_Pagina="+ID_Pagina_Permiso+" and FK_ID_Usuario="+ID_Usuario+" end");
        }
        public List<int> Permisos_De_Usuario(int ID_Usuario)
        {
            DataTable dataDT = connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [FK_ID_Permiso] FROM [FYP_Soldadura_ETE].[dbo].[Registro_Permisos] where [FK_ID_Usuario]=" + ID_Usuario+ " and [FK_ID_EstatusPermiso]=1"));
            List<int> dataList = dataDT.AsEnumerable().Select(r => r.Field<int>("FK_ID_Permiso")).ToList();
            return dataList;
        }
        public bool Dar_Alta_NuevoUsuario(string Username, string nombre,int rol,int Departamento, int nomina, int Pass)
        {

            if (connectionSQL().EjecutarQuerySQL("insert into [FYP_Soldadura_ETE].[dbo].[Usuarios] (Usuario,Nombre_Usuario,FK_ID_Puesto,FK_ID_Estatus,FK_ID_Departamento,FK_ID_Nivel_Rango, Nomina,Password) values ('" + Username.ToLower() + "','" + nombre + "'," + rol + ",1," + Departamento + ",1,"+nomina+","+Pass+")"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool usuarioExistente(int Nomina)
        {
           var resultado= connectionSQL().SLQ_Valores_DataReader_query("SELECT Nomina FROM [FYP_Soldadura_ETE].[dbo].[Usuarios] where Nomina=" + Nomina+" ");
            if (resultado[0].ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
               
            }
        }
        public DataTable Get_Departamentos()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT * FROM [FYP_Soldadura_ETE].[dbo].[Departamentos]"));
        }
       
        public DataTable Get_Roles()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT * FROM [FYP_Soldadura_ETE].[dbo].[Rangos]"));
        }
        public DataTable Get_Puestos()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Puesto],[Puesto_Usuario] FROM [FYP_Soldadura_ETE].[dbo].[Puesto_Usuarios]"));
        }

    }
}
