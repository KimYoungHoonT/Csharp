////namespace 자료구조 
////{
////    class Player
////    {

////    }

////    class Monster
////    {
////        public int hp;
////    }

////    class _10일차
////    {
////        // 배열 = 같은 종류의 데이터를 한줄로 묶어놓은 연속된 저장공간
////        // 일반배열 = 고정된 배열 - 크기를 수정하지 못한다.
////        // 배열은 참조 형식이다.

////        // int[] a = new int[6];
////        // a = new int[7];
////        //정리 : 아예 새로운 배열을 만들고 변수의 참조를 변경, 기존 배열은 메모리 어딘가에 남아있다가 나중에 삭제됨

////        // int, flaot, bool = 값 그자체 저장됨 = 값형식 배열
////        // class, array = 힙영역에 생성 그 주소가 스택에 저장됨 = 참조형식 배열

////        // foreach 는 읽기 전용 반복문이다.
////        // 엘리먼트는 읽기전용이라 변경이 불가하다
////        // 값형식은 엘리먼트 자체에 값이 들어가있어 변경불가
////        // 참조형식은 엘리먼트가 주소이기에 그걸 타고 들어가서 내부 필드에 접근하여 내부 필드는 값의 변경이 가능하다.
////        // 단순 조회, 출력, 합계, 검색 최적
////        // 그래서 데이터를 읽기만 할때는 foreach 유용하다 
////        // 배열의 요소를 수정해야할때는 for 문을 사용

////        static void Main()
////        {
////            int[] c = new int[6] { 10, 20, 30, 40, 50, 60 };
////            //int[] c = new int[] { 10, 20, 30, 40, 50, 60 };
////            //int[] c = { 10, 20, 30, 40, 50, 60 };
////            // b[10][20][30][40][50][60]

////            int[] array = new int[6]; // 배열 만들기 공간설정 // a[0][0][0][0][0][0]
////            array[0/*인덱스*/] = 1; // 값 쓰기
////            int b = array[0/*인덱스*/]; // 값 읽기

////            // foreach 는 읽기전용
////            // foreach 받아온 개별 엘리먼트는 수정을 할 수 없음
////            foreach (int item in array)
////            {
////                // item = 10; X
////                int temp = item;
////                Console.WriteLine(item);
////            }

////            Monster[] monsters = new Monster[3]; // heap [Monster][null][null]
////                                                 //          ^            
////            monsters[0] = new Monster();         // heep [Monster]

////            foreach (Monster monster in monsters)
////            {
////                // monster = new Monster  엘리먼트 자체는 수정불가 
////                monster.hp = 10; // 엘리먼트의 내부 필드는 수정 가능
////            }

////            for (int i = 0; i < 6; i++)
////            {
////                array[i] = i;
////            }
////        }
////    }
////}

//namespace Quiz
//{
//    class Program
//    {
//        static void Main()
//        {
//            //========================
//            //문제 1) 합계와 평균 구하기 (누적합)
//            //========================
//            //- 정수 배열 a = { 5, 8, 12, -3, 7 }가 있다.
//            //- 배열의 합계와 평균 을 출력하라.

//            //[출력결과]
//            //Sum = 29
//            //Avg = 5.8

//            //int[] a = { 5, 8, 12, -3, 7 };      // 1) 문제에서 주어진 값으로 초기화
//            //int sum = 0;                        // 2) 합계 누적을 위한 변수 선언

//            //for (int i = 0; i < a.Length; i++)  // 3) 배열 처음부터 끝까지 순회
//            //{
//            //    sum += a[i]; // 4) sum에 현재 요소 더하기
//            //}

//            //float avg = (float)sum / a.Length; // 5) 평균 계산(정수 나눗셈 방지)

//            //Console.WriteLine($"Sum = {sum}"); // 6) 합계 출력
//            //Console.WriteLine($"Avg = {avg}"); // 7) 평균 출력


//            //========================
//            //문제 2) 최대값과 최소값 찾기
//            //========================
//            //- 정수 배열 a = { 15, 3, 9, 27, -5, 8 }이 있다.
//            //- 배열에서 가장 큰 값과 가장 작은 값을 찾아라.

//            //int[] a = { 15, 3, 9, 27, -5, 8 };

//            //int max = a[0];
//            //int min = a[0];

//            //for (int i = 1; i < a.Length; i++)
//            //{
//            //    if (a[i] > max)
//            //    {
//            //        max = a[i];
//            //    }
//            //    if (a[i] < min)
//            //    {
//            //        min = a[i];
//            //    }
//            //}

//            //Console.WriteLine($"Max = {max}"); // 7) 최대값 출력
//            //Console.WriteLine($"Min = {min}"); // 8) 최소값 출력
//            // 갱신 한바퀴씩 제일 작은값
//            // 갱신 한바퀴씩 제일 큰값

//            //[출력결과]
//            //Max = 27
//            //Min = -5

//            //=====================================
//            //문제 3) 빈도수 세기(작은 히스토그램)
//            //=====================================
//            //- 0, 1, 2만 들어있는 정수 배열 nums = { 1,0,2,2,1,0,0,2,1,1 }의
//            //  각 숫자(0,1,2)가 몇 번 나오는지 출력하라.

//            //int[] nums = { 1, 0, 2, 2, 1, 0, 0, 2, 1, 1 };

//            //int[] count = new int[3];

//            //for (int i = 0; i < nums.Length; i++) 
//            //{
//            //    count[nums[i]]++;
//            //}

//            //Console.WriteLine($"0:{count[0]} 1:{count[1]} 2:{count[2]}");

//            //[출력결과]
//            //0:3 1:4 2:3

//            //=====================================
//            //문제 4) 배열 뒤집기(제자리 반전)
//            //=====================================
//            //- 정수 배열 a = { 1, 2, 3, 4, 5, 6 }을
//            //  추가 배열 없이 제자리에서 뒤집어 출력하라.

//            //int[] a = { 6, 5, 4, 3, 2, 1 };

//            //int left = 0;
//            //int right = a.Length -1;

//            //while (left < right) 
//            //{
//            //    int tmp = a[left];
//            //    a[left] = a[right];
//            //    a[right] = tmp;

//            //    left++;
//            //    right--;
//            //}

//            //for (int i = 0; i < a.Length; i++)
//            //{
//            //    Console.Write($"{a[i]} ");
//            //}

//            //[출력결과]
//            //6 5 4 3 2 1


//            //========================
//            //문제 5) 배열 오름차순 정렬 - 선택정렬
//            //========================
//            //- 정수 배열 a = { 42, 17, 8, 99, 23 }가 있다.
//            //- 배열을 오름차순으로 정렬하여 출력하라.
//            //- 단, Array.Sort()는 사용하지 말고 직접 알고리즘을 구현

//            //int[] a = { 42, 17, 8, 99, 23 };

//            //for (int i = 0; i < a.Length; i++) 
//            //{
//            //    int minIndex = i;

//            //    for (int j = i + 1; j < a.Length; j++) 
//            //    {
//            //        if (a[j] < a[minIndex])
//            //            minIndex = j;
//            //    }

//            //    int temp = a[i];
//            //    a[i] = a[minIndex];
//            //    a[minIndex] = temp;
//            //}

//            //foreach(int item in a )
//            //    Console.WriteLine(item);

//            //[출력결과]
//            //8 17 23 42 99
//        }
//    }
//}

////========================
////문제 5) 배열 오름차순 정렬
////========================
////- 정수 배열 a = { 42, 17, 8, 99, 23 }가 있다.
////- 배열을 오름차순으로 정렬하여 출력하라.
////- 단, Array.Sort()는 사용하지 말고 직접 알고리즘을 구현

////[출력결과]
////8 17 23 42 99
///

//using System.Globalization;

//namespace 다차원배열
//{
//    class Program
//    {
//        static public int[,] board = {
//                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
//                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
//         };

//        static void Main()
//        {
//            // 1 1 1 1 1 1 1 1 1 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 0 0 0 0 0 0 0 0 1
//            // 1 1 1 1 1 1 1 1 1 1

//            /*
//             -------------------------------------------------
//            [ 1차원 배열로 10×10 맵을 표현한 경우 ]
//            -------------------------------------------------
//            Index:   0   1   2   3   4   5   6   7   8   9 ...
//            Value:  [1] [1] [1] [1] [1] [1] [1] [1] [1] [1] ...

//            (2, 5) 좌표 → index = 2*10 + 5 = 25  // 매번 계산 필요
//             */

//            /*
//             -------------------------------------------------
//            [ 2차원 배열로 10×10 맵을 표현한 경우 ]
//            -------------------------------------------------
//            Row 0: [1] [1] [1] [1] [1] [1] [1] [1] [1] [1] 
//            Row 1: [1] [0] [0] [0] [*] [1] [0] [0] [0] [1]
//            Row 2: [1] [0] [0] [1] [0] [0] [1] [0] [0] [1]
//            ...
//            Row 9: [1] [0] [0] [0] [0] [0] [0] [0] [0] [1]

//            (2, 5) 좌표 → map[2, 5]  // 직관적, 계산 불필요
//             */

//            // 데이터타입[,] = new 타입[행, 열]
//            int[,] map = new int[10, 10];
//            // map[행, 열] = 값;
//            map[0, 0] = 1;
//            map[0, 1] = 2;
//            map[1, 2] = 3;
//            map[2, 3] = 4;
//            Render();

//            int[,] test = new int[3, 4];

//            int[][] jagged = new int[3][];
//            jagged[0] = new int[3];      // 0행 길이 3
//            jagged[1] = new int[5];      // 1행 길이 5(다름)
//            jagged[1] = new int[4];      // 1행 길이 4(다름)

//            //[ [][][] ]
//            //[ [][][][][] ]
//            //[ [][][][] ]


//            //-10×10 맵을 2차원 배열로 정의하라.
//            //- 1은 벽, 0은 빈칸으로 간주하고, 벽은 '■', 빈칸은 '·' 문자로 출력하라.
//            //- 각 행은 줄바꿈으로 구분한다.

//            //[출력결과]
//            //■ ■ ■ ■ ■ ■ ■ ■ ■ ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ · · · · · · · · ■
//            //■ ■ ■ ■ ■ ■ ■ ■ ■ ■


//            char[][] chars = new char[10][];
//            for (int i = 0; i < chars.Length; i++) chars[i] = new char[10];
//            for (int i = 0; i < chars.Length; i++)
//            {
//                for (int j = 0; j < chars[i].Length; j++)
//                {
//                    if (i == 0 || j == 0 || i == chars.Length - 1 || j == chars.Length - 1) chars[i][j] = '■';
//                    else chars[i][j] = '·';
//                    Console.Write(chars[i][j]);
//                }
//                Console.WriteLine();
//            }

//            //========================
//            //문제 3) 전치(Transpose) 출력
//            //========================
//            //- 3×3 배열을 전치하여 출력하라.
//            //- 전치란 a[r,c]를 aT[c,r]로 바꾸는 것이다.

//            int[,] a = new int[3, 3]
//                    {
//                        { 1, 2, 3 },
//                        { 4, 5, 6 },
//                        { 7, 8, 9 }
//                    };

//            int n = a.GetLength(0);
//            int m = a.GetLength(1);

//            int[,] t = new int[n, m];

//            for (int 행 = 0; 행 < n; 행++)
//            {
//                for (int 열 = 0; 열 < n; 열++)
//                {
//                    t[1, 0] = a[0, 1];
//                }
//            }

//            for (int r = 0; r < t.GetLength(0); r++)
//            {
//                for (int c = 0; c < t.GetLength(1); c++)
//                {
//                    Console.Write($"{t[r, c]} ");

//                }
//                Console.WriteLine();
//            }

//            //[출력결과]
//            // 1 4 7
//            // 2 5 8
//            // 3 6 9

//        }

//        static public void Test()
//        {
//            foreach (int x in board)
//            {
//                Console.Write(x);
//            }
//        }

//        static public void Render()
//        {
//            for (int x = 0; x < board.GetLength(0); x++)
//            {
//                for (int y = 0; y < board.GetLength(1); y++)
//                {
//                    if (board[x, y] == 1)
//                        Console.ForegroundColor = ConsoleColor.Red;
//                    else
//                        Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write('\u25cf');
//                }
//                Console.WriteLine();
//            }
//            Console.ResetColor();
//        }
//    }
//}

//namespace 리스트
//{
//    class Program
//    {
//        static void Main()
//        {
//            // List - 필요할떄 자동으로 커지는 배열
//            // 내부적으로는 배열, 클래스 내부에서 배열을 관리
//            // [ 0 ][ 1 ][ 2 ][ 3 ]   // 꽉 찼음
//            //   ↓
//            // [ 0 ][ 1 ][ 2 ][ 3 ][ _ ][ _ ][ _ ][ _ ]   // 더 큰 배열로 교체

//            List<int> numbers = new List<int>();
//            //List<float> numbers = new List<float>();
//            // 제네릭 문법 <int> : 여기 안에 저장할 데이터의 타입을 지정
//            // 예) List<float>, List<string>, List<Player> 등
//            // 인덱스를 통해 접근

//            //1) 데이터 추가
//            numbers.Add(10); // numbers[0] → 10
//            numbers.Add(10); // numbers[1] → 10
//            numbers.Add(10); // numbers[2] → 10

//            numbers.Add(10); // numbers[4] → 10
//            numbers.Add(20); // numbers[5] → 20
//                             // numbers[6] → 25
//            numbers.Add(30); // numbers[3] → 30
//            numbers.Insert(2, 25); // 1번 인덱스에 25 삽입


//            // numbers.Insert(5, 25); // 리스트범위 초과시 에러

//            // [0][1][2][3]  // 2번 자리에 999 삽입
//            // [0][1][ ][2][3]  → 2,3,4를 한 칸씩 뒤로 이동 후 삽입

//            // 삭제
//            bool test = numbers.Remove(10);  // 지우는데 성공하면 참 반환
//            bool test1 = numbers.Remove(444);  // 지우는데 실패하면 거짓 반환

//            numbers.RemoveAt(1); // 1번 인덱스 삭제

//            //numbers.RemoveAt(6); // 인덱스 초과시 에러

//            // [10][20][30][40][50]
//            // [10][20][40][50]

//            // 중간 삽입, 삭제 에 시간이 오래걸린다.
//            // O(n) - 선형시간
//            //numbers.Clear();

//            // 배열(Array)                리스트(List)  
//            // 크기 고정                  크기 유동적
//            // 접근 속도 빠름             사용 편리
//            // 메모리 절약 가능           삽입 / 삭제 자유로움
//            // 크기 변경 불가             중간 삽입/삭제 시 성능 저하

//            // 결론: 데이터 개수가 변하지 않는다면 배열, 변한다면 리스트

//            // 2) 전체 출력
//            for (int i = 0; i < numbers.Count; i++)
//            {
//                Console.WriteLine($"Index {i} : {numbers[i]}");
//            }

//            //foreach (int val in numbers)
//            //{
//            //    Console.WriteLine(val);
//            //}
//        }
//    }
//}

//using System.Threading;

//namespace 딕셔너리
//{
//    class Monster
//    {
//        public int id;
//        public Monster(int id) { this.id = id; }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            // 딕셔너리는 헤시테이블을 사용함

//            // 고유 키값
//            // ID 가 1234 몬스터 찾아서 HP 깎아라

//            // for문으로 진행시
//            // O(n) - 3초
//            // [ 리스트 검색 ]
//            // [0] → [1] → [2] → ... → [N]   // 처음부터 끝까지 탐색 (O(N))

//            // Dictionary : key - value 쌍
//            // O(1) - 상수시간
//            // [ 딕셔너리검색  ]
//            //    ┌───────┐
//            // ID:1234 → 몬스터 객체  // Key로 바로 찾음 (O(1))
//            //    └───────┘

//            // key = 데이터의 이름표
//            // value = 데이터(내용물)
//            //Dictionary<Key타입, Value타입> 변수명 = new Dictionary<Key타입, Value타입>();
//            // 예: Dictionary<int, string> → Key는 int, Value는 string
//            // 예: Dictionary<int, Monster> → Key는 int, Value는 Monster 클래스

//            //List<Monster> monsters = new List<Monster>();
//            //monsters.Add(new Monster());

//            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
//            dic.Add(1, new Monster(1));
//            // dic.Add(1, new Monster(2));

//            bool test = dic.TryAdd(1, new Monster(1)); // Add 시도하는데 만약 동일키가 있으면 flase 반환 종료

//            dic[1234] = new Monster(1234); // 이전에 키값이 없었으면 키값을 새로 생성해서 넣어줌
//            dic[1] = new Monster(2); // 이전에 키값이 있었으면 해당 키의 벨류를 교체

//            Monster monster1 = dic[1];
//            // Monster monster2 = dic[2]; // 해당하는 키가 없으면 에러 발생
//class Monster
//{
//    void Test()
//    {

//        bool success = dic.TryGetValue(1, out Monster monster2);
//        monster2.Test();
//    }
//}
//            bool success2 = dic.Remove(1);
//            // 키값을 넣어주면 해당하는 엘리먼트를 삭제한다
//            // 그리고 삭제에 성공하면 true, 벨류값을 반환
//            // 삭제에 실패하면 false 반환

//            dic.Clear(); // 전체 삭제시

//            // 딕셔너리는 두가지 행동을 함
//            // 첫번째 : Key 값을 해시(Hash)화 해서 인덱스로 변환하고 그걸 저장 (여러가지 일)
//            // 두번째 : 변환된 해시값을 큰하나의 통에 통쨰로 넣는게 아니라 잘게 쪼갠 통에 넣어줌
//        }
//    }
//}