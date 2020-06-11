namespace Algorithms.HackerRank
{
    using System;
    using System.Collections;
    using System.Collections.Generic;


/*
 *
 *
 * You are given a string representing an attendance record for a student. The record only contains the following three characters:
 * 'A' : Absent.
 * 'L' : Late.
 * 'P' : Present.
 * A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).
 *
 * You need to return whether the student could be rewarded according to his attendance record.
 *
 *
 */

    public class Solution {
        public int NetworkDelayTime(int[][] times, int N, int K) {
            Stack<int[]> stack = new Stack<int[]>();

            //visited.get(key)[0] == visited, [1] == min distance to node from S
            Dictionary<int, int[]> visited = new Dictionary<int, int[]>();

            //Convert inputs to adjacency list
            List<List<int[]>> adj = new List<List<int[]>>();
            
            for (var i = 0; i < N; ++i) {
                adj.Add(new List<int[]>());
                visited.Add(i, new int[2] {0, Int32.MaxValue}); 
            }

            foreach (int[] edge in times) {
                adj[edge[0] - 1].Add(edge);
            };

            //Push initial node
            stack.Push(new int[2] {K, 0}); //stack[0] == node, stack[1] == current travel time to this node

            int counter = 0;
            while (stack.Count > 0) {
                //perform DFS
                var currNode = stack.Pop();
                int nodeId = currNode[0];
                int dist = currNode[1];
                visited.TryGetValue(nodeId - 1, out var status);
                status[0] = 1; //visisted
                status[1] = Math.Min(status[1], dist);

                foreach (int[] edge in adj[currNode[0]]) {
                    //push onto stack
                    visited.TryGetValue(edge[1] - 1, out var next);
                    if (next[0] == 0 || next[1] > dist + edge[2])
                        stack.Push(new int[] {edge[1], dist + edge[2]});
                    counter++;
                }
            }
            
            return counter;
            
            var max = Int32.MinValue;

            foreach (var visit in visited) {
                if (visit.Value[0] == 0) return -3; //cannot reach node
                max = max > visit.Value[1] ? max : visit.Value[1];
            }

            return max;
        }
    } 
}
