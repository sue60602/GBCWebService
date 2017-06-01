using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using GBC_WebService;

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
        //JSON單筆測試
        public string GetVw_GBCVisaDetail(string acmWordNum)
        {

            Vw_GBCVisaDetailVO vw_GBCVisaDetailVO = dao.findViewByAcmWordNum(acmWordNum);

            Vw_GBCVisaDetail[] view = new Vw_GBCVisaDetail[] {
            new Vw_GBCVisaDetail(){
                PK_會計年度 = vw_GBCVisaDetailVO.getPK_會計年度(),
                PK_動支編號 = vw_GBCVisaDetailVO.getPK_動支編號(),
                PK_種類 = vw_GBCVisaDetailVO.getPK_種類(),
                PK_次別 = vw_GBCVisaDetailVO.getPK_次別(),
                PK_明細號 = vw_GBCVisaDetailVO.getPK_明細號(),
                F_科室代碼 = vw_GBCVisaDetailVO.getF_科室代碼(),
                F_用途別代碼 = vw_GBCVisaDetailVO.getF_用途別代碼(),
                F_計畫代碼 = vw_GBCVisaDetailVO.getF_計畫代碼(),
                F_動支金額 = vw_GBCVisaDetailVO.getF_動支金額(),
                F_製票日 = vw_GBCVisaDetailVO.getF_製票日(),
                F_是否核定 = vw_GBCVisaDetailVO.getF_是否核定(),
                F_核定金額 = vw_GBCVisaDetailVO.getF_核定金額(),
                F_核定日期 = vw_GBCVisaDetailVO.getF_核定日期(),
                F_摘要 = vw_GBCVisaDetailVO.getF_摘要(),
                F_受款人 = vw_GBCVisaDetailVO.getF_受款人(),
                F_受款人編號 = vw_GBCVisaDetailVO.getF_受款人編號(),
                F_批號 = vw_GBCVisaDetailVO.getF_批號()
            }
        };

            return JsonConvert.SerializeObject(view);
        }

        [WebMethod]
        //XML單筆測試
        public Vw_GBCVisaDetail[] GetVw_GBCVisaDetailXML(string acmWordNum)
        {

            Vw_GBCVisaDetailVO vw_GBCVisaDetailVO = dao.findViewByAcmWordNum(acmWordNum);

            Vw_GBCVisaDetail[] view = new Vw_GBCVisaDetail[] {
            new Vw_GBCVisaDetail(){
                PK_會計年度 = vw_GBCVisaDetailVO.getPK_會計年度(),
                PK_動支編號 = vw_GBCVisaDetailVO.getPK_動支編號(),
                PK_種類 = vw_GBCVisaDetailVO.getPK_種類(),
                PK_次別 = vw_GBCVisaDetailVO.getPK_次別(),
                PK_明細號 = vw_GBCVisaDetailVO.getPK_明細號(),
                F_科室代碼 = vw_GBCVisaDetailVO.getF_科室代碼(),
                F_用途別代碼 = vw_GBCVisaDetailVO.getF_用途別代碼(),
                F_計畫代碼 = vw_GBCVisaDetailVO.getF_計畫代碼(),
                F_動支金額 = vw_GBCVisaDetailVO.getF_動支金額(),
                F_製票日 = vw_GBCVisaDetailVO.getF_製票日(),
                F_是否核定 = vw_GBCVisaDetailVO.getF_是否核定(),
                F_核定金額 = vw_GBCVisaDetailVO.getF_核定金額(),
                F_核定日期 = vw_GBCVisaDetailVO.getF_核定日期(),
                F_摘要 = vw_GBCVisaDetailVO.getF_摘要(),
                F_受款人 = vw_GBCVisaDetailVO.getF_受款人(),
                F_受款人編號 = vw_GBCVisaDetailVO.getF_受款人編號(),
                F_批號 = vw_GBCVisaDetailVO.getF_批號()
            }
        };

            return view;
        }

        [WebMethod]
        //JSON集合
        public string GetVw_GBCVisaDetailJSON(string acmWordNum)
        {
            acmWordNum = acmWordNum.Trim(); //去空白
            acmWordNum = acmWordNum.Replace("*", ""); //去掉"*"字號
                                                      //Regex rx = new Regex(@"\*\d{8}-\d{1,2}-\d{1,2}\*"); //輸入規則:*10500001-1-1*
            Regex rx = new Regex(@"\d{8}-\d{1}-\d{1,3}$");  //輸入規則:10500001-1-1
            Match match = rx.Match(acmWordNum);
            List<Vw_GBCVisaDetailVO> vw_GBCVisaDetailVO = dao.getAll(acmWordNum);
            List<Vw_GBCVisaDetail> view = new List<Vw_GBCVisaDetail>();

            if (match.Success)
            {
                foreach (var item in vw_GBCVisaDetailVO)
                {
                    view.Add(
                        new Vw_GBCVisaDetail()
                        {
                            基金代碼 = item.get基金代碼(),
                            PK_會計年度 = item.getPK_會計年度(),
                            PK_動支編號 = item.getPK_動支編號(),
                            PK_種類 = item.getPK_種類(),
                            PK_次別 = item.getPK_次別(),
                            PK_明細號 = item.getPK_明細號(),
                            F_科室代碼 = item.getF_科室代碼(),
                            F_用途別代碼 = item.getF_用途別代碼(),
                            F_計畫代碼 = item.getF_計畫代碼(),
                            F_動支金額 = item.getF_動支金額(),
                            F_製票日 = item.getF_製票日(),
                            F_是否核定 = item.getF_是否核定(),
                            F_核定金額 = item.getF_核定金額(),
                            F_核定日期 = item.getF_核定日期(),
                            F_摘要 = item.getF_摘要(),
                            F_受款人 = item.getF_受款人(),
                            F_受款人編號 = item.getF_受款人編號(),
                            F_批號 = item.getF_批號()
                        }
                    );
                }
            }
            else
            {
                return JsonConvert.SerializeObject("輸入格式錯誤");
            }

            return JsonConvert.SerializeObject(view);
        }

        [WebMethod]
        //回填傳票號碼
        public string FillVouNo(List<GBCVisaDetailAbateDetailVO> fillVouList)
        {
            GBCAbateVO gbcAbateVO = new GBCAbateVO();
            List<GBCVisaDetailAbateDetailVO> gbcVisaDetailAbateDetailVOList = new List<GBCVisaDetailAbateDetailVO>();

            foreach (var gbcVisaDetailAbateDetailVOListItem in gbcVisaDetailAbateDetailVOList)
            {
                gbcAbateVO.PK_會計年度 = gbcVisaDetailAbateDetailVOListItem.getPK_會計年度();
                gbcAbateVO.PK_動支編號 = gbcVisaDetailAbateDetailVOListItem.getPK_動支編號();
                gbcAbateVO.PK_種類 = gbcVisaDetailAbateDetailVOListItem.getPK_種類();
                gbcAbateVO.PK_次別 = gbcVisaDetailAbateDetailVOListItem.getPK_次別();
                gbcAbateVO.PK_明細號 = gbcVisaDetailAbateDetailVOListItem.getPK_明細號();
                gbcAbateVO.F_製票號 = gbcVisaDetailAbateDetailVOListItem.getF_傳票號1();
                gbcAbateVO.F_製票日期 = gbcVisaDetailAbateDetailVOListItem.getF_製票日期1();
                gbcAbateVO.F_過帳號 = gbcVisaDetailAbateDetailVOListItem.getF_傳票號1();
                gbcAbateVO.F_過帳日期 = gbcVisaDetailAbateDetailVOListItem.getF_製票日期1();

                abateDAO.Delete(gbcAbateVO);
                abateDAO.Insert(gbcAbateVO);
            }

            return "xxx";
        }

        //=================手動選取資料=================
        [WebMethod]
        //取年度
        public List<string> GetYear()
        {
            List<string> yearList = new List<string>(dao.GetYear());
            return yearList;
        }

        [WebMethod]
        //取動支編號
        public List<string> GetAcmWordNum(string accYear)
        {
            List<string> acmNoList = new List<string>(
                dao.GetAcmWordNum(accYear)
                );

            return acmNoList;
        }

        [WebMethod]
        //取種類
        public List<string> GetAccKind(string accYear, string acmWordNum)
        {
            List<string> accKindList = new List<string>(
                dao.GetAccKind(accYear, acmWordNum)
                );
            return accKindList;
        }

        [WebMethod]
        //取次數
        public List<string> GetAccCount(string accYear, string acmWordNum, string accKind)
        {
            List<string> accCountList = new List<string>(
                dao.GetAccCount(accYear, acmWordNum, accKind)
                );
            return accCountList;
        }

        [WebMethod]
        //取明細號
        public List<string> GetAccDetail(string accYear, string acmWordNum, string accKind, string accCount)
        {
            List<string> accDetailList = new List<string>(
                dao.GetAccDetail(accYear, acmWordNum, accKind, accCount)
                );
            return accDetailList;
        }

        [WebMethod]
        //依據所有KEY值取View
        public string GetByPrimaryKey(string accYear, string acmWordNum, string accKind, string accCount, string accDetail)
        {
            string getGBCVisaDetail = dao.GetByPrimaryKey(accYear, acmWordNum, accKind, accCount, accDetail);
            return getGBCVisaDetail;
        }
    }
}
