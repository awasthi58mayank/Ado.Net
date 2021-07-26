using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class GraderDL
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
            List<String> lstGrader = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Grader", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drGrader = sqlCmdObj.ExecuteReader();
                while (drGrader.Read())
                {
                    lstGrader.Add(String.Concat(drGrader["Marks_Obtained"] + "  ", drGrader["Feedback"] + "  ", drGrader["BatchID"] + "  ", drGrader["CourseID"] + "  ", drGrader["ParticipantID"]));
                }
                return lstGrader;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstGrader;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
