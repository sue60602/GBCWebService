using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GBC_WebService
{
    public interface GBCAbate_Interface
    {
        void Insert(GBCAbateVO gBCAbate);
        void Delete(GBCAbateVO gBCAbate);
    }
}