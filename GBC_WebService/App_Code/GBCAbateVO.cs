using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GBC_WebService
{
    public class GBCAbateVO
    {
        public string PK_會計年度 {get; set;}
        public string PK_動支編號 { get; set; }
        public string PK_種類 { get; set; }
        public string PK_次別 { get; set; }
        public string PK_明細號 { get; set; }
        public string PK_沖銷傳票種類 { get; set; }
        public string PK_沖銷傳票主號 { get; set; }
        public string PK_沖銷傳票細號 { get; set; }
        public string F_金額 { get; set; }
        public string F_編修狀態 { get; set; }
        public string F_編修人員 { get; set; }
        public string F_編修時間 { get; set; }
        public string F_製票號 { get; set; }
        public string F_製票日期 { get; set; }
        public string F_過帳號 { get; set; }
        public string F_過帳日期 { get; set; }


    }
}