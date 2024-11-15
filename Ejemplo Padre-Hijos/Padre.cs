using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo_Padre_Hijos
{
    class Padre
    {
        public string Nombre { get; set; }

        public Padre(string name)
        {
            this.Nombre = name;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"Soy el padre {Nombre} y voy a colaborar con mis hijos");

                Monitor.Enter(SharedResource.mutexPadreHijos); 

                try
                {
                    if (SharedResource.Dinero == 0)
                        SharedResource.Dinero = 10;

                    Monitor.Pulse(SharedResource.mutexPadreHijos);
                    Console.WriteLine($"Soy el padre {Nombre} y me quede esperando...");
                    Monitor.Wait(SharedResource.mutexPadreHijos);
                    Console.WriteLine($"Soy el padre {Nombre} y me comunican que estan necesitando dinero...");
                    Thread.Sleep(2000);


                }
                finally
                {
                    Monitor.Exit(SharedResource.mutexPadreHijos);
                }
            }
        }

    }
}
