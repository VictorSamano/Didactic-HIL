using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection.Emit;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prueba
{
    public partial class Form1 : Form
    {
        private StringBuilder dataBuffer = new StringBuilder();
        private Animation animation = new Animation();

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
            chart1.ChartAreas[0].AxisY.Minimum = -0.16;//
            chart1.ChartAreas[0].AxisY.Maximum = 0.16;//
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.WhiteSmoke;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.WhiteSmoke;
        }

        private void BorrarDibujos(Graphics g)
        {
            g.Clear(lienzo.BackColor); // Se limpia el fondo
        }

        public void ConfigurarGrafica(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            // Primero, limpia el lienzo antes de actualizar la configuración
            lienzo.Paint -= (sender, e) => animation.DibujarComponentes(e.Graphics);
            lienzo.Paint += (sender, e) => BorrarDibujos(e.Graphics); // Redibuja un fondo vacío

            if (cbx_system.Text == "Ball & Beam")
            {
                lienzo.Paint += (sender, e) => animation.DibujarComponentes(e.Graphics);
                chart.ChartAreas[0].AxisY.Minimum = -0.16;
                chart.ChartAreas[0].AxisY.Maximum = 0.16;
                lbl_ctrl.Text = "BEAM ANGLE [rad]";
                lbl_out.Text = "BALL POSITION [M]";
                gaugeVelocity.Visible = false;
                gaugeAngle.Visible = false;
                eliminar.Visible = false;

            }
            else if (cbx_system.Text == "Gear Motor")
            {
                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 180;
                lbl_ctrl.Text = "VOLTAGE [mV]";
                lbl_out.Text = "ANGULAR POSITION [°]";
                gaugeVelocity.Visible = false;
                gaugeAngle.Visible = true;
                eliminar.Visible = false;
            }
            else if (cbx_system.Text == "Motor")
            {
                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 5000;
                lbl_ctrl.Text = "VOLTAGE [mV]";
                lbl_out.Text = "VELOCITY [RPM]";
                gaugeVelocity.Visible = true;
                gaugeAngle.Visible = false;
                eliminar.Visible = false;
            }
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
                            spUpdated = true;

                        else if (segment.StartsWith("G(s):") && double.TryParse(segment.Substring(5), out valueGS))
                            gsUpdated = true;
                    }

                    if (spUpdated && gsUpdated)
                    {
                        ProcessData(spUpdated, valueSP, gsUpdated, valueGS);
                        Invoke((MethodInvoker)delegate
                        {
                            if (spUpdated) animation.UpdateLinePositions(valueSP);
                            if (gsUpdated) animation.UpdateEllipsePosition(valueGS);
                            lienzo.Invalidate();
                        });

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
                    if (cbx_system.Text == "Ball & Beam")
                    {
                        lbl_Angle.Text = Math.Round((valueSP / 490.0) * -90, 6).ToString();
                        chart1.Series["C(s)"].Points.AddY((valueSP / 4900.0) * (-90.0 * Math.PI / 180.0));
                    }
                    else if (cbx_system.Text == "Gear Motor")
                    {
                        lbl_Angle.Text = (valueSP).ToString();
                        chart1.Series["C(s)"].Points.AddY(valueSP);
                    }
                    else if (cbx_system.Text == "Motor")
                    {
                        double valueSPN = valueSP * (5000.0 / 4095.0);
                        chart1.Series["C(s)"].Points.AddY(valueSPN);
                        lbl_Angle.Text = Math.Round(valueSPN, 2).ToString();
                    }
                }
                if (gsUpdated)
                {
                    if (cbx_system.Text == "Ball & Beam")
                    { 
                        lbl_ellipsePosX.Text = Math.Round(((valueGS - 2047.5) / 2047.5) * 0.15, 6).ToString();
                        chart1.Series["G(s)"].Points.AddY(((valueGS - 2047.5) / 2047.5) * 0.15);
                    }
                    else if (cbx_system.Text == "Gear Motor")
                    {
                        double valueGSn = (valueGS / 4095.0) * 200.0;
                        lbl_ellipsePosX.Text = Math.Round(valueGSn,2).ToString();
                        chart1.Series["G(s)"].Points.AddY(valueGSn);
                        gaugeAngle.Value = (float)valueGSn;
                    }
                    else if (cbx_system.Text == "Motor")
                    {
                        double valueGSN = valueGS * (5000.0 / 4095.0);
                        chart1.Series["G(s)"].Points.AddY(valueGSN);
                        gaugeVelocity.Value = (float)valueGSN;
                        lbl_ellipsePosX.Text = Math.Round(valueGSN, 2).ToString();
                    }
                }

                LimitChartPoints();
                lienzo.Invalidate();
            });
        }

        private void LimitChartPoints()
        {
            const int maxPoints = 150;

            while (chart1.Series["C(s)"].Points.Count > maxPoints)
                chart1.Series["C(s)"].Points.RemoveAt(0);

            while (chart1.Series["G(s)"].Points.Count > maxPoints)
                chart1.Series["G(s)"].Points.RemoveAt(0);
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

            double intervaloTiempo = 0.017;
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
                    cbx_system.Enabled = true;
                }
                else if (!serialPort1.IsOpen && !string.IsNullOrEmpty(cbx_system.Text))
                {
                    serialPort1.PortName = comboBoxPort.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.ReadTimeout = 1000;
                    serialPort1.DtrEnable = true;
                    serialPort1.RtsEnable = true;
                    serialPort1.Open();

                    buttonPort.Text = "STOP";
                    comboBoxPort.Enabled = false;
                    cbx_system.Enabled = false;

                    ConfigurarGrafica(chart1);

                    serialPort1.DataReceived += DataReceivedHandler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de Puerto Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrafica()
        {
            throw new NotImplementedException();
        }

        private void buttonPort_Click(object sender, EventArgs e) => ToggleSerialPort();

        private void BtnBuscarPuertos_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;

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
