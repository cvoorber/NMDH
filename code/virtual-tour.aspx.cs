using System;
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
            // for now I have the whole list of floors showing ... later might want to just have floor 1
            bindAllDepList();
    }
    }

    // this routine will grab the department page data, based on the dept id from deptChoose panel and bind to the page repeater.
    protected void subChooseCommand(object sender, CommandEventArgs e)
    {
        // this will use the command argument from deptChoose panel to call the getDepartments Where function
        var chosenID = int.Parse(e.CommandArgument.ToString());
        rpt_deptpage.DataSource = objVirt.getDepartmentByID(chosenID);
        rpt_deptpage.DataBind();

    }


    // this routine binds the list of all departments to the the dept choose repeater.
    private void bindAllDepList()
    {
        rpt_deptchoose.DataSource = objVirt.getDepartments();
        rpt_deptchoose.DataBind();
    }

    // this routine will use string argument indicating floor to decide if Floor 1,2,3 or All will 
    // be shown for the departments list

    protected void subChooseFloor(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument == "floorall")
        {
            // reveal list for all floors
            bindAllDepList();
        }
        else // if Command Argument is for floor1, floor2, or floor3
        {
            switch (e.CommandArgument.ToString())
            {
                case "floor1":
                    // implementation for floor 1
                    rpt_deptchoose.DataSource = objVirt.getDepartmentsByFloorNo(1);
                    rpt_deptchoose.DataBind();
                    break;

                case "floor2":
                    // implementation for floor 2
                    rpt_deptchoose.DataSource = objVirt.getDepartmentsByFloorNo(2);
                    rpt_deptchoose.DataBind();
                    break;

                case "floor3":
                    // implementation for floor 3
                    rpt_deptchoose.DataSource = objVirt.getDepartmentsByFloorNo(3);
                    rpt_deptchoose.DataBind();
                    break;

                
            }

        }

    }

}