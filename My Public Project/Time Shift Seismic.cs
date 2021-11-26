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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float ID, SD, RV, Timeshift;



            ID = float.Parse(textBox1.Text);
            SD = float.Parse(textBox2.Text);
            RV = float.Parse(textBox3.Text);


            Timeshift = (ID - SD) / RV * 2000;
            textBox4.Text = Timeshift.ToString();
        }
    }
}
