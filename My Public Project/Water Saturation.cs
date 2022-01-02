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
    public partial class Form19 : Form
    {
        int formheight;
        int formwidth;
        int counter=0;
        int Chartlocationx, Chartlocationy, Chartsizex, Chartsizey, ChartcolorR, ChartcolorG, ChartcolorB;
        List<float> Depth = new List<float>();
        List<float> RT = new List<float>();
        List<float> Effective_Porosity2 = new List<float>();
        List<float> Effective_Porosity = new List<float>();
        List<float> Ratio = new List<float>();
        List<double> SW = new List<double>();
        List<float> Water_saturation = new List<float>();
        List<float> Water_saturation_Percentage = new List<float>();
        List<float> Hydrocarbon_saturation_Percentage = new List<float>();
        List<float> Step_Depth = new List<float>();
        List<float> Step_Water_saturation_Percentage = new List<float>();
        List<float> Step_Hydrocarbon_saturation_Percentage = new List<float>();
       
        public Chart Chart1;
        public Series Series1;
        public Series Series2;
        public Title Title1;        
        public Form19()
        {
            InitializeComponent();
            formheight = this.Height;
            formwidth = this.Width;
            //textBox1.Text = formheight.ToString();
            //textBox2.Text = formwidth.ToString();
            dataGridView1.Columns[0].HeaderText = "Depth";
            dataGridView1.Columns[1].HeaderText = "Rt (LLD)";
            dataGridView1.Columns[2].HeaderText = "Effective Porosity";            
            dataGridView2.Columns[0].HeaderText = "Sw";           
            Chartlocationx = (formwidth/100 *36);
            Chartlocationy = 66;
            Chartsizex = (formwidth * 63/100);
            Chartsizey = 520;
            ChartcolorR = 0;
            ChartcolorG = 211;
            ChartcolorB = 230;

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
            chartArea.AxisY.Title = "Water Saturation & Hydrocarbon Saturation (%age)";           
            chartArea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);            
            chartArea.AxisY.LabelStyle.Enabled = true;
            //colorR = 255;
            //colorG = 191;
            //colorB = 255;
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
        private Title GetChartTitle(Chart chart, String ChartName)
        {
            var title1 = new Title();
           // title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorR)))), ((int)(((byte)(colorG)))), ((int)(((byte)(colorB)))));
           // title1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DottedDiamond;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Text = ChartName;
            title1.Position.Auto = false;
            title1.Position.Height = 8F;
            title1.Position.Width = 40F;
            title1.Position.X = 20F;
            title1.Position.Y = 3F;
            chart.Titles.Add(title1);
            return title1;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       
        private void button1_Click(object sender, EventArgs e)
        {
            String Chartname;
            if (Chart1.Titles.Count == 1)
            {
                Chart1.Titles.RemoveAt(0);
            }
            counter = 0;
            dataGridView2.Rows.Clear();
            Depth.Clear();
            RT.Clear();
            SW.Clear();
            Ratio.Clear();
            Effective_Porosity2.Clear();
            Effective_Porosity.Clear();
            Water_saturation.Clear();
            Water_saturation_Percentage.Clear();
            Hydrocarbon_saturation_Percentage.Clear();
            Step_Depth.Clear();
            Step_Water_saturation_Percentage.Clear();
            Step_Hydrocarbon_saturation_Percentage.Clear();
                                                                                       
            while (dataGridView1.Rows[counter].Cells[0].Value != null)
            {
                Depth.Add(float.Parse((dataGridView1.Rows[counter].Cells[0].Value).ToString()));
                RT.Add(float.Parse((dataGridView1.Rows[counter].Cells[1].Value).ToString()));
                Effective_Porosity2.Add(float.Parse((dataGridView1.Rows[counter].Cells[2].Value).ToString()));                
                counter++;
            }
                       
            float Rw = float.Parse(textBox2.Text);
            for (int i = 0; i < counter; i++)
            {
                float temp = Rw/(RT[i]);
                Ratio.Add(temp);
            }

            //Conversion of NPHI Percentage into decimal to be used in forumulae//
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < counter; i++)
                {
                    float temp = Effective_Porosity2[i] / 100;
                    Effective_Porosity.Add(temp);
                }
            }
            else
            {
                for (int i = 0; i < counter; i++)
                {
                    float temp = Effective_Porosity2[i];
                    Effective_Porosity.Add(temp);
                }
            }

            for (int i = 0; i < counter; i++)
            {
                double temp = Math.Sqrt((1 / (Effective_Porosity[i] * Effective_Porosity[i])) * Ratio[i]);
                SW.Add(temp);
            }
            //Double to float values converison
            for (int i = 0; i < counter; i++)
            {
                float temp = (float)SW[i];
                Water_saturation.Add(temp);
            }
            for (int i = 0; i < counter; i++)
            {
                float temp =  (Water_saturation[i] * 100);
                Water_saturation_Percentage.Add(temp);
            }

            for (int i = 0; i < counter; i++)
            {
                float temp = (100 - Water_saturation_Percentage[i]);
                Hydrocarbon_saturation_Percentage.Add(temp);
            }

            for (int i = 0; i < counter; i++)
            {
                dataGridView2.Rows.Add(Water_saturation_Percentage[i].ToString());
            }
               
            while (Chart1.Series.Count > 0)
            {
                Chart1.Series.RemoveAt(0);
            }

            int countnew = 0;
            int markerstep = int.Parse(textBox4.Text);
            for (int i = 0; i < counter; i+=markerstep)
            {
                Step_Depth.Add(Depth[i]);
                Step_Water_saturation_Percentage.Add(Water_saturation_Percentage[i]);
                Step_Hydrocarbon_saturation_Percentage.Add(Hydrocarbon_saturation_Percentage[i]);                
                countnew++;
            }

            Chartname = (textBox1.Text);
                  
            Title1 = GetChartTitle(Chart1, Chartname);
            Series1 = GetSeries(Chart1);
            for (int i = 0; i < countnew; i++)
            {
                Chart1.Series["Series"].Points.AddXY(Step_Depth[i], Step_Water_saturation_Percentage[i]);
            }
            //Chart1.ChartAreas[0].AxisY.Interval = 0.2;
            int depthmin = Convert.ToInt32(Step_Depth.Min());
            int depthmax = Convert.ToInt32(Step_Depth.Max());
            Chart1.ChartAreas[0].AxisX.Minimum = depthmin;
            Chart1.ChartAreas[0].AxisX.Maximum = depthmax;
            Chart1.ChartAreas[0].AxisX.Interval = (depthmax - depthmax) / 6;
            Chart1.ChartAreas[0].AxisY.Minimum = 0;
            Chart1.ChartAreas[0].AxisY.Maximum = 100;
            Chart1.Series["Series"].Color = Color.DarkOrange;
            Chart1.Series["Series"].BorderWidth = 3;
            Chart1.Series["Series"].Name = "Water Saturation %";


            Series2 = GetSeries(Chart1);
            for (int i = 0; i < countnew; i++)
            {
                Chart1.Series["Series"].Points.AddXY(Step_Depth[i], Step_Hydrocarbon_saturation_Percentage[i]);
            }                
            Chart1.Series["Series"].Color = Color.Green;
            Chart1.Series["Series"].BorderWidth = 3;
            Chart1.Series["Series"].Name = "Hydrocarbon Saturation %";
        }
        
        
    }
}
