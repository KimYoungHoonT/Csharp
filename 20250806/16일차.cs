//namespace Stack_Queue
//{
//    class Program
//    {
//        static void Main()
//        {
//            // 선형 자료 구조 - 배열, 리스트, 연결리스트, 스택, 큐
//            // 비선형 자료 구조 - 그래프, 트리, 딕셔너리, 해시셋

//            // 스택 - LIFO(last in first out) = 후입선출

//            // 큐 - FIFO(first in first out) = 선입선출

//            // 스택 (Stack)
//            // 원칙: LIFO (Last In, First Out, 후입선출)
//            // 삽입 (push): 맨 뒤(Top)에만 가능
//            // 삭제 (pop): 맨 뒤(Top)에서만 가능
//            // 즉, 마지막에 넣은 것만 꺼낼 수 있음

//            // 큐 (Queue)
//            // 원칙: FIFO (First In, First Out, 선입선출)
//            // 삽입 (enqueue): 맨 뒤(Rear)에만 가능
//            // 삭제 (dequeue): 맨 앞(Front)에서만 가능
//            // 즉, 먼저 들어간 것부터 꺼낼 수 있음

//            // 스택, 큐 : 고정되어 있는 사용방식을 자료구조로 만들어 둠

//            Stack<int> stack = new Stack<int>();
//            stack.Push(1); 
//            stack.Push(2);
//            stack.Push(3);
//            stack.Push(4);
//            stack.Push(5);
//            int number = stack.Pop(); // 맨뒤에서 아예 하나를 뽑아옴
//            int number2 = stack.Peek(); // 맨뒤에서 하나를 엿보기
//            int result = -1;
//            bool test = stack.TryPop(out result);
//            // Push - 마지막에 데이터 넣기
//            // Pop -  마지막 데이터 뽑아냄
//            // Peek - 마지막 데이터 엿보기


//            DeQueue<int> q = new Queue<int>();
//            q.Enqueue(1);
//            q.Enqueue(2);
//            q.Enqueue(3);
//            q.Enqueue(4);
//            q.Enqueue(5);
//            int number3 = q.Dequeue(); // 맨앞에서 아예 하나를 뽑아옴
//            int number4 = q.Peek(); // 맨앞에서 하나를 엿보기
//                                    // Push - 마지막에 데이터 넣기
//                                    // Enqueue -  첫번째 데이터 뽑아냄
//                                    // Peek - 첫번째 데이터 엿보기
//                                    // 순환 버퍼
//                                    // [][][][][]
//                                    //  ^         
//        }
//    }
//}

//namespace Graph
//{
//    // Graph - 개념적으로는 현실 세계의 사물이나 추상적인 개념간의 연결 관계를 표현 한다.
//    // 정점 - vertex, 노드
//    //  -> 데이터를 표현(위치, 사람, 물건)
//    // 간선 - 엣지
//    //  -> 정점들을 잇는 선(관계, 경로) 


//    class Program
//    {
//        //class Vertex
//        //{
//        //    public List<Vertex> edges = new List<Vertex>();
//        //}

//        //class Edge
//        //{
//        //    public int vertex;
//        //    public int weight;

//        //    public Edge(int v, int w)
//        //    {
//        //        vertex = v;
//        //        weight = w;
//        //    }
//        //}

//        static void Main()
//        {
//            int[,] adj = new int[5, 5] // 입접행렬
//            {
//                { -1, 02, 03, -1, -1 }, // 0 번점 표시
//                { 02, -1, 07, 26, -1 }, // 1 번점 표시
//                { 03, 07, -1, 12, -1 }, // 2 번점 표시
//                { -1, 26, 12, -1, 09 }, // 3 번점 표시
//                { -1, -1, -1, 09, -1 }, // 4 번점 표시
//            };

//            List<int>[] adj = new List<int>[5] // 인접 리스트
//            {
//                new List<int> { 1, 2 },
//                new List<int> { 2, 3 },
//                new List<int> { 0, 2, 3 },
//                new List<int> { 4 },
//                new List<int> { },
//            };

//            //List<Edge>[] adj = new List<Edge>[4]
//            //{
//            //    new List<Edge> { new Edge(1, 2),  new Edge(2, 3) },
//            //    new List<Edge> { new Edge(2, 7),  new Edge(3, 26) },
//            //    new List<Edge> { new Edge(0, 3),  new Edge(3, 12) },
//            //    new List<Edge> { new Edge(4, 9) },
//            //};

//            //List<Vertex> Vertexs = new List<Vertex>();
//            //Vertexs.Add(new Vertex());
//            //Vertexs.Add(new Vertex());
//            //Vertexs.Add(new Vertex());
//            //Vertexs.Add(new Vertex());
//            //Vertexs.Add(new Vertex());

//            //Vertexs[0].edges.Add(Vertexs[1]);
//            //Vertexs[0].edges.Add(Vertexs[2]);

//            //Vertexs[1].edges.Add(Vertexs[0]);
//            //Vertexs[1].edges.Add(Vertexs[2]);
//            //Vertexs[1].edges.Add(Vertexs[3]);

//            //Vertexs[2].edges.Add(Vertexs[0]);
//            //Vertexs[2].edges.Add(Vertexs[2]);
//            //Vertexs[2].edges.Add(Vertexs[3]);

//            //Vertexs[3].edges.Add(Vertexs[1]);
//            //Vertexs[3].edges.Add(Vertexs[3]);
//            //Vertexs[3].edges.Add(Vertexs[4]);

//            //Vertexs[4].edges.Add(Vertexs[3]);

//            
//        }
//    }
//}
