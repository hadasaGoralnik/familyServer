﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class UserConvertion
    {
        public static UserDto ConvertToDto(User User)
        {
            UserDto newPreson = new UserDto();
            newPreson.Id = User.Id;
            newPreson.Birthday = User.Birthday;
            newPreson.MarryDate = User.MarryDate;
            newPreson.LastName = User.LastName;
            newPreson.Address = User.Address;
            newPreson.ChatMessages = ChatMessagesConvertor.ConvertToDtoList(User.ChatMessages.ToList());
            newPreson.Events = EventsConvertion.ConvertToDtoList(User.Events.ToList());
            newPreson.FirstName = User.FirstName;
            newPreson.Groups = GroupsConvertion.ConvertToDtoList(User.Groups.ToList());
            newPreson.Image = User.Image;
            newPreson.IsEnable = User.IsEnable;
            newPreson.IsMale = User.IsMale;
            newPreson.Mail = User.Mail;
            newPreson.Menu = MenuConvertion.ConvertToDtoList(User.Menus.ToList());
            newPreson.Message = MessageConvertion.ConvertToDtoList(User.Messages.ToList());
            newPreson.Password = User.Password;
            newPreson.UserName = User.UserName;
            return newPreson;
           
        }
        public static List<UserDto> ConvertToDtoList(List<User> u)
        {
            List<UserDto> newUser = new List<UserDto>();
            u.ForEach(x =>
            {
                newUser.Add(ConvertToDto(x));
            });
            return newUser;
        }
        public static List<User> convertToListUser(List<UserDto> u)
        {
            List<User> newUser = new List<User>();
            u.ForEach(x =>
            {
                newUser.Add(ConvertToUser(x));
            });
            return newUser;
        }
        public static User ConvertToUser(UserDto User)
        {
            User newPreson = new User();
            newPreson.Id = User.Id;
            newPreson.Birthday = Convert.ToDateTime(User.Birthday);
            newPreson.MarryDate = User.MarryDate;
            newPreson.LastName = User.LastName;
            newPreson.Address = User.Address;
            newPreson.ChatMessages = ChatMessagesConvertor.convertToListChatMessages(User.ChatMessages);
            newPreson.Events = EventsConvertion.convertToListEvent(User.Events);
            newPreson.FirstName = User.FirstName;
            newPreson.Groups = GroupsConvertion.convertToListGroups(User.Groups);
            newPreson.Image = User.Image;
            newPreson.IsEnable = User.IsEnable;
            newPreson.IsMale = User.IsMale;
            newPreson.Mail = User.Mail;
            newPreson.Menus = MenuConvertion.convertToListMenu(User.Menu);
            newPreson.Messages = MessageConvertion.convertToListMessage(User.Message);
            newPreson.Password = User.Password;
            newPreson.UserName = User.UserName;
            return newPreson;
        }
    }
}