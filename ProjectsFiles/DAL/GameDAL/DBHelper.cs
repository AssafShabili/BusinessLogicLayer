using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.IO;




/// <summary>
/// Summary description for DBHelper
/// DBHelper access the HttpServerUtility methods through
/// the intrinsic Server object.(that why it inheritance from Page!)
/// </summary>
namespace GameDAL
{
    public static class DBHelper
    {
      
        /// <summary>
        /// open a OleDbConnection
        /// </summary>
        /// <returns>if the connection succeeded return that connection , if not will return null</returns>
        public static OleDbConnection GetConnection()
        {
            OleDbConnection connection = new OleDbConnection(MakeConnectionString());
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                //Console.Write("Run time error :" + ex.Message);
                connection = null;
            }
            return connection;
        }

        private static string MakeConnectionString()
        {
            return String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={0};Persist Security Info = False;",
                @"C:\Users\user\Documents\GitHub\BusinessLogicLayer\ProjectsFiles\DAL\GameDAL\DataBase\DataBaseGameAssafShabili.accdb");
            //F:\ProjectsFiles\GameBLL\GameBLL\bin\Debug\DataBaseGameAssafShabili.accdb
            //@"~\DataBase\DataBaseGameAssafShabili.accdb"
        }


        /// <summary>
        /// get a Sql Query string
        /// and return accordingly
        /// </summary>
        /// <param name="SqlString"></param>
        /// <returns> DataSet fill by the Sql Query string OR null</returns>
        public static DataSet GetDataSet(string SqlString)
        {
            OleDbConnection con = GetConnection();
            if (con == null)
                return null;
            OleDbCommand cmd = new OleDbCommand(SqlString, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            con.Close();
            return ds;
        }


        /// <summary>
        /// will close the connection to database manually
        /// </summary>
        public static void Close(OleDbConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
      
        public static bool UpdateQuery(string SqlString)
        {
            OleDbConnection con = GetConnection();
            if (con == null)
                return false;//if we dont have a connection we cant updata
                             //con.Open();
            OleDbCommand cmd = new OleDbCommand(SqlString, con);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                DBHelper.Close(con);
                return true;
            }
            else
            {
                DBHelper.Close(con);
                return false;
            }
        }

        public static DataTable GetDataTable(int indexOfQuery, string sqlstring)
        {
            var g = GetConnection();
            if (g != null)
            {

                DataSet ds = GetDataSet(sqlstring);
                g.Close();
                return ds.Tables[indexOfQuery];
            }
            return null;
        }

    }
}