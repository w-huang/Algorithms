namespace Algorithms.Leetcode {

    public class SetMismatch{

        public int[] FindErrorNums(int[] a) {

            return null;
//            int xor = 0;
//            for (var i = 0; i < a.Length; ++i) {
//                xor = xor ^ (i+1);
//                xor = xor ^ a[i];
//            }
//
//            int xor1 = 0;
//            int xor2 = 0;
//            int lsb = xor & (~(xor - 1));
//
//            for (var i = 0; i < a.Length; ++i) {
//                if (a[i] & lsb > 0) {
//                    xor1 = xor1 ^ a[i];
//                } else {
//                    xor2 = xor2 ^ a[i];
//                }
//            }
//
//            for (var i = 0; i < a.Length; ++i) {
//                if (a[i] ^ xor1 == 0) return new int[] {xor1, xor2};
//                if (a[i] ^ xor2 == 0) return new int[] {xor2, xor1};
//            }
//
//            return null;

        }
    }
}
