using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitecore.Habitat.Microsites.Dialogs
{
    public partial class SiteBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateSite_Click(object sender, EventArgs e)
        {
            var rootNode = Request.QueryString[Foundation.Microsites.Constants.RootNodeName];
            if(!string.IsNullOrEmpty(rootNode))
            {
               var rootNodeMaster =  Configuration.Factory.GetDatabase("master").GetItem(rootNode);
                if(rootNodeMaster != null)
                {
                    using (new SecurityModel.SecurityDisabler())
                    {
                        rootNodeMaster.Editing.BeginEdit();
                        try
                        {
                            var values = new NameValueCollection();
                            values.Add("name", txtname.Text);
                            values.Add("hostname", txtHostname.Text);
                            values.Add("rootPath", txtRootPath.Text);
                            values.Add("startItem", txtStartItem.Text);
                            values.Add("language", txtLanguage.Text);
                            values.Add("content", txtContent.Text);
                            rootNodeMaster[Foundation.Microsites.Templates.MicrositeRoot.Fields.SiteParameters] = StringUtil.NameValuesToString(values, " &");
                        }
                        finally
                        {
                            rootNodeMaster.Editing.EndEdit();
                        }
                    }
                }

            }
        }
    }
}