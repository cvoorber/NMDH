using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class displayMenu_test : System.Web.UI.Page
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

    void DisplayNodes(XmlNode node)
    {
        //Print the node type, node name and node value of the node
        if (node.NodeType == XmlNodeType.Text && node.ParentNode.Name == "title")
        {
            Response.Write(node.Value + "<br />");
        }

        //Print individual children of the node, gets only direct children of the node
        XmlNodeList children = node.ChildNodes;
        foreach (XmlNode child in children)
        {
            DisplayNodes(child);
        }
    }

    void otherload(XmlNodeList titleList)
    {
        Response.Write("<ul>");
        foreach (XmlNode node in titleList)
        {
            if (node.ChildNodes[3].FirstChild.Value == "1")
            {
                Response.Write("<li>" + node.ChildNodes[2].FirstChild.Value + "</li>");
            }
            
        }

        Response.Write("</ul>");
    }
}