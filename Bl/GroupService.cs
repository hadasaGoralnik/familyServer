using Dal;
using Dto;
using Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bl
{
    public class GroupService
    {
        public static List<GroupsDto> Get(int userId)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                // Groups find = new Groups();
                var groupIds = (from groups in db.Groups
                                where groups.User.Any(c => c.Id == userId)
                                select groups.Id).ToList();
                var find = db.Groups.Include("User").Include("Events")
                    .Where(x => groupIds.Contains(x.Id)).ToList();
                if (find == null)
                    return null;
                return Convertion.GroupsConvertion.ConvertToDtoList(find);
            }
        }


        public static GroupsDto AddGroup(AddGroupRequest request)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                Groups group = db.Groups.Add(Convertion.GroupsConvertion.ConvertAddGroupRequestToUser(request));
                User user = db.User.FirstOrDefault(u => u.Id == request.UserId);
                group.User.Add(user);
                db.SaveChanges();
                if (group == null)
                    return null;
                db.SaveChanges();
                return Convertion.GroupsConvertion.ConvertToDto(group);
            }
        }

        
        public static GroupsDto DeleteGroup(DeleteGroupRequest request)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                var group = db.Groups.Include(a => a.User).SingleOrDefault(a => a.Id == request.GroupId);

                if (group != null)
                {
                    foreach (var user in group.User
                        .Where(u => u.Groups.Contains(group)).ToList())
                    {
                        group.User.Remove(user);
                    }
                    db.Groups.Remove(group);
                    db.SaveChanges();
                }

                if (group == null)
                    return null;
                return Convertion.GroupsConvertion.ConvertToDto(group);
            }
        }
        public static GroupsDto DeleteUserFromGroup(DeleteUserFromGroupRequest request)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                var group = db.Groups.Include(a => a.User).SingleOrDefault(a => a.Id == request.GroupId);

                if (group != null)
                {
                    var user = group.User.FirstOrDefault(u => u.Id == request.UserId);
                    if (user != null)
                    {
                        group.User.Remove(user);
                        if (group.User.Count == 0)
                        {
                            db.Groups.Remove(group);
                            group = null;
                        }

                        db.SaveChanges();
                    }
                    if (group != null)
                    {
                        return Convertion.GroupsConvertion.ConvertToDto(group);
                    }
                }
                    return null;
            }

        }
        public static List<UserDto> GetUsers(int groupId)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                List<User> users = db.Groups.FirstOrDefault(grp => grp.Id == groupId).User.ToList();
                if (users == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDtoList(users);
            }
        }
        public static UserDto AddUserToGroup(AddUeserToGroupRequest request)
        {
            using (familydbEntities8 db = new familydbEntities8())
            {
                var group = db.Groups.Include(a => a.User).SingleOrDefault(a => a.Id == request.GroupId);
                var user = db.User.FirstOrDefault(u => u.Mail == request.Mail);
                if (user == null)
                {
                    user = db.User.Add(Convertion.GroupsConvertion.ConvertAddUeserToGroupToUser(request));
                    db.SaveChanges();
                    if (user == null)
                        return null;
                }   
                if(group.User.FirstOrDefault(u1 => u1.Mail == request.Mail )== null)
                { group.User.Add(user);
                db.SaveChanges();
                EmailSender.send(request.Mail, group.Name,user.Password,user.UserName,request.UserSender);
                }
                
                
                return Convertion.UserConvertion.ConvertToDto(user);

            }
        }
    }

}
