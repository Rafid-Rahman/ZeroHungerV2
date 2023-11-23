namespace ZeroHunger_v2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int AssignmentID { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime AssignmentTime { get; set; }
        public string Status { get; set; }
    
        public virtual User User { get; set; }
        public virtual Request Request { get; set; }
    }
}
