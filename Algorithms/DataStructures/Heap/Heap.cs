namespace Algorithms.DataStructures
{
    using System;
    using System.Collections;

    class BinaryHeap<T> 
        where T: IComparable    
    {

        T[] arr; 
        public int Size { get; private set;} 
        public int Count { get; private set;}
        public bool isMaxHeap { get; private set;} 

        public BinaryHeap(int size, bool max=false) {
            arr = new T[size];
            Size = size;
            Count = 0;
            isMaxHeap = max;

        }

        //TODO: do we need to memcpy the items over? might not want to heapify original array
        public BinaryHeap(T[] items, bool max=false) {
            Array.Copy(items, 0, arr, 0, items.Length); 
            Count = arr.Length;
            Size = arr.Length; // size is equal to the array
            isMaxHeap = max;
            Heapify(); //heapify the array

            return;
        }

        //Methods
        public void Add(T item) {
            if (Count == Size) {
                resize();
            }

            arr[Count] = item;
            siftUp(Count);
            Count++;

            return;
        }

        public T Peek() {
            if (Count <= 0) throw new Exception("Cannot peek empty heap");
            return arr[0];
        }

        public T Pop() {
            if (Count == 0) {
                throw new Exception("Popping empty heap"); // throw exception?
            }

            T result = arr[0];
            Count--;
            arr[0] = arr[Count];
            siftDown(0);

            return result;
        }

        //Private Methods
        private void Heapify() {
            int n = parent(Count - 1);

            //for each item that is not a leaf, perform siftdown
            for( var i = n; i > 0; --i) {
                siftDown(n);
            }

            return;
        }

        private void siftUp(int n) {

            while (n != 0 && !isHeap(parent(n))) {
                int p = parent(n);

                //swap
                var temp = arr[n];
                arr[n] = arr[p];
                arr[p] = temp;
                n = p;
            }

        }

        private void siftDown(int n) {
            int mod = isMaxHeap ? 1 : -1;
            while (!isHeap(n)) {
                //isHeap failed implies the node is NOT leaf
                if (right(n) >= Count) {
                    //only left( child, can swap directly
                    var temp = arr[n];
                    arr[n] = arr[left(n)];
                    arr[left(n)] = temp;
                    n = left(n);
                } else {
                    //right and left(
                    int index =  mod * arr[left(n)].CompareTo(arr[right(n)]) > 0 ? right(n) : left(n);
                    var temp = arr[n];
                    arr[n] = arr[index];
                    arr[index] = temp;
                    n = index;
                }
            }
        }


        //HELPER METHODS
        bool isHeap(int n) {
            bool result = true;
            int mod = isMaxHeap ? 1 : -1;

            if (left(n) < Count) {
                result &= mod * arr[n].CompareTo(arr[left(n)]) > 0;          
            }

            if (right(n) < Count) {
                result &= mod * arr[n].CompareTo(arr[right(n)]) > 0;
            }

            return result;
        }

        bool isLeaf(int n) {
            return 2 * n + 1 > Count;
        }

        void resize() {
            T[] next = new T[arr.Length * 2];
            Array.Copy(arr, 0, next, 0, arr.Length);
            this.arr = next;
        }

        int right(int curr) {
            return 2 * curr + 2;
        }

        int left(int curr) {
            return 2 * curr + 1;
        }

        int parent (int curr) {
            return curr % 2 == 1 ? (curr - 1)/2 : curr/2 - 1;
        }
    }
}
