using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarWin
{
    public class Channel
    {
        decimal ExpLeft;
        decimal ExpRight;
        decimal Trimm;
        byte reverse;
    }

    public class CarItem
    {
        string MenuName;
        Channel[] Channels = new Channel[2];
        byte dFix;
        byte[] rf_magic = new byte[4];
    }

    public static class CarTx
    {
        static CarItem[] Items = new CarItem[8];
        static byte CurrIndex;

        public static byte SelectedIndex
        {
            get
            {
                return CurrIndex;
            }
            set
            {
                CurrIndex = value;
            }
        }
        public static void Load(byte Index)
        {

        }
        public static void LoadAll()
        {

        }
    }
}
