using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2018;
namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            

            Changuito changoDeCompras = new Changuito(6);

            Dulce c1 = new Dulce(Producto.MarcaProducto.Sancor, "ASD012", ConsoleColor.Black);
            Dulce c2 = new Dulce(Producto.MarcaProducto.Ilolay, "ASD913", ConsoleColor.Red);
            Leche m1 = new Leche(Producto.MarcaProducto.Pepsico, "HJK789", ConsoleColor.White);
            Leche m2 = new Leche(Producto.MarcaProducto.Serenisima, "IOP852", ConsoleColor.Blue, Leche.TipoLeche.Descremada);
            Snacks a1 = new Snacks(Producto.MarcaProducto.Campagnola, "QWE968", ConsoleColor.Gray);
            Snacks a2 = new Snacks(Producto.MarcaProducto.Arcor, "TYU426", ConsoleColor.DarkBlue);
            Snacks a3 = new Snacks(Producto.MarcaProducto.Sancor, "IOP852", ConsoleColor.Green);
            Snacks a4 = new Snacks(Producto.MarcaProducto.Sancor, "TRE321", ConsoleColor.Green);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el m1 repetido) y muestro
            changoDeCompras += c1;
            changoDeCompras += c2;
            changoDeCompras += m1;
            changoDeCompras += m1;
            changoDeCompras += m2;
            changoDeCompras += a1;
            changoDeCompras += a2;
            changoDeCompras += a3;
            changoDeCompras += a4;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= c1;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.TipoProducto.Dulce));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Leches
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.TipoProducto.Leche));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.TipoProducto.Snacks));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
        }
    }
}
