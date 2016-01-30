using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace Sitecore.Foundation.Microsite
{
    public class Templates
    {
        public struct MicrositeRoot
        {
            public static ID ID = new ID("{5432A264-88F9-41F2-92FB-3A0C8327F8C4}");

            public struct Fields
            {
                public static readonly ID SiteParameters = new ID("{BC758BC7-CD11-460C-BE27-8C6A7C83A2B2}");
                public static readonly ID SiteName = new ID("{6E4E7EE0-6C8E-475A-B460-A551F07E8A06}");
            }
        }
    }
}
