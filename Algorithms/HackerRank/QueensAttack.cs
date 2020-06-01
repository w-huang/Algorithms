// https://www.hackerrank.com/challenges/queens-attack-2/problem
namespace Algorithms.HackerRank
{
    using System;
    using Algorithms.Searching;

    class QueensAttack 
    {
		/*
         * inputs:
         * n: size of chess board
         * k: number of obstacles
         * rq: row of queen
         * cq: column of queen
         * obstacles: 2xk array of ro_i and co_i 
         *
         * output: number of tiles the queen can reach
         * 
         * Idea: we calculate how far the queen can go in each direction assuming no obstacles.
         * Then, we iterate through the obstacles and for each that alignts with a direction, we reduce the amount for that direction. 
         * If two obstacles are aligned, we will always take the closer one by greedily choosing the minimal possible distance the queen can go
         */
		public static int solve(int n, int k, int rq, int cq, int[][] obstacles) {
            int[][] ordinalDirections = new int[][] {
                new int[] {0,1},  // 0
                new int[] {1,0},  // 1
                new int[] {0,-1}, // 2
                new int[] {-1,0}, // 3
                new int[] {1,1},  // 4 
                new int[] {1,-1}, // 5
                new int[] {-1,1}, // 6
                new int[] {-1,-1},// 7
            };

            int[] traversable = {
                n - rq,
                n - cq,
                rq - 1,
                cq - 1,
                Math.Min(n-rq, n-cq),
                Math.Min(n-cq, rq - 1),
                Math.Min(cq-1, n-rq),
                Math.Min(cq-1, rq-1)
            };
			Console.WriteLine(string.Join(", ", traversable));

            foreach (int[] obstacle in obstacles) {
                int[] delta = new int[] { obstacle[1] - cq, obstacle[0] - rq };    

                int ordinalDirection = getOrdinalDir(delta);
                if (ordinalDirection > -1) { 
                    traversable[ordinalDirection] = Math.Min(traversable[ordinalDirection], Math.Max(Math.Abs(delta[0]) - 1, Math.Abs(delta[1]) - 1));
                }
            }

			Console.WriteLine(string.Join(", ", traversable));

            var ans = 0;
            foreach (int distance in traversable) {
                ans += distance;
            }

            return ans;
		}

        //returns int representing which of the ordinalDirections the vector is along.
        //returns -1 if it does not match any of the ordinaldir's
        private static int getOrdinalDir(int[] vector) {
            if (vector[0] == 0) {
                return vector[1] > 0 ? 0 : 2;
            }

            if (vector[1] == 0) {
                return vector[0] > 0 ? 1 : 3;
            }

            if (vector[0] + vector[1] == 0) {
                return vector[0] > 0 ? 5 : 6;
            }

            if (vector[0] - vector[1] == 0) {
                return vector[0] > 0 ? 4 : 7;
            }

            return -1;

        }
    }
}

