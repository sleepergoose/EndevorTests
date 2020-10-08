using System;
using System.Collections.Generic;
using System.Text;

namespace BiLinkedList
{
    interface IBiLinkedList<T> 
    {
        int Count { get; }
        Node<T> First { get; }
        Node<T> Last { get; }

        void Add(T data);
        bool AppendAfter(T insertData, T previousData);
        void AppendFirst(T data);
        void Clear();
        bool Contains(T data);
        void Dispose();
        List<T> GetAllData();
        bool Remove(T data);
        Node<T> Get(T data);
    }
}
