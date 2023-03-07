using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PocCShaprFileCompare
{
    internal class FileHelper
    {
        // Using memcmp to fast compare two byte array
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        private readonly HashAlgorithm cryptographySevice;

        public FileHelper(HashAlgorithm hashAlgorithm) => this.cryptographySevice = hashAlgorithm;
        public string ComputeFielHash(string filePath)
        {

            using (cryptographySevice)
            {
                using (var fileStream = new FileStream(filePath,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.ReadWrite))
                {
                    var hash = cryptographySevice.ComputeHash(fileStream);
                    var hashString = Convert.ToBase64String(hash);
                    return hashString.TrimEnd('=');
                }
            }

        }
        public static bool StreamEqual(Stream pFirstStream, Stream pSecondStream)
        {
            const int bufferSize = 2048;
            byte[] bufferFirst = new byte[bufferSize]; //buffer size
            byte[] bufferSecond = new byte[bufferSize];
            while (true)
            {
                int countFirst = pFirstStream.Read(bufferFirst, 0, bufferSize);
                int countSecond = pSecondStream.Read(bufferSecond, 0, bufferSize);

                if (countFirst != countSecond)
                    return false;

                if (countFirst == 0)
                    return true;

                // You might replace the following with an efficient "memcmp"
                if (!ByteArrayCompare(bufferFirst, bufferSecond))
                    return false;
            }
           
        }

        public static bool FilesEqual(string pFirstFile, string pSecondFile)
        {
            using (var file1 = new FileStream(pFirstFile, FileMode.Open))
            using (var file2 = new FileStream(pSecondFile, FileMode.Open))
                return StreamEqual(file1, file2);
        }

        private static bool ByteArrayCompare(byte[] firstArray, byte[] secondArray) 
        {
            return firstArray.Length == secondArray.Length && (memcmp(firstArray,secondArray, firstArray.Length) == 0) ;


        }

       
    }
}
