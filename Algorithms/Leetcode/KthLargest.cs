//Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

public class KthLargestElement{

    public int FindKthLargest(int[] nums, int k) {
        int low = 0;
        int high = nums.Length - 1;

        while (low < high) {
            int pivot = low;

            int j = low + 1;
            for (var i = j; i <= high; ++i) {
                if (nums[i] < nums[pivot]) {
                    swap(nums, i, j);
                    j++;
                }
            }

            swap(nums, pivot, j-1);
            pivot = j-1;
            if (pivot == (k - 1)) return nums[pivot];
            if (pivot > (k-1)) {
                low = pivot+1;
            }
            if (pivot < (k-1)) {
                high = pivot-1;
            }
        }


        return low;
    }

    public void swap(int[] n, int i, int j) {
        int temp = n[i];
        n[i] = n[j];
        n[j] = temp;
        return;
    }

}
