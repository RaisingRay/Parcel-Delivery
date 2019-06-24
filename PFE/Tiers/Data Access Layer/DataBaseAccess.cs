using System;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PFE.Tiers.Data_Access_Layer
{
    public class DataBaseAccess
    {        //sql attributes
        private MySqlConnection connection;
        private MySqlCommand command;

        //constructors

        public DataBaseAccess()
        {
            connection = getConnection();
        }

        //Ops
        public MySqlDataReader offlineProcedureCall(String ProcedureName)
        {
            command = new MySqlCommand();
            MySqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = ProcedureName;
                connection.Open();
                rdr = command.ExecuteReader();
                return rdr;
            }
            catch (MySqlException)
            {
                connection.Close();
                return null;
            }

        }

        public MySqlDataReader offlineSelection(String Query)
        {
            command = new MySqlCommand();
            MySqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandText = Query;
                connection.Open();
                rdr = command.ExecuteReader();
                return rdr;
            }
            catch (MySqlException)
            {
                connection.Close();
                return null;
            }
        }

        protected MySqlDataReader onlineProcedureCall(String ProcedureName,MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            MySqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = ProcedureName;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                }
                connection.Open();
                rdr = command.ExecuteReader();
                return rdr;
            }
            catch (MySqlException)
            {
                connection.Close();
                return null;
            }

        }

        protected Object onlineProcedureCallScaler(String ProcedureName, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            Object rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = ProcedureName;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                }
                connection.Open();
                rdr = command.ExecuteScalar();
                connection.Close();
                return rdr;
            }
            catch (MySqlException)
            {
                connection.Close();
                return null;
            }

        }

        public MySqlDataReader onlineSelection(String Query, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            MySqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandText = Query;

                System.Diagnostics.Debug.WriteLine("Querryyy");

                System.Diagnostics.Debug.WriteLine(Query);

                connection.Open();
                if(parameters!=null)
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                }
                
                rdr = command.ExecuteReader();
                return rdr;
            }
            catch (MySqlException)
            {
                connection.Close();
                return null;
            }

        }

        protected int updateProcedureCall(String procedureName, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                }
                connection.Open();
                int effectedRow = command.ExecuteNonQuery();
                connection.Close();
                return effectedRow;
            }
            catch (MySqlException)
            {
                connection.Close();
                return -1;
            }

        }

        protected int insertProcedureCall(String procedureName, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                    
                }

                MySqlParameter par = new MySqlParameter();
                par.ParameterName = "@ID";
                par.DbType = DbType.Int32;
                par.Direction = ParameterDirection.Output;
                command.Parameters.Add(par);
                connection.Open();
                command.ExecuteNonQuery();
                int id =(int) command.Parameters["@ID"].Value;
                connection.Close();
                return id;
            }
            catch (MySqlException)
            {
                connection.Close();
                return -1;
            }

        }
        protected int insertProcedureCallWithoutID(String procedureName, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            try
            {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);

                }

               
                connection.Open();
                int id = command.ExecuteNonQuery();
                connection.Close();
                return id;
            }
            catch (MySqlException)
            {
                connection.Close();
                return -1;
            }

        }



        protected int updateQuery(String Query, MySqlParameter[] parameters)
        {
            command = new MySqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = Query;
                foreach (MySqlParameter para in parameters)
                {
                    command.Parameters.Add(para);
                }
                connection.Open();
                int effectedRow = command.ExecuteNonQuery();
                connection.Close();
                return effectedRow;
            }
            catch (MySqlException)
            {
                connection.Close();
                return -1;
            }
        }


        private MySqlConnection getConnection()
        {
            try
            {
                return new MySqlConnection(WebConfigurationManager.OpenWebConfiguration("/web.config").ConnectionStrings.ConnectionStrings["raising"].ConnectionString);
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        protected void Close()
        {
            connection.Close();
        }
    }
}