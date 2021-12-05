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
    public partial class Form28 : Form
    {
        float T1, T2, D1, D2, ID, WE, PseudoRV, DS, TS, RD, Y, M, X, C, RD0, zerot, zerod;
        float[] Array1 = new float[10];
        float[] Array2 = new float[10];
        List<float> Time2 = new List<float>();
        List<float> Depth2 = new List<float>();
        List<float> Time = new List<float>();
        List<float> Depth = new List<float>();
        List<float> multiTime = new List<float>();
        List<float> multiDepth = new List<float>();
        int counter = 0;
        int multicounter = 0;
        public Form28()
        {
            InitializeComponent();
            panel2.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Time (ms)";
            dataGridView1.Columns[1].HeaderText = "Depth";
            /////////////////////////// For My Testing /////////////////////////////
            //string Timeline = "512.6	700	800	900	1000	1100	1200	1300	1400	1500";
            //string Depthline = "627	950	1100	1270	1490	1650	1800	2000	2278	2424";
            //char[] delimiterChars = { ' ', '\t' };
            //string[] twords = Timeline.Split(delimiterChars);
            //string[] dwords = Depthline.Split(delimiterChars);
            //for (int i = 0; i < 10; i++)
            //{
            //    Array1[i] = float.Parse(twords[i]);
            //    Array2[i] = float.Parse(dwords[i]);
            //    dataGridView1.Rows.Add(Array1[i].ToString(), Array2[i].ToString());
            //}
            ///////////////////////////////////////////////////////////////////////
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

        //////////////////////////////////Time Calculation Funciton/////////////////////////////////////////////////
        public float CalculateTime(float depth)
        {
            counter = 0;
            while (Time2.Count > 0)
            {
                Time2.RemoveAt(0);
                Depth2.RemoveAt(0);
            }
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Time2.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));
                Depth2.Add(float.Parse((dataGridView1.Rows[counter].Cells[1].Value).ToString()));
                counter++;
            }
            textBox9.Text = counter.ToString();
            ID = float.Parse(textBox1.Text);
            WE = float.Parse(textBox2.Text);            
            DS = WE - ID;                                                        
            RD = depth;
            zerot=0;
            zerod = DS;
            while (Time.Count > 0)
            {
                Time.RemoveAt(0);
                Depth.RemoveAt(0);
            }
            Time.Add(zerot);
            Depth.Add(zerod);
            counter++;
            //dataGridView2.Rows.Clear();
            for (int i = 0; i < counter-1; i++)
            {
                Time.Add(Time2[i]);
                Depth.Add(Depth2[i]);
                //dataGridView2.Rows.Add(Time[i].ToString(), Depth[i].ToString());
            }
            if (RD >= Depth[0])
            {
                for (int i = 0; i < counter - 1; i++)
                {
                    if (RD >= Depth[i] && RD < Depth[i + 1])
                    {
                        T1 = Time[i];
                        T2 = Time[i + 1];
                        D1 = Depth[i];
                        D2 = Depth[i + 1];
                        textBox13.Text = T1.ToString();
                        textBox12.Text = T2.ToString();
                        textBox11.Text = D1.ToString();
                        textBox10.Text = D2.ToString();
                        M = (T2 - T1) / (D2 - D1);
                        X = RD - D1;
                        C = T1;                        
                        Y = (M * X) + C;
                        textBox17.Text = M.ToString();
                        textBox15.Text = X.ToString();
                        textBox14.Text = C.ToString();
                        textBox8.Text = Y.ToString();
                        break;                 
                    }
                }
                if (RD >= Depth[counter - 1])
                {
                    T1 = Time[counter - 2];
                    T2 = Time[counter - 1];
                    D1 = Depth[counter - 2];
                    D2 = Depth[counter - 1];
                    textBox13.Text = T1.ToString();
                    textBox12.Text = T2.ToString();
                    textBox11.Text = D1.ToString();
                    textBox10.Text = D2.ToString();
                    M = (T2 - T1) / (D2 - D1);
                    X = RD - D1;
                    C = T1;
                    Y = (M * X) + C;
                    textBox17.Text = M.ToString();
                    textBox15.Text = X.ToString();
                    textBox14.Text = C.ToString();
                    textBox8.Text = Y.ToString();
                }
            }

            //else if ()
            
            //else
                      
            return Y;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////// 


        private void button1_Click(object sender, EventArgs e)
        {
            RD0 = 0;
            CalculateTime(RD0);             //For calculating at 0 Depth. or pseudoTime shift.
            textBox16.Text = Y.ToString();
            TS = Y;
            PseudoRV = (ID - WE) / TS *2000;
            textBox7.Text = PseudoRV.ToString();
            //Now Required depth is sent to function.
            RD = float.Parse(textBox5.Text);
            CalculateTime(RD);
 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            dataGridView2.Columns[0].HeaderText = "Depth (MD)";
            dataGridView3.Columns[0].HeaderText = "Time (ms)";
        }

        private void Single_CheckedChanged(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox17.Clear();
            panel1.Visible = true;
            panel3.Visible = true;
            panel2.Visible = false;
        }


        ///////////////////////////////Copy and Paste from Clip board///////////////////////////////////////////////
        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
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
                int r = dataGridView2.SelectedCells[0].RowIndex;
                int c = dataGridView2.SelectedCells[0].ColumnIndex;
                //add rows into grid to fit clipboard lines
                if (dataGridView2.Rows.Count < (r + rowsInClipboard.Length))
                {
                    dataGridView2.Rows.Add(r + rowsInClipboard.Length - dataGridView2.Rows.Count + 1);
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
                        if (dataGridView2.ColumnCount - 1 >= c + iCol)
                        {
                            dataGridView2.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                        }
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        private void button2_Click(object sender, EventArgs e)
        {
            multicounter = 0;
            dataGridView3.Rows.Clear();
            while (multiTime.Count > 0)
            {
                multiTime.RemoveAt(0);
                multiDepth.RemoveAt(0);
            }
            while (dataGridView2.Rows[multicounter].Cells[0].Value != null)
            {
                multiDepth.Add(float.Parse((dataGridView2.Rows[multicounter].Cells[0].Value).ToString()));
                multicounter++;
            }

            RD0 = 0;
            CalculateTime(RD0);             //For calculating at 0 Depth. or pseudoTime shift.
            textBox16.Text = Y.ToString();
            TS = Y;
            PseudoRV = (ID - WE) / TS * 2000;
            textBox7.Text = PseudoRV.ToString();

            for (int i = 0; i < multicounter; i++)
            {
                CalculateTime(multiDepth[i]);
                multiTime.Add(Y);
            }
            for (int i = 0; i < multicounter; i++)
            {
                dataGridView3.Rows.Add(multiTime[i].ToString());
            }
        }

        
    }
}
