using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea_2_ia;

namespace Tarea_2_ia
{
    public partial class FRMHijos : Form
    {
        #region Variables

        public List<CLEstado>Hijos = new List<CLEstado>();
        private int apuntador = 0;

        #endregion
        #region Constructor
        public FRMHijos()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void FRMHijos_Load(object sender, EventArgs e)
        {
            if (Hijos.Count > 0)
            {
                apuntador = 0;
                TrasladarEstadoATablero(apuntador);
            }
            else
            {
                MessageBox.Show("Sin hijos");
            }
        }

        #endregion

        #region Métodos
        // Matriz 4x4 con los labels en su posicion real dentro de la cuadricula.
        // La columna derecha y la ultima fila estan nombradas al reves.
        private Label[,] ObtenerTablero()
        {
            return new Label[4, 4]
            {
                { LBL00,  LBL01,  LBL02,  label3 },
                { LBL10,  LBL11,  LBL12,  label2 },
                { LBL20,  LBL21,  LBL22,  label1 },
                { label7, label6, label5, label4 }
            };
        }

        private void TrasladarEstadoATablero(int apuntador)
        {
            Label[,] labels = ObtenerTablero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    labels[i, j].Text = Hijos[apuntador].tablero[i, j].ToString();
            LBLHijo.Text = "Hijo " + (apuntador + 1).ToString();
        }
        #endregion

        private void BTNDerecha_Click(object sender, EventArgs e)
        {
            if ((Hijos.Count-1) > apuntador)
            {
                apuntador++;
                TrasladarEstadoATablero(apuntador);
            }
        }

        private void BTNIzquierda_Click(object sender, EventArgs e)
        {
            if (apuntador>0)
            {
                apuntador--;
                TrasladarEstadoATablero(apuntador);
            }
        }

        private void LBL00_Click(object sender, EventArgs e)
        {

        }

        private void LBL01_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
