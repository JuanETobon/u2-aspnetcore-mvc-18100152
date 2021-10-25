using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU2.Models
{
    public static class Datos
    {
        private static List<Mascota> objetos = new List<Mascota>();

        public static IEnumerable<Mascota> Objetos => objetos;

        public static void AgregarObjeto(Mascota miMascota)
        {
            objetos.Add(miMascota);
        }

        public static void EliminarObjeto(Mascota miMascota)
        {
            objetos.Remove(miMascota);
        }
    }
}
