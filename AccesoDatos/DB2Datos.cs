using IBM.Data.DB2.iSeries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DB2Datos : DB2_DB_Conexion
    {
        //Metodo para traer datable 
        public static DataTable DB2_Traer_DataTable(string query)
        {
            DataTable dataTable_retorno = new DataTable();
            iDB2DataAdapter data = new iDB2DataAdapter(query.ToString(), db2con);
            data.Fill(dataTable_retorno);
            return dataTable_retorno;
        }
        //Metodo traer SqlDataReader con SP y parametros
        public static iDB2DataReader DB2_Traer_DataReader(string sql)
        {
            iDB2Command Cmd = new iDB2Command();
            Cmd = new iDB2Command(sql, db2con);
            return Cmd.ExecuteReader();

        }

        public static bool DB2_Ejecutar_query(string query_to_exec_sql)
        {
            bool retorno = false;
            iDB2Command Cmd = new iDB2Command();
            Cmd.CommandText = query_to_exec_sql;
            Cmd.Connection = db2con;
            Cmd.ExecuteNonQuery();
            retorno = true;
            return retorno;
        }
    }
}
