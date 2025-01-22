using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.IO;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prueba
{
    public partial class Form1 : Form
    {
        private StringBuilder dataBuffer = new StringBuilder();
        private int ellipsePosX = 0;
        private int ellipsePosY = 0;
        private int lineStartXM1 = 200, lineEndXM1 = 450, lineStartYM1 = 190, lineEndYM1 = 190, lineStartX = 450, lineStartY = 190, lineEndX = 700, lineEndY = 190, lineEndX2 = 200, lineEndY2 = 170, lineEndX3 = 700, lineEndY3 = 170;
        private int lineLength = 250;
        private int lineLength2 = 25;
        private int Lx = 0, Ly = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnBuscarPuertos.Enabled = true;
            buttonPort.Enabled = true;
            comboBoxPort.Enabled = true;
            string[] portList = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(portList);

            // Configuración inicial del gráfico
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 150;
            chart1.ChartAreas[0].AxisY.Minimum = -0.16;
            chart1.ChartAreas[0].AxisY.Maximum = 0.16;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.WhiteSmoke;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.WhiteSmoke;

            lienzo.Paint += new PaintEventHandler(DibujarElipse);
        }

        private void DibujarComponentes(Graphics papel)
        {
            using (Pen lapiz1 = new Pen(Color.WhiteSmoke))
            {
                papel.DrawEllipse(lapiz1, ellipsePosX - 2, ellipsePosY - 26, 25, 25);

                // Líneas grandes
                papel.DrawLine(lapiz1, lineStartX, lineStartY, lineEndX, lineEndY);
                papel.DrawLine(lapiz1, lineStartXM1, lineStartYM1, lineEndXM1, lineEndYM1);

                // Líneas pequeñas
                papel.DrawLine(lapiz1, lineStartXM1, lineStartYM1, lineEndX2, lineEndY2);
                papel.DrawLine(lapiz1, lineEndX, lineEndY, lineEndX3, lineEndY3);

                // Pivote
                papel.DrawLine(lapiz1, 450, 190, 430, 250);
                papel.DrawLine(lapiz1, 450, 190, 470, 250);
                papel.DrawLine(lapiz1, 430, 250, 470, 250);
            }
        }

        private void DibujarElipse(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DibujarComponentes(e.Graphics);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string incomingData = serialPort1.ReadExisting();
                dataBuffer.Append(incomingData);

                if (dataBuffer.ToString().Contains(";"))
                {
                    string[] dataSegments = dataBuffer.ToString().Split(';');
                    dataBuffer.Clear();  // Limpia el buffer después de procesar

                    double valueSP = 0.0, valueGS = 0.0;
                    bool spUpdated = false, gsUpdated = false;

                    foreach (string segment in dataSegments)
                    {
                        if (segment.StartsWith("SP:") && double.TryParse(segment.Substring(3), out valueSP))
                        {
                            spUpdated = true;
                        }
                        else if (segment.StartsWith("G(s):") && double.TryParse(segment.Substring(5), out valueGS))
                        {
                            gsUpdated = true;
                        }
                    }

                    if (spUpdated && gsUpdated)
                    {
                        ProcessData(spUpdated, valueSP, gsUpdated, valueGS);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer datos: {ex.Message}");
            }
        }

        private void ProcessData(bool spUpdated, double valueSP, bool gsUpdated, double valueGS)
        {
            Invoke((MethodInvoker)delegate
            {
                if (spUpdated)
                {
                    UpdateLinePositions(valueSP);
                    lbl_Angle.Text = Math.Round((valueSP / 490.0) * -90, 6).ToString();
                    chart1.Series["C(s)"].Points.AddY((valueSP / 4900.0) * (-90.0 * Math.PI / 180.0));
                }

                if (gsUpdated)
                {
                    UpdateEllipsePosition(valueGS);
                    lbl_ellipsePosX.Text = Math.Round(((valueGS - 2047.5) / 2047.5) * 0.15, 6).ToString();
                    chart1.Series["G(s)"].Points.AddY(((valueGS - 2047.5) / 2047.5) * 0.15);
                }

                LimitChartPoints();
                lienzo.Invalidate();
            });
        }

        private void UpdateLinePositions(double valueSP)
        {
            double rad = (valueSP / 490.0) * (-90.0 * Math.PI / 180.0);
            if (rad > 0.524) rad = 0.524;
            if (rad < -0.524) rad = -0.524;
            lineEndX = lineStartX + (int)(lineLength * Math.Cos(rad));
            lineEndY = lineStartY - (int)(lineLength * Math.Sin(rad));

            lineStartXM1 = lineEndXM1 - (int)(lineLength * Math.Cos(rad));
            lineStartYM1 = lineEndYM1 + (int)(lineLength * Math.Sin(rad));

            lineEndX2 = lineStartXM1 + (int)(lineLength2 * Math.Sin(-rad));
            lineEndY2 = lineStartYM1 - (int)(lineLength2 * Math.Cos(-rad));

            lineEndX3 = lineEndX + (int)(lineLength2 * Math.Sin(-rad));
            lineEndY3 = lineEndY - (int)(lineLength2 * Math.Cos(-rad));

            Lx = lineStartXM1 + (int)(478 * Math.Cos(rad));
            Ly = lineStartYM1 - (int)(478 * Math.Sin(rad));
        }

        private void UpdateEllipsePosition(double valueGS)
        {
            ellipsePosX = lineStartXM1 + (int)((valueGS / 4095.0) * (Lx - lineStartXM1));
            ellipsePosY = lineStartYM1 + (int)((valueGS / 4095.0) * (Ly - lineStartYM1));
        }

        private void LimitChartPoints()
        {
            const int maxPoints = 150;

            while (chart1.Series["C(s)"].Points.Count > maxPoints)
            {
                chart1.Series["C(s)"].Points.RemoveAt(0);
            }

            while (chart1.Series["G(s)"].Points.Count > maxPoints)
            {
                chart1.Series["G(s)"].Points.RemoveAt(0);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", Title = "Guardar datos del gráfico como CSV" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportChartDataToCSV(saveFileDialog.FileName);
                        MessageBox.Show("Datos exportados correctamente.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportChartDataToCSV(string fileName)
        {
            StringBuilder csvContent = new StringBuilder("Tiempo,G(s),C(s)\n");

            double intervaloTiempo = 0.032;
            var seriesG = chart1.Series["G(s)"];
            var seriesC = chart1.Series["C(s)"];

            int pointCount = Math.Max(seriesG.Points.Count, seriesC.Points.Count);
            for (int i = 0; i < pointCount; i++)
            {
                double time = i * intervaloTiempo;
                double gValue = i < seriesG.Points.Count ? seriesG.Points[i].YValues[0] : 0;
                double cValue = i < seriesC.Points.Count ? seriesC.Points[i].YValues[0] : 0;

                csvContent.AppendLine($"{time},{gValue},{cValue}");
            }

            File.WriteAllText(fileName, csvContent.ToString());
        }

        private void ToggleSerialPort()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    buttonPort.Text = "START";
                    comboBoxPort.Enabled = true;
                }
                else
                {
                    serialPort1.PortName = comboBoxPort.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.ReadTimeout = 1000;
                    serialPort1.DtrEnable = true;
                    serialPort1.RtsEnable = true;
                    serialPort1.Open();

                    buttonPort.Text = "STOP";
                    comboBoxPort.Enabled = false;

                    serialPort1.DataReceived += DataReceivedHandler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de Puerto Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPort_Click(object sender, EventArgs e) => ToggleSerialPort();

        private void BtnBuscarPuertos_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            if (comboBoxPort.Items.Count > 0)
            {
                comboBoxPort.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("NINGÚN PUERTO DETECTADO");
                comboBoxPort.Text = string.Empty;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                MessageBox.Show("Favor de cerrar el puerto serial", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }


    }
}
