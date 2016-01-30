using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Microsites
{
    public class StyleCache
    {
        private static Dictionary<string, StyleCache> _caches;

        private StyleCache() { }

        public static StyleCache Instance
        {
            get
            {
                if (Context.Site == null)
                    return null;

                if (_caches == null)
                    _caches = new Dictionary<string, StyleCache>();

                return SiteSpecificCache;
            }
        }

        private static StyleCache SiteSpecificCache
        {
            get
            {
                if (!_caches.ContainsKey(Context.Site.Name))
                {
                    var rootItem = Sitecore.Context.Database.GetItem(Context.Site.RootPath);

                    var cache = new StyleCache()
                    {
                        BackgroundColor = rootItem[Templates.MicrositeRoot.Fields.SiteBackgroundColour],
                        TextColor = rootItem[Templates.MicrositeRoot.Fields.SiteTextColour]
                    };

                    _caches.Add(Context.Site.Name, cache);
                } 

                return _caches[Context.Site.Name];
            }
        }

        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
    }
}
