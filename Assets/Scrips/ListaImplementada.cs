using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleLinkList<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
    Node Head { get; set; }
    int count = 0;

    public void AddNodeAtStart(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            count = count + 1;
        }
        else if (Head != null)
        {
            Node tmp = Head;
            Head = newNode;
            Head.Next = tmp;
            count = count + 1;

        }
    }
   
    public void AddNodeAtEnd(T value)
    {
        if (Head == null)
        {
            AddNodeAtStart(value);
        }
        else if (Head != null)
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            Node newNode = new Node(value);
            tmp.Next = newNode;
            count = count + 1;
        }
    }
    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNodeAtStart(value);
        }
        else if (position == count)
        {
            AddNodeAtEnd(value);
        }
        else if (position > count)
        {
            Debug.Log("Eso no se puede hacer papu");
        }
        else
        {
            int currentPosition = 0;
            Node tmp = Head;
            while (currentPosition < position - 1)
            {
                tmp = tmp.Next;
                currentPosition = currentPosition + 1;
            }
            Node nodeAtPosition = tmp.Next;
            Node newNode = new Node(value);

            tmp.Next = newNode;
            newNode.Next = nodeAtPosition;

            count = count + 1;
        }
    }

   



    public T GetNodeAtStart()
    {
        if (Head == null)
        {
            throw new Exception();
        }
        else
        {
            return Head.Value;
        }
    }
    public T GetNodeAtEnd()
    {
        if (Head == null)
        {
            throw new Exception();
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }
    }
    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeAtStart();
        }
        else if (position == count - 1)
        {
            return GetNodeAtEnd();
        }
        else if (position > count)
        {
            throw new Exception();
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            return tmp.Value;
        }
    }
    public void RemoveAtStart()
    {
        if (Head == null)
        {
            Debug.Log("Eso no se puede hacer");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = null;
            Head = newHead;
            count = count - 1;
        }
    }
    public void RemoveAtEnd()
    {
        Node tmp = Head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }
        Node finalNode = tmp.Next;
        finalNode = null;
        tmp.Next = null;
        count = count - 1;

    }

    public int GetCount()
    {
        return count;
    }
    public void RemoveNodeAtPosition(int position)
    {
        if (position == 0)
        {
            RemoveAtStart();
        }
        else if (position == count - 1)
        {
            RemoveAtEnd();
        }
        else if (position > count)
        {
           Debug.Log("Eso no se puede hacer papu");
        }
        else
        {
            int iterator = 0;
            Node previousNode = Head;
            while (iterator < position - 1)
            {
                previousNode = previousNode.Next;
                iterator = iterator + 1;
            }
            Node currentNode = previousNode.Next;
            Node nextNode = currentNode.Next;

            currentNode.Next = null;
            currentNode = null;
            previousNode.Next = null;

            previousNode.Next = nextNode;
            count = count + 1;
        }

    }

    private Node GetLastNode()
    {
        Node tmp = Head;
        while (tmp.Next != Head)
        {
            tmp = tmp.Next;
        }
        return tmp;
    }
    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Console.WriteLine("Acceso denegado rufián");
        }
        else
        {
            Head.Value = value;
        }
    }
    public void ModifyAtEnd(T value)
    {
        if (Head == null)
        {
            Console.WriteLine("Acceso denegado rufián");
        }
        else
        {
            Node node = GetLastNode();
            node.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == count - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position >= count || position < 0)
        {
            Console.WriteLine("Acceso denegado rufián");
        }
        else
        {
            Node tmp = Head;
            int iterator = 0;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            tmp.Value = value;
        }

    }


}
