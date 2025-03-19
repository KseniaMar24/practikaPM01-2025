using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppKS;

namespace WebAppKS.Models
{
    public class Response_Warehouse
    {
        public Response_Warehouse(Склады склады)
        {
            ID_склада = склады.ID_склада;
            Наименование = склады.Наименование;
            Адрес = склады.Адрес;
            Тип = склады.Тип;
         


        }
        public int ID_склада { get; set; }
        public string Наименование { get; set; }
        public string Адрес { get; set; }
        public string Тип { get; set; }
    }
}