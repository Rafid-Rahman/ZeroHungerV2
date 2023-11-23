namespace ZeroHunger_v2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            this.Assignments = new HashSet<Assignment>();
            this.DistributionRecords = new HashSet<DistributionRecord>();
        }
    
        public int RequestID { get; set; }
        public int RestaurantID { get; set; }
        public System.DateTime RequestTime { get; set; }
        public System.DateTime MaxPreservationTime { get; set; }
        public string Status { get; set; }
        public string FoodDetails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistributionRecord> DistributionRecords { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
