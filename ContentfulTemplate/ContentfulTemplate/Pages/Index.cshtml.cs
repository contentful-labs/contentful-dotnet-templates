using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentfulTemplate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IContentfulClient _client;

        public IndexModel(IContentfulClient client)
        {
            _client = client;
        }

        public async Task OnGet()
        {
            var qb = QueryBuilder<object>.New.Limit(5);
            Entries = await _client.GetEntries(qb);
            Assets = await _client.GetAssets();

            var imageQuery = QueryBuilder<Asset>.New.MimeTypeIs(MimeTypeRestriction.Image);

            ImageAssets = await _client.GetAssets(imageQuery);

        }

        public ContentfulCollection<object> Entries { get; set; }
        public ContentfulCollection<Asset> Assets { get; set; }
        public ContentfulCollection<Asset> ImageAssets { get; set; }
    }
}
