using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoinPlan.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Activity Image")]
        [Required]
        public string ImageUrl { get; set; }
        [Display(Name = "Organizer Contact")]
        [Required]
        public string OrganizerEmail { get; set; }
        [Display(Name = "Activity Date & Time"),
         DisplayFormat(DataFormatString ="{0:dd/MM/yyyy hh:mm:ss tt}",ApplyFormatInEditMode =true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ActivityDateTime { get; set; }
        [Display(Name = "Max. Participants")]
        [Required]
        public int MaxParticipant { get; set; }
        
        public virtual ICollection<Participation> Participations { get; set; }
        public virtual ICollection<ActivityUpdate> ActivityUpdates { get; set; }
    }
}