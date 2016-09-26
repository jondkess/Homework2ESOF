using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2ESOF
{
    abstract class SoftwareTool
    {
        Sort sort;
        public String name;
        public void mathSort()
        {
            
            switch (sort)
            {
                case Sort.Bubble:

                    break;
                case Sort.Insert:

                    break;
                case Sort.Merge:

                    break;
            }
        }

        public void setSortStrategy(Sort setSort)
        {
            sort = setSort;
        }

        public Sort Default
        {
            get { return sort; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
