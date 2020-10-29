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
            using (familydbEntities3 db = new familydbEntities3())
            {
                // Groups find = new Groups();
                var groupIds = (from groups in db.Groups
                                where groups.User1.Any(c => c.Id == userId)
                                select groups.Id).ToList();
                var find = db.Groups.Include("User1").Include("Events")
                    .Where(x => groupIds.Contains(x.Id)).ToList();
                if (find == null)
                    return null;
                return Convertion.GroupsConvertion.ConvertToDtoList(find);
            }
        }


        public static GroupsDto AddGroup(AddGroupRequest request)
        {
            using (familydbEntities3 db = new familydbEntities3())
            {

                Groups group = db.Groups.Add(Convertion.GroupsConvertion.ConvertAddGroupRequestToUser(request));
                db.SaveChanges();
                if (group == null)
                    return null;
                User user = db.User.FirstOrDefault(x => x.Id == request.ManagerId);
                group.User1.Add(user);
                db.SaveChanges();
                return Convertion.GroupsConvertion.ConvertToDto(group);
            }
        }

        
        public static GroupsDto DeleteGroup(DeleteGroupRequest request)
        {
            using (familydbEntities3 db = new familydbEntities3())
            {
                var group = db.Groups.Include(a => a.User).SingleOrDefault(a => a.Id == request.GroupId);

                if (group != null)
                {
                    foreach (var user in group.User1
                        .Where(u => u.Groups.Contains(group)).ToList())
                    {
                        group.User1.Remove(user);
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
            using (familydbEntities3 db = new familydbEntities3())
            {
                var group = db.Groups.Include(a => a.User).SingleOrDefault(a => a.Id == request.GroupId);

                if (group != null)
                {
                    var user = group.User1.FirstOrDefault(u => u.Id == request.UserId);
                    if (user != null)
                    {
                        group.User1.Remove(user);
                        if (group.User1.Count == 0)
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
            using (familydbEntities3 db = new familydbEntities3())
            {
                List<User> users = db.Groups.FirstOrDefault(grp => grp.Id == groupId).User1.ToList();
                if (users == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDtoList(users);
            }
        }
    }

}
