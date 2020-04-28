// public class TreeNode{
//     public TreeNode left;
//     public TreeNode right;
//     public int val;
//     public TreeNode(int data){
//         val = data;
//     }
// }
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace BST {
public class Solution_Codec {

        // Encodes a tree to a single string.
        // https://leetcode.com/problems/serialize-and-deserialize-bst/
        public string serialize(TreeNode root) {
        Stack<TreeNode> st = new Stack<TreeNode>();
        StringBuilder sb = new StringBuilder();
        while(root != null || st.Any()){
            if(root != null){
                st.Push(root);
                root = root.left;
            }
            else{
                root = st.Pop();
                sb.Append(root.val.ToString());
                sb.Append(",");
                root = root.right;
            }
        }
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] elements = data.Split(',');
        int[] res = new int[elements.Length];
        for(int p=0;p<elements.Length;p++){
            int value;
            if(elements[p] == "null"){
               res[p] = int.MaxValue;     
            }
            else if(int.TryParse(elements[p], out value))
            {
                res[p] = value;
            }
        }
        Array.Sort(res);
        return ConvertSortedArrayToBST(res, 0, elements.Length -1);
    }
      private TreeNode ConvertSortedArrayToBST(int[] nums, int l, int r){
        if(nums == null) return null;
        if(l>r) return null;
        int mid = (l+r)/2;
        TreeNode root = new TreeNode(mid);
        if(root.left != null){
        root.left = ConvertSortedArrayToBST(nums,l,mid-1);
        if(root.left.val == int.MaxValue){
            root.left = null;
        }}
        if(root.right != null){
        root.right = ConvertSortedArrayToBST(nums,mid,r);
        if(root.right.val == int.MaxValue){
            root.right = null;
        }
        }
        return root;
    }
}
}
// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));