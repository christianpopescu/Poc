using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PocCShaprFileCompare
{
    internal class FileHelper
    {
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
    }
}
