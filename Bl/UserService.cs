using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
using Dto.Requests;

namespace Bl
{
     public class UserService
    {
        //public static List<UserDto> gets()//מחזיר את כל המשתמשים
        //{
        //    using (familydbEntities1 db = new familydbEntities1())
        //    {
        //        List<UserDto> users = new List<UserDto>();
        //        db.Users.ToList().ForEach(x =>
        //        {
        //            users.Add(Convertion.UserConvertion.ConvertToDto(x));
        //        });
        //        return users;
        //    }
        //}
        public static UserDto Login(LoginRequest request)
        {
            using (familydbEntities2 db = new familydbEntities2())
            {
                User find = db.User.FirstOrDefault(x=>x.Password== request .Password& x.UserName== request.UserName);
                if (find == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(find);
            }
        }

        //public static UserDto put(string password,UserDto user)
        //{
        //    using (familydbEntities1 db = new familydbEntities1())
        //    {
        //        User find = new User();
        //      find=  db.Users.ToList().FirstOrDefault(x => x.Password== password);
        //        if (find == null)
        //            return null;
        //        //. עדכון נתונים כותבים רק את מה שרוצים לתת לשנות
        //        find.LastName = user.LastName;
        //        db.SaveChanges();
        //        return Convertion.UserConvertion.ConvertToDto(find);
        //    }
        //}
        //
        public static UserDto SignUp(SignUpRequest request)
        {
            using (familydbEntities2 db = new familydbEntities2())
            {
                User user = new User();
                user = db.User.Add(Convertion.UserConvertion.ConvertSignUpRequestToUser(request));
                db.SaveChanges();
                if (user == null)
                    return null;
                return Convertion.UserConvertion.ConvertToDto(user);
            }
        }


    }
}
