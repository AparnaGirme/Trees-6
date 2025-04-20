/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    int sum = 0;
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null){
            return 0;
        }
        Dfs(root, low, high);
        return sum;
    }

    public void Dfs(TreeNode root, int low, int high){
        if(root == null){
            return;
        }
        if(root.val > low){
            Dfs(root.left, low, high);
        }
        
        if(root.val >= low && root.val <= high){
            sum += root.val;
        }
        if(root.val < high){
            Dfs(root.right, low, high);
        }
    }

    public void DfsBR(TreeNode root, int low, int high){
        if(root == null){
            return;
        }
        Dfs(root.left, low, high);
        if(root.val >= low && root.val <= high){
            sum += root.val;
        }
        Dfs(root.right, low, high);
    }
}