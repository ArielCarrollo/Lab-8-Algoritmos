using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkedList<T> : MonoBehaviour
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    private Node head;
    public int length = 0;

    public void InsertAtEnd(T value)
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
            newNode.Previous = current;
        }
        length++;
    }

    public T ObtainNodeAtPosition(int position)
    {
        if (position < 0 || position >= length)
        {
            throw new System.Exception("Posicion no valida");
        }

        Node current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        return current.Value;
    }
}
