using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Microsites
{
    public class Constants
    {
        public const string SiteBuilderPath = "/Dialogs/SiteBuilder.aspx";
        public const string RootNodeName = "rootNode";

        public struct SiteParameters
        {
            public static readonly string SiteName = "siteName";
            public static readonly string RootPath = "rootPath";
            public static readonly string HostName = "hostName";
            public static readonly string StartItem = "startItem";
            public static readonly string Domain = "domain";
            public static readonly string Database = "database";
            public static readonly string Language = "Language";
        }
    }
}
