using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dto;
using Bl;
using System.Web.Http;
using System.Web.Http.Cors;
using System.IO;

namespace Ui.Controllers
{
    [RoutePrefix("api/events")]
 
    public class EventsController: ApiController
    {
        [Route("getEventsByGroupId/{groupId}")]
        public IHttpActionResult GetEventsByGroupId(int groupId)
        {
            return Ok(EventService.Get(groupId));
        }
        [HttpGet]
        [Route("getEventById/{eventId}")]
        public IHttpActionResult GetEventById(int eventId)
        {
            return Ok(EventService.GetEventById(eventId));
        }
        [HttpPost]
        [Route("Upload/{id}")]
        public IHttpActionResult SaveImage(int id)
        {

            var myFile = HttpContext.Current.Request.Files[0];
            var ext = myFile.FileName.Split('.')[1];
            var name = myFile.FileName.Split('.')[0];
            string fileName = Guid.NewGuid() + "." + ext;
            if (myFile != null && myFile.ContentLength != 0)
            {
                string fullPath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory,"Images", fileName);
                myFile.SaveAs(fullPath);
            }

            EventService.SaveImage(id, fileName, name);

            return Ok();
        }

        [Route("GetPicturesByEventId/{eventId}")]
        public IHttpActionResult GetPicturesByEventId(int eventId)
        {
            return Ok(EventService.GetPicturesByEventId(eventId));
        }
        [HttpGet]
        [Route("GetAllEventsKind")]
        public IHttpActionResult GetAllEventsKind()
        {
            return Ok(EventService.GetAllEventsKind());
        }
        [HttpPost]
        public IHttpActionResult CreateEvents(EventsDto events)
        {
            if (events == null)
                return BadRequest();
            EventsDto events1 = EventService.CreateEvents(events);
            if (events1 != null)
                return Ok(events1);
            return BadRequest();
        }

    }
}