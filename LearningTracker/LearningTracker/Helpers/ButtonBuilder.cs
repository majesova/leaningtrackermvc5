using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Helpers
{
    public static class ButtonBuilder
    {
        public static HtmlString Button(this HtmlHelper helper,string id, string text, string url) {
             var tag = $"<a href=\"{url}\" id = \"{id}\" class=\"btn btn-primary\">{text}</a>";
            return new HtmlString(tag);
        }
    }
}