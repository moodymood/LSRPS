﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.StatusCode = 404;
    }


    protected void Go_Back(object sender, EventArgs e)
    {
        if(Session["UserName"]!=null)
            Response.Redirect("~/Default.aspx");
        else
            Response.Redirect("~/Login.aspx");
    }
}