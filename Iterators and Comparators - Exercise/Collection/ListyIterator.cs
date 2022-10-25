﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(params T[] allElements)
        {
            AllElements = allElements.ToList();
            CurrIndex = 0;
        }

        public int CurrIndex { get; set; }
        public List<T> AllElements { get; set; }

        public bool Move()
        {
            if (CurrIndex < AllElements.Count - 1)
            {
                CurrIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (++CurrIndex < AllElements.Count)
            {
                CurrIndex--;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (AllElements.Count != 0)
                Console.WriteLine($"{AllElements[CurrIndex]}");
            else
                Console.WriteLine("Invalid Operation!");
        }

        public void PrintAll()
        {
            foreach (var item in AllElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < AllElements.Count; i++)
            {
                yield return AllElements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
