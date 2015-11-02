using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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
                last = new SinglyLinkedListNode(values[values.Length - 1] as string);
            }
        }

        private int count = -1;
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

        //public void AddLast(string value)
        //{
        //    Console.WriteLine("value", value);
        //    if (null == first.Value)
        //    {
        //        first = new SinglyLinkedListNode(value);
        //        last = first;
        //    }
        //    else
        //    {

        //    }

        //}
        public void AddLast(string value)
        {
            if (last.Value == null)
            {
                count++;
                first = new SinglyLinkedListNode(value);
                last = first;
            }
            else
            {
                count++;
                SinglyLinkedListNode storage = last;
                last = new SinglyLinkedListNode(value);
                storage.Next = last;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return count;
        }

        public string ElementAt(int index)
        {
            if (index == 0)
            {
                if (count == -1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return first.ToString();
                }
            }
            else if (index == count)
            {
                if (last == null)
                {
                    return null;
                }
                else
                {
                    return last.ToString();  
                }
            }
            else if (index < count)
            {
                if (GetIndex(index) != null)
                {
                    return GetIndex(index).ToString();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public SinglyLinkedListNode GetIndex(int index)
        {
            int z = 0;
            SinglyLinkedListNode thing = first.Next;
            for (int i = 0; i < (index -1); i++)
            {
                if (thing.Next != null)
                {
                    thing = thing.Next;
                }
                else
                {
                    return null;
                }
            }
            return thing;
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
            try
            {
                return last.ToString();
            }
            catch (Exception)
            {
                return null;
            }
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
            List<string> NodeList = new List<string>();
            if (Count() == -1)
            {
                return NodeList.ToArray();
            }
            NodeList.Add(first.ToString());
            int i = 1;
            while (GetIndex(i) != null)
            {
                if (GetIndex(i).ToString() != null)
                {
                    NodeList.Add(GetIndex(i).ToString());
                }
                else
                {
                    continue;
                }
                i++;
            }
            return NodeList.ToArray();
        }

        public override string ToString()
        {
            if (first.Value == null) { return "{ }"; }
            else
            {
                string[] NodeArray = ToArray();
                string result = "{ ";
                for (int i = 0; i < NodeArray.Length; i++)
                {
                    result += "\"" + NodeArray[i];
                    if (i + 1 < NodeArray.Length)
                    {
                        result += "\", ";
                    }
                }
                result += "\" }";
                return result;
            }
        }
    }
}