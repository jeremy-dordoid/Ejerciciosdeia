using Ejerciciosdeia;
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
        public FRMOchoPuzzle()
        {
            InitializeComponent();
        }

        private void LBL00_Click(object sender, EventArgs e)
        {
            if (LBL10.Text == "0")
            {
                LBL10.Text = LBL07.Text;
                LBL07.Text = "0";
            }
            else if (LBL01.Text == "0")
            {
                LBL01.Text = LBL07.Text;
                LBL07.Text = "0";
            }
        }

        private void LBL10_Click(object sender, EventArgs e)
        {
            if (LBL07.Text == "0")
            {
                LBL07.Text = LBL10.Text;
                LBL10.Text = "0";
            }
            else if (LBL11.Text == "0")
            {
                LBL11.Text = LBL10.Text;
                LBL10.Text = "0";
            }
            else if (LBL20.Text == "0")
            {
                LBL20.Text = LBL10.Text;
                LBL10.Text = "0";
            }
        }

        private void LBL20_Click(object sender, EventArgs e)
        {
            if (LBL10.Text == "0")
            {
                LBL10.Text = LBL20.Text;
                LBL20.Text = "0";
            }
            else if (LBL21.Text == "0")
            {
                LBL21.Text = LBL20.Text;
                LBL20.Text = "0";
            }
        }

        private void LBL01_Click(object sender, EventArgs e)
        {
            if (LBL07.Text == "0")
            {
                LBL07.Text = LBL01.Text;
                LBL01.Text = "0";
            }
            else if (LBL11.Text == "0")
            {
                LBL11.Text = LBL01.Text;
                LBL01.Text = "0";
            }
            else if (LBL02.Text == "0")
            {
                LBL02.Text = LBL01.Text;
                LBL01.Text = "0";
            }
        }

        private void LBL02_Click(object sender, EventArgs e)
        {
            if (LBL01.Text == "0")
            {
                LBL01.Text = LBL02.Text;
                LBL02.Text = "0";
            }
            else if (LBL12.Text == "0")
            {
                LBL12.Text = LBL02.Text;
                LBL02.Text = "0";
            }
        }

        private void LBL11_Click(object sender, EventArgs e)
        {
            if (LBL01.Text == "0")
            {
                LBL01.Text = LBL11.Text;
                LBL11.Text = "0";
            }
            else if (LBL10.Text == "0")
            {
                LBL10.Text = LBL11.Text;
                LBL11.Text = "0";
            }
            else if (LBL21.Text == "0")
            {
                LBL21.Text = LBL11.Text;
                LBL11.Text = "0";
            }
            else if (LBL12.Text == "0")
            {
                LBL12.Text = LBL11.Text;
                LBL11.Text = "0";
            }
        }

        private void LBL12_Click(object sender, EventArgs e)
        {
            if (LBL11.Text == "0")
            {
                LBL11.Text = LBL12.Text;
                LBL12.Text = "0";
            }
            else if (LBL22.Text == "0")
            {
                LBL22.Text = LBL12.Text;
                LBL12.Text = "0";
            }
            else if (LBL02.Text == "0")
            {
                LBL02.Text = LBL12.Text;
                LBL12.Text = "0";
            }
        }

        private void LBL21_Click(object sender, EventArgs e)
        {
            if (LBL11.Text == "0")
            {
                LBL11.Text = LBL21.Text;
                LBL21.Text = "0";
            }
            else if (LBL20.Text == "0")
            {
                LBL20.Text = LBL21.Text;
                LBL21.Text = "0";
            }
            else if (LBL22.Text == "0")
            {
                LBL22.Text = LBL21.Text;
                LBL21.Text = "0";
            }
        }

        private void LBL22_Click(object sender, EventArgs e)
        {
            if (LBL21.Text == "0")
            {
                LBL21.Text = LBL22.Text;
                LBL22.Text = "0";
            }
            else if (LBL12.Text == "0")
            {
                LBL12.Text = LBL22.Text;
                LBL22.Text = "0";
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
            if (contador < 50)
            {
                contador++;
                LBLContador.Text = contador.ToString();

                // Cargar tablero en matriz
                string[,] tablero = new string[3, 3];
                Label[,] labels = new Label[3, 3]
                {
            { LBL07, LBL01, LBL02 },
            { LBL10, LBL11, LBL12 },
            { LBL20, LBL21, LBL22 }
                };

                // Encontrar el 0
                int fi = 0, fj = 0;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
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
                    if (ni >= 0 && ni < 3 && nj >= 0 && nj < 3)
                        movValidos.Add(new int[] { ni, nj });
                }

                // Elegir movimiento aleatorio válido e intercambiar
                Random rnd = new Random();
                int[] mov = movValidos[rnd.Next(movValidos.Count)];
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
            CLEstado Inicial = new CLEstado(
       Convert.ToInt32(LBL07.Text),
       Convert.ToInt32(LBL01.Text),
       Convert.ToInt32(LBL02.Text),
       Convert.ToInt32(LBL10.Text),
       Convert.ToInt32(LBL11.Text),
       Convert.ToInt32(LBL12.Text),
       Convert.ToInt32(LBL20.Text),
       Convert.ToInt32(LBL21.Text),
       Convert.ToInt32(LBL22.Text)
                                 );

            List<CLEstado> Hijos = Inicial.GenerarHijos(new List<CLEstado>(), new List<CLEstado>());
            FRMHijos A = new FRMHijos();
            A.Hijos = Hijos;
            A.ShowDialog();

        }

        private void LBLContador_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CLEstado Estado = new CLEstado();
            CLEstado Inicial = new CLEstado(Convert.ToInt32(LBL07.Text),
                                            Convert.ToInt32(LBL01.Text),
                                            Convert.ToInt32(LBL02.Text),
                                            Convert.ToInt32(LBL10.Text),
                                            Convert.ToInt32(LBL11.Text),
                                            Convert.ToInt32(LBL12.Text),
                                            Convert.ToInt32(LBL20.Text),
                                            Convert.ToInt32(LBL21.Text),
                                            Convert.ToInt32(LBL22.Text)
                                            );

            if (Inicial.EsFinal())
            {
                MessageBox.Show("Es estado final");
            }
            else
            {
                MessageBox.Show("No es el estado final");
            }
        }
    }
}
