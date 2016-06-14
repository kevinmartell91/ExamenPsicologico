using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace ExamenPsicoligico
{
    public partial class Form1 : Form
    {

        #region Image procesing declarations


        Capture capWebCam;
        OpenFileDialog open;
        List<Image<Bgr, Byte>> images;
        List<String> imagesNames; 
        Image<Bgr, Byte> imgInputFrame;
        Image<Gray, Byte> imgProcessed;
        Image<Gray, Byte> imgProcessedCanny;
        Image<Bgr, Byte> imgProcessedHoughCircle;
        Image<Bgr, Byte> imgProcessedHoughCircle2;
        //Image<Gray, Byte> imgProcessedHoughCircle2;
        int B_MIN, B_MAX;
        int G_MIN, G_MAX;
        int R_MIN, R_MAX;
        int THRESHOLD_BINARY_MIN;
        int THRESHOLD_BINARY_MAX;

        int DYNAMIC_VALUE;
        int OPTION;
        int LECTURE_MODE, PAGE, PICK_COLOR;

        int THRESH, THRESH_LINKING;
        int CANNY_THRESHOLD, ACUMMULATOR_THRESHOLD;

        bool Pause;
        bool BeginProcess;
        bool allProcessed;

        int ID_SEQUENCE;
        int TOTAL_APPLICANTS;
        int TOTAL_SCANNED_PAPERS;

        int MIN_RADIO;
        int MAX_RADIO;
        Double MIN_DIST;

        List<Question> questions;
        List<Applicant> applicants;

        List<List<CircleF>> lsMarkedAnswersPlusCode;
        List<List<CircleF>> lsAnswersCompleted;


        int codeNumber;

        int opcion_01;
        int opcion_02;
        int codigo_sede;
        int num_01;
        int num_02;
        int codigo_semestre;
        int codigo_turno;

        LineSegment2D HorizontalMiddleLine;
        MCvScalar scalar;
        Bgr color;


        //
        int horizontalDesfase_Y_1;
        int horizontalDesfase_Y_2;
        int horizontalDesfase_Y_3;
        int horizontalDesfase_Y_4;
        int horizontalDesfase_Y_5;
        int horizontalDesfase_Y_6;
        int horizontalDesfase_Y_7;

        public void InitializeOpenFileDialog()
        {
            open = new OpenFileDialog();

            open.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                          "All files (*.*)|*.*";

            open.Multiselect = true;
            open.Title = "Seleccione";
        }

        #region Initialization color configuration

        private void inicializeColorConfigurationBlue()
        {
            //Azul
            B_MIN = 104; B_MAX = 255; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 27; G_MAX = 63; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 0; R_MAX = 167; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 300; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 276; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 9; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 16; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 4; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 7; lbMaxRadioo.Text = MAX_RADIO.ToString();


        }

        public void InicializeColorConfigurationBlack()
        {
            //Negro
            B_MIN = 42; B_MAX = 88; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 46; G_MAX = 135; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 76; R_MAX = 122; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 166; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 399; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 14; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 16; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 2; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 10; lbMaxRadioo.Text = MAX_RADIO.ToString();
        }

        public void InicializeColorConfigurationRed()
        {
            //Rojo
            B_MIN = 74; B_MAX = 139; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 0; G_MAX = 116; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 167; R_MAX = 232; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 300; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 276; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 9; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 15; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 2; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 10; lbMaxRadioo.Text = MAX_RADIO.ToString();
        }

        public void InicializeColorConfigurationpPen_200ppp()
        {
            //Lapiz  queda // range, smoothgaussian(23), thresholdBinary, canny.
            B_MIN = 60; B_MAX = 227; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 27; G_MAX = 247; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 80; R_MAX = 232; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 500; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 19; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 16; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 22; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 159;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        public void InicializeColorConfigurationpPen_200ppp_EDIT()
        {
            //TO EDIT

            //Lapiz  queda // range, smoothgaussian(41), thresholdBinary, canny.  OK => filtra solo pintados + codigo
            B_MIN = 60; B_MAX = 227; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 27; G_MAX = 247; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 80; R_MAX = 232; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 500; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 30; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 1; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 22; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 166;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        public void InicializeColorConfigurationpPen_200ppp_Inverse()
        {
            //Lapiz
            B_MIN = 0; B_MAX = 204; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 0; G_MAX = 205; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 0; R_MAX = 206; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 500; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 34; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 9; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 12; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 119;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        public void InicializeColorConfigurationpPen_200ppp_No_Inverse_First_Iteration()
        {
            //Lapiz  queda // range, smoothgaussian(41), thresholdBinary, canny.  OK => filtra solo pintados + codigo
            B_MIN = 60; B_MAX = 227; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 27; G_MAX = 247; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 80; R_MAX = 232; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 500; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 30; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 1; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 22; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 166;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        public void InicializeColorConfigurationpPen_200ppp_No_Inverse_Second_Iteration()
        {
            //Lapiz  queda // range, smoothgaussian(31), thresholdBinary, canny.
            B_MIN = 46; B_MAX = 241; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 39; G_MAX = 236; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 61; R_MAX = 217; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 392; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 1; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 1; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 9; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 8;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        public void InicializeColorConfigurationpPen_200ppp_No_Inverse_Third_Iteration()
        {
            //Lapiz
            B_MIN = 46; B_MAX = 241; lbBlueMin.Text = B_MIN.ToString(); lbBlueMax.Text = B_MAX.ToString();
            G_MIN = 39; G_MAX = 236; lbGreenMin.Text = G_MIN.ToString(); lbGreenMax.Text = G_MAX.ToString();
            R_MIN = 61; R_MAX = 217; lbRedMin.Text = R_MIN.ToString(); lbRedMax.Text = R_MAX.ToString();

            THRESH = 92; lbThresh.Text = THRESH.ToString();
            THRESH_LINKING = 392; lbThrehLinking.Text = THRESH_LINKING.ToString();
            CANNY_THRESHOLD = 1; lbCannyThreshold.Text = CANNY_THRESHOLD.ToString();
            ACUMMULATOR_THRESHOLD = 34; lbAcummulatorThrehold.Text = ACUMMULATOR_THRESHOLD.ToString();

            MIN_DIST = 31; lbMinDist.Text = MIN_DIST.ToString();
            MIN_RADIO = 10; lbMinRadio.Text = MIN_RADIO.ToString();
            MAX_RADIO = 13; lbMaxRadioo.Text = MAX_RADIO.ToString();

            THRESHOLD_BINARY_MIN = 60;
            THRESHOLD_BINARY_MAX = 255;
            lbThresholdBinary_Min.Text = THRESHOLD_BINARY_MIN.ToString();
            lbThresholdBinary_Max.Text = THRESHOLD_BINARY_MAX.ToString();

        }

        #endregion

        #region  test_dataDridView

        public void CreateColumnsAndData()
        {
             
            
            for (int i = 0; i <= 175 + 7; i++)
            {
                if (i == 0) { dataGridView1.Columns.Add("Col_0", "DNI"); dataGridView1.Columns[i].Width = 60; }
                if (i == 1) { dataGridView1.Columns.Add("Col_0", "Alb-1"); dataGridView1.Columns[i].Width = 36; }
                if (i == 2) { dataGridView1.Columns.Add("Col_0", "Alb-2"); dataGridView1.Columns[i].Width = 36; }
                if (i == 3) { dataGridView1.Columns.Add("Col_0", "Sede"); dataGridView1.Columns[i].Width = 34; }
                if (i == 4) { dataGridView1.Columns.Add("Col_0", "Cic-01"); dataGridView1.Columns[i].Width = 39; }
                if (i == 5) { dataGridView1.Columns.Add("Col_0", "Cic-02"); dataGridView1.Columns[i].Width = 39; }
                if (i == 6) { dataGridView1.Columns.Add("Col_0", "Semes"); dataGridView1.Columns[i].Width = 39; }
                if (i == 7) { dataGridView1.Columns.Add("Col_0", "Turno"); dataGridView1.Columns[i].Width = 36; }

                if (i >= 8) { 
                    dataGridView1.Columns.Add("Col_" + i.ToString(), (i-7).ToString());
                    dataGridView1.Columns[i].Width = 30;
                }
                
            }


            string[] row1 = new string[176];

            for (int i = 0; i < 175; i++)
            {
                row1[i + 1] = "DATA " + (i + 1).ToString();
                // string[] row1 = new string[] { "column2 value", "column6 value" };
            }
            //dataGridView1.Rows.Add(row1);

        }

        public void addColumToGridView(string[] row)
        {
            dataGridView1.Rows.Add(row);
        }

        #endregion




        public struct Question
        {
            int idQuestion;
            String answer;

            public void fillQuestion(int id, String ans)
            {
                idQuestion = id;
                answer = ans;
            }
            public int getIdQuestion()
            {
                return idQuestion;
            }
            public String getAnswer()
            {
                return answer;
            }
        }

        public struct Applicant
        {
            int Id;
            String nombre;
            List<Question> exam;

            public void fillApplicant(int pId, String pNombre, List<Question> pQuestions)
            {
                Id = pId;
                nombre = pNombre;
                exam = pQuestions;
            }

            public int getId()
            {
                return Id;
            }
            public List<Question> getExam()
            {
                return exam;
            }

        }

        #endregion


        #region Mayas technique

        int numMayas;
        List<Circle> mayas_corner;

        List<AbstractObject> lstAbsDNI;
        AbstractObject abs_aux_DNI;

        List<AbstractQuestion> lstAbsQuestions;
        AbstractQuestion abs_question;
        AbstractQuestion abs_aux_question;

        List<AbstractObject> lstAbsOptions;
        AbstractObject abs_aux_option;

        List<AbstractObject> lstAbsSede;
        AbstractObject abs_aux_sede;

        List<AbstractObject> lstAbsCiclo;
        AbstractObject abs_aux_ciclo;

        List<AbstractObject> lstAbsSemestre;
        AbstractObject abs_aux_semestre;

        List<AbstractObject> lstAbsTurno;
        AbstractObject abs_aux_turno;

        List<AbstractQuestion> lstAbsBigMaya;
        AbstractQuestion abs_big_maya;
        AbstractQuestion abs_aux_big_maya;

        public bool flag_init;
        Contour<System.Drawing.Point> contours;
        List<CountorsPositions> contoursPositions;

        float scala_x;
        float scala_y;

        int FILAS;
        int COLUMNAS;
        int LIMITE_AREA_RESPUESTA;

        List<MCvBox2D> listSquares;
        

        public struct AbstractObject
        {
            int id;
            int idQuestion;
            float x, y;
            float radio;
            int respuesta;


            public void set_id(int id)
            {
                this.id = id;
            }
            public int get_id()
            {
                return id;
            }

            public void set_idQuestion(int idQuestion)
            {
                this.idQuestion = idQuestion;
            }
            public int get_idQuestion()
            {
                return idQuestion;
            }

            public void set_x(float x)
            {
                this.x = x;
            }
            public float get_x()
            {
                return x;
            }

            public void set_y(float y)
            {
                this.y = y;
            }
            public float get_y()
            {
                return y;
            }

            public void set_radio(float radio)
            {
                this.radio = radio;
            }
            public float get_radio()
            {
                return radio;
            }

            public void set_respuesta(int respuesta)
            {
                this.respuesta = respuesta;
            }
            public int get_respuesta()
            {
                return respuesta;
            }
        }

        public struct AbstractQuestion
        {
            int idQuestion;
            float x1, y1;
            float x2, y2;
            float radio;
            int respuesta;

            public void set_idQuestion(int idQuestion)
            {
                this.idQuestion = idQuestion;
            }
            public int get_idQuestion()
            {
                return idQuestion;
            }

            public void set_x1(float x1)
            {
                this.x1 = x1;
            }
            public float get_x1()
            {
                return x1;
            }

            public void set_y1(float y1)
            {
                this.y1 = y1;
            }
            public float get_y1()
            {
                return y1;
            }

            public void set_x2(float x2)
            {
                this.x2 = x2;
            }
            public float get_x2()
            {
                return x2;
            }

            public void set_y2(float y2)
            {
                this.y2 = y2;
            }
            public float get_y2()
            {
                return y2;
            }

            public void set_radio(float radio)
            {
                this.radio = radio;
            }
            public float get_radio()
            {
                return radio;
            }

            public void set_respuesta(int respuesta)
            {
                this.respuesta = respuesta;
            }
            public int get_respuesta()
            {
                return respuesta;
            }

        }

        public struct CountorsPositions
        {
            public float x;
            public float y;
            public float area;

            public CountorsPositions(float x, float y, float area)
            {
                this.x = x;
                this.y = y;
                this.area = area;
            }
        }
        Pen my_pen;

        string empty;

        #endregion

        public delegate void MyEvent(object sender, object param);
        event MyEvent OnMyEvent;

        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Image procesing Form_Load

            //if (PICK_COLOR == 0) { InicializeColorConfigurationpPen_200ppp(); rbColorPen2B.Checked = true; }
            //if (PICK_COLOR == 0) { InicializeColorConfigurationpPen_200ppp_EDIT(); rbColorPen2B.Checked = true; }
            if (PICK_COLOR == 0) { InicializeColorConfigurationpPen_200ppp_No_Inverse_First_Iteration(); rbColorPen2B.Checked = true; }
            if (PICK_COLOR == 1) { InicializeColorConfigurationBlack(); rbColorBlack.Checked = true; }
            if (PICK_COLOR == 2) { InicializeColorConfigurationRed(); rbColorRed.Checked = true; }
            if (PICK_COLOR == 3) { inicializeColorConfigurationBlue(); rbColorBlue.Checked = true; }


            DYNAMIC_VALUE = 0;
            OPTION = 0;
            LECTURE_MODE = 0;
            PAGE = 0;
            PICK_COLOR = 3;

            btnOpenFile.Enabled = false;
            btnPause.Enabled = true;
            Pause = false;
            BeginProcess = true;
            allProcessed = false;

            timer1.Enabled = false;
            timer1.Interval = 30;

            rbVideo.Checked = false;
            rbFile.Checked = true;
            btnPreview.Enabled = false;
            rbAnalizeAll.Checked = true;


            images = new List<Image<Bgr, byte>>();
            imagesNames = new List<string>();
            questions = new List<Question>();
            applicants = new List<Applicant>();

            txtTotalApplicants.Text = "1";
            txtTotalScanedPapers.Text = "1";

            TOTAL_APPLICANTS = 0;
            TOTAL_SCANNED_PAPERS = 0;



            //TestAngle();
            //Application.Idle += ProcesseFrameAndUpdateGUI;



            CreateColumnsAndData();

            #endregion

            #region Mayas inicialization  -> 3 in total

            FILAS = 48;
            COLUMNAS = 28;
            txtTotalApplicants.Text = "1000";
            LIMITE_AREA_RESPUESTA = 350;
            numMayas = 4;

            flag_init = false;

            

            opcion_01 = -1;
            opcion_02 = -1;
            codigo_sede = -1;
            num_01 = -1;
            num_02 = -1;
            codigo_semestre = -1;
            codigo_turno = -1;
            empty = "";

            // Dimension of picture box ->   578, 708

            #region ORIGINAL Dynamic inicialization of the mayas_corner

            //int numMayas = 3;
            //mayas_corner = new List<Circle>();


            //int count = 0;
            //for (int k = 0; k < numMayas; k++)
            //{

            //    Circle lstCirculos = new Circle();
            //    Circle circulo_0 = new Circle();
            //    Circle circulo_1 = new Circle();
            //    Circle circulo_2 = new Circle();
            //    Circle circulo_3 = new Circle();

            //    int lineasHorizontales = 0;
            //    int lineasVerticales = 0;

            //    lstCirculos.circles.Add(circulo_0);
            //    lstCirculos.circles.Add(circulo_1);
            //    lstCirculos.circles.Add(circulo_2);
            //    lstCirculos.circles.Add(circulo_3);


            //    for (int j = 0; j < 2; j++)
            //    {

            //        for (int i = 0; i < 2; i++)
            //        {
            //            int index = j * 2 + i;

            //            // Mayas ubications in pixels  ERG : (i * 93) + 376

            //            if (k == 0) // DNI
            //            {
            //                lineasHorizontales = 9;
            //                lineasVerticales = 7;
            //                lstCirculos.circles[index].set_X((i * 93) + 376);
            //                lstCirculos.circles[index].set_Y((j * 95) + 121);
            //            }
            //            if (k == 1) // Opcion Albergue
            //            {
            //                lineasHorizontales = 4;
            //                lineasVerticales = 1;
            //                lstCirculos.circles[index].set_X((i * 14) + 308);
            //                lstCirculos.circles[index].set_Y((j * 42) + 163); // 8.4
            //            }
            //            //if (k == 2) // sede
            //            //{
            //            //    lineasHorizontales = 4;
            //            //    lineasVerticales = 1;
            //            //    lstCirculos.circles[index].set_X((i * 13) + 116);
            //            //    lstCirculos.circles[index].set_Y((j * 43) + 243);
            //            //}
            //            //if (k == 3) //anio
            //            //{
            //            //    lineasHorizontales = 9;
            //            //    lineasVerticales = 1;
            //            //    lstCirculos.circles[index].set_X((i * 15) + 116);
            //            //    lstCirculos.circles[index].set_Y((j * 97) + 328);
            //            //}
            //            //if (k == 4) // ciclo y turno 
            //            //{
            //            //    lineasHorizontales = 1;
            //            //    lineasVerticales = 1;
            //            //    lstCirculos.circles[index].set_X((i * 15) + 116);
            //            //    lstCirculos.circles[index].set_Y((j * 42) + 470);
            //            //}
            //            if (k >= 2) //respuestas
            //            {
            //                //lineasHorizontales = 34;
            //                //lineasVerticales = 2;
            //                //lstCirculos.circles[index].set_X((i * 13) + 185     +   (spaceColumnsAnswers * count)) ;
            //                //lstCirculos.circles[index].set_Y((j * 368) + 242);


            //                //implented just for answers
            //                //lineasHorizontales = 34;
            //                //lineasVerticales = 21;
            //                //lstCirculos.circles[index].set_X((i * 289) + 185 );
            //                //lstCirculos.circles[index].set_Y((j * 368) + 242);

            //                //
            //                lineasHorizontales = 34;
            //                lineasVerticales = 26;
            //                lstCirculos.circles[index].set_X((i * 347) + 121);
            //                lstCirculos.circles[index].set_Y((j * 356) + 246);

            //            }
            //        }
            //    }
            //    lstCirculos.set_X(lineasVerticales);
            //    lstCirculos.set_Y(lineasHorizontales);
            //    mayas_corner.Add(lstCirculos);
            //    if (k >= 5)
            //        count++;
            //}

            #endregion

            Inicialization_BigMaya();

            // the same nnumber of num of mayas_corner

            #region Dynamic inicialization of lstAbsDIN

            lstAbsDNI = new List<AbstractObject>();
            abs_aux_DNI = new AbstractObject();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int pos = j + (i * 8);

                    abs_aux_DNI.set_idQuestion(i);
                    abs_aux_DNI.set_respuesta(-1);
                    abs_aux_DNI.set_radio(8.7f);
                    abs_aux_DNI.set_id(pos);

                    lstAbsDNI.Add(abs_aux_DNI);
                }

            }
            #endregion

            #region Dynamic inicialization of lstAbsQuestions

            lstAbsQuestions = new List<AbstractQuestion>();
            abs_question = new AbstractQuestion();
            abs_aux_question = new AbstractQuestion();


            for (int i = 0; i < 175; i++)
            {
                AbstractQuestion aq = new AbstractQuestion();
                lstAbsQuestions.Add(aq);
            }

            #endregion

            #region Dynamic inicializatin of lstAbsOptions

            lstAbsOptions = new List<AbstractObject>();

            abs_aux_option = new AbstractObject();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int pos = j + (i * 2);

                    abs_aux_option.set_idQuestion(i);
                    abs_aux_option.set_respuesta(-1);
                    abs_aux_option.set_radio(8.7f);
                    abs_aux_option.set_id(pos);

                    lstAbsOptions.Add(abs_aux_option);
                }

            }
            #endregion

            #region Dynamic inicialization of lstSede

            lstAbsSede = new List<AbstractObject>();
            abs_aux_sede = new AbstractObject();

            for (int i = 0; i < 5; i++)
            {


                abs_aux_sede.set_id(i);
                abs_aux_sede.set_idQuestion(i);
                abs_aux_sede.set_radio(8.7f);
                abs_aux_sede.set_respuesta(-1);

                lstAbsSede.Add(abs_aux_sede);

            }
            #endregion

            #region Dynamic inicialization of lstCiclo

            lstAbsCiclo = new List<AbstractObject>();
            abs_aux_ciclo = new AbstractObject();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int pos = j + (i * 2);

                    abs_aux_ciclo.set_id(pos);
                    abs_aux_ciclo.set_idQuestion(i);
                    abs_aux_ciclo.set_radio(8.7f);
                    abs_aux_ciclo.set_respuesta(-1);

                    lstAbsCiclo.Add(abs_aux_ciclo);

                }

            }
            #endregion

            #region Inicialization of lstSemestre

            lstAbsSemestre = new List<AbstractObject>();
            abs_aux_semestre = new AbstractObject();
            for (int i = 0; i < 2; i++)
            {
                abs_aux_semestre.set_id(i);
                abs_aux_semestre.set_idQuestion(i);
                abs_aux_semestre.set_radio(8.7f);
                abs_aux_semestre.set_respuesta(-1);

                lstAbsSemestre.Add(abs_aux_semestre);
            }

            #endregion

            #region Inicialization of lstTurno
            lstAbsTurno = new List<AbstractObject>();
            abs_aux_turno = new AbstractObject();
            for (int i = 0; i < 2; i++)
            {
                abs_aux_turno.set_id(i);
                abs_aux_turno.set_idQuestion(i);
                abs_aux_turno.set_radio(8.7f);
                abs_aux_turno.set_respuesta(-1);

                lstAbsTurno.Add(abs_aux_turno);
            }

            #endregion

            #region Dynamic inicialization of lstAbsBigMaya

            lstAbsBigMaya = new List<AbstractQuestion>();
            abs_big_maya = new AbstractQuestion();
            abs_aux_big_maya = new AbstractQuestion();


            for (int i = 0; i < COLUMNAS*FILAS; i++)
            {
                AbstractQuestion aq = new AbstractQuestion();
                lstAbsBigMaya.Add(aq);
            }

            #endregion

            contoursPositions = new List<CountorsPositions>();

            //pictureBox1.Image = new System.Drawing.Bitmap(@"E:\Voluntades\Reclutamiento 2015\Claudia Alarcón.jpg");
            //pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\kevin\Desktop\MVVM_ppts\2015-08-02_MVVM_242.jpg");
            //pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\kevin\Downloads\Superior.jpeg");

            #endregion

        }

        
         #region Methods for image procesing in general

        public void set_drag_points_of_mayas_dni(PointF p1, PointF p2, PointF p3, PointF p4)
        {

          
            mayas_corner[0].circles[0].set_X(p1.X);
            mayas_corner[0].circles[0].set_Y(p1.Y);
            mayas_corner[0].circles[1].set_X(p2.X);
            mayas_corner[0].circles[1].set_Y(p2.Y);
            mayas_corner[0].circles[2].set_X(p3.X);
            mayas_corner[0].circles[2].set_Y(p3.Y);
            mayas_corner[0].circles[3].set_X(p4.X);
            mayas_corner[0].circles[3].set_Y(p4.Y);

            
        }
      
        public void set_drag_points_of_mayas_options(PointF p1, PointF p2, PointF p3, PointF p4)
        {


            mayas_corner[1].circles[0].set_X(p1.X);
            mayas_corner[1].circles[0].set_Y(p1.Y);
            mayas_corner[1].circles[1].set_X(p2.X);
            mayas_corner[1].circles[1].set_Y(p2.Y);
            mayas_corner[1].circles[2].set_X(p3.X);
            mayas_corner[1].circles[2].set_Y(p3.Y);
            mayas_corner[1].circles[3].set_X(p4.X);
            mayas_corner[1].circles[3].set_Y(p4.Y);


        }
        
        public void set_drag_points_of_mayas_answers(PointF p1, PointF p2, PointF p3, PointF p4)
        {


            mayas_corner[2].circles[0].set_X(p1.X);
            mayas_corner[2].circles[0].set_Y(p1.Y);
            mayas_corner[2].circles[1].set_X(p2.X);
            mayas_corner[2].circles[1].set_Y(p2.Y);
            mayas_corner[2].circles[2].set_X(p3.X);
            mayas_corner[2].circles[2].set_Y(p3.Y);
            mayas_corner[2].circles[3].set_X(p4.X);
            mayas_corner[2].circles[3].set_Y(p4.Y);


        }

        public void Inicialization_BigMaya()
        {
            #region Dynamic inicialization of the mayas_corner

            
            mayas_corner = new List<Circle>();


            int count = 0;
            for (int k = 0; k < numMayas; k++)
            {

                Circle lstCirculos = new Circle();
                Circle circulo_0 = new Circle();
                Circle circulo_1 = new Circle();
                Circle circulo_2 = new Circle();
                Circle circulo_3 = new Circle();

                int lineasHorizontales = 0;
                int lineasVerticales = 0;

                lstCirculos.circles.Add(circulo_0);
                lstCirculos.circles.Add(circulo_1);
                lstCirculos.circles.Add(circulo_2);
                lstCirculos.circles.Add(circulo_3);

                
                for (int j = 0; j < 2; j++)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        int index = j * 2 + i;

                        // Ubications mayas_corner' drag and drop circles in pixels positions  ERG : (i * 93) + 376

                        if (k == 0) // DNI
                        {
                            lineasHorizontales = 9;
                            lineasVerticales = 7;
                            //lstCirculos.circles[index].set_X((i * 93) + 376);
                            //lstCirculos.circles[index].set_Y((j * 95) + 121);
                        }
                        if (k == 1) // Opcion Albergue
                        {
                            lineasHorizontales = 4;
                            lineasVerticales = 1;
                            //lstCirculos.circles[index].set_X((i * 14) + 308);
                            //lstCirculos.circles[index].set_Y((j * 42) + 163); // 8.4
                        }
                       
                        if (k == 2) //respuestas
                        {
                           
                            lineasHorizontales = 34;
                            lineasVerticales = 26;
                            //lstCirculos.circles[index].set_X((i * 347) + 111);
                            //lstCirculos.circles[index].set_Y((j * 356) + 246);

                        }
                        if (k == 3)
                        {
                            //identify the markers per each test and use in 
                                lineasHorizontales = FILAS;
                                lineasVerticales = COLUMNAS;
                                //lstCirculos.circles[index].set_X((i * 372) + 98);//97
                                //lstCirculos.circles[index].set_Y((j * 502) + 110);//100
                            //lstCirculos.circles[0].set_X(p1.X);
                            //lstCirculos.circles[0].set_Y(p1.Y);
                            //lstCirculos.circles[1].set_X(p2.X);
                            //lstCirculos.circles[1].set_Y(p2.Y);
                            //lstCirculos.circles[2].set_X(p3.X);
                            //lstCirculos.circles[2].set_Y(p3.Y);
                            //lstCirculos.circles[3].set_X(p4.X);
                            //lstCirculos.circles[3].set_Y(p4.Y);
                        }

                       
                    }
                }
                lstCirculos.set_X(lineasVerticales);
                lstCirculos.set_Y(lineasHorizontales);
                mayas_corner.Add(lstCirculos);



                

                if (k >= 5)
                    count++;

            }

           

            #endregion

        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebCam != null)
            {
                capWebCam.Dispose();
            }
        }

        public void ProcessFromFile()
        {

            //TOTAL_APPLICANTS = Convert.ToInt32(txtTotalApplicants.Text);
            //TOTAL_SCANNED_PAPERS = Convert.ToInt32(txtTotalScanedPapers.Text);
            //TOTAL_APPLICANTS = images.Count();
            //TOTAL_SCANNED_PAPERS = images.Count();


            if (images.Count() == 0)
            {
                BeginProcess = false;

            }
            else //begin images processing
            {
                if (TOTAL_SCANNED_PAPERS <= 1)
                {
                    btnNext.Enabled = false;
                    btnPreview.Enabled = false;
                }

                if (LECTURE_MODE == 0) //read all at once
                {
                    if (!allProcessed)
                    {
                        ProcesScannedImages();
                        //kevinRemote
                        flag_init = false;
                        allProcessed = true;
                    }
                    else
                    {
                        //changeImage(PAGE);
                    }
                }
                else if (LECTURE_MODE == 1) //read one by one
                {
                    if (images != null && images.Count > 0)
                        ProcesScannedImagesOneByOne(PAGE);

                    //kevinRemote
                    flag_init = false;
                }
                btnOpenFile.Enabled = true;
            }
        }

        private void changeImage(int pPage)
        {
            ibOriginal.Image = images[pPage];
        }

        public void ProcessFromVideo()
        {
            try
            {
                if (capWebCam == null)
                {
                    capWebCam = new Capture();
                }
                imgInputFrame = capWebCam.QueryFrame();
                ProcesseFrameToFindCircles(imgInputFrame, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void ProcesScannedImages()
        {
            /*
             *this method suports miltiple surveys at once image charge
             */
            #region Read all at once

            txtResult.Clear();
            applicants.Clear();

            for (int k = 0; k < TOTAL_APPLICANTS; k++)
            {
                int oneSurveyPages = TOTAL_SCANNED_PAPERS / TOTAL_APPLICANTS;

                // Survey for one person
                for (int i = k * oneSurveyPages; i < (k + 1) * oneSurveyPages; i++)
                {
                    ProcesseFramesToFindSquares(images[i]);
                   
                    ProcesseFrameToFindCircles(images[i], 0); 
                }

                // Add the applicant to the list of applicants 
                Applicant applicant = new Applicant();
                applicant.fillApplicant(k + 1, "NOMBRE " + (k + 1).ToString(), questions);
                applicants.Add(applicant);

                // print applicant resutls
                //txtResult.AppendText(Environment.NewLine);
                //txtResult.AppendText("=============  APPLICANT N°  : " + (k + 1).ToString() + "  ==============");

                //each applicants result
                string[] row = new string[176 + 7];
                row[0] = txtCode.Text;
                if (opcion_01 == -1) row[1] = empty; else row[1] = (opcion_01 + 1).ToString();
                if (opcion_02 == -1) row[2] = empty; else row[2] = (opcion_02 + 1).ToString();
                if (codigo_sede == -1) row[3] = empty; else row[3] = (codigo_sede + 1).ToString();
                if (num_01 == -1) row[4] = empty; else row[4] = num_01.ToString();
                if (num_02 == -1) row[5] = empty; else row[5] = num_02.ToString();
                if (codigo_turno == -1) row[6] = empty; else row[6] = (codigo_semestre + 1).ToString();
                if (codigo_turno == -1) row[7] = empty; else row[7] = (codigo_turno + 1).ToString();

                for (int j = 0; j < applicants[0].getExam().Count(); j++)
                {
                    //txtResult.AppendText(Environment.NewLine);
                    //txtResult.AppendText("Pregunta ID: " + (1 + j).ToString() + " - Answer :  " + applicants[0].getExam()[j].getAnswer());

                    //To gridView
                    row[j + 8] = applicants[0].getExam()[j].getAnswer();
                }
                addColumToGridView(row);

                if (k == TOTAL_APPLICANTS - 1)
                //if (k == TOTAL_APPLICANTS )
                {
                    //TODO : Comment to calibrate  
                    //BeginProcess = false;
                }

                //clear resources used for each applicant
                questions.Clear();
                ID_SEQUENCE = 0;

                CleanAllList();

            }

            #endregion
        }

        public void ProcesScannedImagesOneByOne(int pPage)
        {

            /*
             *this method one surveys 
             */
            #region Read one

            txtResult.Clear();
            applicants.Clear();
            
            //kevinRemote
            label4.Text = "Test Numero : " + (pPage + 1).ToString();
            ProcesseFramesToFindSquares(images[pPage]);
            pictureBox1.Image = new System.Drawing.Bitmap(imagesNames[pPage]);
            label3.Text = imagesNames[pPage];
            ProcesseFrameToFindCircles(images[pPage], 0);

            // Add the applicant to the list of applicants 
            Applicant applicant = new Applicant();
            applicant.fillApplicant(codeNumber, "  -  NOMBRE  TEST de prueba", questions);
            applicants.Add(applicant);

            // print applicant resutls
            //txtResult.AppendText(Environment.NewLine);
            //txtResult.AppendText("=============  APPLICANT N°  : " + codeNumber.ToString() + "  ==============");

            //each applicants result
            string[] row = new string[176 + 7];
            
            row[0] = txtCode.Text;
            if (opcion_01 == -1) row[1] = empty; else row[1] = (opcion_01 + 1).ToString();
            if (opcion_02 == -1) row[2] = empty; else row[2] = (opcion_02 + 1).ToString();
            if (codigo_sede == -1) row[3] = empty; else row[3] = (codigo_sede + 1).ToString();
            if (num_01 == -1) row[4] = empty; else row[4] = num_01.ToString();
            if (num_02 == -1) row[5] = empty; else row[5] = num_02.ToString();
            if (codigo_turno == -1) row[6] = empty; else row[6] = (codigo_semestre + 1).ToString();
            if (codigo_turno == -1) row[7] = empty; else row[7] = (codigo_turno + 1).ToString();
            for (int j = 0; j < applicants[0].getExam().Count(); j++)
            {
                //txtResult.AppendText(Environment.NewLine);
                //txtResult.AppendText("Pregunta ID: " + applicants[0].getExam()[j].getIdQuestion().ToString() + " - Answer :  " + applicants[0].getExam()[j].getAnswer());

                //To gridView

                row[j + 8] = applicants[0].getExam()[j].getAnswer();

            }
            addColumToGridView(row);


            //TODO : Comment to calibrate  
            //BeginProcess = false;

            //clear resources used for each applicant
            questions.Clear();
            CleanAllList();
            #endregion
        }

        public void ProcesseFramesToFindSquares(Image<Bgr, Byte> pImage)
        {

            pbBad.Visible = false;
            pbGood.Visible = false;
            scala_x = (float)(pImage.Width * 1.0 / pictureBox1.Width);
            scala_y = (float)(pImage.Height * 1.0 / pictureBox1.Height);

            #region square
            if (pImage != null)
            {

                Image<Bgr, Byte> pImg = pImage.Copy();
                Image<Gray, Byte> gray = pImg.Convert<Gray, Byte>().PyrDown().PyrUp();
                ibHoughCircles.Image = null;
                ibHoughCircles.Image = gray;

                Gray cannyThreshold = new Gray(180);
                Gray cannyThresholdLinking = new Gray(120);

                Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
                ibHoughCircles2.Image = null;
                ibHoughCircles2.Image = cannyEdges;

                LineSegment2D[] lines = cannyEdges.HoughLinesBinary(1, Math.PI / 45.0, 20, 30, 10)[0];

                List<MCvBox2D> boxList = new List<MCvBox2D>();
                listSquares = new List<MCvBox2D>();
                int squares = 0;
                using (MemStorage storage = new MemStorage())
                {
                    for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                    {
                        //Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                        if (contours.Area > 1000 )// Int32.Parse(txtTotalApplicants.Text))
                        {
                            if (currentContour.Total == 4 || currentContour.Total == 2 || currentContour.Total == 6)
                            {
                                bool isRectangle = true;
                                Point[] pts = currentContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);
                                //using edges i found coordinates.
                                for (int i = 0; i < edges.Length; i++)
                                {
                                    double angle = Math.Abs(edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                    if (angle < 85 || angle > 95)
                                    //if (angle < 80 || angle > 110)
                                    //if (angle != 90)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                    if (isRectangle)
                                    {
                                        boxList.Add(currentContour.GetMinAreaRect());
                                        // added
                                        MCvBox2D box = contours.GetMinAreaRect();
                                        listSquares.Add(box);
                                        pImg.Draw(box, new Bgr(System.Drawing.Color.Red), 9);
                                        squares++;
                                    }
                                }
                            }
                        }
                    }
                }
                ibOriginal.Image = pImg;
                txtTotalApplicants.Text = listSquares.Count.ToString(); //squares.ToString();


                bool a, b, c, d;
                a = b = c = d = false;
                for (int i = 0; i < listSquares.Count; i++)
                {
                    //set the x,y position of the 4 squares guides of the scanned papaer
                    float xp = listSquares[i].center.X / scala_x;
                    float yp = listSquares[i].center.Y / scala_y;

                    if (listSquares[i].center.X < pImg.Width / 2 &&
                        listSquares[i].center.Y < pImg.Height / 2)
                    {
                        mayas_corner[3].circles[0].set_X(xp);
                        mayas_corner[3].circles[0].set_Y(yp);
                        a = true;
                    }
                    if (listSquares[i].center.X > pImg.Width / 2 &&
                        listSquares[i].center.Y < pImg.Height / 2)
                    {
                        mayas_corner[3].circles[1].set_X(xp);
                        mayas_corner[3].circles[1].set_Y(yp);
                        b = true;
                    }
                    if (listSquares[i].center.X < pImg.Width / 2 &&
                        listSquares[i].center.Y > pImg.Height / 2)
                    {
                        mayas_corner[3].circles[2].set_X(xp);
                        mayas_corner[3].circles[2].set_Y(yp);
                        c = true;
                    }
                    if (listSquares[i].center.X > pImg.Width / 2 &&
                        listSquares[i].center.Y > pImg.Height / 2)
                    {
                        mayas_corner[3].circles[3].set_X(xp);
                        mayas_corner[3].circles[3].set_Y(yp);
                        d = true;
                    }

                }
                //cleanList();
                Image img_gb = null;
                if (!(a && b && c && d))
                {
                    //if was found just 3 points
                    PointF missingPoint = findOneMissingPointFromSquare(mayas_corner[3], a, b, c, d);
                    if (missingPoint.X != 0 && missingPoint.Y != 0)
                    {
                        if (!a)
                        {
                            mayas_corner[3].circles[0].set_X(missingPoint.X);
                            mayas_corner[3].circles[0].set_Y(missingPoint.Y);
                        }
                        else if (!b)
                        {
                            mayas_corner[3].circles[1].set_X(missingPoint.X);
                            mayas_corner[3].circles[1].set_Y(missingPoint.Y);
                        }
                        else if (!c)
                        {
                            mayas_corner[3].circles[2].set_X(missingPoint.X);
                            mayas_corner[3].circles[2].set_Y(missingPoint.Y);
                        }
                        else
                        {
                            mayas_corner[3].circles[3].set_X(missingPoint.X);
                            mayas_corner[3].circles[3].set_Y(missingPoint.Y);
                        }
                        pbGood.Visible = true;
                    }
                    else
                    {
                        for (int i = 0; i < mayas_corner[3].circles.Count; i++)
                        {
                            mayas_corner[3].circles[i].set_X(0);
                            mayas_corner[3].circles[i].set_Y(0);
                        }
                        pbBad.Visible = true;
                    }

                    //for (int i = 0; i < mayas_corner[3].circles.Count; i++)
                    //{
                    //    mayas_corner[3].circles[i].set_X(0);
                    //    mayas_corner[3].circles[i].set_Y(0);
                    //}
                    //pbBad.Visible = true;

                }
                else { pbGood.Visible = true; }


                listSquares.Clear();
                updateMayasCornerPosition();

                PointF p1 = new PointF(lstAbsBigMaya[894].get_x1(), lstAbsBigMaya[894].get_y1());
                PointF p2 = new PointF(lstAbsBigMaya[1223].get_x1(), lstAbsBigMaya[1223].get_y1());
                PointF p3 = new PointF(lstAbsBigMaya[903].get_x1(), lstAbsBigMaya[903].get_y1());
                PointF p4 = new PointF(lstAbsBigMaya[1232].get_x1(), lstAbsBigMaya[1232].get_y1());
                set_drag_points_of_mayas_dni(p1, p2, p3, p4);

                p1 = new PointF(lstAbsBigMaya[663].get_x1(), lstAbsBigMaya[663].get_y1());
                p2 = new PointF(lstAbsBigMaya[710].get_x1(), lstAbsBigMaya[710].get_y1());
                p3 = new PointF(lstAbsBigMaya[667].get_x1(), lstAbsBigMaya[667].get_y1());
                p4 = new PointF(lstAbsBigMaya[714].get_x1(), lstAbsBigMaya[714].get_y1());
                set_drag_points_of_mayas_options(p1, p2, p3, p4);

                p1 = new PointF(lstAbsBigMaya[13].get_x1(), lstAbsBigMaya[13].get_y1());
                p2 = new PointF(lstAbsBigMaya[1235].get_x1(), lstAbsBigMaya[1235].get_y1());
                p3 = new PointF(lstAbsBigMaya[47].get_x1(), lstAbsBigMaya[47].get_y1());
                p4 = new PointF(lstAbsBigMaya[1269].get_x1(), lstAbsBigMaya[1269].get_y1());
                set_drag_points_of_mayas_answers(p1, p2, p3, p4);
                //p1 = new PointF(lstAbsBigMaya[12].get_x1(), lstAbsBigMaya[12].get_y1());
                //p2 = new PointF(lstAbsBigMaya[1234].get_x1(), lstAbsBigMaya[1234].get_y1());
                //p3 = new PointF(lstAbsBigMaya[47].get_x1(), lstAbsBigMaya[47].get_y1());
                //p4 = new PointF(lstAbsBigMaya[1269].get_x1(), lstAbsBigMaya[1269].get_y1());
                //set_drag_points_of_mayas_answers(p1, p2, p3, p4);

                updateMayasCornerPosition();
            }

            #endregion // put inside an event

        }

        public PointF findOneMissingPointFromSquare(Circle circles, bool a, bool b, bool c, bool d)
        {
            int count_corner = 0;
            if (a) count_corner++;
            if (b) count_corner++;
            if (c) count_corner++;
            if (d) count_corner++;
            if (count_corner < 3) return new PointF(0,0);

            if (!a) { return new PointF(circles.circles[1].getX() + circles.circles[2].getX() - circles.circles[3].getX() ,
                                        circles.circles[1].getY() + circles.circles[2].getY() - circles.circles[3].getY());
            }
            else if (!b)
            {
                return new PointF(circles.circles[3].getX() + circles.circles[0].getX() - circles.circles[2].getX(),
                                  circles.circles[3].getY() + circles.circles[0].getY() - circles.circles[2].getY());
            }
            else if (!c)
            {
                return new PointF(circles.circles[3].getX() + circles.circles[0].getX() - circles.circles[1].getX(),
                                  circles.circles[3].getY() + circles.circles[0].getY() - circles.circles[1].getY());
            }
            else
            {
                return new PointF(circles.circles[1].getX() + circles.circles[2].getX() - circles.circles[0].getX(),
                                  circles.circles[1].getY() + circles.circles[2].getY() - circles.circles[0].getY());
            }

            //PointF pm = new PointF();
            //if (!a || !d) 
            //{ 
            //    pm = getMiddlePoint(circles.circles[1], circles.circles[2]);
            //    if (!a)
            //    {
            //        return new PointF(2 * pm.X - circles.circles[3].getX() , 2 * pm.Y - circles.circles[3].getY());  
            //    }
            //    else 
            //    {
            //        return new PointF(2 * pm.X - circles.circles[0].getX(), 2 * pm.Y - circles.circles[0].getY());  
            //    }
            //}
            //else// (!b || !d) 
            //{ 
            //    pm = getMiddlePoint(circles.circles[0], circles.circles[3]);
            //    if (!b)
            //    {
            //        return new PointF(2 * pm.X - circles.circles[3].getX(), 2 * pm.Y - circles.circles[3].getY());
            //    }
            //    else
            //    {
            //        return new PointF(2 * pm.X - circles.circles[1].getX(), 2 * pm.Y - circles.circles[1].getY());
            //    }

            //}


         
        }

        public PointF getMiddlePoint(Circle circle1, Circle circle2)
        {
            return new PointF((circle1.getX() + circle2.getX()) / 2.0f , (circle1.getY() + circle2.getY() ) / 2.0f);
        }
      
        public void updateMayasCornerPosition()
        {
              #region dibujar mayas_corner

                        float refPoint_X = 0;
                        float refPoint_Y = 0;
                        float refPoint_Y_1 = 0;

                        double delta_X_H = 0;
                        float delta_Y_H = 0;
                        double delta_X_V = 0;
                        double delta_Y_V = 0;

                        double dist_X_H = 0;
                        float dist_Y_H = 0;
                        double dist_X_V = 0;
                        double dist_Y_V = 0;





                        for (int k = 0; k < mayas_corner.Count; k++)
                        {
                            Circle lstCirculos = mayas_corner[k];// 46 + 2 (drag & drop circles) =  48 insted (horizontal lines)
                            //  28        (vertical lines)


                            #region horizontal lines of the dynamic grid - Creation and Drawing

                            int numHorizontalLines = (int)lstCirculos.getY();

                            double distHorizontal1 = lstCirculos.circles[2].y - lstCirculos.circles[0].y;
                            double intervalHorizonatal1 = distHorizontal1 / numHorizontalLines;

                            double distHorizontal2 = lstCirculos.circles[3].y - lstCirculos.circles[1].y;
                            double intervalHorizontal2 = distHorizontal2 / numHorizontalLines;

                            double intervalHorizontalX1 = (lstCirculos.circles[2].x - lstCirculos.circles[0].x) * 1.0 / numHorizontalLines;
                            double intervalHorizontalX2 = (lstCirculos.circles[3].x - lstCirculos.circles[1].x) * 1.0 / numHorizontalLines;

                            for (int i = 0; i <= numHorizontalLines; i++)
                            {

                                //e.Graphics.DrawLine(
                                //           new Pen(Color.Red, 1f),
                                //           new Point((int)((i * intervalHorizontalX1) + lstCirculos.circles[0].x), (int)((i * intervalHorizonatal1) + lstCirculos.circles[0].y)),
                                //           new Point((int)((i * intervalHorizontalX2) + lstCirculos.circles[1].x), (int)((i * intervalHorizontal2) + lstCirculos.circles[1].y)));



                            }
                            #endregion

                            #region Vertical lines of the dynamic grid - Creation and Drawing - Creating lstAbsQuestion and lstAbsOnjects

                            int numVerticalLines = (int)lstCirculos.getX();

                            double distVertical1 = lstCirculos.circles[1].x - lstCirculos.circles[0].x;
                            double intervalVertical1 = distVertical1 / numVerticalLines;

                            double distVertical2 = lstCirculos.circles[3].x - lstCirculos.circles[2].x;
                            double intervalVertical2 = distVertical2 / numVerticalLines;

                            double intervalVerticalY1 = (lstCirculos.circles[1].y - lstCirculos.circles[0].y) * 1.0 / numVerticalLines;
                            double intervalVerticalY2 = (lstCirculos.circles[3].y - lstCirculos.circles[2].y) * 1.0 / numVerticalLines;

                            int index_x = 1;
                            int aux_count = 0;
                            int aux_indice_columna = 0;
                            //pass throug of all the vertical lines 
                            for (int i = 0; i <= numVerticalLines; i++)
                            {
                                #region Vertical lines of the dynamic grid - Drawing
                                //e.Graphics.DrawLine(
                                //           new Pen(Color.Red, 1f),
                                //           new Point((int)((i * intervalVertical1) + lstCirculos.circles[0].x), (int)((i * intervalVerticalY1) + lstCirculos.circles[0].y)),
                                //           new Point((int)((i * intervalVertical2) + lstCirculos.circles[2].x), (int)((i * intervalVerticalY2) + lstCirculos.circles[2].y)));
                                #endregion
                                if (k < 2)
                                //if(false)
                                {
                                    #region Validation Areas of abstract DNI and Options Albergue

                                    dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                                    dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                                    delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                                    delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);

                                    int sign = 1;
                                    if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                                        //if (lstCirculos.circles[2].x < lstCirculos.circles[0].x ||
                                        //    lstCirculos.circles[1].x < lstCirculos.circles[3].x)
                                        sign *= -1;

                                    refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                                    refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                                    for (int r = 0; r <= numHorizontalLines; r++)
                                    {

                                        float x = (refPoint_X + (r * (float)delta_X_V * sign));
                                        float y = (refPoint_Y + (r * (float)delta_Y_V));

                                        if (k == 0)
                                        {

                                            #region This is the DNI abstract area
                                            int pos = (r * 8) + i;

                                            abs_aux_DNI = lstAbsDNI[pos];
                                            abs_aux_DNI.set_x(x);
                                            abs_aux_DNI.set_y(y);

                                            lstAbsDNI[pos] = abs_aux_DNI;

                                            my_pen = new Pen(Color.Green, 1f);

                                            #endregion
                                        }
                                        if (k == 1)
                                        {
                                            #region This is the Option Albergue abstract area
                                            int pos = (r * 2) + i;

                                            abs_aux_option = lstAbsOptions[pos];
                                            abs_aux_option.set_x(x);
                                            abs_aux_option.set_y(y);

                                            lstAbsOptions[pos] = abs_aux_option;

                                            #endregion
                                        }
                                    }
                                    #endregion
                                }
                                //else
                                if (k == 2)
                                {
                                    #region Validating areas of abstract questions, Sedes, ciclo y turno

                                    if (i != 2 &&
                                        i != 3 &&
                                        i != 4 &&
                                        i != 7 &&
                                        i != 8 &&
                                        i != 9 &&
                                        i != 12 &&
                                        i != 13 &&
                                        i != 14 &&
                                        i != 17 &&
                                        i != 18 &&
                                        i != 19 &&
                                        i != 22 &&
                                        i != 23 &&
                                        i != 24)
                                    {
                                        dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                                        dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                                        delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                                        delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);


                                        int sign = 1;
                                        if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                                            sign *= -1;

                                        refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                                        refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                                        int index_y = 0;

                                        //pass throug of all the validated horizontal lines
                                        for (int r = 0; r <= numHorizontalLines; r++)
                                        {
                                            float x = (refPoint_X + (r * (float)delta_X_V * sign));
                                            float y = (refPoint_Y + (r * (float)delta_Y_V));

                                            //All vertical lines that belong to Sede , ciclo y turno
                                            //avoiding not desiered horizontal lines
                                            if (r != 5 && r != 26 &&
                                                r != 6 && r != 27 &&
                                                r != 7 && r != 28 &&
                                                r != 18 && r != 29 &&
                                                r != 19 && r != 30 &&
                                                r != 20 && r != 31 &&
                                                r != 22 && r != 32 &&
                                                r != 23 && r != 33 &&
                                                r != 24 && r != 34 && (i == 0 || i == 1))
                                            {

                                                #region logic to save obstrat object to a lstAbsOjects of Sede , ciclo y turno


                                                if (r <= 4)
                                                {
                                                    #region Sedes Abstrac area
                                                    if (i == 1)
                                                    {
                                                        abs_aux_sede = lstAbsSede[r];
                                                        abs_aux_sede.set_x(x);
                                                        abs_aux_sede.set_y(y);

                                                        lstAbsSede[r] = abs_aux_sede;

                                                        my_pen = new Pen(Color.Salmon, 1f);

                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    if (r <= 17)
                                                    {
                                                        #region Ciclo abstract area

                                                        int index_pos = (i * 1) + ((r - 8) * 2);

                                                        abs_aux_ciclo = lstAbsCiclo[index_pos];  // 8 - 17 -> fuera
                                                        abs_aux_ciclo.set_x(x);
                                                        abs_aux_ciclo.set_y(y);

                                                        lstAbsCiclo[index_pos] = abs_aux_ciclo;

                                                        my_pen = new Pen(Color.Silver, 1f);

                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        if (r <= 21)
                                                        {
                                                            #region Semestre abstract area
                                                            int index_pos = (r - 21) + i;

                                                            abs_aux_semestre = lstAbsSemestre[index_pos];
                                                            abs_aux_semestre.set_x(x);
                                                            abs_aux_semestre.set_y(y);

                                                            lstAbsSemestre[index_pos] = abs_aux_semestre;

                                                            my_pen = new Pen(Color.Purple, 1f);

                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            if (r <= 25)
                                                            {
                                                                #region Turno abstract area
                                                                int index_pos = (r - 25) + i;


                                                                abs_aux_turno = lstAbsTurno[index_pos];
                                                                abs_aux_turno.set_x(x);
                                                                abs_aux_turno.set_y(y);

                                                                lstAbsTurno[index_pos] = abs_aux_turno;

                                                                my_pen = new Pen(Color.Orange, 1f);

                                                                #endregion
                                                            }
                                                        }

                                                    }
                                                }



                                                #endregion
                                            }
                                            else
                                            {
                                                //All vertical lines that belong to AbsQuestion
                                                if (i > 2)
                                                {
                                                    #region logic to save ordered obstract question to a lstAbsQuestions


                                                    //save abstract position on list
                                                    if ((index_x % 2) == 1)
                                                    {
                                                        //add in the first columna the object to the  list 
                                                        abs_question.set_x1(x);
                                                        abs_question.set_y1(y);

                                                        abs_question.set_idQuestion(index_y + (35 * aux_indice_columna));
                                                        abs_question.set_radio(lstCirculos.getRadio());

                                                        lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_question;

                                                    }
                                                    else
                                                    {
                                                        abs_aux_question.set_x1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_x1());
                                                        abs_aux_question.set_y1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_y1());

                                                        abs_aux_question.set_idQuestion(lstAbsQuestions[index_y].get_idQuestion());
                                                        abs_aux_question.set_radio(lstAbsQuestions[index_y].get_radio());

                                                        abs_aux_question.set_x2(x);
                                                        abs_aux_question.set_y2(y);
                                                        lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_aux_question;

                                                    }

                                                    aux_count++;

                                                    if (r == 34)
                                                    {
                                                        //for debug
                                                        int ri = 0;
                                                    }

                                                    index_y++;



                                                    if (aux_count % 70 == 0 && aux_count != 0)
                                                    {
                                                        aux_indice_columna++;
                                                    }
                                                    if (aux_count >= 350)
                                                    {// set all vallues to zero 

                                                    }
                                                    #endregion
                                                }

                                            }

                                        }

                                        //not delete this count
                                        index_x++;
                                        //----------------------

                                    }
                                    #endregion
                                }

                                if (k == 3)
                                {
                                    #region Validating areas of abstract questions, Sedes, ciclo y turno

                                    if (i != 0 && i != COLUMNAS)
                                    {
                                        dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                                        dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                                        delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                                        delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);


                                        int sign = 1;
                                        if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                                            sign *= -1;

                                        refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                                        refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                                        int index_y = 0;

                                        //pass throug of all the validated horizontal lines
                                        for (int r = 0; r <= numHorizontalLines; r++)
                                        {
                                            float x = (refPoint_X + (r * (float)delta_X_V * sign));
                                            float y = (refPoint_Y + (r * (float)delta_Y_V));

                                            //All vertical lines that belong to Sede , ciclo y turno
                                            //avoiding not desiered horizontal lines
                                            if (true)
                                            {
                                                //All vertical lines that belong to AbsQuestion
                                                //if (i > 2)
                                                if (r != 0 && r != FILAS)
                                                //if(true)
                                                {
                                                    #region logic to save ordered obstract question to a lstAbsQuestions

                                                    //my_pen = new Pen(Color.Gray, 1f);
                                                    //e.Graphics.DrawEllipse(
                                                    //        my_pen,
                                                    //        x - lstCirculos.getRadio() / 2,
                                                    //        y - lstCirculos.getRadio() / 2,
                                                    //        lstCirculos.getRadio(), lstCirculos.getRadio());



                                                    abs_big_maya.set_x1(x);
                                                    abs_big_maya.set_y1(y);

                                                    abs_big_maya.set_idQuestion(index_x);
                                                    abs_big_maya.set_radio(lstCirculos.getRadio());


                                                    lstAbsBigMaya[index_x] = abs_big_maya;
                                                    index_x++;


                                                    #endregion
                                                }

                                            }

                                        }

                                        float rr = lstAbsBigMaya[13].get_y1();
                                    }
                                    #endregion
                                }
                            }

                            #endregion


                        }

                        #endregion
        }
        
        public void ProcesseFrameToFindCircles(Image<Bgr, Byte> pImage, int iterator)
        {
            #region test_200ppp

            //if (pImg != null)
            //{
            //    //Images where to draw of what is processed
            //    imgProcessedHoughCircle = pImg.Copy();
            //    imgProcessedHoughCircle2 = pImg.Copy();


            //    ////   

            //    Image<Bgr, byte> blur = pImg.SmoothBlur(10, 10, true);
            //    //ibOriginal.Image = blur;
            //    Image<Bgr, byte> mediansmooth = pImg.SmoothMedian(3);
            //    //imageBox1.Image = mediansmooth;
            //    Image<Bgr, byte> bilat = pImg.SmoothBilatral(7, 255, 34);
            //    //imageBox2.Image = bilat;
            //    Image<Bgr, byte> gauss = pImg.SmoothGaussian(3, 3, 34.3, 45.3);
            //    //ibHoughCircles2.Image = gauss;

            //    ///


            //    //ranges
            //    imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
            //                                      new Bgr(B_MAX, G_MAX, R_MAX));
            //    ibOriginal.Image = imgProcessed;





            //    //SmoothGuassian process
            //    imgProcessed = imgProcessed.SmoothGaussian(11);
            //    ibCanny.Image = imgProcessed;


            //    /*
            //    //THRESHOLD_BINARY 
            //    imgProcessed = imgProcessed.ThresholdBinary(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary

            //    ibCanny.Image = imgProcessed;



            //    //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);

            //    //ibHoughCircles2.Image = imgSobel;
            //    imgProcessed = imgProcessed.SmoothGaussian(9);
            //    ibHoughCircles.Image = imgProcessed;

            //    */
            //    // canny process
            //    imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
            //    ibHoughCircles.Image = imgProcessedCanny;

            //    // finding all circles from image
            //    CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
            //                                                       new Gray(ACUMMULATOR_THRESHOLD),
            //                                                       2,
            //        //imgProcessed.Height / 4,
            //                                                       MIN_DIST,
            //        // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
            //                                                       MIN_RADIO,
            //                                                       MAX_RADIO)[0];

            //    //circles = null;

            //    if (circles != null)
            //    {
            //        txtTotalCircles.Text = circles.Length.ToString();

            //        for (int i = 0; i < circles.Length; i++)
            //        {
            //            CvInvoke.cvCircle(imgProcessedHoughCircle,
            //                              new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
            //                              2,
            //                              new MCvScalar(0, 255, 0),
            //                              -1,
            //                              LINE_TYPE.CV_AA,
            //                              0);
            //        }

            //        for (int i = 0; i < circles.Length; i++)
            //        {

            //            imgProcessedHoughCircle.Draw(circles[i],
            //                           new Bgr(Color.Red),
            //                           2);
            //            // mostrmo lo Id desordemandos del arreglo de circles                 
            //            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
            //            imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
            //        }

            //        ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList());


            //        //ibHoughCircles.Image = imgProcessedHoughCircle;
            //        //ibHoughCircles2.Image = imgProcessedHoughCircle2;
            //        ibHoughCircles2.Image = imgProcessedHoughCircle;
            //        imageBox1.Image = imgProcessedHoughCircle2;



            //    }

            //    //ibOriginal.Image = pImg;
            //    //ibCanny.Image = imgProcessedCanny;

            //}


            #endregion


            switch (iterator)
            {
                #region test_200ppp Better_FOTOS 3 NO inverse  => first iteration     0


                case 0:
                    #region Official


                    if (pImage != null)
                    {

                        Image<Bgr, Byte> pImg = pImage.Copy();
                        //Image<Bgr, Byte> pImgN = pImage.Copy();
                        ////ibCanny.Image = pImgN;
                        
                        ////History equalization and gamma corretion
                        //Image<Bgr, Byte> pImgEH = pImage.Copy();
                        //pImgEH._EqualizeHist();
                        //ibHoughCircles.Image = pImgEH;
                        //Image<Bgr, Byte> pImgG = pImgEH.Copy();
                        //pImgG._GammaCorrect(2.9d);
                        //ibHoughCircles2.Image = pImgG;

                        //ranges
                        imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
                                                          new Bgr(B_MAX, G_MAX, R_MAX));
                        //Image <Gray, Byte> gi = pImgG.Convert<Gray, Byte>();
                        //imgProcessed = gi.ThresholdBinary(new Gray(240),new Gray(255));
                        //ibCanny.Image = imgProcessed;

                        

                        //Test using expensive filters...not good results
                        //Image<Gray, float> imgSobel = imgProcessed.Sobel(1, 0, 23);
                        //ibHoughCircles.Image = imgSobel;
                        //imgProcessed = imgProcessed.SmoothGaussian(3);
                        //ibHoughCircles2.Image = imgProcessed;

                        //THRESHOLD_BINARY 
                        //imgProcessed = imgProcessed.ThresholdBinary(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary
                        //imgProcessed = imgProcessed.ThresholdBinaryInv(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary
                        #region MemStorage

                        

                        contoursPositions.Clear();


                        #region Circles

                        using (MemStorage stor = new MemStorage())
                        {
                            //Find contours with no holes try CV_RETR_EXTERNAL to find holes
                            contours = imgProcessed.FindContours(
                             Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                             Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL,
                             stor);

                            //contours = imgProcessed.FindContours(
                            //  Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                            //  Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_CCOMP,
                            //  stor);
                            //markers.Clear();
                            for (int i = 0; contours != null; contours = contours.HNext)
                            {
                                i++;
                                //if ((contours.Area > Math.Pow(17, 2)) && (contours.Area < Math.Pow(45, 2)))
                                if ((contours.Area > Math.Pow(7, 2)) && (contours.Area < Math.Pow(45, 2)))
                                {

                                    MCvBox2D box = contours.GetMinAreaRect();
                                    CountorsPositions cp = new CountorsPositions(box.center.X, box.center.Y,(float)contours.Area);

                                    contoursPositions.Add(cp);

                                    //pImg.Draw(box, new Bgr(System.Drawing.Color.Red), 3);
                                    //blobCount++;

                                    CvInvoke.cvCircle(pImg,
                                                      new System.Drawing.Point((int)box.center.X, (int)box.center.Y),
                                                      2,
                                                      new MCvScalar(0, 255, 0),
                                                      -1,
                                                      LINE_TYPE.CV_AA,
                                                      0);

                                    PointF p = new PointF((int)box.center.X, (int)box.center.Y);

                                    CircleF c = new CircleF(p, (float)Math.Sqrt(contours.Area));
                                    pImg.Draw(c,
                                                 new Bgr(System.Drawing.Color.Orange),
                                                 3);
                                    //markers.Add(new Point((int)box.center.X, (int)box.center.Y));

                                }
                            }
                        }
                        #endregion
//cleanList();
                        FillingAnswersToAbstractObject();
                        

                        FillingAnswerstToFinalQuestionsList();

                        //if (markers.Count == 4)
                        //{
                        //    DrawLines(markers);
                        //}
                        ////this.outImg.Source = ImageHelpers.ToBitmapSource(openCVImg);
                        ////txtBlobCount.Text = blobCount.ToString();

                        #endregion

                        


                        //ibHoughCircles.Image = imgProcessed;


                        //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);
                        //ibHoughCircles2.Image = imgSobel;
                        //imgProcessed = imgProcessed.SmoothGaussian(3);
                        //ibHoughCircles.Image = imgProcessed;


                        // canny process
                        //imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
                        //ibHoughCircles2.Image = imgProcessed;

                        // finding all circles from image
                        CircleF[] circles;/* = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
                                                                           new Gray(ACUMMULATOR_THRESHOLD),
                                                                           2,
                            //imgProcessed.Height / 4,
                                                                           MIN_DIST,
                            // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
                                                                           MIN_RADIO,
                                                                           MAX_RADIO)[0];
                        */
                        circles = null;

                        if (circles != null)
                        {
                            txtTotalCircles.Text = circles.Length.ToString();

                            for (int i = 0; i < circles.Length; i++)
                            {
                                CvInvoke.cvCircle(imgProcessedHoughCircle,
                                                  new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
                                                  2,
                                                  new MCvScalar(0, 255, 0),
                                                  -1,
                                                  LINE_TYPE.CV_AA,
                                                  0);
                            }

                            for (int i = 0; i < circles.Length; i++)
                            {

                                imgProcessedHoughCircle.Draw(circles[i],
                                               new Bgr(Color.Red),
                                               2);
                                // mostrmo lo Id desordemandos del arreglo de circles                 
                                MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
                                imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
                            }

                            // call method to make second iteration
                            //ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList(),0);


                            //ibHoughCircles.Image = imgProcessedHoughCircle;
                            //ibHoughCircles2.Image = imgProcessedHoughCircle2;
                            //ibHoughCircles2.Image = imgProcessedHoughCircle;
                            imageBox1.Image = imgProcessedHoughCircle2;



                        }

                       //ibOriginal.Image = pImg;
                        //ibCanny.Image = imgProcessedCanny;

                    }

                    break;
                    #endregion


                #region test_200ppp_Edit

                //if (pImg != null)
                //{
                //    //Images where to draw of what is processed
                //    imgProcessedHoughCircle = pImg.Copy();
                //    imgProcessedHoughCircle2 = pImg.Copy();


                //    ////   

                //    //Image<Bgr, byte> blur = pImg.SmoothBlur(10, 10, true);
                //    //ibOriginal.Image = blur;
                //    //Image<Bgr, byte> mediansmooth = pImg.SmoothMedian(3);
                //    //imageBox1.Image = mediansmooth;
                //    //Image<Bgr, byte> bilat = pImg.SmoothBilatral(7, 255, 34);
                //    //imageBox2.Image = bilat;
                //    //Image<Bgr, byte> gauss = pImg.SmoothGaussian(3, 3, 34.3, 45.3);
                //    //ibHoughCircles2.Image = gauss;

                //    ///


                //    //ranges
                //    imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
                //                                      new Bgr(B_MAX, G_MAX, R_MAX));
                //    ibOriginal.Image = imgProcessed;





                //    //SmoothGuassian process
                //    imgProcessed = imgProcessed.SmoothGaussian(31);
                //    ibCanny.Image = imgProcessed;



                //    //THRESHOLD_BINARY 
                //    imgProcessed = imgProcessed.ThresholdBinary(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary

                //    ibHoughCircles.Image = imgProcessed;



                //    //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);

                //    //ibHoughCircles2.Image = imgSobel;
                //    //imgProcessed = imgProcessed.SmoothGaussian(9);



                //    // canny process
                //    imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
                //    //ibHoughCircles.Image = imgProcessedCanny;

                //    // finding all circles from image
                //    CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
                //                                                       new Gray(ACUMMULATOR_THRESHOLD),
                //                                                       2,
                //        //imgProcessed.Height / 4,
                //                                                       MIN_DIST,
                //        // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
                //                                                       MIN_RADIO,
                //                                                       MAX_RADIO)[0];

                //    //circles = null;

                //    if (circles != null)
                //    {
                //        txtTotalCircles.Text = circles.Length.ToString();

                //        for (int i = 0; i < circles.Length; i++)
                //        {
                //            CvInvoke.cvCircle(imgProcessedHoughCircle,
                //                              new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
                //                              2,
                //                              new MCvScalar(0, 255, 0),
                //                              -1,
                //                              LINE_TYPE.CV_AA,
                //                              0);
                //        }

                //        for (int i = 0; i < circles.Length; i++)
                //        {

                //            imgProcessedHoughCircle.Draw(circles[i],
                //                           new Bgr(Color.Red),
                //                           2);
                //            // mostrmo lo Id desordemandos del arreglo de circles                 
                //            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
                //            imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
                //        }

                //        ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList(),0);


                //        //ibHoughCircles.Image = imgProcessedHoughCircle;
                //        //ibHoughCircles2.Image = imgProcessedHoughCircle2;
                //        ibHoughCircles2.Image = imgProcessedHoughCircle;
                //        imageBox1.Image = imgProcessedHoughCircle2;



                //    }

                //    //ibOriginal.Image = pImg;
                //    //ibCanny.Image = imgProcessedCanny;

                //}
                //break;

                #endregion

                #endregion

                //#region second iteration   1
                //case 1:
                //    if (pImg != null)
                //    {
                //        InicializeColorConfigurationpPen_200ppp_No_Inverse_Second_Iteration();


                //        //Images where to draw of what is processed
                //        imgProcessedHoughCircle = pImg.Copy();
                //        imgProcessedHoughCircle2 = pImg.Copy();


                //        ////   

                //        //Image<Bgr, byte> blur = pImg.SmoothBlur(10, 10, true);
                //        //ibOriginal.Image = blur;
                //        //Image<Bgr, byte> mediansmooth = pImg.SmoothMedian(13);
                //        //imageBox1.Image = mediansmooth;

                //        //imageBox1.Image = mediansmooth;
                //        //Image<Bgr, byte> bilat = pImg.SmoothBilatral(5, 255, 34);
                //        //imageBox2.Image = bilat;
                //        //Image<Bgr, byte> gauss = pImg.SmoothGaussian(7, 7, 34.3, 45.3);
                //        //imageBox1.Image = gauss;

                //        ///


                //        //ranges
                //        imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
                //                                          new Bgr(B_MAX, G_MAX, R_MAX));


                //        //ibOriginal.Image = imgProcessed;



                //        //SmoothGuassian process
                //        imgProcessed = imgProcessed.SmoothGaussian(31);
                //        ibCanny.Image = imgProcessed;



                //        //THRESHOLD_BINARY 
                //        imgProcessed = imgProcessed.ThresholdBinary(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary


                //        ibHoughCircles.Image = imgProcessed;



                //        //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);

                //        //ibHoughCircles2.Image = imgSobel;
                //        imgProcessed = imgProcessed.SmoothGaussian(9);
                //        //ibHoughCircles.Image = imgProcessed;


                //        // canny process
                //        //imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
                //        ibHoughCircles2.Image = imgProcessed;

                //        // finding all circles from image
                //        CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
                //                                                           new Gray(ACUMMULATOR_THRESHOLD),
                //                                                           2,
                //            //imgProcessed.Height / 4,
                //                                                           MIN_DIST,
                //            // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
                //                                                           MIN_RADIO,
                //                                                           MAX_RADIO)[0];

                //        //circles = null;

                //        if (circles != null)
                //        {
                //            txtTotalCircles.Text = circles.Length.ToString();

                //            for (int i = 0; i < circles.Length; i++)
                //            {
                //                CvInvoke.cvCircle(imgProcessedHoughCircle,
                //                                  new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
                //                                  2,
                //                                  new MCvScalar(0, 255, 0),
                //                                  -1,
                //                                  LINE_TYPE.CV_AA,
                //                                  0);
                //            }

                //            for (int i = 0; i < circles.Length; i++)
                //            {

                //                imgProcessedHoughCircle.Draw(circles[i],
                //                               new Bgr(Color.Red),
                //                               2);
                //                // mostrmo lo Id desordemandos del arreglo de circles                 
                //                MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
                //                imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
                //            }

                //            // call method to make second iteration
                //            ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList(), 1);


                //            //ibHoughCircles.Image = imgProcessedHoughCircle;
                //            //ibHoughCircles2.Image = imgProcessedHoughCircle2;
                //            //ibHoughCircles2.Image = imgProcessedHoughCircle;
                //            imageBox1.Image = imgProcessedHoughCircle2;



                //        }

                //        //ibOriginal.Image = pImg;
                //        //ibCanny.Image = imgProcessedCanny;

                //    }

                //    break;

                //#endregion

                //#region  third iteration    2
                //case 2:
                //    if (pImg != null)
                //    {
                //        InicializeColorConfigurationpPen_200ppp_No_Inverse_Third_Iteration();

                //        //Images where to draw of what is processed
                //        imgProcessedHoughCircle = pImg.Copy();
                //        imgProcessedHoughCircle2 = pImg.Copy();


                //        ////   

                //        //Image<Bgr, byte> blur = pImg.SmoothBlur(10, 10, true);
                //        //ibOriginal.Image = blur;
                //        //Image<Bgr, byte> mediansmooth = pImg.SmoothMedian(13);
                //        //imageBox1.Image = mediansmooth;

                //        //imageBox1.Image = mediansmooth;
                //        //Image<Bgr, byte> bilat = pImg.SmoothBilatral(5, 255, 34);
                //        //imageBox2.Image = bilat;
                //        //Image<Bgr, byte> gauss = pImg.SmoothGaussian(7, 7, 34.3, 45.3);
                //        //imageBox1.Image = gauss;

                //        ///


                //        //ranges
                //        imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
                //                                          new Bgr(B_MAX, G_MAX, R_MAX));


                //        ibOriginal.Image = imgProcessed;



                //        //SmoothGuassian process
                //        imgProcessed = imgProcessed.SmoothGaussian(23);
                //        ibCanny.Image = imgProcessed;



                //        //THRESHOLD_BINARY 
                //        imgProcessed = imgProcessed.ThresholdBinary(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary


                //        ibHoughCircles.Image = imgProcessed;



                //        //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);

                //        //ibHoughCircles2.Image = imgSobel;
                //        //imgProcessed = imgProcessed.SmoothGaussian(9);
                //        //ibHoughCircles.Image = imgProcessed;


                //        // canny process
                //        imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
                //        ibHoughCircles2.Image = imgProcessedCanny;

                //        // finding all circles from image
                //        CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
                //                                                           new Gray(ACUMMULATOR_THRESHOLD),
                //                                                           2,
                //            //imgProcessed.Height / 4,
                //                                                           MIN_DIST,
                //            // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
                //                                                           MIN_RADIO,
                //                                                           MAX_RADIO)[0];

                //        //circles = null;

                //        if (circles != null)
                //        {
                //            txtTotalCircles.Text = circles.Length.ToString();

                //            for (int i = 0; i < circles.Length; i++)
                //            {
                //                CvInvoke.cvCircle(imgProcessedHoughCircle,
                //                                  new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
                //                                  2,
                //                                  new MCvScalar(0, 255, 0),
                //                                  -1,
                //                                  LINE_TYPE.CV_AA,
                //                                  0);
                //            }

                //            for (int i = 0; i < circles.Length; i++)
                //            {

                //                imgProcessedHoughCircle.Draw(circles[i],
                //                               new Bgr(Color.Red),
                //                               2);
                //                // mostrmo lo Id desordemandos del arreglo de circles                 
                //                MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
                //                imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
                //            }

                //            // call method to make second iteration
                //            ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList(), 2);


                //            //ibHoughCircles.Image = imgProcessedHoughCircle;
                //            //ibHoughCircles2.Image = imgProcessedHoughCircle2;
                //            //ibHoughCircles2.Image = imgProcessedHoughCircle;
                //            imageBox1.Image = imgProcessedHoughCircle2;



                //        }

                //        //ibOriginal.Image = pImg;
                //        //ibCanny.Image = imgProcessedCanny;

                //    }

                //    break;

                //#endregion

            }

            #region test_200ppp Better_ VALORES EN FOTOS 1 y 2

            //if (pImg != null)
            //{
            //    //Images where to draw of what is processed
            //    imgProcessedHoughCircle = pImg.Copy();
            //    imgProcessedHoughCircle2 = pImg.Copy();


            //    ////   

            //    Image<Bgr, byte> blur = pImg.SmoothBlur(10, 10, true);
            //    ibOriginal.Image = blur;
            //    //Image<Bgr, byte> mediansmooth = pImg.SmoothMedian(13);
            //    //imageBox1.Image = mediansmooth;

            //    //imageBox1.Image = mediansmooth;
            //    //Image<Bgr, byte> bilat = pImg.SmoothBilatral(5, 255, 34);
            //    //imageBox2.Image = bilat;
            //    //Image<Bgr, byte> gauss = pImg.SmoothGaussian(7, 7, 34.3, 45.3);
            //    //imageBox1.Image = gauss;

            //    ///


            //    //ranges
            //    imgProcessed = blur.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
            //                                      new Bgr(B_MAX, G_MAX, R_MAX));


            //    ibCanny.Image = imgProcessed;



            //    //SmoothGuassian process
            //    imgProcessed = imgProcessed.SmoothGaussian(23);
            //    //ibCanny.Image = imgProcessed;



            //    //THRESHOLD_BINARY 
            //    imgProcessed = imgProcessed.ThresholdBinaryInv(new Gray(THRESHOLD_BINARY_MIN), new Gray(THRESHOLD_BINARY_MAX)); //ThresholdBinary


            //    ibHoughCircles.Image = imgProcessed;



            //    //Image<Gray,float> imgSobel = imgProcessed.Sobel(1, 0,3);

            //    //ibHoughCircles2.Image = imgSobel;
            //    //imgProcessed = imgProcessed.SmoothGaussian(9);
            //    //ibHoughCircles.Image = imgProcessed;


            //    // canny process
            //    imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));
            //    ibHoughCircles2.Image = imgProcessedCanny;

            //    // finding all circles from image
            //    CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
            //                                                       new Gray(ACUMMULATOR_THRESHOLD),
            //                                                       2,
            //        //imgProcessed.Height / 4,
            //                                                       MIN_DIST,
            //        // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
            //                                                       MIN_RADIO,
            //                                                       MAX_RADIO)[0];

            //    //circles = null;

            //    if (circles != null)
            //    {
            //        txtTotalCircles.Text = circles.Length.ToString();

            //        for (int i = 0; i < circles.Length; i++)
            //        {
            //            CvInvoke.cvCircle(imgProcessedHoughCircle,
            //                              new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
            //                              2,
            //                              new MCvScalar(0, 255, 0),
            //                              -1,
            //                              LINE_TYPE.CV_AA,
            //                              0);
            //        }

            //        for (int i = 0; i < circles.Length; i++)
            //        {

            //            imgProcessedHoughCircle.Draw(circles[i],
            //                           new Bgr(Color.Red),
            //                           2);
            //            // mostrmo lo Id desordemandos del arreglo de circles                 
            //            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
            //            imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
            //        }

            //        //ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList());


            //        //ibHoughCircles.Image = imgProcessedHoughCircle;
            //        //ibHoughCircles2.Image = imgProcessedHoughCircle2;
            //        imageBox1.Image = imgProcessedHoughCircle;
            //        imageBox2.Image = imgProcessedHoughCircle2;



            //    }

            //    //ibOriginal.Image = pImg;
            //    //ibCanny.Image = imgProcessedCanny;

            //}

            #endregion

            #region test_100ppp so so

            //if (pImg != null)
            //{
            //    //Images where to draw of what is processed
            //    imgProcessedHoughCircle = pImg.Copy();
            //    imgProcessedHoughCircle2 = pImg.Copy();

            //    //ranges
            //    imgProcessed = pImg.InRange(new Bgr(B_MIN, G_MIN, R_MIN),
            //                                            new Bgr(B_MAX, G_MAX, R_MAX));
            //    //SmoothGuassian process
            //    imgProcessed = imgProcessed.SmoothGaussian(9);


            //    // canny process
            //    imgProcessedCanny = imgProcessed.Canny(new Gray(THRESH), new Gray(THRESH_LINKING));

            //    // finding all circles from image
            //    CircleF[] circles = imgProcessedCanny.HoughCircles(new Gray(CANNY_THRESHOLD),
            //                                                       new Gray(ACUMMULATOR_THRESHOLD),
            //                                                       2,
            //        //imgProcessed.Height / 4,
            //                                                       MIN_DIST,
            //        // de 1 a 4 varia en la cantidad de pixeles a procesar, calidad de la imagen
            //        /* =>      */                                  MIN_RADIO,
            //                                                       MAX_RADIO)[0];

            //    //COMENTAR PARA HACER PRUEBAS DE CALIBRACION 
            //    //circles = null;

            //    if (circles != null)
            //    {
            //        txtTotalCircles.Text = circles.Length.ToString();

            //        for (int i = 0; i < circles.Length; i++)
            //        {
            //            CvInvoke.cvCircle(imgProcessedHoughCircle,
            //                              new Point((int)circles[i].Center.X, (int)circles[i].Center.Y),
            //                              2,
            //                              new MCvScalar(0, 255, 0),
            //                              -1,
            //                              LINE_TYPE.CV_AA,
            //                              0);
            //        }

            //        for (int i = 0; i < circles.Length; i++)
            //        {

            //            imgProcessedHoughCircle.Draw(circles[i],
            //                           new Bgr(Color.Red),
            //                           2);
            //            // mostrmo lo Id desordemandos del arreglo de circles                 
            //            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
            //            imgProcessedHoughCircle.Draw(i.ToString(), ref f, new Point((int)circles[i].Center.X + 10, (int)circles[i].Center.Y + 6), new Bgr(255, 0, 0));
            //        }

            //        ProcesseFrameToFindAnswers(imgProcessedHoughCircle2, circles.ToList());


            //        ibHoughCircles.Image = imgProcessedHoughCircle;
            //        ibHoughCircles2.Image = imgProcessedHoughCircle2;
            //    }

            //    ibOriginal.Image = pImg;
            //    ibCanny.Image = imgProcessedCanny;

            //}

            #endregion

        }

        public void ProcesseFrameToFindAnswers(Image<Bgr, Byte> pImg, List<CircleF> pCircles, int iterator)
        {

            #region ok

            //for (int iteration = 0; iteration < 2; iteration++)
            //{
            //    if (pImg != null && pCircles.Count != 0)
            //    {
            //        //Draw reference lines
            //        LineSegment2D[] answerReferenceLines;
            //        LineSegment2D[] codeNumberReferenceLines;
            //        answerReferenceLines = getAnswerReferenceLines(pImg);
            //        codeNumberReferenceLines = getCodeNumberReferenceLines(pImg);
            //        drawRefenceLines(answerReferenceLines, codeNumberReferenceLines, pImg);

            //        List<List<CircleF>> lsAnswerAndCodeNumbersOrdered = orderAnswersAndCodeNumber_ByPos_Y(pCircles,
            //                                                                                answerReferenceLines,
            //                                                                                codeNumberReferenceLines);

            //        List<List<CircleF>> lsAnswersComplete = validateQuestionBoxes(lsAnswerAndCodeNumbersOrdered,
            //                                                                                    answerReferenceLines);

            //        showID(lsAnswerAndCodeNumbersOrdered);

            //        //processAnswers(lsAnswerAndCodeNumbersOrdered, answerReferenceLines, codeNumberReferenceLines, pImg);
            //        processAnswersComplete(lsAnswersComplete, answerReferenceLines, pImg);
            //    }
            //}
            #endregion

            LineSegment2D[] answerReferenceLines;
            LineSegment2D[] codeNumberReferenceLines;
            //Draw reference lines
            answerReferenceLines = getAnswerReferenceLines(pImg);
            codeNumberReferenceLines = getCodeNumberReferenceLines(pImg);
            drawRefenceLines(answerReferenceLines, codeNumberReferenceLines, pImg);


            List<List<CircleF>> lsAnswerAndCodeNumbersOrdered;
            switch (iterator)
            {
                #region //first iteration => find blank answers spaces and invert selection (TRUE or FALSE)   1

                case 0:

                    if (pImg != null && pCircles.Count != 0)
                    {

                        lsAnswerAndCodeNumbersOrdered = orderAnswersAndCodeNumber_ByPos_Y(pCircles,
                                                                                                answerReferenceLines,
                                                                                                codeNumberReferenceLines);

                        lsMarkedAnswersPlusCode = validateQuestionBoxes(lsAnswerAndCodeNumbersOrdered,
                                                                                                   answerReferenceLines);
                        //adding a the code list 
                        lsMarkedAnswersPlusCode.Add(lsAnswerAndCodeNumbersOrdered[lsAnswerAndCodeNumbersOrdered.Count - 1]);

                        //processAnswers(lsAnswersCompletedWithNonMarkerdAnswers, answerReferenceLines, codeNumberReferenceLines, pImg);

                        // call method to make second iteration
                        //ProcesseFrameToFindCircles(pImg, 1);
                    }
                    break;

                #endregion

                #region  // second iteration => find non detected answers; then, analize erased answer to be added to List<answer> from iteration 1    2

                case 1:
                    if (pImg != null && pCircles.Count != 0)
                    {

                        lsAnswerAndCodeNumbersOrdered = orderAnswersAndCodeNumber_ByPos_Y(pCircles,
                                                                                                answerReferenceLines,
                                                                                                codeNumberReferenceLines);

                        List<List<CircleF>> lsLeftAnswers = validateQuestionBoxes(lsAnswerAndCodeNumbersOrdered,
                                                                                                    answerReferenceLines);
                        lsLeftAnswers.Add(new List<CircleF>());

                        //showID(lsAnswerAndCodeNumbersOrdered);

                        //processAnswers(lsAnswerAndCodeNumbersOrdered, answerReferenceLines, codeNumberReferenceLines, pImg);
                        //processAnswersBlackCircleSelected(lsAnswersComplete, answerReferenceLines, pImg);

                        lsAnswersCompleted = comparePositions(lsMarkedAnswersPlusCode, lsLeftAnswers, answerReferenceLines);


                        processAnswers(lsAnswersCompleted, answerReferenceLines, codeNumberReferenceLines, pImg);

                        // call method to make third iteration
                        //ProcesseFrameToFindCircles(pImg, 2);
                    }
                    break;

                #endregion

                #region thrid iteration => find codes   no iterator number

                case 2:

                    //Reuse the last vector for gettin code numbrer
                    lsAnswerAndCodeNumbersOrdered = orderAnswersAndCodeNumber_ByPos_Y(pCircles,
                                                                                            answerReferenceLines,
                                                                                            codeNumberReferenceLines);
                    //let's add the last listof code number to the lsAnswer completed
                    lsAnswersCompleted.Add(lsAnswerAndCodeNumbersOrdered[lsAnswerAndCodeNumbersOrdered.Count - 1]);

                    //List<List<CircleF>> lsAnswersComplete = validateQuestionBoxes(lsAnswerAndCodeNumbersOrdered,
                    //                                                                             answerReferenceLines);

                    //showID(lsAnswerAndCodeNumbersOrdered);

                    //processAnswersBlackCircleSelected(lsAnswersComplete, answerReferenceLines, pImg);



                    // first completation of the List<Question> => asumming that everthing is completed.
                    processAnswers(lsAnswersCompleted, answerReferenceLines, codeNumberReferenceLines, pImg);


                    break;

                #endregion
            }
        }

        private List<List<CircleF>> comparePositions(List<List<CircleF>> lsMarkedAnswersPlusCode, List<List<CircleF>> lsLeftAnswers, LineSegment2D[] rflines)
        {
            for (int i = 0; i < lsMarkedAnswersPlusCode.Count - 1; i++)
            {
                for (int j = 0; j < lsMarkedAnswersPlusCode[i].Count - 1; j++)
                {
                    if (lsMarkedAnswersPlusCode[i][j].Center.X == rflines[i].P1.X)
                    {
                        PointF p;
                        CircleF c;

                        if (lsLeftAnswers[i][j].Center.X > rflines[i].P1.X)
                        {
                            p = new PointF(rflines[i].P1.X - 60, lsLeftAnswers[i][j].Center.Y);
                        }
                        else
                        {
                            p = new PointF(rflines[i].P1.X + 60, lsLeftAnswers[i][j].Center.Y);

                        }
                        c = new CircleF(p, 20);

                        lsMarkedAnswersPlusCode[i][j] = c;
                    }
                }
            }
            return lsMarkedAnswersPlusCode;
        }

        private void processAnswersBlackCircleSelected(List<List<CircleF>> lsAnswersComplete, LineSegment2D[] pAnswerReferenceLines, Image<Bgr, byte> pImg)
        {
            Question question;

            for (int i = 0; i < lsAnswersComplete.Count; i++)
            {
                int maxLengthList = lsAnswersComplete[i].Count;
                for (int j = 0; j < maxLengthList; j++)
                {
                    // for Answers
                    // note that the last list of list is for CodeNumbers, so "-1" leave the last for letter...(else)
                    #region process answers

                    question = new Question();
                    if (lsAnswersComplete[i][j].Center.X == pAnswerReferenceLines[i].P1.X)
                    {
                        question.fillQuestion(ID_SEQUENCE + 1, "*************");
                        scalar = new MCvScalar(0, 255, 0);
                        color = new Bgr(Color.Green);
                    }
                    else
                    {
                        if (lsAnswersComplete[i][j].Center.X < pAnswerReferenceLines[i].P1.X)
                        {// Yes Answer
                            question.fillQuestion(ID_SEQUENCE + 1, "False");
                            scalar = new MCvScalar(0, 0, 255);
                            color = new Bgr(Color.Green);
                        }
                        else
                        {// No answer
                            question.fillQuestion(ID_SEQUENCE + 1, "Verdadero");
                            scalar = new MCvScalar(255, 0, 0);
                            color = new Bgr(Color.Green);
                        }



                    }
                    questions.Add(question);
                    ID_SEQUENCE++;
                    CvInvoke.cvCircle(pImg,
                                         new Point((int)lsAnswersComplete[i][j].Center.X,
                                                   (int)lsAnswersComplete[i][j].Center.Y),
                                                   6,
                                                   scalar,
                                                   -1,
                                                   LINE_TYPE.CV_AA,
                                                   0);
                    #endregion
                }
            }

        }

        private List<List<CircleF>> validateQuestionBoxes(List<List<CircleF>> lsAnswerAndCodeNumbersOrdered, LineSegment2D[] answerReferenceLines)
        {
            List<List<CircleF>> completAnswers = new List<List<CircleF>>();

            for (int k = 0; k < lsAnswerAndCodeNumbersOrdered.Count - 1; k++)
            {
                List<CircleF> completeAnswerPerReferenceLine = new List<CircleF>();

                for (int j = 5; j < 46; j++) //number if horizontal boxes
                {
                    if (j != 10 && j != 16 && j != 22 && j != 28 && j != 34 && j != 40)
                    {
                        int posCircle = isInsideHorizontalBox(lsAnswerAndCodeNumbersOrdered[k], answerReferenceLines[j], answerReferenceLines[j + 1]);
                        if (99999 != posCircle)
                        {
                            completeAnswerPerReferenceLine.Add(lsAnswerAndCodeNumbersOrdered[k][posCircle]);
                        }
                        else
                        {
                            PointF p = new PointF((answerReferenceLines[k].P1.X), (answerReferenceLines[j].P1.Y + answerReferenceLines[j + 1].P1.Y) / 2);
                            CircleF c = new CircleF(p, 12);
                            completeAnswerPerReferenceLine.Add(c);
                        }
                    }
                }

                completAnswers.Add(completeAnswerPerReferenceLine);


            }

            return completAnswers;
        }

        private int isInsideHorizontalBox(List<CircleF> circles, LineSegment2D line_Sup, LineSegment2D line_Inf)
        {
            for (int i = 0; i < circles.Count; i++)
            {
                if (circles[i].Center.Y > line_Sup.P1.Y && circles[i].Center.Y < line_Inf.P1.Y)
                    return i;
            }
            return 99999;

        }

        private void processAnswers(List<List<CircleF>> pLsOrdered, LineSegment2D[] pAnswerReferenceLines, LineSegment2D[] pCodeNumberRefenceLines, Image<Bgr, Byte> pImg)
        {
            Question question;

            for (int i = 0; i < pLsOrdered.Count; i++)
            {
                int maxLengthList = pLsOrdered[i].Count;
                for (int j = 0; j < maxLengthList; j++)
                {
                    // for Answers
                    // note that the last list of list is for CodeNumbers, so "-1" leave the last for letter...(else)
                    #region process answers

                    if (i < maxLengthList - 1)
                    {
                        question = new Question();

                        if (pLsOrdered[i][j].Center.X == pAnswerReferenceLines[i].P1.X)
                        {
                            question.fillQuestion(ID_SEQUENCE + 1, "*************");
                            scalar = new MCvScalar(0, 255, 0);
                            color = new Bgr(Color.Green);
                        }
                        else
                        {
                            if (pLsOrdered[i][j].Center.X < pAnswerReferenceLines[i].P1.X)
                            {// Yes Answer
                                question.fillQuestion(ID_SEQUENCE + 1, "True");
                                scalar = new MCvScalar(0, 0, 255);
                                color = new Bgr(Color.Green);
                            }
                            else
                            {// No answer
                                question.fillQuestion(ID_SEQUENCE + 1, "False");
                                scalar = new MCvScalar(255, 0, 0);
                                color = new Bgr(Color.Green);
                            }



                        }
                        questions.Add(question);
                        ID_SEQUENCE++;

                    }
                    #endregion

                    // for CodeNumbers
                    #region process codes number

                    else //this is the last list of circles
                    {
                        codeNumber = 0;
                        int ii = pLsOrdered[i].Count - 1;
                        //for (int k =  - 1; 0 <= k; k--)
                        for (int k = 0; k < pLsOrdered[i].Count; k++)
                        {
                            codeNumber += (int)(getDigitFromCode(pLsOrdered[i][k], pCodeNumberRefenceLines) * Math.Pow(10, ii));
                            ii--;
                        }

                        txtCode.Text = codeNumber.ToString();

                        scalar = new MCvScalar(0, 0, 0);
                        color = new Bgr(Color.Green);


                    }

                    if (pLsOrdered[i][j].Radius == 20)
                    {
                        scalar = new MCvScalar(255, 255, 0);
                    }
                    CvInvoke.cvCircle(pImg,
                                        new Point((int)pLsOrdered[i][j].Center.X,
                                                  (int)pLsOrdered[i][j].Center.Y),
                                                  15,
                                                  scalar,
                                                  -1,
                                                  LINE_TYPE.CV_AA,
                                                  0);
                    #endregion

                }
            }
        }

        public int getDigitFromCode(CircleF circle, LineSegment2D[] pReferenceLines)
        {
            // remember that the first reference line is the horizontal one ,so we do not consider the line in this porocess
            return binarySearch((int)circle.Center.X, pReferenceLines, (pReferenceLines.Count() - 2) / 2);

        }

        #region Binary Search

        public int binarySearch(int posX, LineSegment2D[] pReferenceLines, int middle)
        {
            return _binarySearch(posX, pReferenceLines, middle, pReferenceLines.Count() - 1);
        }

        public int _binarySearch(int posX, LineSegment2D[] pReferenceLines, int posCurrent, int posPast)
        {
            // if (posPast == 11 && posCurrent == 10)
            //     return 9;

            if (Math.Abs(posPast - posCurrent) <= 1 && posX < pReferenceLines[posCurrent].P1.X)
            {
                return posCurrent - 3;
            }
            if (Math.Abs(posPast - posCurrent) <= 1 && posX > pReferenceLines[posCurrent].P1.X)
            {
                return posCurrent - 2;
            }

            if (posX < pReferenceLines[posCurrent].P1.X)
            {
                return _binarySearch(posX, pReferenceLines, (int)Math.Floor(posCurrent / 2.0), posCurrent);
            }
            else
            {
                return _binarySearch(posX, pReferenceLines, (int)Math.Floor((posPast + posCurrent) / 2.0), posPast);
            }


        }

        #endregion

        #region Help Methods

        private void showID(List<List<CircleF>> pListOrdered)
        {
            int id = 0;
            for (int i = 0; i < pListOrdered.Count; i++)
            {
                for (int j = 0; j < pListOrdered[i].Count; j++)
                {
                    MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.9, 0.9);
                    imgProcessedHoughCircle2.Draw((id + 1).ToString(), ref f, new Point((int)pListOrdered[i][j].Center.X + 10, (int)pListOrdered[i][j].Center.Y + 6), new Bgr(0, 0, 255));
                    id++;
                }
            }
        }

        private List<List<CircleF>> orderAnswersAndCodeNumber_ByPos_Y(List<CircleF> pCircles, LineSegment2D[] pAnswerReferenceLines, LineSegment2D[] pCodeNumberReferenceLines)
        {
            #region Test
            //Segmentation of the answers by each line of reference
            int minDistToReferenceLine = 50;
            int maxDistFromReferenceLine = 19;
            List<List<CircleF>> lsAnswersAndCodes = new List<List<CircleF>>();
            List<CircleF> lsCodeNumbers = new List<CircleF>();

            for (int i = 0; i < pAnswerReferenceLines.Length - 42; i++)
            {
                List<CircleF> lsAnswersPerReferenceLine = new List<CircleF>();
                for (int j = 0; j < pCircles.Count; j++)
                {
                    /*
                     * filtering Answers and CodeNumbers, note that the first "pCodeNumberReferenceLines[0] " is 
                     * used for this purpuse, remember this comes from " getCodeNumberReferenceLines() "
                    */

                    // Answer Circles
                    if (Math.Abs(pAnswerReferenceLines[i].P1.X - pCircles[j].Center.X) < minDistToReferenceLine &&
                        //Math.Abs(pAnswerReferenceLines[i].P1.X - pCircles[j].Center.X) > maxDistFromReferenceLine &&
                        pCircles[j].Center.Y > pAnswerReferenceLines[5].P1.Y)
                    {

                        lsAnswersPerReferenceLine.Add(pCircles[j]);
                    }


                    // CodesNumbers Circles =>  Validate Code Zone
                    else if (pCircles[j].Center.Y > pCodeNumberReferenceLines[0].P1.Y &&
                             pCircles[j].Center.Y < pCodeNumberReferenceLines[1].P1.Y &&
                            pCircles[j].Center.X > pCodeNumberReferenceLines[2].P1.X &&
                            pCircles[j].Center.X < pCodeNumberReferenceLines[12].P1.X &&
                             lsCodeNumbers.Count < 3)
                    {
                        lsCodeNumbers.Add(pCircles[j]);
                    }

                }

                lsAnswersAndCodes.Add(lsAnswersPerReferenceLine);
            }
            //Remenber and respect the last list of circles correspondes to CodesNumber Circles
            lsAnswersAndCodes.Add(lsCodeNumbers);

            //TODO: FIX = > a Bool vector for not repeating the visit to each circle 
            // ordering anwers and codes by positions in y (quickSort), it is include all the list of list since
            // is just for orderig 
            for (int i = 0; i < lsAnswersAndCodes.Count; i++)
            {
                QuickSort(lsAnswersAndCodes[i], 0, lsAnswersAndCodes[i].Count - 1);
            }
            return lsAnswersAndCodes;
            #endregion

            #region ok
            ////Segmentation of the answers by each line of reference
            //int minDistToReferenceLine = 50;
            //List<List<CircleF>> lsAnswersAndCodes = new List<List<CircleF>>();
            //List<CircleF> lsCodeNumbers = new List<CircleF>();

            //for (int i = 0; i < pAnswerReferenceLines.Length  ; i++)
            //{
            //    List<CircleF> lsAnswersPerReferenceLine = new List<CircleF>();
            //    for (int j = 0; j < pCircles.Count; j++)
            //     {
            //        /*
            //         * filtering Answers and CodeNumbers, note that the first "pCodeNumberReferenceLines[0] " is 
            //         * used for this purpuse, remember this comes from " getCodeNumberReferenceLines() "
            //        */

            //        // Answer Circles
            //        if (Math.Abs(pAnswerReferenceLines[i].P1.X - pCircles[j].Center.X) < minDistToReferenceLine &&
            //            pCircles[j].Center.Y > pCodeNumberReferenceLines[1].P1.Y )
            //        {
            //            lsAnswersPerReferenceLine.Add(pCircles[j]);
            //        }


            //        // CodesNumbers Circles
            //        else if (pCircles[j].Center.Y > pCodeNumberReferenceLines[0].P1.Y &&
            //                 pCircles[j].Center.Y < pCodeNumberReferenceLines[1].P1.Y &&
            //                 lsCodeNumbers.Count < 3)
            //        {
            //            lsCodeNumbers.Add(pCircles[j]);
            //        }

            //    }

            //    lsAnswersAndCodes.Add(lsAnswersPerReferenceLine);
            //}
            ////Remenber and respect the last list of circles correspondes to CodesNumber Circles
            //lsAnswersAndCodes.Add(lsCodeNumbers);

            ////TODO: FIX = > a Bool vector for not repeating the visit to each circle 
            //// ordering anwers and codes by positions in y (quickSort), it is include all the list of list since
            //// is just for orderig 
            //for (int i = 0; i < lsAnswersAndCodes.Count ; i++)
            //{
            //    QuickSort(lsAnswersAndCodes[i], 0, lsAnswersAndCodes[i].Count - 1);
            //}
            //return lsAnswersAndCodes;
            #endregion
        }

        public LineSegment2D[] getAnswerReferenceLines(Image<Bgr, Byte> img)
        {


            int scala = 2;
            int totalLines = 47;
            int desface = 172 * scala;
            int horizontalLineSpace = 131 * scala;
            LineSegment2D[] referencesLines = new LineSegment2D[totalLines];
            if (img != null)
            {
                //getting VERTICAL lines for answers
                for (int i = 0; i < 5; i++)
                {
                    LineSegment2D line = makeLine(desface + (i * horizontalLineSpace),
                                                 0,
                                                 desface + (i * horizontalLineSpace),
                                                 img.Height);
                    referencesLines[i] = line;
                }

                //getting HORIZONTAL lines for answers


                int inicio = (int)(img.Height / 3.55) - 15;
                int espacio = 212;

                for (int i = 0; i < 7; i++)
                {
                    if (i == 0) horizontalDesfase_Y_1 = inicio + espacio * i;
                    if (i == 1) horizontalDesfase_Y_2 = inicio + espacio * i + 1;
                    if (i == 2) horizontalDesfase_Y_3 = inicio + espacio * i + 3;
                    if (i == 3) horizontalDesfase_Y_4 = inicio + espacio * i + 5;
                    if (i == 4) horizontalDesfase_Y_5 = inicio + espacio * i + 8;
                    if (i == 5) horizontalDesfase_Y_6 = inicio + espacio * i + 10;
                    if (i == 6) horizontalDesfase_Y_7 = inicio + espacio * i + 12;
                }

                int horizontalWidth = 38;
                for (int i = 5; i < totalLines; i++)
                {
                    int indice = (i - 5);

                    if (indice < 6)
                    {
                        LineSegment2D line = makeLine(0,
                                                    horizontalDesfase_Y_1 + indice * horizontalWidth,
                                                     img.Width,
                                                     horizontalDesfase_Y_1 + indice * horizontalWidth);
                        referencesLines[i] = line;
                    }
                    else
                    {
                        if (indice < 12)
                        {
                            indice -= 6;
                            LineSegment2D line = makeLine(0,
                                                        horizontalDesfase_Y_2 + indice * horizontalWidth,
                                                         img.Width,
                                                         horizontalDesfase_Y_2 + indice * horizontalWidth);
                            referencesLines[i] = line;
                        }
                        else
                        {
                            if (indice < 18)
                            {
                                indice -= 12;
                                LineSegment2D line = makeLine(0,
                                                            horizontalDesfase_Y_3 + indice * horizontalWidth,
                                                             img.Width,
                                                             horizontalDesfase_Y_3 + indice * horizontalWidth);
                                referencesLines[i] = line;
                            }
                            else
                            {
                                if (indice < 24)
                                {
                                    indice -= 18;
                                    LineSegment2D line = makeLine(0,
                                                                horizontalDesfase_Y_4 + indice * horizontalWidth,
                                                                 img.Width,
                                                                 horizontalDesfase_Y_4 + indice * horizontalWidth);
                                    referencesLines[i] = line;
                                }
                                else
                                {
                                    if (indice < 30)
                                    {
                                        indice -= 24;
                                        LineSegment2D line = makeLine(0,
                                                                    horizontalDesfase_Y_5 + indice * horizontalWidth,
                                                                     img.Width,
                                                                     horizontalDesfase_Y_5 + indice * horizontalWidth);
                                        referencesLines[i] = line;
                                    }
                                    else
                                    {
                                        if (indice < 36)
                                        {
                                            indice -= 30;
                                            LineSegment2D line = makeLine(0,
                                                                        horizontalDesfase_Y_6 + indice * horizontalWidth,
                                                                         img.Width,
                                                                         horizontalDesfase_Y_6 + indice * horizontalWidth);
                                            referencesLines[i] = line;
                                        }
                                        else
                                        {
                                            indice -= 36;
                                            LineSegment2D line = makeLine(0,
                                                                        horizontalDesfase_Y_7 + indice * horizontalWidth,
                                                                         img.Width,
                                                                         horizontalDesfase_Y_7 + indice * horizontalWidth);
                                            referencesLines[i] = line;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return referencesLines;
        }
        /*
        public LineSegment2D[] getAnswerReferenceLines(Image<Bgr, Byte> img)
        {
            int scala = 2;
            int totalLines = 47;
            int desface = 172 * scala;
            int horizontalLineSpace = 131 * scala;
            LineSegment2D[] referencesLines = new LineSegment2D[totalLines];
            if (img != null)
            {
                //getting VERTICAL lines for answers
                for (int i = 0; i < 5; i++)
                {
                    LineSegment2D line = makeLine(desface + (i * horizontalLineSpace),
                                                 0,
                                                 desface + (i * horizontalLineSpace),
                                                 img.Height);
                    referencesLines[i] = line;
                }

                //getting HORIZONTAL lines for answers


                int inicio = (int)(img.Height / 3.55) - 15;
                int espacio = 212;

                for (int i = 0; i < 7; i++)
                {
                    if (i == 0) horizontalDesfase_Y_1 = inicio + espacio * i;
                    if (i == 1) horizontalDesfase_Y_2 = inicio + espacio * i + 1;
                    if (i == 2) horizontalDesfase_Y_3 = inicio + espacio * i + 3;
                    if (i == 3) horizontalDesfase_Y_4 = inicio + espacio * i + 5;
                    if (i == 4) horizontalDesfase_Y_5 = inicio + espacio * i + 8;
                    if (i == 5) horizontalDesfase_Y_6 = inicio + espacio * i + 10;
                    if (i == 6) horizontalDesfase_Y_7 = inicio + espacio * i + 12;
                }

                int horizontalWidth = 38;
                for (int i = 5; i < totalLines; i++)
                {
                    int indice = (i - 5);

                    if (indice < 6)
                    {
                        LineSegment2D line = makeLine(0,
                                                    horizontalDesfase_Y_1 + indice * horizontalWidth,
                                                     img.Width,
                                                     horizontalDesfase_Y_1 + indice * horizontalWidth);
                        referencesLines[i] = line;
                    }
                    else
                    {
                        if (indice < 12)
                        {
                            indice -= 6;
                            LineSegment2D line = makeLine(0,
                                                        horizontalDesfase_Y_2 + indice * horizontalWidth,
                                                         img.Width,
                                                         horizontalDesfase_Y_2 + indice * horizontalWidth);
                            referencesLines[i] = line;
                        }
                        else
                        {
                            if (indice < 18)
                            {
                                indice -= 12;
                                LineSegment2D line = makeLine(0,
                                                            horizontalDesfase_Y_3 + indice * horizontalWidth,
                                                             img.Width,
                                                             horizontalDesfase_Y_3 + indice * horizontalWidth);
                                referencesLines[i] = line;
                            }
                            else
                            {
                                if (indice < 24)
                                {
                                    indice -= 18;
                                    LineSegment2D line = makeLine(0,
                                                                horizontalDesfase_Y_4 + indice * horizontalWidth,
                                                                 img.Width,
                                                                 horizontalDesfase_Y_4 + indice * horizontalWidth);
                                    referencesLines[i] = line;
                                }
                                else
                                {
                                    if (indice < 30)
                                    {
                                        indice -= 24;
                                        LineSegment2D line = makeLine(0,
                                                                    horizontalDesfase_Y_5 + indice * horizontalWidth,
                                                                     img.Width,
                                                                     horizontalDesfase_Y_5 + indice * horizontalWidth);
                                        referencesLines[i] = line;
                                    }
                                    else
                                    {
                                        if (indice < 36)
                                        {
                                            indice -= 30;
                                            LineSegment2D line = makeLine(0,
                                                                        horizontalDesfase_Y_6 + indice * horizontalWidth,
                                                                         img.Width,
                                                                         horizontalDesfase_Y_6 + indice * horizontalWidth);
                                            referencesLines[i] = line;
                                        }
                                        else
                                        {
                                            indice -= 36;
                                            LineSegment2D line = makeLine(0,
                                                                        horizontalDesfase_Y_7 + indice * horizontalWidth,
                                                                         img.Width,
                                                                         horizontalDesfase_Y_7 + indice * horizontalWidth);
                                            referencesLines[i] = line;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return referencesLines;
        }
        */
        public LineSegment2D[] getCodeNumberReferenceLines(Image<Bgr, Byte> pImg)
        {
            int scala = 2;

            int totalLines = 13;
            int verticalDesface = 406 * scala;
            int horizontalDesfase_Y = (int)(pImg.Height / 4.55);
            int spaceBtwVerticallines = 26 * scala;

            LineSegment2D[] verticallReferencesLines = new LineSegment2D[totalLines];
            if (pImg != null)
            {

                //first is HORIZONTAL referece line for getting the codes discrimination
                Point p1 = new Point(0, (int)(horizontalDesfase_Y / 1.5));
                Point p2 = new Point((int)pImg.Width, (int)(horizontalDesfase_Y / 1.5));
                LineSegment2D l = new LineSegment2D(p1, p2);

                verticallReferencesLines[0] = l;

                //Second is HORIZONTAL referece line for getting the codes discrimination
                p1 = new Point(0, horizontalDesfase_Y);
                p2 = new Point((int)pImg.Width, horizontalDesfase_Y);
                l = new LineSegment2D(p1, p2);

                verticallReferencesLines[1] = l;

                //referece lines for codes
                for (int i = 2; i < totalLines; i++)
                {
                    LineSegment2D line = makeLine(verticalDesface + (i * spaceBtwVerticallines),
                                                 120,
                                                 verticalDesface + (i * spaceBtwVerticallines),
                                                 horizontalDesfase_Y);
                    verticallReferencesLines[i] = line;
                }


            }

            return verticallReferencesLines;
        }

        public void drawRefenceLines(LineSegment2D[] pAnswerLines, LineSegment2D[] pCodeNumberLines, Image<Bgr, Byte> pImg)
        {
            //draw referece lines for answers
            for (int i = 0; i < pAnswerLines.Length; i++)
            {
                pImg.Draw(pAnswerLines[i], new Bgr(Color.Red), 2);
            }

            //draw referece lines for codes
            for (int i = 0; i < pCodeNumberLines.Length; i++)
            {
                pImg.Draw(pCodeNumberLines[i], new Bgr(Color.Green), 2);
            }


        }

        public LineSegment2D makeLine(int start_p1, int start_p2, int end_p1, int end_p2)
        {
            Point start = new Point(start_p1, start_p2);
            Point end = new Point(end_p1, end_p2);
            return new LineSegment2D(start, end);
        }

        public void TestAngle(/*LineSegment2D HorizontalMiddleLine*/)
        {
            Image<Bgr, Byte> imgBackground = new Image<Bgr, byte>("C:\\Users\\kevin\\Downloads\\gridBackground2.jpg");
            LineSegment2D line1 = new LineSegment2D(new Point(100, 0), new Point(200, 150));
            LineSegment2D line2 = new LineSegment2D(new Point(200, 150), new Point(150, 300));

            imgBackground.Draw(line1, new Bgr(Color.Red), 1);
            imgBackground.Draw(line2, new Bgr(Color.Blue), 1);


            Double angle = 0;
            angle = (line1.GetExteriorAngleDegree(line2));//* (180.0 / Math.PI) );

            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.6, 0.6);
            imgBackground.Draw(angle.ToString(), ref f, new Point(50, 50), new Bgr(0, 0, 0));

            //ibTestAngle.Image = imgBackground;

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (PICK_COLOR == 0) InicializeColorConfigurationpPen_200ppp();
            //if (PICK_COLOR == 1) InicializeColorConfigurationBlack();
            //if (PICK_COLOR == 2) InicializeColorConfigurationRed();
            //if (PICK_COLOR == 3) inicializeColorConfigurationBlue();

            if (flag_init)
            {
                switch (OPTION)
                {
                    case 0:

                        break;
                    case 1: // from file

                        if (BeginProcess)
                        {
                            ProcessFromFile();
                        }
                        else
                        {
                            //images.Clear(); 
                        }
                        break;

                    case 2: // from video
                        if (!Pause)
                        {
                            ProcessFromVideo();
                        }

                        break;

                }
            }
            else
            {   //drawing -> for manual calibrating

            }
            pictureBox1.Invalidate();

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
           
           
            if (images.Count() > 0)
            {
                images.Clear();
            }

            if (open.ShowDialog() == DialogResult.OK)
            {
                TOTAL_SCANNED_PAPERS = open.FileNames.Count(); 
                TOTAL_APPLICANTS = open.FileNames.Count();
                 
                pictureBox2.Width = 85;
                pictureBox2.Height = 68;
                label11.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                if (imagesNames != null) imagesNames.Clear();

                foreach (String file in open.FileNames)
                {
                    try
                    {
                        images.Add(imgInputFrame = new Image<Bgr, byte>(file));
                        imagesNames.Add(file);
                        pictureBox1.Image = new System.Drawing.Bitmap(file);

                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                    timer1.Enabled = true;
                }

                BeginProcess = true;

            }


        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (capWebCam != null && !Pause)
            {
                capWebCam.Pause();
                Pause = true;
                btnPause.Text = "Resume";
            }
            else
            {
                //capWebCam.QueryFrame();
                imgInputFrame = capWebCam.QueryFrame();
                Pause = false;
                btnPause.Text = "Pause";
            }
        }

        #region Quicksort

        public void QuickSort(List<CircleF> input, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(input, left, right);
                QuickSort(input, left, q - 1);
                QuickSort(input, q + 1, right);
            }
        }

        public int Partition(List<CircleF> input, int left, int right)
        {
            float pivot = input[right].Center.Y;
            CircleF temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (input[j].Center.Y <= pivot)
                {
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                }
            }

            CircleF aux = input[right];
            input[right] = input[i];
            input[i] = aux;

            return i;
        }

        #endregion

        #region Trackbas


        private void tbBlueMin_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbBlueMin.Value;
            lbBlueMin.Text = DYNAMIC_VALUE.ToString();
            B_MIN = DYNAMIC_VALUE;
        }

        private void tbGreenMin_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbGreenMin.Value;
            lbGreenMin.Text = DYNAMIC_VALUE.ToString();
            G_MIN = DYNAMIC_VALUE;
        }

        private void tbRedMin_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbRedMin.Value;
            lbRedMin.Text = DYNAMIC_VALUE.ToString();
            R_MIN = DYNAMIC_VALUE;

        }

        private void tbBlueMax_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbBlueMax.Value;
            lbBlueMax.Text = DYNAMIC_VALUE.ToString();
            B_MAX = DYNAMIC_VALUE;
        }

        private void tbGreenMax_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbGreenMax.Value;
            lbGreenMax.Text = DYNAMIC_VALUE.ToString();
            G_MAX = DYNAMIC_VALUE;
        }

        private void tbRedMax_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = 0;
            DYNAMIC_VALUE = tbRedMax.Value;
            lbRedMax.Text = DYNAMIC_VALUE.ToString();
            R_MAX = DYNAMIC_VALUE;
        }

        private void tbThresh_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbThresh.Value;
            lbThresh.Text = DYNAMIC_VALUE.ToString();
            THRESH = DYNAMIC_VALUE;
        }

        private void tbThrehLinking_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbThrehLinking.Value;
            lbThrehLinking.Text = DYNAMIC_VALUE.ToString();
            THRESH_LINKING = DYNAMIC_VALUE;
        }

        private void tbCannyThreshold_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbCannyThreshold.Value;
            lbCannyThreshold.Text = DYNAMIC_VALUE.ToString();
            CANNY_THRESHOLD = DYNAMIC_VALUE;

        }

        private void tbAccumulatorThreshold_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbAccumulatorThreshold.Value;
            lbAcummulatorThrehold.Text = DYNAMIC_VALUE.ToString();
            ACUMMULATOR_THRESHOLD = DYNAMIC_VALUE;
        }

        private void tbMindistBtwCir_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbMindistBtwCir.Value;
            lbMinDist.Text = DYNAMIC_VALUE.ToString();
            MIN_DIST = DYNAMIC_VALUE;
        }

        private void tbMinRadio_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbMinRadio.Value;
            lbMinRadio.Text = DYNAMIC_VALUE.ToString();
            MIN_RADIO = DYNAMIC_VALUE;
        }

        private void tbMaxRadio_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbMaxRadio.Value;
            lbMaxRadioo.Text = DYNAMIC_VALUE.ToString();
            MAX_RADIO = DYNAMIC_VALUE;

        }


        private void tbThresholdBinary_Min_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbThresholdBinary_Min.Value;
            lbThresholdBinary_Min.Text = DYNAMIC_VALUE.ToString();
            THRESHOLD_BINARY_MIN = DYNAMIC_VALUE;
        }

        private void tbThresholdBinary_Max_Scroll(object sender, EventArgs e)
        {
            DYNAMIC_VALUE = tbThresholdBinary_Max.Value;
            lbThresholdBinary_Max.Text = DYNAMIC_VALUE.ToString();
            THRESHOLD_BINARY_MAX = DYNAMIC_VALUE;
        }

        #endregion

        #region  RadioButtons

        private void rbVideo_CheckedChanged(object sender, EventArgs e)
        {
            OPTION = 2;
            
            btnOpenFile.Enabled = false;
            btnPause.Enabled = true;
            Pause = false;


        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (images != null)
                images.Clear();
            OPTION = 1;
            btnOpenFile.Enabled = true;
            btnPause.Enabled = false;

        }

        #endregion

        #region Next and Prev Images Button

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PAGE < images.Count - 1)
            {
                //kevinRemote
                flag_init = true;

                ID_SEQUENCE = 0;
                PAGE++;
                btnPreview.Enabled = true;
                BeginProcess = true;
            }
            if (PAGE == images.Count - 1)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (PAGE > 0)
            {
                //kevinRemote
                flag_init = true;

                ID_SEQUENCE = 0;
                PAGE--;
                btnNext.Enabled = true;
                BeginProcess = true;
            }
            if (PAGE == 0)
            {
                btnPreview.Enabled = false;
            }

        }

        #endregion

        #region Refresh Radio buttons of LECTURE_MODE

        private void rbAnalizeAll_CheckedChanged(object sender, EventArgs e)
        {
            refreshOptions();
           
            btnPreview.Visible = false;
            btnNext.Visible = false;
            label4.Visible = false;
            LECTURE_MODE = 0;
        }

        private void rbAnalizeOneByOne_CheckedChanged(object sender, EventArgs e)
        {
            refreshOptions();
         
            LECTURE_MODE = 1;
            
            flag_init = false;
        }

        #endregion

        private void refreshOptions()
        {
            if (LECTURE_MODE == 1)
            {
                BeginProcess = true;
                allProcessed = false;
            }
            if (LECTURE_MODE == 0)
            {
                BeginProcess = true;
                allProcessed = false;
            }
            dataGridView1.Rows.Clear();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (images == null || images.Count == 0)
            {
                MessageBox.Show("Aún no se ha cargado ningún test para corregido. Por favor seleccione almenos uno en el Paso 01 : Cargar Test.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            refreshOptions();
            if (LECTURE_MODE == 1)
            {

                btnPreview.Visible = true;
                btnNext.Visible = true;
                label4.Visible = true;

                PAGE = 0;
                btnNext.Enabled = true;
                btnPreview.Enabled= false;

            }
            flag_init = true;
            BeginProcess = true;
            //allProcessed = true;
        }


        #region ColorPicker to Track

        private void rbColorPen2B_CheckedChanged(object sender, EventArgs e)
        {
            ID_SEQUENCE = 0;
            PICK_COLOR = 0;
            refreshOptions();
        }

        private void rbColorBlack_CheckedChanged(object sender, EventArgs e)
        {
            ID_SEQUENCE = 0;
            PICK_COLOR = 1;
            refreshOptions();
        }

        private void rbColorRed_CheckedChanged(object sender, EventArgs e)
        {
            ID_SEQUENCE = 0;
            PICK_COLOR = 2;
            refreshOptions();
        }

        private void rbColorBlue_CheckedChanged(object sender, EventArgs e)
        {
            ID_SEQUENCE = 0;
            PICK_COLOR = 3;
            refreshOptions();
        }

        #endregion


        #endregion

         
        #region  Draw Mayas

        //ORIGINAL private void pictureBox1_Paint(object sender, PaintEventArgs e)

        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
            
        //    #region dibujar mayas_corner

        //    float refPoint_X = 0;
        //    float refPoint_Y = 0;
        //    float refPoint_Y_1 = 0;

        //    double delta_X_H = 0;
        //    float delta_Y_H = 0;
        //    double delta_X_V = 0;
        //    double delta_Y_V = 0;

        //    double dist_X_H = 0;
        //    float dist_Y_H = 0;
        //    double dist_X_V = 0;
        //    double dist_Y_V = 0;

        //    for (   int k = 0; k < mayas_corner.Count; k++)
        //    {
        //        Circle lstCirculos = mayas_corner[k];


        //        #region horizontal lines of the dynamic grid - Creation and Drawing

        //        int numHorizontalLines = lstCirculos.getY();

        //        double distHorizontal1 = lstCirculos.circles[2].y - lstCirculos.circles[0].y;
        //        double intervalHorizonatal1 = distHorizontal1 / numHorizontalLines;

        //        double distHorizontal2 = lstCirculos.circles[3].y - lstCirculos.circles[1].y;
        //        double intervalHorizontal2 = distHorizontal2 / numHorizontalLines;

        //        double intervalHorizontalX1 = (lstCirculos.circles[2].x - lstCirculos.circles[0].x) * 1.0 / numHorizontalLines;
        //        double intervalHorizontalX2 = (lstCirculos.circles[3].x - lstCirculos.circles[1].x) * 1.0 / numHorizontalLines;

        //        for (int i = 0; i <= numHorizontalLines; i++)
        //        {

        //            //e.Graphics.DrawLine(
        //            //           new Pen(Color.Red, 1f),
        //            //           new Point((int)((i * intervalHorizontalX1) + lstCirculos.circles[0].x), (int)((i * intervalHorizonatal1) + lstCirculos.circles[0].y)),
        //            //           new Point((int)((i * intervalHorizontalX2) + lstCirculos.circles[1].x), (int)((i * intervalHorizontal2) + lstCirculos.circles[1].y)));



        //        }
        //        #endregion

        //        #region Vertical lines of the dynamic grid - Creation and Drawing - Creating lstAbsQuestion and lstAbsOnjects

        //        int numVerticalLines = lstCirculos.getX();

        //        double distVertical1 = lstCirculos.circles[1].x - lstCirculos.circles[0].x;
        //        double intervalVertical1 = distVertical1 / numVerticalLines;

        //        double distVertical2 = lstCirculos.circles[3].x - lstCirculos.circles[2].x;
        //        double intervalVertical2 = distVertical2 / numVerticalLines;

        //        double intervalVerticalY1 = (lstCirculos.circles[1].y - lstCirculos.circles[0].y) * 1.0 / numVerticalLines;
        //        double intervalVerticalY2 = (lstCirculos.circles[3].y - lstCirculos.circles[2].y) * 1.0 / numVerticalLines;

        //        int index_x = 1;
        //        int aux_count = 0;
        //        int aux_indice_columna = 0;
        //        //pass throug of all the vertical lines 
        //        for (int i = 0; i <= numVerticalLines; i++)
        //        {
        //            #region Vertical lines of the dynamic grid - Drawing
        //            //e.Graphics.DrawLine(
        //            //           new Pen(Color.Red, 1f),
        //            //           new Point((int)((i * intervalVertical1) + lstCirculos.circles[0].x), (int)((i * intervalVerticalY1) + lstCirculos.circles[0].y)),
        //            //           new Point((int)((i * intervalVertical2) + lstCirculos.circles[2].x), (int)((i * intervalVerticalY2) + lstCirculos.circles[2].y)));
        //            #endregion

        //            if (k < 2)
        //            {
        //                #region Validation Areas of abstract DNI and Options Albergue

        //                dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
        //                dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

        //                delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
        //                delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);

        //                int sign = 1;
        //                //if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
        //                if (lstCirculos.circles[2].x < lstCirculos.circles[0].x ||
        //                    lstCirculos.circles[1].x < lstCirculos.circles[3].x)
        //                    sign *= -1;

        //                refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
        //                refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

        //                for (int r = 0; r <= numHorizontalLines; r++)
        //                {

        //                    float x = (refPoint_X + (r * (float)delta_X_V * sign));
        //                    float y = (refPoint_Y + (r * (float)delta_Y_V));

        //                    if (k == 0)
        //                    {

        //                        #region This is the DNI abstract area
        //                        int pos = (r * 8) + i;

        //                        abs_aux_DNI = lstAbsDNI[pos];
        //                        abs_aux_DNI.set_x(x);
        //                        abs_aux_DNI.set_y(y);

        //                        lstAbsDNI[pos] = abs_aux_DNI;

        //                        my_pen = new Pen(Color.Green, 1f);

        //                        #endregion
        //                    }
        //                    if (k == 1)
        //                    {
        //                        #region This is the Option Albergue abstract area
        //                        int pos = (r * 2) + i;

        //                        abs_aux_option = lstAbsOptions[pos];
        //                        abs_aux_option.set_x(x);
        //                        abs_aux_option.set_y(y);

        //                        lstAbsOptions[pos] = abs_aux_option;


        //                        my_pen = new Pen(Color.PaleVioletRed, 1f);

        //                        #endregion
        //                    }
        //                    e.Graphics.DrawEllipse(
        //                            my_pen,
        //                            x - lstCirculos.getRadio() / 2,
        //                            y - lstCirculos.getRadio() / 2,
        //                            lstCirculos.getRadio(), lstCirculos.getRadio());
        //                }
        //                #endregion
        //            }
        //            else
        //            {
        //                #region Validating areas of abstract questions, Sedes, ciclo y turno

        //                if (i != 2 &&
        //                    i != 3 &&
        //                    i != 4 &&
        //                    i != 7 &&
        //                    i != 8 &&
        //                    i != 9 &&
        //                    i != 12 &&
        //                    i != 13 &&
        //                    i != 14 &&
        //                    i != 17 &&
        //                    i != 18 &&
        //                    i != 19 &&
        //                    i != 22 &&
        //                    i != 23 &&
        //                    i != 24)
        //                {
        //                    dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
        //                    dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

        //                    delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
        //                    delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);


        //                    int sign = 1;
        //                    if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
        //                        sign *= -1;

        //                    refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
        //                    refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

        //                    int index_y = 0;

        //                    //pass throug of all the validated horizontal lines
        //                    for (int r = 0; r <= numHorizontalLines; r++)
        //                    {
        //                        float x = (refPoint_X + (r * (float)delta_X_V * sign));
        //                        float y = (refPoint_Y + (r * (float)delta_Y_V));

        //                        //All vertical lines that belong to Sede , ciclo y turno
        //                        //avoiding not desiered horizontal lines
        //                        if (r != 5 && r != 26 &&
        //                            r != 6 && r != 27 &&
        //                            r != 7 && r != 28 &&
        //                            r != 18 && r != 29 &&
        //                            r != 19 && r != 30 &&
        //                            r != 20 && r != 31 &&
        //                            r != 22 && r != 32 &&
        //                            r != 23 && r != 33 &&
        //                            r != 24 && r != 34 && (i == 0 || i == 1))
        //                        {

        //                            #region logic to save obstrat object to a lstAbsOjects of Sede , ciclo y turno


        //                            if (r <= 4)
        //                            {
        //                                #region Sedes Abstrac area
        //                                if (i == 1)
        //                                {
        //                                    abs_aux_sede = lstSede[r];
        //                                    abs_aux_sede.set_x(x);
        //                                    abs_aux_sede.set_y(y);

        //                                    lstSede[r] = abs_aux_sede;

        //                                    my_pen = new Pen(Color.Salmon, 1f);

        //                                }
        //                                #endregion
        //                            }
        //                            else
        //                            {
        //                                if (r <= 17)
        //                                {
        //                                    #region Ciclo abstract area

        //                                    int index_pos = (i * 1) + ((r - 8) * 2);

        //                                    abs_aux_ciclo = lstCiclo[index_pos];  // 8 - 17 -> fuera
        //                                    abs_aux_ciclo.set_x(x);
        //                                    abs_aux_ciclo.set_y(y);

        //                                    lstCiclo[index_pos] = abs_aux_ciclo;

        //                                    my_pen = new Pen(Color.Silver, 1f);

        //                                    #endregion
        //                                }
        //                                else
        //                                {
        //                                    if (r <= 21)
        //                                    {
        //                                        #region Semestre abstract area
        //                                        int index_pos = (r - 21) + i;

        //                                        abs_aux_semestre = lstSemestre[index_pos];
        //                                        abs_aux_semestre.set_x(x);
        //                                        abs_aux_semestre.set_y(y);

        //                                        lstSemestre[index_pos] = abs_aux_semestre;

        //                                        my_pen = new Pen(Color.Purple, 1f);

        //                                        #endregion
        //                                    }
        //                                    else
        //                                    {
        //                                        if (r <= 25)
        //                                        {
        //                                            #region Turno abstract area
        //                                            int index_pos = (r - 25) + i;


        //                                            abs_aux_turno = lstTurno[index_pos];
        //                                            abs_aux_turno.set_x(x);
        //                                            abs_aux_turno.set_y(y);

        //                                            lstTurno[index_pos] = abs_aux_turno;

        //                                            my_pen = new Pen(Color.Orange, 1f);

        //                                            #endregion
        //                                        }
        //                                    }

        //                                }
        //                            }


        //                            if (!(r < 5 && i == 0))
        //                            {
        //                                e.Graphics.DrawEllipse(
        //                                       my_pen,
        //                                       x - lstCirculos.getRadio() / 2,
        //                                       y - lstCirculos.getRadio() / 2,
        //                                       lstCirculos.getRadio(), lstCirculos.getRadio());
        //                            }

        //                            #endregion
        //                        }
        //                        else
        //                        {
        //                            //All vertical lines that belong to AbsQuestion
        //                            if (i > 2)
        //                            {
        //                                #region logic to save ordered obstract question to a lstAbsQuestions

        //                                my_pen = new Pen(Color.Red, 1f);
        //                                e.Graphics.DrawEllipse(
        //                                        my_pen,
        //                                        x - lstCirculos.getRadio() / 2,
        //                                        y - lstCirculos.getRadio() / 2,
        //                                        lstCirculos.getRadio(), lstCirculos.getRadio());


        //                                //save abstract position on list
        //                                if ((index_x % 2) == 1)
        //                                {
        //                                    //add in the first columna the object to the  list 
        //                                    abs_question.set_x1(x);
        //                                    abs_question.set_y1(y);

        //                                    abs_question.set_idQuestion(index_y + (35 * aux_indice_columna));
        //                                    abs_question.set_radio(lstCirculos.getRadio());

        //                                    lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_question;

        //                                }
        //                                else
        //                                {
        //                                    abs_aux_question.set_x1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_x1());
        //                                    abs_aux_question.set_y1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_y1());

        //                                    abs_aux_question.set_idQuestion(lstAbsQuestions[index_y].get_idQuestion());
        //                                    abs_aux_question.set_radio(lstAbsQuestions[index_y].get_radio());

        //                                    abs_aux_question.set_x2(x);
        //                                    abs_aux_question.set_y2(y);
        //                                    lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_aux_question;

        //                                }

        //                                aux_count++;

        //                                if (r == 34)
        //                                {
        //                                    //for debug
        //                                    int ri = 0;
        //                                }

        //                                index_y++;



        //                                if (aux_count % 70 == 0 && aux_count != 0)
        //                                {
        //                                    aux_indice_columna++;
        //                                }
        //                                if (aux_count >= 350)
        //                                {// set all vallues to zero 

        //                                }
        //                                #endregion
        //                            }

        //                        }

        //                    }

        //                    //not delete this count
        //                    index_x++;
        //                    //----------------------

        //                }
        //                #endregion
        //            }
        //        }

        //        #endregion

        //        #region draw the 4 squares that can be drag and drop

        //        for (int i = 0; i < lstCirculos.circles.Count; i++)
        //        {
        //            e.Graphics.DrawEllipse(
        //                new Pen(Color.Black, 1f),
        //                lstCirculos.circles[i].getX() - (lstCirculos.circles[i].getRadio() / 2),
        //                lstCirculos.circles[i].getY() - (lstCirculos.circles[i].getRadio() / 2),
        //                lstCirculos.circles[i].getRadio(), lstCirculos.circles[i].getRadio());
        //        }

        //        #endregion
        //    }

        //    #endregion

        //    #region test - Drawing numbers of idQuestions
        //    for (int i = 0; i < lstTurno.Count; i++)
        //    {

        //        //e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Black, lstAbsQuestions[i].get_x1(), lstAbsQuestions[i].get_y1());
        //        //e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Red, lstAbsQuestions[i].get_x2(), lstAbsQuestions[i].get_y2());

        //        //e.Graphics.DrawString(lstAbsDNI[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstAbsDNI[i].get_x(), lstAbsDNI[i].get_y());

        //        //e.Graphics.DrawString(lstAbsOptions[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstAbsOptions[i].get_x(), lstAbsOptions[i].get_y());

        //        //e.Graphics.DrawString(lstCiclo[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstCiclo[i].get_x(), lstCiclo[i].get_y());

        //        //e.Graphics.DrawString(lstSemestre[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstSemestre[i].get_x(), lstSemestre[i].get_y());

        //        //e.Graphics.DrawString(lstTurno[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstTurno[i].get_x(), lstTurno[i].get_y());



        //    }
        //    #endregion
        //}
  
        #region 31  de diciembre

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            #region dibujar mayas_corner

            float refPoint_X = 0;
            float refPoint_Y = 0;
            float refPoint_Y_1 = 0;

            double delta_X_H = 0;
            float delta_Y_H = 0;
            double delta_X_V = 0;
            double delta_Y_V = 0;

            double dist_X_H = 0;
            float dist_Y_H = 0;
            double dist_X_V = 0;
            double dist_Y_V = 0;


              
            
            
            for (int k = 0; k < mayas_corner.Count ; k++)
            {
                Circle lstCirculos = mayas_corner[k];// 46 + 2 (drag & drop circles) =  48 insted (horizontal lines)
                                                                             //  28        (vertical lines)


                #region horizontal lines of the dynamic grid - Creation and Drawing

                int numHorizontalLines = (int)lstCirculos.getY();

                double distHorizontal1 = lstCirculos.circles[2].y - lstCirculos.circles[0].y;
                double intervalHorizonatal1 = distHorizontal1 / numHorizontalLines;

                double distHorizontal2 = lstCirculos.circles[3].y - lstCirculos.circles[1].y;
                double intervalHorizontal2 = distHorizontal2 / numHorizontalLines;

                double intervalHorizontalX1 = (lstCirculos.circles[2].x - lstCirculos.circles[0].x) * 1.0 / numHorizontalLines;
                double intervalHorizontalX2 = (lstCirculos.circles[3].x - lstCirculos.circles[1].x) * 1.0 / numHorizontalLines;

                for (int i = 0; i <= numHorizontalLines; i++)
                {

                    //e.Graphics.DrawLine(
                    //           new Pen(Color.Red, 1f),
                    //           new Point((int)((i * intervalHorizontalX1) + lstCirculos.circles[0].x), (int)((i * intervalHorizonatal1) + lstCirculos.circles[0].y)),
                    //           new Point((int)((i * intervalHorizontalX2) + lstCirculos.circles[1].x), (int)((i * intervalHorizontal2) + lstCirculos.circles[1].y)));



                }
                #endregion

                #region Vertical lines of the dynamic grid - Creation and Drawing - Creating lstAbsQuestion and lstAbsOnjects

                int numVerticalLines = (int)lstCirculos.getX();

                double distVertical1 = lstCirculos.circles[1].x - lstCirculos.circles[0].x;
                double intervalVertical1 = distVertical1 / numVerticalLines;

                double distVertical2 = lstCirculos.circles[3].x - lstCirculos.circles[2].x;
                double intervalVertical2 = distVertical2 / numVerticalLines;

                double intervalVerticalY1 = (lstCirculos.circles[1].y - lstCirculos.circles[0].y) * 1.0 / numVerticalLines;
                double intervalVerticalY2 = (lstCirculos.circles[3].y - lstCirculos.circles[2].y) * 1.0 / numVerticalLines;

                int index_x = 1;
                int aux_count = 0;
                int aux_indice_columna = 0;
                //pass throug of all the vertical lines 
                for (int i = 0; i <= numVerticalLines; i++)
                {
                    #region Vertical lines of the dynamic grid - Drawing
                    //e.Graphics.DrawLine(
                    //           new Pen(Color.Red, 1f),
                    //           new Point((int)((i * intervalVertical1) + lstCirculos.circles[0].x), (int)((i * intervalVerticalY1) + lstCirculos.circles[0].y)),
                    //           new Point((int)((i * intervalVertical2) + lstCirculos.circles[2].x), (int)((i * intervalVerticalY2) + lstCirculos.circles[2].y)));
                    #endregion
                    if (k < 2)
                    //if(false)
                    {
                        #region Validation Areas of abstract DNI and Options Albergue

                        dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                        dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                        delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                        delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);

                        int sign = 1;
                        if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                        //if (lstCirculos.circles[2].x < lstCirculos.circles[0].x ||
                        //    lstCirculos.circles[1].x < lstCirculos.circles[3].x)
                            sign *= -1;

                        refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                        refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                        for (int r = 0; r <= numHorizontalLines; r++)
                        {

                            float x = (refPoint_X + (r * (float)delta_X_V * sign));
                            float y = (refPoint_Y + (r * (float)delta_Y_V));

                            if (k == 0)
                            {

                                #region This is the DNI abstract area
                                int pos = (r * 8) + i;

                                abs_aux_DNI = lstAbsDNI[pos];
                                abs_aux_DNI.set_x(x);
                                abs_aux_DNI.set_y(y);

                                lstAbsDNI[pos] = abs_aux_DNI;

                                //my_pen = new Pen(Color.Green, 1f);
                                my_pen = new Pen(Color.LightGray, 1f);

                                #endregion
                            }
                            if (k == 1)
                            {
                                #region This is the Option Albergue abstract area
                                int pos = (r * 2) + i;

                                abs_aux_option = lstAbsOptions[pos];
                                abs_aux_option.set_x(x);
                                abs_aux_option.set_y(y);

                                lstAbsOptions[pos] = abs_aux_option;


                                //my_pen = new Pen(Color.PaleVioletRed, 1f);
                                my_pen = new Pen(Color.LightGray, 1f);


                                #endregion
                            }
                            e.Graphics.DrawEllipse(
                                    my_pen,
                                    x - lstCirculos.getRadio() / 2,
                                    y - lstCirculos.getRadio() / 2,
                                    lstCirculos.getRadio(), lstCirculos.getRadio());
                        }
                        #endregion
                    }
                    //else
                    if(k==2)
                    {
                        #region Validating areas of abstract questions, Sedes, ciclo y turno

                        if (i != 2 &&
                            i != 3 &&
                            i != 4 &&
                            i != 7 &&
                            i != 8 &&
                            i != 9 &&
                            i != 12 &&
                            i != 13 &&
                            i != 14 &&
                            i != 17 &&
                            i != 18 &&
                            i != 19 &&
                            i != 22 &&
                            i != 23 &&
                            i != 24)
                        {
                            dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                            dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                            delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                            delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);


                            int sign = 1;
                            if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                                sign *= -1;

                            refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                            refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                            int index_y = 0;

                            //pass throug of all the validated horizontal lines
                            for (int r = 0; r <= numHorizontalLines; r++)
                            {
                                float x = (refPoint_X + (r * (float)delta_X_V * sign));
                                float y = (refPoint_Y + (r * (float)delta_Y_V));

                                //All vertical lines that belong to Sede , ciclo y turno
                                //avoiding not desiered horizontal lines
                                if (r != 5 && r != 26 &&
                                    r != 6 && r != 27 &&
                                    r != 7 && r != 28 &&
                                    r != 18 && r != 29 &&
                                    r != 19 && r != 30 &&
                                    r != 20 && r != 31 &&
                                    r != 22 && r != 32 &&
                                    r != 23 && r != 33 &&
                                    r != 24 && r != 34 && (i == 0 || i == 1))
                                {

                                    #region logic to save obstrat object to a lstAbsOjects of Sede , ciclo y turno


                                    if (r <= 4)
                                    {
                                        #region Sedes Abstrac area
                                        if (i == 1)
                                        {
                                            abs_aux_sede = lstAbsSede[r];
                                            abs_aux_sede.set_x(x);
                                            abs_aux_sede.set_y(y);

                                            lstAbsSede[r] = abs_aux_sede;

                                            //my_pen = new Pen(Color.Salmon, 1f);
                                            my_pen = new Pen(Color.LightGray, 1f);

                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        if (r <= 17)
                                        {
                                            #region Ciclo abstract area

                                            int index_pos = (i * 1) + ((r - 8) * 2);

                                            abs_aux_ciclo = lstAbsCiclo[index_pos];  // 8 - 17 -> fuera
                                            abs_aux_ciclo.set_x(x);
                                            abs_aux_ciclo.set_y(y);

                                            lstAbsCiclo[index_pos] = abs_aux_ciclo;

                                            //my_pen = new Pen(Color.Silver, 1f);
                                            my_pen = new Pen(Color.LightGray, 1f);

                                            #endregion
                                        }
                                        else
                                        {
                                            if (r <= 21)
                                            {
                                                #region Semestre abstract area
                                                int index_pos = (r - 21) + i;

                                                abs_aux_semestre = lstAbsSemestre[index_pos];
                                                abs_aux_semestre.set_x(x);
                                                abs_aux_semestre.set_y(y);

                                                lstAbsSemestre[index_pos] = abs_aux_semestre;

                                                //my_pen = new Pen(Color.Purple, 1f);
                                                my_pen = new Pen(Color.LightGray, 1f);

                                                #endregion
                                            }
                                            else
                                            {
                                                if (r <= 25)
                                                {
                                                    #region Turno abstract area
                                                    int index_pos = (r - 25) + i;


                                                    abs_aux_turno = lstAbsTurno[index_pos];
                                                    abs_aux_turno.set_x(x);
                                                    abs_aux_turno.set_y(y);

                                                    lstAbsTurno[index_pos] = abs_aux_turno;

                                                    //my_pen = new Pen(Color.Orange, 1f);
                                                    my_pen = new Pen(Color.LightGray, 1f);

                                                    #endregion
                                                }
                                            }

                                        }
                                    }


                                    if (!(r < 5 && i == 0))
                                    {
                                        e.Graphics.DrawEllipse(
                                               my_pen,
                                               x - lstCirculos.getRadio() / 2,
                                               y - lstCirculos.getRadio() / 2,
                                               lstCirculos.getRadio(), lstCirculos.getRadio());
                                    }

                                    #endregion
                                }
                                else
                                {
                                    //All vertical lines that belong to AbsQuestion
                                    if (i > 2)
                                    {
                                        #region logic to save ordered obstract question to a lstAbsQuestions

                                        //my_pen = new Pen(Color.Red, 1f);
                                        my_pen = new Pen(Color.LightGray, 1f);
                                        
                                        e.Graphics.DrawEllipse(
                                                my_pen,
                                                x - lstCirculos.getRadio() / 2,
                                                y - lstCirculos.getRadio() / 2,
                                                lstCirculos.getRadio(), lstCirculos.getRadio());


                                        //save abstract position on list
                                        if ((index_x % 2) == 1)
                                        {
                                            //add in the first columna the object to the  list 
                                            abs_question.set_x1(x);
                                            abs_question.set_y1(y);

                                            abs_question.set_idQuestion(index_y + (35 * aux_indice_columna));
                                            abs_question.set_radio(lstCirculos.getRadio());

                                            lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_question;

                                        }
                                        else
                                        {
                                            abs_aux_question.set_x1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_x1());
                                            abs_aux_question.set_y1(lstAbsQuestions[index_y + (35 * aux_indice_columna)].get_y1());

                                            abs_aux_question.set_idQuestion(lstAbsQuestions[index_y].get_idQuestion());
                                            abs_aux_question.set_radio(lstAbsQuestions[index_y].get_radio());

                                            abs_aux_question.set_x2(x);
                                            abs_aux_question.set_y2(y);
                                            lstAbsQuestions[index_y + (35 * aux_indice_columna)] = abs_aux_question;

                                        }

                                        aux_count++;

                                        if (r == 34)
                                        {
                                            //for debug
                                            int ri = 0;
                                        }

                                        index_y++;



                                        if (aux_count % 70 == 0 && aux_count != 0)
                                        {
                                            aux_indice_columna++;
                                        }
                                        if (aux_count >= 350)
                                        {// set all vallues to zero 

                                        }
                                        #endregion
                                    }

                                }

                            }

                            //not delete this count
                            index_x++;
                            //----------------------

                        }
                        #endregion
                    }

                    if (k == 3)
                    {
                        #region Validating areas of abstract questions, Sedes, ciclo y turno

                        if (i != 0 && i != COLUMNAS)
                        {
                            dist_X_V = Math.Abs(((i * intervalVertical1) + lstCirculos.circles[0].x) - ((i * intervalVertical2) + lstCirculos.circles[2].x));
                            dist_Y_V = Math.Abs(((i * intervalVerticalY1) + lstCirculos.circles[0].y) - ((i * intervalVerticalY2) + lstCirculos.circles[2].y));

                            delta_X_V = (dist_X_V * 1.0 / numHorizontalLines);
                            delta_Y_V = (dist_Y_V * 1.0 / numHorizontalLines);


                            int sign = 1;
                            if (lstCirculos.circles[2].x < lstCirculos.circles[0].x)
                                sign *= -1;

                            refPoint_X = (float)((i * intervalVertical1) + lstCirculos.circles[0].x);
                            refPoint_Y = (float)((i * intervalVerticalY1) + lstCirculos.circles[0].y);

                            int index_y = 0;

                            //pass throug of all the validated horizontal lines
                            for (int r = 0; r <= numHorizontalLines; r++)
                            {
                                float x = (refPoint_X + (r * (float)delta_X_V * sign));
                                float y = (refPoint_Y + (r * (float)delta_Y_V));

                                //All vertical lines that belong to Sede , ciclo y turno
                                //avoiding not desiered horizontal lines
                                if (true)
                                {
                                    //All vertical lines that belong to AbsQuestion
                                    //if (i > 2)
                                    if (r != 0 && r!= FILAS)
                                    //if(true)
                                    {
                                        #region logic to save ordered obstract question to a lstAbsQuestions

                                        //my_pen = new Pen(Color.Gray, 1f);
                                        //e.Graphics.DrawEllipse(
                                        //        my_pen,
                                        //        x - lstCirculos.getRadio() / 2,
                                        //        y - lstCirculos.getRadio() / 2,
                                        //        lstCirculos.getRadio(), lstCirculos.getRadio());



                                        abs_big_maya.set_x1(x);
                                        abs_big_maya.set_y1(y);

                                        abs_big_maya.set_idQuestion(index_x);
                                        abs_big_maya.set_radio(lstCirculos.getRadio());


                                        lstAbsBigMaya[index_x] = abs_big_maya;
                                        index_x++;


                                        #endregion
                                    }

                                }

                            }

                            float rr = lstAbsBigMaya[13].get_y1();
                        }
                        #endregion
                    }
                }

                #endregion

                #region draw the 4 squares that can be drag and drop
                if (k == 3)
                {
                    for (int i = 0; i < lstCirculos.circles.Count; i++)
                    {
                        e.Graphics.DrawRectangle(
                            new Pen(Color.Red, 2f),
                            lstCirculos.circles[i].getX() - (lstCirculos.circles[i].getRadio() / 2),
                            lstCirculos.circles[i].getY() - (lstCirculos.circles[i].getRadio() / 2),
                            lstCirculos.circles[i].getRadio(), lstCirculos.circles[i].getRadio());
                    }
                }
                #endregion
            }

            #endregion

            #region test - Drawing numbers of idQuestions
            int index = 0;
            for (int i = 0; i < lstAbsBigMaya.Count; i++)
            {

                //e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Black, lstAbsQuestions[i].get_x1(), lstAbsQuestions[i].get_y1());
                //e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Red, lstAbsQuestions[i].get_x2(), lstAbsQuestions[i].get_y2());

                //e.Graphics.DrawString(lstAbsDNI[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstAbsDNI[i].get_x(), lstAbsDNI[i].get_y());

                //e.Graphics.DrawString(lstAbsOptions[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstAbsOptions[i].get_x(), lstAbsOptions[i].get_y());

                //e.Graphics.DrawString(lstCiclo[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstCiclo[i].get_x(), lstCiclo[i].get_y());

                //e.Graphics.DrawString(lstSemestre[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstSemestre[i].get_x(), lstSemestre[i].get_y());

                //e.Graphics.DrawString(lstTurno[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstTurno[i].get_x(), lstTurno[i].get_y());

                //e.Graphics.DrawString(lstTurno[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstTurno[i].get_x(), lstTurno[i].get_y());

//                lstAbsBigMaya[i].set_idQuestion(index);

//                FontFamily fontFamily = new FontFamily("Arial");
//Font f = new Font(
//   fontFamily,
//   6,
//   FontStyle.Regular,
//   GraphicsUnit.Pixel);

//                e.Graphics.DrawString(lstAbsBigMaya[i].get_idQuestion().ToString(), f, Brushes.Black, lstAbsBigMaya[i].get_x1(), lstAbsBigMaya[i].get_y1());
                //e.Graphics.DrawString(lstAbsBigMaya[i].get_idQuestion().ToString(), this.Font, Brushes.Red, lstAbsBigMaya[i].get_x2(), lstAbsBigMaya[i].get_y2());

                index++;
            }
            #endregion
        }


        #endregion

        #region Methods of Mayas

        public void CleanAllList()
        {

            //txtCode=-1;
            opcion_01 = -1;
            opcion_02 = -1;
            codigo_sede = -1;
            num_01 = -1;
            num_02 = -1;
            codigo_semestre = -1;
            codigo_turno = -1;
            //Question

            for (int k = 0; k < lstAbsQuestions.Count(); k++)
            {
                AbstractQuestion absQuestion = new AbstractQuestion();
                absQuestion = lstAbsQuestions[k];
                absQuestion.set_respuesta(-1);
                lstAbsQuestions[k] = absQuestion;
            }

            //DNI
            txtCode.Text = "";
            for (int j = 0; j < lstAbsDNI.Count(); j++)
            {
                AbstractObject absDNI = new AbstractObject();
                absDNI = lstAbsDNI[j];
                absDNI.set_respuesta(-1);
                lstAbsDNI[j] = absDNI;
            }

            //Opcion

            for (int j = 0; j < lstAbsOptions.Count(); j++)
            {
                AbstractObject absOpcion = new AbstractObject();
                absOpcion = lstAbsOptions[j];
                absOpcion.set_respuesta(-1);
                lstAbsOptions[j] = absOpcion;
            }

            //Sede

            for (int j = 0; j < lstAbsSede.Count(); j++)
            {
                AbstractObject absSede = new AbstractObject();
                absSede = lstAbsSede[j];
                absSede.set_respuesta(-1);
                lstAbsSede[j] = absSede;
            }

            //Ciclo

            for (int j = 0; j < lstAbsCiclo.Count(); j++)
            {
                AbstractObject absCiclo = new AbstractObject();
                absCiclo = lstAbsCiclo[j];
                absCiclo.set_respuesta(-1);
                lstAbsCiclo[j] = absCiclo;
            }

            //Semestre

            for (int j = 0; j < lstAbsSemestre.Count(); j++)
            {
                AbstractObject absSemestre = new AbstractObject();
                absSemestre = lstAbsSemestre[j];
                absSemestre.set_respuesta(-1);
               lstAbsSemestre[j] = absSemestre;
            }

            //turno

            for (int j = 0; j < lstAbsTurno.Count(); j++)
            {
                AbstractObject absTurno = new AbstractObject();
                absTurno = lstAbsTurno[j];
                absTurno.set_respuesta(-1);
                lstAbsTurno[j] = absTurno;
            }


        }

        public void FillingAnswersToAbstractObject()
        {
            //Question
            for (int k = 0; k < lstAbsQuestions.Count(); k++)
            {
                    AbstractQuestion absQuestion = lstAbsQuestions[k];

                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    //True abstract area
                    double dist_1 = Math.Pow((contour.x / scala_x - absQuestion.get_x1()), 2) + Math.Pow((contour.y / scala_y - absQuestion.get_y1()), 2);
                    double res_1 = Math.Sqrt(dist_1);
                    if (res_1 <= absQuestion.get_radio() / 2)
                    {
                        absQuestion.set_respuesta(1);
                        lstAbsQuestions[k] = absQuestion;
                    }

                    //False abstract area
                    double dist_2 = Math.Pow((contour.x / scala_x - absQuestion.get_x2()), 2) + Math.Pow((contour.y / scala_y - absQuestion.get_y2()), 2);
                    double res_2 = Math.Sqrt(dist_2);
                    if (res_2 <= absQuestion.get_radio() / 2)
                    {
                        absQuestion.set_respuesta(2);
                        lstAbsQuestions[k] = absQuestion;
                    }

                }
            }

            //DNI

            for (int j = 0; j < lstAbsDNI.Count(); j++)
            {
                AbstractObject absDNI = lstAbsDNI[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];
                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absDNI.get_x()), 2) + Math.Pow((contour.y / scala_y - absDNI.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res < absDNI.get_radio() / 2)
                        {
                            absDNI.set_respuesta(1);
                            lstAbsDNI[j] = absDNI;
                        }                      
                    }                      

                }
            }

            //Opcion

            for (int j = 0; j < lstAbsOptions.Count(); j++)
            {
                AbstractObject absOpcion = lstAbsOptions[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absOpcion.get_x()), 2) + Math.Pow((contour.y / scala_y - absOpcion.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res <= absOpcion.get_radio() / 2)
                        {
                            absOpcion.set_respuesta(1);
                            lstAbsOptions[j] = absOpcion;
                        }
                    }

                }
            }

            //Sede

            for (int j = 0; j < lstAbsSede.Count(); j++)
            {
                AbstractObject absSede = lstAbsSede[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absSede.get_x()), 2) + Math.Pow((contour.y / scala_y - absSede.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res <= absSede.get_radio() / 2)
                        {
                            absSede.set_respuesta(1);
                            lstAbsSede[j] = absSede;
                        }
                    }

                }
            }

            //Ciclo

            for (int j = 0; j < lstAbsCiclo.Count(); j++)
            {
                AbstractObject absCiclo = lstAbsCiclo[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absCiclo.get_x()), 2) + Math.Pow((contour.y / scala_y - absCiclo.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res <= absCiclo.get_radio() / 2)
                        {
                            absCiclo.set_respuesta(1);
                            lstAbsCiclo[j] = absCiclo;
                        }
                    }

                }
            }

            //Semestre

            for (int j = 0; j < lstAbsSemestre.Count(); j++)
            {
                AbstractObject absSemestre = lstAbsSemestre[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absSemestre.get_x()), 2) + Math.Pow((contour.y / scala_y - absSemestre.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res <= absSemestre.get_radio() / 2)
                        {
                            absSemestre.set_respuesta(1);
                            lstAbsSemestre[j] = absSemestre;
                        }
                    }

                }
            }

            //turno

            for (int j = 0; j < lstAbsTurno.Count(); j++)
            {
                AbstractObject absTurno = lstAbsTurno[j];
                for (int i = 0; i < contoursPositions.Count(); i++)
                {
                    CountorsPositions contour = contoursPositions[i];

                    if (contour.area > LIMITE_AREA_RESPUESTA)
                    {
                        double dist = Math.Pow((contour.x / scala_x - absTurno.get_x()), 2) + Math.Pow((contour.y / scala_y - absTurno.get_y()), 2);
                        double res = Math.Sqrt(dist);
                        if (res <= absTurno.get_radio() / 2)
                        {
                            absTurno.set_respuesta(1);
                            lstAbsTurno[j] = absTurno;
                        }
                    }

                }
            }
        }

        public void FillingAnswerstToFinalQuestionsList()
        {

            //Questions
            Question question = new Question();
            string result ="";

            for (int i = 0; i < lstAbsQuestions.Count(); i++)
            {

                if (lstAbsQuestions[i].get_respuesta() == 0)
                { result = empty; }
                if (lstAbsQuestions[i].get_respuesta() == 1)
                { result = "V"; }
                if (lstAbsQuestions[i].get_respuesta() == 2)
                { result = "F";}

                question.fillQuestion(lstAbsQuestions[i].get_idQuestion(), result);
                questions.Add(question);

                
            }

            
            //DNI
            txtCode.Text = getDNI();


            //Opcion
             //opcion_01;
             //opcion_02;
            bool opcione_01 = true;
            for (int j = 0; j < 2; j++)
            {
                
                for (int i = 0; i < 5; i++)
                {
                    int pos = (i * 2) + (j * 1);
                    if (lstAbsOptions[pos].get_respuesta() == 1)
                    {
                        if (opcione_01)
                        { opcion_01 = lstAbsOptions[pos].get_idQuestion(); opcione_01 = false; }
                        else
                        {   
                            opcion_02 = lstAbsOptions[pos].get_idQuestion(); 
                        }
                    }
                    
                }
                
            }
            
            //Sede
           
            for (int i = 0; i < lstAbsSede.Count(); i++)
            {
                if (lstAbsSede[i].get_respuesta() == 1)
                    codigo_sede = lstAbsSede[i].get_idQuestion();
            }

            //Ciclo
            
            for (int j = 0; j < 2; j++)
            {
                int aux_count = 0;
                for (int i = 0; i < 10; i++)
                {
                    int pos = j + (i * 2);
                    if (lstAbsCiclo[pos].get_respuesta() == 1)
                    {
                        if (j == 0)
                        { num_01 = lstAbsCiclo[pos].get_idQuestion(); }
                        if (j == 1 )
                        { num_02 = lstAbsCiclo[pos].get_idQuestion(); }
                    }
                    else
                        aux_count++;
                }

            }

            //semestre
            
            for (int i = 0; i < lstAbsSemestre.Count(); i++)
            {
                if (lstAbsSemestre[i].get_respuesta() == 1)
                    codigo_semestre = lstAbsSemestre[i].get_idQuestion();
            }

            //turno
            

            for (int i = 0; i < lstAbsTurno.Count(); i++)
            {
                if (lstAbsTurno[i].get_respuesta() == 1)
                    codigo_turno = lstAbsTurno[i].get_idQuestion();
            }


        }

        public string getDNI()
        {
            //DNI
            StringBuilder dni = new StringBuilder();

            for (int j = 0; j < 8; j++)
            {
                int aux_count = 0;
                for (int i = 0; i < 10; i++)
                {
                    int pos = j + (i * 8);

                    if (lstAbsDNI[pos].get_respuesta() == 1)
                        dni.Append(lstAbsDNI[pos].get_idQuestion().ToString());
                    else
                        aux_count++;
                }
                if (aux_count == 10)
                    dni.Append("_");

            }

            return dni.ToString();
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            MouseEventArgs me = (MouseEventArgs)e;
            Point mc = me.Location;

            for (int k = 0; k < mayas_corner.Count; k++)
            {
                Circle lstCirculos = mayas_corner[k];
                for (int i = 0; i < lstCirculos.circles.Count; i++)
                {
                    double dist = Math.Pow((mc.X - lstCirculos.circles[i].getX()), 2) + Math.Pow((mc.Y - lstCirculos.circles[i].getY()), 2);
                    double res = Math.Sqrt(dist);

                    if (res <= lstCirculos.circles[i].getRadio() / 2)
                        lstCirculos.circles[i].setSelected(true);
                    else
                        lstCirculos.circles[i].setSelected(false);
                }
            }


            //mayas_corner[3].circles[0].set_X(mayas_corner[3].circles[0].getX());
            //mayas_corner[3].circles[0].set_Y(listSquares[8].center.Y);
            //mayas_corner[3].circles[1].set_X(listSquares[12].center.X);
            //mayas_corner[3].circles[1].set_Y(listSquares[12].center.Y);
            //mayas_corner[3].circles[2].set_X(listSquares[4].center.X);
            //mayas_corner[3].circles[2].set_Y(listSquares[4].center.Y);
            //mayas_corner[3].circles[3].set_X(listSquares[0].center.X);
            //mayas_corner[3].circles[3].set_Y(listSquares[0].center.Y);


            //PointF p1 = new PointF(lstAbsBigMaya[894].get_x1(), lstAbsBigMaya[894].get_y1());
            //PointF p2 = new PointF(lstAbsBigMaya[1223].get_x1(), lstAbsBigMaya[1223].get_y1());
            //PointF p3 = new PointF(lstAbsBigMaya[903].get_x1(), lstAbsBigMaya[903].get_y1());
            //PointF p4 = new PointF(lstAbsBigMaya[1232].get_x1(), lstAbsBigMaya[1232].get_y1());
            //set_drag_points_of_mayas_dni(p1, p2, p3, p4);

            //p1 = new PointF(lstAbsBigMaya[663].get_x1(), lstAbsBigMaya[663].get_y1());
            //p2 = new PointF(lstAbsBigMaya[710].get_x1(), lstAbsBigMaya[710].get_y1());
            //p3 = new PointF(lstAbsBigMaya[667].get_x1(), lstAbsBigMaya[667].get_y1());
            //p4 = new PointF(lstAbsBigMaya[714].get_x1(), lstAbsBigMaya[714].get_y1());
            //set_drag_points_of_mayas_options(p1, p2, p3, p4);

            //p1 = new PointF(lstAbsBigMaya[13].get_x1(), lstAbsBigMaya[13].get_y1());
            //p2 = new PointF(lstAbsBigMaya[1235].get_x1(), lstAbsBigMaya[1235].get_y1());
            //p3 = new PointF(lstAbsBigMaya[47].get_x1(), lstAbsBigMaya[47].get_y1());
            //p4 = new PointF(lstAbsBigMaya[1269].get_x1(), lstAbsBigMaya[1269].get_y1());
            //set_drag_points_of_mayas_answers(p1, p2, p3, p4);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            for (int k = 0; k < mayas_corner.Count; k++)
            {
                Circle lstCirculos = mayas_corner[k];

                for (int i = 0; i < lstCirculos.circles.Count; i++)
                {
                    if (lstCirculos.circles[i].getSelected())
                    {
                        MouseEventArgs me = (MouseEventArgs)e;
                        Point mc = me.Location;
                        lstCirculos.circles[i].set_X(mc.X);
                        lstCirculos.circles[i].set_Y(mc.Y);
                        //txtCode.Text = lstCirculos.circles[i].getX().ToString() + "   " + lstCirculos.circles[i].getY().ToString();
                    }
                }
            }

            //in this secction it must be set the main drag points of mayas_corner

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int k = 0; k < mayas_corner.Count; k++)
            {
                Circle lstCirculos = mayas_corner[k];

                for (int i = 0; i < lstCirculos.circles.Count; i++)
                {
                    if (lstCirculos.circles[i].getSelected())
                    {
                        lstCirculos.circles[i].setSelected(false);
                    }
                }
            }

        }

        public void drawDynamicLines(object sender, PaintEventArgs e)
        {

        }

        #endregion

       

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            if (this.dataGridView1.GetClipboardContent() != null)
                Clipboard.SetDataObject(
                this.dataGridView1.GetClipboardContent());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CursorChanged(object sender, EventArgs e)
        {
            String hola = "fdasfs";
        }

        private void txtTotalApplicants_TextChanged(object sender, EventArgs e)
        {

        }

        



    }
}
