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
 // TC => O(n)
 // SC => O(n)
public class Solution {
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        if(root == null){
            return new List<IList<int>>();
        }

        Queue<TreeNode> queueNode = new Queue<TreeNode>();
        Queue<int> queueOrder = new Queue<int>();
        Dictionary<int, List<int>> orderMap = new Dictionary<int, List<int>>();
        int min = Int32.MaxValue;
        int max = Int32.MinValue;
        queueNode.Enqueue(root);
        queueOrder.Enqueue(0);

        while(queueNode.Count > 0){
            int size = queueNode.Count;
            for(int i = 0; i < size; i++){
                TreeNode current = queueNode.Dequeue();
                int order = queueOrder.Dequeue();
                max = Math.Max(max, order);
                min = Math.Min(min, order);
                orderMap.TryAdd(order, new List<int>());
                orderMap[order].Add(current.val);

                if(current.left != null){
                    queueNode.Enqueue(current.left);
                    queueOrder.Enqueue(order - 1);
                }

                if(current.right != null){
                    queueNode.Enqueue(current.right);
                    queueOrder.Enqueue(order + 1);
                }
            }
        }

        // List<int> keys = orderMap.Keys.ToList();
        // keys.Sort();
        IList<IList<int>> result = new List<IList<int>>();
        for(int i = min; i <= max; i++){
            result.Add(orderMap[i]);
        }

        return result;
    }
}