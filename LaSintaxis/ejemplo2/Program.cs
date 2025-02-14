using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Condicionales
            //IF
            //switch

            int a = 10;
            int b = 12;

            //operadores
            //== != > < >= <=
            // ! && ||

            for (int i = 0; i < 10; i++) {

                Console.WriteLine("Hola " + i);
                /*while (a != 0)
                {
                    Console.WriteLine("Hola " + i);
                    a--;
                    
                }
                a = 10;*/
                
            }

            Console.ReadKey();

            /* if(a==b)
             {
                 Console.WriteLine("Los numeros son iguales");
                 Console.ReadKey();
             } else {
                 Console.WriteLine("No son iguales");
                 Console.ReadKey();  
             }*/
        }
    }
}
