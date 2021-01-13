using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bl
{
    public class MenuService
    {
        public static List<MenuDto> GetMenusByEventId(int eventId)
        {
            using (familydbEntities1 db = new familydbEntities1())
            {
                List<Menu> find = new List<Menu>();
                find = db.Menu.Include("User").Where(x => x.EventId == eventId).ToList();
                if (find == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDtoList(find).ToList();
            }
        }
        public static MenuDto GetMenuByMenuId(int menuId)
        {
            using (familydbEntities1 db = new familydbEntities1())
            {
                Menu find = new Menu();
                find = db.Menu.Include("User").FirstOrDefault(x => x.Id == menuId);
                if (find == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDto(find);
            }
        }
        public static MenuDto CreateMenu(MenuDto menu)
        {

            using (familydbEntities1 db = new familydbEntities1())
            {
                Menu m = new Menu();
                m = db.Menu.Add(Convertion.MenuConvertion.ConvertToMenu(menu));
                db.SaveChanges();
                if (m == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDto(m);
            }
        }
    }
}
