//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KingITGalishnikov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arendatory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arendatory()
        {
            this.Arenda = new HashSet<Arenda>();
        }
    
        public int ID_tenant { get; set; }
        public Nullable<int> ID_rent { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arenda { get; set; }
    }
}
