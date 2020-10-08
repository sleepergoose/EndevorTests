using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BiLinkedList
{
    public class BiLinkedList<T> : IBiLinkedList<T>, IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        private int count = 0;

        /// <summary>
        /// Returns the total number of elements in a Linked List 
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Returns the first element in a Linked List 
        /// </summary>
        public Node<T> First { get { return head; } }

        /// <summary>
        /// Returns the last element in a Linked List
        /// </summary>
        public Node<T> Last { get { return tail; } }

        /// <summary>
        /// Add element into Linked List
        /// </summary>
        /// <param name="data">Node data</param>
        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException();

            Node<T> node = new Node<T>(data);
            if (count == 0)
                head = node;
            else
            {
                node.Previous = tail;
                tail.Next = node;
            }
            tail = node;
            count++;
        }

        /// <summary>
        /// Inserts data after a specific element
        /// </summary>
        /// <param name="insertData">Inserted data</param>
        /// <param name="previousData">The data after which insertData is inserted</param>
        /// <returns></returns>
        public bool AppendAfter(T insertData, T previousData)
        {
            if (insertData == null || previousData == null)
                throw new ArgumentNullException();

            var node = new Node<T>(insertData);
            var current = head;

            while (current != null)
            {
                if (current.Data.Equals(previousData))
                {
                    if (current == tail)
                        this.Add(insertData);
                    else
                    {
                        node.Previous = current;
                        node.Next = current.Next;
                        current.Next.Previous = node;
                        current.Next = node;
                    }
                    count++;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Add element into head of Linked List
        /// </summary>
        /// <param name="data">Node data</param>
        public void AppendFirst(T data)
        {
            if (data == null)
                throw new ArgumentNullException();

            var node = new Node<T>(data);
            if (count == 0)
            {
                head = node;
                tail = head;
            }
            else
            {
                node.Next = head;
                head = node;
            }
            count++;
        }

        /// <summary>
        /// Clear Linked List
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Returns True if specifid item is present in a Linked List, otherwise, False 
        /// </summary>
        /// <param name="data">Data for searching</param>
        public bool Contains([AllowNull] T data)
        {
            if (data == null)
                return false;

            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Clear();
        }

        /// <summary>
        /// Gets all data in a Linked List as a List<T>
        /// </summary>
        /// <returns>Returns List<T></returns>
        public List<T> GetAllData()
        {
            return this.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Removes item with given data from a Linked List
        /// </summary>
        /// <param name="data">Given data for removing</param>
        /// <returns>Returns True if removing is done, otherwise, False</returns>
        public bool Remove([AllowNull] T data)
        {
            if (data == null)
                return false;

            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == head)
                    {
                        head.Next.Previous = null;
                        head = head.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns Node<T> item by its data
        /// </summary>
        /// <param name="data">Key for finding</param>
        /// <returns>Returns the Node<T> item if it exists; otherwise, returns null</returns>
        public Node<T> Get([AllowNull] T data)
        {
            if (data == null)
                return null;

            var farward = head;
            var backward = tail;

            while (farward != null)
            {
                if (farward.Data.Equals(data))
                {
                    return farward;
                }
                else if (backward.Data.Equals(data))
                {
                    return backward;
                }
                if (farward == backward)
                    return null;

                farward = farward.Next;
                backward = backward.Previous;
            }
            return null;
        }
    }
}


