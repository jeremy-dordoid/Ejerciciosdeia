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
                LBL10.Text = LBL00.Text;
                LBL00.Text = "0";
            }
            else if (LBL01.Text == "0")
            {
                LBL01.Text = LBL00.Text;
                LBL00.Text = "0";
            }
        }

        private void LBL10_Click(object sender, EventArgs e)
        {
            if (LBL00.Text == "0")
            {
                LBL00.Text = LBL10.Text;
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
            if (LBL00.Text == "0")
            {
                LBL00.Text = LBL01.Text;
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
            
            List<string> valores = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "0" };

           
            Random rnd = new Random();
            valores = valores.OrderBy(x => rnd.Next()).ToList();

  
            LBL00.Text = valores[0];
            LBL01.Text = valores[1];
            LBL02.Text = valores[2];
            LBL10.Text = valores[3];
            LBL11.Text = valores[4];
            LBL12.Text = valores[5];
            LBL20.Text = valores[6];
            LBL21.Text = valores[7];
            LBL22.Text = valores[8];
        }

        private void TMRRelog_Tick(object sender, EventArgs e)
        {
            if (contador < 10)
            {
                contador++;
                LBLContador.Text = contador.ToString();

            }
            else
            {
                TMRRelog.Enabled = false;
                MessageBox.Show("Reloj APAGADO");
                LBLContador.Text = "";
                contador = 0;
            }
        }
    }
}
