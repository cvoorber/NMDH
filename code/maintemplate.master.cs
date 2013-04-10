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

    //this function loads the menu items into the header and footer menus
    void _loadMenus()
    {
        //locate the xml document
        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();

        //add the located xml doc into the new Xml Document
        doc.Load(xmlPath);

        //create a nodelist based on the "url" tags
        XmlNodeList titleList = doc.GetElementsByTagName("url");

        //clear current menu items
        primary_menu.Items.Clear();
        foreach (XmlNode node in titleList)
        {
            //check if each node belongs in the "home" menu (this is based on the 3rd childnode of "url")
            if (node.ChildNodes[3].FirstChild.Value == "home")
            {
                //create a menu item for each match
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value.ToUpper()); //set the value of the menu item
                output.Text = node.ChildNodes[2].FirstChild.Value.ToUpper();
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                primary_menu.Items.Add(output); //add it to the menu
            }

        }

        //the following does the same as above, but for the "feature" menu

        //clear any items currently in the menu
        feature_menu.Items.Clear();

        //loop through each node
        foreach (XmlNode node in titleList)
        {
            //check if the node belongs in the feature menu
            if (node.ChildNodes[3].FirstChild.Value == "feature")
            {
                //create the menu item
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value.ToUpper());
                output.Text = node.ChildNodes[2].FirstChild.Value.ToUpper();
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                feature_menu.Items.Add(output);
            }

        }

        //the following populates the footer menu in the same way as the menus above

        //clear the existing items
        bottom_menu.Items.Clear();

        //loop through each node
        foreach (XmlNode node in titleList)
        {
            //check that the menu items is a home page item - this means that it is a main or feature menu item
            if (node.ChildNodes[3].FirstChild.Value == "feature" || node.ChildNodes[3].FirstChild.Value == "home")
            {
                //assign the value to a new menu item
                MenuItem output = new MenuItem((string)node.ChildNodes[2].FirstChild.Value);
                output.Text = node.ChildNodes[2].FirstChild.Value;
                output.NavigateUrl = node.ChildNodes[0].FirstChild.Value.ToString();
                bottom_menu.Items.Add(output); //add the item to the menu
            }

        }

        //populate the bottom menu (copyright and terms)
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

    //this section deals with increasing and decreasing

    //create a public eventhandler that can be used by the page and submaster
    public event EventHandler upFont; 
    public event EventHandler downFont;

    //increase the font size by 2pts
    public void fontInc(object sender, EventArgs e)
    {
        //the new main menu font size is the original plus 2
        int newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;

        //the new padding is the original padding less 6 (to accomodate for the increasing font)
        int paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) -6;

        //the new feature menu font size is the original size plus 2
        int newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2)) + 2;

        //the new feature padding is the original padding less 5
        int paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) - 5;

        //20pts is the maximum font size
        if (newsizeMain > 20)
        {
            //at this point, the font size and padding remain the same as they were
            newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
            newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
        }
        //set each menu to the new size and padding
        primary_menu.Font.Size = FontUnit.Point(newsizeMain);
        primary_menu.StaticMenuItemStyle.HorizontalPadding = paddingMain;
        feature_menu.Font.Size = FontUnit.Point(newsizeFeat);
        feature_menu.StaticMenuItemStyle.HorizontalPadding = paddingFeat;

        //check if there is a submaster page and pass the eventhandler to it
        if (content_area.Page.Master.Master == this)
        {
            this.upFont(this, e);
        }

    }

    //decrease the font size by 2pts
    public void fontDec(object sender, EventArgs e)
    {
        //the new main menu font size is the original plus 2
        int newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;

        //the new padding is the original padding less 6 (to accomodate for the increasing font)
        int paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) + 6;

        //the new feature menu font size is the original size plus 2
        int newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2)) - 2;

        //the new feature padding is the original padding less 5
        int paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString()) + 5;

        //12pt is the minimum font size for the main menu
        if (newsizeMain < 12)
        {
            //at this point, the new size should remain the same as the existing size
            newsizeMain = int.Parse(primary_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingMain = int.Parse(primary_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
            newsizeFeat = int.Parse(feature_menu.Font.Size.Unit.ToString().Substring(0, 2));
            paddingFeat = int.Parse(feature_menu.StaticMenuItemStyle.HorizontalPadding.Value.ToString());
        }
        //set the menu fonts and padding to the new values
        primary_menu.Font.Size = FontUnit.Point(newsizeMain);
        primary_menu.StaticMenuItemStyle.HorizontalPadding = paddingMain;
        feature_menu.Font.Size = FontUnit.Point(newsizeFeat);
        feature_menu.StaticMenuItemStyle.HorizontalPadding = paddingFeat;

        //check if the page is using a submaster and pass through the eventhandler if it is
        if (content_area.Page.Master.Master == this)
        {
            this.downFont(this, e);
        }

    }
}
