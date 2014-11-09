using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarWin
{
    public class tChannel
    {
        public int ExpLeft;
        public int ExpRight;
        public byte Trimm;
        public byte Revers;

        public int Center;
        public int MaxVal;
        public int MinVal;
        public int chValue;
    }

    public class tModel
    {
        public string ModelName;
        public byte[] Addr = new byte[4];
        public byte MatchByte;
        public byte dFix;
        public tChannel[] Channel = new tChannel[2];
    }
}
