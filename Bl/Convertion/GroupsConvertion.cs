using Bl.Convertion;
using Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bl.Convertion
{
    public class GroupsConvertion
    {
        public static GroupsDto ConvertToDto(Groups groups)
        {
            GroupsDto newgroups = new GroupsDto();
            newgroups.Id = groups.Id;
            newgroups.ManagerId = groups.ManagerId;
            newgroups.Name = groups.Name;
            newgroups.User1 = UserConvertion.ConvertToDtoList(groups.User1.ToList());
            newgroups.Events = EventsConvertion.ConvertToDtoList(groups.Events.ToList());
            return newgroups;
        }
        public static Groups ConvertToGroups(GroupsDto groups)
        {
            Groups newgroups = new Groups();
            newgroups.Id = groups.Id;
            newgroups.ManagerId = groups.ManagerId;
            newgroups.Name = groups.Name;
            newgroups.User1 = UserConvertion.convertToListUser(groups.User1);
            newgroups.Events = EventsConvertion.convertToListEvent(groups.Events);
            return newgroups;
        }
        public static List<GroupsDto> ConvertToDtoList(List<Groups> g)
        {
            List<GroupsDto> Groups = new List<GroupsDto>();
            g.ForEach(x =>
            {
                Groups.Add(ConvertToDto(x));
            });
            return Groups;
        }
        public static List<Groups> convertToListGroups(List<GroupsDto> g)
        {
            List<Groups> Groups = new List<Groups>();
            g.ForEach(x =>
            {
                Groups.Add(ConvertToGroups(x));
            });
            return Groups;
        }
    }
}
