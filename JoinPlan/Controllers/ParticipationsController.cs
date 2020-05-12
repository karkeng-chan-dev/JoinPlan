using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JoinPlan.DAL;
using JoinPlan.Models;

namespace JoinPlan.Controllers
{
    public class ParticipationsController : ApiController
    {
        private JoinPlanContext db = new JoinPlanContext();

        // GET: api/Participations/5
        [ResponseType(typeof(List<Activity>))]
        public IHttpActionResult GetParticipation(string participantEmail)
        {
            List<Participation> participations = db.Participations.Where(p => p.ParticipantEmail == participantEmail).ToList();

            List<Activity> participatedActivities = new List<Activity>();

            participations.ForEach(p =>
               {
                   var activity = db.Activities.Find(p.ActivityID);
                   participatedActivities.Add(activity);
               });
            
            return Ok(participatedActivities.OrderByDescending(a => a.ActivityDateTime));
        }

        // POST: api/Participations
        [ResponseType(typeof(Participation))]
        public IHttpActionResult PostParticipation(Participation participation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (db.Participations.ToList().FindIndex( p => p.ActivityID == participation.ActivityID && p.ParticipantEmail == participation.ParticipantEmail ) < 0)
            {
                db.Participations.Add(participation);
                db.SaveChanges();

                return this.Content(HttpStatusCode.OK, new { Success = true });
            }
            else
            {
                return this.Content(HttpStatusCode.OK, new { Success = false, Message = "You've already participated in this activity" });
            }
        }

        // DELETE: api/Participations/5
        [ResponseType(typeof(Participation))]
        public IHttpActionResult DeleteParticipation(int id)
        {
            Participation participation = db.Participations.Find(id);
            if (participation == null)
            {
                return NotFound();
            }

            db.Participations.Remove(participation);
            var result = db.SaveChanges();

            return this.Content(HttpStatusCode.OK, new { Success = result > 0 });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipationExists(int id)
        {
            return db.Participations.Count(e => e.ParticipationID == id) > 0;
        }
    }
}