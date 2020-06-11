public class Solution {

    //
    public bool IsStrobogrammatic(string num) {
        string notEligible = "23457";
        string eligible = "01689";

        var j = nums.Length - 1;
        var i = 0;

        var opposites = new Dictionary<char, char>()
        {
           {'1', '1'},
           {'6', '9'},
           {'8', '8'},
           {'0', '0'},
        };


        while (i <= j) {

			if (eligible.IndexOf(num[i]) < 0 || eligible.IndexOf(num[j]) < 0) {
				return false;
			}

			opposites.TryGetValue(num[i], out var rotated);

			if (j != rotated) return false;

            ++i;
            --j;
        }

		return true;

    }
}



public class PhoneDirectory {


	private Dictionary<int, bool> availableNumbers;
	private Dictionary<int, bool> takenNumbers;

    /** Initialize your data structure here
        @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
    public PhoneDirectory(int maxNumbers) {
		availableNumbers = new Dictionary<int, bool>();
		takenNumbers = new Dictionary<int, bool>();

  		for (var i = 0; i < maxNumbers; ++i) {
			availableNumbers.Add(i, true);
		}
    }
    
    /** Provide a number which is not assigned to anyone.
        @return - Return an available number. Return -1 if none is available. */
    public int Get() {
		int result = -1;
		
		//take first and break
		foreach (int key in availableNumbers.Keys) {
			result = key;
			break;
		}

     	availableNumbers.Remove(result);
		takenNumbers.Add(result, true);
		return result;
    }
    
    /** Check if a number is available or not. */
    public bool Check(int number) {
	   availableNumbers.TryGetValue(number, out var result);
       return result;
    }
    
    /** Recycle or release a number. */
    public void Release(int number) {
		takenNumbers.TryGetValue(number, out var isTaken);
		
		if (isTaken) {
			takenNumbers.Remove(number);
			availableNumbers.Add(number, true);    
		}
    }
}

/**
 * Your PhoneDirectory object will be instantiated and called as such:
 * PhoneDirectory obj = new PhoneDirectory(maxNumbers);
 * int param_1 = obj.Get();
 * bool param_2 = obj.Check(number);
 * obj.Release(number);
 */
