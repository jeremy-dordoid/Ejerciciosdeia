using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2_ia
{
    public class CLEstado
    {
        #region Campos
        private int[,] _tablero;
        private int _nivel;
        public CLEstado padre = null;
        #endregion

        #region Propiedades
        public int[,] tablero
        {
            get => _tablero;
            set => _tablero = value;
        }
        public int nivel
        {
            get => _nivel;
            set => _nivel = value;
        }
        #endregion

        #region Constructor
        public CLEstado()
        {
            this._tablero = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this._tablero[i, j] = 0;
        }

        public CLEstado(int p00, int p01, int p02,
                        int p10, int p11, int p12,
                        int p20, int p21, int p22)
        {
            this._tablero = new int[3, 3];
            this._tablero[0, 0] = p00;
            this._tablero[0, 1] = p01;
            this._tablero[0, 2] = p02;
            this._tablero[1, 0] = p10;
            this._tablero[1, 1] = p11;
            this._tablero[1, 2] = p12;
            this._tablero[2, 0] = p20;
            this._tablero[2, 1] = p21;
            this._tablero[2, 2] = p22;
            this._nivel = 0;
        }
        #endregion

        #region Métodos
        public List<CLEstado> GenerarHijos(List<CLEstado> Cerrados, List<CLEstado> Abiertos)
        {
            List<CLEstado> Respuesta = new List<CLEstado>();
            String pos0 = "";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] == 0)
                        pos0 = i.ToString() + j.ToString();

            CLEstado A;

            switch (pos0)
            {
                case "00":
                    A = new CLEstado(this._tablero[0, 1], this._tablero[0, 0], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[1, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[0, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "01":
                    A = new CLEstado(this._tablero[0, 1], this._tablero[0, 0], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 2], this._tablero[0, 1],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[1, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[0, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "02":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 2], this._tablero[0, 1],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[1, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[0, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "10":
                    A = new CLEstado(this._tablero[1, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[0, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 1], this._tablero[1, 0], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[2, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[1, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "11":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[1, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[0, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 1], this._tablero[1, 0], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 2], this._tablero[1, 1],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[2, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[1, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "12":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[1, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[0, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 2], this._tablero[1, 1],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[2, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[1, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "20":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[2, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[1, 0], this._tablero[2, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 1], this._tablero[2, 0], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "21":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 1], this._tablero[2, 0], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 2], this._tablero[2, 1]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[2, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[1, 1], this._tablero[2, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;

                case "22":
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[1, 2],
                                     this._tablero[2, 0], this._tablero[2, 2], this._tablero[2, 1]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0], this._tablero[0, 1], this._tablero[0, 2],
                                     this._tablero[1, 0], this._tablero[1, 1], this._tablero[2, 2],
                                     this._tablero[2, 0], this._tablero[2, 1], this._tablero[1, 2]);
                    A.padre = this; A.nivel = this.nivel + 1; Respuesta.Add(A);
                    break;
            }

            return TratarRepetidos(Respuesta, Cerrados, Abiertos);
        }

        public bool EsIgual(CLEstado otro)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] != otro._tablero[i, j])
                        return false;
            return true;
        }

        public static List<CLEstado> TratarRepetidos(List<CLEstado> Hijos, List<CLEstado> Cerrados, List<CLEstado> Abiertos)
        {
            List<CLEstado> Resultado = new List<CLEstado>();
            foreach (CLEstado hijo in Hijos)
            {
                bool estaEnCerrados = Cerrados.Any(c => c.EsIgual(hijo));
                bool estaEnAbiertos = Abiertos.Any(a => a.EsIgual(hijo));
                if (!estaEnCerrados && !estaEnAbiertos)
                    Resultado.Add(hijo);
            }
            return Resultado;
        }

        internal bool EsFinal()
        {
            int[,] meta = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] != meta[i, j])
                        return false;
            return true;
        }
        #endregion
    }
}