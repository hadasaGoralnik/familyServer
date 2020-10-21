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
    [RoutePrefix("api/group")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class GroupController : ApiController
    {
        [Route("getGroupsByUserId/{userId}")]
        public IHttpActionResult GetGroupsByUserId(int userId)
        {
            return Ok( GroupService.Get(userId));
        }
      
        [HttpPost]//,data
        public IHttpActionResult songPost(GroupsDto group)
        {
            if (group == null)
                return BadRequest();
            group = GroupService.Sighin(group);
            if (group != null)
                return Ok(group);
            return BadRequest();
        }

    }
}