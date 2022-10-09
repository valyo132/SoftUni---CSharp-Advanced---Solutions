using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            list = new Stack<T>();
        }

        private Stack<T> list;

        public int Count { get { return list.Count; } }

        public void Add(T element)
        {
            list.Push(element);
        }

        public T Remove()
        {
            return list.Pop();
        }
    }
}
