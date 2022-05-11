using DataBaseIO1;
using DBProvider1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
namespace HelloTanDan.Controllers
{
    public class HomeController : Controller
    {
        DBIO1 db = new DBIO1();
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.InfBook = db.GetListOb_Book();
            mymodel.ListCategory = db.GetListOb_Category();
            mymodel.GetHotW = db.GetInfBook_MaTL("HOTW");
            return View(mymodel);
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult CheckLogin(FormCollection collection)
        {
            string user = collection["user"];
            string pass = collection["pass"];
            JsonResult jr = new JsonResult();
            DBIO1 db = new DBIO1();
            NHANVIEN u = db.GetOb_User(user);
            if(u==null)
            {
                jr.Data = new
                {
                    status = "F"
                };
            }
            else
            {
                if(u.PASSNV==pass)
                {
                    Session["user"] = u;
                    Session.Timeout = 5;
                    jr.Data = new
                    {
                        status = "OK"
                    };
                }
                else
                {
                    jr.Data = new
                    {
                        status = "F"
                    };
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}