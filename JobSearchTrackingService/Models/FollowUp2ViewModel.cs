using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchTrackingService.Models
{
    public class FollowUp2ViewModel
    {
        public int JSTrackingID { get; set; }
        public string Type { get; set; }
        public DateTime? FollowUpDate { get; set; }
    }
}