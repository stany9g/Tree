using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Node
    {
        public int Value;
        public Node LeftChild, RightChild;

        public Node(int value, Node leftChild = null, Node rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }


        public IEnumerator<int> GetEnumerator()
        {
            if (LeftChild != null)
            {
                foreach (var v in LeftChild)
                {
                    yield return v;
                }
            }

            yield return Value;

            if (RightChild != null)
            {
                foreach (var v in RightChild)
                {
                    yield return v;
                }
            }
        }


    }
}
