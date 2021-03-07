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
            int[] arr = new int[7];

            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(arr.Length * -1 * 2, arr.Length * 10);
            }



            
            int[] arrTemp1 = new int[arr.Length];
            int[] arrTemp2 = new int[arr.Length];
            int[] arrTemp3 = new int[arr.Length];


            Array.Copy(arr, arrTemp1, arr.Length);
            Array.Copy(arr, arrTemp2, arr.Length);
            Array.Copy(arr, arrTemp3, arr.Length);

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
            Sort(arrTemp3, 0, arrTemp3.Length - 1);
            TimeSpan mergeEnd = DateTime.Now - mergeStart;
            Console.WriteLine($"Mergesort tog {mergeEnd.TotalMilliseconds} ms");


            foreach (int a in arrTemp3)
            {
                Console.WriteLine(a);
            }
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
        static void Merge(int[] arr, int leftLength, int middle, int rightLength)
        {
            int start = middle - leftLength + 1;
            int end = rightLength - middle;
            int leftIdx = 0;
            int rightIdx = 0;
            int arrIdx = leftLength;

            int[] left = new int[start];
            int[] right = new int[end];

            for (int i = 0; i < start; i++)
            {
                left[i] = arr[leftLength + i];
            }
            for (int i = 0; i < end; i++)
            {
                right[i] = arr[middle + i + 1];
            }

            while (leftIdx < start && rightIdx < end)
            {
                if (left[leftIdx] <= right[rightIdx])
                {
                    arr[arrIdx] = left[leftIdx];
                    leftIdx++;
                }
                else
                {
                    arr[arrIdx] = right[rightIdx];
                    rightIdx++;
                }
                arrIdx++;
            }

            while (leftIdx < start)
            {
                arr[arrIdx] = left[leftIdx];
                leftIdx++;
                arrIdx++;
            }

            while (rightIdx < end)
            {
                arr[arrIdx] = right[rightIdx];
                rightIdx++;
                arrIdx++;
            }
        }

        static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                Sort(arr, left, middle);
                Sort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }
    }
}

