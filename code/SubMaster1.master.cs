using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class SubMaster1 : System.Web.UI.MasterPage
{
    private string _url = "";
    public string pp_Url
    {
        get { return _url; }
        set { _url = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _loadMenu();
    }

    protected void _loadMenu()
    {
        side_menu.Items.Clear();

        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        XmlNodeList titleList = doc.GetElementsByTagName("url");
        string urlparent = "";
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[0].FirstChild.Value == pp_Url)
            {
                urlparent = node.ChildNodes[3].FirstChild.Value.ToString();
            }
        }

        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == urlparent)
            {
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value);
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                side_menu.Items.Add(output);
            }

        }
    }
}
