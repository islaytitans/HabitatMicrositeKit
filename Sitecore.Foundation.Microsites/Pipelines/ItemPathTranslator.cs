using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Microsites.Pipelines
{
    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Exceptions;

    public class ItemPathTranslator
    {
        private readonly Item _source;
        private readonly Item _sourceRoot;
        private readonly Item _target;
        private readonly Item _targetRoot;

        public ItemPathTranslator(Item source, Item target)
          : this(source, source, target, target)
        {
        }

        public ItemPathTranslator(Item source, Item sourceRoot, Item target, Item targetRoot)
        {
            Assert.ArgumentNotNull(source, "source");
            Assert.ArgumentNotNull(sourceRoot, "sourceRoot");
            Assert.ArgumentNotNull(target, "target");
            Assert.ArgumentNotNull(targetRoot, "targetRoot");
            _source = source;
            _sourceRoot = sourceRoot;
            _target = target;
            _targetRoot = targetRoot;
        }

        public bool CanTranslatePath(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            return IsDescendantOrSelf(item, _source) || IsDescendantOrSelf(item, _sourceRoot);
        }

        private bool IsDescendantOrSelf(Item item, Item otherItem)
        {
            return item.ID == otherItem.ID || item.Axes.IsDescendantOf(otherItem);
        }

        public string TranslatePath(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            if (IsDescendantOrSelf(item, _source))
            {
                var path  = GetFullPath(_target, _source, item).Replace("$name", _target.Name);
             
                return path;
                
            }

            if (IsDescendantOrSelf(item, _sourceRoot))
            {
                var path = GetFullPath(_targetRoot, _sourceRoot, item).Replace("$name", _target.Name);
              
                return path;
            }

            throw new InvalidItemException(string.Format("Item {0} is not a descendant of {1} or {2}.",
              AuditFormatter.FormatItem(item),
              AuditFormatter.FormatItem(_source),
              AuditFormatter.FormatItem(_sourceRoot)));
        }

        private string GetFullPath(Item closestEquivalentAncestor, Item closestAncestor, Item item)
        {
            string startPathPart = closestEquivalentAncestor.Paths.FullPath;
            string relativePathPart = GetRelativePath(closestAncestor, item);
            return StringUtil.EnsurePostfix('/', startPathPart) + StringUtil.RemovePrefix('/', relativePathPart);
        }

        private string GetRelativePath(Item closestAncestor, Item item)
        {
            return item.Paths.FullPath.Replace(closestAncestor.Paths.FullPath, string.Empty);
        }
    }
}
