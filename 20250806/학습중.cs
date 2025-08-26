using System;
using System.Diagnostics;

namespace MyList
{
    [DebuggerTypeProxy(typeof(MyList<>.DebugView))]
    class MyList<T>
    {
        public int count; // 실제로 사용중인 데이터 개수
        public int capacity { get { return _data.Length; } } // 메모리에 예약된 배열의 실제 크기

        T[] _data = new T[1];

        public void Add(T item)
        {
            if (count >= capacity)
            {
                T[] newArr = new T[count * 2];

                for (int i = 0; i < count; i++)
                    newArr[i] = _data[i];

                _data = newArr;
            }

            _data[count] = item;
            count++;
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            count--;
        }

        // ===== 디버거 전용 프록시 =====
        internal sealed class DebugView
        {
            private readonly MyList<T> _list;
            public DebugView(MyList<T> list) { _list = list; }

            // 디버거에서 바로 자식 아이템으로 보이게 함
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public T[] Items
            {
                get
                {
                    var arr = new T[_list.count];
                    Array.Copy(_list._data, 0, arr, 0, _list.count);
                    return arr;
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            myList.RemoveAt(2);

        }
    }
}
