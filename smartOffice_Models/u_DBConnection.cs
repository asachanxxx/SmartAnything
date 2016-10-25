//**********************************************************************
//Developer  :PUBUDU
//Date       :2013/10/04
//Description:Create Database Connection
//Module Name: smartOffice
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace smartOffice_Models
{
    public struct ParamStruct
    {
        public string ParamName;
        public DbType DataType;
        public object value;
        public ParameterDirection direction;
        public string sourceColumn;
        public Int16 size;
    }

    public enum DBEngine
    {
        MSSQL,
        MYSQL
    }

    #region Database Connection Class

    public class u_DBConnection
    {
        
        
        public static DBEngine strDBType;
        public static IDbConnection g_DBConnection;
        private static IDbDataAdapter DAdapter;
        private static IDbCommand command;
        public static IDbTransaction trans = null;

       
        //public static SqlConnection g_DBConnection;
        //private static SqlDataAdapter DAdapter;
        //private static SqlCommand command;
        //public static SqlTransaction trans = null;
        
        private static int intCommandTimeout=100;



        public static void BeginTrans()
        {
            if (g_DBConnection == null)
                getConnection();

            trans = g_DBConnection.BeginTransaction();
            
        }

        public static void CommitTrans()
        {
            trans.Commit();
            trans = null;
        }

        public static void RollbackTrans()
        {
            trans.Rollback();
            trans = null;
        }
       

        #region Database Operations

        /// <summary>
        /// Returns an active database connection based on the type of RDBMS
        /// </summary>
        /// <returns>IDbConnection object</returns>
        public static IDbConnection getConnection()
        {
            try
            {
                string strConSettings;
                if (g_DBConnection == null)
                {
                    strDBType = DatabaseFactory.GetDBType();
                    strConSettings = DatabaseFactory.GetConnectionString(strDBType);

                    g_DBConnection = DatabaseFactory.GetConnection(strDBType);
                    g_DBConnection.ConnectionString = strConSettings;
                    //Check the current state of database
                    if (g_DBConnection.State == ConnectionState.Open)
                    {
                        g_DBConnection.Close();
                    }
                    g_DBConnection.Open();
                    
                }
                return g_DBConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IDbConnection getConn()
        {
            try
            {
                string strConSettings;
                if (g_DBConnection == null)
                {
                    strDBType = DatabaseFactory.GetDBType();
                    strConSettings = DatabaseFactory.GetConnectionString(strDBType);

                    g_DBConnection = DatabaseFactory.GetConnection(strDBType);
                    g_DBConnection.ConnectionString = strConSettings;
                    //Check the current state of database
                    if (g_DBConnection.State == ConnectionState.Open)
                    {
                        g_DBConnection.Close();
                    }
                    g_DBConnection.Open();
                }
                return g_DBConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean RunQuery(SqlCommand sqlCom)
        {            
           // String connStr; 
            bool rtnVal = false;          
            IDbConnection conn = getConnection();
       
            try
            {               
               IDbCommand objCommand = sqlCom;                 
               objCommand.Connection = conn;
               objCommand.ExecuteNonQuery();               
                
               rtnVal = true;
               return rtnVal;
            }
            catch (Exception ex)
            {
                throw ex;              
            }

            return rtnVal;
        }

     

        /// <summary>
        /// Add parameters to the SQLCommand object which is used for MSSQL databases
        /// </summary>
        /// <param name="param">An array of parameters for MSSQL database query</param>
        private static void AddParameters(IDbDataParameter[] param)
        {
            try
            {
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        if (param[i] != null)
                        {
                            command.Parameters.Add(param[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Returns dataTable object consists of data by executing a SQL query
        /// </summary>
        /// <param name="query">SQL query statement</param>
        /// <returns>DataTable object</returns>
        public static DataTable ReturnDataTable(string query,CommandType cmdType)
        {
            try
            {
                return ReturnDataTable(query, cmdType, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Returns dataTable object consists of data by executing a SQL query and it's parameters
        /// </summary>
        /// <param name="query">SQL query statement</param>
        /// <param name="param">Data Parameters to execute the query</param>
        /// <returns>DataTable object</returns>
        public static DataTable ReturnDataTable(string query, CommandType cmdType, IDbDataParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                if (g_DBConnection.State != ConnectionState.Open)
                {
                    g_DBConnection.Open();
                }
                command = DatabaseFactory.GetCommand(strDBType);
                command.CommandText = query;
                command.Connection = g_DBConnection;
                AddParameters(param);
                DAdapter = DatabaseFactory.GetAdapter(strDBType);
                DAdapter.SelectCommand = command;
                DAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
            }
        }
        

        /// <summary>
        /// Return data table by giving SQL Query 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable ReturnDT(String Query)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //String connStr;

            // connStr = "server=Asela-pc;database=VehicleDB3;uid=RIT;pwd=SYSMANAGER;";
            // connStr = constring1;
            // string connStr  = "Data Source=NIRMAN\\SQLEXPRESS;Initial Catalog=SOARSmartCommon Integrated Security=True;";  //"Data Source=MYSERVER; Integrated Security=True;";

            try
            {

               // return ReturnDataTable(Query, cmdType, null);
               


                using (IDbConnection conn = getConn())
                {

                    //conn.Open();
                    //IDbCommand objCommand = new IDbCommand(Query, conn);
                    //SqlDataAdapter da = new SqlDataAdapter(objCommand);
                    //da.Fill(dt);
                    //conn.Close();

                    command = DatabaseFactory.GetCommand(strDBType);
                    command.CommandText = Query;
                    command.Connection = conn;
                   // AddParameters(param);
                    DAdapter = DatabaseFactory.GetAdapter(strDBType);
                    DAdapter.SelectCommand = command;
                    DAdapter.Fill(ds);
                    return ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }



        /// <summary>
        /// Return a single Data Row by executing a SQL query
        /// </summary>
        /// <param name="query">SQL query statement</param>
        /// <returns>DataRow object</returns>
        public static DataRow ReturnDataRow(string query)
        {
            try
            {
                return ReturnDataRow(query, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Return a single Data Row by executing a SQL query with it's data parameters
        /// </summary>
        /// <param name="query">SQL query statement</param>
        /// <param name="param">Data Parameters to execute the query</param>
        /// <returns>DataRow object</returns>
        public static DataRow ReturnDataRow(string query, IDbDataParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                command = DatabaseFactory.GetCommand(strDBType);
                command.CommandText = query;
                command.Connection = g_DBConnection;
                AddParameters(param);
                 DAdapter = DatabaseFactory.GetAdapter(strDBType);
                DAdapter.SelectCommand = command;
                DAdapter.Fill(ds); 
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    return ds.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command= null;
            }
        }


        /// <summary>
        /// Return a scaler value
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>object that can be casted to a scaler type</returns>
        public static object ReturnScaler(string query)
        {
            try
            {
                return ReturnScaler(query, null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        /// <summary>
        /// Return a scaler values by executing a parameterizd query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="param">data parameters to execute the query</param>
        /// <returns>object that can be casted to a scaler type</returns>
        public static object ReturnScaler(string query, IDbDataParameter[] param)
        {
            try
            {
                command = DatabaseFactory.GetCommand(strDBType);
                command.CommandText = query;
                command.Connection = g_DBConnection;
                AddParameters(param);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
            }
        }


        /// <summary>
        /// To execute Insert, Update, Delete queries
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>No. of effected rows</returns>
        public static int ExecuteNonQuery(string query)
        {
            try
            {
                return ExecuteNonQuery(query,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To execute Insert, Update, Delete queries
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>No. of effected rows</returns>
        public static int ExecuteNonQuery(string query, decimal NO)
        {
            try
            {
                return ExecuteNonQuery(query,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// To execute parameterized Insert, Update, Delete queries
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="param">Data parameters</param>
        /// <returns>No. of effected rows</returns>
        public static int ExecuteNonQuery(string query, IDbDataParameter[] param)
        {
            try
            {
                command = DatabaseFactory.GetCommand(strDBType);
                command.CommandText = query;
                command.Connection = g_DBConnection;
                command.CommandTimeout = 3000;
                AddParameters(param);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
            }
        }



        /// <summary>
        /// connect the stored procedure with the project
        /// modified by Peshala Rupasingha 2013/12/12
        /// </summary>
        /// <param name="spName">stored procedure name</param>
        /// <param name="type">Form type</param>
        /// <returns>data table fill with data </returns>
        public static DataTable Select(string spName, string type)
        {
            try
            {
                DataSet dataset = new DataSet();
                command = DatabaseFactory.GetCommand(strDBType);
                command.CommandText = spName;
                command.Connection = g_DBConnection;
                //AddParameters(param);
                DAdapter = DatabaseFactory.GetAdapter(strDBType);
                DAdapter.SelectCommand = command;

                DAdapter.SelectCommand.CommandText = spName;
                // command.CommandType = CommandType.StoredProcedure;
                DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (type != null)
                {

                    SqlParameter parameter = new SqlParameter("@type",type);
                    //command.Parameters.Add(parameter);
                    DAdapter.SelectCommand.Parameters.Add(parameter);

                }
                DAdapter.Fill(dataset);
                if (dataset != null)
                {
                    return dataset.Tables[0];
                } return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
           
        }



       





        #endregion
        
    }

    #endregion

    #region Database Factory Class

    class DatabaseFactory
    {
        #region Command
        
        public static IDbCommand GetCommand(DBEngine db)
        {
            switch(db)
            {
                case DBEngine.MSSQL:
                    return new SqlCommand();
                case DBEngine.MYSQL:
                    return new MySqlCommand();
                default:
                    return new SqlCommand();
            }
        }

        #endregion


        #region Data Adapter
        
        public static IDbDataAdapter GetAdapter(DBEngine db)
        {
            switch(db)
            {
                case DBEngine.MSSQL:
                    return new SqlDataAdapter();
                case DBEngine.MYSQL:
                    return new MySqlDataAdapter();
                default:
                    return new SqlDataAdapter();
            }

        }
    
        #endregion


        #region Connection

        public static IDbConnection GetConnection(DBEngine db)
        {
            switch(db)
            {
                case DBEngine.MSSQL:
                    return new SqlConnection();
                case DBEngine.MYSQL:
                    return new MySqlConnection();
                default:
                    return new SqlConnection();
            }
        }

        #endregion


        #region CommandBuilder
        
        public static object GetCommandBuilder(DBEngine db)
        {
            switch (db)
            {
                case DBEngine.MSSQL:
                    return new SqlCommandBuilder();
                case DBEngine.MYSQL:
                    return new MySqlCommandBuilder();
                default:
                    return new SqlCommandBuilder();
            }
        }

        #endregion


        #region Configuration Settings
        
        public static String GetConnectionString(DBEngine db) 
        {
            switch(db)
            {
                case DBEngine.MSSQL:
                    return ConfigurationSettings.AppSettings.Get("MSSQLConnectionString");
                case DBEngine.MYSQL:
                    return ConfigurationSettings.AppSettings.Get("MYSQLConnectionString");
                default:
                    return ConfigurationSettings.AppSettings.Get("MSSQLConnectionString");
            }
        }

        public static DBEngine GetDBType() 
        {
            if (ConfigurationSettings.AppSettings.Get("DBType").ToString() == DBEngine.MSSQL.ToString())
                return DBEngine.MSSQL;
            else if (ConfigurationSettings.AppSettings.Get("DBType").ToString() == DBEngine.MYSQL.ToString())
                return DBEngine.MYSQL;
            else
                return DBEngine.MSSQL;
        
        }

        #endregion

    }

    #endregion






  

}
