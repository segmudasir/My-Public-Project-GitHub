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
    public partial class Form6 : Form
    {
        float T1, T2, D1, D2, RT, Y, M, X, C;
        String Label1;
        String Label2;
        float[] Array1 = new float[10];
        float[] Array2 = new float[10];
        List<float> Time = new List<float>();       
        List<float> Depth = new List<float>(); 
        int counter = 0;       
        public Form6()
        {           
            InitializeComponent();                     
            dataGridView1.Columns[0].HeaderText = "Label 1";
            dataGridView1.Columns[1].HeaderText = "Label 2";                       
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////     
   
    //////////////////////////////////Interpolation Calculation Function/////////////////////////////////////////////////
    public float CalculateInterpolation(float time)
    {
        RT = time;
                                                                               
                for (int i = 0; i < counter-1; i++)
                {
                    if (RT >= Time[i] && RT < Time[i+1])
                    {
                        T1 = Time[i];                       
                        T2 = Time[i + 1];
                        D1 = Depth[i];                        
                        D2 = Depth[i + 1];                       
                        textBox2.Text = T1.ToString();
                        textBox3.Text = T2.ToString();
                        textBox9.Text = D1.ToString();
                        textBox4.Text = D2.ToString();
                        M = (D2 - D1) / (T2 - T1);
                        X = RT - T1;
                        C = D1;
                        Y = (M * X) + C;
                        textBox6.Text = M.ToString();
                        textBox7.Text = X.ToString();
                        textBox1.Text = C.ToString();
                        textBox16.Text = Y.ToString(); 
                        break;
                    }
                }
                if (RT >= Time[counter-1])
                {                    
                    T1 = Time[counter - 2];
                    T2 = Time[counter - 1];
                    D1 = Depth[counter - 2];
                    D2 = Depth[counter - 1];
                   
                    textBox2.Text = T1.ToString();
                    textBox3.Text = T2.ToString();
                    textBox9.Text = D1.ToString();
                    textBox4.Text = D2.ToString();
                    M = (D2 - D1) / (T2 - T1);               
                    X = RT - T1;
                    C = D1;
                    Y = (M * X) + C;
                    textBox6.Text = M.ToString();
                    textBox7.Text = X.ToString();                   
                    textBox1.Text = C.ToString();
                    textBox16.Text = Y.ToString();                  
                }                                   
            return Y;
    }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////// 

    


    private void button1_Click(object sender, EventArgs e)
    {
        counter = 0;      
        RT = float.Parse(textBox5.Text);          
            while (Time.Count > 0)
            {
                Time.RemoveAt(0);
                Depth.RemoveAt(0);               
            }
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Time.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));
                Depth.Add(float.Parse((dataGridView1.Rows[counter].Cells[1].Value).ToString()));
                counter++;
            }
            textBox14.Text = counter.ToString();         
            CalculateInterpolation(RT);                                             
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Label1 = (textBox12.Text);
        Label2 = (textBox11.Text);
        dataGridView1.Columns[0].HeaderText = (Label1);
        dataGridView1.Columns[1].HeaderText = (Label2);
        label2.Text = (Label1);
        label3.Text = (Label2);      
        label10.Text = (Label1);
        label17.Text = (Label2);
    }

    

                             
    }
}
