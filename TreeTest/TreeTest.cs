using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;

namespace TreeTest
{
    [TestClass]
    public class TreeTest
    {
        private MyTree _myTree;
        private BSTree _yourTree;
        private List<int> _numbers;
        [TestInitialize]
        public void Init()
        {
            _myTree = new MyTree();
            _yourTree = new BSTree();

            Random rand = new Random();
            _numbers = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                _numbers.Add(rand.Next(0,10000));
            }
        }
        [TestMethod]
        public void InsertTest()
        {
            foreach (int number in _numbers)
            {
                _myTree.Insert(number);
                _yourTree.Insert(number);
            }

            EqualTrees(_myTree, _yourTree);
        }

        private bool EqualTrees(MyTree myTree, BSTree yourTree)
        {
            MyEnumerator myTreeEnumerator = new MyEnumerator(myTree);
            MyEnumerator yourTreeEnumerator = new MyEnumerator(yourTree);

            while(yourTreeEnumerator.MoveNext()) {
                if (yourTreeEnumerator.MoveNext() != true)
                {
                    Console.WriteLine("[ERROR] Iterator neobsahuje vsechny prvky");
                    return false;
                }
                if (myTreeEnumerator.Current() != yourTreeEnumerator.Current())
                {
                    Console.WriteLine("[ERROR] Iterator nevraci spravne poradi prvku");
                    return false;
                }
            }
            if (myTreeEnumerator.MoveNext())
            {
                Console.WriteLine("[ERROR] Iterator ma vice prvku");
                return false;
            }
            return true;
        }
    }
}
