namespace Algorithms.LeetCode
{
    using System;
    using Algorithms.Searching;
    using System.Collections;
    using System.Collections.Generic;

    class NextPermutation 
    {
        public static void Solve(int[] arr) {

            var n = arr.Length - 1;
            if (n == 0) return;

            if (arr[n] > arr[n - 1]) {
                swap(arr, n, n -1);
                return;
            }

            int j = -1;
            for( var i = n - 1; i >= 0; --i) {
                if (arr[i] < arr[i + 1]) {
                    j = i; break;
                }
            }

            if (j == -1) {
                //highest lexico order, just reverse and return
                Array.Reverse(arr);
                return;
            }

            int mindex = -1;
            int minsf = Int32.MaxValue;
            for (var i = arr.Length - 1; i > j; --i) {
                if (arr[i] < minsf && arr[i] > arr[j]) {
                    mindex = i;
                    minsf = arr[j];
                }; 
            }

            swap(arr, j, mindex);

            Array.Reverse(arr, j, arr.Length - 1);
            return;
            
            
        }

        private static void swap(int[] arr, int i, int j) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return;
        }
    }
}
