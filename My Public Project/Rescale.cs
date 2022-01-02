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
    public partial class Form23 : Form
    {
        float old_min, old_max, new_min, new_max,m,c;        
        List<float> Oldlist = new List<float>();
        List<float> Newlist = new List<float>();        
        int counter = 0;       
        public Form23()
        {
            InitializeComponent();
            dataGridView1.Columns[0].HeaderText = "Old Values";
            dataGridView2.Columns[0].HeaderText = "New Values";
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            Oldlist.Clear();
            Newlist.Clear();
            dataGridView2.Rows.Clear();
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Oldlist.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));               
                counter++;
            }
            old_min = float.Parse(textBox5.Text);
            old_max = float.Parse(textBox1.Text);
            new_min = float.Parse(textBox3.Text);
            new_max = float.Parse(textBox2.Text);
            m = (new_max - new_min) / (old_max - old_min);            
            c = new_min;
            for (int i = 0; i < counter; i++)
            {
                float temp = (m * (Oldlist[i] - old_min)) + c;
                Newlist.Add(temp);
            }
            //textBox6.Text = M.ToString();
            for (int i = 0; i < counter; i++)
            {
                dataGridView2.Rows.Add(Newlist[i]);               
            }
        }
    }
}
