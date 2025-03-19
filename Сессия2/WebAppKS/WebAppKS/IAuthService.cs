using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppKS;

namespace WebAppKS
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
        string AuthenticateWith2FA(string username, string token);
    }

    public class AuthService : IAuthService
    {
        private readonly List<Пользователи> _users = new List<Пользователи>
    {
        new Пользователи { ID_пользователя = 1, ИмяПользователя = "admin", ХэшПароля = "hashed_password_1", ID_роли = 1 },
        new Пользователи { ID_пользователя = 2, ИмяПользователя = "storekeeper", ХэшПароля = "hashed_password_2", ID_роли = 2 }
    };

        public string Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.ИмяПользователя == username && u.ХэшПароля == password);
            if (user == null)
                return null;

            // Генерация JWT-токена (упрощенно)
            return "generated_jwt_token";
        }

        public string AuthenticateWith2FA(string username, string token)
        {
            var user = _users.SingleOrDefault(u => u.ИмяПользователя == username);
            if (user == null || token != "valid_2fa_token")
                return null;

            // Генерация JWT-токена (упрощенно)
            return "generated_jwt_token";
        }
    }
}