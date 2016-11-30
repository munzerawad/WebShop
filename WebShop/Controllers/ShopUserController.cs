using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.ShopUserModelView;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class ShopUserController : Controller
    {

        private IRepository _rep;

        public ShopUserController(IRepository rep)
        {
            _rep = rep;
        }


        // GET: ShopUser
        public ActionResult Index()
        {

            return PartialView("_ShopUsersPartialView");
        }


        //Get jeson List Of the User
        public JsonResult ShopUsers()
        {
            List<UserForViewList> usersList = _rep.GetShoUserList();
            return Json(usersList, JsonRequestBehavior.AllowGet);
        }

        //Get
        public ActionResult Create()
        {
            return PartialView("_CreateShopUserPartialView");
        }


        //Post
        [HttpPost]
        public async Task<ActionResult> Create(ShopUserCreateViewModel user)
        {
            if (ModelState.IsValid)
            {
                if(Request.Files!=null)
                {
                    var file = Request.Files[0];
                }
                
               var Result= await _rep.CreateUser(user);
                if(Result.Succeeded)
                {
                    return Content("Done");
                }
            }
                return null;
        }
    }
}