namespace Algorithms.Searching
{
    using System;
    using System.Collections;

    class Search
    {
        public Search() {
            return;
        }

        public void Hi() {
            Console.WriteLine("Hi from object");
        }

        /*
         * Returns the index that val would belong in a sorted array arr
         */
        public static int BinarySearch<T> (T[] arr, T val) where T: IComparable 
        {
            int n = arr.Length;

            if (n == 0) {
                //val will not be in an empty array, and the correct position for inserting is index 0; hence, return -1;
                return -1;
            }

            int low = 0; int high = n-1; int mid = (high + low) / 2;

            while (high - low > 1) {
                int comparison = val.CompareTo(arr[mid]);
                if (comparison == 0) {
                    return mid;
                }

                if (comparison > 0) 
                {
                    low=mid;
                }
                else 
                {
                    high = mid;
                }

                mid = (high + low) / 2;
            }

            if (val.CompareTo(arr[high]) == 0) return high; 
            if (val.CompareTo(arr[low]) == 0) return low; 
            if (val.CompareTo(arr[high]) > 0) {
                //larger than the entire array
                return -1 * (high + 1) - 1;
            }
            if (val.CompareTo(arr[low]) < 0) {
                //smaller than the entire array
                return -1 * low - 1;
            }
            else 
            {
                //val is between higher and lower
                return (-1 * high) - 1;
            }
            
        }
    }
}
