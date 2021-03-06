﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniLinkedList
{
    public class Node<T>
    {
        private T _data;

        public T Data { get { return _data; } set { _data = value; } }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this._data = data;
        }
    }
}
