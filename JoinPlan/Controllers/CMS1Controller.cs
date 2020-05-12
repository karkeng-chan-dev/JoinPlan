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
    public class CMS1Controller : ApiController
    {
        private JoinPlanContext db = new JoinPlanContext();

        // GET: api/CMS1
        public IQueryable<CMS> GetCMS()
        {
            return db.CMS;
        }
        
    }
}