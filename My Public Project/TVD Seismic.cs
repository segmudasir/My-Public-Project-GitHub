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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        float SD, WE, MD, TVDS;

        private void button1_Click(object sender, EventArgs e)
        {
            SD = float.Parse(textBox1.Text);
            WE = float.Parse(textBox2.Text);
            MD = float.Parse(textBox3.Text);


            TVDS = SD - WE + MD;
            textBox4.Text = TVDS.ToString();
        }
    }
}
