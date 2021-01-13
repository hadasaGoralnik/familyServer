﻿using System;
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
            using (familydbEntities8 db = new familydbEntities8())
            {
                List<Menu> find = new List<Menu>();
                find = db.Menu.Include("User").Where(x => x.EventId == eventId).ToList();
                if (find == null)
                    return null;
                return Convertion.MenuConvertion.ConvertToDtoList(find).ToList();
            }
        }
        public static MenuDto CreateMenu(MenuDto menu)
        {

            using (familydbEntities8 db = new familydbEntities8())
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