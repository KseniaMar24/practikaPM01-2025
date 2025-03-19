using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppKS;

namespace WebAppKS.Models
{
    public class Response_Users
    {
        public Response_Users(Пользователи юзер)
        {
            ID_пользователя = юзер.ID_пользователя;
            ИмяПользователя = юзер.ИмяПользователя;
            ХэшПароля = юзер.ХэшПароля;
            ЭлектроннаяПочта = юзер.ЭлектроннаяПочта;
            Телефон = юзер.Телефон;
            ПолноеИмя = юзер.ПолноеИмя;
            ID_роли = юзер.ID_роли;
            СекретДвухфакторнойАутентификации = юзер.СекретДвухфакторнойАутентификации;



        }
        public int ID_пользователя { get; set; }
        public string ИмяПользователя { get; set; }
        public string ХэшПароля { get; set; }
        public string ЭлектроннаяПочта { get; set; }
        public string Телефон { get; set; }
        public string ПолноеИмя { get; set; }
        public int ID_роли { get; set; }
        public string СекретДвухфакторнойАутентификации { get; set; }
    }
}