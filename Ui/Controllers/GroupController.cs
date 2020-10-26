using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dto;
using Bl;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto.Requests;

namespace Ui.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class GroupController : ApiController
    {

        [HttpGet]
        [Route("api/group/getGroups/{UserId}")]
 
        public IHttpActionResult getGroups(int UserId)
        {
            return Ok( GroupService.Get(UserId));
        }

        //[HttpPost]//,data
        //public IHttpActionResult songPost(GroupsDto group)
        //{
        //    if (group == null)
        //        return BadRequest();
        //    group = GroupService.Sighin(group);
        //    if (group != null)
        //        return Ok(group);
        //    return BadRequest();
        //}
        [HttpPost]
        public IHttpActionResult AddGroup(AddGroupRequest request)
        {

            GroupsDto group = GroupService.AddGroup(request);
            if (group == null)
                return BadRequest();
            if (group != null)
                return Ok(group);
            return BadRequest();
        }
    }
}