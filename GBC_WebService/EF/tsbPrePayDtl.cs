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
    
    public partial class tsbPrePayDtl
    {
        public short tsbYear { get; set; }
        public int tsbApplyNo { get; set; }
        public int tsbDecideNo { get; set; }
        public short tsbPrePayYear { get; set; }
        public int tsbPrePayNo { get; set; }
        public int tsbApplySeq { get; set; }
        public short tsbDecideSeq { get; set; }
        public string tsbPayeeNo { get; set; }
        public string tsbPayeeName { get; set; }
        public Nullable<short> tsbOutlayYear { get; set; }
        public string tsbOutlayCode { get; set; }
        public string tsbBgtSourceCode { get; set; }
        public string tsbAccKind { get; set; }
        public string tsbBizCode { get; set; }
        public Nullable<decimal> tsbMoney { get; set; }
        public string tsbMemo { get; set; }
        public string tsbPlanCode { get; set; }
        public Nullable<int> FK_VisaNo { get; set; }
        public Nullable<int> FK_DetailNo { get; set; }
        public string tsbExchNo { get; set; }
        public Nullable<System.DateTime> tsbExchMakeDate { get; set; }
        public Nullable<System.DateTime> tsbExchPassDate { get; set; }
        public string tsbBgtDepCode { get; set; }
    
        public virtual tsbPrePay tsbPrePay { get; set; }
    }
}
