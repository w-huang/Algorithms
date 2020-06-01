namespace Algorithms.HackerRank
{
    using System;
    using Algorithms.Searching;

    class ClimbingTheLeaderboard
    {
        public static int[] solve(int[] scores, int[] alice) {
			int[] ans = new int[alice.Length];
			int[] ranks = new int[scores.Length];

			var currentRank = 1;
			for (var i = scores.Length - 1; i >= 0; --i) {
				if (i == scores.Length - 1) 
				{
					ranks[i] = currentRank;
					continue;
				} 
				else if (scores[i] == scores[i+1]) {
					ranks[i] = currentRank;
					continue;
				} else {
					ranks[i] = ++currentRank;
				}
			}

            Console.WriteLine(String.Format("{0}", string.Join(", ", ranks)));

			//perform binary search for each input of alice
			//j = -index - 1 => index = - (j + 1)
			for (var i = 0; i < alice.Length; ++i) {
				var j = Search.BinarySearch<int>(scores, alice[i]);
                Console.WriteLine(j);

                if (j >= 0) {
                    //found
                    ans[i] = ranks[j];
                }
                else {
                    //not found
                    j = -1 * (j + 1); //convert j

                    if (j == 0) ans[i] = ranks[0] + 1; //lowest rank possible
                    else if (j == scores.Length) ans[i] = 1; //highest rank possible
                    else ans[i] = ranks[j-1]; //takes the rank of the preceeding element

                }

			}

			return ans; 
        } 
    }
}

