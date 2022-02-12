using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechSolutionsApplication.Models
{
    public class NewViewEngine : RazorViewEngine
    {

        private static readonly string[] NEW_PARTIAL_VIEW_FORMATS = new[] {
      "~/Views/Query/{0}.cshtml","~/Views/Categories/{0}.cshtml" };

        public NewViewEngine()
        {
            // Keep existing locations in sync
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NEW_PARTIAL_VIEW_FORMATS).ToArray();
        }
    }
}