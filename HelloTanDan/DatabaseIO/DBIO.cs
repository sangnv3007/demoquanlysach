using DBProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO1
{
    public class DBIO
    {
        MyDB mydb = new MyDB();
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
        //Thêm bản ghi vào bảng nhân viên trực tiếp trên giao diện
        public void AddUser_GUI<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        public void DeleteUser_GUI<T>(T obj)
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
