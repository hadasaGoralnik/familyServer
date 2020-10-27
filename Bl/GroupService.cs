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
            using (familydbEntities2 db = new familydbEntities2())
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


        public static GroupsDto AddGroup(AddGroupRequest request)
        {
            using (familydbEntities2 db = new familydbEntities2())
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

        public static GroupsDto DeleteGroup(DeleteGroupRequest request)
        {
            using (familydbEntities2 db = new familydbEntities2())
            {
                var group = db.Groups.Include(a => a.Users).SingleOrDefault(a => a.Id == request.GroupId);

                if (group != null)
                {
                    foreach (var user in group.Users
                        .Where(u => u.Groups.Contains(group)).ToList())
                    {
                        group.Users.Remove(user);
                    }
                    db.Groups.Remove(group);
                    db.SaveChanges();
                }
               
                if (group == null)
                    return null;
                return Convertion.GroupsConvertion.ConvertToDto(group);
            }
        }

        public static List<UserDto> GetUsers(int groupId)
        {
            using (familydbEntities2 db = new familydbEntities2())
            {
                List<User> users = db.Groups.FirstOrDefault(grp => grp.Id == groupId).Users.ToList();
                if (users == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDtoList(users);
            }
        }
    }

}
