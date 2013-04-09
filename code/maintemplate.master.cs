using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class maintemplate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        _loadMenus();
    }

    void _loadMenus()
    {
        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        XmlNodeList titleList = doc.GetElementsByTagName("url");

        primary_menu.Items.Clear();
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == "home")
            {
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value.ToUpper());
                output.Text = node.ChildNodes[2].FirstChild.Value.ToUpper();
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                primary_menu.Items.Add(output);
            }

        }

        //MenuItemCollection all = (MenuItemCollection)primary_menu.Items;
        feature_menu.Items.Clear();
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == "feature")
            {
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value.ToUpper());
                output.Text = node.ChildNodes[2].FirstChild.Value.ToUpper();
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                feature_menu.Items.Add(output);
            }

        }

        bottom_menu.Items.Clear();
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == "feature" || node.ChildNodes[3].FirstChild.Value == "home")
            {
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value);
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                bottom_menu.Items.Add(output);
            }

        }

        bottom_menu2.Items.Clear();
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == "footer")
            {
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value);
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                bottom_menu2.Items.Add(output);
            }
        }
    }

    public event EventHandler upFont; 
    public event EventHandler downFont;
    public void fontInc(object sender, EventArgs e)
    {
        int newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
        int paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) -6;

        int newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;
        int paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) - 5;

        if (newsizeMain > 20)
        {
            newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
            newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
        }
        primary_menu.Font.Size = FontUnit.Point(newsizeMain);
        primary_menu.StaticMenuItemStyle.HorizontalPadding = paddingMain;
        feature_menu.Font.Size = FontUnit.Point(newsizeFeat);
        feature_menu.StaticMenuItemStyle.HorizontalPadding = paddingFeat;

        this.upFont(this, e);
    }

    public void fontDec(object sender, EventArgs e)
    {
        int newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
        int paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) + 6;
        int newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;
        int paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) + 5;
        if (newsizeMain < 12)
        {
            newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
            newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
        }
        primary_menu.Font.Size = FontUnit.Point(newsizeMain);
        primary_menu.StaticMenuItemStyle.HorizontalPadding = paddingMain;
        feature_menu.Font.Size = FontUnit.Point(newsizeFeat);
        feature_menu.StaticMenuItemStyle.HorizontalPadding = paddingFeat;

        this.downFont(this, e);
    }
}
