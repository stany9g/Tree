using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class MyEnumerator : IEnumerator
    {
        private int _currentindex = 0;
        private List<int> _list;
        public MyEnumerator(MyTree myTree)
        {
            _list = getInOrder(myTree.GetRoot());
        }
        public MyEnumerator(BSTree yourTree)
        {
            _list = getInOrder(yourTree.GetRoot());
        }
        public int Current()
        {
            _currentindex++;
             return _list.ElementAt(_currentindex - 1);
        }

        public bool MoveNext()
        {
            if (_currentindex >= _list.Count())
            {
                return false;
            }
            if (_list.Count() == 0)
            {
                return false;
            }
            return true;
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        private static List<int> getInOrder(Node root)
        {
            Node current = root;
            Stack<Node> stack = new Stack<Node>();
            stack.Clear();
            bool done = false;
            List<int> list = new List<int>();

            while (!done)
            {

                if (current != null)
                {
                    stack.Push(current);
                    current = current.LeftChild;
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        current = stack.Pop();
                        list.Add(current.Value);
                        current = current.RightChild;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }

            return list;

        }
    }
}
