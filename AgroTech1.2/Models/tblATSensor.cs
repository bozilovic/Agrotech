//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroTech1._2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblATSensor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblATSensor()
        {
            this.tblATNodesSensorsConnections = new HashSet<tblATNodesSensorsConnection>();
        }
    
        public long sensor_id { get; set; }
        public string sensor_type { get; set; }
        public string measuring_unit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblATNodesSensorsConnection> tblATNodesSensorsConnections { get; set; }
    }
}
