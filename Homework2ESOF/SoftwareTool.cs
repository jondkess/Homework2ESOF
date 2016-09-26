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
            if (arrToSort.Length <= 1)
            {
                return arrToSort;
            }

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
            if (arrToSort.Length <= 1)
            {
                return arrToSort;
            }

            for (int i = 1; i < arrToSort.Length; i++)
            {
                int j = i;

                while((j>0) && (arrToSort[j] < arrToSort[j - 1]))
                {
                    int k = j - 1;
                    int temp = arrToSort[k];
                    arrToSort[k] = arrToSort[j];
                    arrToSort[j] = temp;

                    j--;
                }
            }
            return arrToSort;
        }

        public int[] mergeSort(int[] arrToSort)
        {
            if (arrToSort.Length <= 1)
            {
                return arrToSort;
            }

            int middle = arrToSort.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arrToSort.Length - middle];

            Array.Copy(arrToSort, left, middle);
            Array.Copy(arrToSort, middle, right, 0, right.Length);

            left = mergeSort(left);
            right = mergeSort(right);

            return merge(left, right);
        }

        public static int[] merge(int[] left, int[] right)
        {
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> resultList = new List<int>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0] <= rightList[0])
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }

                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }

                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }

                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            int[] result = resultList.ToArray();
            return result;
        }
    }
}
