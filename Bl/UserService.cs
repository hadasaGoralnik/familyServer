using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl
{
     public class UserService
    {
        public static List<UserDto> gets()//מחזיר את כל המשתמשים
        {
            using (familydbEntities db = new familydbEntities())
            {
                List<UserDto> users = new List<UserDto>();
                db.User.ToList().ForEach(x =>
                {
                    users.Add(Convertion.UserConvertion.ConvertToDto(x));
                });
                return users;
            }
        }
        public static UserDto Login(string password,string name)
        {
            using (familydbEntities db = new familydbEntities())
            {
                User find = db.User.FirstOrDefault(x=>x.Password==password&x.FirstName==name);
                if (find == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(find);
            }
        }
   
        public static UserDto put(string password,UserDto user)
        {
            using (familydbEntities db = new familydbEntities())
            {
                User find = new User();
              find=  db.User.ToList().FirstOrDefault(x => x.Password== password);
                if (find == null)
                    return null;
                //. עדכון נתונים כותבים רק את מה שרוצים לתת לשנות
                find.LastName = user.LastName;
                db.SaveChanges();
                return Convertion.UserConvertion.ConvertToDto(find);
            }
        }
        public static UserDto post(UserDto user)
        {
            using (familydbEntities db = new familydbEntities())
            {
                User post = new User();
                post = db.User.Add(Convertion.UserConvertion.ConvertToUser(user));
                db.SaveChanges();
                if (post == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(post);
            }
        }


    }
}
