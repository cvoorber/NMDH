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
        string xmlPath = Request.PhysicalApplicationPath + @"XMLSitemap.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        //XmlNode rootNode = doc.DocumentElement;
        //DisplayNodes(rootNode);


        XmlNodeList urlList = doc.GetElementsByTagName("url");
        otherload(urlList);
    }

    void otherload(XmlNodeList titleList)
    {
        //MenuItemCollection all = (MenuItemCollection)primary_menu.Items;
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
}
