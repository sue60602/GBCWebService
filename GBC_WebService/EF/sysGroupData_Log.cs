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
    
    public partial class sysGroupData_Log
    {
        public int LogNo { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string LogMod { get; set; }
        public string LogModUser { get; set; }
        public Nullable<System.DateTime> LogModDate { get; set; }
        public string LogDataUser { get; set; }
        public Nullable<System.DateTime> LogDataDate { get; set; }
        public Nullable<int> LogMainNo { get; set; }
        public short PK_grpNo { get; set; }
        public string PK_mnuNo { get; set; }
        public string grpdAdd { get; set; }
        public string grpdModify { get; set; }
        public string grpdDel { get; set; }
        public string grpdSeek { get; set; }
        public string grpdPrn { get; set; }
        public string grpdPower1 { get; set; }
        public string grpdPower2 { get; set; }
        public string grpdPower3 { get; set; }
        public string grpdPower4 { get; set; }
        public string grpdMode { get; set; }
        public string Pk_MnuSys { get; set; }
    }
}
