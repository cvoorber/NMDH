using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class newPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _bindDDL();
            _rebind();
        }
    }

    public List<ListItem> getTypes()
    {
        List<ListItem> type = new List<ListItem>();
        type.Add(new ListItem("Select"));
        type.Add(new ListItem("About"));
        type.Add(new ListItem("Services"));
        type.Add(new ListItem("Visitors"));
        type.Add(new ListItem("Policies"));
        return type;
    }

    private void _bindDDL()
    {
        ddl_type.DataSource = getTypes();
        ddl_type.DataBind();
    }

    protected void setType(object sender, EventArgs e)
    {
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        navClass objPage = new navClass();
        string _title = txt_title.Text.ToString();
        string _content = txt_content.Text.ToString();
        string _type = ddl_type.SelectedValue.ToString();
        string _image = "testimg";
        bool _pub = chk_publish.Checked;
        output.Text = _message(objPage.newPage(_title, _type, _content, _image, _pub), "add");

        if (_pub)
        {

            string xmlpath = Request.PhysicalApplicationPath + "XMLSitemap.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);                      // This code assumes that the XML file is in the same folder.


            //http://support.microsoft.com/kb/317664
            //http://support.microsoft.com/kb/317666
            // A. Addition
            // 1. Create a new item element.
            XmlElement newElem = doc.CreateElement("url");

            string pagesource = "";
            var source = objPage.getPageByName(txt_title.Text.ToString());
            foreach (var s in source)
            {
                pagesource = s.gp_id.ToString();
            }

            string parent = "";
            string path = "";
            switch (ddl_type.SelectedValue.ToString())
            {
                case "About":
                    parent = "about";
                    path = "~/navigation/about.aspx";
                    break;
                case "Services":
                    parent = "services";
                    path = "~/navigation/services.aspx";
                    break;
                case "Visitors":
                    parent = "visitors";
                    path = "~/navigation/visitors.aspx";
                    break;
                case "Policies":
                    parent = "policies";
                    path = "~/navigation/policies.aspx";
                    break;
            }


            // Create the child nodes. This code demonstrates various ways to add them.
            newElem.InnerXml = "<loc></loc><lastmod></lastmod><title></title><parent></parent><sourceid></sourceid>";
            newElem["loc"].InnerText = path;
            newElem["lastmod"].InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            newElem["title"].InnerText = txt_title.Text.ToString();
            newElem["parent"].InnerText = parent;
            newElem["sourceid"].InnerText = pagesource;


            // 2.  Add the new element to the end of the item list.
            doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(newElem);


            // 3. Save the modified XML to a file in Unicode format.
            doc.PreserveWhitespace = true;
            XmlTextWriter wrtr = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
            doc.WriteTo(wrtr);
            wrtr.Close();
        }

        txt_title.Text = string.Empty;
        txt_content.Text = string.Empty;
        ddl_type.SelectedIndex = 0;

        _rebind();
        pnl_new.Visible = false;

    }

    protected void subCancel(object sender, EventArgs e)
    {
        output.Text = string.Empty;
        txt_title.Text = string.Empty;
        txt_content.Text = string.Empty;
        ddl_type.SelectedIndex = 0;
        pnl_new.Visible = false;
    }

    private string _message(bool success, string action)
    {
        if (success == true)
        {
            return "Page has been " + action + "ed successfully!";
        }
        else
        {
            return "Epic fail.";
        }
    }

    private void _rebind()
    {
        navClass objPages = new navClass();
        rpt_all.DataSource = objPages.getAll();
        rpt_all.DataBind();
    }

    protected void subEdit(object sender, RepeaterCommandEventArgs e)
    {
        output.Text = string.Empty;
        navClass objDetails = new navClass();
        dtv_edit.DataSource = objDetails.getPageByID(int.Parse(e.CommandArgument.ToString()));
        dtv_edit.DataBind();
        DropDownList sections = (DropDownList)dtv_edit.FindControl("ddl_section");
        sections.DataSource = getTypes();
        sections.DataBind();
        var selected = objDetails.getPageByID(int.Parse(e.CommandArgument.ToString()));
        string sel = "";
        foreach (var s in selected)
        {
            sel = s.gp_section.ToString();
        }
        sections.SelectedValue = sel;
        dtv_edit.ChangeMode(DetailsViewMode.Edit);
        pnl_all.Visible = false;
        pnl_edit.Visible = true;
    }

    protected void subChange(object sender, DetailsViewCommandEventArgs e)
    {
        navClass objNav = new navClass();
        string xmlpath = Request.PhysicalApplicationPath + "XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlpath);

        string parent = "";
        string path = "";

        switch (e.CommandName)
        {
            case "save":
                int _id = int.Parse(e.CommandArgument.ToString());
                if (dtv_edit.CurrentMode == DetailsViewMode.Edit)
                {
                    TextBox txt_title = (TextBox)dtv_edit.FindControl("txt_title");
                    string title = txt_title.Text;

                    TextBox txt_content = (TextBox)dtv_edit.FindControl("txt_content");
                    string content = txt_content.Text;

                    CheckBox chk_active = (CheckBox)dtv_edit.FindControl("chk_activeE");
                    bool active = chk_active.Checked;

                    DropDownList ddl_section = (DropDownList)dtv_edit.FindControl("ddl_section");
                    string section = ddl_section.SelectedValue.ToString();

                    output.Text = _message(objNav.updatePage(_id, title, section, content, active), "edit");

                    switch (section)
                    {
                        case "About":
                            parent = "about";
                            path = "~/navigation/about.aspx";
                            break;
                        case "Services":
                            parent = "services";
                            path = "~/navigation/services.aspx";
                            break;
                        case "Visitors":
                            parent = "visitors";
                            path = "~/navigation/visitors.aspx";
                            break;
                        case "Policies":
                            parent = "policies";
                            path = "~/navigation/policies.aspx";
                            break;
                    }

                    XmlElement updElem = doc.CreateElement("url");
                    updElem.InnerXml = "<loc></loc><lastmod></lastmod><title></title><parent></parent><sourceid></sourceid>";
                    updElem["loc"].InnerText = path;
                    updElem["lastmod"].InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                    updElem["title"].InnerText = title;
                    updElem["parent"].InnerText = parent;
                    updElem["sourceid"].InnerText = _id.ToString();

                    var elements = doc.GetElementsByTagName("sourceid");
                    var match = false;
                    foreach (XmlNode el in elements)
                    {
                        if (el.InnerText == _id.ToString())
                        {
                            match = true;
                            if (el.ParentNode.ChildNodes[0].InnerText == path && active)
                            {
                                el.ParentNode.ParentNode.ReplaceChild(updElem, el.ParentNode);
                                break;
                            }
                            else
                            {
                                el.ParentNode.ParentNode.RemoveChild(el.ParentNode);
                                if (active)
                                {
                                    doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(updElem);
                                    break;
                                }
                            }
                        }
                    }
                    if (!match && active)
                    {
                        doc.DocumentElement.SelectNodes("/urlset/url[loc='" + path + "']")[0].AppendChild(updElem);
                    }

                    // 3. Save the modified XML to a file in Unicode format.
                    doc.PreserveWhitespace = true;
                    XmlTextWriter wrtr = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
                    doc.WriteTo(wrtr);
                    wrtr.Close();
                }

                break;
            case "cancel":
                break;
            case "delet":
                output.Text = _message(objNav.deletePage(int.Parse(e.CommandArgument.ToString())), "delet");
                var elementsD = doc.GetElementsByTagName("sourceid");
                foreach (XmlNode el in elementsD)
                {
                    if (el.InnerText == e.CommandArgument.ToString())
                    {
                        el.ParentNode.ParentNode.RemoveChild(el.ParentNode);
                        break;
                    }
                }
                // 3. Save the modified XML to a file in Unicode format.
                doc.PreserveWhitespace = true;
                XmlTextWriter wrtrD = new XmlTextWriter(xmlpath, System.Text.Encoding.Unicode);
                doc.WriteTo(wrtrD);
                wrtrD.Close();
                break;
        }
        pnl_edit.Visible = false;
        pnl_all.Visible = true;
        _rebind();
    }

    protected void showNew(object sender, EventArgs e)
    {
        output.Text = string.Empty;
        pnl_new.Visible = true;
    }
    protected void modeChange(object sender, DetailsViewModeEventArgs e)
    {
    }
}