//using System.Xml.Linq;

//namespace 트리
//{
//    class TreeNode<T>
//    {
//        public T Data;
//        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
//    }
//    class Program
//    {
//        static TreeNode<string> MakeTree()
//        {
//            TreeNode<string> root = new TreeNode<string>() { Data = "A" };
//            {
//                TreeNode<string> nodeB = new TreeNode<string>() { Data = "B" };
//                {
//                    TreeNode<string> nodeD = new TreeNode<string>() { Data = "D" };
//                    {
//                        TreeNode<string> nodeH = new TreeNode<string>() { Data = "H" };
//                        TreeNode<string> nodeI = new TreeNode<string>() { Data = "I" };

//                        nodeD.Children.Add(nodeH);
//                        nodeD.Children.Add(nodeI);
//                    }
//                    TreeNode<string> nodeE = new TreeNode<string>() { Data = "E" };

//                    nodeB.Children.Add(nodeD);
//                    nodeB.Children.Add(nodeE);
//                }
//                TreeNode<string> nodeC = new TreeNode<string>() { Data = "C" };
//                {
//                    TreeNode<string> nodeF = new TreeNode<string>() { Data = "F" };
//                    TreeNode<string> nodeG = new TreeNode<string>() { Data = "G" };

//                    nodeC.Children.Add(nodeF);
//                    nodeC.Children.Add(nodeG);
//                }

//                root.Children.Add(nodeB);
//                root.Children.Add(nodeC);
//            }

//            return root;
//        } 

//        static void PrintTree(TreeNode<string> node)
//        {
//            // 현재 노드의 데이터 출력
//            Console.WriteLine(node.Data);

//            // 내 자식도 똑같이 출력하게 함
//            foreach (var child in node.Children)
//            {
//                PrintTree(child);
//            }
//        }


//        static int GetHeight(TreeNode<string> node)
//        {
//            int height = 0;

//            foreach (var child in node.Children)
//            {
//                int newHeight = GetHeight(child) + 1;
//                //if (height < newHeight)
//                //    height = newHeight;
//                height = Math.Max(height, newHeight);
//            }

//            return height;
//        }

//        static void Main()
//        {
//            var root = MakeTree();
//            PrintTree(root);
//        }
//    }
//}

//namespace 트리
//{
//    class BSTNode
//    {
//        public int Key;
//        public BSTNode Left;
//        public BSTNode Right;

//        public BSTNode(int key)
//        {
//            this.Key = key;
//        }
//    }

//    class BinarySearchTree
//    {
//        private BSTNode _root;

//        // Insert 까지 구현
//        public void Insert(int key)
//        {
//            _root = InsertRec(_root, key);
//        }

//        private BSTNode InsertRec(BSTNode node, int key)
//        {
//            if (node == null)
//                return new BSTNode(key);

//            if (key < node.Key)
//                node.Left = InsertRec(node.Left, key);

//            if (key > node.Key)
//                node.Right = InsertRec(node.Right, key);

//            return node;
//        }

//        // 탐색 
//        public bool Contains(int key)
//        {
//            // 루트부터 시작해서 순회(foreach 아님) 하기
//            var now = _root;

//            while (now != null)
//            {
//                // 지금 이 노드가 니가 찾는 노드 맞음?
//                if (key == now.Key) 
//                    return true;

//                // 아니면 왼쪽 오른쪽 비교 
//                now = (key < now.Key) ? now.Left : now.Right;
//            }

//            // 전부 다했는데 못찾았다 그럼 없음
//            return false;
//        }

//        // 삭제
//        public void Remove(int key)
//        {
//            _root = RemoveRec(_root, key);
//        }

//        private BSTNode RemoveRec(BSTNode node, int key)
//        {
//            // 삭제하려는 노드가 널일때
//            if (node == null)
//                return null;

//            // 삭제하려는 키가 현재 노드보다 작다면
//            if (key < node.Key)
//            {
//                node.Left = RemoveRec(node.Left, key);
//            }
//            // 삭제하려는 키가 현재 노드보다 크다면
//            else if (key > node.Key)
//            {
//                node.Right = RemoveRec(node.Right, key);
//            }
//            // 모두가 아니라면 == 즉 현재 노드가 삭제하려는 노드라면
//            else
//            {
//                // 자식 없는 노드라면
//                if (node.Left == null && node.Right == null)
//                    return null;

//                // 자식이 1개 있는 노드라면
//                if (node.Left == null)
//                    return node.Right;
//                if (node.Right == null)
//                    return node.Left;

//                // 자식이 2개 있는 노드라면
//                BSTNode min = FindMin(node.Right);
//                node.Key = min.Key;
//                node.Right = RemoveRec(node.Right, min.Key);
//            }

//            return node;
//        }

//        private BSTNode FindMin(BSTNode node)
//        {
//            while (node.Left != null)
//            {
//                node = node.Left;
//            }

//            return node;
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            var bst = new BinarySearchTree();
//            int[] data = { 16, 14, 78, 31, 87, 90 };
//            foreach (int i in data)
//            {
//                bst.Insert(i);
//            }

//            bst.Remove(16);
//        }
//    }
//}


// 자기 균형 이진 탐색 트리(self Balancing BST)
// AVL -> Red Black Tree
// AVL => 빡섹게 균형잡는것
// RedBlack Tree => 살짝더 느슨하게 균형을 잡습니다.

// RedBlack Tree : 자기 균형 이진 탐색 트리
// 아이디어 : 빨강 또는 검정 이라는 색이라는 개념을 도입하여 규칙을 생성함
// 규칙 : 
// - 모든 노드는 빨강 또는 검정이다.
// - 루트는 항상 검정이다.
// - 모든 리프(NIL 노드)는 검정이다.
// - 빨강 노드의 자식은 항상 검정이다.
// - 루트에서 어떤 리프까지 가는 모든 경로에 있는 검정 노드 개수는 동일하다.


// (힙트리 - 힙정렬 - 우선순위큐)



namespace PriorityQueue_우선순위큐
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;

                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            } 
        }

        public T Pop()
        {
            T ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] =_heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                if (next == now)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
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
        public int id {  get; set; }

        public int CompareTo(Knight other)
        {
            if (id == other.id)
                return 0;

            return id > other.id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main()
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { id = 20 });
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