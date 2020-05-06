using System.Security.Cryptography;
using System.Text;

namespace ProductTracking.BL
{
    public class PasswordHasher
    {
        public static string HeshedPassword(string password)
        {
            using (var hashAlg = MD5.Create())
            {
                byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder(hash.Length * 2);
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}
