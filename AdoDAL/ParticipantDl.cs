using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class ParticipantDl
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
            List<String> lstPart = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Participants", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drPart = sqlCmdObj.ExecuteReader();
                while (drPart.Read())
                {
                    lstPart.Add(String.Concat(drPart["ParticipantID"] + "  ", drPart["ParticipantName"] + "  ", drPart["ParticipantEmailID"]));
                }
                return lstPart;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstPart;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
