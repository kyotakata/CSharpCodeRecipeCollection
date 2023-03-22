using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeRecipeCollection
{
    public class Array<T>
    {
        public Array(int index)
        {
            Items = new T[index];
        }

        private T[] Items { get; set; } = new T[0];

        public void Set(int index, T item)
        {
            Items[index] = item;
        }

        public T Get(int index)
        {
            return Items[index];
        }
    }
}
