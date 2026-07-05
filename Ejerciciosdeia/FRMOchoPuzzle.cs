using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_2_ia
{
    public partial class FRMOchoPuzzle : Form
    {
        private int contador = 0;
        private List<CLEstado> _solucion = new List<CLEstado>();
        private int _pasoSolucion = 0;
        private Timer _timerSolucion;
        private Random _rnd = new Random();

        public FRMOchoPuzzle()
        {
            InitializeComponent();
            _timerSolucion = new Timer();
            _timerSolucion.Interval = 500;
            _timerSolucion.Tick += new EventHandler(TimerSolucion_Tick);
            foreach (Label celda in ObtenerTablero())
                celda.Click += Celda_Click;
        }

        // Matriz 4x4 con los labels en su posicion real dentro de la cuadricula.
        // La ultima fila esta nombrada al reves (label7 es la esquina izquierda).
        private Label[,] ObtenerTablero()
        {
            return new Label[4, 4]
            {
                { LBL07,  LBL01,  LBL02,  label1 },
                { LBL10,  LBL11,  LBL12,  label2 },
                { LBL20,  LBL21,  LBL22,  label3 },
                { label7, label6, label5, label4 }
            };
        }

        private void Celda_Click(object sender, EventArgs e)
        {
            Label celda = (Label)sender;
            Label[,] labels = ObtenerTablero();

            // Buscar la posicion de la celda clickeada
            int fi = 0, fj = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (labels[i, j] == celda)
                    { fi = i; fj = j; }

            // Si algun vecino es el 0, intercambiar
            int[,] dirs = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            for (int d = 0; d < 4; d++)
            {
                int ni = fi + dirs[d, 0];
                int nj = fj + dirs[d, 1];
                if (ni >= 0 && ni < 4 && nj >= 0 && nj < 4 && labels[ni, nj].Text == "0")
                {
                    labels[ni, nj].Text = celda.Text;
                    celda.Text = "0";
                    break;
                }
            }
        }

        private void BTNOrdenar_Click(object sender, EventArgs e)
        {
            Label[,] labels = ObtenerTablero();
            int valor = 1;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    labels[i, j].Text = (valor == 16) ? "0" : valor.ToString();
                    valor++;
                }
        }

        private void BTNDesordenar_Click(object sender, EventArgs e)

        {

            contador = 0;
            TMRRelog.Interval = 1; 
            TMRRelog.Enabled = true;

        }

        private void TMRRelog_Tick(object sender, EventArgs e)
        {
            if (contador <= 50)
            {
                contador++;
                LBLContador.Text = contador.ToString();

                // Cargar tablero en matriz
                Label[,] labels = ObtenerTablero();

                // Encontrar el 0
                int fi = 0, fj = 0;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (labels[i, j].Text == "0")
                        { fi = i; fj = j; }

                // Direcciones posibles: arriba, abajo, izquierda, derecha
                int[,] dirs = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

                // Filtrar solo movimientos válidos dentro del tablero
                List<int[]> movValidos = new List<int[]>();
                for (int d = 0; d < 4; d++)
                {
                    int ni = fi + dirs[d, 0];
                    int nj = fj + dirs[d, 1];
                    if (ni >= 0 && ni < 4 && nj >= 0 && nj < 4)
                        movValidos.Add(new int[] { ni, nj });
                }

                // Elegir movimiento aleatorio válido e intercambiar
                int[] mov = movValidos[_rnd.Next(movValidos.Count)];
                labels[fi, fj].Text = labels[mov[0], mov[1]].Text;
                labels[mov[0], mov[1]].Text = "0";
            }
            else
            {
                TMRRelog.Enabled = false;
                MessageBox.Show("Reloj apagado");
                LBLContador.Text = "";
                contador = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            List<CLEstado> Hijos = Inicial.GenerarHijos();
            FRMHijos A = new FRMHijos();
            A.Hijos = Hijos;
            A.ShowDialog();

        }

        private void LBLContador_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            if (Inicial.EsFinal())
            {
                MessageBox.Show("Es estado final");
            }
            else
            {
                MessageBox.Show("No es el estado final");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            List<CLEstado> Solucion = CLAlgoritmosDeBusqueda.AnchuraPrioritaria(Inicial);

            MessageBox.Show("Pasos encontrados: " + Solucion.Count);

            if (Solucion.Count == 0)
            {
                MessageBox.Show("No se encontro solucion.");
                return;
            }



            Solucion.Reverse();
            _solucion = Solucion;
            _pasoSolucion = 0;
            _timerSolucion.Start();
        }

        private void TimerSolucion_Tick(object sender, EventArgs e)
        {
            if (_pasoSolucion >= _solucion.Count)
            {
                _timerSolucion.Stop();
                MessageBox.Show("Puzzle resuelto!");
                return;
            }

            CLEstado paso = _solucion[_pasoSolucion];
            Label[,] labels = ObtenerTablero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    labels[i, j].Text = paso.tablero[i, j].ToString();

            _pasoSolucion++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            int limite = (int)numericUpDown1.Value;

            List<CLEstado> Solucion = CLAlgoritmosDeBusqueda.ProfundidadLimitada(Inicial, limite);

            if (Solucion.Count == 0)
            {
                MessageBox.Show("No se encontró solución con límite: " + limite);
                return;
            }

            MessageBox.Show("Resolviendo ");

            _solucion = Solucion;
            _pasoSolucion = 0;
            _timerSolucion.Start();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            int limite = (int)numericUpDown2.Value;

            List<CLEstado> Solucion = CLAlgoritmosDeBusqueda.ProfundidadIterativa(Inicial, limite);

            if (Solucion.Count == 0)
            {
                MessageBox.Show("No se encontró solución con límite: " + limite);
                return;
            }

            MessageBox.Show("Pasos encontrados: " + (Solucion.Count - 2));

            _solucion = Solucion;
            _pasoSolucion = 0;
            _timerSolucion.Start();
        }

        // Lee las 16 celdas de la pantalla y arma el estado 4x4
        private CLEstado ObtenerEstadoActual()
        {
            Label[,] labels = ObtenerTablero();
            int[,] valores = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    valores[i, j] = Convert.ToInt32(labels[i, j].Text);
            return new CLEstado(valores);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CLEstado estado = ObtenerEstadoActual();
            MessageBox.Show("H1 (fichas mal colocadas) = " + estado.H1());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CLEstado estado = ObtenerEstadoActual();
            MessageBox.Show("H2 (distancia Manhattan) = " + estado.H2());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CLEstado estado = ObtenerEstadoActual();
            MessageBox.Show("H3 (Manhattan + penalización) = " + estado.h3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CLEstado Inicial = ObtenerEstadoActual();

            List<CLEstado> Solucion = CLAlgoritmosDeBusqueda.AEstrella(Inicial);

            if (Solucion.Count == 0)
            {
                MessageBox.Show("No se encontró solución.");
                return;
            }

            MessageBox.Show("A* con H3 - Pasos encontrados: " + Solucion.Count);

            Solucion.Reverse();
            _solucion = Solucion;
            _pasoSolucion = 0;
            _timerSolucion.Start();
        }

        private void LBL21_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
