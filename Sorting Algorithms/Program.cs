using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100000];

            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(arr.Length * -1 * 2, arr.Length * 10);
            }


            int[] arrTemp1 = arr;
            int[] arrTemp2 = arr;
            int[] arrTemp3 = arr;

            DateTime start = DateTime.Now;
            Quicksort(arrTemp1, 0, arr.Length - 1);
            TimeSpan quickSortEnd = DateTime.Now - start;
            Console.WriteLine($"Quicksort tog {quickSortEnd.TotalMilliseconds} ms");

            DateTime bubbleStart = DateTime.Now;
            BubbleSort(arr);
            TimeSpan bubbleEnd = DateTime.Now - bubbleStart;
            Console.WriteLine($"Bubblesort tog {bubbleEnd.TotalMilliseconds} ms");

            DateTime insertionStart = DateTime.Now;
            InsertionSort(arrTemp2);
            TimeSpan insertionEnd = DateTime.Now - insertionStart;
            Console.WriteLine($"Insertionsort tog {insertionEnd.TotalMilliseconds} ms");

            DateTime mergeStart = DateTime.Now;
            MergeSort(arrTemp3);
            TimeSpan mergeEnd = DateTime.Now - mergeStart;
            Console.WriteLine($"Mergesort tog {mergeEnd.TotalMilliseconds} ms");
        }

        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        static void Quicksort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);

                Quicksort(arr, low, pivot - 1);
                Quicksort(arr, pivot + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;

                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }

            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }

        static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
        static int[] MergeSort(int[] arr)
        {
            int[] left;
            int[] right;
            int[] sortedArr;

            if (arr.Length <= 1)
                return arr;

            int middle = arr.Length / 2;
            left = new int[middle];

            if (arr.Length % 2 == 0)
                right = new int[middle];
            else
                right = new int[middle + 1];

            for (int i = 0; i < middle; i++)
            {
                left[i] = arr[i];
            }
            int rightIdx = 0;
            for (int i = middle; i < arr.Length; i++)
            {
                right[rightIdx] = arr[i];
                rightIdx++;
            }

            left = MergeSort(left);
            right = MergeSort(right);
            sortedArr = Merge(left, right);

            return sortedArr;
        }
        static int[] Merge(int[] left, int[] right)
        {
            int[] sortedArr = new int[right.Length + left.Length];

            int leftIdx = 0;
            int rightIdx = 0;
            int sortedIdx = 0;
            while (left.Length > leftIdx || right.Length > rightIdx)
            {
                if (left.Length > leftIdx && right.Length > rightIdx)
                {
                    if (left[leftIdx] <= right[rightIdx])
                    {
                        sortedArr[sortedIdx] = left[leftIdx];
                        leftIdx++;
                        sortedIdx++;
                    }
                    else
                    {
                        sortedArr[sortedIdx] = right[rightIdx];
                        rightIdx++;
                        sortedIdx++;
                    }
                }
                else if (left.Length > leftIdx)
                {
                    sortedArr[sortedIdx] = left[leftIdx];
                    leftIdx++;
                    sortedIdx++;
                }
                else if (right.Length > rightIdx)
                {
                    sortedArr[sortedIdx] = right[rightIdx];
                    rightIdx++;
                    sortedIdx++;
                }
            }
            return sortedArr;
        }
    }
}
