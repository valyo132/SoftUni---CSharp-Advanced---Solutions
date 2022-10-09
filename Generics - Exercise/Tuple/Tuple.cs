using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, Y>
    {
        public Tuple(T firstItem, Y secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public T FirstItem { get; set; }
        public Y SecondItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}
