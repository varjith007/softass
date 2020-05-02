using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.form1

namespace control_system_temparature
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private double button1_Click(object sender, EventArgs e)
        {
            double T_i = 8 ;
            double T_d = 1 ;
            double T_s = 0.5;
            double K_p = 2.94 ;
            double integralbuffer = 0;

            double setpoint = Convert.ToDouble(textBox1.Text);
            double processvariable = Form1.u;
            double error = setpoint - processvariable;
            double Controlsignal = K_p * error + (K_p / T_i) * integralbuffer;
            integralbuffer += T_s * error;
            return Controlsignal;
        }
    }
}
