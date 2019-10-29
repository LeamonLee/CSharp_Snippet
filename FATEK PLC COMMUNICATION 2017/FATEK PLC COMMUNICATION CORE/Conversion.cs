using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialNetworks.FatekCom
{
    public class Conversion
    {

        #region HEX STRING TO NUMBER
        public static short HEXToINT(string hexNumber)  
        {
            short result = 0;
            result = short.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        public static int HEXToDINT(string hexNumber)
        {
            int result = 0;
            result = int.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        public static ushort HEXToWORD(string hexNumber)
        {
            ushort result = 0;
            result = ushort.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        public static uint HEXToDWORD(string hexNumber)
        {
            uint result = 0;
            result = uint.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        public static float HEXToREAL(string hexNumber)
        {
            float result = 0;
            result = float.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        #endregion

        #region NUMBER TO HEX STRING

        //public static short INTToHEX(short number)
        //{
        //    short result = 0;
        //    result = short.Parse(number, System.Globalization.NumberStyles.HexNumber);
        //    int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        //    return result;
        //}

        #endregion
    }
}
