using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccesoNegocio
{
    public class AN_GestionOT:ConexionSQL
    {

        //Actualizar requerimiento
        public bool Actualizar_FechaAprovacionYusuarioArobo_OT(int ID_OT,DateTime Fecha_Aprobo,int id_usuario_aprobo)
        {
            return connectionSQL().EjecutarQuerySQL("UPDATE  [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] set [Fecha_Aprobo]='" + Fecha_Aprobo.ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "', [FK_ID_Usuario_Aprobo]=" + id_usuario_aprobo + " where [ID_Registro]="+ID_OT+"");
        }
        public bool Validar_Si_Es_OT_Calidad(int ID_OT)
        {
            if (connectionSQL().SLQ_Valores_DataReader_query("Select ID_Solicitud from Registro_OrdenesTrabajo  where FK_ID_Tipo_Falla in (325, 326) and [ID_Solicitud]=" + ID_OT + "")[0].ToString()!="")
            {
                return true;
            }
            else { return false; }
        }
        public bool Actualizar_Estatus_OT(int ID_OT, int Estatus)
        {
           
            return connectionSQL().EjecutarQuerySQL("UPDATE  [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] set [FK_ID_Estatus_Solicitud]="+Estatus+ " where  [ID_Solicitud]="+ID_OT+"");
        }
        public bool Guardar_Nuevo_Contramedida(int ID_OT,int ID_UsuarioRealizo, int ID_Contramedida, string Comentario, DateTime FechaInicio,DateTime FechaFin,string AfectoProduccion)
        {
            return connectionSQL().EjecutarQuerySQL("insert into [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT]( [FK_ID_Contramedida],[FK_ID_RegistroOT],[FK_Usuario_Atendio],[Fecha_Registro],[Fecha_Inicio],[Fecha_Termino], Comentarios,Afecto_Produccion) values (" +
                ""+ID_Contramedida+"," +
                ""+ID_OT+"," +
                ""+ID_UsuarioRealizo+"," +
                "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")+"'," +
                "'" + FechaInicio.ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "'," +
                " '" + FechaFin.ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "','"+Comentario.Trim()+"', '"+ AfectoProduccion + "' )");
        }

        public bool Guardar_Nuevo_Requerimiento(int ID_UsuarioSolicito, int ID_Impacto, int Tipo_Falla, int IDCelda,string Comentarios, DateTime Fecha_Inicio_Falla,string Robot)
        {    
           
            return connectionSQL().EjecutarQuerySQL("INSERT INTO [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ([FK_ID_UsuarioSolicito],[FK_ID_TipoImpacto],[Fecha_Registro],[FK_ID_Tipo_Falla],[FK_ID_Celda],[Comentarios],[FK_ID_Estatus_Solicitud],Fecha_Inicio_Falla,Robot_Zona) VALUES (" + ID_UsuarioSolicito + ", " + ID_Impacto + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',"+Tipo_Falla+" ,"+IDCelda+",'"+Comentarios+"',1,'"+Fecha_Inicio_Falla.ToString("yyyy-MM-dd HH:mm:ss") + "','"+Robot+"')");
        }
        public bool Guardar_Nuevo_RegistroCordon(int FK_ID_Contramedida, string Cordones)
        {
            return connectionSQL().EjecutarQuerySQL("INSERT INTO [FYP_Soldadura_ETE].[dbo].[Registro_Cordones_Contramedidas] ([Cordones],[FK_ID_Contramedida]) values ('"+Cordones+"',"+ FK_ID_Contramedida + ")");
        }
        public bool Guardar_Nuevo_RegistroSensores(int FK_ID_Contramedida, string Sensores)
        {
            return connectionSQL().EjecutarQuerySQL("INSERT INTO [FYP_Soldadura_ETE].[dbo].[Registro_Sensosres_Contramedidas] ([Registro_Direccion],[FK_ID_RegistroContramedida]) values ('" + Sensores + "'," + FK_ID_Contramedida + ")");
        }
        public int Get_IDUltimoRequerimiento()
        {           
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT MAX([ID_Solicitud]) FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo]")[0]);
        }
        public int Get_IDUltimoContramedida()
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT MAX([ID_Registro])  FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT]")[0]);
        }
       
        public int Get_ID_TipoFallo(int ID_Codigo_Fallo)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT FK_ID_TipoParo FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] where ID_Codigo = "+ID_Codigo_Fallo+"")[0]);
        }
        public int Get_ID_AreaFallo(int ID_Codigo_Fallo)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT [FK_ID_Area_Fallo] FROM  FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] where [ID_Codigo] = " + ID_Codigo_Fallo + "")[0]);
        }
        public string GET_Fecha_Inicio_Falla_OT(int ID_OT)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("SELECT Fecha_Inicio_Falla FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] where ID_Solicitud="+ID_OT+" ")[0].ToString();
        }
        public int Get_IDUltimoRequerimiento(int ID_Usuario)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT MAX([ID_Solicitud]) FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] where FK_ID_UsuarioSolicito=" + ID_Usuario+"")[0]);
        }
        public string Get_ComenatrioByOT(int ID_OT)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("SELECT Comentarios FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] WHERE ID_Solicitud="+ID_OT+"")[0].ToString();
        }
        
        public DataTable Get_UltimoTipoImpactos()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_TipoImpacto],[Tipo_Impacto_OT] FROM [FYP_Soldadura_ETE].[dbo].[Catalogo_Impactos_OT]"));
        }
        public DataTable Get_Celdas_ByLinea(int ID_Linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Celda],[Nom_Celda] FROM [FYP_Soldadura_ETE].[dbo].[Celdas] WHERE [FK_ID_Linea]="+ID_Linea+""));
        }
        public DataTable Get_Celdas_ByLinea_TOP5(int ID_Linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Celda],[Nom_Celda] FROM [FYP_Soldadura_ETE].[dbo].[Celdas] WHERE [FK_ID_Linea]=" + ID_Linea + ""));
        }
        public DataTable Get_Paros_Totales_DeLinea(string Mes, string Periodo)
        {
            if (Convert.ToInt32(Mes) < 10)
            {
                Mes = "0" + Mes;
            }

            string FechaInical = "";
            FechaInical = Periodo;
            FechaInical = FechaInical + "-" + Mes + "-01";

            string FechaFinal = "";
            FechaFinal = Periodo;
            int iMes = (1 + Convert.ToInt32(Mes));

            if (iMes < 10)
            {
                Mes = "0" + iMes.ToString();
            }

            FechaFinal = FechaFinal + "-" + Mes + "-01";
           
            



            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT LINEAS.Nombre as 'Linea', COUNT(COTT.ID_Registro) AS 'INCIDENCIAS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT " +
                "inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud " +
                "INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                "INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda " +
                "INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea " +
                "WHERE COTT.[Fecha_Inicio]>='"+FechaInical+"' AND  COTT.[Fecha_Termino]<='"+FechaFinal+"' " +
                " GROUP BY LINEAS.Nombre"));
        }
        public DataTable Get_Codigos_FallasByAreaFalla(int ID_AreaFalla)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  [ID_Codigo],Concat([Codigo],' - ',[Descripcion]) as Descripcion,CAF.Area_Falla FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CP inner join Catalogo_Area_Fallas CAF on CP.FK_ID_TipoParo=CAF.ID_AreaFalla WHERE FK_ID_TipoParo=" + ID_AreaFalla + ""));
        }

        public DataTable Get_Codigos_Fallas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  [ID_Codigo],Concat([Codigo],' - ',[Descripcion]) as Descripcion,CAF.Area_Falla FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CP inner join Catalogo_Area_Fallas CAF on CP.FK_ID_TipoParo=CAF.ID_AreaFalla "));
        }
        public DataTable Get_Robots()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT Robot FROM [FYP_Soldadura_ETE].[dbo].[Robots] ORDER BY ID_Robot desc"));
        }

        public DataTable Get_Sensor1()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT Direccion1 FROM [FYP_Soldadura_ETE].[dbo].[Sensores] GROUP BY (Direccion1)"));
        }
        public DataTable Get_Sensor2()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT Direccion2 FROM [FYP_Soldadura_ETE].[dbo].[Sensores] GROUP BY (Direccion2)"));
        }
        public DataTable Get_Sensor3()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT Direccion3 FROM [FYP_Soldadura_ETE].[dbo].[Sensores] GROUP BY (Direccion3)"));
        }


        public DataTable Get_Codigos_Cordones(int FK_ID_Linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  [ID_Cordon],Cordon FROM [FYP_Soldadura_ETE].[dbo].[Cordones] WHERE Tipo_Maquina ='" + Get_TipoMaquina_Linea(FK_ID_Linea) + "' order by cordon desc "));
        }
        public string Get_TipoMaquina_Linea(int FK_ID_Linea)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("SELECT  Tipo_Maquina FROM [FYP_Soldadura_ETE].[dbo].[Lineas] WHERE ID_Linea=" + FK_ID_Linea + " ")[0].ToString() ;
        }
        public string Get_ID_Linea(string Nombre)
        {
            return connectionSQL().SLQ_Valores_DataReader_query("SELECT  ID_Linea  FROM [FYP_Soldadura_ETE].[dbo].[Lineas] WHERE [Nombre]='" + Nombre + "' ")[0].ToString();
        }
        public DataTable Get_Codigos_FallasByAreaFalla_PalabraClave(string PalabraClave)
        {

            DataTable DT_for = new DataTable();
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  [ID_Codigo],Concat([Codigo],' - ',[Descripcion]) as Descripcion,CAF.Area_Falla FROM [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CP inner join Catalogo_Area_Fallas CAF on CP.FK_ID_TipoParo=CAF.ID_AreaFalla where CP.Descripcion like '%"+PalabraClave+"%' "));

        }
        public DataTable Get_Contramedidas()
        {

            DataTable DT_for = new DataTable();
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Contramedida] ,[Contramedida] FROM [FYP_Soldadura_ETE].[dbo].[Contramedidas] "));

        }
        public int Get_TipoFallaByID_OT(int ID_OT)
        {
            return Convert.ToInt32(connectionSQL().SLQ_Valores_DataReader_query("SELECT FK_ID_Tipo_Falla FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] WHERE [ID_Solicitud]=" + ID_OT+"")[0]);
        }
        public DataTable Get_Lineas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Linea],[Nombre] FROM [FYP_Soldadura_ETE].[dbo].[Lineas]"));
        }
        public DataTable Get_TipoFallas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_FallaOT],[Falla] FROM  [FYP_Soldadura_ETE].[dbo].[Catalogo_Fallas_NuevaOT]"));
        }
        public DataTable OTS_De_Usuario(int ID_USuario)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',[Robot_Zona] as 'Robot',[Fecha_Inicio_Falla] as 'Fecha que inicio falla',[Fecha_Registro] as 'Fecha que creo OT', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de paro', AREA_FALLA.[Area_Falla] AS 'Area de Falla'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario" +
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                " WHERE ROT.FK_ID_Estatus_Solicitud=1 AND ROT.FK_ID_UsuarioSolicito=" + ID_USuario+" ORDER BY ROT.Fecha_Registro DESC "
                ));
        }
        public DataTable OT_Abiertas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',[Robot_Zona] as 'Robot',[Fecha_Inicio_Falla] as 'Fecha que inicio falla',[Fecha_Registro] as 'Fecha que creo OT', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de paro', AREA_FALLA.[Area_Falla] AS 'Area de Falla'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario"+
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                "  INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                " WHERE ROT.FK_ID_Estatus_Solicitud=1 ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Abiertas(int ID_Linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',[Robot_Zona] as 'Robot',[Fecha_Inicio_Falla] as 'Fecha que inicio falla',[Fecha_Registro] as 'Fecha que creo OT', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de paro', AREA_FALLA.[Area_Falla] AS 'Area de Falla'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario" +
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                "  INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                  " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                " WHERE ROT.FK_ID_Estatus_Solicitud=1 and LINEAS.ID_Linea=" +ID_Linea+" "
                ));
        }
        public DataTable OT_Abiertas_Desaprobadas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',[Robot_Zona] as 'Robot',[Fecha_Registro] as 'Fecha de registro', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de paro'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario" +
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                "  INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                " WHERE ROT.FK_ID_Estatus_Solicitud=4 ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Abiertas_Desaprobadas(int id_linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',[Robot_Zona] as 'Robot',[Fecha_Registro] as 'Fecha de registro', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de paro'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario" +
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                "  INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                " WHERE ROT.FK_ID_Estatus_Solicitud=4 and LINEAS.ID_Linea=" + id_linea + " ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Cerradas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder(" SELECT USUARIOS.Nombre_Usuario as 'Usuario atendio OT' ,ROT.ID_Solicitud AS 'Folio OT',CODIGOS_PARO.Descripcion  ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda' ,[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud,ROT.Fecha_Inicio_Falla AS 'Fecha Inicio falla', COTT.Fecha_Inicio as 'Fecha atendio OT',DATEDIFF(MINUTE,ROT.Fecha_Inicio_Falla,COTT.Fecha_Inicio) AS 'Tiempo de respuesta', COTT.Fecha_Termino as 'Fecha finalizo OT',DATEDIFF(MINUTE,COTT.Fecha_Inicio,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos',DATEDIFF(MINUTE,ROT.Fecha_Inicio_Falla,COTT.Fecha_Termino) AS 'Tiempo total de paro', COTT.Fecha_Registro as 'Fecha realizo registro mtto', COTT.Fecha_Aprobo as 'Fecha aprobo',USUARIO_APROBO.Nombre_Usuario as 'Usuario aprobo'  " +
               " FROM[FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT"+
               "  inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT = ROT.ID_Solicitud" +
               "  INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida = CT.ID_Contramedida" +
                "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio = USUARIOS.ID_Usuario" +
                 " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda = CELDAS.ID_Celda" +
                  " INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea = LINEAS.ID_Linea" +
                "  LEFT join dbo.Usuarios USUARIO_APROBO on COTT.FK_ID_Usuario_Aprobo = USUARIO_APROBO.ID_Usuario" +
                 " INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto = TIPO_IMPACTO.ID_TipoImpacto" +
                 " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud = ESTATUS_OT.ID_EstatusSolicitud" +
                 " INNER JOIN[FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla] = CODIGOS_PARO.[ID_Codigo]" +
                 "  INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                " WHERE ROT.FK_ID_Estatus_Solicitud = 3 ORDER BY ROT.Fecha_Registro DESC"
                ));
        }

        public DataTable OT_Cerradas_ByLinea(int ID_Folio)
        {
            if (ID_Folio==0)
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT USUARIOS.Nombre_Usuario as 'Usuario atendio OT',ROT.ID_Solicitud AS 'Folio OT',CODIGOS_PARO.Descripcion ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda',[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud, ROT.Fecha_Registro AS 'Fecha Solicitud OT', COTT.Fecha_Inicio as 'Fecha atendio OT', COTT.Fecha_Termino as 'Fecha finalizo OT',DATEDIFF(MINUTE,COTT.Fecha_Inicio,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos' , COTT.Fecha_Registro as 'Fecha realizo registro mtto', COTT.Fecha_Aprobo as 'Fecha aprobo',USUARIO_APROBO.Nombre_Usuario as 'Usuario aprobo'" +
                              " FROM[FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT" +
                              "  inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT = ROT.ID_Solicitud" +
                              "  INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida = CT.ID_Contramedida" +
                               "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio = USUARIOS.ID_Usuario" +
                                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda = CELDAS.ID_Celda" +
                                 " INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea = LINEAS.ID_Linea" +
                               "  LEFT join dbo.Usuarios USUARIO_APROBO on COTT.FK_ID_Usuario_Aprobo = USUARIO_APROBO.ID_Usuario" +
                                " INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto = TIPO_IMPACTO.ID_TipoImpacto" +
                                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud = ESTATUS_OT.ID_EstatusSolicitud" +
                                " INNER JOIN[FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla] = CODIGOS_PARO.[ID_Codigo]" +
                                "  INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                               " WHERE ROT.FK_ID_Estatus_Solicitud = 3  ORDER BY ROT.Fecha_Registro  DESC"
                               ));
            }
            else
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT USUARIOS.Nombre_Usuario as 'Usuario atendio OT',ROT.ID_Solicitud AS 'Folio OT',CODIGOS_PARO.Descripcion ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda',[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud, ROT.Fecha_Registro AS 'Fecha Solicitud OT', COTT.Fecha_Inicio as 'Fecha atendio OT', COTT.Fecha_Termino as 'Fecha finalizo OT',DATEDIFF(MINUTE,COTT.Fecha_Inicio,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos' , COTT.Fecha_Registro as 'Fecha realizo registro mtto', COTT.Fecha_Aprobo as 'Fecha aprobo',USUARIO_APROBO.Nombre_Usuario as 'Usuario aprobo'" +
              " FROM[FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT" +
              "  inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT = ROT.ID_Solicitud" +
              "  INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida = CT.ID_Contramedida" +
               "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio = USUARIOS.ID_Usuario" +
                " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda = CELDAS.ID_Celda" +
                 " INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea = LINEAS.ID_Linea" +
               "  LEFT join dbo.Usuarios USUARIO_APROBO on COTT.FK_ID_Usuario_Aprobo = USUARIO_APROBO.ID_Usuario" +
                " INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto = TIPO_IMPACTO.ID_TipoImpacto" +
                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud = ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN[FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla] = CODIGOS_PARO.[ID_Codigo]" +
                "  INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
               " WHERE ROT.FK_ID_Estatus_Solicitud = 3 and ROT.ID_Solicitud ='" + ID_Folio + "' ORDER BY ROT.Fecha_Registro  DESC"
               ));
            }
        }
        public DataTable OT_Espera_Aprobacion()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("" +
                " SELECT  USUARIOS.Nombre_Usuario as 'Usuario atendio OT',ROT.ID_Solicitud AS 'Folio de OT',CODIGOS_PARO.Descripcion ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda',ROT.[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Afecto_Produccion as 'Afecto produccion',COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud, ROT.Fecha_Inicio_Falla AS 'Fecha de inicio falla (OT)', COTT.Fecha_Inicio as 'Fecha atendio OT', COTT.Fecha_Termino as 'Fecha finalizo OT' , DATEDIFF(MINUTE,COTT.Fecha_Inicio ,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos', DATEDIFF(MINUTE,ROT.Fecha_Inicio_Falla ,COTT.Fecha_Termino) as 'Tiempo total de falla/paro', DATEDIFF(MINUTE,ROT.Fecha_Inicio_Falla ,COTT.Fecha_Inicio) as 'Tiempo de respuesta' , COTT.Fecha_Registro as 'Fecha realizo registro mtto',CASE WHEN RCC.Cordones='' THEN 'NA' ELSE RCC.Cordones END AS 'Cordon', RSC.Registro_Direccion AS 'Sensor',AREA_FALLA.[Area_Falla] AS 'Area de Falla'" +
                " FROM [FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT" +
                " inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida=CT.ID_Contramedida" +
                "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio=USUARIOS.ID_Usuario" +
                "  INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto " +
                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud"+
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                "  INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                " LEFT JOIN dbo.Registro_Cordones_Contramedidas RCC on COTT.ID_Registro=RCC.FK_ID_Contramedida" +
                " LEFT JOIN dbo.Registro_Sensosres_Contramedidas RSC on COTT.ID_Registro=RSC.FK_ID_RegistroContramedida" +
                " WHERE ROT.FK_ID_Estatus_Solicitud in (9,2)  ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Espera_Aprobacion(int id_linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("" +
                " SELECT  COTT.ID_Registro as 'ID registro',USUARIOS.Nombre_Usuario as 'Usuario atendio OT',ROT.ID_Solicitud AS 'Solicitud OT',CODIGOS_PARO.Descripcion ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda',ROT.[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Afecto_Produccion,COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud, ROT.Fecha_Registro AS 'Fecha Solicitud OT', COTT.Fecha_Inicio as 'Fecha atendio OT', COTT.Fecha_Termino as 'Fecha finalizo OT',  DATEDIFF(MINUTE,COTT.Fecha_Inicio,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos' ,COTT.Fecha_Registro as 'Fecha realizo registro mtto',CASE WHEN RCC.Cordones='' THEN 'NA' ELSE RCC.Cordones END AS 'Cordon', RSC.Registro_Direccion AS 'Sensor'" +
                " FROM [FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT" +
                " inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida=CT.ID_Contramedida" +
                "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio=USUARIOS.ID_Usuario" +
                "  INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto " +
                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo]" +
                 " LEFT JOIN dbo.Registro_Cordones_Contramedidas RCC on COTT.ID_Registro=RCC.FK_ID_Contramedida" +
                 " LEFT JOIN dbo.Registro_Sensosres_Contramedidas RSC on COTT.ID_Registro=RSC.FK_ID_RegistroContramedida" +
                " WHERE ROT.FK_ID_Estatus_Solicitud=2  and LINEAS.ID_Linea=" + id_linea + " ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Espera_Aprobacion_Calidad()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("" +
                " SELECT  COTT.ID_Registro as 'ID registro',USUARIOS.Nombre_Usuario as 'Usuario atendio OT',ROT.ID_Solicitud AS 'Solicitud OT',CODIGOS_PARO.Descripcion ,LINEAS.Nombre as 'Linea',CELDAS.Nom_Celda as 'Celda',ROT.[Robot_Zona] as 'Robot', CT.Contramedida AS 'Tipo de ajuste',COTT.Afecto_Produccion,COTT.Comentarios as 'Comentario de contramedidas', ESTATUS_OT.Solicitud, ROT.Fecha_Registro AS 'Fecha Solicitud OT', COTT.Fecha_Inicio as 'Fecha atendio OT', COTT.Fecha_Termino as 'Fecha finalizo OT',  DATEDIFF(MINUTE,COTT.Fecha_Inicio,COTT.Fecha_Termino) as 'Tiempo total de ajuste minutos' ,COTT.Fecha_Registro as 'Fecha realizo registro mtto',CASE WHEN RCC.Cordones='' THEN 'NA' ELSE RCC.Cordones END AS 'Cordon', RSC.Registro_Direccion AS 'Sensor'" +
                " FROM [FYP_Soldadura_ETE].[dbo].Registro_Contramedidas_OT COTT" +
                " inner join dbo.Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN dbo.Contramedidas CT ON COTT.FK_ID_Contramedida=CT.ID_Contramedida" +
                "  INNER JOIN dbo.Usuarios USUARIOS ON COTT.FK_Usuario_Atendio=USUARIOS.ID_Usuario" +
                "  INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto " +
                " INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo]" +
                "  INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla]" +
                 " LEFT JOIN dbo.Registro_Cordones_Contramedidas RCC on COTT.ID_Registro=RCC.FK_ID_Contramedida" +
                 " LEFT JOIN dbo.Registro_Sensosres_Contramedidas RSC on COTT.ID_Registro=RSC.FK_ID_RegistroContramedida" +
                " WHERE ROT.FK_ID_Estatus_Solicitud=10 ORDER BY ROT.Fecha_Registro DESC"
                ));
        }
        public DataTable OT_Todas()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("  SELECT [ID_Solicitud] as 'ID OT' ,USUARIOS.Usuario AS 'Usuario Solicito',TIPO_IMPACTO.Tipo_Impacto_OT as 'Impacto',  CELDAS.Nom_Celda as 'Celda',LINEAS.Nombre as 'Linea',ESTATUS_OT.Solicitud,[Robot_Zona] as 'Robot',[Fecha_Inicio_Falla] as 'Fecha que inicio falla', ROT.[Fecha_Registro] as 'Fecha que creo OT', ESTATUS_OT.Solicitud as 'Estatus', CODIGOS_PARO.[Descripcion] AS 'Tipo de par', RCOT.Fecha_Termino AS 'Fecha termino ajuste falla', DATEDIFF(MINUTE,ROT.Fecha_Inicio_Falla, RCOT.Fecha_Termino) AS 'Tiempo total de paro'" +
                 " FROM [FYP_Soldadura_ETE].[dbo].[Registro_OrdenesTrabajo] ROT" +
                 " INNER JOIN dbo.Usuarios USUARIOS ON ROT.FK_ID_UsuarioSolicito=USUARIOS.ID_Usuario" +
                 " INNER JOIN dbo.Celdas CELDAS on ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                 "  INNER JOIN dbo.Lineas LINEAS on CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                 "  INNER JOIN dbo.Catalogo_Impactos_OT TIPO_IMPACTO ON ROT.FK_ID_TipoImpacto=TIPO_IMPACTO.ID_TipoImpacto" +
                 "  INNER JOIN Estaus_Solicitud ESTATUS_OT ON ROT.FK_ID_Estatus_Solicitud=ESTATUS_OT.ID_EstatusSolicitud" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Codigos_Paro] CODIGOS_PARO ON ROT.[FK_ID_Tipo_Falla]=CODIGOS_PARO.[ID_Codigo] " +
                   " INNER JOIN [FYP_Soldadura_ETE].[dbo].[Catalogo_Area_Fallas] AREA_FALLA ON CODIGOS_PARO.[FK_ID_Area_Fallo]=AREA_FALLA.[ID_AreaFalla] " +
                   " LEFT JOIN  [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] RCOT ON ROT.ID_Solicitud=RCOT.FK_ID_RegistroOT " +
                   "  WHERE ROT.FK_ID_Estatus_Solicitud<>5 " +
                 " order by  ROT.Fecha_Inicio_Falla DESC "
                 ));
        }

        public DataTable Top5_Fallas(string Fechainicial, string FechaFinal, string Linea,string Celda)
        {
            if (Linea == "11111"&&Celda == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA', COUNT(ROT.FK_ID_Tipo_Falla) AS 'INCIDENCIAS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + Fechainicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' " +
                " GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                " order by  COUNT(ROT.FK_ID_Tipo_Falla) DESC" +
                " "
                ));
            }
            
            if (Linea == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA', COUNT(ROT.FK_ID_Tipo_Falla) AS 'INCIDENCIAS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + Fechainicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and CELDAS.ID_Celda='" + Celda + "' " +
                " GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                " order by  COUNT(ROT.FK_ID_Tipo_Falla) DESC" +
                " "
                ));
            }
            if (Celda == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA', COUNT(ROT.FK_ID_Tipo_Falla) AS 'INCIDENCIAS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + Fechainicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and LINEAS.ID_Linea='" + Linea + "' " +
                " GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                " order by  COUNT(ROT.FK_ID_Tipo_Falla) DESC" +
                " "
                ));
            }
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA', COUNT(ROT.FK_ID_Tipo_Falla) AS 'INCIDENCIAS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + Fechainicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and LINEAS.ID_Linea='" + Linea + "' and CELDAS.ID_Celda='" + Celda + "'" +
                " GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                " order by  COUNT(ROT.FK_ID_Tipo_Falla) DESC" +
                " "
                ));
        }
        public DataTable Top5_Fallas_MayorTiempoParoLinea(string FechaInicial, string FechaFinal, string Linea,string Celda)
        {
            if (Celda == "11111" && Linea == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA',SUM( DATEDIFF(minute,ROT.Fecha_Inicio_Falla,COTT.Fecha_Termino)) AS'MINUTOS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + FechaInicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' " +
                "  GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                "  order by MINUTOS desc"
                ));
            }
     
            if (Linea == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA',SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + FechaInicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and CELDAS.ID_Celda='" + Celda + "'  " +
                "  GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                "  order by MINUTOS desc"
                ));
            }
            if (Celda == "11111")
            {
                return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA',SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + FechaInicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and LINEAS.ID_Linea='" + Linea + "' and ROT.FK_ID_UsuarioSolicito<>2 " +
                "  GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                "  order by MINUTOS desc"
                ));
            }
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT  top 5 replace(COP.Descripcion,' ','<br>') AS 'FALLA',SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + FechaInicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "' and LINEAS.ID_Linea = '" + Linea + "' and CELDAS.ID_Celda = '" + Celda + "' " +
                "  GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                "  order by MINUTOS desc"
                ));
            
           

        }
        public DataTable Fallas_MTTR(string FechaInicial, string FechaFinal,string ID_Linea)
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT replace(COP.Descripcion,' ','<br>') AS 'FALLA', COUNT(ROT.FK_ID_Tipo_Falla) AS '#INCIDENCIAS', SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS', SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino))/COUNT(ROT.FK_ID_Tipo_Falla) as 'MTTR'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                 " INNER JOIN [FYP_Soldadura_ETE].[dbo].Celdas CELDAS ON ROT.FK_ID_Celda=CELDAS.ID_Celda" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Lineas LINEAS ON CELDAS.FK_ID_Linea=LINEAS.ID_Linea" +
                " WHERE COTT.[Fecha_Inicio]>='" + FechaInicial + "' AND  COTT.[Fecha_Termino]<='" + FechaFinal + "'  and LINEAS.ID_Linea='" + ID_Linea + "' and ROT.FK_ID_UsuarioSolicito<>2 " +
                "  GROUP BY COP.Descripcion,ROT.FK_ID_Tipo_Falla" +
                "  order by  MTTR DESC"
                ));
        }
        public DataTable Reporte_TotalTiempo_Acumulado_Mensual()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT DATEPART(MONTH,Fecha_Inicio) AS 'MES', SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS'" +
                " FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT" +
                " inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud" +
                " INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo" +
                " where COTT.Fecha_Inicio >=DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)" +
                "  GROUP BY  DATEPART(MONTH,Fecha_Inicio)" +
                "  order by MINUTOS desc"
                ));
        }
        public DataTable Reporte_TotalTiempo_Acumulado_Semanal()
        {
            return connectionSQL().SLQ_Traer_DataTable(new StringBuilder("SELECT DATEPART(WEEK,Fecha_Inicio) AS 'SEMANA', SUM( DATEDIFF(minute,COTT.Fecha_Inicio,COTT.Fecha_Termino)) AS'MINUTOS' " +
                "FROM [FYP_Soldadura_ETE].[dbo].[Registro_Contramedidas_OT] COTT " +
                "inner join [FYP_Soldadura_ETE].[dbo].Registro_OrdenesTrabajo ROT ON COTT.FK_ID_RegistroOT=ROT.ID_Solicitud " +
                "INNER JOIN [FYP_Soldadura_ETE].[dbo].Codigos_Paro COP ON ROT.FK_ID_Tipo_Falla=COP.ID_Codigo " +
                "where COTT.Fecha_Inicio >=DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) and (ROT.[FK_ID_Estatus_Solicitud]<>1 AND [FK_ID_Estatus_Solicitud]<>2 " +
                " AND [FK_ID_Estatus_Solicitud]<>4 AND [FK_ID_Estatus_Solicitud]<>5 AND [FK_ID_Estatus_Solicitud]<>7 AND [FK_ID_Estatus_Solicitud]<>8 AND [FK_ID_Estatus_Solicitud]<>10) " +
                "GROUP BY  DATEPART(WEEK,Fecha_Inicio) " +
                "order by MINUTOS desc"));
        }

    }
}
