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
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Xml.Linq;

    public partial class tblATPlant
    {
        public long plant_id { get; set; }
        public string plant_name { get; set; }
        public Nullable<long> node_id { get; set; }
        public byte[] img { get; set; }
        public string details { get; set; }

        public virtual tblATNode tblATNode { get; set; }
    }
}
