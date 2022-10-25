using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        public Stack(params T[] elements)
        {
            Elements = elements.ToList();
        }

        public List<T> Elements { get; set; }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            {
                Elements.Insert(0, item);
            }
        }

        public void Pop()
        {
            if (Elements.Count != 0)
            {
                T itemToRemove = Elements[0];
                Elements.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
