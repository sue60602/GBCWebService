using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace GBC_WebService
{
    public class GBCAbateDAO : GBCAbate_Interface
    {
        private const string DELETE_GBCABATE_STMT =
        "delete from GBCAbate where PK_會計年度=@PK_會計年度 and PK_動支編號=@PK_動支編號 and PK_種類=@PK_種類 and PK_次別=@PK_次別 and PK_明細號=@PK_明細號";

        private const string INSERT_GBCABATE_STMT =
        "insert into GBCAbate values(@PK_會計年度, @PK_動支編號, @PK_種類, @PK_次別, @PK_明細號, @PK_沖銷傳票種類, @PK_沖銷傳票主號, @PK_沖銷傳票細號,  @F_金額, @F_編修狀態, @F_編修人員, @F_編修時間, @F_製票號, @F_製票日期, @F_過帳號, @F_過帳日期)";

        public void Delete(GBCAbateVO gBCAbate)
        {
            SqlConnection conn = null;
            SqlCommand com = null;

            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
            conn.Open();
            com = new SqlCommand(DELETE_GBCABATE_STMT, conn);
            com.Parameters.AddWithValue("@PK_會計年度", gBCAbate.PK_會計年度);
            com.Parameters.AddWithValue("@PK_動支編號", gBCAbate.PK_動支編號);
            com.Parameters.AddWithValue("@PK_種類", gBCAbate.PK_種類);
            com.Parameters.AddWithValue("@PK_次別", gBCAbate.PK_次別);
            com.Parameters.AddWithValue("@PK_明細號", gBCAbate.PK_明細號);

            com.CommandType = CommandType.Text;
            com.ExecuteNonQuery();

            conn.Close();
        }

        public void Insert(GBCAbateVO gBCAbate)
        {
            SqlConnection conn = null;
            SqlCommand com = null;

            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
            conn.Open();
            com = new SqlCommand(INSERT_GBCABATE_STMT, conn);
            com.Parameters.AddWithValue("@PK_會計年度", gBCAbate.PK_會計年度);
            com.Parameters.AddWithValue("@PK_動支編號", gBCAbate.PK_動支編號);
            com.Parameters.AddWithValue("@PK_種類", gBCAbate.PK_種類);
            com.Parameters.AddWithValue("@PK_次別", gBCAbate.PK_次別);
            com.Parameters.AddWithValue("@PK_明細號", gBCAbate.PK_明細號);
            com.Parameters.AddWithValue("@PK_沖銷傳票種類", "");
            com.Parameters.AddWithValue("@PK_沖銷傳票主號", "");
            com.Parameters.AddWithValue("@PK_沖銷傳票細號", "");
            com.Parameters.AddWithValue("@F_金額", "");
            com.Parameters.AddWithValue("@F_編修狀態", "");
            com.Parameters.AddWithValue("@F_編修人員", "");
            com.Parameters.AddWithValue("@F_編修時間", "");
            com.Parameters.AddWithValue("@F_製票號", gBCAbate.F_製票號);
            com.Parameters.AddWithValue("@F_製票日期", gBCAbate.F_製票日期);
            com.Parameters.AddWithValue("@F_過帳號", gBCAbate.F_過帳號);
            com.Parameters.AddWithValue("@F_過帳日期", gBCAbate.F_過帳日期);

            com.CommandType = CommandType.Text;
            com.ExecuteNonQuery();

            conn.Close();
        }
    }
}