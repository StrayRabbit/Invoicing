//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class MobilePhone
    {
        public int ID { get; set; }
        public string MobileIMEI { get; set; }
        public Nullable<int> MobileBrandId { get; set; }
        public Nullable<int> MobileModelId { get; set; }
        public Nullable<decimal> MobileCost { get; set; }
        public Nullable<decimal> MobileSales { get; set; }
        public Nullable<decimal> MobileProfit { get; set; }
        public Nullable<int> MobileSupplierId { get; set; }
        public Nullable<int> MobileSalesPersonId { get; set; }
        public Nullable<System.DateTime> MobileInTime { get; set; }
        public Nullable<System.DateTime> MobileOutTime { get; set; }
        public Nullable<int> MobileState { get; set; }
        public string MobileRemarks { get; set; }
        public string MobileOutRemarks { get; set; }
    
        public virtual PROPTYPEBASE MobileSupplier { get; set; }
        public virtual PROPTYPEBASE MobileBrand { get; set; }
        public virtual PROPTYPEBASE MobileModel { get; set; }
        public virtual PROPTYPEBASE SalesPerson { get; set; }
    }
}
