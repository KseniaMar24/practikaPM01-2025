//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppKS
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЛогиПользователей
    {
        public int ID_лога { get; set; }
        public int ID_пользователя { get; set; }
        public string Действие { get; set; }
        public System.DateTime ВремяДействия { get; set; }
    
        public virtual Пользователи Пользователи { get; set; }
    }
}
