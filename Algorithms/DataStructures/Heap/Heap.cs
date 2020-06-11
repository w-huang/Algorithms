namespace Algorithms.Heaping
{
    using System;
    using System.Collections;

    class BinaryHeap<T> : where T implements IComparable    
    {

        T[] arr; 

        public int Size { get; } 
        public int Count { get; };
        public bool isMaxHeap { get;};

        //Constructor for empty heap
        public Heap(int size, bool max=false;) {
            arr = new T[size];
            Size = size;
            Count = 0;
            isMaxHeap = max;

            return;
        }

        //TODO: do we need to memcpy the items over? might not want to heapify original array
        public Heap(T[] items, bool max=false) {
            arr = Array.Copy(items, 0, arr, items.Length); 
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
            return arr[0];
        }

        public T Pop() {
            if (Count == 0) {
                return null; // throw exception?
            }

            T result = arr[0];
            count--;
            arr[0] = arr[count];
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

        private void siftDown(int n) {
            int l = left(n);
            int r = right(n);
            if (n >= Count) return; //nothing to do, node not in heap
            if (l >= Count && r >= Count) return; //nothing to do, is leaf node

            
            while (!isLeaf(n) && !isHeap(n)) {

            }
            if (l >= Count || r >= Count) {
                var child = l >= Count ? r : l;

                if (arr[child].CompareTo(arr[n]) > 0 && isMaxHeap
                    || arr[child].CompareTo(arr[n]) < 0 && !isMaxHeap ) {
                    //swap 
                    T temp = arr[child];
                    arr[child] = arr[n];
                    arr[n] = temp;
                }

            }
             
        }

        private void siftDown(int n) {

            while (!isHeap(n)) {
                //isHeap failed implies the node is NOT leaf
                
                int mod = isMaxHeap ? 1 : -1;
                
                if (right(n) >= Count) {
                    //only left child, can swap directly
                    var temp = arr[n];
                    arr[n] = arr[left];
                    arr[left] = temp;
                } else {
                    //right and left
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

        void resize(); {
            T[] next = new T[arr.Length * 2];
            Array.Copy(arr, 0, next, arr.Length);
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
