namespace LeetcodeProgrammingApp
{

    class TreeNode {

        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    
    
    }




    internal class FindMinimumDepth
    {
        
        public async Task <TreeNode> AddNode(TreeNode current,int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value > current.value)
            {
                current.right = await AddNode(current.right, value);
            }
            else
            {
                current.left = await AddNode(current.left, value);
            }

            return current;


        }

        public async Task<int> ReturnDepth(TreeNode root, int cnt)
        {
            TreeNode node = root;

            if (node.left == null && node.right == null)
            {
                return cnt;
            }

            int left = Int32.MaxValue;
            int right = Int32.MaxValue;

            if (node.left != null)
            {
                left = await ReturnDepth(node.left, cnt + 1);
            }

            if (node.right != null)
            {
                right = await ReturnDepth(node.right, cnt + 1);
            }


            if (left < right)
            {
                return left;
            }
            else
            {
                return right;
            }

        }

        public bool GetNum(int input, out int result)
        {
            result = 0;
            if (input==0)
            {
                return false;
            }
            result = input;
            return true;
        }

        public async void FindDepth()
        {
            TreeNode root = null;

            Console.WriteLine("Enter the values\nEnter 0 to stop");
            int value;
            while (GetNum(Convert.ToInt32(Console.ReadLine()), out value))
            {
                root = await AddNode(root, value);
            }

            Console.WriteLine("Minimum depth of Tree : " + await ReturnDepth(root, 1));


        }


        static void Main(string[] args)
        {
            
            FindMinimumDepth findMinimumDepth = new FindMinimumDepth();

            //root = findMinimumDepth.AddNode(root,3);
            //findMinimumDepth.AddNode(root,2);
            //findMinimumDepth.AddNode(root,20);
            //findMinimumDepth.AddNode(root,15);
            //findMinimumDepth.AddNode(root,7);

            findMinimumDepth.FindDepth();





        }
    }
}
