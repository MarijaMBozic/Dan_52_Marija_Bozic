//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PastryShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cake
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cake()
        {
            this.ListOfCakeInOrders = new HashSet<ListOfCakeInOrder>();
        }
    
        public int CakeId { get; set; }
        public string Name { get; set; }
        public bool IsForChildren { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListOfCakeInOrder> ListOfCakeInOrders { get; set; }
    }
}
