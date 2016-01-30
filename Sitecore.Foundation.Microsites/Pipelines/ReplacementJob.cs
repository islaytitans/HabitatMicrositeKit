using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Microsites.Pipelines
{
    using Sitecore;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Data.Query;
    using Sitecore.Diagnostics;
    using Sitecore.Jobs;
    using System.Collections.Generic;
    using System.Linq;

    public class ReferenceReplacementJob
    {
        private readonly Item _source;
        private readonly Item _target;

        public ReferenceReplacementJob(Item source, Item target)
        {
            Assert.ArgumentNotNull(source, "source");
            Assert.ArgumentNotNull(target, "target");
            _source = source;
            _target = target;
        }

        public void StartAsync()
        {
            string jobCategory = typeof(ReferenceReplacementJob).Name;
            string siteName = Context.Site == null ? "No Site Context" : Context.Site.Name;
            JobOptions jobOptions = new JobOptions(GetJobName(), jobCategory, siteName, this, "Start");
            JobManager.Start(jobOptions);
        }

        private string GetJobName()
        {
            return string.Format("Resolving item references between source {0} and target {1}.", AuditFormatter.FormatItem(_source), AuditFormatter.FormatItem(_target));
        }

        public void Start()
        {
            ItemPathTranslator translator = new ItemPathTranslator(_source, _target);
            IEnumerable<Item> sourceDescendants = GetDescendantsAndSelf(_source);
            ItemReferenceReplacer replacer = InitializeReplacer(sourceDescendants, translator);
            foreach (Item equivalentTarget in replacer.OtherItems)
            {
                replacer.ReplaceItemReferences(equivalentTarget);
            }
        }

        private IEnumerable<Item> GetDescendantsAndSelf(Item source)
        {
            return Query.SelectItems("descendant-or-self::*", source) ?? Enumerable.Empty<Item>();
        }

        private ItemReferenceReplacer InitializeReplacer(IEnumerable<Item> sourceDescendants, ItemPathTranslator translator)
        {
            ItemReferenceReplacer replacer = new ItemReferenceReplacer(ExcludeStandardSitecoreFieldsExceptLayout);
            foreach (Item sourceDescendant in sourceDescendants)
            {
                if (!translator.CanTranslatePath(sourceDescendant))
                    continue;

                Item equivalentTarget = sourceDescendant.Database.GetItem(translator.TranslatePath(sourceDescendant));
                if (equivalentTarget == null)
                    continue;

                replacer.AddItemPair(sourceDescendant, equivalentTarget);
            }
            return replacer;
        }

        private bool ExcludeStandardSitecoreFieldsExceptLayout(Field field)
        {
            Assert.ArgumentNotNull(field, "field");
            return field.ID == FieldIDs.LayoutField || !field.Name.StartsWith("__");
        }
    }
}
