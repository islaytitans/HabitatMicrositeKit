using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Sites;
using StringDictionary = Sitecore.Collections.StringDictionary;

namespace Sitecore.Foundation.Microsites.Providers
{
    public class DynamicMicrositesProvider : ConfigSiteProvider
    {
        private object _lock = new object();
        private SafeDictionary<string, Site> _siteDictionary;
        private SiteCollection _sitesCollection;
        public string DatabaseName { get; set; }
        protected readonly Sitecore.Sites.SiteProvider siteProvider;

        public DynamicMicrositesProvider(Sitecore.Sites.SiteProvider implementation)
        {
            Assert.IsNotNull(implementation, "implementation");

            siteProvider = implementation;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            siteProvider.Initialize(name, config);
        }

        public override Site GetSite(string siteName)
        {
            Assert.IsNotNullOrEmpty(siteName, "siteName");

            InitializeSites();

            Site site;

            if (_siteDictionary.TryGetValue(siteName, out site))
            {
                site = siteProvider.GetSite(siteName);
            }
            else
            {
                site = base.GetSite(siteName);
            }

            return site;
        }

        public override SiteCollection GetSites()
        {
            InitializeSites();

            var sitesCollection = new SiteCollection();

            // Add dynamic sites
            sitesCollection.AddRange(_sitesCollection);

            // Add configured sites
            sitesCollection.AddRange(base.GetSites());

            return sitesCollection;
        }

        private void InitializeSites()
        {
            Database database = Factory.GetDatabase(DatabaseName, false);
            if (database == null)
                return;

            if (_siteDictionary != null)
                return;

            lock (_lock)
            {
                if (_siteDictionary != null)
                    return;

                var sitesCollection = new SiteCollection();
                var siteDictionary = new SafeDictionary<string, Site>(StringComparer.InvariantCultureIgnoreCase);

                foreach (Item siteItem in GetSiteDeinitionItems(database))
                {
                    Site site = ResolveSite(siteItem);

                    if (site != null)
                    {
                        siteDictionary[site.Name] = site;
                        sitesCollection.Add(site);
                    }
                }

                _sitesCollection = sitesCollection;
                _siteDictionary = siteDictionary;
            }
        }

        public virtual IEnumerable<Item> GetSiteDeinitionItems(Database database)
        {
            if (database == null)
            {
                Log.Error("Failed to get sites in method GetSiteDeinitionItems in DynamicSiteProvider, database was null", this);
                return null;
            }

            var siteItems = new List<Item>();

            Item contentRoot = database.GetItem(Sitecore.ItemIDs.ContentRoot);
            if (contentRoot == null)
                return null;

            var siteRoots =
                contentRoot.GetChildren(ChildListOptions.SkipSorting)
                    .Where(i => i.TemplateID.Equals(Templates.MicrositeRoot.ID));

            siteItems.AddRange(siteRoots);

            return siteItems;
        }

        public virtual Site ResolveSite(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            Site site = null;

            if (IsValidSiteName(item[Templates.MicrositeRoot.Fields.SiteName]))
            {
                var properties = GetSiteProperties(item);

                if (AssertMandatoryProperties(properties))
                {
                    site = new Site(item[Templates.MicrositeRoot.Fields.SiteName], properties);
                }
            }

            return site;
        }

        private bool AssertMandatoryProperties(StringDictionary properties)
        {
            return (properties.ContainsKey("siteName")
                    && properties.ContainsKey("virtualFolder")
                    && properties.ContainsKey("physicalFolder")
                    && properties.ContainsKey("rootPath")
                    && properties.ContainsKey("startItem")
                    && properties.ContainsKey("domain")
                    && properties.ContainsKey("database"));
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private bool IsValidSiteName(string siteName)
        {
            Assert.ArgumentNotNullOrEmpty(siteName, "siteName");

            bool valid = false;

            try
            {
                string validName = Factory.CreateObject("cacheSizes/sites/" + siteName, false) as string;
                valid =  true;
            }
            catch (Exception e)
            {
                Log.Error("Site " + siteName + "is an invalid site name. Not adding it to Site collection", this);
                valid = false;
            }

            return valid;
        }

        private StringDictionary GetSiteProperties(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            Assert.IsNotNull(item.Fields[Templates.MicrositeRoot.Fields.SiteParameters], "item field SiteParameters");

            NameValueListField siteParametersField = item.Fields[Templates.MicrositeRoot.Fields.SiteParameters];

            var properties = new StringDictionary();

            foreach (string key in siteParametersField.NameValues)
            {
                properties.Add(key, HttpUtility.UrlDecode(siteParametersField.NameValues[key]));
            }

            return properties;
        }
    }
}
