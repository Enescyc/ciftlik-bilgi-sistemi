//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CiftlikCalisma
{
    using System;
    using System.Collections.Generic;
    
    public partial class Childs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Childs()
        {
            this.ChildVaccine = new HashSet<ChildVaccine>();
        }
    
        public int ShipId { get; set; }
        public int Ciftlikno { get; set; }
        public int Devletno { get; set; }
        public Nullable<double> kuzu_Price { get; set; }
        public string kuzu_durum { get; set; }
        public string kuzu_not { get; set; }
        public string kuzu_cinsiyet { get; set; }
        public System.DateTime kuzu_date { get; set; }
        public int MomId { get; set; }
    
        public virtual Ships Ships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChildVaccine> ChildVaccine { get; set; }
    }
}