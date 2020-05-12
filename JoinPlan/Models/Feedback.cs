using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoinPlan.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        [Display(Name = "Member Email")]
        public string MemberEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Display(Name = "Message")]
        [Required]
        public string Body { get; set; }
        [Display(Name = "Feedback date time"),
         DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime FeedbackDateTime { get; set; } = DateTime.Now;
        [Display(Name = "Read")]
        [Required]
        public bool Read { get; set; } = false;
    }
}