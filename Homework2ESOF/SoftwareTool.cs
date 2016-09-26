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
        public int[] mathSort(int[] arr)
        {
            int[] sortedArr;

            switch (sort)
            {
                case Sort.Bubble:
                  sortedArr = this.bubbleSort(arr);
                    break;
                case Sort.Insert:
                    sortedArr = this.insertSort(arr);
                    break;
                case Sort.Merge:
                    sortedArr = this.mergeSort(arr);
                    break;
                default:
                    throw new Exception("Sort method not specified");
            }

            return sortedArr;
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

        public int[] bubbleSort(int[] arrToSort)
        {
            Boolean isChanged = false;
            int a;
            int b;
            var tempList = arrToSort;
            do
            {
                isChanged = false;
                for (int i = 1; i < arrToSort.Count(); i++)
                {
                    a = arrToSort[i - 1];
                    b = arrToSort[i];

                    if (a > b)
                    {
                        arrToSort[i - 1] = b;
                        arrToSort[i] = a;
                        isChanged = true;
                    }
                }
            } while (isChanged == true);

            return arrToSort;
        }

        public int[] insertSort(int[] arrToSort)
        {
            return arrToSort;
        }

        public int[] mergeSort(int[] arrToSort)
        {
            return arrToSort;
        }
    }
}
