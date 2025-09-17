namespace BFS
{
    // & | ^ ~
    // & AND     true && true => true
    // 0001
    // 0010
    // 0110 -> ????
    // 트랜지스터 전구 켜지거나 꺼지거나
    // 컴퓨터 -> 트랜지스터의 집합
    // 비트 -> 컴퓨터에서 바이트 자료구조 1Byte 8bit 1 0, 1 
    //    1001 -> 13                   11001001
    //  & 1011                     &   00000000             
    //   ------              =>       ----------
    //    1001                         11001001

    //    1001                         11001001
    //  & 1011                     |   00000000             
    //   ------              =>       ----------
    //    1001                         11001001

    //    1011                         11001001
    //  & 1011                     ^   10101010             
    //   ------              =>       ----------
    //    1001                         01100011

    //    1011                         10101010
    //  ~                           ~            
    //   ------             =>        ----------
    //    0100                         01010101




    //    class Graph
    //    {
    //        int[,] map = new int[,]
    //        {
    //            { 0, 1, 0, 1, 0, 0 },
    //            { 1, 0, 1, 1, 0, 0 },
    //            { 0, 1, 0, 0, 0, 0 },
    //            { 1, 1, 0, 0, 1, 0 },
    //            { 0, 0, 0, 1, 0, 1 },
    //            { 0, 0, 0, 0, 1, 0 }
    //        };

    //        방문 목록만들기
    //        public bool[] found = new bool[6];
    //        public int[] distance = new int[6];
    //        public void BFS(int start)
    //        {
    //            예약목록 만들기
    //            Queue<int> queue = new Queue<int>();

    //            예약 목록에 예약하기
    //            queue.Enqueue(start);
    //            found[start] = true;
    //            distance[start] = 0;

    //            예약 목록에서 예약을 꺼내서 아직 예약
    //             안했고 연결되어있고 방문안한 애들 예약하기
    //            while (queue.Count > 0)
    //            {
    //                int now = queue.Dequeue();
    //                Console.WriteLine($"방문 : {now}");
    //                Console.WriteLine($"단계 : {distance[now]}");

    //                for (int next = 4; next < map.GetLength(0); next++)
    //                {
    //                    범위초과

    //                    연결이 되어있는지
    //                    if (map[now, next] == 0)
    //                        continue;
    //                    방문이 되어있는지
    //                    if (found[next] == true)
    //                        continue;

    //                    예약하기
    //                    queue.Enqueue(next);
    //                    found[next] = true;
    //                    distance[next] = distance[now] + 1;
    //                }

    //            }

    //            Console.WriteLine(distance[5]);
    //        }
    //    }


    //    class Program
    //    {
    //        static void Main()
    //        {
    //            Graph graph = new Graph();
    //            graph.BFS(0);
    //        }

    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] deltaY = { -1, 0, 1, 0 };
    //        int[] deltaX = { 0, -1, 0, 1 };

    //        int n, m;
    //        int[,] map;
    //        bool[,] visited;
    //        int[,] distance;

    //        string[] input = Console.ReadLine().Split();
    //        n = int.Parse(input[0]);
    //        m = int.Parse(input[1]);

    //        map = new int[n, m];
    //        visited = new bool[n, m];
    //        distance = new int[n, m];

    //        for (int i = 0; i < n; i++)
    //        {
    //            string line = Console.ReadLine();
    //            for (int j = 0; j < m; j++)
    //            {
    //                map[i, j] = line[j] - '0';
    //            }
    //        }

    //        // 예약 목록
    //        Queue<(int, int)> q = new Queue<(int, int)>();
    //        visited[0, 0] = true;
    //        distance[0, 0] = 1;
    //        q.Enqueue((0, 0));

    //        // 예약 한거 꺼내오기
    //        while (q.Count > 0)
    //        {
    //            // 오래기다린놈 끄집어오기
    //            (int y, int x) = q.Dequeue();
    //            for (int i = 0; i < 4; i++)
    //            {
    //                int nextY = y + deltaY[i];
    //                int nextX = x + deltaX[i];

    //                // 범위초과 확인
    //                if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= m)
    //                    continue;
    //                // 연결되어있는지 확인
    //                if (map[nextY, nextX] == 0)
    //                    continue;
    //                // 이미방문했는지확인
    //                if (visited[nextY, nextX] == true)
    //                    continue;

    //                // 예약하기
    //                q.Enqueue((nextY, nextX));

    //                // 방문처리
    //                visited[nextY, nextX] = true;
    //                distance[nextY, nextX] = distance[y, x] + 1;
    //            }
    //        }

    //        Console.WriteLine(distance[n - 1, m - 1]);
    //    }
    //}

    //class Graph
    //{
    //    int[,] map = new int[,]
    //        {
    //            { -1, 10, -1, 18, -1, -1, -1, -1 },
    //            { 10, -1, 05, 06, -1, -1, -1, -1 },
    //            { -1, 05, -1, -1, -1, -1, -1, -1 },
    //            { 18, 06, -1, -1, 13, -1, -1, -1 },
    //            { -1, -1, -1, 13, -1, 14, 08, -1 },
    //            { -1, -1, -1, -1, 14, -1, -1, 17 },
    //            { -1, -1, -1, -1, 08, -1, -1, 26 },
    //            { -1, -1, -1, -1, -1, 17, 26, -1 },
    //        };

    //    bool[] visited = new bool[8];
    //    int[] distance = new int[8];
    //    int[] parent = new int[8];

    //    public void Dijkstra(int start)
    //    {
    //        Array.Fill(distance, Int32.MaxValue);
    //        distance[start] = 0;
    //        parent[start] = start;

    //        while (true)
    //        {
    //            // 제일 좋은 후보 찾기 (최단 거리 후보)

    //            // 가장 유력한 후보의 거리와 번호를 저장
    //            int closet = Int32.MaxValue;
    //            int now = -1;

    //            for (int i = 0; i < 8; i++)
    //            {
    //                // 이미 방문한 정점은 스킵
    //                if (visited[i] == true)
    //                    continue;

    //                // 아직 발견된 적이 없거나, 기존 후보보다 멀면 스킵
    //                if (distance[i] == Int32.MaxValue || distance[i] >= closet)
    //                    continue;

    //                // 발겨한 후보중 가장 좋은 후보를 찾음, 정보를 갱신
    //                closet = distance[i];
    //                now = i;
    //            }

    //            if (now == -1)
    //                break;

    //            // 제일 좋은 후보 방문
    //            visited[now] = true;

    //            // 방문한 정점의 인접점 확인해서 최단거리를 갱신하다.
    //            for (int next = 0; next < 8; next++)
    //            {
    //                // 연결이 되어있지 않으면 스킵
    //                if (map[now, next] == -1)
    //                    continue;
    //                // 이미 방문한 정점도 스킵
    //                if (visited[next] == true)
    //                    continue;

    //                // 새로 조사된 인접 정점의 최단거리 계산
    //                int nextDist = distance[now] + map[now, next];
    //                // 위의 인접 정점의 최단거리를 갱신
    //                if (nextDist < distance[next])
    //                {
    //                    distance[next] = nextDist;
    //                    parent[next] = now;
    //                }

    //            }
    //        }
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Graph g = new Graph();
    //        g.Dijkstra(0);
    //    }
    //}
}