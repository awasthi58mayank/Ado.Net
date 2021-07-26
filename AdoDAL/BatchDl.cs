using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class BatchDl
    {
        System.Data.SqlClient.SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlConObj.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstBatch = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Batch", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drBatch = sqlCmdObj.ExecuteReader();
                while (drBatch.Read())
                {
                    lstBatch.Add(String.Concat(drBatch["BatchId"] + "  ", drBatch["BatchName"] + "  ", drBatch["BatchStrength"]));
                }
                return lstBatch;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstBatch;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
