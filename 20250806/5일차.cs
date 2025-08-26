////using CSharp;
////using System.Drawing;

////namespace CSharp
////{
////    // 절차 지향 - 원래는 뭔가 우리가 알고 있는 절차의 의미가 아님
////    // (ex : 1단계 → 2단계 → 3단계처럼 차례로 진행되는 방식)

////    // 절차 지향(Procedural Programming) 
////    //            Procedure 프로시저       - 함수 중심으로 프로그램을 구조화해서 문제를 해결하는 방식입니다.

////    // 프로그램이 커지거나, 분할되거나 이떄부터 무리가 생김
////    // 캐릭터 -> 스테이지 -> 몬스터 싸울지 말지

////    // 절차지향의 가장큰 문제점은 순서
////    // 함수 호출순서로 문제를 해결

////    //static void Main()
////    //{
////    //    LoadData(); // <- 데이터 로딩
////    //    ShowUI();   // <- 로딩된 데이터 기반 유아이 표출
////    //    WaitForPlayerInput();
////    //}

////    // 객체지향(Object-Oriented Programming, OOP)
////    // 캐릭터, 몬스터, 아이템, 보이는거 
////    // 스킬, 사운드, 인풋 안보이는거 까지
////    // 전부다 하나의 객체로 각각 만드는거에요

////    // 자동차를 수리한다.
////    // 자동차
////    //  ㄴ> 엔진, 베터리, 타이어

////    // 절차지향은 '함수 중심으로 흐름을 만들고 조립하는 방식'이라면,
////    // 객체지향은 '객체에게 역할을 부여하고, 객체 간 협력을 통해 문제를 해결하는 방식' 입니다.

////    // 설계도 == 설정집
////    // 오크 : 힘이 세다, 인간을 증오한다.

////    // 주인공이 오크를 만났다. 오크가 울부짖었다.
////    // 객체를 생성했다.

////    class Player // 클래스는 일종의 설계도
////    {
////        // 필드 : 멤버 변수 
////        public int hp;
////        public int str;
////        public int atk;
////        public int def;

////        // 기능, 메소드 : 멤버 함수
////        void Attack()
////        {

////        }
////    }

////    class Program
////    {
////        static void Main(string[] args)
////        {
////            Player player/*이 변수는 힙에 생성된 객체의 주소를 담음*/ = new Player(); //  인스턴스화 = 객체생성 = 힙에 생성
////            Console.WriteLine(player.hp);
////            Console.WriteLine(player.str);

////            // 값 형식 = 10, "aaa"
////            // 스택메모리 저장됨
////            // 값이 복사가 되는것들
////            // int, float, struct, enum, bool
////            // ^ 기본 매개변수로 전달 하면 : 값 전달 

////            // 참조 형식 = 
////            // 스택엔 주소만 저장됨
////            // 힙에 실제 값이 저장됨
////            // 주소만 복사가 되는것들
////            // class , 배열, List
////            // ^ 기본 매개변수로 전달 하면 : 참조 전달

////            void AddTen(int x)
////            {
////                x += 10;
////            }

////            int a = 5;
////            AddTen(a);
////            Console.WriteLine(a);
////            // ^ 위에 있는건 값 전달 (값 전달)
////            // 1. 인트 a 라는 변수 만들어서 5라는 값 대입
////            // 2. AddTen 함수 호출하며 a에 있는 "값 : 5" 를 !!!복사해서!!! 전달
////            // 3. AddTen 함수는 !!!복사한 값 5!!!! 를 x 라고 호칭함
////            // 4. x 라고 칭하는 5값에 10을 더함
////            // 5. 15라는 값이 완성되지만 함수가 종료되며 !!!복사한 값!!! 은 사라짐
////            // 6. 1. 에 있는 인트 a는 아무도 건들지 않았으니 그냥 5값 그대로 출력됨

////            void Test(Player player)
////            {
////                player.hp += 10;
////            }

////            Player p = new Player();
////            Test(p);
////            Console.WriteLine(p.hp);


////            void AddTen2(ref int x2)
////            {
////                x2 += 10;
////            }

////            int a2 = 5;
////            AddTen2(ref a2);
////            Console.WriteLine(a2);
////            // ^ 위에 있는건 참조 전달 (주소 공유)
////            // 1. 인트 a 라는 변수 만들어서 5라는 값 대입
////            // 2. AddTen2 함수 호출하며 !!!!!a 변수 그자체를!!!!!! 전달
////            // 3. AddTen2 함수는 !!!변수 a 그자체!!!! 를 x 라고 호칭함
////            // 4. x 라고 칭하는 a에 10을 더함
////            // 5. a 의 5와 10 이라는 값이 더해져서 15 완성,
////            // 6. !!!!!!a 에 15의 값을 대입!!!!!
////            // 6. 1. 에 있는 인트 a를 AddTen2 이 건드렸으니 15 값이 출력됨


////            // | 구분           | 뜻                                   | 예시 비유                                      |
////            // | ---------      | ------------------------------------ | ---------------------------------------------  |
////            // | 값 전달 * *  | 값을 "복사해서" 줌 → 원본은 안 바뀜 | “사본을 줌” (복사한 종이 한 장 줌)           |
////            // | 참조 전달**  | 주소(참조)를 줌 → 원본도 같이 바뀜  | “원본을 줌” (원본 문서를 줘서 거기다 낙서함) |


////        }
////    }
////}

////// 구조체
////struct Point
////{
////    public int x;
////    public int y;
////}
////// 구조체는 값형식 의 데이터
////// 값 형식: 메모리에 값 자체를 저장하고, 전달 시 값이 복사됨
////// 스택메모리에 올라감

////// 함수에 넘길때 값 전달 -> 함수 호출 시 해당 값을 복사해서 넘기는 방식

//////-------스택메모리-------------
//////[  ][  ][ x ][ y ][  ][  ]
//////[  ][  ][4 B][4 B][  ][  ]

//////int a = 10;
//////int b = a;
//////[  ][  ][a][][  ][b]
//////b = 20;

//////Console.WriteLine(a); // 10
//////Console.WriteLine(b); // 20

////// 클래스
////// 참조형식 : 메모리에 주소를 저장하고, 전달 시 주소가 복사됨
////// 스택메모리에 힙에 올라간 값의 주소를 저장, 힙에는 실제 데이터 값을 저장

//////namespace CSharp
//////{
//////    class Point
//////    {
//////        public int x;
//////        public int y;
//////    }

//////    class Program
//////    {


//////        static void Main(string[] args)
//////        {
//////            Point p1 = new Point();
//////            p1.x = 1;
//////            p1.y = 2;

//////            Point p2 = p1;
//////            p2 = p1;
//////            p2.x = 5;
//////            p2.y = 6;



//////            Console.WriteLine($"{p1.x} {p1.y}\n{p2.x} {p2.y}");
//////        }
//////    }
//////}

//////[Stack]                   [Heap]
//////---------- - -------------
//////| p1 | ——+———>          | point 객체 |
//////| p2 | —/               | x: 5 |
//////                        | y: 6 |

//////!!!! 문제 !!!!
//////namespace CSharp
//////{
//////    struct Mage
//////    {
//////        public int hp;
//////        public int atk;
//////    }

//////    class Knight
//////    {
//////        public int hp;
//////        public int atk;
//////    }

//////    class Program
//////    {
//////        static void KillMage(ref Mage mage)
//////        {
//////            mage.hp = 0;
//////        }

//////        static void KillKnight(Knight knight)
//////        {
//////            knight.hp = 0;
//////        }

//////        static void Main(string[] args)
//////        {
//////            Mage mage = new Mage();
//////            mage.hp = 100;
//////            mage.atk = 50;
//////            KillMage(ref mage);

//////            Knight knight = new Knight();
//////            knight.hp = 100;
//////            knight.atk = 50;
//////            KillKnight(knight);

//////            Console.WriteLine($"Mage HP {mage.hp}\nKnight HP {knight.hp}");
//////        }
//////    }
//////}

////// 얕은 복사 (Shallow Copy)
////// 주소 복사 
//////static void Main(string[] args)
//////{
//////    Knight k1 = new Knight();
//////    k1.hp = 100;

//////    Knight k2 = k1;  // ← 얕은 복사
//////    k2.hp = 50;

//////    Console.WriteLine(k1.hp); // 출력: 50
//////}
//////[Stack][Heap]
//////------------------------
//////| k1 | —+———————→       | Knight 객체 |
//////| k2 | —/               | hp: 50 |
//////                        | atk: 0 |


////// 깊은 복사 (Deep copy)
//////class Knight
//////{
//////    public int hp;
//////    public int atk;

//////    public Knight Clone()
//////    {
//////        Knight knight = new Knight();
//////        knight.hp = hp;
//////        knight.atk = atk;
//////        return knight;
//////    }
//////}

//////static void Main(string[] args)
//////{
//////    // 깊은 복사 1
//////    Knight k1 = new Knight();
//////    k1.hp = 100;

//////    Knight k2 = new Knight();
//////    k2.hp = k1.hp; // ← 깊은 복사

//////    k2.hp = 50;
//////    Console.WriteLine(k1.hp); // 출력: 100



//////    // 깊은 복사 2
//////    Knight k3 = new Knight();
//////    k3.hp = 100;

//////    Knight k4 = k3.Clone();// ← 깊은 복사

//////    k4.hp = 50;
//////    Console.WriteLine(k4.hp); // 출력: 50
//////}
//////[Stack][Heap]
//////------------------------
//////| k3 | ————→            | Knight 1 |
//////| k4 | ————→            | hp: 50 |
//////                        |              |
//////                        | Knight 2 |
//////                        | hp: 50 |

////// 주소가 아닌 값을 서로 다른 객체에서 값 자체를 복사하는것
