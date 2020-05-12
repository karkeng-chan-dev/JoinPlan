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
    public class ActivitiesController : ApiController
    {
        private JoinPlanContext db = new JoinPlanContext();

        // GET: api/Activities
        public IQueryable<Activity> GetActivities(Boolean futureDated = false)
        {
            Func <Activity, bool> futureActs = (Activity activity) => activity.ActivityDateTime >= DateTime.Now;
            Func <Activity, bool> pastActs = (Activity activity) => activity.ActivityDateTime < DateTime.Now;

            return db.Activities.Include(a => a.ActivityUpdates).Where( futureDated ? futureActs : pastActs ).OrderByDescending( a => a.ActivityDateTime ).AsQueryable();
        }

        // GET: api/Activities
        //public List<Activity> GetActivitiesFiltered(Boolean futureDated)
        //{
        //    Predicate<Activity> futureActs = (Activity activity) => activity.ActivityDateTime >= DateTime.Now;
        //    Predicate<Activity> pastActs = (Activity activity) => activity.ActivityDateTime < DateTime.Now;

        //    return db.Activities
        //        .Include(a => a.ActivityUpdates).ToList().FindAll(futureDated ? futureActs : pastActs);
        //}


        // GET: api/Activities/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult GetActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityID)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Activities
        [ResponseType(typeof(Activity))]
        public IHttpActionResult PostActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activity.ActivityID }, activity);
        }

        // DELETE: api/Activities/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityID == id) > 0;
        }
    }
}