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
    
    public partial class TC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TC()
        {
            this.Pavilioni = new HashSet<Pavilioni>();
        }
    
        public int Number_SC { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> ValueAddedFactor { get; set; }
        public Nullable<double> Floors { get; set; }
        public byte[] Picture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pavilioni> Pavilioni { get; set; }
    }
}