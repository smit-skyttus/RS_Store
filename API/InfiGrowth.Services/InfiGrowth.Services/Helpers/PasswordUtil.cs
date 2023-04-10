using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace InfiGrowth.Services.Helpers
{
    public static class PasswordUtil
    {
        public static string HashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCryptNet.Verify(password, passwordHash);
        }

        public static string Encryptdata(string password)
        {
            byte[] encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encode);
        }

        public static string Decryptdata(string encryptpwd)
        {
            UTF8Encoding encodepwd = new();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new string(decoded_char);
        }

        public static string GeneratePassword()
        {
            int passwordlength = 10;
            string _allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random randNum = new Random();
            char[] chars = new char[passwordlength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < passwordlength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}
