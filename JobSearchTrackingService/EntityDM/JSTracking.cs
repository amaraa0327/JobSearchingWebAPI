//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobSearchTrackingService.EntityDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class JSTracking
    {
        public int JSTrackingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string JobDescription { get; set; }
        public string SourcePosting { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<System.DateTime> ResumeDate { get; set; }
        public Nullable<System.DateTime> InterviewDate { get; set; }
        public string Note { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual FollowUp1 FollowUp1 { get; set; }
        public virtual FollowUp2 FollowUp2 { get; set; }
        public virtual Location Location { get; set; }
    }
}