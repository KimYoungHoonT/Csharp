//using System.Collections;

//namespace _20250806
//{

//    // 열거자(Enumerator) 
//    // 어떤 데이터 집합을 순서대로 하나씩 탐색하는 기능
//    // IEnumerable 인터페이스
//    // IEnumerator 인터페이스
//    // foreach -> 위의 두가지 인터페이스 개념위에 구축되어있음

//    /*
//                  [컬렉션] ──▶ GetEnumerator()
//                     │
//                     ▼
//            ┌───────────────────┐
//            │  Enumerator 객체   │
//            │───────────────────│
//            │ + MoveNext()      │
//            │ + Current         │
//            └───────────────────┘
//                     │
//                     ▼
//            foreach 루프 실행

//     Start
//       │
//       ▼
//    [컬렉션]
//       │  GetEnumerator()
//       ▼
//    Enumerator 생성
//       │
//       ▼
//    while (MoveNext())
//       │
//       ├─ true ─▶ Current 읽기 ─▶ 루프 본문 실행 ─┐
//       │                                          │
//       └─ false ──────────────────────────────────┘
//       │
//       ▼
//       End
//    */

//    // 배열은 연속된 저장공간에 할당
//    //   []      []      []      []      [] 
//    // 0x1000  0x1004  0x1008  0x1012  0x1016

//    // indexer this[int index]

//    // arr[7]
//    // element_address = base_address + (index* sizeof(T))
//    // 사용자에게는 노출 하지 않고 컴파일/JIT 이 알아서 처리를 해줍니다. 

//    // Head ──▶ [10 | next] ──▶ [20 | next] ──▶ [30 | null]

//    /*
//     Start → node = head
//        │
//        ▼
//        MoveNext()
//        │ true
//        ▼
//        Current = node.Value (10)
//        node = node.Next
//        │
//        ▼
//        MoveNext()
//        │ true
//        ▼
//        Current = node.Value (20)
//        node = node.Next
//        │
//        ▼
//        MoveNext()
//        │ true
//        ▼
//        Current = node.Value (30)
//        node = node.Next (null)
//        │
//        ▼
//        MoveNext()
//        │ false
//        ▼
//        End
//     */

//    // 유니티 
//    // IEnumorator Test()
//    // {
//    //    yield => 내부에서 IEnumerator와 IEnumerable 인터페이스 자동구현 코드 생성
//    //    
//    //    return new waitForSecond(3);
//    //    Consoloe.WriteLine("sdsdsd");
//    // }


//    // IEnumorator MoveRight()
//    // {
//    //    // 오른쪽 으로만 이동하는 코드
//    // }

//    // void MoveUp()
//    // {
//    //    // 위쪽 으로만 이동하는 코드
//    // }

//    // [프레임루프]
//    //    |
//    //    ㄴ StartCourutine(MoveRight) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
//    //    ㄴ StartCourutine(MoveUp) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
//    //    ㄴ 다른 코루틴 있는지 확인?

//    // 코루틴 => 하나의 쓰레드에서 처리되는거다!


//    //public class MyCollection : IEnumerable
//    //{
//    //    private int[] _data;

//    //    public MyCollection(int[] data)
//    //    {
//    //        _data = data;
//    //    }

//    //    public IEnumerator GetEnumerator()
//    //    {
//    //        return new MyEnermerator(_data);
//    //    }

//    //    private class MyEnermerator : IEnumerator
//    //    {
//    //        private int[] _data;
//    //        private int _position = -1; // 시작전 위치

//    //        public MyEnermerator(int[] data)
//    //        {
//    //            _data = data;
//    //        }

//    //        public object Current
//    //        {
//    //            get
//    //            {
//    //                if (_position < 0 || _position >= _data.Length)
//    //                    throw new InvalidOperationException();
//    //                return _data[_position];
//    //            }
//    //        }

//    //        public bool MoveNext()
//    //        {
//    //            _position++;
//    //            return _position < _data.Length;
//    //        }

//    //        public void Reset()
//    //        {
//    //            _position = -1;
//    //        }
//    //    }
//    //}


//    //class Program
//    //{
//    //    static void Main()
//    //    {
//    //        var myData = new MyCollection(new int[] { 10, 20, 30 });

//    //        foreach (int item in myData)
//    //        {
//    //            Console.WriteLine(item);
//    //        }
//    //    }
//    //}



//    // 인접행렬
//    // 단점 : 연결이되어있지 않은 간선까지 표현을 하기에 메모리에 낭비가 있을수 있음
    
//    // 인접리스트
//    // 단점 : 연결되어있지 않은 간선은 기록하지 않기에 정점에 대한 순회가 필요하다. 

//    //class Graph
//    //{
//    //    int[,] adj = new int[6, 6]
//    //    {
//    //        { 0, 1, 0, 1, 0, 0 },
//    //        { 1, 0, 1, 1, 0, 0 },
//    //        { 0, 1, 0, 0, 0, 0 },
//    //        { 1, 1, 0, 0, 0, 0 },
//    //        { 0, 0, 0, 0, 0, 1 },
//    //        { 0, 0, 0, 0, 1, 0 },
//    //    };

//    //    bool[] visited = new bool[6];

//    //    public void DFS(int now)
//    //    {
//    //        // 1. now 부터 방문 후 방문 체크
//    //        Console.WriteLine($"방문 : {now}");
//    //        visited[now] = true;

//    //        // 2. now 와 연결된 정점들을 하나씩
//    //        // 확인해서 아직 방문하지 않은 정점을
//    //        // 방문
//    //        for (int next = 0; next < adj.GetLength(0); next++)
//    //        {
//    //            // 배열을 초과하지 않는지 확인

//    //            if (adj[now, next] == 0)
//    //                continue;

//    //            if (visited[next] == true)
//    //                continue;

//    //            DFS(next);
//    //        }
//    //    }

//    //    public void SearchAll()
//    //    {
//    //        visited = new bool[6];
//    //        for (int now = 4; now < adj.GetLength(0); now++)
//    //        {
//    //            if (visited[now] == false)
//    //            {
//    //                DFS(now);
//    //                count++;
//    //            }
//    //        }
//    //    }
//    //}

//    class Program
//    {
//        static int[,] adj = new int[50, 50];
//        static bool[,] visited = new bool[50, 50];
//        static int[] dY = { -1, 0, 1, 0 };
//        static int[] dX = { 0, -1, 0, 1 };
//        static int m, n, k;

//        static void DFS(int y, int x)
//        {
//            //1 단계 방문처리
//            visited[y, x] = true;
//            //2 연결되어있는 노드 확인해서 아직 방문 안한녀석 방문
//            for (int i = 0; i < 4; i++)
//            {
//                int newY = y + dY[i];
//                int newX = x + dX[i];

//                if (newY < 0 || newY >= n || newX < 0 || newX >= m)
//                    continue;

//                if (adj[newY, newX] == 0)
//                    continue;

//                if (visited[newY, newX] == true)
//                    continue;

//                DFS(newY, newX);
//            }
//        }

//        static void Main()
//        {
//            int t = int.Parse(Console.ReadLine());
//            while (t-- > 0) 
//            {
//                int ret = 0;

//                Array.Clear(adj);
//                Array.Clear(visited);

//                string[] s = Console.ReadLine().Split();
//                m = int.Parse(s[0]);
//                n = int.Parse(s[1]);
//                k = int.Parse(s[2]);

//                int x, y;

//                for (int i = 0; i < k; i++)
//                {
//                    s = Console.ReadLine().Split();
//                    x = int.Parse(s[0]);
//                    y = int.Parse(s[1]);
//                    adj[y, x] = 1;
//                }

//                // SearchAll = 이 함수를 만들라는게 아니라 
//                // 이전에 했던 SearchAll 함수를 기억하라고!!!!!
//                for (int i = 0; i < n; i++)
//                {
//                    for (int j = 0; j < m; j++)
//                    {
//                        // 연결되있음?
//                        if (adj[i, j] == 0)
//                            continue;

//                        // 방문했음?
//                        if (visited[i, j] == true)
//                            continue;

//                        // DFS 아 오케이 돌자
//                        DFS(i, j);

//                        // ret++; 돌고 나왔으니 덩어리 + 1
//                        ret++;
//                    }
//                }

//                Console.WriteLine(ret);
//            }
//        }
//    }
//}
