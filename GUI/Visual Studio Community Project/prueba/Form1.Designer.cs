namespace prueba
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.BtnBuscarPuertos = new System.Windows.Forms.Button();
            this.buttonPort = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eliminar = new System.Windows.Forms.PictureBox();
            this.gaugeVelocity = new System.Windows.Forms.AGauge();
            this.gaugeAngle = new System.Windows.Forms.AGauge();
            this.lienzo = new System.Windows.Forms.PictureBox();
            this.lbl_ellipsePosX = new System.Windows.Forms.Label();
            this.lbl_Angle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.cbx_system = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ctrl = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_out = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 138);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(291, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SERIAL PORT";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.comboBoxPort, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.BtnBuscarPuertos, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(285, 93);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPort.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(3, 2);
            this.comboBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(136, 31);
            this.comboBoxPort.TabIndex = 0;
            // 
            // BtnBuscarPuertos
            // 
            this.BtnBuscarPuertos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscarPuertos.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarPuertos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnBuscarPuertos.Location = new System.Drawing.Point(145, 2);
            this.BtnBuscarPuertos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBuscarPuertos.Name = "BtnBuscarPuertos";
            this.BtnBuscarPuertos.Size = new System.Drawing.Size(137, 89);
            this.BtnBuscarPuertos.TabIndex = 2;
            this.BtnBuscarPuertos.Text = "SEARCH PORTS";
            this.BtnBuscarPuertos.UseVisualStyleBackColor = true;
            this.BtnBuscarPuertos.Click += new System.EventHandler(this.BtnBuscarPuertos_Click);
            // 
            // buttonPort
            // 
            this.buttonPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPort.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPort.Location = new System.Drawing.Point(145, 2);
            this.buttonPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPort.Name = "buttonPort";
            this.buttonPort.Size = new System.Drawing.Size(137, 96);
            this.buttonPort.TabIndex = 1;
            this.buttonPort.Text = "START";
            this.buttonPort.UseVisualStyleBackColor = true;
            this.buttonPort.Click += new System.EventHandler(this.buttonPort_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(306, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(867, 383);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PLOTS";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            chartArea1.BorderColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            legend1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.WhiteSmoke;
            legend1.HeaderSeparatorColor = System.Drawing.Color.WhiteSmoke;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.WhiteSmoke;
            legend1.Name = "Legend1";
            legend1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            legend1.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            legend1.TitleSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 18);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "C(s)";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series1.YValuesPerPoint = 2;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.DarkOrange;
            series2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            series2.Legend = "Legend1";
            series2.Name = "G(s)";
            series2.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(861, 363);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.groupBox4.Controls.Add(this.eliminar);
            this.groupBox4.Controls.Add(this.gaugeVelocity);
            this.groupBox4.Controls.Add(this.gaugeAngle);
            this.groupBox4.Controls.Add(this.lienzo);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(207, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(966, 440);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ANIMATION";
            // 
            // eliminar
            // 
            this.eliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eliminar.Location = new System.Drawing.Point(3, 18);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(960, 420);
            this.eliminar.TabIndex = 2;
            this.eliminar.TabStop = false;
            // 
            // gaugeVelocity
            // 
            this.gaugeVelocity.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeVelocity.BaseArcRadius = 150;
            this.gaugeVelocity.BaseArcStart = 135;
            this.gaugeVelocity.BaseArcSweep = 270;
            this.gaugeVelocity.BaseArcWidth = 2;
            this.gaugeVelocity.Center = new System.Drawing.Point(200, 200);
            this.gaugeVelocity.Location = new System.Drawing.Point(208, 17);
            this.gaugeVelocity.MaxValue = 5000F;
            this.gaugeVelocity.MinValue = 0F;
            this.gaugeVelocity.Name = "gaugeVelocity";
            this.gaugeVelocity.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.gaugeVelocity.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeVelocity.NeedleRadius = 150;
            this.gaugeVelocity.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.gaugeVelocity.NeedleWidth = 2;
            this.gaugeVelocity.ScaleLinesInterColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeVelocity.ScaleLinesInterInnerRadius = 140;
            this.gaugeVelocity.ScaleLinesInterOuterRadius = 150;
            this.gaugeVelocity.ScaleLinesInterWidth = 1;
            this.gaugeVelocity.ScaleLinesMajorColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeVelocity.ScaleLinesMajorInnerRadius = 140;
            this.gaugeVelocity.ScaleLinesMajorOuterRadius = 150;
            this.gaugeVelocity.ScaleLinesMajorStepValue = 500F;
            this.gaugeVelocity.ScaleLinesMajorWidth = 2;
            this.gaugeVelocity.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gaugeVelocity.ScaleLinesMinorInnerRadius = 140;
            this.gaugeVelocity.ScaleLinesMinorOuterRadius = 150;
            this.gaugeVelocity.ScaleLinesMinorTicks = 9;
            this.gaugeVelocity.ScaleLinesMinorWidth = 1;
            this.gaugeVelocity.ScaleNumbersColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeVelocity.ScaleNumbersFormat = null;
            this.gaugeVelocity.ScaleNumbersRadius = 170;
            this.gaugeVelocity.ScaleNumbersRotation = 0;
            this.gaugeVelocity.ScaleNumbersStartScaleLine = 0;
            this.gaugeVelocity.ScaleNumbersStepScaleLines = 1;
            this.gaugeVelocity.Size = new System.Drawing.Size(539, 423);
            this.gaugeVelocity.TabIndex = 1;
            this.gaugeVelocity.Text = "aGauge1";
            this.gaugeVelocity.Value = 0F;
            // 
            // gaugeAngle
            // 
            this.gaugeAngle.BaseArcColor = System.Drawing.Color.Gray;
            this.gaugeAngle.BaseArcRadius = 150;
            this.gaugeAngle.BaseArcStart = 180;
            this.gaugeAngle.BaseArcSweep = 180;
            this.gaugeAngle.BaseArcWidth = 2;
            this.gaugeAngle.Center = new System.Drawing.Point(200, 200);
            this.gaugeAngle.Location = new System.Drawing.Point(239, 19);
            this.gaugeAngle.MaxValue = 180F;
            this.gaugeAngle.MinValue = 0F;
            this.gaugeAngle.Name = "gaugeAngle";
            this.gaugeAngle.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.gaugeAngle.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gaugeAngle.NeedleRadius = 150;
            this.gaugeAngle.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.gaugeAngle.NeedleWidth = 2;
            this.gaugeAngle.ScaleLinesInterColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeAngle.ScaleLinesInterInnerRadius = 140;
            this.gaugeAngle.ScaleLinesInterOuterRadius = 150;
            this.gaugeAngle.ScaleLinesInterWidth = 1;
            this.gaugeAngle.ScaleLinesMajorColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeAngle.ScaleLinesMajorInnerRadius = 140;
            this.gaugeAngle.ScaleLinesMajorOuterRadius = 150;
            this.gaugeAngle.ScaleLinesMajorStepValue = 20F;
            this.gaugeAngle.ScaleLinesMajorWidth = 2;
            this.gaugeAngle.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gaugeAngle.ScaleLinesMinorInnerRadius = 140;
            this.gaugeAngle.ScaleLinesMinorOuterRadius = 150;
            this.gaugeAngle.ScaleLinesMinorTicks = 9;
            this.gaugeAngle.ScaleLinesMinorWidth = 1;
            this.gaugeAngle.ScaleNumbersColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeAngle.ScaleNumbersFormat = null;
            this.gaugeAngle.ScaleNumbersRadius = 170;
            this.gaugeAngle.ScaleNumbersRotation = 0;
            this.gaugeAngle.ScaleNumbersStartScaleLine = 0;
            this.gaugeAngle.ScaleNumbersStepScaleLines = 1;
            this.gaugeAngle.Size = new System.Drawing.Size(539, 423);
            this.gaugeAngle.TabIndex = 1;
            this.gaugeAngle.Text = "aGauge1";
            this.gaugeAngle.Value = 0F;
            // 
            // lienzo
            // 
            this.lienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lienzo.Location = new System.Drawing.Point(-120, 20);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(1175, 420);
            this.lienzo.TabIndex = 0;
            this.lienzo.TabStop = false;
            // 
            // lbl_ellipsePosX
            // 
            this.lbl_ellipsePosX.AutoSize = true;
            this.lbl_ellipsePosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ellipsePosX.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ellipsePosX.Location = new System.Drawing.Point(3, 60);
            this.lbl_ellipsePosX.Name = "lbl_ellipsePosX";
            this.lbl_ellipsePosX.Size = new System.Drawing.Size(180, 61);
            this.lbl_ellipsePosX.TabIndex = 20;
            this.lbl_ellipsePosX.Text = "-";
            this.lbl_ellipsePosX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Angle
            // 
            this.lbl_Angle.AutoSize = true;
            this.lbl_Angle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Angle.Location = new System.Drawing.Point(3, 72);
            this.lbl_Angle.Name = "lbl_Angle";
            this.lbl_Angle.Size = new System.Drawing.Size(180, 59);
            this.lbl_Angle.TabIndex = 18;
            this.lbl_Angle.Text = "-";
            this.lbl_Angle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.63462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.36538F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 843);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.8427F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.1573F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1176, 387);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.9322F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.73446F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(297, 381);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.7451F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.2549F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 130);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 49);
            this.label3.TabIndex = 7;
            this.label3.Text = "HILed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.49275F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.50725F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(285, 75);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::prueba.Properties.Resources.logo22;
            this.pictureBox1.Location = new System.Drawing.Point(101, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::prueba.Properties.Resources.logo12;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(92, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.groupBox5.Controls.Add(this.tableLayoutPanel7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(3, 256);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 122);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SYSTEM";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.buttonPort, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.cbx_system, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(285, 100);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // cbx_system
            // 
            this.cbx_system.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_system.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_system.FormattingEnabled = true;
            this.cbx_system.Items.AddRange(new object[] {
            "Ball & Beam",
            "Gear Motor",
            "Motor"});
            this.cbx_system.Location = new System.Drawing.Point(3, 2);
            this.cbx_system.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_system.Name = "cbx_system";
            this.cbx_system.Size = new System.Drawing.Size(136, 31);
            this.cbx_system.TabIndex = 2;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.37251F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.62749F));
            this.tableLayoutPanel10.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 396);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1176, 444);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.groupBox2.Controls.Add(this.tableLayoutPanel11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 438);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATA";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel13, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel14, 0, 2);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(192, 417);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.lbl_ctrl, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.lbl_Angle, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(186, 131);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // lbl_ctrl
            // 
            this.lbl_ctrl.AutoSize = true;
            this.lbl_ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ctrl.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ctrl.Location = new System.Drawing.Point(3, 0);
            this.lbl_ctrl.Name = "lbl_ctrl";
            this.lbl_ctrl.Size = new System.Drawing.Size(180, 72);
            this.lbl_ctrl.TabIndex = 15;
            this.lbl_ctrl.Text = "CONTROL SIGNAL";
            this.lbl_ctrl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Controls.Add(this.lbl_ellipsePosX, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.lbl_out, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 140);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(186, 121);
            this.tableLayoutPanel13.TabIndex = 3;
            // 
            // lbl_out
            // 
            this.lbl_out.AutoSize = true;
            this.lbl_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_out.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_out.Location = new System.Drawing.Point(3, 0);
            this.lbl_out.Name = "lbl_out";
            this.lbl_out.Size = new System.Drawing.Size(180, 60);
            this.lbl_out.TabIndex = 19;
            this.lbl_out.Text = "CONTROLLED SIGNAL";
            this.lbl_out.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.45029F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.00585F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.12865F));
            this.tableLayoutPanel14.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 267);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 3;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.97297F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.05405F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.64865F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(186, 147);
            this.tableLayoutPanel14.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(27, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 72);
            this.button1.TabIndex = 2;
            this.button1.Text = "ESPORT CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1182, 843);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 890);
            this.MinimumSize = new System.Drawing.Size(1200, 890);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HILed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button BtnBuscarPuertos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lbl_Angle;
        private System.Windows.Forms.Label lbl_ellipsePosX;
        private System.Windows.Forms.PictureBox lienzo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label lbl_ctrl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label lbl_out;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.ComboBox cbx_system;
        private System.Windows.Forms.PictureBox eliminar;
        private System.Windows.Forms.AGauge gaugeAngle;
        private System.Windows.Forms.AGauge gaugeVelocity;
    }
}

