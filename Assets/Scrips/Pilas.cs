using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilas 
{
    public class StackP<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(T t)
            {
                Value = t;
                Next = null;
                Previous = null;
            }

        }
        private Node Head;
        private Node Top;
        private int count = 0;

       
        public void Push(T newvalue)
        {
            Node newNode = new Node(newvalue);
            if (Head == null)
            {
                newNode.Previous = null;
                Head = newNode;
                Top = newNode;
                count++;
                return;
            }
            Top.Next = newNode;
            newNode.Previous = Top;
            Top = newNode;
            count++;
        }
        public int Count()
        {
            return count;
        }
        public void Pop()
        {
            if (count > 0)
            {
                Top = Top.Previous;
                Top.Next = null;
                count--;
            }
            else
            {
                Top = null;
                Head = null;
                count = 0;
            }
        }
        public T GetTop()
        {
            return Top.Value;
        }


    }


  
}
   
