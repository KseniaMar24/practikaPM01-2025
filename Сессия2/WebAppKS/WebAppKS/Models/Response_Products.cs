using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppKS;

namespace WebApplication1.Models
{
    public class Response_Products
    {
        public Response_Products(Товары товары)
        {
            ID_товара = товары.ID_товара;
            Наименование = товары.Наименование;
            Артикул = товары.Артикул;
            Штрихкод = товары.Штрихкод;
            Категория = товары.Категория;
            ЕдиницаИзмерения = товары.ЕдиницаИзмерения;
            Цена = товары.Цена;
            СрокГодности = товары.СрокГодности;
            СерийныйНомер = товары.СерийныйНомер;
            МинимальныйОстаток = товары.МинимальныйОстаток;


        }
        public int ID_товара { get; set; }
        public string Наименование { get; set; }
        public string Артикул { get; set; }
        public string Штрихкод { get; set; }
        public string Категория { get; set; }
        public string ЕдиницаИзмерения { get; set; }
        public decimal Цена { get; set; }
        public Nullable<System.DateTime> СрокГодности { get; set; }
        public string СерийныйНомер { get; set; }
        public Nullable<int> МинимальныйОстаток { get; set; }
    }
}