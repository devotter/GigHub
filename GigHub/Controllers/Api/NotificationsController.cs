using GigHub.App_Start;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<Notification, NotificationDto>();
            //    c.CreateMap<Gig, GigDto>();
            //    c.CreateMap<ApplicationUser, UserDto>();
            //    c.CreateMap<Genre, GenreDto>();
            //});

            //var mapper = config.CreateMapper();
             

            return notifications.Select(n => MappingProfile.Mapper.Map<Notification, NotificationDto>(n));

            //return notifications.Select(n => mapper.Map<Notification, NotificationDto>(n));

            //return notifications.Select(mapper.Map<Notification,NotificationDto>);


            //return notifications.Select(n => new NotificationDto 
            //{
            //    DateTime = n.DateTime,
            //    Gig = new GigDto 
            //    {
            //        Artist = new UserDto 
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name
            //        },
            //        DateTime = n.Gig.DateTime,
            //        Id = n.Gig.Id,
            //        IsCanceled = n.Gig.IsCanceled,
            //        Venue = n.Gig.Venue
            //    },
            //    OriginalDateTime = n.OriginalDateTime,
            //    OriginalVenue = n.OriginalVenue,
            //    Type = n.Type
            //});
        }


        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok();
        }

        
    }
}
