using System.Security.Cryptography;
using System.Text;

namespace test
{
    public static class CryptoHelper
    {
        public static string ComputeSha256Hash(string raw)
        {
            if (raw == null) return null;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
