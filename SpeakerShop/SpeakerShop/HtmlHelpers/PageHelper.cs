using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SpeakerShop.Models;

namespace SpeakerShop.HtmlHelpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder link = new StringBuilder();
            for(int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag_a = new TagBuilder("a");
                tag_a.MergeAttribute("href", pageUrl(i));
                tag_a.InnerHtml = i.ToString();
                if(i == pageInfo.CurrentPage)
                {
                    tag_a.AddCssClass("selected_page_link");
                }
                tag_a.AddCssClass("other_page_link");
                link.Append(tag_a.ToString());
            }
            return MvcHtmlString.Create(link.ToString());
        }
    }
}