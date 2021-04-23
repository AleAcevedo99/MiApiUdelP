using MiApiUdelp.Util;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MiApiUdelp.Data
{
    public class DataBaseHelper
    {
        /// <summary>
        /// conexion
        /// </summary>
        /// <returns></returns>
        private static SqlConnection conexion()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.SQL_CONNECTION].ConnectionString;
            return conn;
        }

        /// <summary>
        /// executeQueryDatasSet
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataSet executeQueryDatasSet(ParametersDataBaseHelper values)
        {
            DataSet answer = new DataSet();

            SqlConnection conn = conexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand(values.storedProcedureName, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(values.parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(answer);
                    }
                }
            }
            catch (Exception ex)
            {
                answer = null;
            }
            finally
            {
                conn.Close();
            }
            return answer;
        }

        /// <summary>
        /// executeQueryInt
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int executeQueryInt(ParametersDataBaseHelper values)
        {
            int answer = 0;
            SqlConnection conn = conexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand(values.storedProcedureName, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(values.parameters);

                    cmd.Parameters.Add(Constants.SQL_ANSWER, SqlDbType.Int);
                    cmd.Parameters[Constants.SQL_ANSWER].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    answer = int.Parse(cmd.Parameters[Constants.SQL_ANSWER].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                answer = 0;
            }
            finally
            {
                conn.Close();
            }

            return answer;
        }
    }
}