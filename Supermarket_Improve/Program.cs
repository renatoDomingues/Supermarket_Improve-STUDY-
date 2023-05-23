using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Improve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("= SuPeRmArKeT = DOMINGUES = SuPeRmArKeT =");
            Console.WriteLine("\r\a");

            /* MAIN */



            //Object,Instance
            DataBaseDB dataBaseDB = new DataBaseDB();
            InterfaceProducts ourProductsRegister = new InterfaceProducts(dataBaseDB);



            //Call Methods
            ourProductsRegister.StartInterface();



            //Finish
            Console.WriteLine("\r\a");
            Console.WriteLine("= SuPeRmArKeT = DOMINGUES = SuPeRmArKeT =");
            Console.WriteLine("\r\a");
            Console.WriteLine("Press any key to exit ...");
            Console.WriteLine("\r\a");
            Console.ReadKey();
        }
    }
}
