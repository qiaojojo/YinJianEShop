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
    
    public partial class Sellers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sellers()
        {
            this.GoodsInfo = new HashSet<GoodsInfo>();
        }
    
        public int Id { get; set; }
        public string SellerNum { get; set; }
        public string SellerPasswd { get; set; }
        public string Telephone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsInfo> GoodsInfo { get; set; }
    }
}
