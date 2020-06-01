namespace Algorithms
{
    using System;
    using Algorithms.Searching;
    using Algorithms.HackerRank;

    class Program
    {
        static void Main(string[] args)
        {
            var search = new Search();

            int[] scores = new int[] {10, 20, 40, 40, 50, 100, 100};
			int[] alice = new int[] {5, 25, 50, 120};
			
			var ans = ClimbingTheLeaderboard.solve(scores, alice);
            Console.WriteLine(String.Format("{0}", string.Join(", ", ans)));

        }
    }
}
