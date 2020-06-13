public class Solution {
    public string LongestPalindrome(string s) {

        if (s.Length < 2) return s;
        int max_er = 0;
        int e_i = -1;
        int o_i = 0;
        int max_or = 1;

        for (var i = 0; i < s.Length -1; ++i)  {
            int even_result = PalindromeLength(s, i, true);
            int odd_result = PalindromeLength(s, i, false);

            if (even_result > max_er) {
                e_i = i; max_er = even_result;
            }
            if (odd_result > max_or) {
                o_i = i; max_or = odd_result;
            }
        }

        if (max_or * 2 - 1 > max_er * 2) {
            //ODD
            return s.Substring(o_i - max_or + 1, 2 * max_or - 1);
        } else {
            //EVEN
            return s.Substring(e_i - max_er + 1, max_er * 2);
        }

    }
    
    public int PalindromeLength(string s, int i, bool even) {
        int j = i;
        int result = 0;
        if (even) {
            j++;
        } 

        while (i >= 0 && j <= s.Length) {
            if (s[i--] == s[j++]) result++; 
            else break;
        }

        return result;
    }
}
