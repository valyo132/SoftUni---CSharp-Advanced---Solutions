using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {

        }

        public Box(T input)
        {
            Input = input;
        }

        public T Input { get; set; }

        public int Count(List<T> list, T element)
        {
            int count = 0;
            foreach (var item in list)
            {
               int flag = element.CompareTo(item);

                if (flag < 0)
                    count++;
            }

            return count;
        }
    }
}
