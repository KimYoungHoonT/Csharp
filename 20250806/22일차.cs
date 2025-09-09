//using System.Security.Cryptography.X509Certificates;

//namespace 이진_검색_트리_binary_search_tree_BST
//{
//    // 이진 검색 트리 
//    // 왼쪽값은 다 나보다 작은값
//    // 오른쪽값은 다 나보다 큰값
//    // 잘 정리되어있다는 기준으로 값을 빠르게 찾기 가능 O(log n)
//    // 정돈된 값을 넣을 경우 트리의 균형이 깨질수 있다
//    // 균형이 깨진 이진 검색 트리는 탐색 속도가 느려진다.O(n)

//    // BST 시간 복잡도
//    // 평균: O(log n) (트리가 균형잡혀 있을 때)
//    // 최악: O(n) (트리가 한쪽으로 치우쳐서 사실상 연결 리스트가 되었을 때)

//    // 균형이 맞지 않는 트리 편향트리 (skewed tree)
//    // 균형이 완벽히 잘 맞는 트리 완전 이진트리 (perfect binary tree)
//    // BST 에는 강제로 균형을 유지하는 규칙이 없음
//    // 입력 데이터의 순서에 따라, 최선과 최악 이 나뉨

//    // 자기 균형 이진 탐색 트리 (self-balacing BST)
//    // 균형이 깨지는걸 대비하기 위해 스스로 복구하는 균형 트리라는게 있다
//    // 추가적을 삽입시 스스로 균형을 유지하게끔 만들어진 트리
//    // AVL, RedBlack treee, B Tree 

//    // AVL - 강제로 높이 차이를 1 이내로 제한, 아주 강하게 균형을 잡는다.
//    //  ㄴ> 균형을 강하게 잡는 대신, 연산이 많이 이루어짐
//    // RedBlack - 균형유지시 조금 느슨한 제한을 걸어둠
//    //  ㄴ> 연산은 상대적으로 적으나, 구현이 매우 어렵다.
//    // 최악이나 최선이나 항상 O(log n)의 시간을 보장한다.

//    // 레드블랙 트리는 스스로 균형을 유지하는 이진 탐색트리의 한 종류
//    // 구현 개념은 빨강, 검정 이라는 색의 개념을 도입
//    // 색과 규칙을 통해 편향 트리가 발생되지 않도록 함
//    // 레드블랙 트리의 규칙 5가지
//    // ㄴ> 모든 노드는 빨강 또는 검정이다.
//    // ㄴ> 루트는 항상 검정이다.
//    // ㄴ> 모든 리프(NIL)는 검정이다.
//    // ㄴ> 빨강 노드의 자식은 항상 검정노드이다. (빨강 - 빨강 불가)
//    // ㄴ> 루트에서 어떤 리프까지 가는 모든 경로에 있는 검정노드 개수는 동일 하다.

//    // 항상 삽입, 삭제, 탐색 O(log n) 시간이 보장이됨

//    // 레드 블랙 트리가 무엇인가?
//    // 자기 균형 이진 탐색 트리의 한 종류
//    // 노드에 색붙이고, 특정 규칙을 통해 트리 높이가 log n에 머물도록 보장
//    // 삽입 삭제 탐색 최악의 경우에도 모두 O(log n) 성능 갖음

//    // 힙트리 -> 힙정렬 => 우선순위큐 => 에이스타!


//    // [0][1][2][3][4][5][6][7][8][9] [492][12][10]

//    class BstNode<T>
//    {
//        public int Key;
//        public T Value;
//        public BstNode<T> Left;
//        public BstNode<T> Right;

//        public BstNode(int key, T value) 
//        { 
//            Key = key;
//            Value = value;
//        }
//    }

//    class BinarySearchTree<T>
//    {
//        private BstNode<T> _root;

//        // 삽입
//        public void Insert(int key, T value)
//        {
//            _root = InsertRec(_root, key, value);
//        }

//        private BstNode<T> InsertRec(BstNode<T> node, int key, T value)
//        {
//            if (node == null)
//                return new BstNode<T>(key, value);

//            if (key < node.Key)
//                node.Left = InsertRec(node.Left, key, value);

//            if (key > node.Key)
//                node.Right = InsertRec(node.Right, key, value);

//            return node;
//        }

//        // 탐색 
//        public bool Contains(int key)
//        {
//            var now = _root;
//            while (now != null)
//            {
//                if (key == now.Key)
//                    return true;

//                now = (key < now.Key) ? now.Left : now.Right;
//            }

//            return false;
//        }

//        // 어떠한 값이 들어있는지 반환하는
//        public BstNode<T> Find(int key)
//        {
//            var now = _root;
//            while (now != null)
//            {
//                if (key == now.Key)
//                    return now;

//                now = (key < now.Key) ? now.Left : now.Right;
//            }

//            return null;
//        }

//        // 삭제
//        public void Remove(int key)
//        {
//            _root = RemoveRec(_root, key);
//        }

//        private BstNode<T> RemoveRec(BstNode<T> node, int key)
//        {
//            if (node == null)
//                return null;

//            if (key < node.Key)
//            {
//                node.Left = RemoveRec(node.Left, key);
//            }
//            else if (key > node.Key)
//            {
//                node.Right = RemoveRec(node.Right, key);
//            }
//            else
//            {
//                // case 1 : 리프
//                if (node.Left == null && node.Right == null)
//                    return null;

//                // case 2 : 자식 1개
//                if (node.Left == null) 
//                    return node.Right;
//                if (node.Right == null)
//                    return node.Left;

//                // case 3 : 자식 2개
//                BstNode<T> min = FindMin(node.Right);
//                node.Key = min.Key;
//                node.Right = RemoveRec(node.Right, min.Key);
//            }

//            return node;
//        }

//        private BstNode<T> FindMin(BstNode<T> node)
//        {
//            while (node.Left != null)
//                node = node.Left;

//            return node;
//        }
//    }

//    class Program
//    {

//        // 0 1 2 3 4 5 6 7 8 9  -> ChangeBinary(List<int> ret, int lo, int hi) -> 4 1 0 2 3 7 5 6 8 9
        
//        static List<int> ChangeBinary()
//        {
//            List<int> result = new List<int>();

//            ChangeBinary(result, 0, 9);

//            return result;
//        }

//        static void ChangeBinary(List<int> ret, int lo, int hi)
//        {
//            if (lo > hi)
//                return;

//            int mid = (lo + hi) / 2;
//            ret.Add(mid);

//            ChangeBinary(ret, lo, mid - 1);
//            ChangeBinary(ret, mid + 1, hi);
//        }

//        static void Main()                             
//        {
//            var bst = new BinarySearchTree<int>();           

//            foreach (var item in ChangeBinary())
//            {
//                Console.WriteLine(item);
//                bst.Insert(item, item);
//            }
//        }
//    }
//}
///*
//1
// \
//  2
//   \
//    3
//     \
//      4
//       \
//        5
//*/



//// 필수 구현 범위
//// BFS, DFS, 트리 높이구하기, 정렬된 배열로 이진 탐색 트리 배열로 바꾸기, 리스트, 연결리스트


//// 권장 구현 범위
//// 스택, 큐, 해시테이블

//// 누적합 알고리즘, LIS, 정렬