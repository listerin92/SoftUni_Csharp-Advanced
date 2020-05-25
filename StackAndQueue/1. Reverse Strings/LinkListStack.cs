using System;

namespace _1._Reverse_Strings
{
    internal class LinkListStack
    {
        Node top;
        public LinkListStack() => top = null;

        internal void Push(int value)
        {
            Node newNode = new Node(value);
            if (top == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = top;
            }
            top = newNode;
            Console.WriteLine("{0} pushed to stack", value);
        }
        internal void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow. Deletion not possible");
                return;
            }

            Console.WriteLine("Item popped is {0}", top.data);
            top = top.next;
        }
        internal void Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow.");
                return;
            }

            Console.WriteLine("{0} is on the top of Stack", this.top.data);
        }
    }
}
