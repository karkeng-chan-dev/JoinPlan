using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JoinPlan.Models
{
    public class Participation
    {
        public int ParticipationID { get; set; }
        [Required]
        public int ActivityID { get; set; }
        [Required]
        public string ParticipantEmail { get; set; }
    }
}