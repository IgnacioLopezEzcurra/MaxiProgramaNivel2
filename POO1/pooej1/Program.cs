using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Persona: edad, sueldo, nombre
            

            Persona p1 = new Persona();

           /* p1.setEdad(20);

            Console.WriteLine("La edad de p1 es " + p1.getEdad());*/

            p1.Edad = 15;


            Console.WriteLine("La edad de p1 es " + p1.Edad);
            Console.ReadKey();


        }
    }
}
