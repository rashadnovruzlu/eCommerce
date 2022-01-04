using System.Security.Cryptography;
using System.Text;

namespace eCommerce.SharedKernel;

public static class TextEncryption
{
    private const string _key = "AAEWAwQFBgcICQoTDA0ODw==";
    private static TripleDESCryptoServiceProvider GetCryproProvider()
    {
        var md5 = new MD5CryptoServiceProvider();

        var key = md5.ComputeHash(Encoding.UTF8.GetBytes(_key));

        return new TripleDESCryptoServiceProvider() { Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
    }

    public static string Encrypt(string plainString)
    {
        var data = Encoding.UTF8.GetBytes(plainString);

        var tripleDes = GetCryproProvider();

        var transform = tripleDes.CreateEncryptor();

        var resultsByteArray = transform.TransformFinalBlock(data, 0, data.Length);

        return Convert.ToBase64String(resultsByteArray);
    }

    public static string Decrypt(string encryptedString)
    {
        var data = Convert.FromBase64String(encryptedString);

        var tripleDes = GetCryproProvider();

        var transform = tripleDes.CreateDecryptor();

        var resultsByteArray = transform.TransformFinalBlock(data, 0, data.Length);

        return Encoding.UTF8.GetString(resultsByteArray);
    }
}
