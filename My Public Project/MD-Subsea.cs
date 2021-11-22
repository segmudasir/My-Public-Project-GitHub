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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float WE, MD, SS;

        private void button1_Click(object sender, EventArgs e)
        {
            WE = float.Parse(textBox5.Text);
            MD = float.Parse(textBox6.Text);


            SS = WE - MD;
            textBox7.Text = SS.ToString();
        }
    }
}
