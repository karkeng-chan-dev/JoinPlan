using JoinPlan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace JoinPlan.DAL
{
    public class JoinPlanContext : DbContext
    {
        public JoinPlanContext() : base("JoinPlanContext")
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CMS> CMS { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<JoinPlan.Models.ActivityUpdate> ActivityUpdates { get; set; }

        public System.Data.Entity.DbSet<JoinPlan.Models.Participation> Participations { get; set; }
    }
}