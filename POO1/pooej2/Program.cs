using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Primer lote con 10 registros de productos, cada producto tiene:
            //  - Código Artículo (3 digitos no correlativos)
            //  - Precio
            //  - Código de Marca (1 a 10)
            //  Segundo lote con las ventas de la semana. Cada venta tiene:
            //  - Codigo Articulo
            //  - Cantidad
            //  - Codigo Cliente
            //  Este lote corta con Código de Cliente cero.

            Articulo[] articulos = new Articulo[3];

           

            for (int i = 0; i < 3; i++)
            {
                articulos[i] = new Articulo();
                Console.WriteLine("Ingrese los datos del producto N°" + i);
                Console.WriteLine("Codigo:");
                articulos[i].CodigoArticulo = int.Parse(Console.ReadLine());
                Console.WriteLine("Precio:");
                articulos[i].Precio = float.Parse(Console.ReadLine());
                Console.WriteLine("Marca (1 al 10)");
                articulos[i].CodigoMarca = int.Parse(Console.ReadLine());
            }

            for (int i = 0;i < 3; i++)
            {
                Console.WriteLine(articulos[i]);
            }

            Console.ReadKey();

        }
  
    }
}
