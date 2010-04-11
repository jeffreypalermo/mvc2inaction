using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Configuration;

public partial class Common_Site : System.Web.UI.MasterPage
{
    protected string CurrentLanguageExtension
    {
        get
        {
            if (Request.Path.EndsWith("vb.aspx", StringComparison.InvariantCultureIgnoreCase))
                return "VB.aspx";
            else
                return "CS.aspx";
        }
    }

    protected string MaxRequestLength
    {
        get
        {
            return (SlickUploadConfiguration.MaxRequestLength / 1024 / 1024).ToString() + " MB";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Title.IndexOf(" - SlickUpload Samples") == -1)
            Page.Title += " - SlickUpload Samples";
    }
}
