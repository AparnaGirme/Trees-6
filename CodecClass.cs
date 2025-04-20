/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // TC => O(n)
    // SC => O(n)
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null)
        {
            return string.Empty;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        StringBuilder sb = new StringBuilder();

        queue.Enqueue(root);
        while(queue.Count > 0){
            TreeNode current = queue.Dequeue();
            if(current == null){
                sb.Append("null");
                sb.Append(",");
                continue;
            }
            sb.Append(current.val);
            // if(current.left == null && current.right == null){
            //     continue;
            // }
            queue.Enqueue(current.left);
            queue.Enqueue(current.right);
            sb.Append(",");
        }

        return sb.ToString();
    }

    // TC => O(n)
    // SC => O(n)
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(string.IsNullOrEmpty(data)){
            return null;
        }

        string[] array = data.Split(",");
        Queue<TreeNode> queue = new Queue<TreeNode>();
        TreeNode root = new TreeNode(Int32.Parse(array[0]));
        queue.Enqueue(root);
        int i = 1;

        while(queue.Count > 0){
            TreeNode current = queue.Dequeue();
            if(array[i] != "null"){
                current.left = new TreeNode(Int32.Parse(array[i]));
                queue.Enqueue(current.left);
            }
            i++;
            if(array[i] != "null"){
                current.right = new TreeNode(Int32.Parse(array[i]));
                queue.Enqueue(current.right);
            }
            i++;
        }
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));