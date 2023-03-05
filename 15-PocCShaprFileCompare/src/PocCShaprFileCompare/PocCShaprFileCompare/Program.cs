using System.Security.Cryptography;

Console.WriteLine("HashValue");
string FilePath = @"E:\CCP_library\Doc\books_2016\2016_2\21st Century C.pdf";

Console.WriteLine("MD5 Hash Code  : {0}", ComputeFielHash(FilePath, new MD5CryptoServiceProvider()));
Console.WriteLine("SHA1 Hash Code  : {0}", ComputeFielHash(FilePath, new SHA1CryptoServiceProvider()));
Console.WriteLine("SHA256 Hash Code: {0}", ComputeFielHash(FilePath, new SHA256CryptoServiceProvider()));
Console.WriteLine("SHA384 Hash Code: {0}", ComputeFielHash(FilePath, new SHA384CryptoServiceProvider()));
Console.WriteLine("SHA512 Hash Code: {0}", ComputeFielHash(FilePath, new SHA512CryptoServiceProvider()));
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
