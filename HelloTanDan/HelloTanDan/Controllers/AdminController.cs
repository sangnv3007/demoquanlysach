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
    public class AdminController : Controller
    {

        // GET: Admin
        DBIO1 db = new DBIO1();
        public ActionResult AuthorManagement()
        {
            Check();
            List<TACGIA> list = db.GetListOb_AuThor();
            return View(list);
        }
        public ActionResult BookManagement()
        {
            Check();
            dynamic mymodel = new ExpandoObject();
            mymodel.getAllSach = db.GetListOb_Book();
            mymodel.getCategory = db.GetListOb_Category();
            mymodel.getTacGia = db.GetListOb_AuThor();
            return View(mymodel);
        }
        public ActionResult CategoryManagement()
        {
            Check();
            List<THELOAI> list = db.GetListOb_Category();
            return View(list);
        }
        //Kiểm tra Session
        public void Check()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Home/Login");
            }
            else
            {
                NHANVIEN user = (NHANVIEN)Session["user"];
                ViewBag.FullName = user.HOTEN;
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return Redirect("~/");
        }
        //***Thêm sửa xóa thể loại***
        [HttpPost]
        public JsonResult AddCategory(FormCollection data)
        {
            string MATL = data["MATL"];
            string TENTL = data["TENTL"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(MATL) ||
                String.IsNullOrEmpty(TENTL))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                THELOAI t = new THELOAI
                {
                    MaTL = MATL,
                    TenTL = TENTL,
                };
                db.Add_GUI(t);
                db.Save();
                js.Data = new
                {
                    status = "OK"
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DelCategory(FormCollection data)
        {
            string MaTL = data["MATL"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(MaTL))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                THELOAI c = db.GetOb_Category(MaTL);
                if (c == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    db.Delete_GUI(c);
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditCategory(FormCollection data)
        {
            string Id = data["MATL"];
            string TENTL = data["TENTL"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TENTL))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                THELOAI c = db.GetOb_Category(Id);
                if (c == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    c.TenTL = TENTL;
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        //***Thêm sửa xóa sách***
        [HttpPost]
        public JsonResult AddBook(FormCollection data)
        {         
            string TENS = data["TENS"];
            string MATG = data["MATG"];
            string MATL= data["MATL"];
            string NXB = data["NXB"];
            string GIA = data["GIA"];
            string GIAKM = data["GIAKM"];
            string LINKIMAGE = data["LINKIMAGE"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TENS) ||
                String.IsNullOrEmpty(MATG) ||
                String.IsNullOrEmpty(MATL) ||
                String.IsNullOrEmpty(NXB) ||
                String.IsNullOrEmpty(GIA) ||
                String.IsNullOrEmpty(GIAKM) ||
                String.IsNullOrEmpty(LINKIMAGE))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"               
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                SACH b = new SACH
                {
                    MaS = Guid.NewGuid().ToString("N").Substring(0, 10),
                    TenS = TENS,
                    MaTG = MATG,
                    MaTL = MATL,
                    NXB = NXB,
                    Gia = Convert.ToDouble(GIA),
                    GIAKM = Convert.ToDouble(GIAKM),
                    ANH = LINKIMAGE
                };
                db.Add_GUI(b);
                db.Save();
                js.Data = new
                {
                    status = "OK",
                    strMAS = b.MaS
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditBook(FormCollection data)
        {
            string MAS = data["MAS"];
            string TENS = data["TENS"];
            string MATG = data["MATG"];
            string MATL = data["MATL"];
            string NXB = data["NXB"];
            string GIA = data["GIA"];
            string GIAKM = data["GIAKM"];
            string LINKIMAGE = data["LINKIMAGE"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TENS) ||
                String.IsNullOrEmpty(TENS) ||
                String.IsNullOrEmpty(MATG) ||
                String.IsNullOrEmpty(MATL) ||
                String.IsNullOrEmpty(NXB) ||
                String.IsNullOrEmpty(GIA) ||
                String.IsNullOrEmpty(GIAKM) ||
                String.IsNullOrEmpty(LINKIMAGE))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                SACH b = db.GetOb_Book(MAS);
                if (b == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    b.TenS = TENS;
                    b.MaTG = MATG;
                    b.MaTL = MATL;
                    b.NXB = NXB;
                    b.Gia = Convert.ToDouble(GIA);
                    b.GIAKM = Convert.ToDouble(GIAKM);
                    b.ANH = LINKIMAGE;
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DelBooks(FormCollection data)
        {
            string MAS = data["MAS"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(MAS))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Không thế bỏ trống dữ liệu"
                };

            }
            else
            {
                DBIO1 db = new DBIO1();
                SACH b = db.GetOb_Book(MAS);
                if (b == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    db.Delete_GUI(b);
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}