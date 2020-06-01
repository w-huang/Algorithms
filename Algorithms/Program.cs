namespace Algorithms
{
    using Algorithms.Searching;
    using Algorithms.HackerRank;
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
        static void Main(string[] args)
        {
			string[] nk = Console.ReadLine().Split(' ');

			int n = Convert.ToInt32(nk[0]);

			int k = Convert.ToInt32(nk[1]);

			string[] r_qC_q = Console.ReadLine().Split(' ');

			int r_q = Convert.ToInt32(r_qC_q[0]);

			int c_q = Convert.ToInt32(r_qC_q[1]);

			int[][] obstacles = new int[k][];

			for (int i = 0; i < k; i++) {
				obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
			}

			int result = QueensAttack.solve(n, k, r_q, c_q, obstacles);

			Console.WriteLine(result);

        }
    }
}
