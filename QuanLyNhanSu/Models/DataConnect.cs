using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class DataConnect
    {
        string ChuoiConn;
        public DataConnect()
        {
            ChuoiConn = ConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString;
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(ChuoiConn);
        }

    }
}