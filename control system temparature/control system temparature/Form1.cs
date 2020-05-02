using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control_system_temparature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            /* textGain.Text = Convert.ToString(gain);
             textEnTemp.Text = Convert.ToString(time_constant);
             textTimeConstant.Text = Convert.ToString(t_env);
             textDelay.Text = Convert.ToString(time_delay);
             */



        }


        static class AirHeater
        {

            static public double gain = 2.5;
            static public double time_constant = 22;
            static public double time_delay = 3;
            static public double t_env = 22;
            static public double ControlSignal = 3.5;
            static public Queue<double> DelayedSignals;
            static public double dt = 0.1;
            static public double T;
            static public double u;


            static AirHeater()
            {

                DelayedSignals = new Queue<double>();
                for (double t = 0; t < time_delay; t += dt)
                    DelayedSignals.Enqueue(0);

            }

            static double calculatetemparature()
            {
                DelayedSignals.Enqueue(u);
                double delayed_signals = DelayedSignals.Dequeue();

                double DT_dt = (1 / time_constant) * ((t_env - T) + gain * time_delay);
                T += dt * DT_dt;
                return T;

            }
        }


        public double checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            double u;

            if (checkBox1.Checked == true)
            {

                u =
                trackBarSignal.AllowDrop = 'false';
                trackBarSignal.Value = Convert.ToInt32(u);
                return u;
            }
            else
            {
                u = u_man;
                return u;

            }

            


        }

        private void trackBarSignal_Scroll(object sender, EventArgs e)
        {
            double u_man;
            u_man = 0.1 * trackBarSignal.Value;
            label9.Text = Convert.ToString(u_man);

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.DataSource = T; 
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}


    
             
    
    

