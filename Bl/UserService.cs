using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
using Dto.Requests;
using System.Data.Entity;

namespace Bl
{
    public class UserService
    {
        public static UserDto Login(LoginRequest request)
        {
            using (familydbEntities4 db = new familydbEntities4())
            {
                User find = db.User.FirstOrDefault(x => x.Password == request.Password & x.UserName == request.UserName);
                if (find == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(find);
            }
        }

        public static UserDto SignUp(UserRequest request)
        {
            using (familydbEntities4 db = new familydbEntities4())
            {
                User user = new User();
                User find = db.User.ToList().FirstOrDefault(u => u.Password == request.Password && u.UserName == request.UserName);
                if (find == null)
                {
                    user = db.User.Add(Convertion.UserConvertion.ConvertUserRequestToUser(request));
                    db.SaveChanges();
                    if (user == null)
                        return null;
                }
                else
                {
                    return null;
                }
                return Convertion.UserConvertion.ConvertToDto(user);
            }
        }
        public static UserDto UpdateUser(UpdateUserRequest request)
        {
            using (familydbEntities4 db = new familydbEntities4())
            {
                User user = new User();
                User find = db.User.ToList().FirstOrDefault(u => u.Id == request.Id);
                if (find != null)
                {
                    user = Convertion.UserConvertion.ConvertUpdateUserRequestToUser(request);
                    db.User.AddOrUpdate(user);
                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
                return Convertion.UserConvertion.ConvertToDto(user);
            }
        }

        public static UserDto Unsubscribe(UnsuscribeRequest request)
        {
            using (familydbEntities4 db = new familydbEntities4())
            {
                var usr = db.User.Include(a => a.Groups).SingleOrDefault(a => a.Id == request.UserId);

                if (usr != null)
                {
                    foreach (var grp in usr.Groups
                        .Where(u => u.User.Contains(usr)).ToList())
                    {
                        usr.Groups.Remove(grp);
                        db.SaveChanges();
                    }
                   
                    db.User.Remove(usr);
                    db.SaveChanges();
                }

                if (usr == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(usr);

            }
        }
    }

}

