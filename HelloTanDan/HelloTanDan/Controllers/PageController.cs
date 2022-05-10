using DataBaseIO1;
using DBProvider1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloTanDan.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            DBIO1 db = new DBIO1();
            SACH s = db.GetOb_Book("S01");
            return View(s);
        }
        public ActionResult Index2()
        {
            DBIO1 db = new DBIO1();
            List<NHANVIEN> list = db.GetListOb_User();
            return View(list);
        }
        [HttpPost]
        public JsonResult AddUser(FormCollection data)
        {
            string MaNV = data["MANV"];
            string HoTen = data["HOTEN"];
            string SDT = data["SDT"];
            string Pass = data["PASSNV"];
            string DiaChi = data["DIACHI"];
            string Quyen = data["QUYEN"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(MaNV) || 
                String.IsNullOrEmpty(HoTen) || 
                String.IsNullOrEmpty(SDT) || 
                String.IsNullOrEmpty(Pass)||
                String.IsNullOrEmpty(DiaChi)|| 
                String.IsNullOrEmpty(Quyen))
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
                NHANVIEN u = new NHANVIEN
                {
                    IDNV = Guid.NewGuid().ToString("N").Substring(0,10),
                    MANV = MaNV,
                    HOTEN = HoTen,
                    SDT = SDT,
                    PASSNV = Pass,
                    DIACHI = DiaChi,
                    QUYEN = Quyen
                };
                db.Add_GUI(u);
                db.Save();
                js.Data = new
                {
                    status = "OK"
                };
            }
                return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditUser(FormCollection data)
        {
            string Id = data["ID"];
            string MaNV = data["MANV"];
            string HoTen = data["HOTEN"];
            string SDT = data["SDT"];
            string Pass = data["PASSNV"];
            string DiaChi = data["DIACHI"];
            string Quyen = data["QUYEN"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(Id) ||
                String.IsNullOrEmpty(MaNV) ||
                String.IsNullOrEmpty(HoTen) ||
                String.IsNullOrEmpty(SDT) ||
                String.IsNullOrEmpty(Pass) ||
                String.IsNullOrEmpty(DiaChi) ||
                String.IsNullOrEmpty(Quyen))
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
                NHANVIEN u = db.GetOb_User(Id);
                if (u == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    u.MANV = MaNV;
                    u.HOTEN = HoTen;
                    u.SDT = SDT;
                    u.PASSNV = Pass;
                    u.DIACHI = DiaChi;
                    u.QUYEN = Quyen;
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(FormCollection data)
        {
            string id = data["ID"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(id))
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
                NHANVIEN u = db.GetOb_User(id);
                if(u == null)
                {
                    js.Data = new
                    {
                        status = "ERORR",
                        message = "Dữ liệu không tồn tại !"
                    };
                }
                else
                {
                    db.Delete_GUI(u);
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