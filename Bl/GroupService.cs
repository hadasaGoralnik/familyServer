﻿using Dal;
using Dto;
using Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class GroupService
    {
        public static List<GroupsDto> Get(int userId)
        {
            using (familydbEntities1 db = new familydbEntities1())
            {
               // Groups find = new Groups();
                var groupIds = (from groups in db.Groups
                            where groups.Users.Any(c => c.Id == userId)
                            select groups.Id).ToList();
                var find = db.Groups.Include("User").Include("Events")
                    .Where(x =>groupIds.Contains(x.Id)).ToList();
                if (find == null)
                    return null;
                return Convertion.GroupsConvertion.ConvertToDtoList(find);
            }
        }
        //public static GroupsDto Sighin(GroupsDto group)
        //{
        //    using (familydbEntities1 db = new familydbEntities1())
        //    {
        //        Group group1 = db.Groups.Add(Convertion.GroupsConvertion.ConvertToGroups(group));
        //        db.SaveChanges();
        //        if (group1 == null)
        //            return null;
        //        return Convertion.GroupsConvertion.ConvertToDto(group1);
        //    }
        //}


        public static GroupsDto AddGroup(AddGroupRequest request)
        {
            using (familydbEntities1 db = new familydbEntities1())
            {
            
                Group group = db.Groups.Add(Convertion.GroupsConvertion.ConvertAddGroupRequestToUser(request));
                db.SaveChanges();
                if (group == null)
                    return null;
                User user = db.Users.FirstOrDefault(x => x.Id == request.ManagerId);
                group.Users.Add(user);
                db.SaveChanges();
                return Convertion.GroupsConvertion.ConvertToDto(group);
            }
        }
    }

}
