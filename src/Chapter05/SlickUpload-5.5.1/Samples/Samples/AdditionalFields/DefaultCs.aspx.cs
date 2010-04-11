﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;
using System.Text;

public partial class AdditionalFields_DefaultCs : System.Web.UI.Page
{
    protected string SerializeDictionaryToString(IDictionary<string, string> values)
    {
        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<string, string> pair in values)
        {
            if (sb.Length > 0)
                sb.Append("<br />");

            sb.Append(pair.Key);
            sb.Append(": ");
            sb.Append(pair.Value.Replace("\r\n", "<br />"));
        }

        return sb.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID;
    }

    protected void SlickUpload1_UploadComplete(object sender, UploadStatusEventArgs e)
    {
        uploadPanel.Visible = false;
        resultPanel.Visible = true;

        if (e.UploadedFiles != null && e.UploadedFiles.Count > 0)
        {
            resultsRepeater.DataSource = e.UploadedFiles;
            resultsRepeater.DataBind();

            resultsRepeater.Visible = true;
        }
        else
        {
            resultsRepeater.Visible = false;
        }
    }

    protected void newUploadButton_Click(object sender, EventArgs e)
    {
        uploadPanel.Visible = true;
        resultPanel.Visible = false;
    }
}
