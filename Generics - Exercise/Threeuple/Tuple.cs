using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T, Y, K>
    {
        public Threeuple(T firstItem, Y secondItem, K thirthItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
            ThirthItem = thirthItem;
        }

        public T FirstItem { get; set; }
        public Y SecondItem { get; set; }
        public K ThirthItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirthItem}";
        }
    }
}
