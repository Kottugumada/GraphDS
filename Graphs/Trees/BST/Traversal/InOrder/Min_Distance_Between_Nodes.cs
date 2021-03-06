// Definition for a binary tree node.
// Time and Space Complexity O(n)
//  public class TreeNode {
//      public int val;
//      public TreeNode left;
//      public TreeNode right;
//      public TreeNode(int x) { val = x; }
//  }
using System;
using System.Linq;
using System.Collections.Generic;

namespace BST
{
    public class Solution_MinDiffInBST {
        /// <summary>
        /// https://leetcode.com/problems/minimum-distance-between-bst-nodes/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST(TreeNode root) {
            Stack<TreeNode> st = new Stack<TreeNode>();
            int minDiff = int.MaxValue;
            TreeNode prev = null;
            if(root == null) return 0;
            while(root != null || st.Any()){
                if(root != null){
                    st.Push(root);
                    root = root.left;
                }
                else{
                    root = st.Pop();
                    if(prev != null){
                        minDiff = Math.Min(minDiff,root.val - prev.val);
                    }
                    prev = root;
                    root = root.right;
                }
    }
    return minDiff;
    }
}
}