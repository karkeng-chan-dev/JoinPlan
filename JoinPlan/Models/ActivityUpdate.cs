using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoinPlan.Models
{
    public class ActivityUpdate
    {
        public int ID { get; set; }
        public string Body { get; set; }
        [Display(Name = "Activity Date & Time"),
         DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; }

        public int ActivityID { get; set; }
        //public virtual Activity Activity { get; set; }

        public ActivityUpdate() { }

        public ActivityUpdate ( string updateText, int activityId)
        {
            this.Body = updateText;
            this.PublishedDateTime = DateTime.Now;
            this.ActivityID = activityId;
        }
    }
}