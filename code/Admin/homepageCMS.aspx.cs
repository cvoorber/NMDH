using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_homepageCMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _BindData();
        }
    }

    //instantiating the class
    waitClass objWait = new waitClass();

    private void _BindData()
    {
        lv_main.DataSource = objWait.getWait();
        lv_main.DataBind();
    }

    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {

        if (e.CommandName == "subUpdate")
        {
            string format = "dd/MM/yyyy hh:mm tt";
            string stringDate = DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
            DateTime dateTime = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            TextBox txtPatients = (TextBox)e.Item.FindControl("txt_patientsE");
            Decimal Patients = Convert.ToDecimal(txtPatients.Text);
            TextBox txtOnStaff = (TextBox)e.Item.FindControl("txt_onstaffE");
            Decimal OnStaff = Convert.ToDecimal(txtOnStaff.Text);
            HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_idE");
            int waitID = int.Parse(hdfID.Value.ToString());
            Decimal estimate = (Patients * 30 / OnStaff) / 60;

            _strMessage(objWait.commitUpdate(waitID, Patients, OnStaff, dateTime, estimate), "update");
            _BindData();
        }
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>Wait time " + str + " was successful.</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry, unable to " + str + " wait time.</span>";
        }
    }
}