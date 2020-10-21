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

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public List<UserDto> GetLogin()
        {
            return UserService.gets();
        }
        [HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {

            UserDto user= UserService.Login(request);
            if (user == null)
                return BadRequest();
           if (user != null)
                return Ok(user);
            return BadRequest();
        }
  
    }
}
