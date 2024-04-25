using System;
using laba12;
using System.ComponentModel.Design;
using лаба10;
using lab12dot7;
using System.Xml.Linq;
namespace lab12dot7
{

    public class BalancedBinaryTree<T> where T : MusicalInstrument
    {
        private class TreeNode
        {
            public T Data;
            public TreeNode LeftChild;
            public TreeNode RightChild;

            public TreeNode(T data)
            {
                Data = data;
            }
        }

        private TreeNode _root;

        public BalancedBinaryTree(T[] elements)
        {
            _root = ConstructBalancedTree(elements, 0, elements.Length - 1);
        }

        private TreeNode ConstructBalancedTree(T[] elements, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(elements[mid]);

            node.LeftChild = ConstructBalancedTree(elements, start, mid - 1);
            node.RightChild = ConstructBalancedTree(elements, mid + 1, end);

            return node;
        }

        public void PrintLevelOrder()
        {
            if (_root == null)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    Console.Write(currentNode.Data + " ");

                    if (currentNode.LeftChild != null)
                    {
                        queue.Enqueue(currentNode.LeftChild);
                    }

                    if (currentNode.RightChild != null)
                    {
                        queue.Enqueue(currentNode.RightChild);
                    }
                }

                Console.WriteLine();
            }
        }

        public T FindMax()
        {
            if (_root == null)
            {
                throw new InvalidOperationException("Дерево пустое");
            }

            return FindMax(_root);
        }

        private T FindMax(TreeNode node)
        {
            if (node.RightChild == null)
            {
                return node.Data;
            }

            return FindMax(node.RightChild);
        }

        public BalancedBinaryTree<T> Balance()
        {
            List<T> elements = new List<T>();
            InOrderTraversal(_root, elements);

            return new BalancedBinaryTree<T>(elements.ToArray());
        }

        private void InOrderTraversal(TreeNode node, List<T> elements)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.LeftChild, elements);
            elements.Add(node.Data);
            InOrderTraversal(node.RightChild, elements);
        }
    }
}

