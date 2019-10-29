using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerator_practice
{
    class MeList<T>
    {
        T[] items = new T[5];
        int count;

        public void Add(T item)
        {
            if(count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < count; i++)
            //{
            //    yield return items[i];
            //}

            return new meEnumerator(this);
        }

        class meEnumerator : IEnumerator<T>
        {
            int index = -1;
            MeList<T> _list;
            public meEnumerator(MeList<T> _list)
            {
                this._list = _list;
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public T Current
            {
                get
                {

                    if (index < 0 || index >= _list.count)
                        return default(T);
                    return _list.items[index];
                }
            }

            public void Dispose()
            {
                // throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                index++;
                return index < _list.count;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MeList<int> myPartyAges = new MeList<int>();
            myPartyAges.Add(10);
            myPartyAges.Add(20);
            myPartyAges.Add(30);

            IEnumerator<int> rator = myPartyAges.GetEnumerator();
            foreach (var item in myPartyAges)
            {
                Console.WriteLine(item);
            }

        }
    }
}
