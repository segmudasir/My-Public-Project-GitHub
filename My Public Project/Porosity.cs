using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace My_Project
{
    public partial class Form16 : Form
    {
        int formheight;
        int formwidth;
        int counter=0;       
        int Chartlocationx, Chartlocationy, Chartsizex, Chartsizey, ChartcolorR, ChartcolorG, ChartcolorB;
        List<float> Depth = new List<float>();
        List<float> Step_Depth = new List<float>();
        List<float> GR = new List<float>();
        List<float> VSH_decimal = new List<float>();
        List<float> RHOB = new List<float>();
        List<float> NPHI2 = new List<float>();
        List<float> NPHI = new List<float>();
        List<float> NPHI_Decimal = new List<float>();
        List<float> DPHI = new List<float>();
        List<float> DPHI_Decimal = new List<float>();
        List<float> Total_Porosity_Decimal = new List<float>();
        List<float> Total_Porosity = new List<float>();
        List<float> Effective_Porosity = new List<float>();
        List<float> Step_Total_Porosity = new List<float>();
        List<float> Step_Effective_Porosity = new List<float>();

        public Chart Chart1;
        public Series Series1;
        public Series Series2;
        public Title Title1;        
        public Form16()
        {
            InitializeComponent();
            formheight = this.Height;
            formwidth = this.Width;
            //textBox1.Text = formheight.ToString();
            //textBox2.Text = formwidth.ToString();
            dataGridView1.Columns[0].HeaderText = "Depth";
            dataGridView1.Columns[1].HeaderText = "GR";
            dataGridView1.Columns[2].HeaderText = "RHOB";
            dataGridView1.Columns[3].HeaderText = "NPHI";
            dataGridView2.Columns[0].HeaderText = "E.Porosity";
            dataGridView2.Columns[1].HeaderText = "T.Porosity";
            Chartlocationx = (formwidth/100 *40);
            Chartlocationy = 66;
            Chartsizex = (formwidth * 60/100);
            Chartsizey = 520;
            ChartcolorR = 255;
            ChartcolorG = 204;
            ChartcolorB = 255;

            Chart1 = GetChart(Chartlocationx, Chartlocationy, Chartsizex, Chartsizey, ChartcolorR, ChartcolorG, ChartcolorB);
            Controls.Add(Chart1);
            textBox4.Text = 1.ToString(); 
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

        /////////////////////////////////////Main Ends - Chart General////////////////////////////////////////////////////////
        private Chart GetChart(int locationx, int locationy, int sizex, int sizey, int colorR, int colorG, int colorB)
        {
            var chart = new Chart();
            chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorR)))), ((int)(((byte)(colorG)))), ((int)(((byte)(colorB)))));                            
            chart.Location = new System.Drawing.Point(locationx, locationy);
            chart.Size = new System.Drawing.Size(sizex, sizey);
            chart.Name = "Chart1";
            // Add Chart Titles 
                 
            // Add Chart Area
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.IsStartedFromZero = false;
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisX.Title = "Depth (meter)";
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F); 
            chartArea.AxisY.Title = "Porosity (%age)";           
            chartArea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);            
            chartArea.AxisY.LabelStyle.Enabled = true;
            colorR = 0;
            colorG = 191;
            colorB = 255;
            //chartArea.BackColor = Color.FromArgb(((int)(((byte)(colorR)))), ((int)(((byte)(colorG)))), ((int)(((byte)(colorB))))); 
            chartArea.Name = "ChartArea1";
            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.Height = 78F;
            chartArea.InnerPlotPosition.Width = 90F;
            chartArea.InnerPlotPosition.X = 9F;
            chartArea.InnerPlotPosition.Y = 12F;
            // Add Chart Legends
            Legend Legend1 = new Legend();
            Legend1.Alignment = StringAlignment.Center;
            Legend1.Docking = Docking.Right;
            Legend1.Name = "Legend1";
            // Add Chart Area and Series to Chart
            chart.ChartAreas.Add(chartArea);
            chart.Legends.Add(Legend1);
            return chart;
        }


        private Series GetSeries(Chart chart)
        {
            var series = new Series();
            series.Name = "Series";
            chart.Series.Add("Series");
            chart.Series["Series"].IsValueShownAsLabel = false;
            chart.Series["Series"].ChartType = SeriesChartType.Spline;           
            //chart.Series["Series"].MarkerBorderColor = System.Drawing.Color.Fuchsia;
            //chart.Series["Series"].MarkerColor = System.Drawing.Color.Blue;
            //chart.Series["Series"].MarkerSize = 6;
            return series;
        }

        private Title GetChartTitle(Chart chart, String ChartName, int colorR, int colorG, int colorB)
        {
            var title1 = new Title();
            //title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorR)))), ((int)(((byte)(colorG)))), ((int)(((byte)(colorB)))));
            //title1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DottedDiamond;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Text = ChartName;
            title1.Position.Auto = false;
            title1.Position.Height = 8F;
            title1.Position.Width = 30F;
            title1.Position.X = 30F;
            title1.Position.Y = 3F;            
            chart.Titles.Add(title1);
            return title1;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
       
       
        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            dataGridView2.Rows.Clear();

            //List Clearing
            Depth.Clear();
            GR.Clear();
            RHOB.Clear();
            NPHI2.Clear();
            NPHI.Clear();
            VSH_decimal.Clear();
            DPHI_Decimal.Clear();
            DPHI.Clear();
            Total_Porosity_Decimal.Clear();
            Total_Porosity.Clear();
            
            Effective_Porosity.Clear();
            
                                              
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Depth.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));
                GR.Add(float.Parse((dataGridView1.Rows[counter].Cells[1].Value).ToString()));
                RHOB.Add(float.Parse((dataGridView1.Rows[counter].Cells[2].Value).ToString()));
                NPHI2.Add(float.Parse((dataGridView1.Rows[counter].Cells[3].Value).ToString()));
                counter++;
            }
                                          
            float GRMax = float.Parse(textBox2.Text);
            float GRMin = float.Parse(textBox3.Text);

            for (int i = 0; i < counter; i++)
            {
                float tempvsh = ((GR[i]-GRMin)/(GRMax-GRMin));
                VSH_decimal.Add(tempvsh);
            }            

            for (int i = 0; i < counter; i++)
            {
                float tempdphi = ((2.65F - RHOB[i]) / (2.65F - 1.03F));
                DPHI_Decimal.Add(tempdphi);
            }

            for (int i = 0; i < counter; i++)
            {
                float temp2 =  (DPHI_Decimal[i] * 100);
                DPHI.Add(temp2);
            }

            //Conversion of NPHI Percentage into decimal to be used in forumulae//
            if (radioButton1.Checked == true)
                {
                    for (int i = 0; i < counter; i++)
                    {
                        float temp = NPHI2[i] / 100;
                        NPHI.Add(temp);
                    }
                }
                else
                {
                    for (int i = 0; i < counter; i++)
                    {
                        float temp = NPHI2[i];
                        NPHI.Add(temp);
                    }
                }
            
            for (int i = 0; i < counter; i++)
            {
                float temp = (DPHI_Decimal[i] + NPHI[i])/2;
                Total_Porosity_Decimal.Add(temp);
            }

            for (int i = 0; i < counter; i++)
            {
                float temp = (Total_Porosity_Decimal[i] *100);
                Total_Porosity.Add(temp);
            }

            for (int i = 0; i < counter; i++)
            {
                float temp4 = (Total_Porosity[i] * (1-VSH_decimal[i]));
                //temp4 = temp4 * 100;
                Effective_Porosity.Add(temp4);
            }

            for (int i = 0; i < counter; i++)
            {
                dataGridView2.Rows.Add(Effective_Porosity[i].ToString(), Total_Porosity[i].ToString());
            }
                           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Chartname;
            if (Chart1.Titles.Count==1)
            {
                Chart1.Titles.RemoveAt(0);
            }
                
           
            while (Chart1.Series.Count > 0)
            {
                Chart1.Series.RemoveAt(0);                
            }

            Step_Depth.Clear();
            Effective_Porosity.Clear();
            Total_Porosity.Clear();
            Step_Total_Porosity.Clear();
            Step_Effective_Porosity.Clear();

            counter = 0;
            while (dataGridView2.Rows[counter].Cells[0].Value != null)
            {
                Effective_Porosity.Add(float.Parse((dataGridView2.Rows[counter].Cells[0].Value).ToString()));
                Total_Porosity.Add(float.Parse((dataGridView2.Rows[counter].Cells[1].Value).ToString()));               
                counter++;
            }
            int countnew = 0;
            int markerstep = int.Parse(textBox4.Text);
            for (int i = 0; i < counter; i+=markerstep)
            {
                Step_Depth.Add(Depth[i]);
                Step_Effective_Porosity.Add(Effective_Porosity[i]);
                Step_Total_Porosity.Add(Total_Porosity[i]);
                countnew++;
            }

            Chartname = (textBox1.Text);
            ChartcolorR = 0;
            ChartcolorG = 220;
            ChartcolorB = 200;
            
            Title1 = GetChartTitle(Chart1, Chartname, ChartcolorR, ChartcolorG, ChartcolorB);
            Series1 = GetSeries(Chart1);            
            for (int i = 0; i < countnew; i++)
            {
                Chart1.Series["Series"].Points.AddXY(Step_Depth[i], Step_Total_Porosity[i]);
            }
            //Chart1.ChartAreas[0].AxisY.Interval = 0.2;
            int depthmin = Convert.ToInt32(Step_Depth.Min());
            int depthmax = Convert.ToInt32(Step_Depth.Max());
            Chart1.ChartAreas[0].AxisX.Minimum = depthmin;
            Chart1.ChartAreas[0].AxisX.Maximum = depthmax;
            Chart1.ChartAreas[0].AxisX.Interval = (depthmax - depthmax) / 6;
            Chart1.Series["Series"].Color = Color.DarkOrange;
            Chart1.Series["Series"].BorderWidth = 3;
            Chart1.Series["Series"].Name = "Total Porosity";


            Series2 = GetSeries(Chart1);
            for (int i = 0; i < countnew; i++)
            {
                Chart1.Series["Series"].Points.AddXY(Step_Depth[i], Step_Effective_Porosity[i]);
            }
            Chart1.Series["Series"].Color = Color.DarkCyan;
            Chart1.Series["Series"].BorderWidth = 3;
            Chart1.Series["Series"].Name = "Effective Porosity";
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();            
        }

        

        


        
    }
}
