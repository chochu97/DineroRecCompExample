using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Padre_Hijos
{
    class SharedResource
    {
        public static decimal Dinero { get; set; }

        public static object mutexPadreHijos = new object();
    }
}
