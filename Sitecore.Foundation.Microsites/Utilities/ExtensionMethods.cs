using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;

namespace Sitecore.Foundation.Microsites.Utilities
{
    public static class ExtensionMethods
    {
        internal static bool ContainsKeyWithValue(this StringDictionary p, string key)
        {
            return p.ContainsKey(key) && !string.IsNullOrEmpty(p[Constants.SiteParameters.SiteName]);
        }

        public static bool IsStandardTemplateField(this Field f)
        {
           Template template =TemplateManager.GetTemplate(Configuration.Settings.DefaultBaseTemplate, f.Database);

            Assert.IsNotNull(template, "template");

            return template.ContainsField(f.ID);
        }
    }
}
