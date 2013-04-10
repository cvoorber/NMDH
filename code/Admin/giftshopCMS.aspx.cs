using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_giftshopCMS : System.Web.UI.Page
{
    //instantiating the products class
    productsClass objProd = new productsClass();

    //executing the bind functions on initial page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
            _Rebind();
        }
    }

    //first bind function - clears inputs, binds products and images to respective dataview controls
    private void _subRebind()
    {
        imagesClass objImages = new imagesClass();
        txt_nameI.Text = string.Empty;
        txt_descI.Text = string.Empty;
        txt_priceI.Text = string.Empty;
        rpt_all.DataSource = objProd.getProducts();
        rpt_all.DataBind();
        ddl_imageI.DataSource = objImages.getImages();
        ddl_imageI.DataTextField = "ImageName";
        ddl_imageI.DataValueField = "ImageURL";
        ddl_imageI.DataBind();
        _panelControl(pnl_all);
    }

    //controls the visibility of product IUD panels
    private void _panelControl(Panel pnl)
    {
        pnl_all.Visible = false;
        pnl_delete.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    //message for product insert div
    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>Product " + str + " was successful</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry, unable to " + str + " product</span>";
        }
    }

    //message for product update/delete div
    private void _editMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_editMsg.Text = "<span style='color:green;'>Product " + str + " was successful</span>";
        }
        else
        {
            lbl_editMsg.Text = "<span style='color:red;'>Sorry, unable to " + str + " product</span>";
        }
    }

    //subroutine controlling commands for product insert/update/delete
    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _strMessage(objProd.commitInsert(txt_nameI.Text, txt_descI.Text, ddl_imageI.SelectedValue.ToString(), decimal.Parse(txt_priceI.Text.ToString())), "insert");
                _subRebind();
                break;
            case "Update":
                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
        }
    }

    //displays product edit/update panel
    private void _showUpdate(int id)
    {
        _panelControl(pnl_update);
        rpt_update.DataSource = objProd.getProductsByID(id);
        rpt_update.DataBind();
    }

    //displays product delete panel
    private void _showDelete(int id)
    {
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objProd.getProductsByID(id);
        rpt_delete.DataBind();
    }

    //subroutine controlling update/delete events to carry out
    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                TextBox txtName = (TextBox)e.Item.FindControl("txt_nameU");
                TextBox txtDesc = (TextBox)e.Item.FindControl("txt_descU");
                TextBox txtPrice = (TextBox)e.Item.FindControl("txt_priceU");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                int proID = int.Parse(hdfID.Value.ToString());
                _editMessage(objProd.commitUpdate(proID, txtName.Text, txtDesc.Text, decimal.Parse(txtPrice.Text.ToString())), "update");
                _subRebind();
                break;
            case "Delete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _editMessage(objProd.commitDelete(_id), "delete");
                _subRebind();
                break;
            case "Cancel":
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

            //attempting upload with error handling
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
            //alerting user that only these extensions are allowed
            else
            {
                lbl_msg.Text = "<span style='color:orange;'>Only .gif, .png, .jpg or .jpeg files can be uploaded</span>";
            }
        }
    }

    //second bind function for images
    private void _Rebind()
    {
        imagesClass objImg = new imagesClass();
        dtl_main.DataSource = objImg.getImages();
        dtl_main.DataBind();
    }
}