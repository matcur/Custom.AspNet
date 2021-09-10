using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.AspNet.PagePagination
{
    public class SimplePagination : IPagination
    {
        private readonly int _min;
        
        private readonly int _current;
        
        private readonly int _max;

        public SimplePagination(int min, int current, int itemsCount, int perPage)
            : this(min, current, itemsCount / (float)perPage)
        {

        }

        public SimplePagination(int min, int current, float max)
        {
            _min = min;
            _current = current;
            _max = (int) Math.Ceiling(max);
        }

        public int Current()
        {
            return _current;
        }

        public IEnumerable<int> Pages()
        {
            if (_max == _min)
            {
                return new List<int>();
            }
            
            return Enumerable.Range(_min, _max);
        }
    }
}