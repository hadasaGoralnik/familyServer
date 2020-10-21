using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//namespace Ui.Controllers
//{
//    public class HelpController : ApiController
//    {
       

//            //https://localhost:44325/api/Posts
//            public List<Song> GetSong()
//            {
//                return Bl.UserService.login("1");
//            }

//            //https://localhost:44325/api/Posts?id=1
//            public Post getPost(int id)
//            {
//                Post post = Posts.posts.FirstOrDefault(x => x.id == id);
//                return post;
//            }

//            [HttpPost]
//            public IHttpActionResult songPost(Post post)
//            {
//                if (post == null)
//                    return BadRequest();
//                Posts posts1 = new Posts();
//                List<Post> posts = posts1.PostsPost(post);
//                return Ok(posts);
//            }

//            [HttpDelete]
//            public IHttpActionResult delet(int id)
//            {
//                Posts.posts.Remove(Posts.posts.FirstOrDefault(x => x.id == id));
//                return Ok(Posts.posts);
//            }

//        }
//    }


