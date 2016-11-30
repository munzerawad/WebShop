using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebShop.Models;
using WebShop.Models.Identity;
using WebShop.Models.ShopUserModelView;

namespace WebShop.Services
{
    public class Repository : IRepository
    {

        private AppContext _dbContext;
        private AppUserManager _userManager;

        private AppContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.Current.GetOwinContext().Get<AppContext>();
            }
            set
            {
                _dbContext = value;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        //private AppContext _dp= new AppContext();
        public string test()
        {
           // _dp.Orders.ToList();
            return ("From Repository Test");
        }

        public List<UserForViewList> GetShoUserList()
        {
            IQueryable<UserForViewList> query = DbContext.Users.Select(u => new UserForViewList { FullName = u.FirstName+" "+u.LastName, Email = u.Email });
            List<UserForViewList> shopUsers = query.ToList();
            return shopUsers;
        }

        public async Task<IdentityResult> CreateUser(ShopUserCreateViewModel user)
        {
            var newUser = new ShopUser()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            var result = await UserManager.CreateAsync(newUser,user.Password);
           /* if (result.Succeeded)
            {

                if (model.IsAdmin)
                {

                    var newUser = UserManager.FindByName(model.UserName);
                    var adminRole = await RoleManager.FindByNameAsync("Admin");
                    if (adminRole == null)
                    {
                        adminRole = new AppRole("Admin");
                        await RoleManager.CreateAsync(adminRole);
                    }
                    var roleResult = UserManager.AddToRole(newUser.Id, "Admin");

                }
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            }*/
            return result;
        }

    }
}