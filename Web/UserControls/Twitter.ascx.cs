using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

using LiveFreeRange.Operational;
using System.Xml;
using System.Data;
using System.IO;

public partial class UserControls_Twitter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = "simonbegg";
        string password = "techn0l0gy";

        DataSet ds = new DataSet();
        
        Twitter twitter = new Twitter();

        XmlDocument xmlDoc = twitter.GetUserTimelineAsXML(userName, password, "simonbegg", Twitter.OutputFormatType.XML);

        var query = (from c in xmlDoc.DocumentElement.ChildNodes.Cast<XmlNode>()
                    select c.SelectSingleNode("text").InnerXml).Take(2);



        XmlTextReader xtr = new XmlTextReader(new StringReader(xmlDoc.OuterXml));

        XElement xe = XElement.Load(xtr);

        string tweets = String.Empty;

        var foo = (from c in xe.Elements("status")
                  select c.Element("text")).First();

        foreach (string tweet in query)
            tweets += tweet + "<br />";


        this.litTweet.Text = foo.ToString();
        this.litTweetHeader.Text = "Latest tweets from talamh";
    }
}
