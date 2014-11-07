using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace CarWin
{
    public static class SerialProtocol
    {
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

        public static tChannel aChannel1 = new tChannel();
        public static tChannel aChannel2 = new tChannel();
        public delegate void onCmdChannels();

        public static event onCmdChannels onChannels;
        public static event onCmdChannels onCalibrationView;

        private static void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int count = _SPort.BytesToRead;
            byte[] data = new byte[count];
            _SPort.Read(data, 0, count);
            ParseData(data, count);
        }

        private static void ParseData(byte[] buff, int buff_size)
        {
            for (int i = 0; i < buff_size; i++)
            {
                if (buff[i] == 0x5e)
                {
                    cmd_pos = 0;
                    cmd = 0;
                }
                else
                    if (cmd_pos == 0)
                    {
                        cmd = buff[i];
                        cmd_pos++;
                    }
                    else
                    {
                        Buffer[cmd_pos - 1] = buff[i];
                        cmd_pos++;
                        switch (cmd)
                        {
                            case 0x01: if (cmd_pos == 5) 
                                ParseChannels(); break;
                            case 0x02: if (cmd_pos == 13) 
                                ParseCalibration(); break;
                        }

                    }
            }
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
            cmd_pos = 0;
            cmd = 0;
            onChannels();
        }

        public static void LoadCalibrationRequest()
        {
            byte[] bb = new byte[2];
            bb[0] = 0x5e;
            bb[1] = 0x02;
            _SPort.Write(bb, 0, 2);
        }
    }
}
