﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class AVL
    {
        public static int highestId = 0;
        AVLNode root = null;

        public string InOrderTraverse()
        {
            string description = "{";
            Stack<AVLNode> nodes = new Stack<AVLNode>();
            nodes.Push(root);

            List<int> usedIds = new List<int>();

            bool finished = false;
            bool finishedLeft = false;

            while (!finished)
            {
                if (!finishedLeft)
                {
                    if (nodes.Peek().left == null)
                    {
                        finishedLeft = true;
                    }
                    else
                    {
                        nodes.Push(nodes.Peek().left);
                    }
                }
                else
                {
                    AVLNode previous = null;
                    while (nodes.Peek().right == null || nodes.Peek().right == previous)
                    {
                        previous = nodes.Peek();
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Pop().key + ", ";
                        }
                        else
                        {
                            nodes.Pop();
                        }
                        if (nodes.Peek().parent == root && nodes.Peek().parent.right == nodes.Peek())
                        {
                            finished = true;
                            description = description.Remove(description.Count() - 2, 2);
                            description += "}";
                            break;
                        }
                    }
                    if (!finished)
                    {
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Peek().key + ", ";
                        }
                    }
                    finishedLeft = false;
                    nodes.Push(nodes.Peek().right);

                }
            }

            return description;
        }

        public string PreOrderTraverse()
        {
            string description = "{";
            Stack<AVLNode> nodes = new Stack<AVLNode>();
            nodes.Push(root);
            description += nodes.Peek().key + ", ";

            List<int> usedIds = new List<int>();
            usedIds.Add(nodes.Peek().id);

            bool finished = false;
            bool finishedLeft = false;

            while (!finished)
            {
                if (!finishedLeft)
                {
                    if (nodes.Peek().left == null)
                    {
                        finishedLeft = true;
                    }
                    else
                    {
                        nodes.Push(nodes.Peek().left);
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Peek().key + ", ";
                        }
                    }
                }
                else
                {
                    AVLNode previous = null;
                    while (nodes.Peek().right == null || nodes.Peek().right == previous)
                    {
                        previous = nodes.Peek();
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Pop().key + ", ";
                        }
                        else
                        {
                            nodes.Pop();
                        }
                        if (nodes.Peek().parent == root && nodes.Peek().parent.right == nodes.Peek())
                        {
                            finished = true;
                            description = description.Remove(description.Count() - 2, 2);
                            description += "}";
                            break;
                        }
                    }
                    if (!finished)
                    {
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Peek().key + ", ";
                        }
                    }
                    finishedLeft = false;
                    nodes.Push(nodes.Peek().right);
                    if (!usedIds.Contains(nodes.Peek().id))
                    {
                        usedIds.Add(nodes.Peek().id);
                        description += nodes.Peek().key + ", ";
                    }
                }
            }

            return description;
        }

        public string PostOrderTraverse()
        {
            string description = "{";
            Stack<AVLNode> nodes = new Stack<AVLNode>();
            nodes.Push(root);

            List<int> usedIds = new List<int>();

            bool finished = false;
            bool finishedLeft = false;

            while (!finished)
            {
                if (!finishedLeft)
                {
                    if (nodes.Peek().left == null)
                    {
                        finishedLeft = true;
                    }
                    else
                    {
                        nodes.Push(nodes.Peek().left);
                    }
                }
                else
                {
                    AVLNode previous = null;
                    if (nodes.Peek().key == 6)
                    {
                        int xxxxxx = 0;
                    }
                    while (nodes.Peek().right == null || nodes.Peek().right == previous)
                    {
                        previous = nodes.Peek();
                        if (!usedIds.Contains(nodes.Peek().id))
                        {
                            usedIds.Add(nodes.Peek().id);
                            description += nodes.Pop().key + ", ";
                        }
                        else
                        {
                            nodes.Pop();
                        }
                        if (nodes.Peek().parent == root && nodes.Peek().parent.right == nodes.Peek())
                        {
                            finished = true;
                            description += nodes.Peek().key + ", ";
                            description += root.key + ", ";
                            description = description.Remove(description.Count() - 2, 2);
                            description += "}";

                            break;
                        }
                    }
                    finishedLeft = false;
                    nodes.Push(nodes.Peek().right);
                }
            }

            return description;
        }

        public string LevelOrderTraverse()
        {
            string description = "{";
            bool finished = false;

            List<AVLNode> previousNodes = new List<AVLNode>();
            List<AVLNode> currentNodes = new List<AVLNode>();

            description += root.key + ", ";
            previousNodes.Add(root);

            while (!finished)
            {
                bool anyExist = false;
                foreach (AVLNode node in previousNodes)
                {
                    if (node.left != null)
                    {
                        anyExist = true;
                        description += node.left.key + ", ";
                        currentNodes.Add(node.left);
                    }
                    if (node.right != null)
                    {
                        anyExist = true;
                        description += node.right.key + ", ";
                        currentNodes.Add(node.right);
                    }
                }
                previousNodes = currentNodes;
                currentNodes = new List<AVLNode>();

                if (!anyExist)
                {
                    finished = true;
                }
            }

            description = description.Remove(description.Count() - 2, 2);
            description += "}";
            return description;
        }

        public AVLNode Search(int key)
        {
            return BFS(key, root);
        }

        AVLNode BFS(int key, AVLNode current)
        {
            if (current == null) return null;
            if (key == current.key) return current;
            AVLNode right = BFS(key, current.right);
            AVLNode left = BFS(key, current.left);

            return right != null ? right : left != null ? left : null;
        }

        public AVLNode IterativeFind(int key)
        {
            AVLNode current = root;

            while (current != null && current.key != key)
            {
                if (current.key < key)
                {
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }
            }
            return current;
        }

        public AVLNode Minimum()
        {
            AVLNode current = root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }

        public AVLNode Maximum()
        {
            AVLNode current = root;
            while (current.right != null)
            {
                current = current.right;
            }
            return current;
        }

        public void Insert(AVLNode newNode)
        {
            AVLNode current = root;
            if (current != null)
            {
                while (true)
                {
                    if (current.key > newNode.key)
                    {
                        if (current.left != null)
                        {
                            current = current.left;
                        }
                        else
                        {
                            current.left = newNode;
                            newNode.parent = current;
                            newNode.CalculateHeight();
                            break;
                        }
                    }
                    else
                    {
                        if (current.right != null)
                        {
                            current = current.right;
                        }
                        else
                        {
                            current.right = newNode;
                            newNode.parent = current;
                            newNode.CalculateHeight();
                            break;
                        }
                    }
                }
            }
            else
            {
                root = newNode;
                root.CalculateHeight();
            }
        }

        public void Rebalance(AVLNode start)
        {
            AVLNode current = start;
            while(current != root)
            {
                current.CalculateHeight();
                /*
                 rotate left:
                 og right child becomes parent
                 og right child, left child becomes your right child
                 */
                if (current.Balance() > 1)
                {
                    AVLNode right = current.right;
                    current.right = current.right.left;
                    current.right.left = null;
                    right.parent = current.parent;

                }else if(current.Balance() < -1)
                {

                }

                current = current.parent;
            }
        }
    }

    public class AVLNode
    {
        public int id;
        public int key;
        public int height;
        public AVLNode parent = null;
        public AVLNode left = null;
        public AVLNode right = null;

        public AVLNode(int key)
        {
            this.key = key;
            id = ++AVL.highestId;
        }

        public bool isLeaf()
        {
            return left == null && right == null;
        }

        public override string ToString()
        {
            return "TNode: " + key;
        }

        public void CalculateHeight()
        {
            if (isLeaf()) height = 1;
            else
            {
                height = right.height > left.height ? right.height + 1 : left.height + 1;
            }
        }

        public int Balance()
        {
            return left.height - right.height;
        }
    }
}
