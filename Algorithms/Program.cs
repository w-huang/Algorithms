namespace Algorithms
{
    using Algorithms.Searching;
    using Algorithms.Sorting;
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
			string S = "0101100011";
            
			int[] pre = new int[S.Length];
			int[] post = new int[S.Length];
			
			pre[0] = S[0] == '1' ? 1 : 0;
			post[S.Length - 1] = S[0] == '0' ? 1 : 0;
			
			for (var i = 1; i < S.Length; ++i) {
				pre[i] = pre[i-1];
				post[S.Length - 1 - i] = post[S.Length - i];
				
				
				if (S[i] == '1') pre[i]++;
				if (S[S.Length - 1 - i] == '0') post[S.Length - 1 - i]++;
			}
			
			int min = Int32.MaxValue;
			for (var i = 0; i < pre.Length; ++i) {
				if (pre[i] + post[i] < min) min = pre[i]+post[i];
			}

			Console.WriteLine("Prefix");
			Print(pre);

			Console.WriteLine("PostFix");
			Print(post);
			
			Console.WriteLine(min - 1);

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



    public class Solution {
        public int counter;
        public bool solvable;
        public int[] FindOrder(int numCourses, int[][] pre) {
            this.counter = numCourses;
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            List<int>[] adj = new List<int>[numCourses];

            for(var i = 0; i < adj.Length; ++i) {
                adj[i] = new List<int>();
            }

            foreach(var edge in pre) {
                adj[pre[0]].Add(pre[1]);
            }

            int[] visited = new int[numCourses];

            for (var i = 0; i < numCourses; ++i) {
                if (visited[i] != 0) continue;
                if (!this.solvable) break;

                toposort(adj, map, visited, i);
            }


            if (!solvable) return new int[] {};

            int[] result = new int[numCourses];

            foreach (var kvp in map) {
                result[kvp.Value - 1] = kvp.Key;
            }

            return result;
        }

        public void toposort(
                List<int>[] adj, 
                Dictionary<int, int> map,
                int[] visited,
                int curr
        ) {
            if (visited[curr] == 1 || this.solvable == false) {
                this.solvable = false;
                return;
            }
            visited[curr] = 1;


            foreach (int next in adj[curr]) {
                toposort(adj, map, visited, next);
            }

            map.Add(curr, this.counter);
            counter--;
            visited[curr] = 2;
        }


    }



































    

}

