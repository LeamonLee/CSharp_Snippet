using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encoding_practice
{
    class Program
    {
        static void Main(string[] args)
        {

            byte x = 65;
            Console.WriteLine((char)x);
            char y = 'A';
            Console.WriteLine((byte)y);

            // ===============================

            string s = "abcde";
            byte[] lstBytes = ASCIIEncoding.ASCII.GetBytes(s);

            byte[] lstBytes2 = Encoding.ASCII.GetBytes(s);      // 上一行可以簡化名稱成這個

            foreach (var _byte in lstBytes)
            {
                Console.WriteLine("lstBytes: Byte {0} = {1}", _byte, (char)_byte);
            }

            Console.WriteLine();

            foreach (var _byte in lstBytes2)
            {
                Console.WriteLine("lstBytes2: Byte {0} = {1}", _byte, (char)_byte);
            }

            // ===============================

            string myData = "Here is a string to encode.";

            string myDataEncoded = EncodeTo64(myData);

            Console.WriteLine("Encoded data: {0}", myDataEncoded);

            string myDataUnencoded = DecodeFrom64(myDataEncoded);

            Console.WriteLine("Decoded data: {0}", myDataUnencoded);

            Console.ReadKey();

        }

        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        static public string DecodeFrom64(string encodedData)
        {

            byte[] encodedDataAsBytes

                = System.Convert.FromBase64String(encodedData);

            string returnValue =

               ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }


    }
}
