using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRight
{
    class DataRecord
    {
        public Dictionary<char, int> counts;
        public int total;

        public DataRecord()
        {
            total = 0;
            counts = new Dictionary<char, int>();
        }
    }
}
