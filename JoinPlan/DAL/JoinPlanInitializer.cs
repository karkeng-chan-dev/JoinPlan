using JoinPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoinPlan.DAL
{
    public class JoinPlanInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JoinPlanContext>
    {
        protected override void Seed(JoinPlanContext context)
        {
            List<Activity> activities = new List<Activity>
            {
                new Activity{
                    Name ="Bukit Gasing Hiking",
                    ActivityDateTime = new DateTime(2020,06,30,08,00,00),
                    ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/12/24/e7/02/path-up-bukit-gasing.jpg",
                    Description = "Hiking @ Bukit Gasing to immerse yourself in the beauty of nature",
                    MaxParticipant = 14,
                    OrganizerEmail = "admin@joinplan.my",
                },
                new Activity{
                    Name ="Visit Aquaria @ KLCC",
                    ActivityDateTime = new DateTime(2020,05,01,12,00,00),
                    ImageUrl = "https://goticket.my/wp-content/uploads/2015/04/aquaria-klcc-061-1214x575@2x.jpeg",
                    Description = "Get amazed by impressive marine lives",
                    MaxParticipant = 10,
                    OrganizerEmail = "admin@joinplan.my",
                },
                new Activity{
                    Name ="Broga Hill Hiking",
                    ActivityDateTime = new DateTime(2020,05,31,08,00,00),
                    ImageUrl = "https://hype.my/wp-content/uploads/2017/08/broga-hill-.jpg",
                    Description = "Hiking @ Broga Hill to immerse yourself in the beauty of nature",
                    MaxParticipant = 14,
                    OrganizerEmail = "admin@joinplan.my",
                },
                new Activity{
                    Name ="Shark Diving Trip",
                    ActivityDateTime = new DateTime(2020,02,14,12,00,00),
                    ImageUrl = "https://www.zubludiving.com/images/Articles/Best-places-for-sharks/Reef_Shark_Sipadan.jpg",
                    Description = "Get amazed by shark around you experience",
                    MaxParticipant = 10,
                    OrganizerEmail = "admin@joinplan.my",
                },
                new Activity{
                    Name ="One day trip to Malacca",
                    ActivityDateTime = new DateTime(2020,08,30,08,00,00),
                    ImageUrl = "https://ak.jogurucdn.com/media/image/p25/place-2014-08-28-12-Afamosa71643fe1664c2c6ba29ef1b6e039ed14.jpg",
                    Description = "Hiking @ Bukit Gasing to immerse yourself in the beauty of nature",
                    MaxParticipant = 14,
                    OrganizerEmail = "admin@joinplan.my",
                },
                new Activity{
                    Name ="Visit Zoo Negara",
                    ActivityDateTime = new DateTime(2020,04,15,12,00,00),
                    ImageUrl = "https://www.tourplus.my/attachments/e4c372184136704e087c169342d3017bde28756c/store/16f7af7155e79c66dbebdf75e4b41ecb09504bf19d24d959cbcb7ea4284e/image",
                    Description = "Get amazed by impressive wild lives",
                    MaxParticipant = 15,
                    OrganizerEmail = "admin@joinplan.my",
                }
            };
            activities.ForEach(a => context.Activities.Add(a));

            List<ActivityUpdate> updates = new List<ActivityUpdate>
            {
                new ActivityUpdate("Event postponed due to MCO",1),
                new ActivityUpdate("Event postponed due to MCO",2),
            };

            updates.ForEach(u => context.ActivityUpdates.Add(u));

            List<Participation> participations = new List<Participation>
            {
                new Participation { ActivityID = 1 , ParticipantEmail = "member1@joinplan.my" } ,
                new Participation { ActivityID = 3 , ParticipantEmail = "member1@joinplan.my" } ,
            };

            participations.ForEach(p => context.Participations.Add(p));

            List<Feedback> feedbacks = new List<Feedback>
            {
                new Feedback { Body = "Feedback test 1", Subject="Feedback 1", MemberEmail = "member1@joinplan.my", Read=true } ,
                new Feedback { Body = "Feedback test 2", Subject="Feedback 2", MemberEmail = "member1@joinplan.my" } ,
            };

            feedbacks.ForEach(f => context.Feedbacks.Add(f));

            List<CMS> cmsData = new List<CMS>
            {
                new CMS { Name = "LANDING_BANNER_BG", Value = "https://publicholidays.com.my/wp-content/uploads/2018/03/Malaysia_2020_Malay_Output.jpg", Type="IMAGE" },
                new CMS { Name = "LANDING_HEADER", Value = "Join and plan your trip with JoinPlan!", Type="TEXT" },
                new CMS { Name = "ABOUT_TEAM", Value = "We are a group of trip enthusiasts having ...", Type="TEXT" },
                new CMS { Name = "ABOUT_JP", Value = "JoinPlan is a platform to...", Type="TEXT" },
                new CMS { Name = "FB_LINK", Value = "https://www.facebool.com", Type="LINK" },
                new CMS { Name = "IG_LINK", Value = "https://www.instagram.com", Type="LINK" },
                new CMS { Name = "TW_LINK", Value = "https://www.twitter.com", Type="LINK" },
            };
            cmsData.ForEach(c => context.CMS.Add(c));
            context.SaveChanges();
        }
    }
}