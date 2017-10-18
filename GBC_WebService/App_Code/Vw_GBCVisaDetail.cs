using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Vw_GBCVisaDetail 的摘要描述
/// </summary>
public class Vw_GBCVisaDetail
{
    public String 基金代碼 { get; set; }
    public String PK_會計年度 { get; set; }
    public String PK_動支編號 { get; set; }
    public String PK_種類 { get; set; }
    public String PK_次別 { get; set; }
    public String PK_明細號 { get; set; }
    public String F_科室代碼 { get; set; }
    public String F_用途別代碼 { get; set; }
    public String F_計畫代碼 { get; set; }
    public String F_動支金額 { get; set; }
    public String F_製票日 { get; set; }
    public String F_是否核定 { get; set; }
    public String F_核定金額 { get; set; }
    public String F_核定日期 { get; set; }
    public String F_摘要 { get; set; }
    public String F_受款人 { get; set; }
    public String F_受款人編號 { get; set; }
    public String F_原動支編號 { get; set; }
    public String F_批號 { get; set; }
    public string 實支 { get; set; }
    public string 預付轉正 { get; set; }
    public string 沖抵估列 { get; set; }
}