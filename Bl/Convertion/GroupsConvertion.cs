﻿using Bl.Convertion;
using Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Dal.Group;

namespace Bl.Convertion
{
    public class GroupsConvertion
    {
        public static GroupsDto ConvertToDto(Group groups)
        {
            GroupsDto newgroups = new GroupsDto();
            newgroups.Id = groups.Id;
            newgroups.ManagerId = groups.ManagerId;
            newgroups.Name = groups.Name;
            newgroups.User1 = UserConvertion.ConvertToDtoList(groups.Users.ToList());
            newgroups.Events = EventsConvertion.ConvertToDtoList(groups.Events.ToList());
            return newgroups;
        }
        public static Group ConvertToGroups(GroupsDto groups)
        {
            Group newgroups = new Group();
            newgroups.Id = groups.Id;
            newgroups.ManagerId = groups.ManagerId;
            newgroups.Name = groups.Name;
            newgroups.Users = UserConvertion.convertToListUser(groups.User1);
            newgroups.Events = EventsConvertion.convertToListEvent(groups.Events);
            return newgroups;
        }
        public static List<GroupsDto> ConvertToDtoList(List<Dal.Group> g)
        {
            List<GroupsDto> Groups = new List<GroupsDto>();
            g.ForEach(x =>
            {
                Groups.Add(ConvertToDto(x));
            });
            return Groups;
        }
        public static List<Group> convertToListGroups(List<GroupsDto> g)
        {
            List<Group> Groups = new List<Group>();
            g.ForEach(x =>
            {
                Groups.Add(ConvertToGroups(x));
            });
            return Groups;
        }
    }
}