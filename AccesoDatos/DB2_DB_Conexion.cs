using IBM.Data.DB2.iSeries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DB2_DB_Conexion
    {
        public static iDB2Connection db2con;


        public static void DB2_Iniciar_Sesion(string Direccion, string DB_Name, string DB_usuario, string DB_pass)
        {
            db2con = new iDB2Connection("DataSource=" + Direccion + ";Default Collection=" + DB_Name + " ;UserID=" + DB_usuario + ";Password=" + DB_pass + "");
            DB2_abrir_conexion_interna();
        }
        //-----------Abrir conexion-----------
        static void DB2_abrir_conexion_interna()
        {
            if (db2con.State == ConnectionState.Closed)
            {
                db2con.Open();
            }
        }
        //----------------------------------------
        public static void DB2CerrarSesion()
        {
            if (db2con.State == ConnectionState.Open)
            {
                db2con.Close();
            }
        }
    }
}
