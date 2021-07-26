using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class FacultyDL
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
            List<String> lstFaculty = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Faculty", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drFaculty = sqlCmdObj.ExecuteReader();
                while (drFaculty.Read())
                {
                    lstFaculty.Add(String.Concat(drFaculty["FacultyName"] + "  ", drFaculty["EmailID"] + "  ", drFaculty["PSNo"]));
                }
                return lstFaculty;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstFaculty;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
