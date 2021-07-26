using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDAL
{
    class CourseDL
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
                Console.WriteLine("Something Happened!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstCourses = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Abc"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Courses", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drCourses = sqlCmdObj.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(String.Concat(drCourses["CourseId"] + "  ", drCourses["CourseTitle"] + "  ", drCourses["Duration"] + "  ", drCourses["Owner"] + "  ", drCourses["AssessmentMode"]));
                }
                return lstCourses;
            }
            catch (Exception)
            {
                Console.WriteLine("Something Happened!");
                return lstCourses;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
