using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace Custom.AspNet.PagePagination.Views
{
    public interface IPaginationView
    {
        HtmlString Presentation(string navigationClass = "", string pageClass = "");
    }
}