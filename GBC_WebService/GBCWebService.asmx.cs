using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using GBC_WebService;
using GBC_WebService.EF;

namespace GBC_WebService
{
    /// <summary>
    ///GBCWebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]

    public class GBCWebService : System.Web.Services.WebService
    {
       
        public void GBC_WebService()
        {

            //如果使用設計的元件，請取消註解下列一行
            //InitializeComponent(); 
        }

        Vw_GBCVisaDetailDAO dao = new Vw_GBCVisaDetailDAO();
        GBCAbateDAO abateDAO = new GBCAbateDAO();

        [WebMethod]
        //JSON集合(導入EF方式)
        public string GetVw_GBCVisaDetailJSON(string acmWordNum)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> vw_gbcVisaDetailWithAbate = null;

            acmWordNum = acmWordNum.Trim(); //去空白
            acmWordNum = acmWordNum.Replace("*", ""); //去掉"*"字號
                                                      //Regex rx = new Regex(@"\*\d{8}-\d{1,2}-\d{1,2}\*"); //輸入規則:*10500001-1-1*
            Regex rx = new Regex(@"\d{8}-\d{1}-\d{1,3}$");  //輸入規則:10500001-1-1
            Match match = rx.Match(acmWordNum);
            List<vw_GBCVisaDetailWithAbate> vw_gbcVisaDetailWithAbateView = new List<vw_GBCVisaDetailWithAbate>();

            string accYear = (DateTime.Now.Year - 1911).ToString();
            string[] strs = acmWordNum.Split('-'); //以"-"區分種類及次號
            string acmWordNumOut = strs[0];
            string acmKind = null;
            switch (strs[1])
            {
                case "1":
                    acmKind = "預付";
                    break;
                case "2":
                    acmKind = "核銷";
                    break;
                case "3":
                    acmKind = "估列";
                    break;
                case "4":
                    acmKind = "估列收回";
                    break;
                case "5":
                    acmKind = "預撥收回";
                    break;
                case "6":
                    acmKind = "核銷收回";
                    break;
                default:
                    acmKind = "無";
                    break;
            }
            string acmNo = strs[2];

            //尋找是否有原動支編號           
            int isOrigNum = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.F_原動支編號 == acmWordNumOut).Count();

            if (int.Parse(acmWordNumOut.Substring(0, 3)) < DateTime.Now.Year - 1911)
            {
                if (isOrigNum > 0)
                {
                    vw_gbcVisaDetailWithAbate = dao.getAllWithAbate(x =>
                        x.PK_會計年度 == accYear &&
                        x.F_原動支編號 == acmWordNumOut &&
                        x.PK_種類 == acmKind &&
                        x.PK_次別 == acmNo
                        );
                }
                else
                {
                    vw_gbcVisaDetailWithAbate = dao.getAllWithAbate(x =>
                        x.PK_會計年度 == accYear &&
                        x.PK_動支編號 == acmWordNumOut &&
                        x.PK_種類 == acmKind &&
                        x.PK_次別 == acmNo
                        );
                }

            }
            else
            {
                vw_gbcVisaDetailWithAbate = dao.getAllWithAbate(x =>
                    x.PK_會計年度 == accYear &&
                    x.PK_動支編號 == acmWordNumOut &&
                    x.PK_種類 == acmKind &&
                    x.PK_次別 == acmNo
                    );
            }

            var view = (vw_gbcVisaDetailWithAbate.Select(x => new { x.基金代碼, x.PK_會計年度, x.PK_動支編號, x.PK_種類, x.PK_次別, x.PK_明細號, x.F_科室代碼, x.F_用途別代碼, x.F_計畫代碼, x.F_動支金額, x.F_製票日, F_是否核定 = x.F_是否核定, x.F_核定金額, x.F_核定日期, x.F_摘要, x.F_受款人, x.F_受款人編號, x.F_原動支編號, x.F_批號, x.實支, x.費用, x.預付轉正, x.沖抵估列 })
                .ToList()
                .Select(s1 => new vw_GBCVisaDetailWithAbate
                {
                    基金代碼 = s1.基金代碼,
                    PK_會計年度 = s1.PK_會計年度,
                    PK_動支編號 = s1.PK_動支編號,
                    PK_種類 = s1.PK_種類,
                    PK_次別 = s1.PK_次別,
                    PK_明細號 = s1.PK_明細號,
                    F_科室代碼 = s1.F_科室代碼,
                    F_用途別代碼 = s1.F_用途別代碼,
                    F_計畫代碼 = s1.F_計畫代碼,
                    F_動支金額 = s1.F_動支金額,
                    F_製票日 = s1.F_製票日,
                    F_是否核定 = s1.F_是否核定,
                    F_核定金額 = s1.F_核定金額,
                    F_核定日期 = s1.F_核定日期,
                    F_摘要 = s1.F_摘要,
                    F_受款人 = s1.F_受款人,
                    F_受款人編號 = s1.F_受款人編號,
                    F_原動支編號 = s1.F_原動支編號,
                    F_批號 = s1.F_批號,
                    實支 = s1.實支,
                    費用 = s1.費用,
                    預付轉正 = s1.預付轉正,
                    沖抵估列 = s1.沖抵估列
                })).ToList();
                        
            if ((view.Count()) == 0)
            {
                return acmWordNum + "..查無此資料可就源，請確認是否已審核";
            }
            if (match.Success)
            {
                foreach (var viewItem in view)
                {
                    viewItem.F_用途別代碼 = (viewItem.F_用途別代碼).Substring(2);

                    if ((viewItem.F_計畫代碼).Length > 2)
                    {
                        viewItem.F_計畫代碼 = (viewItem.F_計畫代碼).Substring(7);
                    }
                    else
                    {
                        viewItem.F_計畫代碼 = viewItem.F_計畫代碼;
                    }

                    vw_gbcVisaDetailWithAbateView.Add(viewItem);

                }

                return JsonConvert.SerializeObject(vw_gbcVisaDetailWithAbateView);
            }
            else
            {
                return JsonConvert.SerializeObject("輸入格式錯誤");
            }
        }

        [WebMethod]
        //回填傳票號碼
        public string FillVouNo(string accYear, string acmWordNum, string accKind, string accCount, string accDetail, string vouNo, string vouDate, string passNo, string passDate)
        {
            GBCAbateVO gbcAbateVO = new GBCAbateVO();
            //List<GBCVisaDetailAbateDetailVO> gbcVisaDetailAbateDetailVOList = new List<GBCVisaDetailAbateDetailVO>();

            gbcAbateVO.PK_會計年度 = accYear;
            gbcAbateVO.PK_動支編號 = acmWordNum;
            gbcAbateVO.PK_種類 = accKind;
            gbcAbateVO.PK_次別 = accCount;
            gbcAbateVO.PK_明細號 = accDetail;
            gbcAbateVO.F_製票號 = vouNo;
            gbcAbateVO.F_製票日期 = vouDate;
            gbcAbateVO.F_過帳號 = passNo;
            gbcAbateVO.F_過帳日期 = passDate;
            gbcAbateVO.F_編修時間 = DateTime.Now;

            if (accKind.Equals("核銷") && vouNo.Substring(0,1) == "4")
            {
                gbcAbateVO.PK_沖銷傳票種類 = "8";
            }
            else
            {
                gbcAbateVO.PK_沖銷傳票種類 = "";
            }

            abateDAO.Delete(gbcAbateVO);
            abateDAO.Insert(gbcAbateVO);


            return "xxx";
        }

        //=================手動選取資料=================

        [WebMethod]
        //取年度
        public List<string> GetYear()
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => 1 == 1);
            var yearList = (from s1 in getAllWithAbate select s1.PK_會計年度).Distinct().OrderByDescending(o => o).ToList();

            return yearList;
        }

        [WebMethod]
        //取動支編號
        public List<string> GetAcmWordNum(string accYear)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear);
            var acmNoList = (from s1 in getAllWithAbate select s1.PK_動支編號).Distinct().OrderByDescending(o => o).ToList();

            return acmNoList;
        }

        [WebMethod]
        //取種類
        public List<string> GetAccKind(string accYear, string acmWordNum)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.PK_動支編號 == acmWordNum);
            var accKindList = (from s1 in getAllWithAbate select s1.PK_種類).Distinct().ToList();

            return accKindList;
        }

        [WebMethod]
        //取次數
        public List<string> GetAccCount(string accYear, string acmWordNum, string accKind)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.PK_動支編號 == acmWordNum && x.PK_種類 == accKind);
            var accCountList = (from s1 in getAllWithAbate select s1.PK_次別).Distinct().ToList();

            return accCountList;
        }

        [WebMethod]
        //取明細號
        public List<string> GetAccDetail(string accYear, string acmWordNum, string accKind, string accCount)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.PK_動支編號 == acmWordNum && x.PK_種類 == accKind && x.PK_次別 == accCount);
            var accDetailList = (from s1 in getAllWithAbate select s1.PK_明細號).Distinct().ToList();

            return accDetailList;
        }

        [WebMethod]
        //依據所有KEY值取View
        public string GetByPrimaryKey(string accYear, string acmWordNum, string accKind, string accCount, string accDetail)
        {
            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.PK_動支編號 == acmWordNum && x.PK_種類 == accKind && x.PK_次別 == accCount && x.PK_明細號 == accDetail);
            var result = (from s1 in getAllWithAbate select s1).FirstOrDefault();

            string getGBCVisaDetail = "";
            getGBCVisaDetail = result.基金代碼 + "," + result.PK_會計年度 + "," + result.PK_動支編號 + "," + result.PK_種類 + "," + result.PK_次別 + "," + result.PK_明細號 + "," + result.F_科室代碼 + "," + result.F_用途別代碼 + "," + result.F_計畫代碼 + "," + result.F_動支金額.ToString() + "," + result.F_製票日 + "," + result.F_摘要 + "," + result.F_受款人 + "," + result.F_受款人編號 + "," + result.實支.ToString() + "," + result.預付轉正.ToString() + "," + result.沖抵估列.ToString();

            return getGBCVisaDetail;
        }

        [WebMethod]
        //取種類View
        public List<string> GetByKind(string accYear, string accKind, string batch)
        {
            List<string> list = new List<string>();
            string kindNo = "";

            IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate = dao.getAllWithAbate(x => x.PK_會計年度 == accYear && x.PK_種類 == accKind && x.F_批號 == batch);
            var result = (from s1 in getAllWithAbate select new { s1.基金代碼, s1.PK_會計年度, s1.PK_動支編號, s1.PK_種類, s1.PK_次別 }).ToList().Distinct();
            foreach (var resultItem in result)
            {
                kindNo = resultItem.PK_種類;

                switch (kindNo)
                {
                    case "估列":
                        kindNo = "3";
                        break;
                    case "估列收回":
                        kindNo = "4";
                        break;
                    case "預撥收回":
                        kindNo = "5";
                        break;
                    case "核銷收回":
                        kindNo = "6";
                        break;
                    default:
                        kindNo = "0";
                        break;
                }

                list.Add(resultItem.PK_動支編號 + "-" + kindNo + "-" + resultItem.PK_次別);
            }
            
            return list;
        }

    }
}
