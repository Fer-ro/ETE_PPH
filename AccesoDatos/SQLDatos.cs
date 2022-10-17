using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class SQLDatos
    {
        #region  properties
        private string DBUser = "sa";
        private string DBPass = "";
        private string DBServer = "(local)";
        private string DBName = "TempDB";
        private int DBPort = 1433;
        private string DBInstance = "";
        private string DBDomain = "";
        private bool DBIPAddress = false;
#pragma warning disable CS0414 // El campo 'SQLDatos.DBPersistance' está asignado pero su valor nunca se usa
        private bool DBPersistance = false;
#pragma warning restore CS0414 // El campo 'SQLDatos.DBPersistance' está asignado pero su valor nunca se usa
        private bool DBTrusted = false;
#pragma warning disable CS0414 // El campo 'SQLDatos.DBConnected' está asignado pero su valor nunca se usa
        private bool DBConnected = false;
#pragma warning restore CS0414 // El campo 'SQLDatos.DBConnected' está asignado pero su valor nunca se usa
        private bool DBIsInstance = false;
#pragma warning disable CS0414 // El campo 'SQLDatos.DBExpress' está asignado pero su valor nunca se usa
        private bool DBExpress = false;
#pragma warning restore CS0414 // El campo 'SQLDatos.DBExpress' está asignado pero su valor nunca se usa
        private bool DBMars = true;
        private bool DBCE = false;
        private string DBError = "";
        private string DBString = "";
        #endregion
         private string Make_String()
        {
            string Connection = "";
            if (DBTrusted == true)
            {
                Connection = TrustedConnect();
            }
            else
            {
                //Normal Connection
                Connection = StandardConnect();
            }
            return Connection;
        }

        /**
         *  Establish a Trusted Connection |[Optional] MARS Enabled |[Optional] From CE Device
         *  
         */
        private string TrustedConnect()
        {
            try
            {
                if (DBServer.Length > 0 && DBName.Length > 0)
                {
                    if (DBMars == true)
                    {
                        //MARS ENABLED
                        DBString = "Data Source=" + DBServer + ";Initial Catalog=" + DBName + ";" +
                                                "Integrated Security=SSPI;MultipleActiveResultSets=true;";
                    }
                    else if (DBCE == true)
                    {
                        //CE Device connection
                        DBString = "Data Source=" + DBServer + ";Initial Catalog=" + DBName + ";Integrated Security=SSPI;" +
                                                "User ID=" + DBDomain + "\\" + DBUser + ";Password=" + DBPass + ";";
                    }
                    else if (DBIsInstance == true)
                    {
                        //Instance connection
                        DBString = "Server=" + DBServer + "\\" + DBInstance + ";Database=" + DBName + ";Trusted_Connection=True;";
                    }
                    else
                    {
                        //Normal Trusted Connection
                        DBString = "Data Source=" + DBServer + ";Initial Catalog=" + DBName + ";Integrated Security=SSPI;";
                    }
                    return DBString;

                }
                else
                {
                    DBError = "The server/database is null";
                    return DBError;
                }
            }
            catch (SqlException e)
            {
                DBError = "Error " + e.ErrorCode + ": " + e.Errors;
                return DBError;
            }

        }

        /**
         * StandardConnect
         * Open the standard sql connection. 
         * 
         * @param User string
         * @param Pass string
         * @param Server string
         * @param Name string
         * @param Port int
         * @param Instance boolean
         * @param InstanceNm string
         */
        private string StandardConnect()
        {
            try
            {
                if (DBIsInstance == true && DBUser.Length > 0 && DBServer.Length > 0 && DBIPAddress == false)
                {
                    DBString = "Data Source=" + DBServer + "//" + DBInstance + ";Initial Catalog=" + DBName + ";" +
                                            "User Id=" + DBUser + ";Password=" + DBPass;
                    /*
                    DBString = "Server=" + Server + "//" + InstanceNm + ";Database=" + Name + ";UserID=" + User + ";Password=" + Pass + ";" +
                                            "Trusted_Connection=False;";
                     */
                }
                else if (DBUser.Length > 0 && DBServer.Length > 0 && DBIPAddress == false)
                {
                    DBString = "Data Source=" + DBServer + ";Initial Catalog=" + DBName + ";" +
                                            "User Id=" + DBUser + ";Password=" + DBPass+ ";MultipleActiveResultSets=true ;Trusted_Connection=False";
                    //or
                    /*
                    DBString = "Server=" + Server + ";Database=" + Name + ";UserID=" + User + ";Password=" + Pass + ";" +
                                            "Trusted_Connection=False;";
                     */
                }
                else if (DBIPAddress == true)
                {
                    DBString = "Data Source=" + DBServer + "," + DBPort + ";Network Library=DBMSSOCN;Initial Catalog=" + DBName + ";" +
                               "User ID=" + DBUser + ";Password=" + DBPass + ";";
                }
                return DBString;
            }
            catch (Exception e)
            {
                DBError = "Error: " + e.Message;
                return DBError;
            }
        }

        /// <summary>
        /// Instance connection parameters
        /// </summary>
        /// <param name="User"></param>
        /// <param name="pass"></param>
        /// <param name="DB"></param>
        /// <param name="server"></param>
        public SQLDatos(string User, string pass, string DB, string server)
        {
            DBUser = User;
            DBPass = pass;
            DBServer = server;
            DBName = DB;
            Make_String();
        }

        /// <summary>
        /// Open the granted connection 
        /// </summary>
        /// <param name="con"></param>
        private void SQL_abrir_conexion_interna(SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        /// <summary>
        /// Close the gramted connection
        /// </summary>
        /// <param name="con"></param>
        private void SQLCerrarSesion(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        /// <summary>
        ///  Execute a stored procedure SQL whith Parameters
        /// </summary>
        /// <param name="Nombre_Procedimiento">name of store procedure</param>
        /// <param name="Parametros">SQL Parameters</param>
        public void Ejecutar_Procedimiento_Almacenado(string Nombre_Procedimiento, object[] Parametros)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    SQL_abrir_conexion_interna(con);
                    comando.Connection = con;
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);
                    int i = -1;
                    foreach (SqlParameter Par in comando.Parameters)
                    {
                        if (i > -1)
                        {
                            Par.Value = Parametros.ElementAt(i);
                        }
                        i++;
                    }
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                }
                SQLCerrarSesion(con);
            }
        }

        /// <summary>
        /// Execute a stored procedure SQL
        /// </summary>
        /// <param name="Nombre_Procedimiento">stored procedure to exec</param>
        public void Ejecutar_Procedimiento_Almacenado(string Nombre_Procedimiento)
        {
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
                SQLCerrarSesion(con);
            }
        }

        /// <summary>
        /// Get values of DataReader SQL with store procedure
        /// </summary>
        /// <param name="Nombre_Procedimiento">name of store procedure</param>
        /// <returns></returns>
        public IDataReader SLQ_Valores_DataReader(string Nombre_Procedimiento)
        {
            SqlDataReader ReaderRetorno;
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    ReaderRetorno = comando.ExecuteReader();
                    comando.Parameters.Clear();
                }
                SQLCerrarSesion(con);
            }
            return ReaderRetorno;
        }

        /// <summary>
        /// Get a Datatable SQL (query)
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns></returns>
        public DataTable SLQ_Traer_DataTable(StringBuilder query)
        {
            DataTable TablaRretorno = new DataTable();
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlDataAdapter data = new SqlDataAdapter(query.ToString(), con))
                {
                    data.Fill(TablaRretorno);
                }
                SQLCerrarSesion(con);
            }
            return TablaRretorno;
        }

        /// <summary>
        /// Get a Datatable SQL (store precedure and SQL parmeters)
        /// </summary>
        /// <param name="Nombre_Procedimiento">name of store procedure</param>
        /// <param name="Parametros">parameters</param>
        /// <returns></returns>
        public DataTable SLQ_Traer_DataTable(string Nombre_Procedimiento, object[] Parametros)
        {
            DataTable TablaRretorno = new DataTable();
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);
                    int i = -1;
                    foreach (SqlParameter Par in comando.Parameters)
                    {
                        if (i > -1)
                        {
                            Par.Value = Parametros.ElementAt(i);
                        }
                        i++;
                    }
                    TablaRretorno = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(comando);
                    data.Fill(TablaRretorno);
                }
                SQLCerrarSesion(con);
            }
            return TablaRretorno;
        }

        /// <summary>
        ///  Get a Datatable SQL (store precedure)
        /// </summary>
        /// <param name="Nombre_Procedimiento">name of store procedure</param>
        /// <returns></returns>
        public DataTable SLQ_Traer_DataTable(string Nombre_Procedimiento)
        {
            DataTable TablaRretorno = new DataTable();
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    TablaRretorno = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(comando);
                    data.Fill(TablaRretorno);

                }
                SQLCerrarSesion(con);
            }
            return TablaRretorno;
        }

        /// <summary>
        /// Get values of DataReader SQL (query)
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns></returns>
        public object[] SLQ_Valores_DataReader_query(string query)
        {
            SqlCommand comando;
            SqlDataReader retorno;
            object[] obj_retorno;
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                comando = new SqlCommand(query, con);
                retorno = comando.ExecuteReader();
                int banderaDatoReader = 0;
                List<object> ReaderDataList = new List<object>();               
                while (retorno.Read())
                {
                    object[] datoReader = new object[1];
                    retorno.GetValues(datoReader);
                    ReaderDataList.Add(datoReader[0]);
                    banderaDatoReader++;
                }
                if (!retorno.HasRows)
                {
                    obj_retorno = new object[1];
                    obj_retorno[0] = "";
                    return obj_retorno;
                }
                obj_retorno = new object[banderaDatoReader];
                for (int i =0;ReaderDataList.Count>i;i++)
                {
                    obj_retorno[i] = ReaderDataList[i];
                }
                
                SQLCerrarSesion(con);
            }
            return obj_retorno;
        }

        public bool EjecutarQuerySQL(string query)
        {
            SqlCommand comando;
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                SQLCerrarSesion(con);
                return true;
            }
        }
        /// <summary>
        /// Get values of DataReader SQL (store procedure with SQL parameters)
        /// </summary>
        /// <param name="Nombre_Procedimiento">name of store procedure</param>
        /// <param name="Parametros">parameters</param>
        /// <returns></returns>
        public object[] SLQ_Valores_DataReader(string Nombre_Procedimiento, object[] Parametros)
        {
            object[] obj_retorno;
            SqlDataReader ReaderRetorno;
            using (SqlConnection con = new SqlConnection(DBString))
            {
                SQL_abrir_conexion_interna(con);
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = Nombre_Procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(comando);
                    int i = -1;
                    foreach (SqlParameter Par in comando.Parameters)
                    {
                        if (i > -1)
                        {
                            Par.Value = Parametros.ElementAt(i);
                        }
                        i++;
                    }
                    ReaderRetorno = comando.ExecuteReader();
                    comando.Parameters.Clear();
                    ReaderRetorno.Read();
                    obj_retorno = new object[ReaderRetorno.FieldCount];
                    ReaderRetorno.GetValues(obj_retorno);
                }
                SQLCerrarSesion(con);
            }

            return obj_retorno;
        }


    }
}
