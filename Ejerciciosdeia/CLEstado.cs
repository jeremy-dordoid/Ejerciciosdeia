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
        private CLEstado _padre;
        private int _h3;
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
        public int h3
        {
            get => _h3;
            set => _h3 = value;
        }
        public CLEstado padre
        {
            get => _padre;
            set => _padre = value;
        }
        #endregion
        #region Constructor
        public CLEstado()
        {
            this._tablero = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this._tablero[i, j] = 0;
            this._nivel = 0;
            this._padre = null;
        }
        public CLEstado(int[,] valores)
        {
            this._tablero = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this._tablero[i, j] = valores[i, j];
            this._nivel = 0;
            this._padre = null;
            this._h3 = H3();
        }
        #endregion
        #region Métodos
        // Crea un hijo copiando el tablero y moviendo la ficha (filaFicha, colFicha)
        // al hueco (fila0, col0). El 0 queda donde estaba la ficha.
        private CLEstado CrearHijo(int fila0, int col0, int filaFicha, int colFicha)
        {
            int[,] nuevo = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    nuevo[i, j] = this._tablero[i, j];
            nuevo[fila0, col0] = nuevo[filaFicha, colFicha];
            nuevo[filaFicha, colFicha] = 0;
            CLEstado hijo = new CLEstado(nuevo);
            hijo.nivel = this.nivel + 1;
            hijo.padre = this;
            return hijo;
        }
        public List<CLEstado> GenerarHijos()
        {
            List<CLEstado> Respuesta = new List<CLEstado>();
            String pos0 = "";
            int f = 0, c = 0;

            //busca donde anda el 0 pq sin el no asemos nada xd
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (this._tablero[i, j] == 0)
                    {
                        pos0 = i.ToString() + j.ToString();
                        f = i;
                        c = j;
                    }

            switch (pos0)
            {
                // ----- Fila 0 -----

                case "00":
                    /*
                     [*] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     solo puede ir derecha o abajo
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 1));
                    Respuesta.Add(CrearHijo(f, c, 1, 0));
                    break;

                case "01":
                    /*
                     [ ] [*] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     izq der y abajo nomas
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 0));
                    Respuesta.Add(CrearHijo(f, c, 0, 2));
                    Respuesta.Add(CrearHijo(f, c, 1, 1));
                    break;

                case "02":
                    /*
                     [ ] [ ] [*] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     igual q el otro pero un cuadrito mas
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 1));
                    Respuesta.Add(CrearHijo(f, c, 0, 3));
                    Respuesta.Add(CrearHijo(f, c, 1, 2));
                    break;

                case "03":
                    /*
                     [ ] [ ] [ ] [*]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     eskinita xd
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 2));
                    Respuesta.Add(CrearHijo(f, c, 1, 3));
                    break;

                // ----- Fila 1 -----

                case "10":
                    /*
                     [ ] [ ] [ ] [ ]
                     [*] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     arriba der abajo
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 0));
                    Respuesta.Add(CrearHijo(f, c, 1, 1));
                    Respuesta.Add(CrearHijo(f, c, 2, 0));
                    break;

                case "11":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [*] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]

                     el centro ya tiene todos los movimientos
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 1));
                    Respuesta.Add(CrearHijo(f, c, 1, 0));
                    Respuesta.Add(CrearHijo(f, c, 1, 2));
                    Respuesta.Add(CrearHijo(f, c, 2, 1));
                    break;

                case "12":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [*] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 2));
                    Respuesta.Add(CrearHijo(f, c, 1, 1));
                    Respuesta.Add(CrearHijo(f, c, 1, 3));
                    Respuesta.Add(CrearHijo(f, c, 2, 2));
                    break;

                case "13":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [*]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 0, 3));
                    Respuesta.Add(CrearHijo(f, c, 1, 2));
                    Respuesta.Add(CrearHijo(f, c, 2, 3));
                    break;

                // ----- Fila 2 -----

                case "20":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [*] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 1, 0));
                    Respuesta.Add(CrearHijo(f, c, 2, 1));
                    Respuesta.Add(CrearHijo(f, c, 3, 0));
                    break;

                case "21":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [*] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 1, 1));
                    Respuesta.Add(CrearHijo(f, c, 2, 0));
                    Respuesta.Add(CrearHijo(f, c, 2, 2));
                    Respuesta.Add(CrearHijo(f, c, 3, 1));
                    break;

                case "22":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [*] [ ]
                     [ ] [ ] [ ] [ ]

                     aki me falle una ves por un case jajsj
                    */
                    Respuesta.Add(CrearHijo(f, c, 1, 2));
                    Respuesta.Add(CrearHijo(f, c, 2, 1));
                    Respuesta.Add(CrearHijo(f, c, 2, 3));
                    Respuesta.Add(CrearHijo(f, c, 3, 2));
                    break;

                case "23":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [*]
                     [ ] [ ] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 1, 3));
                    Respuesta.Add(CrearHijo(f, c, 2, 2));
                    Respuesta.Add(CrearHijo(f, c, 3, 3));
                    break;

                // ----- Fila 3 -----

                case "30":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [*] [ ] [ ] [ ]

                     eskina de abajo
                    */
                    Respuesta.Add(CrearHijo(f, c, 2, 0));
                    Respuesta.Add(CrearHijo(f, c, 3, 1));
                    break;

                case "31":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [*] [ ] [ ]
                    */
                    Respuesta.Add(CrearHijo(f, c, 2, 1));
                    Respuesta.Add(CrearHijo(f, c, 3, 0));
                    Respuesta.Add(CrearHijo(f, c, 3, 2));
                    break;

                case "32":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [*] [ ]

                     casi al final juas juas
                    */
                    Respuesta.Add(CrearHijo(f, c, 2, 2));
                    Respuesta.Add(CrearHijo(f, c, 3, 1));
                    Respuesta.Add(CrearHijo(f, c, 3, 3));
                    break;

                case "33":
                    /*
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [ ]
                     [ ] [ ] [ ] [*]

                     solo arriba o izq pq ya no ai mas mundo xd
                    */
                    Respuesta.Add(CrearHijo(f, c, 2, 3));
                    Respuesta.Add(CrearHijo(f, c, 3, 2));
                    break;
            }

            return Respuesta;
        }
        public int H1()
        {
            int piezasFueraDeLugar = 0;
            int[,] estadoMeta =
            {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15,  0 }  
            };
            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 4; columna++)
                {
                    if (_tablero[fila, columna] != 0 &&
                        _tablero[fila, columna] != estadoMeta[fila, columna])
                    {
                        piezasFueraDeLugar++;
                    }
                }
            }
            return piezasFueraDeLugar;
        }

        public int H2()
        {
            int distanciaTotal = 0;
            for (int fila = 0; fila < 4; fila++)
            {
                for (int columna = 0; columna < 4; columna++)
                {
                    int valor = _tablero[fila, columna];
                    if (valor == 0) continue;
                    
                    int filaMeta = (valor - 1) / 4;
                    int columnaMeta = (valor - 1) % 4;
                    distanciaTotal += Math.Abs(fila - filaMeta) + Math.Abs(columna - columnaMeta);
                }
            }
            return distanciaTotal;
        }

        private int H3()
        {
            if (EsFinal()) return 0;
            // Borde del tablero en sentido horario 12 casillas en el 4x4 en este caso como era en el 3x3 xd 
            //nota 2 de jere en este caso no cuenta los del medio porque funciona de otra manera
            int[] borde =
            {
                _tablero[0, 0], _tablero[0, 1], _tablero[0, 2], _tablero[0, 3],
                _tablero[1, 3], _tablero[2, 3], _tablero[3, 3], _tablero[3, 2],
                _tablero[3, 1], _tablero[3, 0], _tablero[2, 0], _tablero[1, 0]
            };
            // El mismo borde pero en el estado meta, para saber el sucesor correcto asi que xd
            int[] bordeMeta = { 1, 2, 3, 4, 8, 12, 0, 15, 14, 13, 9, 5 };
            int sumaS = 0;
            for (int i = 0; i < 12; i++)
            {
                int actual = borde[i];
                if (actual == 0) continue;
                int siguiente = borde[(i + 1) % 12];
                // se busca el sucesor correcto de "actual" segun el borde metaaaaaaaaaaaaaaa
                int sucesorCorrecto = 0;
                for (int k = 0; k < 12; k++)
                    if (bordeMeta[k] == actual)
                        sucesorCorrecto = bordeMeta[(k + 1) % 12];
                if (siguiente != sucesorCorrecto)
                    sumaS += 2;
            }
            // Penalizar si al final no estacd
            if (_tablero[3, 3] != 0)
                sumaS += 1;
            return H2() + (3 * sumaS);
        }

        public bool EsFinal()
        {
            int esperado = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // La ultima casilla debe ser 0, el resto 1..15 en orden
                    if (esperado == 16)
                    {
                        if (_tablero[i, j] != 0) return false;
                    }
                    else if (_tablero[i, j] != esperado)
                    {
                        return false;
                    }
                    esperado++;
                }
            }
            return true;
        }
        public bool EsIgual(CLEstado a)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a.tablero[i, j] != this.tablero[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
