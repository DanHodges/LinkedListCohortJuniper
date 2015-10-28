using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        //public SinglyLinkedList()
        //{
        //NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        //}


        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            if (values.Length == 0)
            {
                first = new SinglyLinkedListNode(null);
                last = new SinglyLinkedListNode(null);
            }
            else
            {
                first = new SinglyLinkedListNode(values[0] as string);
                last = new SinglyLinkedListNode(values[values.Length -1] as string);
            }
        }

        private SinglyLinkedListNode first;
        private SinglyLinkedListNode last;
        

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if (last.Value == null)
            {
                first = new SinglyLinkedListNode(value);
                //last = new SinglyLinkedListNode(value);
                last = first;
            }
            else
            {
                SinglyLinkedListNode storage = last;
                last = new SinglyLinkedListNode(value);
                storage.Next = last;
            }       
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public string First()
        {
            if (first == null)
            {
                return null;
            }
            else
            {
                return first.Value;
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            throw new NotImplementedException();
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
