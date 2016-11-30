using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Models.ShopUserModelView;

namespace WebShop.Services
{
    public interface IRepository
    {
         string test();
         List<UserForViewList> GetShoUserList();
         Task<IdentityResult> CreateUser(ShopUserCreateViewModel user);
    }
}
