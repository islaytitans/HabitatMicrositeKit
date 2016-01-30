using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Foundation.Microsites;

namespace Sitecore.Habitat.Microsites.Dialogs
{
    public partial class SiteBuilder : System.Web.UI.Page
    {
        private const string DatabaseName = "master";

        protected void Page_Load(object sender, EventArgs e)
        {
            var rootNode = Request.QueryString[Foundation.Microsites.Constants.RootNodeName];
            if (!string.IsNullOrEmpty(rootNode))
            {
                var rootNodeMaster = Configuration.Factory.GetDatabase(DatabaseName).GetItem(rootNode);
                lblSite.Text = rootNodeMaster.Name;

                txtLanguage.Text = rootNodeMaster[Templates.MicrositeRoot.Fields.SiteLanguage];
                txtDatabase.Text = rootNodeMaster[Templates.MicrositeRoot.Fields.SiteDatabase];
                txtBgColour.Text = rootNodeMaster[Templates.MicrositeRoot.Fields.SiteBackgroundColour];
                txtTextColor.Text = rootNodeMaster[Templates.MicrositeRoot.Fields.SiteTextColour];
            }
        }

        protected void btnCreateSite_Click(object sender, EventArgs e)
        {
            var rootNode = Request.QueryString[Foundation.Microsites.Constants.RootNodeName];
            if (!string.IsNullOrEmpty(rootNode))
            {
                var rootNodeMaster = Configuration.Factory.GetDatabase(DatabaseName).GetItem(rootNode);
                if (rootNodeMaster != null)
                {
                    using (new SecurityModel.SecurityDisabler())
                    {
                        rootNodeMaster.Editing.BeginEdit();
                        try
                        {
                            rootNodeMaster[Templates.MicrositeRoot.Fields.SiteLanguage] = txtLanguage.Text;
                            rootNodeMaster[Templates.MicrositeRoot.Fields.SiteDatabase] = txtDatabase.Text;

                            rootNodeMaster[Templates.MicrositeRoot.Fields.SiteBackgroundColour] = txtBgColour.Text;
                            rootNodeMaster[Templates.MicrositeRoot.Fields.SiteTextColour] = txtTextColor.Text;

                            panelForm.Visible = false;
                            panelUpdated.Visible = true;
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