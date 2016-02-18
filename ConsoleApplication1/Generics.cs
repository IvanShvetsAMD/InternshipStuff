using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace SideTasts
{
    class GenericArrayClass<T>
    {
        T[] itemset;

        public T GetItem(int i)
        {
            if (i < itemset.Length && itemset[i] != null)
                return itemset[i];

            throw new Exception("out of array bounds");
        }

        public void SetItem(T obj, int i)
        {
            if (i < itemset.Length)
            {
                itemset[i] = obj;
                return;
            }

            throw new Exception("out of array bounds");
        }

        public void SwapByValue(T obj1, T obj2)
        {
            if (itemset.Contains(obj1) && itemset.Contains(obj2))
            {
                int i1 = IndexOf(obj1);
                int i2 = IndexOf(obj2);

                itemset[i1] = obj2;
                itemset[i2] = obj1;
                return;
            }
            throw new Exception("no such intems");
        }

        public void SwapByIndex(int i1, int i2)
        {
            if (i1 < itemset.Length && i2 < itemset.Length)
            {
                T temp = itemset[i1];
                itemset[i1] = itemset[i2];
                itemset[i2] = temp;
                return;
            }
            throw new Exception("out of array bounds");
        }

        public int IndexOf(T obj)
        {
            for (int i = 0; i < itemset.Length; i++)
            {
                if (obj.Equals(itemset[i]))
                    return i;
            }
            return -1;
        }

        public T this[int i]
        {
            get { return itemset[i]; }
            set { itemset[i] = value; }
        }


        public override string ToString()
        {
            return itemset.Aggregate("Array:", (current, VARIABLE) => current + ("\n\t" + VARIABLE));
        }

        public GenericArrayClass(int size)
        {
            itemset = new T[size];
        }
    }
}