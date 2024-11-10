namespace RoomifyAR.StaticServices
{
    public class PasswordHasher
    {
        public static string Hash(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }

        public static bool VerifyPassword(string pwd, string hashedPwd)
        {
            return BCrypt.Net.BCrypt.Verify(pwd, hashedPwd);
        }
    }
}
