using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(params int[] elements)
        {
            Elements = elements.ToList();
        }

        public List<int> Elements { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return Elements[i];
                }
            }

            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return Elements[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
