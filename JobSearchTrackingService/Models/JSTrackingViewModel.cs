using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchTrackingService.Models
{
    public class JSTrackingViewModel
    {
        public int JSTrackingID { get; set; }
        //public int CompanyID { get; set; }
        //public int LocationID { get; set; }
        //public int ContactID { get; set; }
        public string JobDescription { get; set; }
        public string SourcePosting { get; set; }
        public DateTime? ResumeDate { get; set; }
        public DateTime? InterviewDateTime { get; set; }
        public string Note { get; set; }
        public CompanyViewModel Company { get; set; }
        public LocationViewModel Location { get; set; }
        public ContactViewModel Contact { get; set; }
        public FollowUp1ViewModel FollowUp1 { get; set; }
        public FollowUp2ViewModel FollowUp2 { get; set; }
    }
}