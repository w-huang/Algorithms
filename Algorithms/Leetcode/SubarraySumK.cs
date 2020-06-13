namespace Algorithms.LeetCode
{
    using System;
    using Algorithms.Searching;
    using System.Collections;
    using System.Collections.Generic;

    class SubarraySumKSolution 
    {
        public int SubarraySum(int[] nums, int k) {
            int[] sums = new int[nums.Length];
            int ans = 0;

            sums[0] = nums[0];
            for (var i = 1; i < sums.Length; ++i) {
                sums[i] = sums[i - 1] + nums[i];
            }

            var delta = new Dictionary<int, int>();

            for (var i = 0; i < sums.Length; ++i) {
                if (delta.ContainsKey(sums[i])) {
                    delta.TryGetValue(sums[i], out var count);
                    ans += count;
                }
                else {
                    delta.TryGetValue(sums[i] + k, out var old);
                    delta.Remove(sums[i] + k);
                    delta.Add(sums[i] + k, old + 1);
                }
            }

            return ans;

        }
    }
}

