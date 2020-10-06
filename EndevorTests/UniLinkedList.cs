using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EndevorTests
{
    public class UniLinkedList<T> : IUniLinkedList<T>, IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        private int count = 0;

        public int Count { get { return count; } }
        public Node<T> First { get { return head; } }
        public Node<T> Last { get { return tail; } }

        public UniLinkedList(T data)
        {
            head = new Node<T>(data);
            tail = head;
            count = 1;
        }

        public UniLinkedList() { }

        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'Add', argument 'data' can't equal null");

            if (count == 0)
            {
                head = new Node<T>(data);
                tail = head;
            }
            else
            {
                Node<T> addition = new Node<T>(data);
                tail.Next = addition;
                tail = addition;
            }
            count++;
        }

        public bool Remove(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'Add', argument 'data' can't equal null");

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце списка
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        // Если current.Next равен null, значит узел последний
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // Удаляется первый узел
                        head = current.Next;

                        // а если теперь список пуст
                        if (head == null)
                            Clear();
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool AppendAfter(T insertData, T previousData)
        {
            if (insertData == null || previousData == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(previousData))
                {
                    Node<T> node = new Node<T>(insertData);
                    node.Next = current.Next;
                    current.Next = node;
                    if (current == tail)
                        tail = current.Next;
                    count++;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void AppendFirst(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> first = new Node<T>(data);
            first.Next = head;
            head = first;
            count++;
        }

        public bool Contains(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public List<T> GetAllData()
        {
            return this.ToList();
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.count != 0)
                {
                    this.Dispose();
                    head = null;
                    tail = null;
                    count = 0;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
