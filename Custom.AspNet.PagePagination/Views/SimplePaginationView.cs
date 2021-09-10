using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Custom.AspNet.PagePagination.Views
{
    public class SimplePaginationView : IPaginationView
    {
        private readonly SimplePagination _pagination;
        
        private readonly string _currentPageFormat;

        public SimplePaginationView(SimplePagination pagination, string currentPageFormat)
        {
            _pagination = pagination;
            _currentPageFormat = currentPageFormat;
        }

        public HtmlString Presentation(string navigationClass = "", string pageClass = "")
        {
            var pagination = new TagBuilder("div");
            pagination.AddCssClass(navigationClass);
            foreach (var page in _pagination.Pages())
            {
                var anchor = new TagBuilder("a");
                
                anchor.Attributes.Add("href", string.Format(_currentPageFormat, page));
                anchor.AddCssClass(pageClass);
                anchor.InnerHtml.Append(page.ToString());
                
                pagination.InnerHtml.AppendHtml(anchor);
            }
            
            var writer = new StringWriter();
            pagination.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}