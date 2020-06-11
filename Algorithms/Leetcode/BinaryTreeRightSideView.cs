/**
 * Definition for a binary tree node.
 * 
 */


namespace Algorithms.HackerRank
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTreeSideViewSolution {

        internal class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private IList<int> RightSideView(TreeNode root) {
            Queue<TreeNode> bfs1 = new Queue<TreeNode>();
            Queue<TreeNode> bfs2 = new Queue<TreeNode>();
            bfs1.Enqueue(root);
            int level = 1; //root;
            List<int> ans = new List<int>();

            if (root == null) {
                return ans;
            }

            while (bfs1.Count + bfs2.Count > 0) {
                Queue<TreeNode> source = level % 2 == 1 ? bfs1 : bfs2;
                Queue<TreeNode> dest = level % 2 == 1 ? bfs2 : bfs1;
                
                ans.Add(source.Peek().val);
                while (source.Count > 0) {
                    var node = source.Dequeue();

                    if (node.right != null) dest.Enqueue(node.right);
                    if (node.left != null) dest.Enqueue(node.left);
                }
                    
                level++;
            }

            return ans;
            
        }
    }
}
