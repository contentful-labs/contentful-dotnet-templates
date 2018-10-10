using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContentfulTemplateMvc.Models;
using Contentful.Core;
using Contentful.Core.Search;
using Contentful.Core.Models;

namespace ContentfulTemplateMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentfulClient _client;

        public HomeController(IContentfulClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexModel();

            var qb = QueryBuilder<object>.New.Limit(5);
            model.Entries = await _client.GetEntries(qb);
            model.Assets = await _client.GetAssets();

            var imageQuery = QueryBuilder<Asset>.New.MimeTypeIs(MimeTypeRestriction.Image);

            model.ImageAssets = await _client.GetAssets(imageQuery);

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
