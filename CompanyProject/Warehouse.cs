//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.Warehouse_prod_PurchOrd = new HashSet<Warehouse_prod_PurchOrd>();
            this.Warehouse_prod_salesOrd = new HashSet<Warehouse_prod_salesOrd>();
        }
    
        public string W_name { get; set; }
        public string Address { get; set; }
        public Nullable<int> Manager_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse_prod_PurchOrd> Warehouse_prod_PurchOrd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse_prod_salesOrd> Warehouse_prod_salesOrd { get; set; }
    }
}
