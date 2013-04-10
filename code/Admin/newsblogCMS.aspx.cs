using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_newsblogCMS : System.Web.UI.Page
{
    //instantiating the news class
    newsClass objLinq = new newsClass();

    //instantiating the image class
    imagesClass objImg = new imagesClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        //binding data on initial page load
        if (!Page.IsPostBack)
        {
            _subRebind();
            _Rebind();
        }
    }

    //clear fields on refresh, bind drop downs from the news and uploads tables and Listview from the news table
    private void _subRebind()
    {
        txt_titleI.Text = string.Empty;
        txt_descI.Text = string.Empty;
        txt_contactidI.Text = string.Empty;

        //news drop down
        ddl_main.DataSource = objLinq.getNews();
        ddl_main.DataTextField = "n_title";
        ddl_main.DataValueField = "n_id";
        ddl_main.DataBind();

        //images drop down
        ddl_image.DataSource = objImg.getImages();
        ddl_image.DataTextField = "ImageName";
        ddl_image.DataValueField = "ImageURL";
        ddl_image.DataBind();

        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        lv_main.DataSource = objLinq.getNewsByID(_id);
        lv_main.DataBind();
    }

    //binding the images from the database to the DataList
    private void _Rebind()
    {
        imagesClass objImg = new imagesClass();
        dtl_main.DataSource = objImg.getImages();
        dtl_main.DataBind();
    }

    //returning selected item from drop down for editing in the ListView
    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        lv_main.DataSource = objLinq.getNewsByID(_id);
        lv_main.DataBind();
    }

    //displays success or failure message of news IUD
    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>News " + str + " was succesful.</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry, unable to " + str + " news.</span>";
        }
    }

    //news item insert subroutine using current system time
    protected void subInsert(object sender, EventArgs e)
    {
        string format = "dd/MM/yyyy hh:mm tt";
        string stringDate = DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
        DateTime dateTime = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

        _strMessage(objLinq.commitInsert(txt_titleI.Text, txt_descI.Text, ddl_image.SelectedValue.ToString(), dateTime, dateTime, int.Parse(txt_contactidI.Text.ToString())), "insert");
        _subRebind();
    }

    //subroutine to handle commands from listview for update and delete of articles
    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {
 
        switch (e.CommandName)
        {
            case "subUpdate":

                TextBox txtTitle = (TextBox)e.Item.FindControl("txt_titleE");
                TextBox txtDesc = (TextBox)e.Item.FindControl("txt_descE");
                TextBox txtImage = (TextBox)e.Item.FindControl("txt_imageE");
                TextBox txtContactID = (TextBox)e.Item.FindControl("txt_contactidE");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_idE");
                int newsID = int.Parse(hdfID.Value.ToString());

                _strMessage(objLinq.commitUpdate(newsID, txtTitle.Text, txtDesc.Text, txtImage.Text, int.Parse(txtContactID.Text.ToString())), "update");
                _subRebind();
                break;

            case "subDelete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_idE")).Value);
                _strMessage(objLinq.commitDelete(_id), "delete");
                _subRebind();
                break;
        }
    }

    //file uploader
    protected void subImage(object sender, EventArgs e)
    {
        //checking if post has occurred
        if (IsPostBack)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/img/");
            
            //validating file extension
            if (FileUploader.HasFile)
            {
                String fileExtension =
                    Path.GetExtension(FileUploader.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpg", ".jpeg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            //if allowed, attempting upload with error handling
            if (fileOK)
            {
                try
                {
                    FileUploader.PostedFile.SaveAs(path + FileUploader.FileName);
                    string ImgURL = System.IO.Path.GetFileName(FileUploader.FileName);
                    TextBox txtNameI = (TextBox)FileUploader.FindControl("txt_imagename");
                    imagesClass objImgI = new imagesClass();
                    objImgI.ImageName = txtNameI.Text.ToString();
                    objImgI.ImageURL = "~/img/" + ImgURL.ToString();
                    lbl_msg.Text = objImgI.insertImage();
                }
                catch (Exception ex)
                {
                    lbl_msg.Text = "<span style='color:red;'>File could not be uploaded</span> -- " + ex.Message.ToString();
                }
            }
            //notifying user if they try to use a bad extension
            else
            {
                lbl_msg.Text = "<span style='color:orange;'>Only .gif, .png, .jpg or .jpeg files can be uploaded</span>";
            }
        }
    }
}