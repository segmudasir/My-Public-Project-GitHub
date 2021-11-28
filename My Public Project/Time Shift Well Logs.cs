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
            dataGridView1.Columns[0].HeaderText = "Depth";
            dataGridView1.Columns[1].HeaderText = "DT";
        }

        float DT_Sum, AVG, Start_Sonic, WE, Check_shot_Datum, RV2, RV, Timeshift;
        string labeltext;
        int counter;
        List<float> Depth = new List<float>();
        List<float> DT = new List<float>();
        ///////////////////////////////Copy and Paste from Clip board///////////////////////////////////////////////
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                //split it into lines
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                //get the row and column of selected cell in grid
                int r = dataGridView1.SelectedCells[0].RowIndex;
                int c = dataGridView1.SelectedCells[0].ColumnIndex;
                //add rows into grid to fit clipboard lines
                if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))
                {
                    dataGridView1.Rows.Add(r + rowsInClipboard.Length - dataGridView1.Rows.Count + 1);
                }
                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    //split row into cell values
                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    //cycle through cell values
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        //assign cell value, only if it within columns of the grid
                        if (dataGridView1.ColumnCount - 1 >= c + iCol)
                        {
                            dataGridView1.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                        }
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////// 
                              
        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            DT_Sum = 0;
            Depth.Clear();
            DT.Clear();  
            labeltext = string.Empty;
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Depth.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));
                DT.Add(float.Parse((dataGridView1.Rows[counter].Cells[1].Value).ToString()));
                counter++;
            }
            textBox6.Text = counter.ToString();
            if(counter>=100)
            {
                for (int i=0; i<100; i++)
                {
                    DT_Sum = DT_Sum + DT[i];
                }

                AVG = DT_Sum / 100;
                labeltext = "AVG of 1st 100 Samples of DT =";
                label14.Text = labeltext;
                textBox1.Text = AVG.ToString();
                textBox7.Text = "100";
            }
            else
            {
                for (int i = 0; i < counter; i++)
                {
                    DT_Sum = DT_Sum + DT[i];
                }
                AVG = DT_Sum / counter;
                labeltext = "AVG of 1st "+ counter +" Samples of DT =";
                label14.Text = labeltext;
                textBox1.Text = AVG.ToString();
                textBox7.Text = counter.ToString();
            }
            Start_Sonic = Depth[0];
            textBox2.Text = Start_Sonic.ToString();
            WE = float.Parse(textBox3.Text);
            Check_shot_Datum = float.Parse(textBox8.Text);
            RV2 = (1 / AVG) * 1000000;
            // Taking 70 of velocities to match with Seismic velocities.
            RV = (RV2 * 70) / 100;                      
            textBox4.Text = RV.ToString();
            Timeshift = (Start_Sonic - WE + Check_shot_Datum) / RV * 2000;
            textBox5.Text = Timeshift.ToString();                
        }

            
    }
}
