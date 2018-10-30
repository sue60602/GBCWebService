using GBC_WebService.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GBC_WebService
{
    public class TsbEstimateDAO
    {
        MOHWFGBCEEntities db = new MOHWFGBCEEntities();

        //用EF方式取資料
        public IQueryable<tsbEstimate> getTsbEstimate(Expression<Func<tsbEstimate, bool>> condition)
        {
            var result = from s1 in db.tsbEstimate select s1;

            return result.Where(condition);
        }

        //回填傳票號碼
        public void UpdateEstimateVouNo(string accYear, string TsbEstimateType, string VouNo , string VouDate)
        {
            int TmpAccYear = short.Parse(accYear);

            System.Globalization.CultureInfo tc = new System.Globalization.CultureInfo("zh-TW"); tc.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            DateTime tmpVouDate = DateTime.Parse(VouDate, tc).Date;


            var getEstimateByTsbEstimateType = (from s1 in db.tsbEstimate select s1)
                .Where(x => x.tsbYear == TmpAccYear && x.tsbEstimateType == TsbEstimateType && x.tsbOutlayYear == TmpAccYear);

            foreach (var getEstimateByTsbEstimateTypeItem in getEstimateByTsbEstimateType)
            {
                getEstimateByTsbEstimateTypeItem.tsbExchNo = VouNo;
                getEstimateByTsbEstimateTypeItem.tsbExchMakeDate = tmpVouDate;
                getEstimateByTsbEstimateTypeItem.tsbExchPassDate = tmpVouDate;
            }

            db.SaveChanges();
        }
    }
}