using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dto;
using Bl;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ui.Controllers
{
    [RoutePrefix("api/events")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
        [Route("GetPicturesByEventId/{eventId}")]
        public IHttpActionResult GetPicturesByEventId(int eventId)
        {
            return Ok(EventService.GetPicturesByEventId(eventId));
        }
        [HttpGet]
        [Route("GetMenusByEventId/{eventId}")]
        public IHttpActionResult GetMenusByEventId(int eventId)
        {
            return Ok(EventService.GetMenusByEventId(eventId));
        }
    }
}