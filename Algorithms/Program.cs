namespace Algorithms
{
    using Algorithms.Searching;
    using Algorithms.HackerRank;
    using Algorithms.DataStructures;
    using Algorithms.EPI;
	using System.CodeDom.Compiler;
	using System.Collections.Generic;
	using System.Collections;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Serialization;
	using System.Text.RegularExpressions;
	using System.Text;
    using System;

    class Program
    {
        internal const string test = "hello world";

        static void Main(string[] args)
        {

            int[] testcase = new int[] {1,5,5,5,5,5,5,5,5,1,5,5,5,5};
            Print(testcase);
            DNF(testcase,5);
            Print(testcase);
        }

        static void DNF(int[] a, int k) {
            int i=0, kloc=0, j=0;

            for (i = 0; i < a.Length; ++i) {
                if (a[i] < k) {
                    swap(a, i, j);
                    swap(a, j, kloc);
                    kloc++;
                    j++;
                } 
                else if (a[i] == k) {
                    swap(a, j, i);
                    j++;
                }
            }
        }

        private static void swap(int[] arr, int i, int j) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return;
        }
 
        static void Print(int[] arr) {
            for (var i = 0; i < arr.Length; ++i){ 
                Console.Write(String.Format("{0}, ", arr[i]));
            }

            Console.WriteLine();
        }

    }
}
