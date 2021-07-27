namespace Algorithms.Leetcode {

    public class MinKFlips{

        public int MinKBitFlips(int[] a, int k) {
            int result = 0;

            for (var i = 0; i <= a.Length - k; ++i) {
                if ( a[i] == 0 ) {
                    a[i] = 1;
                    result++;
                }
            }

            for (var i = a.Length - k; i < a.Length; ++i) {
                if (a[i] == 0) return -1;
            }

            return result;
        }
    }
}
