public class Solution {

    public int HeightChecker(int[] heights) {
                
        //idea is we need to move a student if his position in the array is not equal to the sum of rank of students below him
        int[] count = new int [100];

        foreach (int height in heights) {
            count[height]++;
        }

        int[] temp = new int[heights.Length];

        var i = 0;

        for (var j = 0; j < count.Length; ++j) {
            for (var k = 0; k < count[j]; ++k) {
                temp[i] = j;
                ++i;
            }
        }

        int ans = 0;
        for (i = 0; i < count.Length; ++i) {
            ans += temp[i] == heights[i] ? 0 : 1;
        }

        return ans;
        
    }

    public bool IsLongPressedName(string name, string typed) {
       int i = 0, j = 0; 
        
       while (i < name.Length && j < typed.Length) {
           if (name[i] == typed[j]) {
               i++;
               j++;
               continue;
           }

           if (j > 0 && typed[j] == typed[j - 1]) {
               j++;
               continue;
           }

           return false;
       }

       if (i < name.Length) {
            return false
       }

       if (j < typed.Length) {
           ++j;
           for (j; j < typed.Length; ++j)  {
               if (typed[j] != typed[j-1]) return false;
           }
       }

       return true;
    }

}
