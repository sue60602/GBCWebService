//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GBC_WebService.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tsbReceipt_Log
    {
        public int LogNo { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string LogMod { get; set; }
        public string LogModUser { get; set; }
        public Nullable<System.DateTime> LogModDate { get; set; }
        public string LogDataUser { get; set; }
        public Nullable<System.DateTime> LogDataDate { get; set; }
        public Nullable<int> LogMainNo { get; set; }
        public short tsbYear { get; set; }
        public int tsbApplyNo { get; set; }
        public int tsbApplySeq { get; set; }
        public int tsbDecideNo { get; set; }
        public short tsbDecideSeq { get; set; }
        public short tsbPrePayYear { get; set; }
        public int tsbPrePayNo { get; set; }
        public short tsbPayYear { get; set; }
        public int tsbPayNo { get; set; }
        public short tsbReceiveSeq { get; set; }
        public Nullable<decimal> tsbReceiveMoney { get; set; }
        public Nullable<System.DateTime> tsbCreateDTime { get; set; }
        public string tsbCreateUser { get; set; }
        public Nullable<System.DateTime> tsbModifyDTime { get; set; }
        public string tsbModifyUser { get; set; }
        public Nullable<System.DateTime> tsbReceiveDate { get; set; }
        public Nullable<int> FK_VisaNo { get; set; }
        public Nullable<int> FK_DetailNo { get; set; }
        public string tsbExchNo { get; set; }
        public Nullable<System.DateTime> tsbExchMakeDate { get; set; }
        public Nullable<System.DateTime> tsbExchPassDate { get; set; }
    }
}
