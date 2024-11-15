using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo_Padre_Hijos
{
    class Hijo
    {
        public string Nombre { get; set; }

        public static object mutexHijo = new object();

        public Hijo(string name)
        {
            this.Nombre = name;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"Soy el hijo {Nombre} y quiero obtener dinero...");

                Monitor.Enter(mutexHijo); 
                //Codigo critico
                try
                {
                    Console.WriteLine($"Soy el hijo {Nombre} y estoy extrayendo dinero. $1. " +
                        $"Saldo: {SharedResource.Dinero}");

                    SharedResource.Dinero--;

                    if (SharedResource.Dinero == 0)
                    {
                        Console.WriteLine($"Soy el hijo {Nombre} y nos quedamos sin dinero");
                        Monitor.Enter(SharedResource.mutexPadreHijos);
                        try
                        {
                            Monitor.Pulse(SharedResource.mutexPadreHijos);
                            Monitor.Wait(SharedResource.mutexPadreHijos);
                        }
                        finally
                        {
                            Monitor.Exit(SharedResource.mutexPadreHijos);
                        }

                    }

                }
                finally
                {
                    Monitor.Exit(mutexHijo);
                } 
            }
        }
    }
}
