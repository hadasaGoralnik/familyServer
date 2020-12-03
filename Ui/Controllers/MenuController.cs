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
    [RoutePrefix("api/menu")]
     public class MenuController : ApiController
    {
        [HttpGet]
        [Route("GetMenusByEventId/{eventId}")]
        public IHttpActionResult GetMenusByEventId(int eventId)
        {
            return Ok(MenuService.GetMenusByEventId(eventId));
        }
        [HttpPost]
        public IHttpActionResult CreateMenu(MenuDto menu)
        {
            if (menu == null)
                return BadRequest();
            MenuDto menu1 = MenuService.CreateMenu(menu);
            if (menu1 != null)
                return Ok(menu1);
            return BadRequest();
        }
    }
}