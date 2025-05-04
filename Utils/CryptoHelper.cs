using System.Security.Cryptography;
using System.Text;

namespace BusinessAPI.Utils;

public static class CryptoHelper
{
  public static string Encrypt(string text)
  {
    using var sha512 = SHA512.Create();
    var bytes = Encoding.UTF8.GetBytes(text);
    var hash = sha512.ComputeHash(bytes);
    return Convert.ToBase64String(hash);
  }
  public static bool Verify(string text, string hash)
  {
    var encryptedText = Encrypt(text);
    return encryptedText == hash;
  }
}