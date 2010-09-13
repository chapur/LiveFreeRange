using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BaseControl
/// </summary>
public class BaseControl : UserControl
{
    public new BasePage LiveFreeRangePage
    {
        get { return(BasePage)this.Page; }
    }
}
