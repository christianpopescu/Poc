using PocCShaprFileCompare;
using System.Security.Cryptography;

Console.WriteLine("HashValue");
string FilePath = @"E:\CCP_library\Doc\books_2016\2016_2\21st Century C.pdf";
FileHelper MD5FileHelper = new(new MD5CryptoServiceProvider());
FileHelper SHA1FileHelper = new(new SHA1CryptoServiceProvider());
FileHelper SHA256FileHelper = new(new SHA256CryptoServiceProvider());
FileHelper SHA384FileHelper = new(new SHA384CryptoServiceProvider());
FileHelper SHA512FileHelper = new(new SHA512CryptoServiceProvider());

Console.WriteLine("MD5 Hash Code  : {0}", MD5FileHelper.ComputeFielHash(FilePath));
Console.WriteLine("SHA1 Hash Code  : {0}", SHA1FileHelper.ComputeFielHash(FilePath));
Console.WriteLine("SHA256 Hash Code: {0}", SHA256FileHelper.ComputeFielHash(FilePath));
Console.WriteLine("SHA384 Hash Code: {0}", SHA384FileHelper.ComputeFielHash(FilePath));
Console.WriteLine("SHA512 Hash Code: {0}", SHA512FileHelper.ComputeFielHash(FilePath));
static string ComputeFielHash (string filePath, HashAlgorithm cryptographySevice)
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
