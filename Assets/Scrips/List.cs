using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplyLinkedList<T> : MonoBehaviour
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }

    private Node head;
    public int length = 0;

    public void InsertNodeAtStart(T value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
        length++;
    }

    public void InsertNodeAtEnd(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        length++;
    }

    public T ObtainNodeAtPosition(int position)
    {
        if (position < 0 || position >= length)
        {
            // throw new Exception("Invalid position");
        }

        Node current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        return current.Value;
    }

    public T GetRandomNode()
    {
        if (length == 0)
        {
            // throw new InvalidOperationException("The list is empty");
        }

        int index = UnityEngine.Random.Range(0, length);
        return ObtainNodeAtPosition(index);
    }
}