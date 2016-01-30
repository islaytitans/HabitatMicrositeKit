using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Sites;

namespace Sitecore.Foundation.Microsite.Providers
{
    public class DynamicSitesProvider : Sitecore.Sites.SiteProvider
    {
        public override Site GetSite(string siteName)
        {
            throw new NotImplementedException();
        }

        public override SiteCollection GetSites()
        {
            throw new NotImplementedException();
        }
    }
}
