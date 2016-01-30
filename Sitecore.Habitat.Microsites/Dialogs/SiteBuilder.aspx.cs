using Sitecore.Data.Fields;
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
            var rootNode = Request.QueryString[Foundation.Microsites.Constants.RootNodeName];
            if (!string.IsNullOrEmpty(rootNode))
            {
                var rootNodeMaster = Configuration.Factory.GetDatabase("master").GetItem(rootNode);
                lblSite.Text = rootNodeMaster.Name;

                txtLanguage.Text = rootNodeMaster["Language"];
                txtDatabase.Text = rootNodeMaster["Database"];
                txtBgColour.Text = rootNodeMaster["Background color"];
                txtTextColor.Text = rootNodeMaster["Text color"];
            }
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
                            rootNodeMaster["Language"] = txtLanguage.Text;
                            rootNodeMaster["Database"] = txtDatabase.Text;

                            rootNodeMaster["Background color"] = txtBgColour.Text;
                            rootNodeMaster["Text color"] = txtTextColor.Text;

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