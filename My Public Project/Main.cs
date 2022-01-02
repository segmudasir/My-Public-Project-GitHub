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
using System.IO;


namespace My_Project
{
    public partial class Main : Form
    {
        int formheight;
        int formwidth;
        int spanellocationx, spanellocationy, spanelsizex, spanelsizey;
        int locationx, locationy;
        int sizex, sizey;
        public Main()
        {
            InitializeComponent();
            formheight = this.Height;
            formwidth = this.Width;
            spanellocationx = 5;
            spanellocationy = ((formheight * 9) / 100);
            spanelsizex = 55;
            spanelsizey = (formheight * 81 / 100);
            locationx = 60;
            locationy = (formheight * 9 / 100);
            sizex = Convert.ToInt32(formwidth / (float.Parse("6.427")));
            sizey = (formheight * 81 / 100);
        }

        public class Logs
        {
            public float Depth;
            public float DT;
            public float RHOB;
            public float GR;
        }

        public Panel ScalePanel;

        public Chart Chart1;
        public Chart Chart2;
        public Chart Chart3;
        public Chart Chart4;
        public Chart Chart5;
        public Chart Chart6;

        List<Logs> Datalog = new List<Logs>();          //Main List
             
        List<float> Velocity = new List<float>();       //Velocity  
        List<float> VShale = new List<float>();         //Volume of Shale
        List<float> PR = new List<float>();             //PR
        String CurveName;
        int counter = 0;
        float ymin;
        float ymax;
        float limitymin2;
        float limitymax2;


       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   

        // For Scale Panel location and size       
        int startoffset;
        int endoffset;
        public Panel GetScalePanel(float limitymin, float limitymax)
        {
            startoffset = (formheight * 10 / 100);
            endoffset = Convert.ToInt32(formheight * ((float.Parse("2.5")) / 100));
            var scalepanel = new Panel();
            scalepanel.Location = new Point(spanellocationx, spanellocationy);
            scalepanel.Size = new Size(spanelsizex, spanelsizey);
            scalepanel.BackColor = Color.White;
            limitymin2 = limitymin;
            limitymax2 = limitymax;
            scalepanel.Paint += spanel_Paint;
            return scalepanel;
        }
        void spanel_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.         
            var blackpen = new Pen(Color.Black, 1);
            var redpen = new Pen(Color.Red, 1);
            int nhlines = 6;   // No. of Horizontal lines                  
            int nhpoints = nhlines * 2; // No. of Horizontal points 
            float scalelabel;
            float labelincriment;
            scalelabel = limitymin2;
            labelincriment = ((limitymax2 - scalelabel) / (nhlines - 1));

            //textBox1.Text = timecount.ToString();
            //textBox2.Text = labelincriment.ToString();
            int newx = spanelsizex - 1;
            int newy = startoffset;
            int labeloffset = 10;
            // Create points that define Vertical lines.
            Point[] VerticalPoints = new Point[02];
            VerticalPoints[0] = new Point(newx, newy);
            VerticalPoints[1] = new Point(newx, spanelsizey - endoffset);
            e.Graphics.DrawLine(blackpen, VerticalPoints[0], VerticalPoints[1]);
            newx = (spanelsizex - 10);
            newy = startoffset;
            // Create points that define Horizontal lines.
            Point[] HorizontalPoints = new Point[nhpoints];
            for (int i = 0; i <= (nhpoints - 1); i += 2)
            {
                if (i == (nhpoints - 2))
                {
                    newy = spanelsizey - endoffset;
                }
                HorizontalPoints[i] = new Point(newx, newy);
                HorizontalPoints[i + 1] = new Point(spanelsizex, newy);
                Label label1 = new Label();
                label1.AutoSize = true;
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(0, newy - labeloffset);
                label1.Size = new System.Drawing.Size(00, 15);
                label1.Name = "label1";
                label1.Text = scalelabel.ToString();
                e.Graphics.DrawString(label1.Text, label1.Font, Brushes.Blue, label1.Location);
                scalelabel = scalelabel + labelincriment;
                newy = newy + ((spanelsizey - startoffset - endoffset) / (nhlines - 1));
            }
            // Draw Horizontal Lines to screen.
            for (int i = 0; i <= (nhpoints - 1); i += 2)
            {
                e.Graphics.DrawLine(blackpen, HorizontalPoints[i], HorizontalPoints[i + 1]);
            }
        }

        /////////////////////////////////General Chart Funtion for All curves DT, RHOB, Velocity, AI, RC///////////////////////////////////////// 

        private Chart GetChart(String CurveName)
        {
            var chart = new Chart();
            chart.Location = new System.Drawing.Point(locationx, locationy);
            chart.Size = new System.Drawing.Size(sizex, sizey);
            //Chart.BackColor = Color.Transparent;
            chart.Name = "Chart1";
            // Add Chart Titles 
            var title1 = new Title();
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            title1.Name = "Title1";
            title1.Text = CurveName;
            title1.Position.Auto = false;
            title1.Position.Height = 4F;
            title1.Position.Width = 70F;
            title1.Position.X = 15F;
            title1.Position.Y = 3F;
            chart.Titles.Add(title1);
            // Add Chart Area
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.IsStartedFromZero = false;
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.AxisY.IsReversed = true;
            //chartArea.AxisY.LabelStyle.Enabled = true;
            chartArea.InnerPlotPosition.Auto = false;
            chartArea.BackColor = Color.Transparent;
            chartArea.InnerPlotPosition.Height = 100F;
            chartArea.InnerPlotPosition.Width = 90F;
            chartArea.InnerPlotPosition.X = 5F;
            chartArea.InnerPlotPosition.Y = 10F;
            chartArea.Name = "ChartArea1";
            // Add Chart Series
            Series Series1 = new Series();
            Series1.ChartArea = "ChartArea1";
            Series1.ChartType = SeriesChartType.Line;
            Series1.Legend = "Legend1";
            Series1.Name = "Series1";
            // Add Chart Area and Series to Chart
            chart.ChartAreas.Add(chartArea);
            chart.Series.Add(Series1);
            return chart;
        }

    
 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File|*.txt";
            ofd.Title = "Select any Text File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string line;
                // Read the file and display it line by line.
                StreamReader file = new StreamReader(ofd.FileName);
                while ((line = file.ReadLine()) != null)
                {
                    //split line
                    char[] delimiterChars = { ' ', '\t' };
                    //Line split and save into words.
                    string[] words = line.Split(delimiterChars);

                    //Object Declaration of Class
                    Logs Object = new Logs();
                    Object.Depth = float.Parse(words[0]);
                    Object.DT = float.Parse(words[1]);
                    Object.RHOB = float.Parse(words[2]);
                    Object.GR = float.Parse(words[3]);
                    // Adding Object to the List.
                    Datalog.Add(Object);
                    counter++;                  
                }

                // Calculate Y Scale.
                ymin = Datalog[0].Depth;
                ymax = Datalog[counter - 1].Depth;

                textBox1.Text = ymin.ToString();
                textBox2.Text = ymax.ToString();
                //Display Scale Panel on opening
                ScalePanel = GetScalePanel(ymin, ymax);
                Controls.Add(ScalePanel);

                //Display DT Curves on Opening
                CurveName = "DT";
                Chart1 = GetChart(CurveName);
                for (int i = 0; i < counter; i++)
                {
                    Chart1.Series["Series1"].Points.AddXY(Datalog[i].DT, Datalog[i].Depth);
                }
                Controls.Add(Chart1);
                locationx = locationx + 220;
                Chart1.Series["Series1"].Color = Color.Red;
                Chart1.Series["Series1"].Name = "DT";
                int max = Convert.ToInt32(Datalog.Max(x => x.DT));
                int min = Convert.ToInt32(Datalog.Min(x => x.DT));
                Chart1.ChartAreas[0].AxisX.Maximum = max;
                Chart1.ChartAreas[0].AxisX.Minimum = min;
                Chart1.ChartAreas[0].AxisX.Interval = (max - min) / 4;
                Chart1.ChartAreas[0].AxisY.Maximum = ymax;
                Chart1.ChartAreas[0].AxisY.Minimum = ymin;
                Chart1.ChartAreas[0].AxisY.Interval = (ymax - ymin) / 5;
                Chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            }  // If bracket............ 
            //Now file is opened perform calculations here.

                // Velocity            
            for (int i = 0; i < counter; i++)
            {
                Velocity.Add ((1 / Datalog[i].DT) * 1000000);

            }

            // Volume of Shale
            // VShale formula = (GR log - GR min) / (GR max - GR min)

            float GRmax = (Datalog.Max(x => x.GR));
            float GRmin = (Datalog.Min(x => x.GR));
            for (int i = 0; i < counter; i++)
            {
                VShale.Add (((Datalog[i].GR - GRmin) / (GRmax - GRmin)) * 100);

            }
            // Poisson's Ratio           
            for (int i = 0; i < counter; i++)
            {
                PR.Add (float.Parse("0.64")-(91 / (Datalog[i].DT * float.Parse("3.28"))));                
            } 
  
            /////////////////////////Enable Menu Items///////////////////////////////
            displayCurvesToolStripMenuItem.Enabled = true;
            estimateCurvesToolStripMenuItem.Enabled = true;
            formationTopsToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = false;
            groupBox2.Visible = true;

        } // Open Bracket


        private void displayDensityCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveName = "RHOB";
            Chart2 = GetChart(CurveName);
            for (int i = 0; i < counter; i++)
            {
                Chart2.Series["Series1"].Points.AddXY(Datalog[i].RHOB, Datalog[i].Depth);
            }
            Controls.Add(Chart2);
            locationx = locationx + 220;
            Chart2.Series["Series1"].Color = Color.Blue;
            Chart2.Series["Series1"].Name = "RHOB";
            Chart2.ChartAreas[0].AxisX.Maximum = 3.0;
            Chart2.ChartAreas[0].AxisX.Minimum = 2.0;
            Chart2.ChartAreas[0].AxisX.Interval = 0.2;
            Chart2.ChartAreas[0].AxisY.Maximum = ymax;
            Chart2.ChartAreas[0].AxisY.Minimum = ymin;
            Chart2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        }


        private void displayGammaRayCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveName = "GR";
            Chart3 = GetChart(CurveName);
            for (int i = 0; i < counter; i++)
            {
                Chart3.Series["Series1"].Points.AddXY(Datalog[i].GR, Datalog[i].Depth);
            }
            Controls.Add(Chart3);
            locationx = locationx + 220;
            Chart3.Series["Series1"].Color = Color.Green;
            Chart3.Series["Series1"].Name = "GR";
            Chart3.ChartAreas[0].AxisX.Maximum = 300;
            Chart3.ChartAreas[0].AxisX.Minimum = 0;
            Chart3.ChartAreas[0].AxisX.Interval = 300 / 5;
            Chart3.ChartAreas[0].AxisY.Maximum = ymax;
            Chart3.ChartAreas[0].AxisY.Minimum = ymin;
            Chart3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        }



        private void calculateVelocityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveName = "Velocity";
            Chart4 = GetChart(CurveName);
            for (int i = 0; i < counter; i++)
            {
                Chart4.Series["Series1"].Points.AddXY(Velocity[i], Datalog[i].Depth);
            }

            Controls.Add(Chart4);
            locationx = locationx + 220;
            Chart4.Series["Series1"].Color = Color.Fuchsia;
            Chart4.Series["Series1"].Name = "Velocity";
            int max = Convert.ToInt32(Velocity.Max());
            int min = Convert.ToInt32(Velocity.Min());
            Chart4.ChartAreas[0].AxisX.Maximum = max;
            Chart4.ChartAreas[0].AxisX.Minimum = min;
            Chart4.ChartAreas[0].AxisX.Interval = (max - min) / 5;
            Chart4.ChartAreas[0].AxisY.Maximum = ymax;
            Chart4.ChartAreas[0].AxisY.Minimum = ymin;
            Chart4.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        }

        private void calculateVolumeOfShaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveName = "VShale";
            Chart5 = GetChart(CurveName);
            for (int i = 0; i < counter; i++)
            {
                Chart5.Series["Series1"].Points.AddXY(VShale[i], Datalog[i].Depth);
            }
            Controls.Add(Chart5);
            locationx = locationx + 220;

            Chart5.Series["Series1"].Color = Color.Purple;
            Chart5.Series["Series1"].Name = "VShale";
            Chart5.ChartAreas[0].AxisX.Maximum = 100;
            Chart5.ChartAreas[0].AxisX.Minimum = 0;
            Chart5.ChartAreas[0].AxisX.Interval = 100 / 5;
            Chart5.ChartAreas[0].AxisY.Maximum = ymax;
            Chart5.ChartAreas[0].AxisY.Minimum = ymin;
            Chart5.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        }

        private void calculatePoissonsRatioFromPSonicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurveName = "PR";
            Chart6 = GetChart(CurveName);
            for (int i = 0; i < counter; i++)
            {
                Chart6.Series["Series1"].Points.AddXY(PR[i], Datalog[i].Depth);
            }
            Controls.Add(Chart6);
            locationx = locationx + 220;

            Chart6.Series["Series1"].Color = Color.Orange;
            Chart6.Series["Series1"].Name = "PR";
            Chart6.ChartAreas[0].AxisX.Maximum = 0.5;
            Chart6.ChartAreas[0].AxisX.Minimum = 0;
            Chart6.ChartAreas[0].AxisX.Interval = 0.5 / 5;
            Chart6.ChartAreas[0].AxisY.Maximum = ymax;
            Chart6.ChartAreas[0].AxisY.Minimum = ymin;
            Chart6.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            //listBox1.Items.Add(PR[0]);
        }


        private void AOI_Click(object sender, EventArgs e)
        {
            ymin = float.Parse(textBox1.Text);
            ymax = float.Parse(textBox2.Text);
            Chart1.ChartAreas[0].AxisY.Maximum = ymax;
            Chart1.ChartAreas[0].AxisY.Minimum = ymin;
            Chart2.ChartAreas[0].AxisY.Maximum = ymax;
            Chart2.ChartAreas[0].AxisY.Minimum = ymin;
            Chart3.ChartAreas[0].AxisY.Maximum = ymax;
            Chart3.ChartAreas[0].AxisY.Minimum = ymin;
            Chart4.ChartAreas[0].AxisY.Maximum = ymax;
            Chart4.ChartAreas[0].AxisY.Minimum = ymin;
            Chart5.ChartAreas[0].AxisY.Maximum = ymax;
            Chart5.ChartAreas[0].AxisY.Minimum = ymin;
            Chart6.ChartAreas[0].AxisY.Maximum = ymax;
            Chart6.ChartAreas[0].AxisY.Minimum = ymin;

        }


        /////////////////////// Main Menu Items clicks//////////////////////////
        private void mDSubseaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new My_Project.Form1();
            Form1.Show();
        }
        private void tVDSeismicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form2 = new My_Project.Form2();
            Form2.Show();
        }

        
        private void syntheticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form Form11 = new My_Project.Form11();
            //Form11.Show();
        }

        private void timeShiftSeismicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form3 = new My_Project.Form3();
            Form3.Show();
        }

        private void timeShiftFromWellLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form4 = new My_Project.Form4();
            Form4.Show();
        }

        private void linearInterpolationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form6 = new My_Project.Form6();
            Form6.Show();
        }
        
        private void timeDepthChartsTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form13 = new My_Project.Form13();
            Form13.Show();
        }

        private void TimeDepthChartsDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form5 = new My_Project.Form5();
            Form5.Show();
        }

        private void timeDepthChartsKingdomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form28 = new My_Project.Form28();
            Form28.Show();
        }

        private void minMaxFinderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Form17 = new My_Project.Form17();
            Form17.Show();
        }

        private void porosityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form16 = new My_Project.Form16();
            Form16.Show();
        }

        private void waterSaturationHydrocarbonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form19 = new My_Project.Form19();
            Form19.Show();
        }


        /*

       private void dBaseMapToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form7 = new My_Project.Form7();
           Form7.Show();       
       }
                
       private void convolution5X5ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form8 = new My_Project.Form8();
           Form8.Show();
       }

       private void mediumConvolutionToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form9 = new My_Project.Form9();
           Form9.Show();
       }
       private void advanceConvolutionToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form10 = new My_Project.Form10();
           Form10.Show();
       }        
       private void shueyToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form12 = new My_Project.Form12();
           Form12.Show();
       }            
       private void tectonicsToolStripMenuItem_Click(object sender, EventArgs e)
       {
           //Form Form14 = new My_Project.Form14();
           //Form14.Show();
       }
       //Form 15 Extra form added for Tectonic Subsidence Graph.
       
       

       private void rMSVelocitiesToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form18 = new My_Project.Form18();
           Form18.Show();
       }
       

       private void dSurveyPointCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form20 = new My_Project.Form20();
           Form20.Show();
       }

       private void rMSVelocitiesMultipleToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form21 = new My_Project.Form21();
           Form21.Show();
       }

       private void intervalVelocitiesToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form22 = new My_Project.Form22();
           Form22.Show();
       }

       private void rescaleToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form23 = new My_Project.Form23();
           Form23.Show();
       }

       private void aVGVelocitiesToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form24 = new My_Project.Form24();
           Form24.Show();
       }
       private void intervalVelocitiesMultipleToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form25 = new My_Project.Form25();
           Form25.Show();
       }
        
       private void aVGVelocitiesMultipleToolStripMenuItem_Click(object sender, EventArgs e)
       {
           //Form Form26 = new My_Project.Form26();
           //Form26.Show();
       }

       private void extractTimeFromHorizonToolStripMenuItem_Click(object sender, EventArgs e)
       {
           Form Form27 = new My_Project.Form27();
           Form27.Show();

       }

       */









    }
}
