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
    
    public partial class GoodOrder
    {
        public int Id { get; set; }
        public Nullable<int> GoodId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> GoodsNum { get; set; }
    
        public virtual GoodsInfo GoodsInfo { get; set; }
        public virtual OrderState OrderState { get; set; }
    }
}
