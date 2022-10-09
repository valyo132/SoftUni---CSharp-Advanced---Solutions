using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T>
    {
        public Box(T input)
        {
            Input = input;
        }

        public T Input { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Input}";
        }
    }
}
