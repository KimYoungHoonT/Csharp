using System.Runtime.InteropServices;

namespace 힙트리
{
    // 힙 트리 Heap Tree (힙메모리와 관련 없음)
    // 구조 조건 2가지 있음
    // 1. 부모가 항상 자식 보다 크거나(최대힙) 작음(최소힙)
    // 2. 마지막 레발 바로 위 레벨까지는 항상 꽉차있어야 함

    // 위 구조로 인해 노드의 개수를 알면 트리의 구조를 머릿속으로 그릴수 있음

    // 배열(리스트)로 만들수 있기 때문에 공식 적용이 가능함
    // [i]번 노드의 왼쪽 자식 접근 : (2 * i) + 1 
    // [i] 번 노드의 오른쪽 자식 접근 : (2 * i) + 2 
    // [i] 번 노드의 부모 접근 : (i - 1) / 2 

    // 삽입
    // 1. 배열(리스트)의 가장 마지막에 일단 삽입
    // 2. 삽입된 위치부터 부모접근(공식 (i - 1) / 2) 하여 비교 통해 위치 변경
    // 3. 반복

    // 삭제
    // 1. 가장 처음것을 뽑아냄(그게 이걸 사용하는 이유임)
    // 2. 가장 마지막 노드를 뽑아서 루트로 올림
    // 3. 루트부터 자기 왼쪽 과 오른쪽을 비교해서
    //    더큰(최대힙일경우) or 더작은(최소힙일경우) 쪽으로 위치 변경
    // 4. 반복

    // 결과적으로 항상 정렬된 값을 가져올 수 있음
    // 이러한 최소, 최대 힙 구조를 이용해서 힙정렬을 할 수 있고
    // 우선순위 큐 또한 구현 가능

    // 특정 조건에 의한 가장 좋은 솔루션을 뽑아올 때 프라이오리티 큐를 이용하면 굉장히 빠르게 연산 가능
    // 삽입 삭제 O(log n)

    class PriorityQueue<T> where T : IComparable<T> // <= 얘를 상속받아 구현한 클래스만 T 가능
    {
        List<T> _heap = new List<T>();

        // 삽입
        public void Push(T data)
        {
            _heap.Add(data);
            // 일단 노드 맨 아래 추가
            /*
                           [32]
                          /    \
                       [26]    [15]
                      /   \    /   \
                   [19]  [new] [6]  [13]
                   / \    /
                [1][10]  [14]
            */
            int now = _heap.Count - 1;
            while(now > 0)
            {
                // 부모 구하기
                int next = (now - 1) / 2;
                // Count == 10
                //  0   1   2   3   4   5   6  7   8   9
                // [32][26][15][19][14][6][13][1][10][new]   

                /*
				       [0]
				      /   \
			       [1]     [2]
			      /   \   /   \
			     [3] [4] [5]  [6]

		        노드 1 : 
		        (1-1) / 2 = 0

		        노드 2 :
		        (2-1) / 2 = 0

		        노드 3 :
		        (3-1) / 2 = 1

		        노드 4 :
		        (4-1) / 2 = 1

		        노드 5 : 
		        (5-1) / 2 = 2

		        노드 6 : 
		        (6-1) / 2 = 2

		        즉, 부모를 구하는 공식 = (now-1)/2
		         */
                // 내가 부모보다 작다면 브레이크
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // 부모랑 나의 위치를 교환
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                /*
					           [32]
					          /    \
				           [26]    [15]
				          /   \    /   \
			           [19]  [new] [6]  [13]
			           / \    /
			        [1][10] [14]
		        */

                // 검사 위치 이동              
                //  0   1   2   3   4   5   6  7   8   9
                // [32][26][15][19][new][6][13][1][10][14]
                //                  ^                  ^
                //                 next   <--------   now
                now = next;
            }
        }

        public T Pop()
        {
            // 반환 데이터 저장
            T ret = _heap[0];
            /*
					       [32] <---------      
					      /    \         |
				       [26]    [15]      |
				      /   \    /   \     |
			       [19]  [14] [6]  [13]  |
			       / \                   |
			    [1] [10] ----------------- 

	            꼴지 노드를 가장 상위로 올려서 트리의 형태를 유지
	        */
            // 마지막 인덱스 가져오기
            int lastIndex = _heap.Count - 1; 
            // 루트 노드의 데이터를 마지막 데이터와 교체하기
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;
            /*
					           [32]                       ---> [10]     
					          /    \                          /    \   
				           [26]    [15]                    [26]    [15] 
				          /   \    /   \                   /   \    /   \
			           [19]  [14] [6]  [13]             [19]  [14] [6]  [13]
			           / \                              /
			        [1]  [10]  <---                   [1]  
		
	        꼴지 노드를 최상위에 올리고 최하위 노드를 RemoveAt 으로 삭제
	        그리고, 라스트 인덱스 1 감소

                                   [10]
						          /   \
						         /     \
						        /       \
					           /         \
					          /           \  
					         /             \
				          [26] <누가더큼?> [15]      
				         /   \            /   \     
			           [19]  [14]       [6]  [13]  
			           /                    
			        [1]  
	            바로 밑 자식 노드중 더 큰쪽 으로 비교 시도 해야함
	        */


            int now = 0;
            while(true)
            {
                // 왼쪽 자식 노드 구하기
                int left = 2 * now + 1;
                
                // 오른쪽 자식 노드 구하기
                int right = 2 * now + 2;
                /*
				                [0]
				                /   \
			                 [1]    [2]
			                /   \   /   \
			              [3]  [4] [5]  [6]

		            노드 1 : 
		            2 * 0 + 1 = 1

		            노드 2 :
		            2 * 0 + 2 = 2

		            왼쪽 자식 구하는 공식   = 2 * now + 1
		            오른쪽 자식 구하는 공식 = 2 * now + 2
		        */
                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;
                /*
					          now >[26]    10   
					              /    \         
		            얘가더큼--->[10]<next[15]      
				              /   \    /   \     
			               [19]  [14] [6]  [13]  
			               /                    
			            [1]  
		        */

                // 만약, 왼쪽 오른쪽 모두 now 보다 작다면 종료
                if (next == now)
                    break;

                /*
		            위의 경우가 없을것 같지만 있음

				            [7]
			                /   \
			            [5]     [6]

		            루트(7) 삭제 -> 마지막 노드(6)를 루트로 올림

				            [6]
			                /   
			            [5]     
		        */

                // 이제 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                /*
				         --->  [10]                            [26]     
					          /    \                          /    \   
				           [26]    [15]               --->  [10]    [15] 
				          /   \    /   \                   /   \    /   \
			           [19]  [14] [6]  [13]             [19]  [14] [6]  [13]
			           /                                /
			        [1]                               [1]  
		
	            */
                now = next;

                /*
				         --->  [10]                            [26]     
					          /    \                          /    \   
				           [26]    [15]                     [19]    [15] 
				          /   \    /   \                   /   \    /   \
			           [19]  [14] [6]  [13]             [10]  [14] [6]  [13]
			           /                                /
			        [1]                               [1]  
		
	            */
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int id { get; set; }

        public int CompareTo(Knight other)
        {
            if (id == other.id)
                return 0;

            return id < other.id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main()
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { id = 20 } );
            q.Push(new Knight() { id = 10 });
            q.Push(new Knight() { id = 30 });
            q.Push(new Knight() { id = 90 });
            q.Push(new Knight() { id = 40 });

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop().id);
            }
        }
    }
}

namespace BFSDFS
{
    internal class Program
    {
        static bool[,] visited = new bool[50, 50]; // 방문 배열 (최대크기가 50이니까)
        static int[] deltaY = { -1, 0, 1, 0 };  // Y 축 좌표
        static int[] deltaX = { 0, -1, 0, 1 };  // X 축 좌표
        static int m, n, k;  // 가로 m, 세로 n, 배추 개수 k
        static int[,] adj = new int[50, 50];    // 맵 배열 (최대크기가 50이라 했음)

        static void DFS(int y, int x)
        {
            visited[y, x] = true;
            for (int i = 0; i < 4; i++)
            {
                int newY = y + deltaY[i];
                int newX = x + deltaX[i];

                if (newY < 0 || newY >= n || newX < 0 || newX >= m)
                    continue;
                if (adj[newY, newX] == 0)
                    continue;
                if (visited[newY, newX] == true)
                    continue;
                DFS(newY, newX);
            }
        }
        void BFS()
        {
            int[] deltaY = { -1, 0, 1, 0 }; // Y축 이동 좌표 : 위, 왼쪽, 아래, 오른쪽
            int[] deltaX = { 0, -1, 0, 1 }; // X축 이동 좌표 : 위, 왼쪽, 아래, 오른쪽
            //      [-1 ] 
            // [-1 ]     [ 1 ] 
            //      [ 1 ]
            int n, m; // 입력받을 n, m 
            int[,] adj; // 맵을 만들 인접행렬
            int[,] visited; // 방문

            string[] input = Console.ReadLine().Split(); // 한줄 통쨰로 입력받아 띄어쓰기로 분할해 배열에 전달
            n = int.Parse(input[0]); // 첫번째 받은 숫자
            m = int.Parse(input[1]); // 두번째 받은 숫자

            adj = new int[n, m]; // 받은 숫자만큼 맵 배열 크기 고정
            visited = new int[n, m]; // 받은 숫자만큼 방문 배열 크기 고정

            // 배열 넘겨준다고 했으니 입력 받기
            for (int i = 0; i < n; i++)
            {
                // 한줄 한줄 들어오니까 한줄 일단 입력 받기 ex) 101111
                string line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    // 입력받은 한줄을 한칸씩 짤라서 맵 배열에 하나씩 넣어주기
                    adj[i, j] = line[j] - '0'; // <-- 여기 나온 '0'은 숫자 48 
                                               // 즉, line[j] 에서 나온 문자 또한 아스키코드 48 (1은 49)
                                               // 아스키코드 뺄샘을 통해서 숫자형식으로 변환
                }
            }

            #region
            Queue<(int, int)> q = new Queue<(int, int)>();
            visited[0, 0] = 1;
            q.Enqueue((0, 0));
            while (q.Count > 0)
            {
                (int y, int x) = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newY = y + deltaY[i];
                    int newX = x + deltaX[i];

                    if (newY < 0 || newY >= n || newX < 0 || newX >= m)
                        continue;

                    if (adj[newY, newX] == 0)
                        continue;

                    if (visited[newY, newX] > 0)
                        continue;

                    visited[newY, newX] = visited[y, x] + 1;
                    q.Enqueue((newY, newX));
                }
            }

            Console.WriteLine(visited[n - 1, m - 1]);
            #endregion

        }

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine()); // 회차
            while (t-- > 0) // 회차 돌때마다 1씩 후위감소연산 
            {
                int ret = 0;

                Array.Clear(adj); // 회차라는건 배열을 그대로 쓴다는거니까 배열 초기화
                Array.Clear(visited); // 회차라는건 배열을 그대로 쓴다는거니까 배열 초기화
                string[] input = Console.ReadLine().Split(); // 2번째 줄에 m, n, k 준다고 했으니까 한줄 받기
                m = int.Parse(input[0]); // 한줄 받아서 분리
                n = int.Parse(input[1]); // 한줄 받아서 분리
                k = int.Parse(input[2]); // 한줄 받아서 분리

                int x, y; // 그 밑에줄부터 배추에 대한 x, y 좌표 준다고 했으니까 

                for (int i = 0; i < k; i++) // 배추 준다고 한 k 개수만큼 포문 돌기
                {
                    string[] delta = Console.ReadLine().Split(); // 좌표 x y 주니까 한줄 받아서 띄어쓰기로 분리
                    x = int.Parse(delta[0]); // 한줄 받아서 분리
                    y = int.Parse(delta[1]); // 한줄 받아서 분리
                    adj[y, x] = 1; // 배추 있는 좌표 받았으니 배열에 해당 좌표에 배추 심기
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (adj[i, j] == 0)
                            continue;
                        if (visited[i, j] == true)
                            continue;
                        DFS(i, j);
                        ret++;
                    }
                }

                Console.WriteLine(ret);
            }
        }
    }
}
