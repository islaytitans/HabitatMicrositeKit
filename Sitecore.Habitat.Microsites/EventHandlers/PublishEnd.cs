using Sitecore.Foundation.Microsites.Providers;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Habitat.Microsites.EventHandlers
{
    public class PublishEnd
    {
        public void ClearDynamicSites(object sender, EventArgs args)
        {
            var provider = (DynamicMicrositesProvider)SiteManager.Providers["dynamic"];
            if (provider != null)
                provider.Clear();
            else
                Diagnostics.Log.Error("Could not find dynamic site provider.", this);
        }
    }
}