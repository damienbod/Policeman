using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicemanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
	        try
	        {
				TestClass testOk = new TestClass("gfdg", 653);
				//TestClass testNok = new TestClass(null, 73);
				TestClass testNok = new TestClass("gfdg", 3);
	        }
	        catch (Exception ex)
	        {
		        Console.WriteLine(ex.Message);
		      
	        }

	        Console.ReadLine();


        }
    }
}
