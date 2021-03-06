﻿using Bl.Convertion;
using Dal;
using Dto;
using Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Dal.Groups;

namespace Bl.Convertion
{
    public class GroupsConvertion
    {
        public static GroupsDto ConvertToDto(Group groups)
        {
            GroupsDto newgroups = new GroupsDto();
            newgroups.Id = groups.Id;
            newgroups.Name = groups.Name;
            newgroups.Image = groups.Image;
            newgroups.Events = EventsConvertion.ConvertToDtoList(groups.Events.ToList());
            return newgroups;
        }
        public static GroupsDto ConvertToSingleDto(Group groups)
        {
            GroupsDto newgroups = new GroupsDto();
            newgroups.Id = groups.Id;
            newgroups.Name = groups.Name;      
            return newgroups;
        }
    public static Group ConvertToGroups(GroupsDto groups)
        {
            Group newgroups = new Group();
            newgroups.Id = groups.Id;
            newgroups.Name = groups.Name;
            newgroups.Image = groups.Image;
            newgroups.Events = EventsConvertion.convertToListEvent(groups.Events);
            return newgroups;
        }
        public static Group ConvertAddGroupRequestToUser(AddGroupRequest request)
        {
            Group newgroups = new Group();
            newgroups.Name = request.Name;
            newgroups.Image = request.Image;
            return newgroups;
        }
     
        public static List<GroupsDto> ConvertToDtoList(List<Dal.Groups> g)
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
        public static User ConvertAddUeserToGroupToUser(AddUeserToGroupRequest request)
        {
            User newPreson = new User(); 
            newPreson.LastName = request.LastName;
            newPreson.FirstName = request.FirstName;
            newPreson.IsMale = request.IsMale;
            newPreson.Mail = request.Mail;
            newPreson.Password = request.Password;
            newPreson.UserName = request.UserName;
            return newPreson;
        }
    }
}
