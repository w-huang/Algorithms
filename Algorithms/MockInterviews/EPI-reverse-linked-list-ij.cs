namespace Algorithms.EPI {

    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedListNode {
        public int val;
        public LinkedListNode next;

        public LinkedListNode( int val ) {
            this.val = val;
            this.next = null;
        }

        public void Print() {
            Console.Write(String.Format("{0}, ", val));
            LinkedListNode n = next;
            while (n != null) {
                Console.Write(String.Format("{0}, ", n.val));
                n = n.next;
            }
            Console.WriteLine();
        }

    }

    public class ReverseSublist {

        //reverse linked list elements from i to j
        //e.g. if i = 0, j = len-1, reverse entire linkedlist
        public static LinkedListNode Solve(LinkedListNode n, int i, int j) {
            
            //IDEA: we walk to the point node before reversal starts
            //We reverse j-i nodes from there
            //We point the head prior to the reversal began to the tail

            var dh = new LinkedListNode(0);
            var head = dh;
            dh.next = n;
            i++;
            j++;

            while (i-- > 1) {
                dh = dh.next;
                j--;
            }

            dh.next = ReverseN(dh.next, j);
            return head.next;


        }

        public static LinkedListNode ReverseN(LinkedListNode n, int N) {
            //reverses the first n nodes in a linkedlist
            //
            if (N <= 1 || n == null) return n;
            
            var oldHead = n;
            var prev = n;
            var iter = n.next;
            for (var i = 1; i < N; ++i) {
                 var tmp = iter.next;
                 iter.next = prev;
                 prev = iter;
                 iter = tmp;
            }

            oldHead.next = iter;

            return prev;

        }

        public static LinkedListNode ReverseEntireList(LinkedListNode n) {
            if (n == null || n.next == null) return n;

            var curr = n.next;
            var prev = n;
            prev.next = null;

            while (curr != null) {
                var tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            return prev;
        }
    }

}
