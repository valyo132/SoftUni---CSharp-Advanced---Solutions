using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box()
        {

        }

        public Box(T input)
        {
            Input = input;
        }
        public T Input { get; set; }

        public List<T> Swap(List<T> list, int firstIndex, int secondIndex)
        {
            var firstItem = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstItem;

            return list;
        }
    }
}
