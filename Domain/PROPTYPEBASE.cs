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
    
    public partial class PROPTYPEBASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROPTYPEBASE()
        {
            this.MobileBrand = new HashSet<MobilePhone>();
            this.MobileModel = new HashSet<MobilePhone>();
            this.MobileSupplier = new HashSet<MobilePhone>();
        }
    
        public int PROPID { get; set; }
        public string PROPCODE { get; set; }
        public string PROPINITCODE { get; set; }
        public string PROPNAME { get; set; }
        public Nullable<int> PROPSTATE { get; set; }
        public Nullable<int> PROPINIT { get; set; }
        public Nullable<int> PROPDEFAULT { get; set; }
        public Nullable<int> PROPPARENT { get; set; }
        public Nullable<int> PROPLEVEL { get; set; }
        public Nullable<int> PROPTYPE { get; set; }
        public Nullable<int> PROPBASEID { get; set; }
        public Nullable<int> PROPORDER { get; set; }
        public string PROPRAVCODE { get; set; }
        public string PROPBASECODE { get; set; }
        public Nullable<int> PROPDETAILFLAG { get; set; }
        public string PROPMEMO { get; set; }
        public Nullable<int> PROPINT1 { get; set; }
        public Nullable<int> PROPINT2 { get; set; }
        public Nullable<int> PROPINT3 { get; set; }
        public Nullable<int> PROPINT4 { get; set; }
        public Nullable<int> PROPINT5 { get; set; }
        public Nullable<int> PROPINT6 { get; set; }
        public Nullable<int> PROPINT7 { get; set; }
        public Nullable<int> PROPINT8 { get; set; }
        public Nullable<double> PROPFLOAT1 { get; set; }
        public Nullable<double> PROPFLOAT2 { get; set; }
        public Nullable<double> PROPFLOAT3 { get; set; }
        public Nullable<double> PROPFLOAT4 { get; set; }
        public string PROPSTRING1 { get; set; }
        public string PROPSTRING2 { get; set; }
        public string PROPSTRING3 { get; set; }
        public string PROPSTRING4 { get; set; }
        public string PROPSTRING5 { get; set; }
        public string PROPSTRING6 { get; set; }
        public string PROPSTRING7 { get; set; }
        public string PROPSTRING8 { get; set; }
        public string PROPSTRING9 { get; set; }
        public string PROPSTRING10 { get; set; }
        public string CREATOR { get; set; }
        public string CREATEDATE { get; set; }
        public string UPDATER { get; set; }
        public string UPDATEDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MobilePhone> MobileBrand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MobilePhone> MobileModel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MobilePhone> MobileSupplier { get; set; }
    }
}