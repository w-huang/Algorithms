namespace Algorithms.HackerRank {
    using System;
    using System.Text;

    class MoveMinimumToMakeValidParenthesisSolution {


        public string MinRemoveToMakeValid(string s) {
            var count = 0;
            bool[] removeAt = new bool[s.Length];
            
            for (var i = 0; i < s.Length; ++i) {
                if (s[i] == '(') count++;
                if (s[i] == ')') count--;

                if (count < 0) {
                    removeAt[i] = true;
                    count = 0;
                }
            }

            count = 0;
            for (var i = s.Length - 1; i > -1; --i) {
                if (s[i] == '(') count--;
                if (s[i] == ')') count++;

                if (count < 0) {
                    removeAt[i] = true;
                    count = 0;
                }
            }

            StringBuilder ans = new StringBuilder();

            for (var i = 0; i < s.Length; ++i) {
                if (removeAt[i]) continue;
                ans.Append(s[i]);
            }

            return ans.ToString();
        }
    }
}


