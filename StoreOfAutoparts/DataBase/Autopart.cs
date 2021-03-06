//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreOfAutoparts.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autopart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autopart()
        {
            this.Consignment = new HashSet<Consignment>();
        }
    
        public int ID { get; set; }
        public string PartNumber { get; set; }
        public int ManufacturerID { get; set; }
        public int ProducingCountryID { get; set; }
        public int CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Country Country { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consignment> Consignment { get; set; }
    }
}
