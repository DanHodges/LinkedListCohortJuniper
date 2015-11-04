using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {   
        private int count = -1;
        private SinglyLinkedListNode first;
        private SinglyLinkedListNode last;

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params string[] values)
        {
            if (values.Length == 0)
            {
                first = new SinglyLinkedListNode(null);
                last = new SinglyLinkedListNode(null);
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    AddLast(values[i].ToString());
                }
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return GetIndex(i).ToString(); }
            set { NodeAt(i).Value = value; }
        }

        public void AddAfter(string existingValue, string value)
        {
            if (existingValue == last.ToString()) { AddLast(value);}
            else
            {
                SinglyLinkedListNode node = first;
                while (node != null)
                {
                    if (existingValue == node.Value)
                    {
                        SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                        newNode.Next = node.Next;
                        node.Next = newNode;
                        count++;
                        break;
                    }
                    else if (node.Next == null) { throw new ArgumentException(); }
                    else { node = node.Next; }
                } 
            }
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode New = new SinglyLinkedListNode(value);
            New.Next = first;
            first = New;
            count ++;
        }

        public void AddLast(string value)
        {
            if (first == null)
            {
                SinglyLinkedListNode thing = new SinglyLinkedListNode(value);
                first = thing;
                last = first;
                count++;
            }
            else if (last.Value == null)
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

        private SinglyLinkedListNode NodeAt(int index)
        {
            SinglyLinkedListNode currentNode = first;
            for (int i = 0; i <= index; i++)
            {
                if (currentNode == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (i == index)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentOutOfRangeException();
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count() { return count + 1; }

        public string ElementAt(int index)
        {
            if (index == 0)
            {
                if (count == -1) { throw new ArgumentOutOfRangeException();}
                else { return first.ToString(); }
            }
            else if (index == count)
            {
                if (last == null) { return null; }
                else { return last.ToString(); }
            }
            else if (index < count)
            {
                //throw new ArgumentException("else if (index < count)");
                if (GetIndex(index) != null) { return GetIndex(index).ToString(); }
                else { throw new IndexOutOfRangeException(); }
            }
            else { throw new ArgumentOutOfRangeException(); }
        }

        public SinglyLinkedListNode GetIndex(int index)
        {
            SinglyLinkedListNode thing = first.Next;
            for (int i = 1; i < index; i++)
            {
                if (thing.Next != null) { thing = thing.Next; }
                else { return null; }
            }
            return thing;
        }

        public string First()
        {
            if (first == null)  { return null; }
            else{ return first.Value; }
        }

        public int IndexOf(string value) {
            int index = -1;
            for (int i = 0; i <= count; i++)
            {
                if (value == NodeAt(i).ToString())
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool IsSorted() {
            for (int i = 0; i < count; i++) {
                if(NodeAt(i) > NodeAt(i + 1))
                {
                    return false;
                }
            } return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            try { return last.ToString(); }
            catch (Exception) { return null; }
        }

        public void Remove(string value)
        {
            int nodeint = IndexOf(value);
            //throw new ArgumentException(count.To)
            if (nodeint == 0)
            {
                if (count == 0)
                {
                    first = null;
                    last = null;
                }
                else
                {
                    first = NodeAt(1);
                }
                count--;
            }
            else if (nodeint == - 1)
            {
                
            }
           else if (nodeint == count)
            {
                last = NodeAt(count - 1);
                last.Next = null;
                NodeAt(count - 2).Next = last;
                //throw new ArgumentException(last.ToString());
                count--;
            }
            else
            {
                NodeAt(nodeint - 1).Next = NodeAt(nodeint + 1);
                count--;
            }
        }

        public void Sort()
        {
            if (count == 0)
            {
                return;
            }
            while (true)
            {
                SinglyLinkedListNode left = first;
                SinglyLinkedListNode right = first.Next;
                bool swapOccured = false;
                while (right != null)
                {
                    if (left > right)
                    {
                        string value = left.Value;
                        left.Value = right.Value;
                        right.Value = value;
                        swapOccured = true;
                    }
                    left = right;
                    right = left.Next;
                }
                if (swapOccured)
                {
                    Sort();
                }
            }
        }

        //public void Sort()
        //{
        //    if (count == 0)
        //    {
        //        return;
        //    }
        //    while (true)
        //    {
        //        SinglyLinkedListNode left = first;
        //        SinglyLinkedListNode right = first.Next;
        //        bool swapOccured = false;
        //        while (right != null)
        //        {
        //            if (left > right)
        //            {
        //                string value = left.Value;
        //                left.Value = right.Value;
        //                right.Value = value;
        //                swapOccured = true;
        //            }
        //            left = right;
        //            right = left.Next;
        //        }
        //        if (!swapOccured)
        //        {
        //            return;
        //        }
        //    }
        //}

        //public void Sort()
        //{
        //    while (!IsSorted())
        //    {
        //        SinglyLinkedListNode left = first;
        //        SinglyLinkedListNode right = first.Next;
        //        while (right != null)
        //        {
        //            if (left > right)
        //            {
        //                string value = left.Value;
        //                left.Value = right.Value;
        //                right.Value = value;
        //            }
        //            left = right;
        //            right = left.Next;
        //        }
        //    }
        //}

        public string[] ToArray()
        {
            List<string> NodeList = new List<string>();
            if (Count() -1 == -1)
            {
                return NodeList.ToArray();
            }
            NodeList.Add(first.ToString());
            int i = 1;
            while (GetIndex(i) != null)
            {
                try
                {
                    NodeList.Add(GetIndex(i).ToString());
                    i++;
                }
                catch { i++; }
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
            //{
            //    int i, j;
            //    int N = count;

            //    if (count == 1)
            //    {
            //        int iffer = string.Compare(first.ToString(), last.ToString());
            //        if (iffer == 1)
            //        {
            //            string storage = first.ToString();
            //            first.Value = last.ToString();
            //            last.Value = storage.ToString();
            //        }
            //    }
            //    else
            //    {
            //        SinglyLinkedListNode node = first;
            //        int counter = 0;
            //        while (counter < count*count)
            //        {
            //            if (ElementAt(count) == node.ToString())
            //            {
            //                node = first;
            //            }
            //            if (node.CompareTo(node.Next) > 0)
            //            {
            //                string NodeValue = node.Value;
            //                node.Value = node.Next.Value;
            //                node.Next.Value = NodeValue;
            //                node = node.Next;
            //            }
            //            else
            //            {
            //                node = node.Next;
            //                if (IndexOf(node.ToString()) == count -1)
            //                {
            //                    node = first;
            //                }
            //            }
            //            counter++;
            //        }                       
            //    }
            //}