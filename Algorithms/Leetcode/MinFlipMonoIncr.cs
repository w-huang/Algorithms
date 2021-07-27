namespace Algorithms.Leetcode {

    public class MinFlipMonoIncr{

        public static int Solve() {
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
			
			int min = 0; // Int32.MaxValue;
			for (var i = 0; i < pre.Length; ++i) {
				if (pre[i] + post[i] < min) min = pre[i]+post[i];
			}
			
			return min - 1;

        }
    }
}
