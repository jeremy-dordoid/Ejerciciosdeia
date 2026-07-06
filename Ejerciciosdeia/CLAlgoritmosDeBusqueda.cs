using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2_ia
{
    public static class CLAlgoritmosDeBusqueda
    {
        

        public static List<CLEstado> TratarRepetidos(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;
            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;
                foreach (var a in abiertos)
                {
                    if (hijo.EsIgual(a)) { encontrado = true; break; }
                }
                if (encontrado) continue;
                foreach (var c in cerrados)
                {
                    if (hijo.EsIgual(c)) { encontrado = true; break; }
                }
                if (!encontrado)
                    HijosDepurado.Add(hijo);
            }
            return HijosDepurado;
        }

        public static List<CLEstado> AEstrella(CLEstado Inicial)
        {
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();

            Abiertos.Add(Inicial);
            Actual = Abiertos[0];

            while (!Actual.EsFinal() && Abiertos.Count > 0)
            {
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);

                Hijos = Actual.GenerarHijos();
                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);

                foreach (CLEstado hijo in Hijos)
                    Abiertos.Add(hijo);

                // Ordenar por f(n) = g(n) + h(n) = nivel + H2
                Abiertos = Abiertos.OrderBy(e => e.nivel + e.h3).ToList();

                if (Abiertos.Count == 0) break;
                Actual = Abiertos[0];
            }

            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);
                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }
            }

            return Solucion;
        }
    }
}