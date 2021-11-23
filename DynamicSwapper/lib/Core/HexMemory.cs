using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSwapper.lib.Core
{
    public class HexMemory
    {
        public void WriteHex(string hex, string file, int offset)
        {
            // write hex in memory
            BinaryWriter mem = new BinaryWriter((Stream)File.Open(file, FileMode.Open, FileAccess.ReadWrite));
            mem.BaseStream.Seek(offset, SeekOrigin.Begin);
            mem.Write(HexToByteArray(hex));
            mem.Close();
            // Give the memory away that was used
            mem.Dispose();
        }
        public static byte[] HexToByteArray(string input)
        {
            if (input.Contains(" "))
            {
                input = input.Replace(" ", "");
            }
            if (input.Length % 2 != 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "ERROR", input));
            }
            byte[] bytearray = new byte[input.Length / 2];
            for (int i = 0; i < bytearray.Length; i++)
            {
                string str = input.Substring(i * 2, 2);
                bytearray[i] = byte.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return bytearray;
        }
    }
}
