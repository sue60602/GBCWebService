using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GBC_WebService.EF;
using System.Linq.Expressions;

/// <summary>
/// Vw_GBCVisaDetailDAO 的摘要描述
/// </summary>
public class Vw_GBCVisaDetailDAO
{
    MOHWFGBCEEntities db = new MOHWFGBCEEntities();

    //private const string GET_ONE_STMT =
    //    "SELECT  [基金代碼],[PK_會計年度],[PK_動支編號],[PK_種類],[PK_次別],[PK_明細號],[F_科室代碼],[F_用途別代碼],[F_計畫代碼],[F_動支金額],[F_製票日],[F_是否核定],[F_核定金額],[F_核定日期],[F_摘要],[F_受款人],[F_受款人編號],[F_原動支編號],[F_批號],[F_原動支編號] FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_動支編號 = @acmWordNum  and PK_種類=@acmKind and PK_次別=@acmNo";

    //private const string GET_ONE_STMT_BY_ORINGINAL =
    //    "SELECT  [基金代碼],[PK_會計年度],[PK_動支編號],[PK_種類],[PK_次別],[PK_明細號],[F_科室代碼],[F_用途別代碼],[F_計畫代碼],[F_動支金額],[F_製票日],[F_是否核定],[F_核定金額],[F_核定日期],[F_摘要],[F_受款人],[F_受款人編號],[F_原動支編號],[F_批號],[F_原動支編號] FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and F_原動支編號 = @acmWordNum  and PK_種類=@acmKind and PK_次別=@acmNo";

    //private const string GET_YEAR_STMT =
    //    "SELECT DISTINCT PK_會計年度 FROM GBCVisaDetail order by PK_會計年度 desc";

    //private const string GET_ACMNO_STMT =
    //    "SELECT DISTINCT PK_動支編號 FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 order by PK_動支編號 desc";

    //private const string GET_ACCKIND_STMT =
    //    "SELECT DISTINCT PK_種類 FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_動支編號=@PK_動支編號";

    //private const string GET_ACCCOUNT_STMT =
    //"SELECT DISTINCT PK_次別 FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_動支編號=@PK_動支編號 and PK_種類=@PK_種類";

    //private const string GET_ACCDTL_STMT =
    //"SELECT DISTINCT PK_明細號 FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_動支編號=@PK_動支編號 and PK_種類=@PK_種類 and PK_次別=@PK_次別";

    //private const string GET_BY_PK_STMT =
    //"SELECT [基金代碼],[PK_會計年度],[PK_動支編號],[PK_種類],[PK_次別],[PK_明細號],[F_科室代碼],[F_用途別代碼],[F_計畫代碼],[F_動支金額],[F_製票日],[F_是否核定],[F_核定金額],[F_核定日期],[F_摘要],[F_受款人],[F_受款人編號],[F_原動支編號],[F_批號],[F_原動支編號] FROM GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_動支編號=@PK_動支編號 and PK_種類=@PK_種類 and PK_次別=@PK_次別 and PK_明細號=@PK_明細號";

    //private const string GET_ESTIMATE_STMT =
    //"select distinct 基金代碼,PK_會計年度,PK_動支編號,PK_種類,PK_次別 from GBCVisaDetail where PK_會計年度=@PK_會計年度 and PK_種類=@PK_種類 and F_批號=@F_批號 ";

    //private const string IS_ORIGINAL_STMT =
    //"select count(*) as cnt from GBCVisaDetail where PK_會計年度=@PK_會計年度 and F_原動支編號=@F_原動支編號";

    ////測試用(找單筆)
    //public Vw_GBCVisaDetailVO findViewByAcmWordNum(string acmWordNum)
    //{
    //    Vw_GBCVisaDetailVO vw_GBCVisaDetailVO = null;
    //    acmWordNum = acmWordNum.Trim(); //去空白
    //    acmWordNum = acmWordNum.Replace("*", ""); //去掉"*"字號
    //    string[] strs = acmWordNum.Split('-'); //以"-"區分種類及次號
    //    string acmWordNumOut = strs[0];
    //    string acmKind = null;
    //    switch (strs[1])
    //    {
    //        case "1":
    //            acmKind = "預付";
    //            break;
    //        case "2":
    //            acmKind = "核銷";
    //            break;
    //        case "3":
    //            acmKind = "估列";
    //            break;
    //        case "4":
    //            acmKind = "估列收回";
    //            break;
    //        case "5":
    //            acmKind = "預撥收回";
    //            break;
    //        case "6":
    //            acmKind = "核銷收回";
    //            break;
    //        default:
    //            acmKind = "無";
    //            break;
    //    }
    //    string acmNo = strs[2];
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ONE_STMT, con);
    //    com.Parameters.AddWithValue("@acmWordNum", acmWordNumOut);
    //    com.Parameters.AddWithValue("@acmKind", acmKind);
    //    com.Parameters.AddWithValue("@acmNo", acmNo);
    //    con.Open();

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read()){
    //        vw_GBCVisaDetailVO = new Vw_GBCVisaDetailVO();
    //        vw_GBCVisaDetailVO.setPK_會計年度(dr["PK_會計年度"].ToString());
    //        vw_GBCVisaDetailVO.setPK_動支編號(dr["PK_動支編號"].ToString());
    //        vw_GBCVisaDetailVO.setPK_種類(dr["PK_種類"].ToString());
    //        vw_GBCVisaDetailVO.setPK_次別(dr["PK_次別"].ToString());
    //        vw_GBCVisaDetailVO.setPK_明細號(dr["PK_明細號"].ToString());
    //        vw_GBCVisaDetailVO.setF_科室代碼(dr["F_科室代碼"].ToString());
    //        vw_GBCVisaDetailVO.setF_用途別代碼(dr["F_用途別代碼"].ToString());
    //        vw_GBCVisaDetailVO.setF_計畫代碼(dr["F_計畫代碼"].ToString());
    //        vw_GBCVisaDetailVO.setF_動支金額(dr["F_動支金額"].ToString());
    //        vw_GBCVisaDetailVO.setF_製票日(dr["F_製票日"].ToString());
    //        vw_GBCVisaDetailVO.setF_是否核定(dr["F_是否核定"].ToString());
    //        vw_GBCVisaDetailVO.setF_核定金額(dr["F_核定金額"].ToString());
    //        vw_GBCVisaDetailVO.setF_核定日期(dr["F_核定日期"].ToString());
    //        vw_GBCVisaDetailVO.setF_摘要(dr["F_摘要"].ToString());
    //        vw_GBCVisaDetailVO.setF_受款人(dr["F_受款人"].ToString());
    //        vw_GBCVisaDetailVO.setF_受款人編號(dr["F_受款人編號"].ToString());
    //        vw_GBCVisaDetailVO.setF_原動支編號(dr["F_原動支編號"].ToString());
    //        vw_GBCVisaDetailVO.setF_批號(dr["F_批號"].ToString());
    //    }
        
    //    con.Close();

    //    return vw_GBCVisaDetailVO;

    //    throw new Exception();
    //}

    ////目前使用此方法
    //public List<Vw_GBCVisaDetailVO> getAll(string acmWordNum) {
    //    List<Vw_GBCVisaDetailVO> list = new List<Vw_GBCVisaDetailVO>();
    //    Vw_GBCVisaDetailVO vw_GBCVisaDetailVO = null;

    //    string[] strs = acmWordNum.Split('-'); //以"-"區分種類及次號
    //    string acmWordNumOut = strs[0];
    //    string acmKind = null;
    //    switch (strs[1])
    //    {
    //        case "1":
    //            acmKind = "預付";
    //            break;
    //        case "2":
    //            acmKind = "核銷";
    //            break;
    //        case "3":
    //            acmKind = "估列";
    //            break;
    //        case "4":
    //            acmKind = "估列收回";
    //            break;
    //        case "5":
    //            acmKind = "預撥收回";
    //            break;
    //        case "6":
    //            acmKind = "核銷收回";
    //            break;
    //        default:
    //            acmKind = "無";
    //            break;
    //    }
    //    string acmNo = strs[2];
         

    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = null;

    //    if (int.Parse(acmWordNumOut.Substring(0, 3)) < DateTime.Now.Year - 1911)
    //    {
    //        if (isOrigNum(acmWordNumOut)>0)
    //        {
    //            com = new SqlCommand(GET_ONE_STMT_BY_ORINGINAL, con);
    //        }
    //        else
    //        {
    //            com = new SqlCommand(GET_ONE_STMT, con);
    //        }
            
    //    }
    //    else
    //    {
    //        com = new SqlCommand(GET_ONE_STMT, con);
    //    }
         
    //    //com.Parameters.AddWithValue("@PK_會計年度", acmWordNumOut.Substring(0, 3));
    //    com.Parameters.AddWithValue("@PK_會計年度", DateTime.Now.Year - 1911);
    //    com.Parameters.AddWithValue("@acmWordNum", acmWordNumOut);
    //    com.Parameters.AddWithValue("@acmKind", acmKind);
    //    com.Parameters.AddWithValue("@acmNo", acmNo);
    //    con.Open();

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        vw_GBCVisaDetailVO = new Vw_GBCVisaDetailVO();
    //        vw_GBCVisaDetailVO.set基金代碼(dr["基金代碼"].ToString()); 
    //        vw_GBCVisaDetailVO.setPK_會計年度(dr["PK_會計年度"].ToString());
    //        vw_GBCVisaDetailVO.setPK_動支編號(dr["PK_動支編號"].ToString());
    //        vw_GBCVisaDetailVO.setPK_種類(dr["PK_種類"].ToString());
    //        vw_GBCVisaDetailVO.setPK_次別(dr["PK_次別"].ToString());
    //        vw_GBCVisaDetailVO.setPK_明細號(dr["PK_明細號"].ToString());
    //        vw_GBCVisaDetailVO.setF_科室代碼(dr["F_科室代碼"].ToString());
    //        vw_GBCVisaDetailVO.setF_用途別代碼((dr["F_用途別代碼"].ToString()).Substring(2));
    //        if((dr["F_計畫代碼"].ToString()).Length > 2)
    //        {
    //            vw_GBCVisaDetailVO.setF_計畫代碼((dr["F_計畫代碼"].ToString()).Substring(7));
    //        }
    //        else {
    //            vw_GBCVisaDetailVO.setF_計畫代碼(dr["F_計畫代碼"].ToString());
    //        }            
    //        vw_GBCVisaDetailVO.setF_動支金額(dr["F_動支金額"].ToString());
    //        vw_GBCVisaDetailVO.setF_製票日(dr["F_製票日"].ToString());
    //        vw_GBCVisaDetailVO.setF_是否核定(dr["F_是否核定"].ToString());
    //        vw_GBCVisaDetailVO.setF_核定金額(dr["F_核定金額"].ToString());
    //        vw_GBCVisaDetailVO.setF_核定日期(dr["F_核定日期"].ToString());
    //        vw_GBCVisaDetailVO.setF_摘要(dr["F_摘要"].ToString());
    //        vw_GBCVisaDetailVO.setF_受款人(dr["F_受款人"].ToString());
    //        vw_GBCVisaDetailVO.setF_受款人編號(dr["F_受款人編號"].ToString());
    //        vw_GBCVisaDetailVO.setF_原動支編號(dr["F_原動支編號"].ToString());
    //        vw_GBCVisaDetailVO.setF_批號(dr["F_批號"].ToString());
    //        list.Add(vw_GBCVisaDetailVO);
    //    }

    //    con.Close();

    //    return list;
    //}

    ////原動支欄位是否存在
    //public int isOrigNum(string acmWordNum)
    //{
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = null;

    //    com = new SqlCommand(IS_ORIGINAL_STMT, con);

    //    com.Parameters.AddWithValue("@PK_會計年度", DateTime.Now.Year - 1911);
    //    com.Parameters.AddWithValue("@F_原動支編號", acmWordNum);

    //    con.Open();

    //    int cnt = int.Parse(com.ExecuteScalar().ToString());

    //    return cnt;
    //}

    ////取年度
    //public List<string> GetYear()
    //{
    //    List<string> yearList = new List<string>();
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_YEAR_STMT, con);

    //    con.Open();

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        yearList.Add(dr["PK_會計年度"].ToString());
    //    }

    //    con.Close();
    //    return yearList;
    //}

    ////取動支編號
    //public List<string> GetAcmWordNum(string accYear)
    //{
    //    List<string> acmNoList = new List<string>();
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ACMNO_STMT, con);

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        acmNoList.Add(dr["PK_動支編號"].ToString());
    //    }

    //    con.Close();
    //    return acmNoList;

    //}

    ////取種類
    //public List<string> GetAccKind(string accYear, string acmWordNum)
    //{
    //    List<string> accKindList = new List<string>();
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ACCKIND_STMT, con);

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);
    //    com.Parameters.AddWithValue("@PK_動支編號", acmWordNum);

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        accKindList.Add(dr["PK_種類"].ToString());
    //    }

    //    con.Close();
    //    return accKindList;
    //}

    ////取次數
    //public List<string> GetAccCount(string accYear, string acmWordNum, string accKind)
    //{
    //    List<string> accCountList = new List<string>();
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ACCCOUNT_STMT, con);

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);
    //    com.Parameters.AddWithValue("@PK_動支編號", acmWordNum);
    //    com.Parameters.AddWithValue("@PK_種類", accKind);

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        accCountList.Add(dr["PK_次別"].ToString());
    //    }

    //    con.Close();
    //    return accCountList;
    //}

    ////取明細號
    //public List<string> GetAccDetail(string accYear, string acmWordNum, string accKind, string accCount)
    //{
    //    List<string> accDetailList = new List<string>();
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ACCDTL_STMT, con);

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);
    //    com.Parameters.AddWithValue("@PK_動支編號", acmWordNum);
    //    com.Parameters.AddWithValue("@PK_種類", accKind);
    //    com.Parameters.AddWithValue("@PK_次別", accCount);

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        accDetailList.Add(dr["PK_明細號"].ToString());
    //    }

    //    con.Close();
    //    return accDetailList;
    //}

    ////依據所有KEY值取View
    //public string GetByPrimaryKey(string accYear, string acmWordNum, string accKind, string accCount, string accDetail)
    //{
    //    //List<string> getGBCVisaDetail = new List<string>();
    //    string getGBCVisaDetail = "";
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_BY_PK_STMT, con);

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);
    //    com.Parameters.AddWithValue("@PK_動支編號", acmWordNum);
    //    com.Parameters.AddWithValue("@PK_種類", accKind);
    //    com.Parameters.AddWithValue("@PK_次別", accCount);
    //    com.Parameters.AddWithValue("@PK_明細號", accDetail);


    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        //getGBCVisaDetail.Add(dr["PK_明細號"].ToString());
    //        getGBCVisaDetail = dr["基金代碼"].ToString() + "," + dr["PK_會計年度"].ToString() + "," + dr["PK_動支編號"].ToString() + "," + dr["PK_種類"].ToString() + "," + dr["PK_次別"].ToString() + "," + dr["PK_明細號"].ToString() + "," + dr["F_科室代碼"].ToString() + "," + dr["F_用途別代碼"].ToString() + "," + dr["F_計畫代碼"].ToString() + "," + dr["F_動支金額"].ToString() + "," + dr["F_製票日"].ToString() + "," + dr["F_摘要"].ToString() + "," + dr["F_受款人"].ToString() + "," + dr["F_受款人編號"].ToString();

    //    }

    //    con.Close();
    //    return getGBCVisaDetail;
    //}

    ////取估列資料
    //public List<string> GetByKind(string accYear, string accKind, string batch)
    //{
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString);
    //    SqlCommand com = new SqlCommand(GET_ESTIMATE_STMT, con);
    //    List<string> list = new List<string>();
    //    string kindNo = "";

    //    con.Open();
    //    com.Parameters.AddWithValue("@PK_會計年度", accYear);
    //    com.Parameters.AddWithValue("@PK_種類", accKind);
    //    com.Parameters.AddWithValue("@F_批號", batch);

    //    SqlDataReader dr = com.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        kindNo = dr["PK_種類"].ToString();
    //        switch (kindNo)
    //        {
    //            case "估列":
    //                kindNo = "3";
    //                break;
    //            case "估列收回":
    //                kindNo = "4";
    //                break;
    //            case "預撥收回":
    //                kindNo = "5";
    //                break;
    //            case "核銷收回":
    //                kindNo = "6";
    //                break;
    //            default:
    //                kindNo = "0";
    //                break;
    //        }
    //        list.Add(dr["PK_動支編號"].ToString() + "-" + kindNo + "-" + dr["PK_次別"].ToString());
    //    }

    //    con.Close();

    //    return list;
    //}

    //用EF方式取資料
    public IQueryable<vw_GBCVisaDetailWithAbate> getAllWithAbate(Expression<Func<vw_GBCVisaDetailWithAbate, bool>> condition)
    {
        var result = from s1 in db.vw_GBCVisaDetailWithAbate select s1;
        return result.Where(condition);
    }

}