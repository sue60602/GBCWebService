using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///
/// </summary>
public interface Vw_GBCVisaDetail_Interface{

   Vw_GBCVisaDetailVO findViewByAcmWordNum(string acmWordNum);
   List<Vw_GBCVisaDetailVO> getAll(string acmWordNum);
}