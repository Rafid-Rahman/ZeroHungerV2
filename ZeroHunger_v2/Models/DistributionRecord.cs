namespace ZeroHunger_v2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DistributionRecord
    {
        public int RecordID { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime DistributionTime { get; set; }
        public string Status { get; set; }
    
        public virtual User User { get; set; }
        public virtual Request Request { get; set; }
    }
}
