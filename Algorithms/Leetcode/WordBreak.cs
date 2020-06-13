namespace Algorithms.LeetCode
{
    using System;
    using Algorithms.Searching;
    using System.Collections;
    using System.Collections.Generic;

    class WordBreak 
    {
        public static bool Solve(string s, IList<string> wordDict) {
            //let len(s) = N
            //let len(wordDict) = M
            //let arg_max(len(word) : wordDict) = K
                
            //let A[s] be dp array;
            //A[i] = whether string from 0 to i can be made up with wordDict
            //A[i+1] = || (word => isSubstr(s[i, n], word) && A[i + 1 - word.len]);
            //Algorithm runtime: N * K * M

            bool[] dp = new bool[s.Length];

            foreach (var word in wordDict) {
                if (s.IndexOf(word) == 0) {
                    dp[word.Length - 1] = true;
                }
            }

            for (var i = 1; i < dp.Length; ++i) {
                if (dp[i] == true) continue;

                var result = false;
                foreach (var word in wordDict) {
                    var memo = word.Length > i ? true : dp[i - word.Length];
                    result = memo && wordFits(s, word, i);
                    if (result) break;
                }
                dp[i] = result;
            }

            return dp[dp.Length - 1];

            //Stack approach (DFS)
            //if (substr(s, word)) st.push(s[word.Length, n]);
            //return true if 
            //Algorithm Runtime: perform O(K) check everytime we push to stack
            //                   push to stack max N * S times (MAX)
            //                   kj
        }

        //returns true if word w is a substring of s ending at j
        private static bool wordFits(string s, string w, int j) {
            if (j < w.Length) return false;
            var result = true;

            for (var i = 0; i < w.Length; ++i) {
                if (s[j - w.Length + 1 + i] != w[i]) {
                    result = false;
                }

                if (!result) return false;
            }
            return result;
        }

    }
}
    
