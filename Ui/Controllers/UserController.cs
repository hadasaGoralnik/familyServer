using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using Bl;
using System.Web.Http.Cors;
using Dto.Requests;

namespace Ui.Controllers
{
    [Route("api/[controller]/{action}")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public List<UserDto> GetLogin()
        {
            return UserService.gets();
        }
        [HttpPost]
        public UserDto Login(LoginRequest request)
        {
            return UserService.Login(request);
        }
        [HttpPost]//,data
        public IHttpActionResult songPost(UserDto user)
        {
            if (user == null)
                return BadRequest();
            user = UserService.post(user);
            if (user != null)
                return Ok(user);
            return BadRequest();
        }
    }
}
