namespace MvcApplication.Helpers
{
    using Models;
    using System;
    using System.Text;
    using System.Web.Mvc;

    public static class PagingHelper
    {
        public static MvcHtmlString Paging(this HtmlHelper html, int a, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= a; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}