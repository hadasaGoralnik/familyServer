using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bl.Convertion
{
    public class MenuConvertion
    {
        public static MenuDto ConvertToDto(Menu menu)
        {
            MenuDto newMenu = new MenuDto();
            newMenu.Id = menu.Id;
            newMenu.VolunteerId = menu.VolunteerId;
            newMenu.Name = menu.Name;
            newMenu.Quantity = menu.Quantity;
            newMenu.Cost = menu.Cost;
            newMenu.EventId = menu.EventId;
            newMenu.MenuOrderNumber = menu.MenuOrderNumber;
            return newMenu;
        }
        public static Menu ConvertToMenu(MenuDto menu)
        {
            Menu newMenu = new Menu();
            newMenu.Id = menu.Id;
            newMenu.VolunteerId = menu.VolunteerId;
            newMenu.Name = menu.Name;
            newMenu.Quantity = menu.Quantity;
            newMenu.Cost = menu.Cost;
            newMenu.EventId = menu.EventId;
            newMenu.MenuOrderNumber = menu.MenuOrderNumber;
            return newMenu;
        }
        public static List<MenuDto> ConvertToDtoList(List<Menu> m)
        {
            List<MenuDto> Menu = new List<MenuDto>();
            m.ForEach(x =>
            {
                Menu.Add(ConvertToDto(x));
            });
            return Menu;
        }
        public static List<Menu> convertToListMenu(List<MenuDto> m)
        {
            List<Menu> Menu = new List<Menu>();
            m.ForEach(x =>
            {
                Menu.Add(ConvertToMenu(x));
            });
            return Menu;
        }
    }
}


