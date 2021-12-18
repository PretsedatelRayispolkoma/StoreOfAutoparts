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
    
    public partial class Consignment
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public int AutopartID { get; set; }
        public decimal PricePerUnit { get; set; }
        public int CountOfUnits { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public System.DateTime DateOfPurchase { get; set; }
    
        public virtual Autopart Autopart { get; set; }
        public virtual Provider Provider { get; set; }
    }
}