using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using Bl;
using System.Web.Http.Cors;

namespace Ui.Controllers
{
    [RoutePrefix("api/user")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public List<UserDto> GetLogin()
        {
            return UserService.gets();
        }
        //?id=1233
        public UserDto GetLogin(string password,string name)
        {
            return UserService.Login(password, name);
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
