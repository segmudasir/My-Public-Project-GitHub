using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Project
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        float AVG, SSBKB, GL, RV2, RV, TS;
                              
        private void button1_Click(object sender, EventArgs e)
        {     
            AVG = float.Parse(textBox1.Text);
            SSBKB = float.Parse(textBox2.Text);
            GL = float.Parse(textBox3.Text);                  
            RV2 = (1/AVG) * 1000000;
            // Taking 70 of velocities to match with Seismic velocities.
            RV = (RV2 * 70) / 100;
            textBox4.Text = RV.ToString();
            TS = (SSBKB - GL) / RV * 2000;
            textBox5.Text = TS.ToString();                
        }

            
    }
}
