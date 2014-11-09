using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace CarWin
{
    public static class SerialProtocol
    {
        private static Dictionary<int, string> _Models = new Dictionary<int, string>();
        public static Dictionary<int, string> Models
        {
            get
            {
                return _Models;
            }
        }
        private static bool InCalibration = false;
        private static byte[] Buffer = new byte[255];
        private static byte cmd;
        private static byte cmd_pos = 0;
        private static SerialPort _SPort;
        public static SerialPort SPort
        {
            get { return _SPort; }
            set
            {
                _SPort = value;
                _SPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
        }
        private static tModel model = new tModel();
        public static tModel Model
        {
            get
            {
                return model;
            }
        }

        public static tChannel aChannel1 = new tChannel();
        public static tChannel aChannel2 = new tChannel();
        public delegate void onCmdChannels();

        public static event onCmdChannels onChannels;
        public static event onCmdChannels onCalibrationView;
        public static event onCmdChannels onModelListView;
        public static event onCmdChannels onModelInfoView;

        private static void SendCommand(byte cmd, byte[] props)
        {
            int lng = 3;
            if (props != null) lng = props.Length * 2 + 2;
            byte[] bb = new byte[lng];
            bb[0] = 0x5e;
            bb[1] = cmd;
            lng = 2;
            if (props!=null)
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i] == 0x5e)
                {
                    bb[lng++] = 0x5d;
                    bb[lng++] = 0x3e;
                }
                else if (props[i] == 0x5d)
                {
                    bb[lng++] = 0x5d;
                    bb[lng++] = 0x3d;
                }
                else
                {
                    bb[lng++] = props[i];
                }
            }

            bb[lng++] = 0x5e;
            _SPort.Write(bb, 0, lng);
        }

        private static void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int count = _SPort.BytesToRead;
            byte[] data = new byte[count];
            _SPort.Read(data, 0, count);
            ParseData(data, count);
        }
        private static bool do_xor = false;
        private static void ParseData(byte[] buff, int buff_size)
        {
            for (int i = 0; i < buff_size; i++)
            {
                if (buff[i] == 0x5e)
                {
                    if (cmd > 0 && cmd_pos > 0)
                    {
                        switch (cmd)
                        {
                            case 0x01: ParseChannels(); break;
                            case 0x02: ParseCalibration(); break;
                            case 0x03: ParseModelInfo(); break;
                            case 0x04: ParseModelList(); break;
                        }
                    }
                    cmd_pos = 0;
                    cmd = 0;
                    do_xor = false;
                }
                else
                    if (cmd_pos == 0)
                    {
                        cmd = buff[i];
                        cmd_pos++;
                    }
                    else
                    {
                        if (buff[i] == 0x5d) do_xor = true;
                        else
                        {
                            if (do_xor) 
                                Buffer[cmd_pos - 1] = (byte)(buff[i] ^ 0x60);
                            else
                                Buffer[cmd_pos - 1] = buff[i];
                            cmd_pos++;
                            do_xor = false;
                        }
                    }
            }
        }

        private static void ParseModelList()
        {
            _Models.Clear();
            for (int i = 0; i < 8; i++)
            {
                string str = "";
                for (int j = 0; j < 11; j++)
                {
                    if (Buffer[i * 12 + j] > 127 || Buffer[i * 12 + j] < 32) ;
                    else str = str + ((char)Buffer[i * 12 + j]);
                }
                _Models.Add(_Models.Count, str);
            }
            cmd_pos = 0;
            cmd = 0;
            onModelListView();
        }

        private static void ParseModelInfo()
        {
            string str = "";
            for (int i=0;i<12;i++)
                if (Buffer[i] > 127 || Buffer[i] < 32) ;
                    else str = str + ((char)Buffer[i]);
            model.ModelName = str;
            for (int i = 12; i < 16; i++)
                model.Addr[i - 12] = Buffer[i];
            model.MatchByte = Buffer[29];
            model.dFix = Buffer[16];
            if (model.Channel[0] == null) model.Channel[0] = new tChannel();
            model.Channel[0].ExpLeft = (Buffer[17] << 8) | (Buffer[18] & 0xff);
            model.Channel[0].ExpRight = (Buffer[19] << 8) | (Buffer[20] & 0xff);
            model.Channel[0].Trimm = Buffer[21];
            model.Channel[0].Revers = Buffer[22];

            if (model.Channel[1] == null) model.Channel[1] = new tChannel();
            model.Channel[1].ExpLeft = (Buffer[23] << 8) | (Buffer[24] & 0xff);
            model.Channel[1].ExpRight = (Buffer[25] << 8) | (Buffer[26] & 0xff);
            model.Channel[1].Trimm = Buffer[27];
            model.Channel[1].Revers = Buffer[28];
            cmd_pos = 0;
            cmd = 0;
            onModelInfoView();
        }

        private static void ParseCalibration()
        {
            aChannel1.MinVal = (Buffer[0] << 8) | Buffer[1];
            aChannel1.Center = (Buffer[2] << 8) | Buffer[3];
            aChannel1.MaxVal = (Buffer[4] << 8) | Buffer[5];

            aChannel2.MinVal = (Buffer[6] << 8) | Buffer[7];
            aChannel2.Center = (Buffer[8] << 8) | Buffer[9];
            aChannel2.MaxVal = (Buffer[10] << 8) | Buffer[11];
            
            cmd_pos = 0;
            cmd = 0;
            onCalibrationView();
        }

        private static void ParseChannels()
        {
            aChannel1.chValue = (Buffer[0] << 8) | Buffer[1];
            aChannel2.chValue = (Buffer[2] << 8) | Buffer[3];
            if (InCalibration)
            {
                if (aChannel1.chValue > aChannel1.MaxVal) aChannel1.MaxVal = aChannel1.chValue;
                if (aChannel1.chValue < aChannel1.MinVal) aChannel1.MinVal = aChannel1.chValue;

                if (aChannel2.chValue > aChannel2.MaxVal) aChannel2.MaxVal = aChannel2.chValue;
                if (aChannel2.chValue < aChannel2.MinVal) aChannel2.MinVal = aChannel2.chValue;
                onCalibrationView();
            }

            cmd_pos = 0;
            cmd = 0;
            onChannels();
        }

        public static void LoadCalibrationRequest()
        {
            SendCommand(0x02, null);
        }

        public static void LoadModelRequest(int index)
        {
            byte[] bb = new byte[1];
            bb[0] = (byte)index;
            SendCommand(0x03, bb);
        }

        public static void LoadModelListRequest()
        {
            SendCommand(0x04, null);
        }

        public static void DoCalibration()
        {
            if (!InCalibration)
            {
                aChannel1.MinVal = aChannel1.chValue;
                aChannel1.Center = aChannel1.chValue;
                aChannel1.MaxVal = aChannel1.chValue;

                aChannel2.MinVal = aChannel2.chValue;
                aChannel2.Center = aChannel2.chValue;
                aChannel2.MaxVal = aChannel2.chValue;
            }
            InCalibration = !InCalibration;

        }

        public static void SaveCalibration()
        {
            InCalibration = false;
            byte[] bb = new byte[12];
            bb[0] = (byte)(aChannel1.MinVal >> 8);
            bb[1] = (byte)(aChannel1.MinVal & 0xff);
            bb[2] = (byte)(aChannel1.Center >> 8);
            bb[3] = (byte)(aChannel1.Center & 0xff);
            bb[4] = (byte)(aChannel1.MaxVal >> 8);
            bb[5] = (byte)(aChannel1.MaxVal & 0xff);

            bb[6] = (byte)(aChannel2.MinVal >> 8);
            bb[7] = (byte)(aChannel2.MinVal & 0xff);
            bb[8] = (byte)(aChannel2.Center >> 8);
            bb[9] = (byte)(aChannel2.Center & 0xff);
            bb[10] = (byte)(aChannel2.MaxVal >> 8);
            bb[11] = (byte)(aChannel2.MaxVal & 0xff);

            SendCommand(0x05, bb);
        }

        public static void SaveModelInfo(int indx)
        {
            byte[] bb = new byte[31];
            bb[0] = (byte)indx;
            char[] nn = Model.ModelName.ToCharArray();
            for (int i = 0; i < 12; i++)
                if (nn.Length > i)
                    bb[i+1] = Convert.ToByte(nn[i]);
                else bb[i+1] = Convert.ToByte(' ');
            for (int i = 0; i < 4; i++)
                bb[i + 13] = model.Addr[i];
            bb[17] = model.dFix;
            bb[18] = (byte)(model.Channel[0].ExpLeft >> 8);
            bb[19] = (byte)(model.Channel[0].ExpLeft & 0xff);
            bb[20] = (byte)(model.Channel[0].ExpRight >> 8);
            bb[21] = (byte)(model.Channel[0].ExpRight & 0xff);
            bb[22] = model.Channel[0].Trimm;
            bb[23] = model.Channel[0].Revers;

            bb[24] = (byte)(model.Channel[1].ExpLeft >> 8);
            bb[25] = (byte)(model.Channel[1].ExpLeft & 0xff);
            bb[26] = (byte)(model.Channel[1].ExpRight >> 8);
            bb[27] = (byte)(model.Channel[1].ExpRight & 0xff);
            bb[28] = model.Channel[1].Trimm;
            bb[29] = model.Channel[1].Revers;

            bb[30] = model.MatchByte;

            SendCommand(0x06, bb);
        }

        public static void SaveModelToFile(string Filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(Filename, System.IO.FileMode.Create);

            byte[] bb = new byte[30];
            char[] nn = Model.ModelName.ToCharArray();
            for (int i = 0; i < 12; i++)
                if (nn.Length > i)
                    bb[i] = Convert.ToByte(nn[i]);
                else bb[i] = Convert.ToByte(' ');
            for (int i = 0; i < 4; i++)
                bb[i + 12] = model.Addr[i];
            bb[16] = model.dFix;
            bb[17] = (byte)(model.Channel[0].ExpLeft >> 8);
            bb[18] = (byte)(model.Channel[0].ExpLeft & 0xff);
            bb[19] = (byte)(model.Channel[0].ExpRight >> 8);
            bb[20] = (byte)(model.Channel[0].ExpRight & 0xff);
            bb[21] = model.Channel[0].Trimm;
            bb[22] = model.Channel[0].Revers;

            bb[23] = (byte)(model.Channel[0].ExpLeft >> 8);
            bb[24] = (byte)(model.Channel[0].ExpLeft & 0xff);
            bb[25] = (byte)(model.Channel[0].ExpRight >> 8);
            bb[26] = (byte)(model.Channel[0].ExpRight & 0xff);
            bb[27] = model.Channel[0].Trimm;
            bb[28] = model.Channel[0].Revers;

            bb[29] = model.MatchByte;

            fs.Write(bb, 0, 30);
            fs.Close();
        }

        public static void LoadModelFromFile(string Filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(Filename, System.IO.FileMode.Open);

            byte[] bb = new byte[30];
            fs.Read(bb, 0, 30);

            string str = "";
            for (int i = 0; i < 12; i++)
                if (bb[i] > 127 || bb[i] < 32) ;
                else str = str + ((char)bb[i]);
            model.ModelName = str;
            for (int i = 12; i < 16; i++)
                model.Addr[i - 12] = bb[i];
            model.MatchByte = bb[29];
            model.dFix = bb[16];
            if (model.Channel[0] == null) model.Channel[0] = new tChannel();
            model.Channel[0].ExpLeft = (bb[17] << 8) | (bb[18] & 0xff);
            model.Channel[0].ExpRight = (bb[19] << 8) | (bb[20] & 0xff);
            model.Channel[0].Trimm = bb[21];
            model.Channel[0].Revers = bb[22];

            if (model.Channel[1] == null) model.Channel[1] = new tChannel();
            model.Channel[1].ExpLeft = (bb[23] << 8) | (bb[24] & 0xff);
            model.Channel[1].ExpRight = (bb[25] << 8) | (bb[26] & 0xff);
            model.Channel[1].Trimm = bb[27];
            model.Channel[1].Revers = bb[28];
            cmd_pos = 0;
            cmd = 0;
            onModelInfoView();
        }
    }
}
