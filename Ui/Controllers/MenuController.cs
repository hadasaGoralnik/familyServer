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
        [HttpGet]
        [Route("GetMenuByMenuId/{menuId}")]
        public IHttpActionResult GetMenuByMenuId(int menuId)
        {
            return Ok(MenuService.GetMenuByMenuId(menuId));
        }
        [HttpPost]
        [Route("CreateMenu")]
        public IHttpActionResult CreateMenu(MenuDto menu)
        {
            if (menu == null)
                return BadRequest();
            MenuDto menu1 = MenuService.CreateMenu(menu);
            if (menu1 != null)
                return Ok(menu1);
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult UpdateMenu(MenuDto menu)
        {
            if (menu == null)
                return BadRequest();
            MenuDto menu1 = MenuService.UpdateMenu(menu);
            if (menu1 != null)
                return Ok(menu1);
            return BadRequest();
        }
        [HttpDelete]
        [Route("DeleteMenu/{menuId}")]
        public IHttpActionResult DeleteMenu(int menuId)
        {
            MenuDto e = MenuService.DeleteMenu(menuId);
            if (e == null)
                return BadRequest();
            if (e != null)
                return Ok(e);
            return BadRequest();
        }
    }
}
