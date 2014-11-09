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
            tabControl1.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbPort.Enabled)
            {
                serialPort.Close();
                serialPort.PortName = cbPort.SelectedItem.ToString();
                serialPort.Open();
                cbPort.Enabled = !serialPort.IsOpen;
                tabControl1.Enabled = serialPort.IsOpen;
                SerialProtocol.SPort = serialPort;
                SerialProtocol.onChannels += new SerialProtocol.onCmdChannels(SerialProtocol_onChannels);
                SerialProtocol.onCalibrationView += new SerialProtocol.onCmdChannels(SerialProtocol_onCalibrationView);
                SerialProtocol.onModelListView += new SerialProtocol.onCmdChannels(SerialProtocol_onModelListView);
                SerialProtocol.onModelInfoView += new SerialProtocol.onCmdChannels(SerialProtocol_onModelInfoView);
                //btnLoad_Click(null, null);
            }
            else
            {
                serialPort.Close();
                cbPort.Enabled = !serialPort.IsOpen;
            }
        }

        void SerialProtocol_onModelInfoView()
        {
            if (ch1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SerialProtocol_onModelInfoView);
                this.Invoke(d, new object[] { });
            }
            else
            {
                mdlName.Text = SerialProtocol.Model.ModelName;
                addr0.Value = SerialProtocol.Model.Addr[0];
                addr1.Value = SerialProtocol.Model.Addr[1];
                addr2.Value = SerialProtocol.Model.Addr[2];
                addr3.Value = SerialProtocol.Model.Addr[3];
                MatchByte.Value = SerialProtocol.Model.MatchByte;
                btnPrev.Checked = Convert.ToBoolean(SerialProtocol.Model.dFix & 1);
                btnNext.Checked = Convert.ToBoolean((SerialProtocol.Model.dFix >> 1) & 1);
                btnCancel.Checked = Convert.ToBoolean((SerialProtocol.Model.dFix >> 2) & 1);
                btnCh4.Checked = Convert.ToBoolean((SerialProtocol.Model.dFix >> 3) & 1);
                ch1_reverse.Checked = Convert.ToBoolean(SerialProtocol.Model.Channel[0].Revers);
                ch1_expleft.Value = SerialProtocol.Model.Channel[0].ExpLeft;
                ch1_expright.Value = SerialProtocol.Model.Channel[0].ExpRight;
                ch1_trimm.Value = SerialProtocol.Model.Channel[0].Trimm;

                ch2_reverse.Checked = Convert.ToBoolean(SerialProtocol.Model.Channel[1].Revers);
                ch2_expleft.Value = SerialProtocol.Model.Channel[1].ExpLeft;
                ch2_expright.Value = SerialProtocol.Model.Channel[1].ExpRight;
                ch2_trimm.Value = SerialProtocol.Model.Channel[1].Trimm;
            }
        }

        void SerialProtocol_onModelListView()
        {
            if (ch1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SerialProtocol_onModelListView);
                this.Invoke(d, new object[] { });
            }
            else
            {
                cbCurrentItem.Items.Clear();
                foreach (KeyValuePair<int, string> p in SerialProtocol.Models)
                {
                    cbCurrentItem.Items.Add(p.Value);
                }

                if (cbCurrentItem.Items.Count > 0) cbCurrentItem.SelectedIndex = 0;
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
            cbCurrentItem.Items.Clear();
            SerialProtocol.LoadCalibrationRequest();
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            SerialProtocol.DoCalibration();
        }

        private void cbCurrentItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialProtocol.LoadModelRequest(cbCurrentItem.SelectedIndex);
        }

        private void btnLoadCurr_Click(object sender, EventArgs e)
        {
            SerialProtocol.LoadModelListRequest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SerialProtocol.SaveCalibration();
        }

        private void btnSaveCurr_Click(object sender, EventArgs e)
        {
            SerialProtocol.LoadModelRequest(cbCurrentItem.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialProtocol.SaveModelInfo(cbCurrentItem.SelectedIndex);
        }

        private void mdlName_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.ModelName = mdlName.Text;
        }

        private void addr0_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Addr[0] = (byte)addr0.Value;
        }

        private void addr1_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Addr[1] = (byte)addr1.Value;
        }

        private void addr2_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Addr[2] = (byte)addr2.Value;
        }

        private void addr3_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Addr[3] = (byte)addr3.Value;
        }

        private void MatchByte_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.MatchByte = (byte)MatchByte.Value;
        }

        private void ch1_reverse_CheckedChanged(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[0].Revers = Convert.ToByte(ch1_reverse.Checked);
        }

        private void ch2_reverse_CheckedChanged(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[1].Revers = Convert.ToByte(ch2_reverse.Checked);
        }

        private void ch1_expleft_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[0].ExpLeft = (int)ch1_expleft.Value;
        }

        private void ch1_expright_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[0].ExpRight = (int)ch1_expright.Value;
        }

        private void ch1_trimm_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[0].Trimm = (byte)ch1_trimm.Value;
        }

        private void ch2_expleft_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[1].ExpLeft = (int)ch2_expleft.Value;
        }

        private void ch2_expright_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[1].ExpRight = (int)ch2_expright.Value;
        }

        private void ch2_trimm_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.Channel[1].Trimm = (byte)ch2_trimm.Value;
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                SerialProtocol.LoadModelFromFile(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = SerialProtocol.Model.ModelName;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fn = saveFileDialog1.FileName;
                if (fn.Substring(fn.Length - 4).ToLower() != ".mdl")
                    fn = fn + ".mdl";
                SerialProtocol.SaveModelToFile(fn);
            }
        }

        private void btnPrev_Leave(object sender, EventArgs e)
        {
            SerialProtocol.Model.dFix = (byte)(Convert.ToByte(btnPrev.Checked) | (Convert.ToByte(btnNext.Checked) << 1) | (Convert.ToByte(btnCancel.Checked) << 2) | (Convert.ToByte(btnCh4.Checked) << 3));
        }

    }
}
