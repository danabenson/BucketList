using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FacebookBucketList.Core;
using FacebookBucketList.Core.Models;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Client;
using FacebookBucketlist.Web.Models;

namespace FacebookBucketlist.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BucketListContext _bucketListContext;

        public HomeController(BucketListContext bucketListContext)
        {
            _bucketListContext = bucketListContext;
        }

        [FacebookAuthorize("email", "user_photos")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Client.GetCurrentUserAsync<MyAppUser>();
                var model = new HomeModel();

                var blUser = GetUser(user);

                model.Name = user.Name;
                model.Bucket = new BucketModel();
                model.Bucket.Name = string.Empty;
                model.Bucket.Items = blUser.Bucket.Items.Select(GetItemModel).ToList();
                
                return View(model);
            }
            return View("Error");
        }

        private ItemModel GetItemModel(BucketItem item)
        {
            var model = new ItemModel();
            model.Id = item.Id;
            model.Text = item.Text;
            return model;
        }

        private User GetUser(MyAppUser fbUser)
        {
            var user = _bucketListContext.Users.Include("Bucket").Include("Bucket.Items").FirstOrDefault(x => x.FacebookId == fbUser.Id);
            if (user == null)
            {
                user = new User();
                user.FacebookId = fbUser.Id;
                user.ProfileImageUrl = fbUser.ProfilePicture.Data.Url;
                user.Bucket = new Bucket();
                user.Bucket.Items = new List<BucketItem>();
                _bucketListContext.Users.Add(user);
                _bucketListContext.SaveChanges();
            }
            return user;
        }

        // This action will handle the redirects from FacebookAuthorizeFilter when 
        // the app doesn't have all the required permissions specified in the FacebookAuthorizeAttribute.
        // The path to this action is defined under appSettings (in Web.config) with the key 'Facebook:AuthorizationRedirectPath'.
        public ActionResult Permissions(FacebookRedirectContext context)
        {
            if (ModelState.IsValid)
            {
                return View(context);
            }
            return View("Error");
        }
    }
}
