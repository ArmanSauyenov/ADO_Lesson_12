//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TablesLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesLocation()
        {
            this.newEquipment = new HashSet<newEquipment>();
        }
    
        public int intLocationId { get; set; }
        public string strLocationName { get; set; }
        public Nullable<int> intMajorLocationID { get; set; }
        public Nullable<double> floatWageStatements { get; set; }
        public Nullable<int> intWageStatementsCurrency { get; set; }
        public Nullable<double> floatAdministrativeExpenses { get; set; }
        public Nullable<int> intAdministrativeExpensesCurrency { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newEquipment> newEquipment { get; set; }
    }
}
