using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.Web.UI.Sheer;
using System;
using Sitecore.Foundation.Microsites;
using Sitecore.Data.Events;
using Sitecore.Diagnostics;

namespace Sitecore.Foundation.Microsites.Pipelines
{
    public class MicrositeBranchAdded
    {
        public void OnItemAdded(object sender, EventArgs args)
        {
            var createdArgs = Event.ExtractParameter(args, 0) as ItemCreatedEventArgs;

            Assert.IsNotNull(createdArgs, "args");
            if (createdArgs != null)
            {
                if (createdArgs.Item == null)
                    return;

                if (createdArgs.Item.TemplateID == Templates.MicrositeRoot.ID)
                {
                    PopupSheerSettings(createdArgs.Item);
                }
            }
        }

        private void PopupSheerSettings(Item branchRoot)
        {
            Text.UrlString parameters = new Text.UrlString();
            parameters.Add(Constants.SiteParameters.RootPath, branchRoot.ID.ToString());

            Shell.Framework.Windows.RunApplication("Site Builder",parameters.ToString());

            var branch = branchRoot.Database.GetItem(Templates.MicrositeRootBranch.ID);
            if (branch == null)
                return;

            new ReferenceReplacementJob(branch.Children[0], branchRoot).StartAsync();
        }

    }
}
