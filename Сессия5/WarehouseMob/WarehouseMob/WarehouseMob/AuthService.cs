using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseMob.DataBase;

namespace WarehouseMob
{
    public class AuthService
    {
        private readonly DatabaseContext _database;

        public AuthService(DatabaseContext database)
        {
            _database = database;
        }

        // Первый этап аутентификации: проверка почты и пароля
        public async Task<Пользователи> AuthenticateAsync(string email, string password)
        {
            var пользователь = await _database.GetПользовательПоПочтеAsync(email);
            if (пользователь == null)
            {
                throw new Exception("Пользователь с такой почтой не найден.");
            }

            if (!PasswordHelper.VerifyPassword(password, пользователь.ХэшПароля))
            {
                throw new Exception("Неверный пароль.");
            }

            return пользователь;
        }

        // Второй этап аутентификации: проверка токена
        public bool VerifyToken(Пользователи пользователь, string Токен)
        {
            return пользователь.Токен.Equals(Токен, StringComparison.OrdinalIgnoreCase);
        }
    }
}

