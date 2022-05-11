using DBProvider1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseIO1
{
    public class DBIO1
    {
        MyDB mydb = new MyDB();
        //Lấy thông tin thể loại theo MaTL
        public THELOAI GetOb_Category(string MATL)
        {
            return mydb.THELOAIs.Where(t => t.MaTL == MATL).FirstOrDefault();
        }
        //Lấy thông sách theo mã sách
        public SACH GetOb_Book(string MaS)
        {
            return mydb.SACHes.Where(t => t.MaS == MaS).FirstOrDefault();
        }
        //Lấy thông tin nhân viên theo IDNV
        public NHANVIEN GetOb_User(string IDNV)
        {
            ////Khong sử dụng Paramaters
            //string SQL = "SELECT * FROM NHANVIEN WHERE IDNV='"+IDNV+ "'";
            //return mydb.Database.SqlQuery<NHANVIEN>(SQL).FirstOrDefault();

            ////Khong sử dụng Paramaters
            //return mydb.Database.SqlQuery<NHANVIEN>("SELECT * FROM NHANVIEN WHERE IDNV = @ID", new SqlParameter("@ID",IDNV)).FirstOrDefault();

            ////Sử dụng iQuery
            return mydb.NHANVIENs.Where(t => t.IDNV == IDNV).FirstOrDefault();
        }
        public List<NHANVIEN> GetListOb_User()
        {
            ////Khong sử dụng Paramaters
            //string SQL = "SELECT * FROM NHANVIEN WHERE IDNV='"+IDNV+ "'";
            //return mydb.Database.SqlQuery<NHANVIEN>(SQL).FirstOrDefault();

            ////Khong sử dụng Paramaters
            //return mydb.Database.SqlQuery<NHANVIEN>("SELECT * FROM NHANVIEN WHERE IDNV = @ID", new SqlParameter("@ID",IDNV)).FirstOrDefault();

            ////Sử dụng iQuery
            return mydb.NHANVIENs.ToList();
        }
        //Lấy danh sách tất cả thể loại sách
        public List<THELOAI> GetListOb_Category()
        {
            return mydb.THELOAIs.ToList();
        }
        //Lấy danh sách tất cả các tác giả
        public List<TACGIA> GetListOb_AuThor()
        {
            return mydb.TACGIAs.ToList();
        }
        //Lấy danh sách tất cả thể loại sách
        public List<SACH> GetListOb_Book()
        {
            return mydb.SACHes.ToList();
        }
        //Lấy thông tin sách dựa trên mã thể loại
        public List<SACH> GetInfBook_MaTL(string MATL)
        {
            return mydb.SACHes.Where(i => i.MaTL== MATL).ToList();
        }
        //Thêm bản ghi vào bảng nhân viên khi reload trang
        public void AddUser(string IDNV, string MANV, string HOTEN, string SDT, string PASSNV, string DIACHI, string QUYEN)
        {
            mydb.Database.ExecuteSqlCommand("INSERT INTO NHANVIEN VALUES(@ID,@M, @H, @S, @P,@D,@Q)",
            new SqlParameter("@ID", IDNV),
            new SqlParameter("@M", MANV),
            new SqlParameter("@H", HOTEN),
            new SqlParameter("@S", SDT),
            new SqlParameter("@P", PASSNV),
            new SqlParameter("@D", DIACHI),
            new SqlParameter("@Q", QUYEN)
            );
        }
        //Thêm bản ghi vào bảng trực tiếp trên giao diện
        public void Add_GUI<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        //Xóa bản ghi trực tiếp trên giao diện
        public void Delete_GUI<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }
        //Lưu mọi thay đổi trong Database Serve
        public void Save()
        {
            mydb.SaveChanges();
        }
    }
}
