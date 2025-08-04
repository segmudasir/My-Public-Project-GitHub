using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using ProjectHelper;

namespace My_Project
{
    public partial class Form42 : Form
    {        
        string result;
        string final_check;
        int digitize_count = 0;
        int first_point_X, first_point_Y;
        int indicator = 0;
        bool digitize_state = false;
        int datapoints_inside_count;    
         
            
        float global_e_xmin, global_e_xmax, global_e_ymin, global_e_ymax;
        public Form42()
        {
            InitializeComponent();
            dataGridView1.Columns[0].HeaderText = "Well Name";
            dataGridView1.Columns[1].HeaderText = "X";
            dataGridView1.Columns[2].HeaderText = "Y";
            dataGridView2.Columns[0].HeaderText = "X";
            dataGridView2.Columns[1].HeaderText = "Y";
           
            dataGridView3.Columns[0].HeaderText = "Well Name";
            dataGridView3.Columns[1].HeaderText = "X";
            dataGridView3.Columns[2].HeaderText = "Y";

            set_chartArea_innerplot_and_e_xy(chart1);            
            
            
        }

        int x0, y0, x1, y1, x2, y2;
        float xx0, yy0;
        float x_max, x_min, y_max, y_min;
        int polygon1_vertix = 0;
        
       
        int tooltripcount = 0; //for diplaying exact tool strip.
        int datapoints_count;        
        List<float> X = new List<float>();
        List<float> Y = new List<float>();
        List<string> Well = new List<string>();

        //Global list for polygon1X polygon1Y............since same name is used locally. so adding g-global
        List<float> gpolygon1_X = new List<float>();
        List<float> gpolygon1_Y = new List<float>();
                      
        int mouseclickcount;
        int dbleclick_count = 0;

        private void set_chartArea_innerplot_and_e_xy(Chart chart)
        {
            //this function. sets ChartArea innerplot position and saves e.x and e.y values in global parameters
            //this function is called in the form section.

            float chart_width = chart.Width;
            float chart_height = chart.Height;

            //these two parameters are necessary otherwise calculations will be wrong.                
            chart.ChartAreas[0].Position.Width = 100;
            chart.ChartAreas[0].Position.Height = 100;

            float ipw = chart.ChartAreas[0].InnerPlotPosition.Width = 85;
            float ipx = chart.ChartAreas[0].InnerPlotPosition.X = 10; //this value should be less than or equal to 100 - ipw.

            //if width is 85% then remaining area is 15% so. IPX (inner plot position x) should be 15). if you will put 16 or higher calculation will be based
            //on value 15. but if you put values less than 15.lets suppose 14 or 10 then it will be based on ipx.

            float iph = chart.ChartAreas[0].InnerPlotPosition.Height = 84;
            float ipy = chart.ChartAreas[0].InnerPlotPosition.Y = 7; //this value should be less than or equal to 100 - iph.

            //saving e.Xmax and e.Xmin, e.Ymin, e.Ymax values in global parameters.
            global_e_xmin = chart_width * ipx / 100;
            float temp = chart_width * ipw / 100;
            global_e_xmax = global_e_xmin + temp;

            global_e_ymin = chart_height * ipy / 100;
            float temp2 = chart_height * iph / 100;
            global_e_ymax = global_e_ymin + temp2;

           // textBox1.Text = global_e_ymin.ToString();
           // textBox12.Text = global_e_ymax.ToString();
        }      

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
            Draw_Chart_Btn.Enabled = true;
        }

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
            Draw_Chart_Btn.Enabled = true;
        }
        private void clear_fun()
        {
            textBox6.Clear();         
            textBox9.Clear();          
            textBox12.Clear();
            X.Clear();
            Y.Clear();
            Well.Clear();

            gpolygon1_X.Clear();
            gpolygon1_Y.Clear();
                       
            dataGridView2.Rows.Clear();        
            dataGridView3.Rows.Clear();
                       
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
                                
        }

        private void reset_fun()
        {          
            polygon1_vertix = 0;           
            mouseclickcount = 0;
            datapoints_count = 0;
           
            digitize_state = false;
            digitize_count = 0;
            digitize_Btn.Enabled = true;
            import_Btn.Enabled = true;

        }

        private void DrawChart_Btn_Click(object sender, EventArgs e)
        {           
            tooltripcount++;
            //this.Controls.Remove(chart2);
            update_Btn.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
          
            clear_fun();
            reset_fun();
           
            while (dataGridView1.Rows[datapoints_count].Cells[0].Value != null)
            {
                Well.Add(dataGridView1.Rows[datapoints_count].Cells[0].Value.ToString());
                X.Add(float.Parse(dataGridView1.Rows[datapoints_count].Cells[1].Value.ToString()));
                Y.Add(float.Parse(dataGridView1.Rows[datapoints_count].Cells[2].Value.ToString()));
                datapoints_count++;
            }
            textBox1.Text = datapoints_count.ToString();
         
            for (int i = 0; i < datapoints_count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(X[i], Y[i]);
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "X";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Y";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            //Data min max x and y
            float xmi = X.Min();
            float xmx = X.Max();
            float ymi = Y.Min();
            float ymx = Y.Max();

            float xfac = (xmx - xmi) / 10;
            float yfac = (ymx - ymi) / 10;
          

            x_min = xmi - xfac;
            x_max = xmx + xfac;
            y_min = ymi - yfac;
            y_max = ymx + yfac;
                                      
            textBox2.Text = x_min.ToString();
            textBox3.Text = x_max.ToString();
            textBox4.Text = y_min.ToString();
            textBox5.Text = y_max.ToString();
           
            chart_datapoints_series_color(chart1);
            chart_minmax_update(chart1);         
        }

          
        private void Update_Btn_Click(object sender, EventArgs e)
        {            
            clear_fun();
            reset_fun();

            x_min = float.Parse(textBox2.Text);
            x_max = float.Parse(textBox3.Text);
            y_min = float.Parse(textBox4.Text);
            y_max = float.Parse(textBox5.Text);
                    
            int count = 0;
            while (dataGridView1.Rows[count].Cells[0].Value != null)
            {
                float tempx = float.Parse(dataGridView1.Rows[count].Cells[0].Value.ToString());
                float tempy = float.Parse(dataGridView1.Rows[count].Cells[1].Value.ToString());
                if ((tempx <= x_max) && (tempx >= x_min) && (tempy <= y_max) && (tempy > y_min))
                {
                    X.Add(tempx);
                    Y.Add(tempy);
                    datapoints_count++;
                }
                count++; 
            }

            textBox1.Text = datapoints_count.ToString();

            for (int i = 0; i < datapoints_count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(X[i], Y[i]);
            }

            chart_datapoints_series_color(chart1);
            chart_minmax_update(chart1);         
           
        }  


        
        private void import_Btn_Click(object sender, EventArgs e)
        {
            digitize_Btn.Enabled = false;
            import_Btn.Enabled = false;
            Filter_wells.Enabled = true;

            List<float> pgon1_X = new List<float>();
            List<float> pgon1_Y = new List<float>();
            int cot = 0;
            while (dataGridView2.Rows[cot].Cells[0].Value != null)
            {
                float tempx = float.Parse(dataGridView2.Rows[cot].Cells[0].Value.ToString());
                float tempy = float.Parse(dataGridView2.Rows[cot].Cells[1].Value.ToString());
                
                    pgon1_X.Add(tempx);
                    pgon1_Y.Add(tempy);
                                  
                cot++;
            }

            textBox6.Text = (cot-1).ToString();
            chart1.Series["Series2"].Points.Clear();
            for (int i = 0; i < pgon1_X.Count; i++)
                chart1.Series["Series2"].Points.AddXY(pgon1_X[i], pgon1_Y[i]);
        }
        
        private void Polygon1_Click()
        {
            
            float poly_vertexcount = float.Parse(textBox6.Text);
            int ct = 0;
            List<float> polygon_X = new List<float>();
            List<float> polygon_Y = new List<float>();

            while (ct < (poly_vertexcount + 1))
            {
                polygon_X.Add(float.Parse(dataGridView2.Rows[ct].Cells[0].Value.ToString()));
                polygon_Y.Add(float.Parse(dataGridView2.Rows[ct].Cells[1].Value.ToString()));
                ct++;
            }
      
            var result = WellChecker.GetWellsInsidePolygon(Well, X, Y, polygon_X, polygon_Y);

            List<string> insideWells = result.Names;
            List<float> list1_X = result.X;
            List<float> list2_Y = result.Y;
            

            //chart 1 series 1
            //clear original chart1 datapoints
            chart1.Series["Series1"].Points.Clear();
            //Add chart1 polygon1 data points.
            for (int i = 0; i < list1_X.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(list1_X[i], list2_Y[i]); 
                dataGridView3.Rows.Add(insideWells[i],list1_X[i], list2_Y[i]);              
            }
            textBox9.Text = list1_X.Count.ToString();

                                
            float a = float.Parse(textBox9.Text);
            textBox12.Text = a.ToString();

        }

            
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            indicator = 1;                
            //Graphics gr = chart1.CreateGraphics();
            if ((digitize_count <= 1) && digitize_state)            
            {
                float xx = xconversion(e.X);
                float yy = yconversion(e.Y);

                if (mouseclickcount == 0)
                {                
                    x1 = e.X;
                    y1 = e.Y;

                    
                    gpolygon1_X.Add(x1);
                    gpolygon1_Y.Add(y1);
                    chart1.Series["Series2"].Points.AddXY(xx, yy); 
                    dataGridView2.Rows.Add(xx, yy);                        
                    textBox6.Text = (mouseclickcount + 1).ToString();
                                     

                    x0 = x1; //saving for end of polygon.
                    y0 = y1;

                    xx0 = xx; //converted first point.
                    yy0 = yy;

                    first_point_X = x1; //For Gray line. keeps changing for X2 if mouseclick is not 0.
                    first_point_Y = y1; 
                }
                else if (mouseclickcount != 0)
                {                    
                    x2 = e.X;
                    y2 = e.Y;
                    
                                          
                    gpolygon1_X.Add(x2);
                    gpolygon1_Y.Add(y2);
                    chart1.Series["Series2"].Points.AddXY(xx, yy);
                    dataGridView2.Rows.Add(xx, yy);
                    textBox6.Text = (mouseclickcount + 1).ToString();
                                        
                    //gr.DrawLine(p, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                    first_point_X = x2;
                    first_point_Y = y2;
                }
                mouseclickcount++;
                dbleclick_count = 0;//for second polygon- abhi first click howa double click ni hoa.
            }

        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
          
            gpolygon1_X.Add(x0);
            gpolygon1_Y.Add(y0);
            chart1.Series["Series2"].Points.AddXY(xx0, yy0);
            //on double click adding first point as last point.
            dataGridView2.Rows.Add(xx0, yy0);               
            polygon1_vertix = mouseclickcount;                 
            
            
                                                             
            mouseclickcount = 0;  // for next polygon it set to 0.           
            chart1.Cursor = Cursors.Arrow;
            dbleclick_count++;
            indicator = 0;
            digitize_state = false;
            Filter_wells.Enabled = true;


        }
       
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tooltripcount!=0)
            {
                float xx = xconversion(e.X); //linear interpolation          
                // linear to logarithmic conversion. required are logarithimic but diplay e.Y are linear           
                float yy = yconversion(e.Y);
                toolStripStatusLabel1.Text = " X = " + xx + "  " + "Y = " + yy;
               // toolStripStatusLabel1.Text = " X = " + e.X + "  " + "Y = " + e.Y;
            }

            ////////generating line online - after click - to - before click//////////////
            Graphics gr = chart1.CreateGraphics();
            Color cl = Color.Gray;
            Pen p = new Pen(cl, 3);

            if ((digitize_count <= 1) && (indicator == 1) && digitize_state)
            {
                x2 = e.X;
                y2 = e.Y;

                //drawing blue color solid points for Gray Hover line.
                Brush br = new SolidBrush(Color.DarkBlue);
                gr.FillEllipse(br, first_point_X - 3, first_point_Y - 3, 6, 6);

                chart1.Refresh();
                gr.DrawLine(p, first_point_X, first_point_Y, x2, y2);

            }
            ////////generating line online - after click - to - before click/////////////              
        }

        public float xconversion(float c)
        {           
            //Required values are basically what we required. forexmaple we have certain e.x value and in our case these value needs to be converted into chart values.
            //x_min are basically log minimum x values
            //x_max is log maximum x values.
            //Basically these are required values.
                 
            float required_xmin = x_min;
            float required_xmax = x_max;
            

            //float e_xmin = 78;
            //float e_xmax = 735;

            //So you can set these values by chartmouse move. and note e.X values. or I have calculated in the form section.
            // for second option no need to note. e.X and e.Y values. Just take value from Global varaiables.

            float e_xmin = global_e_xmin;
            float e_xmax = global_e_xmax;
            
            float xx = ((required_xmax - required_xmin) / (e_xmax - e_xmin) * (c - e_xmin)) + required_xmin;
            return xx;
        }

        public float yconversion(float d)
        {
            //y_min are basically log minimum y values
            //y_max is log maximum y values.

            float required_ymin = y_min;
            float required_ymax = y_max;

            //e.Y values should be taken from runing the program after putting the data.           
            //568 is maximum e.Y value and 44 is minimum e.Y value
       
            //float e_ymin = 568; //opposite because of scale.
            //float e_ymax = 44;
           
            float e_ymin = global_e_ymax; //opposite 
            float e_ymax = global_e_ymin;

            float yy = ((required_ymax - required_ymin) / (e_ymax - e_ymin) * (d - e_ymin)) + required_ymin;

            return yy;
        }
       
        private void chart_minmax_update(Chart chart)
        {        

            chart.ChartAreas[0].AxisX.Minimum = x_min;
            chart.ChartAreas[0].AxisX.Maximum = x_max;
            chart.ChartAreas[0].AxisX.Interval = (x_max - x_min)/10;
                      
            chart.ChartAreas[0].AxisY.Minimum = y_min;
            chart.ChartAreas[0].AxisY.Maximum = y_max ;
            chart.ChartAreas[0].AxisY.Interval = (y_max - y_min)/10;
            
            
            // Optional: Set the border style
            chart.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            chart.ChartAreas[0].BorderWidth = 3;
            chart.ChartAreas[0].BorderColor = Color.Green;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            
            
        }
       
        private void chart_datapoints_series_color(Chart chart)
        {
            chart.Series["Series1"].MarkerColor = Color.DeepSkyBlue;
            chart.Series["Series1"].MarkerStyle = MarkerStyle.Circle;

        }

        private void digitize_Btn_Click(object sender, EventArgs e)
        {
            digitize_state = true;
            chart1.Cursor = Cursors.Cross;                     
            import_Btn.Enabled = false;
            digitize_Btn.Enabled = false;
        }

        private void Filter_Wells_Click(object sender, EventArgs e)
        {
            Filter_wells.Enabled = false;
            update_Btn.Enabled = false;
            textBox12.Visible = true;          
                                                  
            Polygon1_Click();                               
           
        }

        

       
                      
    }

}
