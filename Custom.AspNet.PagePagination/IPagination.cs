using System.Collections.Generic;

namespace Custom.AspNet.PagePagination
{
    public interface IPagination
    {
        int Current();
        
        IEnumerable<int> Pages();
    }
}