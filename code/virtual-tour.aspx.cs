﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    virtClass objVirt = new virtClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // keeping this here just for testing
            bindAllDepList();
    }
    }

    // this routine will grab the department page data, based on the dept id from deptChoose panel
    protected void subChooseCommand(object sender, CommandEventArgs e)
    {
        // this will use the command argument from deptChoose panel to call the getDepartments Where function
        var chosenID = int.Parse(e.CommandArgument.ToString());
        rpt_deptpage.DataSource = objVirt.getDepartmentByID(chosenID);
        rpt_deptpage.DataBind();

    }



    private void bindAllDepList()
    {
        rpt_deptchoose.DataSource = objVirt.getDepartments();
        rpt_deptchoose.DataBind();
    }
}