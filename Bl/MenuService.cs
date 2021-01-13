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
            using (familydbEntities9 db = new familydbEntities9())
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
            using (familydbEntities9 db = new familydbEntities9())
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

            using (familydbEntities9 db = new familydbEntities9())
            {
                Menu m = new Menu();
                m = db.Menu.Add(Convertion.MenuConvertion.ConvertToMenuWithoutIncluse(menu));
                db.SaveChanges();
                if (m == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDto(m);
            }
        }

        public static MenuDto DeleteMenu(int menuId)
        {
            using (familydbEntities9 db = new familydbEntities9())
            {
                Menu m = db.Menu.Where(x => x.Id == menuId).FirstOrDefault();
                MenuDto m1 = Convertion.MenuConvertion.ConvertToDto(m);
                db.Menu.Remove(m);
                db.SaveChanges();
                return m1;
            }
        }

        public static MenuDto UpdateMenu(MenuDto menu)
        {
            using (familydbEntities9 db = new familydbEntities9())
            {
                var menu1 = db.Menu.FirstOrDefault(m => m.Id == menu.Id);
                if(menu1!=null)
                {
                    Menu m = Convertion.MenuConvertion.ConvertToMenuWithoutIncluse(menu);
                    menu1.Cost = m.Cost;
                    menu1.EventId = m.EventId;
                    menu1.Id = m.Id;
                    menu1.MenuOrderNumber = m.MenuOrderNumber;
                    menu1.Name = m.Name;
                    menu1.Quantity = m.Quantity;
                    menu1.VolunteerId = m.VolunteerId;
                    menu1.User = m.User;
                }
                db.SaveChanges();

                return Convertion.MenuConvertion.ConvertToDto(menu1);
            }
        }
    }
}
