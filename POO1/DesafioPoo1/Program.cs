using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPoo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Telefono t1 = new Telefono("J7", "Samsung");

            t1.NumeroTelefonico = "2235299619";
            t1.CodigoOperador = 3;


            Console.WriteLine(t1.NumeroTelefonico);
            Console.WriteLine(t1.CodigoOperador);
            Console.WriteLine(t1.Llamar("Carlos"));
            Console.WriteLine(t1.ToString());
            Console.ReadKey();
        }
    }
}
