namespace My_Project
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayCurvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDensityCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGammaRayCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimateCurvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateVelocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateVolumeOfShaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syntheticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convolution5X5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumConvolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceConvolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shueyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tectonicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formationTopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seismicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBaseMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSurveyPointCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSVelocitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSVelocitiesMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalVelocitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalVelocitiesMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVGVelocitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVGVelocitiesMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractTimeFromHorizonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDSubseaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVDSeismicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeShiftSeismicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeShiftFromWellLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDepthChartsTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDepthChartsDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDepthChartsKingdomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petrophysicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minMaxFinderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porosityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterSaturationHydrocarbonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rescaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Fullextents = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AOI = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.displayCurvesToolStripMenuItem,
            this.estimateCurvesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.formationTopsToolStripMenuItem,
            this.seismicToolStripMenuItem,
            this.calculatorsToolStripMenuItem,
            this.petrophysicsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 56;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // displayCurvesToolStripMenuItem
            // 
            this.displayCurvesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayDensityCurveToolStripMenuItem,
            this.displayGammaRayCurveToolStripMenuItem});
            this.displayCurvesToolStripMenuItem.Enabled = false;
            this.displayCurvesToolStripMenuItem.Name = "displayCurvesToolStripMenuItem";
            this.displayCurvesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.displayCurvesToolStripMenuItem.Text = "Display Curves";
            // 
            // displayDensityCurveToolStripMenuItem
            // 
            this.displayDensityCurveToolStripMenuItem.Name = "displayDensityCurveToolStripMenuItem";
            this.displayDensityCurveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.displayDensityCurveToolStripMenuItem.Text = "Display Density Curve";
            this.displayDensityCurveToolStripMenuItem.Click += new System.EventHandler(this.displayDensityCurveToolStripMenuItem_Click);
            // 
            // displayGammaRayCurveToolStripMenuItem
            // 
            this.displayGammaRayCurveToolStripMenuItem.Name = "displayGammaRayCurveToolStripMenuItem";
            this.displayGammaRayCurveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.displayGammaRayCurveToolStripMenuItem.Text = "Display Gamma Ray Curve";
            this.displayGammaRayCurveToolStripMenuItem.Click += new System.EventHandler(this.displayGammaRayCurveToolStripMenuItem_Click);
            // 
            // estimateCurvesToolStripMenuItem
            // 
            this.estimateCurvesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateVelocityToolStripMenuItem,
            this.calculateVolumeOfShaleToolStripMenuItem,
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem});
            this.estimateCurvesToolStripMenuItem.Enabled = false;
            this.estimateCurvesToolStripMenuItem.Name = "estimateCurvesToolStripMenuItem";
            this.estimateCurvesToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.estimateCurvesToolStripMenuItem.Text = "Estimate Curves";
            // 
            // calculateVelocityToolStripMenuItem
            // 
            this.calculateVelocityToolStripMenuItem.Name = "calculateVelocityToolStripMenuItem";
            this.calculateVelocityToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.calculateVelocityToolStripMenuItem.Text = "Calculate Velocity";
            this.calculateVelocityToolStripMenuItem.Click += new System.EventHandler(this.calculateVelocityToolStripMenuItem_Click);
            // 
            // calculateVolumeOfShaleToolStripMenuItem
            // 
            this.calculateVolumeOfShaleToolStripMenuItem.Name = "calculateVolumeOfShaleToolStripMenuItem";
            this.calculateVolumeOfShaleToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.calculateVolumeOfShaleToolStripMenuItem.Text = "Calculate Volume of Shale";
            this.calculateVolumeOfShaleToolStripMenuItem.Click += new System.EventHandler(this.calculateVolumeOfShaleToolStripMenuItem_Click);
            // 
            // calculatePoissonsRatioFromPSonicToolStripMenuItem
            // 
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem.Name = "calculatePoissonsRatioFromPSonicToolStripMenuItem";
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem.Text = "Calculate Poisson\'s Ratio from P-Sonic";
            this.calculatePoissonsRatioFromPSonicToolStripMenuItem.Click += new System.EventHandler(this.calculatePoissonsRatioFromPSonicToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syntheticToolStripMenuItem,
            this.convolution5X5ToolStripMenuItem,
            this.mediumConvolutionToolStripMenuItem,
            this.advanceConvolutionToolStripMenuItem,
            this.aVOToolStripMenuItem,
            this.tectonicsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // syntheticToolStripMenuItem
            // 
            this.syntheticToolStripMenuItem.Enabled = false;
            this.syntheticToolStripMenuItem.Name = "syntheticToolStripMenuItem";
            this.syntheticToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.syntheticToolStripMenuItem.Text = "Synthetic Seismogram";
            this.syntheticToolStripMenuItem.Click += new System.EventHandler(this.syntheticToolStripMenuItem_Click);
            // 
            // convolution5X5ToolStripMenuItem
            // 
            this.convolution5X5ToolStripMenuItem.Name = "convolution5X5ToolStripMenuItem";
            this.convolution5X5ToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.convolution5X5ToolStripMenuItem.Text = "Convolution (5 x 5) Elements";
            // 
            // mediumConvolutionToolStripMenuItem
            // 
            this.mediumConvolutionToolStripMenuItem.Name = "mediumConvolutionToolStripMenuItem";
            this.mediumConvolutionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.mediumConvolutionToolStripMenuItem.Text = "Medium Convolution";
            // 
            // advanceConvolutionToolStripMenuItem
            // 
            this.advanceConvolutionToolStripMenuItem.Name = "advanceConvolutionToolStripMenuItem";
            this.advanceConvolutionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.advanceConvolutionToolStripMenuItem.Text = "Advance Convolution";
            // 
            // aVOToolStripMenuItem
            // 
            this.aVOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shueyToolStripMenuItem});
            this.aVOToolStripMenuItem.Name = "aVOToolStripMenuItem";
            this.aVOToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.aVOToolStripMenuItem.Text = "AVO";
            // 
            // shueyToolStripMenuItem
            // 
            this.shueyToolStripMenuItem.Name = "shueyToolStripMenuItem";
            this.shueyToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.shueyToolStripMenuItem.Text = "Shuey Approximation";
            // 
            // tectonicsToolStripMenuItem
            // 
            this.tectonicsToolStripMenuItem.Enabled = false;
            this.tectonicsToolStripMenuItem.Name = "tectonicsToolStripMenuItem";
            this.tectonicsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.tectonicsToolStripMenuItem.Text = "Tectonics";
            // 
            // formationTopsToolStripMenuItem
            // 
            this.formationTopsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.formationTopsToolStripMenuItem.Enabled = false;
            this.formationTopsToolStripMenuItem.Name = "formationTopsToolStripMenuItem";
            this.formationTopsToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.formationTopsToolStripMenuItem.Text = "Formation Tops";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // seismicToolStripMenuItem
            // 
            this.seismicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBaseMapToolStripMenuItem,
            this.dSurveyPointCalculatorToolStripMenuItem,
            this.rMSVelocitiesToolStripMenuItem,
            this.rMSVelocitiesMultipleToolStripMenuItem,
            this.intervalVelocitiesToolStripMenuItem,
            this.intervalVelocitiesMultipleToolStripMenuItem,
            this.aVGVelocitiesToolStripMenuItem,
            this.aVGVelocitiesMultipleToolStripMenuItem,
            this.extractTimeFromHorizonToolStripMenuItem});
            this.seismicToolStripMenuItem.Name = "seismicToolStripMenuItem";
            this.seismicToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.seismicToolStripMenuItem.Text = "Seismic";
            // 
            // dBaseMapToolStripMenuItem
            // 
            this.dBaseMapToolStripMenuItem.Name = "dBaseMapToolStripMenuItem";
            this.dBaseMapToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.dBaseMapToolStripMenuItem.Text = "2D Base Map";
            // 
            // dSurveyPointCalculatorToolStripMenuItem
            // 
            this.dSurveyPointCalculatorToolStripMenuItem.Name = "dSurveyPointCalculatorToolStripMenuItem";
            this.dSurveyPointCalculatorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.dSurveyPointCalculatorToolStripMenuItem.Text = "3D Survey Point Calculator";
            // 
            // rMSVelocitiesToolStripMenuItem
            // 
            this.rMSVelocitiesToolStripMenuItem.Name = "rMSVelocitiesToolStripMenuItem";
            this.rMSVelocitiesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.rMSVelocitiesToolStripMenuItem.Text = "RMS Velocities";
            // 
            // rMSVelocitiesMultipleToolStripMenuItem
            // 
            this.rMSVelocitiesMultipleToolStripMenuItem.Name = "rMSVelocitiesMultipleToolStripMenuItem";
            this.rMSVelocitiesMultipleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.rMSVelocitiesMultipleToolStripMenuItem.Text = "RMS Velocities - Multiple";
            // 
            // intervalVelocitiesToolStripMenuItem
            // 
            this.intervalVelocitiesToolStripMenuItem.Name = "intervalVelocitiesToolStripMenuItem";
            this.intervalVelocitiesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.intervalVelocitiesToolStripMenuItem.Text = "Interval Velocities";
            // 
            // intervalVelocitiesMultipleToolStripMenuItem
            // 
            this.intervalVelocitiesMultipleToolStripMenuItem.Name = "intervalVelocitiesMultipleToolStripMenuItem";
            this.intervalVelocitiesMultipleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.intervalVelocitiesMultipleToolStripMenuItem.Text = "Interval Velocities - Multiple";
            // 
            // aVGVelocitiesToolStripMenuItem
            // 
            this.aVGVelocitiesToolStripMenuItem.Name = "aVGVelocitiesToolStripMenuItem";
            this.aVGVelocitiesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.aVGVelocitiesToolStripMenuItem.Text = "AVG Velocities";
            // 
            // aVGVelocitiesMultipleToolStripMenuItem
            // 
            this.aVGVelocitiesMultipleToolStripMenuItem.Name = "aVGVelocitiesMultipleToolStripMenuItem";
            this.aVGVelocitiesMultipleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.aVGVelocitiesMultipleToolStripMenuItem.Text = "AVG Velocities - Multiple";
            // 
            // extractTimeFromHorizonToolStripMenuItem
            // 
            this.extractTimeFromHorizonToolStripMenuItem.Name = "extractTimeFromHorizonToolStripMenuItem";
            this.extractTimeFromHorizonToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.extractTimeFromHorizonToolStripMenuItem.Text = "Extract Time from Horizon";
            // 
            // calculatorsToolStripMenuItem
            // 
            this.calculatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDSubseaToolStripMenuItem,
            this.tVDSeismicToolStripMenuItem,
            this.timeShiftSeismicToolStripMenuItem,
            this.timeShiftFromWellLogsToolStripMenuItem,
            this.linearInterpolationToolStripMenuItem,
            this.timeDepthChartsTimeToolStripMenuItem,
            this.TimeDepthChartsDepthToolStripMenuItem,
            this.timeDepthChartsKingdomToolStripMenuItem});
            this.calculatorsToolStripMenuItem.Name = "calculatorsToolStripMenuItem";
            this.calculatorsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.calculatorsToolStripMenuItem.Text = "Calculators";
            // 
            // mDSubseaToolStripMenuItem
            // 
            this.mDSubseaToolStripMenuItem.Name = "mDSubseaToolStripMenuItem";
            this.mDSubseaToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.mDSubseaToolStripMenuItem.Text = "MD - Subsea";
            this.mDSubseaToolStripMenuItem.Click += new System.EventHandler(this.mDSubseaToolStripMenuItem_Click);
            // 
            // tVDSeismicToolStripMenuItem
            // 
            this.tVDSeismicToolStripMenuItem.Name = "tVDSeismicToolStripMenuItem";
            this.tVDSeismicToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.tVDSeismicToolStripMenuItem.Text = "TVD Seismic";
            this.tVDSeismicToolStripMenuItem.Click += new System.EventHandler(this.tVDSeismicToolStripMenuItem_Click);
            // 
            // timeShiftSeismicToolStripMenuItem
            // 
            this.timeShiftSeismicToolStripMenuItem.Name = "timeShiftSeismicToolStripMenuItem";
            this.timeShiftSeismicToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.timeShiftSeismicToolStripMenuItem.Text = "Time Shift Seismic";
            this.timeShiftSeismicToolStripMenuItem.Click += new System.EventHandler(this.timeShiftSeismicToolStripMenuItem_Click);
            // 
            // timeShiftFromWellLogsToolStripMenuItem
            // 
            this.timeShiftFromWellLogsToolStripMenuItem.Name = "timeShiftFromWellLogsToolStripMenuItem";
            this.timeShiftFromWellLogsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.timeShiftFromWellLogsToolStripMenuItem.Text = "Time Shift from Well logs";
            this.timeShiftFromWellLogsToolStripMenuItem.Click += new System.EventHandler(this.timeShiftFromWellLogsToolStripMenuItem_Click);
            // 
            // linearInterpolationToolStripMenuItem
            // 
            this.linearInterpolationToolStripMenuItem.Name = "linearInterpolationToolStripMenuItem";
            this.linearInterpolationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.linearInterpolationToolStripMenuItem.Text = "Linear Interpolation";
            this.linearInterpolationToolStripMenuItem.Click += new System.EventHandler(this.linearInterpolationToolStripMenuItem_Click_1);
            // 
            // timeDepthChartsTimeToolStripMenuItem
            // 
            this.timeDepthChartsTimeToolStripMenuItem.Name = "timeDepthChartsTimeToolStripMenuItem";
            this.timeDepthChartsTimeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.timeDepthChartsTimeToolStripMenuItem.Text = "Time Depth Charts - Time";
            this.timeDepthChartsTimeToolStripMenuItem.Click += new System.EventHandler(this.timeDepthChartsTimeToolStripMenuItem_Click);
            // 
            // TimeDepthChartsDepthToolStripMenuItem
            // 
            this.TimeDepthChartsDepthToolStripMenuItem.Name = "TimeDepthChartsDepthToolStripMenuItem";
            this.TimeDepthChartsDepthToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.TimeDepthChartsDepthToolStripMenuItem.Text = "Time Depth Charts - Depth";
            this.TimeDepthChartsDepthToolStripMenuItem.Click += new System.EventHandler(this.TimeDepthChartsDepthToolStripMenuItem_Click);
            // 
            // timeDepthChartsKingdomToolStripMenuItem
            // 
            this.timeDepthChartsKingdomToolStripMenuItem.Name = "timeDepthChartsKingdomToolStripMenuItem";
            this.timeDepthChartsKingdomToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.timeDepthChartsKingdomToolStripMenuItem.Text = "Time Depth Charts - Kingdom";
            this.timeDepthChartsKingdomToolStripMenuItem.Click += new System.EventHandler(this.timeDepthChartsKingdomToolStripMenuItem_Click);
            // 
            // petrophysicsToolStripMenuItem
            // 
            this.petrophysicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minMaxFinderToolStripMenuItem1,
            this.porosityToolStripMenuItem,
            this.waterSaturationHydrocarbonToolStripMenuItem,
            this.rescaleToolStripMenuItem});
            this.petrophysicsToolStripMenuItem.Name = "petrophysicsToolStripMenuItem";
            this.petrophysicsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.petrophysicsToolStripMenuItem.Text = "Petrophysics";
            // 
            // minMaxFinderToolStripMenuItem1
            // 
            this.minMaxFinderToolStripMenuItem1.Name = "minMaxFinderToolStripMenuItem1";
            this.minMaxFinderToolStripMenuItem1.Size = new System.Drawing.Size(243, 22);
            this.minMaxFinderToolStripMenuItem1.Text = "Min Max Finder";
            // 
            // porosityToolStripMenuItem
            // 
            this.porosityToolStripMenuItem.Name = "porosityToolStripMenuItem";
            this.porosityToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.porosityToolStripMenuItem.Text = "Porosity";
            // 
            // waterSaturationHydrocarbonToolStripMenuItem
            // 
            this.waterSaturationHydrocarbonToolStripMenuItem.Name = "waterSaturationHydrocarbonToolStripMenuItem";
            this.waterSaturationHydrocarbonToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.waterSaturationHydrocarbonToolStripMenuItem.Text = "Water / Hydrocarbon Saturation";
            // 
            // rescaleToolStripMenuItem
            // 
            this.rescaleToolStripMenuItem.Name = "rescaleToolStripMenuItem";
            this.rescaleToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.rescaleToolStripMenuItem.Text = "Rescale";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Fullextents);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.AOI);
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 39);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Options";
            this.groupBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Start Depth";
            // 
            // Fullextents
            // 
            this.Fullextents.Location = new System.Drawing.Point(499, 10);
            this.Fullextents.Name = "Fullextents";
            this.Fullextents.Size = new System.Drawing.Size(74, 25);
            this.Fullextents.TabIndex = 73;
            this.Fullextents.Text = "Full Extents";
            this.Fullextents.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(277, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "End Depth";
            // 
            // AOI
            // 
            this.AOI.Location = new System.Drawing.Point(392, 10);
            this.AOI.Name = "AOI";
            this.AOI.Size = new System.Drawing.Size(74, 25);
            this.AOI.TabIndex = 66;
            this.AOI.Text = "Apply";
            this.AOI.UseVisualStyleBackColor = true;
            this.AOI.Click += new System.EventHandler(this.AOI_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1023, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayCurvesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayDensityCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGammaRayCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimateCurvesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convolution5X5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDSubseaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVDSeismicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeShiftFromWellLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearInterpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeShiftSeismicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateVelocityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateVolumeOfShaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatePoissonsRatioFromPSonicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seismicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formationTopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syntheticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shueyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumConvolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceConvolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeDepthChartsTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TimeDepthChartsDepthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tectonicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rMSVelocitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem petrophysicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minMaxFinderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porosityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waterSaturationHydrocarbonToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Fullextents;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AOI;
        private System.Windows.Forms.ToolStripMenuItem rMSVelocitiesMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalVelocitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalVelocitiesMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVGVelocitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVGVelocitiesMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rescaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dSurveyPointCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBaseMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractTimeFromHorizonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeDepthChartsKingdomToolStripMenuItem;
    }
}

