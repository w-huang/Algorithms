namespace Algorithms.Leetcode {
	using System;

	public class DecodeWays {
		public int NumDecodings(string s) {
			int[] dp = new int[s.Length];
			
			dp[0] = isValid(s, 0, 1) ? 1 : 0;


            for (var i = 1; i < dp.Length; ++i) {
                dp[i] = 0;
                
                dp[i] += isValid(s, i, 1) ? dp[i-1] : 0;
                if (i == 1) {
                    dp[i] += isValid(s, i-1, 2) ? 1 : 0;
                    continue;
                }
                if (i > 1)
                    dp[i] += isValid(s, i-1, 2) ? dp[i-2] : 0;
            }


            return dp[dp.Length - 1];
		}
		
		public bool isValid(string s, int idx, int len) {

            if (s[idx] == '0') return false;
			if (len == 1) return true;
			

            return (s[idx] - '0') * 10 + s[idx+1] - '0' < 27; 
		}
	}
}


	
