using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoDAL;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            FacultyDL obj = new FacultyDL();
            obj.ConnectToDB();
            obj.ReadfromDB();
            var result = obj.ReadfromDB();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
