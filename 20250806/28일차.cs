//namespace BFS
//{
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

//        // 방문 목록만들기
//        public bool[] visited = new bool[6];
//        public int[] distance = new int[6];
//        public void BFS(int start)
//        {
//            // 예약목록 만들기
//            Queue<int> queue = new Queue<int>();


//            // 예약 목록에 예약하기
//            queue.Enqueue(start);
//            visited[start] = true;
//            distance[start] = 0;

//            // 예약 목록에서 예약을 꺼내서 아직 예약
//            // 안했고 연결되어있고 방문안한 애들 예약하기
//            while (queue.Count > 0)
//            {
//                int now = queue.Dequeue();
//                Console.WriteLine($"방문 : {now}");
//                Console.WriteLine($"단계 : {distance[now]}");

//                for (int next = 0; next < map.GetLength(0); next++)
//                {
//                    // 연결이 되어있는지
//                    if (map[now, next] == 0)
//                        continue;
//                    // 방문이 되어있는지
//                    if (visited[next] == true)
//                        continue;

//                    // 예약하기
//                    queue.Enqueue(next);
//                    visited[next] = true;
//                    distance[next] = distance[now] + 1;
//                }

//            }

//            Console.WriteLine(distance[map.GetLength(0) - 1]);
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

class Program
{
    static void Main()
    {
        int[] deltaY = { -1, 0, 1, 0 };
        int[] deltaX = { 0, -1, 0, 1 };

        int n, m;
        int[,] map;
        bool[,] visited;
        int[,] distance;

        string[] input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        map = new int[n, m];
        visited = new bool[n, m];
        distance = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < m; j++)
            {
                map[i, j] = line[j] - '0';
            }
        }

        // 예약 목록
        Queue<(int, int)> q = new Queue<(int, int)> ();
        visited[0, 0] = true;
        distance[0, 0] = 1;
        q.Enqueue((0, 0));

        // 예약 한거 꺼내오기
        while (q.Count > 0)
        {
            // 오래기다린놈 끄집어오기
            (int y, int x) = q.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nextY = y + deltaY[i];
                int nextX = x + deltaX[i];

                // 범위초과 확인
                if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= m)
                    continue;
                // 연결되어있는지 확인
                if (map[nextY, nextX] == 0)
                    continue;
                // 이미방문했는지확인
                if (visited[nextY, nextX] == true)
                    continue;

                // 예약하기
                q.Enqueue((nextY, nextX));

                // 방문처리
                visited[nextY, nextX] = true;
                distance[nextY, nextX] = distance[y, x] + 1;
            }
        }

        Console.WriteLine(distance[n - 1, m - 1]);
    }
}