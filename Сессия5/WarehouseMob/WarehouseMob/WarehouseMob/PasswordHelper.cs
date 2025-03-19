using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseMob
{
    public static class PasswordHelper
    {
        // Хэширование пароля
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Проверка пароля
        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
