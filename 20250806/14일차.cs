//using System.Diagnostics;
//using System.Xml.Linq;

//namespace MyList
//{
//    [DebuggerTypeProxy(typeof(MyList<>.DebugView))]
//    class MyList<T>
//    {
//        T[] _data = new T[1];
//        public int count { get; set; }
//        public int capacity { get { return _data.Length; } }

//        // 인덱서
//        public T this[int index]
//        {
//            get
//            {
//                if (index >= count)
//                    throw new ArgumentOutOfRangeException(nameof(index));
//                return _data[index];
//            }
//            set
//            {
//                if (index >= count)
//                    throw new ArgumentOutOfRangeException(nameof(index));
//                _data[index] = value;
//            }
//        }

//        public void Add(T item)
//        {
//            // 배열이 남았는지 확인
//            if (count >= capacity)
//            {
//                // 배열이 남지 않았으니까 배열을 늘려줌
//                T[] newArr = new T[count * 2];

//                // 새로운 배열이 생겼으니까 이사하기
//                for (int i = 0; i < count; i++)
//                {
//                    newArr[i] = _data[i];
//                }

//                // 새로운 배열을 기존 배열에 연결
//                _data = newArr;
//            }

//            // 이제 배열에 빈 공간이 생김
//            _data[count] = item;
//            // count == 5
//            // _data[0] _data[1] _data[2] _data[3] _data[4] 
//            //   [1]      [2]      [4]      [5]      [5]      
//            count++;
//        }

//        public void RemoveAt(int index)
//        {
//            // 삭제를 해야되는데 꼭 삭제해야하나?
//            for (int i = index; i < count - 1; i++)
//            {
//                _data[i] = _data[i + 1];
//            }

//            count--;
//        }

//        // ===== 디버거 전용 프록시 =====
//        internal sealed class DebugView
//        {
//            private readonly MyList<T> _list;
//            public DebugView(MyList<T> list) { _list = list; }

//            // 디버거에서 바로 자식 아이템으로 보이게 함
//            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
//            public T[] Items
//            {
//                get
//                {
//                    var arr = new T[_list.count];
//                    Array.Copy(_list._data, 0, arr, 0, _list.count);
//                    return arr;
//                }
//            }
//        }
//    }


//    class Program
//    {
//        static void Main()
//        {
//            MyList<int> list = new MyList<int>();
//            list.Add(1); // 0
//            list.Add(2); // 1
//            list.Add(3); // 2
//            list.Add(4); // 3
//            list.Add(5); // 4

//            list.RemoveAt(2);

//            int a = list[2]; // get
//        }
//    }
//}


using System.Collections.Generic;

// 배열 / 리스트 → 인덱스 접근 빠름 (O(1)), 하지만 중간 삽입/삭제 느림 (O(n))
// 연결 리스트 → 중간 삽입/삭제 빠름 (O(1)), 하지만 인덱스 접근 느림 (O(n))

//namespace LinkedList
//{
//    // 연결리스트의 하나의 요소
//    class Node
//    {
//        public int Data;

//        public Node Next;
//        public Node Prev;
//    }

//    // 노드들이 모인 하나의 집합체 - 자료구조
//    class MyLinkedList
//    {
//        // 현재 연결리스트의 첫번째 노드
//        public Node Head = null;
//        // 현재 연결리스트의 마지막 노드
//        public Node Tail = null;
//        // 현재 연결리스트가 갖고 있는 요소의 개수
//        public int count = 0;

//        // 현재 연결리스트의 마지막 에 노드 추가
//        public Node AddLast(int data)
//        {
//            Node newNode = new Node();
//            newNode.Data = data;

//            if (Head == null)
//                Head = newNode;

//            if (Tail != null)
//            {
//                Tail.Next = newNode;
//                newNode.Prev = Tail;
//            }

//            Tail = newNode;
//            count++;
//            // O(1);
//            return newNode;
//        }
//        
//        // 해당 하는 노드 하나를 삭제
//        public void Remove(Node node)
//        {
//            //                 
//            //  [1] <-> [2] <-> [3] <-> [4] <-> [5]
//            // Head                            Tail

//            // 삭제하려는 노드가 헤드 노드인지 확인
//            if (Head == node)
//            {
//                // 헤드 노드가 맞다면 헤드의 넥스트 즉 다음 번에게 헤드를 넘겨줌
//                Head = Head.Next;
//            }

//            // 지우려는 노드이 마지막집 인지 확인
//            if (Tail == node)
//            {
//                Tail = Tail.Prev;
//            }

//            // 지우려는 노드의 이전노드이 널인지 확인
//            if (node.Prev != null)
//            {
//                // (지우려는 노드의 이전노드)의 다음노드을 지우려는 노드의 다음노드로 변경
//                (node.Prev).Next = node.Next;
//            }

//            // 지우려는 노드의 다음노드가 널인지 확인
//            if (node.Next != null)
//            {
//                // (지우려는 노드의 다음노드)의 이전노드를 지우려는 노드의 이전노드로 변경
//                (node.Next).Prev = node.Prev;
//            }

//            count--;
//            // O(1)
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            // 연결리스트는 노드를 리스트로 들고있다.
//            MyLinkedList list = new MyLinkedList();
//            list.AddLast(1);
//            list.AddLast(2);
//            // 연결리스트 노드는 연결리스트의 하나의 요소이다.
//            Node node = list.AddLast(3);
//            list.AddLast(4);
//            list.AddLast(5);
//            list.Remove(node);
//        }
//    }
//}