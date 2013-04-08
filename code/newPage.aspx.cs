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
        output.Text = _message(objPage.newPage(_title, _type, _content, _image, _pub));

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

    private string _message(bool success)
    {
        if (success == true)
        {
            return txt_title.Text.ToString() + " has been added successfully!";
        }
        else
        {
            return "Epic fail.";
        }
    }
}