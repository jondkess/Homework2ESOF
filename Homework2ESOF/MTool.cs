using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2ESOF
{
    class MTool: SoftwareTool
    {
        public MTool()
        {
            this.name = "MTool";
            this.setSortStrategy(Sort.Merge);
        }
    }
}
