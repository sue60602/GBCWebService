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
    
    public partial class sysBaseUser_Log
    {
        public int LogNo { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string LogMod { get; set; }
        public string LogModUser { get; set; }
        public Nullable<System.DateTime> LogModDate { get; set; }
        public string LogDataUser { get; set; }
        public Nullable<System.DateTime> LogDataDate { get; set; }
        public Nullable<int> LogMainNo { get; set; }
        public short PK_usrNo { get; set; }
        public string usrAlias { get; set; }
        public string usrPwd { get; set; }
        public string usrName { get; set; }
        public string usrUserID { get; set; }
        public Nullable<short> payKind { get; set; }
        public string payCode { get; set; }
        public string usrTel { get; set; }
        public string usrEmail { get; set; }
        public string usrGroup { get; set; }
        public Nullable<short> usrLevel { get; set; }
        public Nullable<System.DateTime> usrLoginDTime { get; set; }
        public Nullable<System.DateTime> usrLogoutDTime { get; set; }
        public Nullable<short> usrDefYear { get; set; }
        public Nullable<short> usrDefMonth { get; set; }
        public string usrTeamCode { get; set; }
        public string usrPrnPath { get; set; }
        public Nullable<short> usrAgentUsrNo { get; set; }
        public Nullable<System.DateTime> usrAgentSDate { get; set; }
        public Nullable<System.DateTime> usrAgentEDate { get; set; }
        public string usrStateKind { get; set; }
        public Nullable<System.DateTime> CreateDTime { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> ModifyDTime { get; set; }
        public string ModifyUser { get; set; }
        public string depCode { get; set; }
        public string usrLoginIP { get; set; }
        public string ageAgentNo { get; set; }
        public string usrArgPath { get; set; }
        public string usrOnlineFlag { get; set; }
    }
}
