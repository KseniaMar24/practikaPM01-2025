//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryKSS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Поставщики
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Поставщики()
        {
            this.ПриходныеНакладные = new HashSet<ПриходныеНакладные>();
        }
    
        public int ID_поставщика { get; set; }
        public string Наименование { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string КонтактныйТелефон { get; set; }
        public string ЭлектроннаяПочта { get; set; }
        public string Адрес { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПриходныеНакладные> ПриходныеНакладные { get; set; }
    }
}
