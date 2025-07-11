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
            label1.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            string[] portList = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(portList);

            // Configuración inicial del gráfico
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 150;
            chart1.ChartAreas[0].AxisY.Minimum = -0.16;
            chart1.ChartAreas[0].AxisY.Maximum = 0.16;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.WhiteSmoke;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.WhiteSmoke;
            chart1.Series["C(s)"].LegendText = $"u [-]";
            chart1.Series["G(s)"].LegendText = $"y [-]";
        }

        private void BorrarDibujos(Graphics g)
        {
            g.Clear(lienzo.BackColor); // Se limpia el fondo
        }

        public void ConfigurarGrafica(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            // Primero limpia el lienzo antes de actualizar la configuración
            lienzo.Paint -= (sender, e) => animation.DibujarComponentes(e.Graphics);
            lienzo.Paint += (sender, e) => BorrarDibujos(e.Graphics); // Redibuja un fondo vacío

            if (cbx_system.Text == "Ball & Beam")
            {
                lienzo.Paint += (sender, e) => animation.DibujarComponentes(e.Graphics);
                chart.ChartAreas[0].AxisY.Minimum = -0.16;
                chart.ChartAreas[0].AxisY.Maximum = 0.16;
                lbl_ctrl.Text = "u: BEAM ANGLE";
                lbl_out.Text = "y: BALL POSITION";
                gaugeVelocity.Visible = false;
                gaugeAngle.Visible = false;
                eliminar.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
            else if (cbx_system.Text == "Gear Motor")
            {
                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 180;
                lbl_ctrl.Text = "u: VOLTAGE";
                lbl_out.Text = "y: ROTOR POSITION";
                gaugeVelocity.Visible = false;
                gaugeAngle.Visible = true;
                eliminar.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
            else if (cbx_system.Text == "Motor")
            {
                chart.ChartAreas[0].AxisY.Minimum = -5000;
                chart.ChartAreas[0].AxisY.Maximum = 5000;
                lbl_ctrl.Text = "u: VOLTAGE";
                lbl_out.Text = "y: VELOCITY";
                gaugeVelocity.Visible = true;
                gaugeAngle.Visible = false;
                eliminar.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
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
                        chart1.ChartAreas[0].AxisX.Title = "Time [s]";
                        chart1.ChartAreas[0].AxisY.Title = "Ball Position [m]";

                        double NSP = Math.Round((valueSP / 4900.0) * 46 * Math.PI / 180.0, 6);
                        if (NSP > 0.802851) NSP = 0.802851;
                        if (NSP < -0.802851) NSP = -0.802851;

                        lbl_Angle.Text = NSP.ToString();
                        label_u1.Text = "rad";

                        chart1.Series["C(s)"].Points.AddY(NSP);
                        //chart1.Series["C(s)"].LegendText = $"Y: {NSP:F3} rad";
                        chart1.Series["C(s)"].LegendText = $"u [rad]";

                    }
                    else if (cbx_system.Text == "Gear Motor")
                    {
                        chart1.ChartAreas[0].AxisX.Title = "Time [s]";
                        chart1.ChartAreas[0].AxisY.Title = "Rotor Position [°]";

                        lbl_Angle.Text = (valueSP).ToString();
                        label_u1.Text = "mV";

                        chart1.Series["C(s)"].Points.AddY(valueSP);

                        //chart1.Series["C(s)"].LegendText = $"Y: {valueSP:F3} mV";
                        chart1.Series["C(s)"].LegendText = $"u [mV]";


                    }
                    else if (cbx_system.Text == "Motor")
                    {
                        chart1.ChartAreas[0].AxisX.Title = "Time [s]";
                        chart1.ChartAreas[0].AxisY.Title = "Velocity [RPM]";

                        double valueSPN = valueSP * (5000.0 / 2047.5);
                        chart1.Series["C(s)"].Points.AddY(valueSPN);

                        lbl_Angle.Text = Math.Round(valueSPN, 2).ToString();
                        label_u1.Text = "mV";

                        //chart1.Series["C(s)"].LegendText = $"y: {valueSPN:F3} mV";
                        chart1.Series["C(s)"].LegendText = $"u [mV]";
                    }
                }
                if (gsUpdated)
                {
                    if (cbx_system.Text == "Ball & Beam")
                    {
                        double NGS = Math.Round(((valueGS - 2047.5) / 2047.5) * 0.15, 6);

                        lbl_ellipsePosX.Text = NGS.ToString();
                        label_u2.Text = "m";

                        chart1.Series["G(s)"].Points.AddY(NGS);
                        //chart1.Series["G(s)"].LegendText = $"u: {NGS:F3} m";
                        chart1.Series["G(s)"].LegendText = $"y [m]";
                    }
                    else if (cbx_system.Text == "Gear Motor")
                    {
                        double valueGSn = (valueGS / 4095.0) * 200.0;

                        lbl_ellipsePosX.Text = Math.Round(valueGSn,2).ToString();
                        label_u2.Text = "°";

                        chart1.Series["G(s)"].Points.AddY(valueGSn);
                        //chart1.Series["G(s)"].LegendText = $"C(s): {valueGSn:F3} °";
                        chart1.Series["G(s)"].LegendText = $"y [°]";

                        gaugeAngle.Value = (float)valueGSn;
                    }
                    else if (cbx_system.Text == "Motor")
                    {
                        double valueGSN = valueGS * (5000.0 / 2047.5);
                        chart1.Series["G(s)"].Points.AddY(valueGSN);
                        
                        //chart1.Series["G(s)"].LegendText = $"C(s): {valueGSN:F3} RPM";
                        chart1.Series["G(s)"].LegendText = $"y [RPM]";
                        
                        gaugeVelocity.Value = (float)Math.Abs(valueGSN);

                        lbl_ellipsePosX.Text = Math.Round(valueGSN, 2).ToString();
                        label_u2.Text = "RPM";

                        if (valueGSN > 0) label2.Text = "COUNTER CLOCKWISE";
                        if (valueGSN == 0) label2.Text = "-";
                        if (valueGSN < 0) label2.Text = "CLOCKWISE";
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

                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;

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