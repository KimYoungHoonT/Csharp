//using static System.Net.Mime.MediaTypeNames;

//class Baekjun
//{
//    static void Main(string[] args)
//    {
//        string[] _size = Console.ReadLine().Split(); //미로의 사이즈
//        int n = int.Parse(_size[0]);//가로
//        int m = int.Parse(_size[1]);//세로

//        int[,] maps = new int[n, m];
//        for (int i = 0; i < n; i++)
//        {
//            string line = Console.ReadLine();
//            for (int j = 0; j < m; j++)
//            {
//                maps[i, j] = line[j] - '0';
//            }
//        }

//        int[,] visited = new int[n, m];
//        //int[,] distance = new int[x, y];

//        //  현재위치에서 위 아래 오른쪽 왼쪽
//        int[] goY = { -1, 1, 0, 0 };
//        int[] goX = { 0, 0, 1, -1 };



//        Queue<(int, int)> queue = new Queue<(int, int)>();
//        visited[0, 0] = 1;
//        queue.Enqueue((0, 0));

//        while (queue.Count > 0)
//        {
//            (int y, int x) = queue.Dequeue();

//            //for(int next = 0; next < y; next++)
//            //{
//            //if (maps[n, next] == 0) continue;
//            //if (visited[n, next] == true) continue;

//            for (int i = 0; i < 4; i++)
//            {
//                int NextY = y + goY[i];
//                int NextX = x + goX[i];

//                if (NextY < 0 || NextY >= n || NextX < 0 || NextY >= m)
//                    continue;
//                if (maps[NextY, NextX] == 0)
//                    continue;
//                if (visited[NextY, NextX] > 0)
//                    continue;

//                //예약
//                queue.Enqueue((NextY, NextX));
//                //방문처리, 거리
//                visited[NextY, NextX] = visited[y, x] + 1;
//                //distance[NextY, NextX] = distance[start,start2] +1;

//            }
//        }
//        Console.WriteLine($"방문한 횟수 {visited[n - 1, m - 1]}");

//    }
//}