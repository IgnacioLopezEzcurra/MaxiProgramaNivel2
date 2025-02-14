using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            //int float bool char
            //double decimal, long, short, string, datetime
            int a, b, c;
            float d, e;

            a = 1;
            b = 2;
            c = a + b;

            Console.WriteLine("Hola Mundo" + " la suma de A + B es " + c);
            Console.WriteLine("Ingrese el valor de A");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("El valor ingresado es " + a);
            Console.ReadKey();
        }
    }
}
