namespace Algorithms.Sorting
{
    using System;
    using System.Collections;

    class QuickSelect 
    {


        public QuickSelect() {

        }

        //Partitions T around partition index pi so that arr[i] < arr[pi] for all i < pi, and 
        //arr[j] > arr[pi] for all j > pi
        private static int Partition<T> (T[] arr, int pi, int high = -1, int low = 0) where T:IComparable 
        {
            if (high == -1) high = arr.Length - 1;

            int i = low;
            int j = high;
            T temp;

            while (i < j) {
                //ignore pi in this step, move it after partitioning is complete
                if (i == pi) {
                    i++;
                    continue;
                }
                if (j == pi) {
                    j--;
                    continue;
                }
                
                if (arr[i].CompareTo(arr[pi]) < 0) {
                    i++;
                    continue;
                }

                if (arr[j].CompareTo(arr[pi]) > 0) {
                    j--;
                    continue;
                }

                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            // i >= j
            //swap pi and i/j
            if (arr[pi].CompareTo(arr[j]) < 0) j--;

            temp = arr[pi];
            arr[pi] = arr[j];
            arr[j] = temp;

            return j;
        }

        //finds the k'th smallest element in arr
        public static T QSelect<T> (T[] arr, int k) where T: IComparable 
        {
            int high = arr.Length - 1;
            int low = 0;

            while (high > low) {
                int pi = (high + low) / 2; //take middle element
                int index = Partition(arr, pi, high, low);

                if (index > k) high = index;
                if (index < k) {low = index; k = k - index;}
                if (index == k) {
                    return arr[k];
                }
            }

            return default(T);
            
        }

        public static int QuickSort<T> (T[] arr) where T: IComparable 
        {
            return 0; //TODO implement

        }
    }
}
