//namespace DFS
//{
// DFS = 깊이 우선 탐색(Depth first Search)
// DFS 는 그래프를 탐색할 떄 쓰는 알고리즘
// 어떤 버텍스부터 시작해서 인접한 버텍스들을 재귀적으로 방문
// 방문한 정점은 다시 방문하지 않습니다.
// 각 분기마다 가능한 가장 멀~~~~~리 있는 버텍스까지 탐색
// DFS 핵심 : 내가 했던일을 내 다음에게 떠넘긴다.
// DFS의 역활 : 끊긴길 찾기

// BFS = 너비 우선 탐색(Breadth first Search)
// 넓이 X = 가로 * 세로
// 기억을 한다** => Queue 를 통해서 값을 넣고 제일 오래기다른 놈부터 꺼내서 씀
// BFS의 역활 : 그래프 경로를 탐색해서 정보를 기록하는 녀석이지, 최단거리를 찾는 알고리즘이 아니다.

//    class Graph
//    {
//        int[,] adj = new int[6, 6] // 인접행렬 방식
//        {
//            { 0, 1, 0, 1, 0, 0, },
//            { 1, 1, 1, 1, 0, 0, },
//            { 0, 1, 0, 0, 0, 0, },
//            { 1, 1, 0, 0, 0, 0, },
//            { 0, 0, 0, 0, 0, 1, },
//            { 0, 0, 0, 0, 1, 0, }
//        };

//        // 인접리스트 

//        bool[] found = new bool[6];
//        int[] parant = new int[6];  // parant[0] => 0번 정점의 부모가 누구야?
//        int[] distance = new int[6]; // distance[0] 해당 정점까지 걸린 길이 몇개야?
//        int[] dy = 
//        int[] dx

//        public void BFS(int start)
//        {
//            found = new bool[6];
//            Queue<int> queue = new Queue<int>(); // 예약을 하는애
//            queue.Enqueue(start);
//            found[start] = true;
//            parant[start] = start;
//            distance[start] = 0;

//            while (queue.Count > 0)
//            {
//                int now = queue.Dequeue();
//                Console.WriteLine($"방문 : {now}");
//                for (int next = 0; next < 6; next++)
//                {

//                    if (adj[now, next] == 0)
//                        continue;
//                    if (found[next] == true)
//                        continue;
//                    queue.Enqueue(next);
//                    found[next] = true;
//                    parant[next] = now;
//                    distance[next] = distance[now] + 1;
//                }
//            }
//        }

//        public void DFS(int now)
//        {
//            // 1. now 부터 방문 후 방문 체크
//            Console.WriteLine($"방문 : {now}");
//            found[now] = true;

//            // 2. now 와 연결된 정점들을 하나씩 확인,
//            // 아직 방문하지 않은 정점을 방문
//            for (int next = 0; next < adj.GetLength(0); next++)
//            {
//                if (adj[now, next] == 0) // 나랑 연결되어있는지 확인
//                    continue;

//                if (found[next] == true) // 이미 방문했는지 확인
//                    continue;

//                DFS(next); // 나랑 연결되있고 방문 안했으면 방문
//            }
//        }

//        public void SearchAll()
//        {
//            // 어떻게해야  그래프를 전체 다 순회할수 있을까?
//            for (int now = 0; now < adj.GetLength(0); now++)
//            {
//                if (found[now] == false)
//                {
//                    DFS(now);
//                    COUNT++;
//                }
//            }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Graph graph = new Graph();
//            graph.DFS(0);
//            //graph.SearchAll();


//            //graph.BFS(0);
//        }
//    }
//}


// 취업시 중요한것 순위
// 1. 포트폴리오 : 아는지식 총동원
// ㄴ> 서류 라도 붙어야지

// 2. 면접 : 기본지식
// ㄴ> 코테는 원래 준비해서 푸는거임

// 3. 코테 : 새로운 지식
// ㄴ> 얘가 꼴지임

// 가변 배열
//int[][] jaggedArray = new int[3][];
//jaggedArray[0] = new int[5];
//jaggedArray[1] = new int[4];
//jaggedArray[2] = new int[9];

// 동적 배열
// List<int> List = new List<int>();

// 정적 배열
// int[,] 정적임 = new int[2,2];
