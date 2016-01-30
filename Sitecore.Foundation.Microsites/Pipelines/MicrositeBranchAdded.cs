using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.Web.UI.Sheer;
using System;
using Sitecore.Foundation.Microsites;

namespace Sitecore.Foundation.Microsites.Pipelines
{
    public class MicrositeBranchAdded
    {
        public void OnItemAdded(object sender, EventArgs args)
        {
            Item targetItem = Event.ExtractParameter(args, 0) as Item;
            if (targetItem == null)
                return;
            if (targetItem.Branch == null)
                return;
            if (targetItem.Branch.InnerItem.Children.Count != 1)
                return;
            Item branchRoot = targetItem.Branch.InnerItem.Children[0];

            if (branchRoot != null && branchRoot.ID == Templates.MicrositeRoot.ID)
            {
                PopupSheerSettings(branchRoot);
            }
        }

        private void PopupSheerSettings(Item branchRoot)
        {
            Text.UrlString parameters = new Text.UrlString();
            parameters.Add(Constants.RootNodeName, branchRoot.ID.ToString());

            Shell.Framework.Windows.RunApplication("Site Builder");
        }
    }
}
