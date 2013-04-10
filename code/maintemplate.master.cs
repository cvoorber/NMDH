﻿using System;
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

        if (content_area.Page.Master.Master == this)
        {
            this.upFont(this, e);
        }

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


        if (content_area.Page.Master.Master == this)
        {
            this.downFont(this, e);
        }

        this.downFont(this, e);

    }

    protected void subSearch(Object sender, EventArgs e)
    {
        if (txt_search.Text == "")
        {
            Response.Redirect("search.aspx");
        }
        else
        {
            string newQuery = txt_search.Text.Replace(" ","+");
            Response.Redirect("search.aspx?query=" + newQuery);
        }
    }
}
