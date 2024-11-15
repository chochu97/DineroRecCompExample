using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo_Padre_Hijos
{
    class Program
    {
        static void Main(string[] args)
        {
            Padre padre = new Padre("Aldo");
            Thread thPadre = new Thread(padre.Run);
            thPadre.Start();

            Thread.Sleep(500);

            Hijo hijo1 = new Hijo("Johann");
            Hijo hijo2 = new Hijo("Ailen");

            Thread thHijo1 = new Thread(hijo1.Run);
            thHijo1.Start();
            Thread thHijo2 = new Thread(hijo2.Run);
            thHijo2.Start();

            Console.Read();
        }
    }
}
