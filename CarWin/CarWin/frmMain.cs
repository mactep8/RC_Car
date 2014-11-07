using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarWin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            cbPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (cbPort.Items.Count > 0) cbPort.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbPort.Enabled)
            {
                serialPort.Close();
                serialPort.PortName = cbPort.SelectedItem.ToString();
                serialPort.Open();
                cbPort.Enabled = !serialPort.IsOpen;
                SerialProtocol.SPort = serialPort;
                SerialProtocol.onChannels += new SerialProtocol.onCmdChannels(SerialProtocol_onChannels);
                SerialProtocol.onCalibrationView += new SerialProtocol.onCmdChannels(SerialProtocol_onCalibrationView);

                btnLoad_Click(null, null);
            }
            else
            {
                serialPort.Close();
                cbPort.Enabled = !serialPort.IsOpen;
            }
        }

        void SerialProtocol_onCalibrationView()
        {
            if (ch1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SerialProtocol_onCalibrationView);
                this.Invoke(d, new object[] { });
            }
            else
            {
                ch1Min.Text = SerialProtocol.aChannel1.MinVal.ToString();
                ch1Center.Text = SerialProtocol.aChannel1.Center.ToString();
                ch1Max.Text = SerialProtocol.aChannel1.MaxVal.ToString();

                ch2Min.Text = SerialProtocol.aChannel2.MinVal.ToString();
                ch2Center.Text = SerialProtocol.aChannel2.Center.ToString();
                ch2Max.Text = SerialProtocol.aChannel2.MaxVal.ToString();
            }
        }

        delegate void SetTextCallback();

        void SerialProtocol_onChannels()
        {
            if (ch1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SerialProtocol_onChannels);
                this.Invoke(d, new object[] { });
            }
            else
            {
                ch1.Text = SerialProtocol.aChannel1.chValue.ToString();
                ch2.Text = SerialProtocol.aChannel2.chValue.ToString();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SerialProtocol.LoadCalibrationRequest();
        }

    }
}
