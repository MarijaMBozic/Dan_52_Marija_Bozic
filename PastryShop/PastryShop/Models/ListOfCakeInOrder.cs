//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PastryShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListOfCakeInOrder
    {
        public int ListOfCakeInOrderId { get; set; }
        public int OrderId { get; set; }
        public int CakeId { get; set; }
    
        public virtual Cake Cake { get; set; }
        public virtual Order Order { get; set; }
    }
}