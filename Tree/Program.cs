using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTree tree = new MyTree();
            List<int> numbers = new List<int> { 13,15,14,16,8,5,10,9,11 };
            foreach(var number in numbers)
            {
                tree.Insert(number);
            }
            tree.Delete(8);

            Console.Write("test");
        }
    }
}
