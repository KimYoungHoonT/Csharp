//#define TEST

//using System.Diagnostics;
//using System.Reflection;
//using System.Runtime.InteropServices;


//namespace Reflection
//{
//    // Reflection = 클래스용 X-ray 촬영
//    // 자주 사용하지 않음 - 그냥 개념을 알고 있으면 됨

//    // Attribute

//    // 이 클래스는 몬스터 클래스이다!

//    // 커스텀 어트리뷰트를 만든거임
//    // 관례로 이름뒤에 Attribute 라는걸 붙임 ImportantAttribute
//    class Important : Attribute
//    {
//        public string message;

//        public Important(string message)
//        {
//            this.message = message;
//        }
//    }

//    [Important("이건 중요한 메시지야, 니가 런타임에 확인해")]
//    class Monster
//    {
//        // 닷넷 환경 밖에서 개발된 코드를 가져오고 싶을때
//        [DllImport("User32.dll")]
//        public static extern int MessageBox(int h, string title, string message, int buttons);


//        // 빌드는 되지만 사용하지 말라고 뜸
//        [Obsolete]
//        public static void Test1()
//        {
//            Console.WriteLine("Test가 호출됨");
//        }

//        // 빌드는 되지만 사용하지 말라고 뜸, 그리고 추가 메시지 넣음
//        [Obsolete("이거 더이상 사용 안되니까 하지마셈")]
//        public static void Test2()
//        {
//            Console.WriteLine("Test가 호출됨");
//        }

//        // 더이상 빌드도 안되게 막아버림
//        [Obsolete("하지말랬는데 왜함?", true)]
//        public static void Test3()
//        {
//            Console.WriteLine("Test가 호출됨");
//        }

//        // 해당 문서(이문서) 최상단에 #define 으로 정의한내용이 없으면 실행안되게
//        // 즉, if문처럼 맨 위에 #define TEST 이거 없으면 이 함수 호출해도 실행 안됨
//        [Conditional("TEST")]
//        public static void Test4()
//        {
//            Console.WriteLine("Test가 호출됨");
//        }

//        public int hp;
//        protected int atk;
//        private float speed;
//    }

//class Monster
//{
//    public int hp;
//    protected int atk;
//    private float speed;
//}

//class Program
//{
//    static void Main()
//    {
//        Monster monster = new Monster();
//        Type type = monster.GetType();
//        var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
//        foreach (var field in fields)
//        {
//            string access = "protected";

//            if (field.IsPublic == true)
//                access = "public";
//            else if (field.IsPrivate == true)
//                access = "priavte";

//            Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
//        }

//        var attributes = type.GetCustomAttributes();
//        foreach (var attribute in attributes)
//        {
//            Important important = attribute as Important;
//            if (important != null)
//            {
//                Console.WriteLine(important.message);
//            }
//        }
//    }
//}
//}


//namespace Nullable
//{
//    // Nullable - null 이 able 가능한
//    // 게임쪽은 상대적으로 덜 사용함
//    // 다만 DB 같은거 하면 사용함

//    class Monster
//    {
//        public int id;

//        public Monster(int id)
//        {
//            this.id = id;
//        }

//        public Monster MatchId(int id)
//        {
//            if (this.id == id)
//                return this;

//            return null;
//        }

//        public int Search(int id)
//        {
//            return 0;
//        }

//    }

//    class Program
//    {
//        static void Main()
//        {
//            int? number = null;
//            int c = number ?? 5;

//            if (number.HasValue == true)
//            {
//                int b = number.Value;
//                Console.WriteLine(b);
//            }
//            else
//            {
//                int b = 5;
//                Console.WriteLine(b);
//            }


//        }
//    }
//}


//using System.Diagnostics;

//namespace 시간복잡도_BigO표기법
//{
//    // 시간복잡도 = 어떠한 알고리즘이 실행되는데 걸리는 시간
//    // 공간복잡도 = 메모리를 얼만큼 사용하느냐
//    // "주요 로직"의 "반복 횟수"를 중점으로 측정

//    // Big-O : 반복해서 몇번 연산되는지 "대충" 판단
//    // 1단계 : 시간복잡도 구하기
//    // 2단계 : 가장 오래걸리는 애만 남기기
//    // 3단계 : 상수항은 탈락시킨다(버린다)

//    // 업엔다운 게임이 대표적인 O(log n) 알고리즘 이다.

//    class Program
//    {

//        static void Test1(int n)
//        {
//            int sum = n;

//            // O(1)
//        }

//        static void Test2(int n)
//        {
//            int sum = 0;

//            for (int i = 0; i < n; i++)
//            {
//                sum++;
//            }
//                 
//            // O(n)
//        }


//        static void Test3(int n)
//        {
//            int sum = 0;

//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < n ; j++)
//                {
//                    sum++;
//                }
//            }

//            // 시간복잡도 = O(n^2)
//        }

//        static void Test4(int n, int m)
//        {
//            int sum = 0;

//            for (int i = 0; i < n; i++)
//            {
//                sum++;
//            }

//            for (int j = 0; j < 2 * n; j++)
//            {
//                for (int k = 0; k < 2 * n; k++)
//                {
//                    sum++;
//                }
//            }

//            sum -= 100;

//            // 시간복잡도 : O(n^2)
//        }

//        // 1~100 : 73
//        // 50 = up
//        // 75 = down
//        // 63 = 

//        // 100 → 50 → 25 → 12 → 6 → 3 → 1 
//        // O(n, m)


//        static void Main()
//        {
//            Stopwatch sw = Stopwatch.StartNew();

//            int sum = 0;

//            for (int i = 0; i < 1_000_000; i++)
//            {
//                sum += 1;
//            }

//            sw.Stop();

//            Console.WriteLine($"총 걸린시간 : {sw.Elapsed.TotalMilliseconds} ms");
//        }
//    }
//}

// 선형 자료구조 - 자료를 순차적으로 나열함
// 배열, 리스트, 연결리스트, 스택, 큐 - 차이점

// 비선형 자료구조 - 하나의 자료 뒤에 다수의 자료가 올 수 있음
// 트리, 그래프

// [1][][][][][][][][][][][][] - 선형 자료구조
// [1] - 비선형 자료구조
//  ㄴ[2]
//  ㄴ[3]
//  ㄴ[4]
//  ㄴ[5]
//  ㄴ[6]

// 게임오브젝트
//    ㄴ> 버튼
//        ㄴ> 텍스트
//    ㄴ> 버튼

// 배열 
// 배열[3] - 배열은 [인덱스를 통한 접근 속도]가 아주 빠름 O(1)
// 처음 설정한 크기가 고정되어 변경이 불가함
// 메모리상에 연속된 형태로 데이터가 저장됨
// 장점 : 데이터 연속, 정확한 크기를 알고있어서 딱 그만큼만 사용한다면 메모리 절약에 효율적
// 단점 : 추가 / 삭제 불가

// 동적배열 (List)
// 내부적으로는 배열 기반으로 동작
// 크기가 꽉 차면 새로운 배열을 만들고 기존 데이터를 복사하여 확장함
// 확장시 보통 1.5배 ~ 2배 단위로 확장 (언어/라이브러리마다 다름)
// 장점 : 크기 확장 자동 처리
// 단점 : 중간 삽입/삭제 느림 O(n)

// 연결 리스트 (Linked List)
// 각 원소(Node)가 데이터 + 다음 노드 + 이전 노드 주소(포인터)로 구성됨
// 메모리상에 연속적으로 배치될 필요 없음 (화살표로 연결)
// 장점 : 중간 삽입/삭제 빠름 O(1)
// 단점 : 특정 위치 검색이 느림

