namespace Algorithms
{
    using Algorithms.Searching;
    using Algorithms.HackerRank;
    using Algorithms.DataStructures;
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
            var myHeap = new BinaryHeap<int>(new int[] {5, 1, 2, 4, 2, 3}, true);   

            myHeap.Add(-40);
            myHeap.Add(-100);
            myHeap.Add(400);

        }
    }
}
