using System;
// Jesse Lucas
//14/08/2020
// P274063
namespace Binary_Tree
{
    class BinaryTree
    {

        class Node
        {
            public string data;
            public Node left;
            public Node right;

            public Node(string data)
            {
                this.data = data;
            }
        }

        Node root;


        public BinaryTree()
        {

        }

        public void Add(string data)
        {
            Node newItem = new Node(data);
            if (root == null)
                root = newItem;
            else
                root = AddRecursive(root, newItem);
        }
        private Node AddRecursive(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (string.Compare(n.data, current.data) < 0)
            {
                current.left = AddRecursive(current.left, n);
                current = BalanceTree(current);
            }
            else if (string.Compare(n.data, current.data) > 0)
            {
                current.right = AddRecursive(current.right, n);
                current = BalanceTree(current);
            }
            return current;
        }
        public void Delete(string target)
        {
            root = DeleteNode(root, target);
        }
        private Node DeleteNode(Node current, string target)
        {
            Node parent;
            if (current == null)
                return null;
            else
            {
                if (target.CompareTo(current.data) < 0)
                {
                    current.left = DeleteNode(current.left, target);
                    if (BalanceFactor(current) == -2)
                    {
                        if (BalanceFactor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateLL(current);
                        }
                    }
                }

                else if (target.CompareTo(current.data) > 0)
                {
                    current.right = DeleteNode(current.right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    if (current.right != null)
                    {
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = DeleteNode(current.right, parent.data);
                        if (BalanceFactor(current) == 2)
                        {
                            if (BalanceFactor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {
                        return current.left;
                    }
                }
            }
            return current;
        }
        private Node BalanceTree(Node current)
        {
            int bFactor = BalanceFactor(current);
            if (bFactor > 1)
            {
                if (BalanceFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (bFactor < -1)
            {
                if (BalanceFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        private int BalanceFactor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int bFactor = 1 - r;
            return bFactor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        public void SearchItem(string key)
        {
            if (SearchRecursive(root, key) == true)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private bool SearchRecursive(Node cur, string key)
        {
            if (cur == null)
            {
                return false;
            }
            if (cur.data == key)
            {
                return true;
            }
            bool res1 = SearchRecursive(cur.left, key);
            if (res1)
            {
                return true;
            }
            bool res2 = SearchRecursive(cur.right, key);
            return res2;
        }
        public void Display()
        {
            Console.WriteLine("The root is " +root.data);
            DisplayInOrder(root);
        }
        private void DisplayInOrder(Node root)
        {
            Node temp;
            temp = root;
            while (root == null) return;
            {
                DisplayInOrder(root.left);
                Console.Write(root.data + " ");
                DisplayInOrder(root.right);

            }

        }
      
    }

      
       
      


    }

