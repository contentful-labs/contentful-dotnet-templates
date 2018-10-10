using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulTemplateMvc.Models
{
    public class IndexModel
    {
        public ContentfulCollection<object> Entries { get; set; }
        public ContentfulCollection<Asset> Assets { get; set; }
        public ContentfulCollection<Asset> ImageAssets { get; set; }
    }
}
