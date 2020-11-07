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
        [HttpPost]
        public IHttpActionResult SignUp(UserRequest request)
        {

            UserDto user = UserService.SignUp(request);
            if (user == null)
                return BadRequest();
            if (user != null)
                return Ok(user);
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult UpdateUser(UpdateUserRequest request)
        {

            UserDto user = UserService.UpdateUser(request);
            if (user == null)
                return BadRequest();
            if (user != null)
                return Ok(user);
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult Unsubscribe(UnsuscribeRequest request)
        {

            UserDto user = UserService.Unsubscribe(request);
            if (user == null)
                return BadRequest();
            if (user != null)
                return Ok(user);
            return BadRequest();
        }
    }
}
