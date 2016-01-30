using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.Web.UI.Sheer;
using System;

namespace Sitecore.Foundation.Microsite.Pipelines
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

            if (branchRoot != null && branchRoot.ID == Constants.RootTemplateID)
            {
                PopupSheerSettings(branchRoot);
            }
        }

        private void PopupSheerSettings(Item branchRoot)
        {
            string baseUrl = Constants.SiteBuilderPath;
            SheerResponse.ShowModalDialog(string.Format("{0}?{1}=(2)", baseUrl,Constants.RootNodeName,branchRoot.ID.ToString()));
        }
    }
}
