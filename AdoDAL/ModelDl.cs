using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class ModelDl
    {
        SqlConnection sqlConObj = null;
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
            List<String> lstModel = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Model", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drModel = sqlCmdObj.ExecuteReader();
                while (drModel.Read())
                {
                    lstModel.Add(String.Concat(drModel["ModelId"] + "  ", drModel["ModelName"] + "  ", drModel["ModelOwner"] + "  ", drModel["ModelDate"]));
                }
                return lstModel;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstModel;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
