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
    
    public partial class tsbEstimateOverAgainst_Log
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
        public int tsbEstimateNo { get; set; }
        public int tsbApplyNo { get; set; }
        public int tsbApplySeq { get; set; }
        public int tsbDecideNo { get; set; }
        public short tsbDecideSeq { get; set; }
        public string tsbEstimateType { get; set; }
        public Nullable<short> tsbBgtYear { get; set; }
        public Nullable<short> tsbBgtMonth { get; set; }
        public string tsbPayeeNo { get; set; }
        public string tsbPayeeName { get; set; }
        public string tsbPlanCode { get; set; }
        public Nullable<short> tsbOutlayYear { get; set; }
        public string tsbOutlayCode { get; set; }
        public string tsbBgtSourceCode { get; set; }
        public string tsbAccKind { get; set; }
        public string tsbBizCode { get; set; }
        public string tsbBgtDepCode { get; set; }
        public Nullable<decimal> tsbEstiOverAgainstMoney { get; set; }
        public string tsbPassFlag { get; set; }
        public Nullable<System.DateTime> tsbPassDTime { get; set; }
        public string tsbPassUser { get; set; }
        public Nullable<System.DateTime> tsbEstiOverAgainstDate { get; set; }
        public Nullable<System.DateTime> tsbCreateDTime { get; set; }
        public string tsbCreateUser { get; set; }
        public Nullable<System.DateTime> tsbModifyDTime { get; set; }
        public string tsbModifyUser { get; set; }
        public Nullable<short> PK_Year { get; set; }
        public string F_ExchNo { get; set; }
        public string PK_MainNo { get; set; }
        public Nullable<short> PK_DetailNo { get; set; }
        public string tran_F_MarkCode { get; set; }
        public Nullable<System.DateTime> tran_F_MarkDate { get; set; }
        public string tran_F_PassCode { get; set; }
        public Nullable<System.DateTime> tran_F_PassDate { get; set; }
    }
}
