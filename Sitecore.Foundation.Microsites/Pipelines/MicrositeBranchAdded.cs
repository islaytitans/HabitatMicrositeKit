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
                if (createdArgs.Item.Branch == null)
                    return;
                if (createdArgs.Item.Branch.InnerItem.Children.Count != 1)
                    return;
                Item branchRoot = createdArgs.Item.Branch.InnerItem.Children[0];

                if (branchRoot != null && branchRoot.ID == Templates.MicrositeRoot.ID)
                {
                    PopupSheerSettings(branchRoot);
                }
            }
        }

        private void PopupSheerSettings(Item branchRoot)
        {
            Text.UrlString parameters = new Text.UrlString();
            parameters.Add(Constants.RootNodeName, branchRoot.ID.ToString());

            Shell.Framework.Windows.RunApplication("Site Builder",parameters.ToString());
        }
    }
}
