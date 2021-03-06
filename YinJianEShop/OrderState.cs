//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YinJianEShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderState()
        {
            this.GoodOrder = new HashSet<GoodOrder>();
        }
    
        public int Id { get; set; }
        public Nullable<int> OrderState1 { get; set; }
        public string OrderNum { get; set; }
        public Nullable<decimal> RealPay { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public Nullable<System.DateTime> UserGetDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> AddressId { get; set; }
        public string CourierNum { get; set; }
    
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodOrder> GoodOrder { get; set; }
        public virtual UserShoppingAddress UserShoppingAddress { get; set; }
    }
}
