using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace prototipo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            ArduinoReader ar= new ArduinoReader();
            ar.inzio();
            do
            {
                Console.WriteLine("inserisci pipo");
                x=int.Parse(Console.ReadLine());
            } while (x != 2);
            ar.fine();
        }
    }
}
