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
    public class ActivityUpdatesController : ApiController
    {
        private JoinPlanContext db = new JoinPlanContext();

        // GET: api/ActivityUpdates
        public IQueryable<ActivityUpdate> GetActivityUpdates()
        {
            return db.ActivityUpdates;
        }

        // GET: api/ActivityUpdates/5
        [ResponseType(typeof(ActivityUpdate))]
        public IHttpActionResult GetActivityUpdate(int id)
        {
            List<ActivityUpdate> activityUpdates = db.ActivityUpdates.Where(a => a.ActivityID == id).ToList();
            //if (activityUpdate == null)
            //{
            //    return NotFound();
            //}

            return Ok(activityUpdates);
        }

        // PUT: api/ActivityUpdates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivityUpdate(int id, ActivityUpdate activityUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityUpdate.ID)
            {
                return BadRequest();
            }

            db.Entry(activityUpdate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityUpdateExists(id))
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

        // POST: api/ActivityUpdates
        //[ResponseType(typeof(ActivityUpdate))]
        //public IHttpActionResult PostActivityUpdate(ActivityUpdate activityUpdate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ActivityUpdates.Add(activityUpdate);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = activityUpdate.ID }, activityUpdate);
        //}

        // POST: api/ActivityUpdates
        //[ResponseType(typeof(ActivityUpdate))]
        public IHttpActionResult PostActivityUpdate(ActivityUpdate activityUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //System.Diagnostics.Debug.WriteLine(activityUpdate);

            //return Ok(activityUpdate);

            //string updateText = 

            var newUpdate = new ActivityUpdate(activityUpdate.Body, activityUpdate.ActivityID);
            db.ActivityUpdates.Add(newUpdate);
            var result = db.SaveChanges();

            return this.Content(HttpStatusCode.OK, new { success = result > 0 });
        }

        // DELETE: api/ActivityUpdates/5
        [ResponseType(typeof(ActivityUpdate))]
        public IHttpActionResult DeleteActivityUpdate(int id)
        {
            ActivityUpdate activityUpdate = db.ActivityUpdates.Find(id);
            if (activityUpdate == null)
            {
                return NotFound();
            }

            db.ActivityUpdates.Remove(activityUpdate);
            db.SaveChanges();

            return Ok(activityUpdate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityUpdateExists(int id)
        {
            return db.ActivityUpdates.Count(e => e.ID == id) > 0;
        }
    }
}