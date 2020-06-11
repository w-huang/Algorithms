//Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

public class ProductOfArrayExceptSelfSolution {

    public int[] ProductExceptSelf(int[] nums) {
        var ans = new int[nums.Length];

        nums[0] = 1;

        for (var i = 1; i < nums.Length; ++i) {
            ans[i] = ans[i-1] * nums[i-1];
        }

        int product = 1;
        for (var i = nums.Length - 1; i > -1; ++i) {
            ans[i] *= product;
            product *= nums[i];
        }

        return ans;
    }

}
