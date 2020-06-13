namespace Algorithms.Leetcode {
	using System;

	public class BalanceBinaryTree { 

		public class TreeNode {
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
				this.val = val;
				this.left = left;
				this.right = right;
			}
		}

		public class BalanceStatus {
			public int height;
			public bool isBalanced;
			public BalanceStatus(int height, bool isBalanced) {
				this.height = height;
				this.isBalanced = isBalanced;
			}
		}

		public bool IsBalanced(TreeNode root) {
			var status = getBalance(root);
			return status.isBalanced;
		}

		public BalanceStatus getBalance(TreeNode n) {
			if (n == null) return new BalanceStatus(0, true); //Base condition

			var lstat= getBalance(n.left);
			if (!lstat.isBalanced) return lstat;
			var rstat = getBalance(n.right);
			if (!rstat.isBalanced) return rstat;

			return new BalanceStatus(Math.Max(lstat.height, rstat.height) + 1, Math.Abs(rstat.height - lstat.height) <= 1);
		}

	}
	


}
