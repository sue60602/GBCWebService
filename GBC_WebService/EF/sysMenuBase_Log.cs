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
    
    public partial class sysMenuBase_Log
    {
        public int LogNo { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string LogMod { get; set; }
        public string LogModUser { get; set; }
        public Nullable<System.DateTime> LogModDate { get; set; }
        public string LogDataUser { get; set; }
        public Nullable<System.DateTime> LogDataDate { get; set; }
        public Nullable<int> LogMainNo { get; set; }
        public string PK_MnuNo { get; set; }
        public string mnuName { get; set; }
        public string mnuUrl { get; set; }
        public string mnuMode { get; set; }
        public string mnuTarget { get; set; }
        public string mnuHint { get; set; }
        public string mnuHelp { get; set; }
        public string mnuGroup { get; set; }
        public Nullable<short> mnuLevel { get; set; }
        public string PK_MnuSys { get; set; }
        public string mnuAlias { get; set; }
    }
}
