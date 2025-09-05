namespace 다익스트라_Dijkstra
{
    class Graph
    {
        int[,] adj = new int[8,8]
        {
            { -1, 10, -1, 18, -1, -1, -1, -1 },
            { 10, -1, 05, 06, -1, -1, -1, -1 },
            { -1, 05, -1, -1, -1, -1, -1, -1 },
            { 18, 06, -1, -1, 13, -1, -1, -1 },
            { -1, -1, -1, 13, -1, 14, 08, -1 },
            { -1, -1, -1, -1, 14, -1, -1, 17 },
            { -1, -1, -1, -1, 08, -1, -1, 26 },
            { -1, -1, -1, -1, -1, 17, 26, -1 },
        };

        public void Dijkstra(int start)
        {
            bool[] visited = new bool[8];
            int[] distance = new int[8];
            Array.Fill(distance, Int32.MaxValue);
            int[] parent = new int[8];

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보 찾기 (최단 거리 후보)

                // 가장 유력한 후보의 거리 번호를 저장 하기 위한 변수
                int closest = Int32.MaxValue;
                int now = -1;

                // 각 정점을 순회 하면서 애당초 얘가 후보가 맞는지(연결이 되어있는지) 확인
                for (int i = 0; i < 8; i++) 
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i] == true)
                        continue;

                    // 아직 발견(예약)된 적이 없거나, 기존 후보보다 멀면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;

                    closest = distance[i];
                    now = i;
                }

                // closest = 10
                // now = 1

                if (now == -1)
                    break;

                // 제일 좋은 후보 방문
                visited[now] = true;

                // 방문한 정점의 인접점을 확인해서 최단거리를 갱신해야함
                for (int next = 0; next < 8; next++)
                {
                    // 연결이 되어있지 않은 정점 스킵
                    if (adj[now, next] == -1)
                        continue;

                    // 이미 방문한 정점도 스킵
                    if (visited[next] == true)
                        continue;

                    // 새로 조사된 인접 정점의 최단거리 계산
                    int nexrDist = distance[now] + adj[now, next];
                    // 위의 인접 정점의 최단거리를 갱신
                    if (nexrDist < distance[next])
                    {
                        distance[next] = nexrDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }

    class Program 
    {
        // 다익스트라(Dijkstra) -> BFS를 알면 얘도 이해하기 쉽다. -> AStar
                


        static void Main()
        { 
            Graph graph = new Graph();
            graph.Dijkstra(0);
        }
    }
}

//        bool[] found = new bool[6];
//        int[] parant = new int[6];  // parant[0] => 0번 정점의 부모가 누구야?
//        int[] distance = new int[6]; // distance[0] 해당 정점까지 걸린 길이 몇개야?

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
//                    distance[next] = distance[0] + 1;
//                }
//            }
//        }



// 권장(이라 쓰고 필수)사항

// - 9월 30일 까지 총 평일 18일 남음, 3주도 안남음

// - 그래서, 9/30 까지 만들 프로젝트를 정해야함
// - 9/5 : 개인 프로젝트 뭐만들지 정해오기
// 고려사항 : 
// 1. 9/12 : 1주차에 뭐만들지  // ex) 이동 및 공격 구현
// 2. 9/19 : 2주차에 뭐만들지  // ex) 인벤토리 구현
// 3. 9/26 : 3주차에 뭐만들지  // ex) 기타 게임로직 구현
// 4. 9/30 : 까지 최종 정리    // ex) 뭐뭐 구현

// - 위 내용을 토대로 제출 하십시오.
