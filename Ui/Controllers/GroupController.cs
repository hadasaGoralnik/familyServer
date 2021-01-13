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

    public class GroupController : ApiController
    {

        [HttpGet]
        [Route("api/group/getGroups/{UserId}")]
 
        public IHttpActionResult getGroups(int UserId)
        {
            return Ok( GroupService.Get(UserId));
        }
        [HttpGet]
        [Route("api/group/GetUsers/{GroupId}")]

        public IHttpActionResult GetUsers(int GroupId)
        {
            return Ok(GroupService.GetUsers(GroupId));
        }

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
        [HttpPost]
        public IHttpActionResult DeleteGroup(DeleteGroupRequest request)
        {

            GroupsDto group = GroupService.DeleteGroup(request);
            if (group == null)
                return BadRequest();
            if (group != null)
                return Ok(group);
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult DeleteUserFromGroup(DeleteUserFromGroupRequest request)
        {

            GroupsDto group = GroupService.DeleteUserFromGroup(request);
            if (group == null)
                return BadRequest();
            if (group != null)
                return Ok(group);
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddUserToGroup(AddUeserToGroupRequest request)
        {
            GroupService.AddUserToGroup(request);

            return Ok();
        }
    }

}