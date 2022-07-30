using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace QuanLyNhanSu.Models
{
    public class NhanSu
    {
        
        [Display(Name ="MaNV")]
        public int MANV { get; set; }
        [Display(Name = "TEN")]
        public string HOTEN { get; set; }
        [Display(Name = "DIACHI")]
        public string DIACHI { get; set; }
        [Display(Name = "NGAYSINH")]
        public string NGAYSINH { get; set; }
        [Display(Name = "GIOITINH")]
        public string GIOITINH { get; set; }
        [Display(Name = "HESOLUONG")]
        public int HESOLUONG { get; set; }
        [Display(Name = "TRINHDO")]
        public string TRINHDO { get; set; }

    }
    class ListNhanSu
        {
        DataConnect dbcon;
        public ListNhanSu()
        {
            dbcon = new DataConnect();
        }
        public List<NhanSu>getdsns(string MANV)
        {
            string url;
            if (string.IsNullOrEmpty(MANV))
            {
                url = "SELECT * FROM NhanVien";
            }
            else
            {

                url = "SELECT * FROM NhanVien WHERE MANV=" + MANV;
            }
            List<NhanSu> dsnhanvien = new List<NhanSu>();
            DataTable dt = new DataTable();
            SqlConnection conn = dbcon.getConnect();
            SqlDataAdapter da = new SqlDataAdapter(url, conn);
            conn.Open();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            NhanSu temp;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                temp = new NhanSu();
                temp.MANV = Convert.ToInt32(dt.Rows[i]["MaNV"].ToString());
                temp.HOTEN = dt.Rows[i]["HOTEN"].ToString();
                temp.DIACHI = dt.Rows[i]["DIACHI"].ToString();
                temp.NGAYSINH = dt.Rows[i]["NGAYSINH"].ToString();
                temp.GIOITINH = dt.Rows[i]["GIOITINH"].ToString();
                temp.HESOLUONG = Convert.ToInt32(dt.Rows[i]["HESOLUONG"].ToString());
                temp.TRINHDO = dt.Rows[i]["TRINHDO"].ToString();
                dsnhanvien.Add(temp);
            }
            return dsnhanvien;
        }
        public void InsertNS(NhanSu ns)
        {
            string url = "INSERT INTO NhanVien VALUES('"+ns.MANV+"','"+ns.HOTEN+"','"+ns.DIACHI+"','"+ns.NGAYSINH+"','"+ns.GIOITINH+"','"+ns.HESOLUONG+"','"+ns.TRINHDO+"')";
            SqlConnection conn = dbcon.getConnect();
            SqlCommand cmd = new SqlCommand(url, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        public void EditNS(NhanSu ns)
        {
           // Update SINHVIEN SET TENSV = '" + sv.TENSV + "', LOP = '" + sv.Lop + "', DIEM = '" + sv.Diem + "', DIACHI = '" + sv.DiaChi + "' where MASV = "+sv.MASV
            string url 
         = "Update NhanVien SET HOTEN='" + ns.HOTEN + "',DIACHI='" + ns.DIACHI + "',NGAYSINH='" + ns.NGAYSINH + "',HESOLUONG='" + ns.HESOLUONG + "',TRINHDO='" + ns.TRINHDO + "' where MANV="+ns.MANV;
            SqlConnection conn = dbcon.getConnect();
            SqlCommand cmd = new SqlCommand(url, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        public void DeleteNS(NhanSu ns)
        {
            string url = "DELETE FROM NhanVien where MANV=" + ns.MANV;
            SqlConnection conn = dbcon.getConnect();
            SqlCommand cmd = new SqlCommand(url, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        }
}