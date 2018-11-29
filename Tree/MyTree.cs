using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class MyTree
    {
        private Node _root = null;


        public int SubtreeMin(Node startNode)
        {
            if (startNode != null)
            {
                while (startNode.LeftChild != null)
                {
                    startNode = startNode.LeftChild;
                }
            }

            return startNode.Value;
        }

        public bool Search(int value)
        {
            if (_root == null)
            {
                return false;
            }

            Node actualNode = _root;

            while (actualNode.Value != value)
            {
                if (actualNode.Value > value)
                {
                    if (actualNode.LeftChild != null)
                    {
                        actualNode = actualNode.LeftChild;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (actualNode.RightChild != null)
                    {
                        actualNode = actualNode.RightChild;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Insert(int value)
        {
            _root = InsertRecur(value, _root);
        }

        private Node InsertRecur(int value, Node startNode)
        {
            if (startNode == null)
            {
                startNode = new Node(value);
            }
            else if (value < startNode.Value)
            {
                startNode.LeftChild = InsertRecur(value, startNode.LeftChild);

            }
            else if (value > startNode.Value)
            {
                startNode.RightChild = InsertRecur(value, startNode.RightChild);
            }

            return startNode;
        }
        public void Delete(int value)
        {
            _root = DeleteRecur(value, _root);
        }
        private Node DeleteRecur(int value, Node startNode)
        {
            if (startNode == null)
            {
                return startNode;
            }
            if (value < startNode.Value)
            {
                startNode.LeftChild = DeleteRecur(value, startNode.LeftChild);
            }
            else if (value > startNode.Value)
            {
                startNode.RightChild = DeleteRecur(value, startNode.RightChild);
            }
            else if (startNode.LeftChild  != null && startNode.RightChild != null) // Two children
            {
                startNode.Value = SubtreeMin(startNode.RightChild);
                startNode.RightChild = DeleteRecur(startNode.Value, startNode.RightChild);
            }
            else
            {
                startNode = (startNode.LeftChild != null) ? startNode.LeftChild : startNode.RightChild;
            }
            return startNode;
        }

        public Node GetRoot()
        {
            return _root;
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (_root == null)
                throw new InvalidOperationException();
            return _root.GetEnumerator();
        }
    }
}
