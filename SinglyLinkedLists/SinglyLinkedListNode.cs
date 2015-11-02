using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get
            {
                return next;
            }
            set
            {
                if (this == value)
                {
                    throw new ArgumentException();
                }
                else
                {
                    next = value;
                }
            }
        }

        private string value;
        public string Value 
        {
            get { return value; }
            set { this.value = value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            this.value = value;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            SinglyLinkedListNode node = obj as SinglyLinkedListNode;
            if (node != null)
            {
                return Value.CompareTo(node.Value);
            }
            else
            {
                throw new ArgumentException("blah blah blah");
            }
        }

        public bool IsLast()
        {
            if (null == this.Next)//it is last true
            {
                return true;
            }
            else // it is not true return false
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is SinglyLinkedListNode)
            {
                SinglyLinkedListNode obj2 = obj as SinglyLinkedListNode;
                return Equals(obj2.Value, this.Value);
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
