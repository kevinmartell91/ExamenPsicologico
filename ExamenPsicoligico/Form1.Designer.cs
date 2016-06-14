namespace ExamenPsicoligico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.ibCanny = new Emgu.CV.UI.ImageBox();
            this.ibHoughCircles = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBlueMax = new System.Windows.Forms.TrackBar();
            this.tbGreenMax = new System.Windows.Forms.TrackBar();
            this.tbRedMax = new System.Windows.Forms.TrackBar();
            this.lbBlueMax = new System.Windows.Forms.Label();
            this.lbGreenMax = new System.Windows.Forms.Label();
            this.lbRedMax = new System.Windows.Forms.Label();
            this.lbRedMin = new System.Windows.Forms.Label();
            this.lbGreenMin = new System.Windows.Forms.Label();
            this.lbBlueMin = new System.Windows.Forms.Label();
            this.tbRedMin = new System.Windows.Forms.TrackBar();
            this.tbGreenMin = new System.Windows.Forms.TrackBar();
            this.tbBlueMin = new System.Windows.Forms.TrackBar();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalScanedPapers = new System.Windows.Forms.TextBox();
            this.txtTotalApplicants = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbThrehLinking = new System.Windows.Forms.Label();
            this.tbThrehLinking = new System.Windows.Forms.TrackBar();
            this.tbThresh = new System.Windows.Forms.TrackBar();
            this.lbThresh = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbAcummulatorThrehold = new System.Windows.Forms.Label();
            this.tbAccumulatorThreshold = new System.Windows.Forms.TrackBar();
            this.tbCannyThreshold = new System.Windows.Forms.TrackBar();
            this.lbCannyThreshold = new System.Windows.Forms.Label();
            this.ibHoughCircles2 = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtTotalCircles = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMaxRadio = new System.Windows.Forms.GroupBox();
            this.lbMaxRadioo = new System.Windows.Forms.Label();
            this.lbMinRadio = new System.Windows.Forms.Label();
            this.lbMinDist = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMaxRadio = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMinRadio = new System.Windows.Forms.TrackBar();
            this.tbMindistBtwCir = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.rbAnalizeAll = new System.Windows.Forms.RadioButton();
            this.rbAnalizeOneByOne = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbColorPen2B = new System.Windows.Forms.RadioButton();
            this.rbColorBlack = new System.Windows.Forms.RadioButton();
            this.rbColorRed = new System.Windows.Forms.RadioButton();
            this.rbColorBlue = new System.Windows.Forms.RadioButton();
            this.tbThresholdBinary_Min = new System.Windows.Forms.TrackBar();
            this.lbThresholdBinary_Min = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbThresholdBinary_Max = new System.Windows.Forms.Label();
            this.tbThresholdBinary_Max = new System.Windows.Forms.TrackBar();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pbGood = new System.Windows.Forms.PictureBox();
            this.pbBad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibCanny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibHoughCircles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueMin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThrehLinking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresh)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAccumulatorThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCannyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibHoughCircles2)).BeginInit();
            this.lbMaxRadio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMindistBtwCir)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresholdBinary_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresholdBinary_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBad)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.Location = new System.Drawing.Point(282, 385);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(169, 146);
            this.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            this.ibOriginal.Visible = false;
            // 
            // ibCanny
            // 
            this.ibCanny.Location = new System.Drawing.Point(336, 40);
            this.ibCanny.Name = "ibCanny";
            this.ibCanny.Size = new System.Drawing.Size(320, 416);
            this.ibCanny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibCanny.TabIndex = 5;
            this.ibCanny.TabStop = false;
            this.ibCanny.Visible = false;
            // 
            // ibHoughCircles
            // 
            this.ibHoughCircles.Location = new System.Drawing.Point(658, 39);
            this.ibHoughCircles.Name = "ibHoughCircles";
            this.ibHoughCircles.Size = new System.Drawing.Size(320, 416);
            this.ibHoughCircles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibHoughCircles.TabIndex = 8;
            this.ibHoughCircles.TabStop = false;
            this.ibHoughCircles.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Voluntades OMR";
            this.label1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(333, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Test número : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(658, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Result 1 - HoughCircles";
            this.label7.Visible = false;
            // 
            // tbBlueMax
            // 
            this.tbBlueMax.Location = new System.Drawing.Point(47, 53);
            this.tbBlueMax.Maximum = 255;
            this.tbBlueMax.Name = "tbBlueMax";
            this.tbBlueMax.Size = new System.Drawing.Size(82, 45);
            this.tbBlueMax.TabIndex = 20;
            this.tbBlueMax.Scroll += new System.EventHandler(this.tbBlueMax_Scroll);
            // 
            // tbGreenMax
            // 
            this.tbGreenMax.Location = new System.Drawing.Point(47, 53);
            this.tbGreenMax.Maximum = 255;
            this.tbGreenMax.Name = "tbGreenMax";
            this.tbGreenMax.Size = new System.Drawing.Size(93, 45);
            this.tbGreenMax.TabIndex = 21;
            this.tbGreenMax.Scroll += new System.EventHandler(this.tbGreenMax_Scroll);
            // 
            // tbRedMax
            // 
            this.tbRedMax.Location = new System.Drawing.Point(47, 48);
            this.tbRedMax.Maximum = 255;
            this.tbRedMax.Name = "tbRedMax";
            this.tbRedMax.Size = new System.Drawing.Size(94, 45);
            this.tbRedMax.TabIndex = 22;
            this.tbRedMax.Scroll += new System.EventHandler(this.tbRedMax_Scroll);
            // 
            // lbBlueMax
            // 
            this.lbBlueMax.AutoSize = true;
            this.lbBlueMax.Location = new System.Drawing.Point(6, 59);
            this.lbBlueMax.Name = "lbBlueMax";
            this.lbBlueMax.Size = new System.Drawing.Size(41, 13);
            this.lbBlueMax.TabIndex = 23;
            this.lbBlueMax.Text = "label10";
            // 
            // lbGreenMax
            // 
            this.lbGreenMax.AutoSize = true;
            this.lbGreenMax.Location = new System.Drawing.Point(6, 59);
            this.lbGreenMax.Name = "lbGreenMax";
            this.lbGreenMax.Size = new System.Drawing.Size(41, 13);
            this.lbGreenMax.TabIndex = 24;
            this.lbGreenMax.Text = "label11";
            // 
            // lbRedMax
            // 
            this.lbRedMax.AutoSize = true;
            this.lbRedMax.Location = new System.Drawing.Point(6, 53);
            this.lbRedMax.Name = "lbRedMax";
            this.lbRedMax.Size = new System.Drawing.Size(41, 13);
            this.lbRedMax.TabIndex = 25;
            this.lbRedMax.Text = "label12";
            // 
            // lbRedMin
            // 
            this.lbRedMin.AutoSize = true;
            this.lbRedMin.Location = new System.Drawing.Point(6, 19);
            this.lbRedMin.Name = "lbRedMin";
            this.lbRedMin.Size = new System.Drawing.Size(35, 13);
            this.lbRedMin.TabIndex = 31;
            this.lbRedMin.Text = "label2";
            // 
            // lbGreenMin
            // 
            this.lbGreenMin.AutoSize = true;
            this.lbGreenMin.Location = new System.Drawing.Point(6, 25);
            this.lbGreenMin.Name = "lbGreenMin";
            this.lbGreenMin.Size = new System.Drawing.Size(35, 13);
            this.lbGreenMin.TabIndex = 30;
            this.lbGreenMin.Text = "label5";
            // 
            // lbBlueMin
            // 
            this.lbBlueMin.AutoSize = true;
            this.lbBlueMin.Location = new System.Drawing.Point(6, 19);
            this.lbBlueMin.Name = "lbBlueMin";
            this.lbBlueMin.Size = new System.Drawing.Size(35, 13);
            this.lbBlueMin.TabIndex = 29;
            this.lbBlueMin.Text = "label6";
            // 
            // tbRedMin
            // 
            this.tbRedMin.Location = new System.Drawing.Point(47, 19);
            this.tbRedMin.Maximum = 255;
            this.tbRedMin.Name = "tbRedMin";
            this.tbRedMin.Size = new System.Drawing.Size(94, 45);
            this.tbRedMin.TabIndex = 28;
            this.tbRedMin.Scroll += new System.EventHandler(this.tbRedMin_Scroll);
            // 
            // tbGreenMin
            // 
            this.tbGreenMin.Location = new System.Drawing.Point(47, 19);
            this.tbGreenMin.Maximum = 255;
            this.tbGreenMin.Name = "tbGreenMin";
            this.tbGreenMin.Size = new System.Drawing.Size(93, 45);
            this.tbGreenMin.TabIndex = 27;
            this.tbGreenMin.Scroll += new System.EventHandler(this.tbGreenMin_Scroll);
            // 
            // tbBlueMin
            // 
            this.tbBlueMin.Location = new System.Drawing.Point(47, 19);
            this.tbBlueMin.Maximum = 255;
            this.tbBlueMin.Name = "tbBlueMin";
            this.tbBlueMin.Size = new System.Drawing.Size(82, 45);
            this.tbBlueMin.TabIndex = 26;
            this.tbBlueMin.Scroll += new System.EventHandler(this.tbBlueMin_Scroll);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.Location = new System.Drawing.Point(50, 32);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(76, 26);
            this.btnOpenFile.TabIndex = 32;
            this.btnOpenFile.Text = "Abrir";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(507, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 68);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1)  Cargar test";
            // 
            // txtTotalScanedPapers
            // 
            this.txtTotalScanedPapers.Location = new System.Drawing.Point(441, 686);
            this.txtTotalScanedPapers.Name = "txtTotalScanedPapers";
            this.txtTotalScanedPapers.Size = new System.Drawing.Size(38, 20);
            this.txtTotalScanedPapers.TabIndex = 38;
            this.txtTotalScanedPapers.Visible = false;
            // 
            // txtTotalApplicants
            // 
            this.txtTotalApplicants.Location = new System.Drawing.Point(10, 50);
            this.txtTotalApplicants.Name = "txtTotalApplicants";
            this.txtTotalApplicants.Size = new System.Drawing.Size(38, 20);
            this.txtTotalApplicants.TabIndex = 37;
            this.txtTotalApplicants.TextChanged += new System.EventHandler(this.txtTotalApplicants_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 693);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Total de hojas";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 663);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 30;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(231, 702);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(59, 23);
            this.btnPause.TabIndex = 35;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(170, 678);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(76, 17);
            this.rbFile.TabIndex = 34;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "Open a file";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.Visible = false;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Location = new System.Drawing.Point(170, 706);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(55, 17);
            this.rbVideo.TabIndex = 33;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "Video ";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.Visible = false;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(18, 462);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 130);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BGR Calibration";
            this.groupBox2.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbRedMax);
            this.groupBox5.Controls.Add(this.tbRedMax);
            this.groupBox5.Controls.Add(this.tbRedMin);
            this.groupBox5.Controls.Add(this.lbRedMin);
            this.groupBox5.Location = new System.Drawing.Point(304, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(152, 99);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Red";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbGreenMax);
            this.groupBox4.Controls.Add(this.lbGreenMin);
            this.groupBox4.Controls.Add(this.lbGreenMax);
            this.groupBox4.Controls.Add(this.tbGreenMin);
            this.groupBox4.Location = new System.Drawing.Point(152, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 99);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Green";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbBlueMax);
            this.groupBox3.Controls.Add(this.tbBlueMin);
            this.groupBox3.Controls.Add(this.lbBlueMin);
            this.groupBox3.Controls.Add(this.lbBlueMax);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 99);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blue";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbThrehLinking);
            this.groupBox6.Controls.Add(this.tbThrehLinking);
            this.groupBox6.Controls.Add(this.tbThresh);
            this.groupBox6.Controls.Add(this.lbThresh);
            this.groupBox6.Location = new System.Drawing.Point(507, 462);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(146, 99);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Canny Calibration";
            this.groupBox6.Visible = false;
            // 
            // lbThrehLinking
            // 
            this.lbThrehLinking.AutoSize = true;
            this.lbThrehLinking.Location = new System.Drawing.Point(6, 53);
            this.lbThrehLinking.Name = "lbThrehLinking";
            this.lbThrehLinking.Size = new System.Drawing.Size(41, 13);
            this.lbThrehLinking.TabIndex = 25;
            this.lbThrehLinking.Text = "label12";
            // 
            // tbThrehLinking
            // 
            this.tbThrehLinking.Location = new System.Drawing.Point(47, 48);
            this.tbThrehLinking.Maximum = 500;
            this.tbThrehLinking.Minimum = 1;
            this.tbThrehLinking.Name = "tbThrehLinking";
            this.tbThrehLinking.Size = new System.Drawing.Size(96, 45);
            this.tbThrehLinking.TabIndex = 22;
            this.tbThrehLinking.Value = 1;
            this.tbThrehLinking.Scroll += new System.EventHandler(this.tbThrehLinking_Scroll);
            // 
            // tbThresh
            // 
            this.tbThresh.Location = new System.Drawing.Point(47, 19);
            this.tbThresh.Maximum = 300;
            this.tbThresh.Minimum = 1;
            this.tbThresh.Name = "tbThresh";
            this.tbThresh.Size = new System.Drawing.Size(96, 45);
            this.tbThresh.TabIndex = 28;
            this.tbThresh.Value = 1;
            this.tbThresh.Scroll += new System.EventHandler(this.tbThresh_Scroll);
            // 
            // lbThresh
            // 
            this.lbThresh.AutoSize = true;
            this.lbThresh.Location = new System.Drawing.Point(7, 19);
            this.lbThresh.Name = "lbThresh";
            this.lbThresh.Size = new System.Drawing.Size(35, 13);
            this.lbThresh.TabIndex = 31;
            this.lbThresh.Text = "label2";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbAcummulatorThrehold);
            this.groupBox7.Controls.Add(this.tbAccumulatorThreshold);
            this.groupBox7.Controls.Add(this.tbCannyThreshold);
            this.groupBox7.Controls.Add(this.lbCannyThreshold);
            this.groupBox7.Controls.Add(this.txtTotalApplicants);
            this.groupBox7.Location = new System.Drawing.Point(507, 567);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(146, 94);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "HoughCircles Calibration";
            this.groupBox7.Visible = false;
            // 
            // lbAcummulatorThrehold
            // 
            this.lbAcummulatorThrehold.AutoSize = true;
            this.lbAcummulatorThrehold.Location = new System.Drawing.Point(6, 53);
            this.lbAcummulatorThrehold.Name = "lbAcummulatorThrehold";
            this.lbAcummulatorThrehold.Size = new System.Drawing.Size(41, 13);
            this.lbAcummulatorThrehold.TabIndex = 25;
            this.lbAcummulatorThrehold.Text = "label12";
            // 
            // tbAccumulatorThreshold
            // 
            this.tbAccumulatorThreshold.Location = new System.Drawing.Point(47, 48);
            this.tbAccumulatorThreshold.Maximum = 255;
            this.tbAccumulatorThreshold.Minimum = 1;
            this.tbAccumulatorThreshold.Name = "tbAccumulatorThreshold";
            this.tbAccumulatorThreshold.Size = new System.Drawing.Size(96, 45);
            this.tbAccumulatorThreshold.TabIndex = 22;
            this.tbAccumulatorThreshold.Value = 1;
            this.tbAccumulatorThreshold.Scroll += new System.EventHandler(this.tbAccumulatorThreshold_Scroll);
            // 
            // tbCannyThreshold
            // 
            this.tbCannyThreshold.Location = new System.Drawing.Point(47, 19);
            this.tbCannyThreshold.Maximum = 255;
            this.tbCannyThreshold.Minimum = 1;
            this.tbCannyThreshold.Name = "tbCannyThreshold";
            this.tbCannyThreshold.Size = new System.Drawing.Size(96, 45);
            this.tbCannyThreshold.TabIndex = 28;
            this.tbCannyThreshold.Value = 1;
            this.tbCannyThreshold.Scroll += new System.EventHandler(this.tbCannyThreshold_Scroll);
            // 
            // lbCannyThreshold
            // 
            this.lbCannyThreshold.AutoSize = true;
            this.lbCannyThreshold.Location = new System.Drawing.Point(6, 19);
            this.lbCannyThreshold.Name = "lbCannyThreshold";
            this.lbCannyThreshold.Size = new System.Drawing.Size(35, 13);
            this.lbCannyThreshold.TabIndex = 31;
            this.lbCannyThreshold.Text = "label2";
            // 
            // ibHoughCircles2
            // 
            this.ibHoughCircles2.Location = new System.Drawing.Point(979, 39);
            this.ibHoughCircles2.Name = "ibHoughCircles2";
            this.ibHoughCircles2.Size = new System.Drawing.Size(320, 416);
            this.ibHoughCircles2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibHoughCircles2.TabIndex = 40;
            this.ibHoughCircles2.TabStop = false;
            this.ibHoughCircles2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(980, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Result2 - Second Iteration";
            this.label2.Visible = false;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(1017, 567);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(319, 92);
            this.txtResult.TabIndex = 42;
            // 
            // txtTotalCircles
            // 
            this.txtTotalCircles.Location = new System.Drawing.Point(1104, 465);
            this.txtTotalCircles.Name = "txtTotalCircles";
            this.txtTotalCircles.Size = new System.Drawing.Size(77, 20);
            this.txtTotalCircles.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1017, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Total circles";
            // 
            // lbMaxRadio
            // 
            this.lbMaxRadio.Controls.Add(this.lbMaxRadioo);
            this.lbMaxRadio.Controls.Add(this.lbMinRadio);
            this.lbMaxRadio.Controls.Add(this.lbMinDist);
            this.lbMaxRadio.Controls.Add(this.label10);
            this.lbMaxRadio.Controls.Add(this.tbMaxRadio);
            this.lbMaxRadio.Controls.Add(this.label8);
            this.lbMaxRadio.Controls.Add(this.tbMinRadio);
            this.lbMaxRadio.Controls.Add(this.tbMindistBtwCir);
            this.lbMaxRadio.Controls.Add(this.label9);
            this.lbMaxRadio.Location = new System.Drawing.Point(661, 534);
            this.lbMaxRadio.Name = "lbMaxRadio";
            this.lbMaxRadio.Size = new System.Drawing.Size(177, 126);
            this.lbMaxRadio.TabIndex = 40;
            this.lbMaxRadio.TabStop = false;
            this.lbMaxRadio.Text = "Circles Calibration";
            this.lbMaxRadio.Visible = false;
            // 
            // lbMaxRadioo
            // 
            this.lbMaxRadioo.AutoSize = true;
            this.lbMaxRadioo.Location = new System.Drawing.Point(159, 85);
            this.lbMaxRadioo.Name = "lbMaxRadioo";
            this.lbMaxRadioo.Size = new System.Drawing.Size(15, 13);
            this.lbMaxRadioo.TabIndex = 36;
            this.lbMaxRadioo.Text = "N";
            // 
            // lbMinRadio
            // 
            this.lbMinRadio.AutoSize = true;
            this.lbMinRadio.Location = new System.Drawing.Point(159, 53);
            this.lbMinRadio.Name = "lbMinRadio";
            this.lbMinRadio.Size = new System.Drawing.Size(15, 13);
            this.lbMinRadio.TabIndex = 34;
            this.lbMinRadio.Text = "N";
            // 
            // lbMinDist
            // 
            this.lbMinDist.AutoSize = true;
            this.lbMinDist.Location = new System.Drawing.Point(159, 23);
            this.lbMinDist.Name = "lbMinDist";
            this.lbMinDist.Size = new System.Drawing.Size(15, 13);
            this.lbMinDist.TabIndex = 35;
            this.lbMinDist.Text = "N";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Max Radio";
            // 
            // tbMaxRadio
            // 
            this.tbMaxRadio.Location = new System.Drawing.Point(66, 80);
            this.tbMaxRadio.Maximum = 255;
            this.tbMaxRadio.Minimum = 1;
            this.tbMaxRadio.Name = "tbMaxRadio";
            this.tbMaxRadio.Size = new System.Drawing.Size(96, 45);
            this.tbMaxRadio.TabIndex = 32;
            this.tbMaxRadio.Value = 1;
            this.tbMaxRadio.Scroll += new System.EventHandler(this.tbMaxRadio_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Min Radio";
            // 
            // tbMinRadio
            // 
            this.tbMinRadio.Location = new System.Drawing.Point(66, 48);
            this.tbMinRadio.Maximum = 255;
            this.tbMinRadio.Minimum = 1;
            this.tbMinRadio.Name = "tbMinRadio";
            this.tbMinRadio.Size = new System.Drawing.Size(96, 45);
            this.tbMinRadio.TabIndex = 22;
            this.tbMinRadio.Value = 1;
            this.tbMinRadio.Scroll += new System.EventHandler(this.tbMinRadio_Scroll);
            // 
            // tbMindistBtwCir
            // 
            this.tbMindistBtwCir.Location = new System.Drawing.Point(66, 19);
            this.tbMindistBtwCir.Maximum = 255;
            this.tbMindistBtwCir.Minimum = 1;
            this.tbMindistBtwCir.Name = "tbMindistBtwCir";
            this.tbMindistBtwCir.Size = new System.Drawing.Size(96, 45);
            this.tbMindistBtwCir.TabIndex = 28;
            this.tbMindistBtwCir.Value = 1;
            this.tbMindistBtwCir.Scroll += new System.EventHandler(this.tbMindistBtwCir_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Min dist btw cir";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(362, 704);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Code:";
            this.label12.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(403, 701);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(82, 20);
            this.txtCode.TabIndex = 45;
            this.txtCode.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(318, 643);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 46;
            this.btnPreview.Text = "<<";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(406, 643);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 47;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // rbAnalizeAll
            // 
            this.rbAnalizeAll.AutoSize = true;
            this.rbAnalizeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnalizeAll.Location = new System.Drawing.Point(36, 32);
            this.rbAnalizeAll.Name = "rbAnalizeAll";
            this.rbAnalizeAll.Size = new System.Drawing.Size(120, 21);
            this.rbAnalizeAll.TabIndex = 40;
            this.rbAnalizeAll.TabStop = true;
            this.rbAnalizeAll.Text = "Corregir todos ";
            this.rbAnalizeAll.UseVisualStyleBackColor = true;
            this.rbAnalizeAll.CheckedChanged += new System.EventHandler(this.rbAnalizeAll_CheckedChanged);
            // 
            // rbAnalizeOneByOne
            // 
            this.rbAnalizeOneByOne.AutoSize = true;
            this.rbAnalizeOneByOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnalizeOneByOne.Location = new System.Drawing.Point(162, 32);
            this.rbAnalizeOneByOne.Name = "rbAnalizeOneByOne";
            this.rbAnalizeOneByOne.Size = new System.Drawing.Size(145, 21);
            this.rbAnalizeOneByOne.TabIndex = 39;
            this.rbAnalizeOneByOne.TabStop = true;
            this.rbAnalizeOneByOne.Text = "Corregir uno a uno";
            this.rbAnalizeOneByOne.UseVisualStyleBackColor = true;
            this.rbAnalizeOneByOne.CheckedChanged += new System.EventHandler(this.rbAnalizeOneByOne_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbAnalizeAll);
            this.groupBox8.Controls.Add(this.rbAnalizeOneByOne);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(658, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(322, 65);
            this.groupBox8.TabIndex = 48;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "2)  Elegir modo del correción ";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbColorPen2B);
            this.groupBox9.Controls.Add(this.rbColorBlack);
            this.groupBox9.Controls.Add(this.rbColorRed);
            this.groupBox9.Controls.Add(this.rbColorBlue);
            this.groupBox9.Location = new System.Drawing.Point(661, 468);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(177, 60);
            this.groupBox9.TabIndex = 49;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Colors to track";
            this.groupBox9.Visible = false;
            // 
            // rbColorPen2B
            // 
            this.rbColorPen2B.AutoSize = true;
            this.rbColorPen2B.Location = new System.Drawing.Point(99, 38);
            this.rbColorPen2B.Name = "rbColorPen2B";
            this.rbColorPen2B.Size = new System.Drawing.Size(44, 17);
            this.rbColorPen2B.TabIndex = 42;
            this.rbColorPen2B.TabStop = true;
            this.rbColorPen2B.Text = "Pen";
            this.rbColorPen2B.UseVisualStyleBackColor = true;
            this.rbColorPen2B.CheckedChanged += new System.EventHandler(this.rbColorPen2B_CheckedChanged);
            // 
            // rbColorBlack
            // 
            this.rbColorBlack.AutoSize = true;
            this.rbColorBlack.Location = new System.Drawing.Point(99, 17);
            this.rbColorBlack.Name = "rbColorBlack";
            this.rbColorBlack.Size = new System.Drawing.Size(52, 17);
            this.rbColorBlack.TabIndex = 41;
            this.rbColorBlack.TabStop = true;
            this.rbColorBlack.Text = "Black";
            this.rbColorBlack.UseVisualStyleBackColor = true;
            this.rbColorBlack.CheckedChanged += new System.EventHandler(this.rbColorBlack_CheckedChanged);
            // 
            // rbColorRed
            // 
            this.rbColorRed.AutoSize = true;
            this.rbColorRed.Location = new System.Drawing.Point(35, 36);
            this.rbColorRed.Name = "rbColorRed";
            this.rbColorRed.Size = new System.Drawing.Size(45, 17);
            this.rbColorRed.TabIndex = 40;
            this.rbColorRed.TabStop = true;
            this.rbColorRed.Text = "Red";
            this.rbColorRed.UseVisualStyleBackColor = true;
            this.rbColorRed.CheckedChanged += new System.EventHandler(this.rbColorRed_CheckedChanged);
            // 
            // rbColorBlue
            // 
            this.rbColorBlue.AutoSize = true;
            this.rbColorBlue.Location = new System.Drawing.Point(35, 17);
            this.rbColorBlue.Name = "rbColorBlue";
            this.rbColorBlue.Size = new System.Drawing.Size(46, 17);
            this.rbColorBlue.TabIndex = 39;
            this.rbColorBlue.TabStop = true;
            this.rbColorBlue.Text = "Blue";
            this.rbColorBlue.UseVisualStyleBackColor = true;
            this.rbColorBlue.CheckedChanged += new System.EventHandler(this.rbColorBlue_CheckedChanged);
            // 
            // tbThresholdBinary_Min
            // 
            this.tbThresholdBinary_Min.Location = new System.Drawing.Point(844, 545);
            this.tbThresholdBinary_Min.Maximum = 255;
            this.tbThresholdBinary_Min.Name = "tbThresholdBinary_Min";
            this.tbThresholdBinary_Min.Size = new System.Drawing.Size(167, 45);
            this.tbThresholdBinary_Min.TabIndex = 50;
            this.tbThresholdBinary_Min.Visible = false;
            this.tbThresholdBinary_Min.Scroll += new System.EventHandler(this.tbThresholdBinary_Min_Scroll);
            // 
            // lbThresholdBinary_Min
            // 
            this.lbThresholdBinary_Min.AutoSize = true;
            this.lbThresholdBinary_Min.Location = new System.Drawing.Point(844, 529);
            this.lbThresholdBinary_Min.Name = "lbThresholdBinary_Min";
            this.lbThresholdBinary_Min.Size = new System.Drawing.Size(54, 13);
            this.lbThresholdBinary_Min.TabIndex = 51;
            this.lbThresholdBinary_Min.Text = "Threshold";
            this.lbThresholdBinary_Min.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(866, 500);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "Thresholdbinary";
            this.label13.Visible = false;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(1245, 39);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(103, 128);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 53;
            this.imageBox1.TabStop = false;
            this.imageBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 20;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(507, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(829, 599);
            this.dataGridView1.TabIndex = 54;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbThresholdBinary_Max
            // 
            this.lbThresholdBinary_Max.AutoSize = true;
            this.lbThresholdBinary_Max.Location = new System.Drawing.Point(844, 579);
            this.lbThresholdBinary_Max.Name = "lbThresholdBinary_Max";
            this.lbThresholdBinary_Max.Size = new System.Drawing.Size(91, 13);
            this.lbThresholdBinary_Max.TabIndex = 56;
            this.lbThresholdBinary_Max.Text = "Threshold Linking";
            this.lbThresholdBinary_Max.Visible = false;
            // 
            // tbThresholdBinary_Max
            // 
            this.tbThresholdBinary_Max.Location = new System.Drawing.Point(844, 596);
            this.tbThresholdBinary_Max.Maximum = 255;
            this.tbThresholdBinary_Max.Name = "tbThresholdBinary_Max";
            this.tbThresholdBinary_Max.Size = new System.Drawing.Size(167, 45);
            this.tbThresholdBinary_Max.TabIndex = 55;
            this.tbThresholdBinary_Max.Visible = false;
            this.tbThresholdBinary_Max.Scroll += new System.EventHandler(this.tbThresholdBinary_Max_Scroll);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(12, 666);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(320, 427);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 57;
            this.imageBox2.TabStop = false;
            this.imageBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(489, 679);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.Crimson;
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.ForeColor = System.Drawing.Color.White;
            this.btnInit.Location = new System.Drawing.Point(43, 29);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(79, 26);
            this.btnInit.TabIndex = 59;
            this.btnInit.Text = "Iniciar";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(441, 348);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnInit);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(986, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(137, 65);
            this.groupBox10.TabIndex = 60;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "3)  Corregir";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(116, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 26);
            this.button1.TabIndex = 61;
            this.button1.Text = "Copiar datos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button1);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(1129, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(207, 65);
            this.groupBox11.TabIndex = 61;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "3)  Seleccione y copie";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Chocolate;
            this.label11.Location = new System.Drawing.Point(352, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 65);
            this.label11.TabIndex = 62;
            this.label11.Text = "ORM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(26, 401);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 35);
            this.label14.TabIndex = 63;
            this.label14.Text = "Instrucciones";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.label15.Location = new System.Drawing.Point(30, 447);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(453, 187);
            this.label15.TabIndex = 64;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // pbGood
            // 
            this.pbGood.Image = ((System.Drawing.Image)(resources.GetObject("pbGood.Image")));
            this.pbGood.Location = new System.Drawing.Point(444, 10);
            this.pbGood.Name = "pbGood";
            this.pbGood.Size = new System.Drawing.Size(50, 50);
            this.pbGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGood.TabIndex = 65;
            this.pbGood.TabStop = false;
            this.pbGood.Visible = false;
            // 
            // pbBad
            // 
            this.pbBad.Image = ((System.Drawing.Image)(resources.GetObject("pbBad.Image")));
            this.pbBad.Location = new System.Drawing.Point(444, 10);
            this.pbBad.Name = "pbBad";
            this.pbBad.Size = new System.Drawing.Size(50, 50);
            this.pbBad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBad.TabIndex = 66;
            this.pbBad.TabStop = false;
            this.pbBad.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1268, 691);
            this.Controls.Add(this.ibOriginal);
            this.Controls.Add(this.pbGood);
            this.Controls.Add(this.pbBad);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtTotalScanedPapers);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.rbFile);
            this.Controls.Add(this.rbVideo);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.lbThresholdBinary_Max);
            this.Controls.Add(this.tbThresholdBinary_Max);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbThresholdBinary_Min);
            this.Controls.Add(this.tbThresholdBinary_Min);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lbMaxRadio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalCircles);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ibHoughCircles);
            this.Controls.Add(this.ibHoughCircles2);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.ibCanny);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voluntades OMR";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibCanny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibHoughCircles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueMin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThrehLinking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresh)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAccumulatorThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCannyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibHoughCircles2)).EndInit();
            this.lbMaxRadio.ResumeLayout(false);
            this.lbMaxRadio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMindistBtwCir)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresholdBinary_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbThresholdBinary_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private Emgu.CV.UI.ImageBox ibCanny;
        private Emgu.CV.UI.ImageBox ibHoughCircles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbBlueMax;
        private System.Windows.Forms.TrackBar tbGreenMax;
        private System.Windows.Forms.TrackBar tbRedMax;
        private System.Windows.Forms.Label lbBlueMax;
        private System.Windows.Forms.Label lbGreenMax;
        private System.Windows.Forms.Label lbRedMax;
        private System.Windows.Forms.Label lbRedMin;
        private System.Windows.Forms.Label lbGreenMin;
        private System.Windows.Forms.Label lbBlueMin;
        private System.Windows.Forms.TrackBar tbRedMin;
        private System.Windows.Forms.TrackBar tbGreenMin;
        private System.Windows.Forms.TrackBar tbBlueMin;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbThrehLinking;
        private System.Windows.Forms.TrackBar tbThrehLinking;
        private System.Windows.Forms.TrackBar tbThresh;
        private System.Windows.Forms.Label lbThresh;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lbAcummulatorThrehold;
        private System.Windows.Forms.TrackBar tbAccumulatorThreshold;
        private System.Windows.Forms.TrackBar tbCannyThreshold;
        private System.Windows.Forms.Label lbCannyThreshold;
        private Emgu.CV.UI.ImageBox ibHoughCircles2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtTotalScanedPapers;
        private System.Windows.Forms.TextBox txtTotalApplicants;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalCircles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox lbMaxRadio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tbMaxRadio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbMinRadio;
        private System.Windows.Forms.TrackBar tbMindistBtwCir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbMaxRadioo;
        private System.Windows.Forms.Label lbMinRadio;
        private System.Windows.Forms.Label lbMinDist;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.RadioButton rbAnalizeAll;
        private System.Windows.Forms.RadioButton rbAnalizeOneByOne;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbColorPen2B;
        private System.Windows.Forms.RadioButton rbColorBlack;
        private System.Windows.Forms.RadioButton rbColorRed;
        private System.Windows.Forms.RadioButton rbColorBlue;
        private System.Windows.Forms.TrackBar tbThresholdBinary_Min;
        private System.Windows.Forms.Label lbThresholdBinary_Min;
        private System.Windows.Forms.Label label13;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbThresholdBinary_Max;
        private System.Windows.Forms.TrackBar tbThresholdBinary_Max;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pbGood;
        private System.Windows.Forms.PictureBox pbBad;
    }
}

