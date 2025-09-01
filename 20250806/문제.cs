//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== If-only 연습 시작 ===");

//        // ───────────── 변수 선언 연습 ─────────────
//        // TODO M0-1) 정수형 변수 a,b를 선언하고 각각 7, 5로 초기화하세요.
//        int a;
//        int b;
//        a = 7;
//        b = 5;
//        // TODO M0-2) 문자열 변수 playerName을 선언하고 "Kim"으로 초기화하세요.
//        string playerName;
//        playerName = Kim;

//        // TODO M0-3) 불린 변수 isMember를 선언하고 false로 초기화하세요.
//        bool isMember;
//        isMember = false;

//        // TODO M0-4) 문자 변수 ch를 선언하고 'a'로 초기화하세요.
//        string ch;
//        ch = a;

//        // TODO M0-5) 정수형 변수 hp를 선언하고 42로 초기화하세요.
//        int hp;
//        hp = 42;

//        // TODO M0-6) 정수형 변수 price를 선언하고 5000으로 초기화하세요.
//        int price;
//        price = 5000;

//        // TODO M0-7) 정수형 변수 level을 선언하고 3으로 초기화하세요.
//        int level;
//        level = 3;

//        // TODO M0-8) 정수형 변수 year를 선언하고 2024로 초기화하세요.
//        int year;
//        year = 2024;

//        // TODO M0-9) 정수형 변수 score를 선언하고 86으로 초기화하세요.
//        int score;
//        score = 86;

//        // TODO M0-10) 불린 변수 flag를 선언하고 true로 초기화하세요.
//        bool flag;
//        flag = true;


//        // ───────────── 함수 구현 & 호출 연습 ─────────────
//        // (중요) 아래 항목들은 함수 “직접 선언/구현/호출” 모두 스스로 작성해야 합니다.

//        호출 개념 약한 것 확인했습니다.
//        GPT에서 개념, 예제 확인 후 진행했습니다.

//        // TODO F01) int a를 매개변수로 받고 void를 반환하는 함수 Test를 만들어,
//        //           함수 안에서 int b를 선언하고 a+b 값을 출력하세요.
//        // TODO M1) Main에서 a를 인자로 넘겨 Test를 호출하세요.
//        void Test(int a)
//        {
//            int b;
//            Console.WriteLine(a + b);

//        }

//        static void Main()
//        {
//            이 부분 잘 모르는것 같습니다.
//        }

//        // TODO F02) int AddIfPositive(int x, int y) 함수를 만들어,
//        //           x,y 모두 양수일 때만 x+y 반환, 아니면 0 반환.
//        // TODO M2) Main에서 a,b를 넘겨 결과를 출력하세요.
//        int AddIfPositive(int x, int y)
//        {
//            if (x > 0 && y > 0)
//            {
//                return x + y;
//            }
//            else
//            {
//                return 0;
//            }

//        }


//        static void Main(string[] args)
//        {
//            var a;
//            var b;
//        }
//        Main에 a, b가 선언되어 있다는 것이 짐작됩니다
//            a와 b를 어딘가로 넘겨 결과를 출력해야한다고 하니까.
//            그런데 그게 어디인지도 모르고 어떤 기능을 갖춘 메서드인지 모르겠습니다.

//        // TODO F03) void PrintSign(int n) 함수를 만들어,
//        //           n>0이면 "양수", n<0이면 "음수", n==0이면 "0" 출력.
//        // TODO M3) Main에서 -3, 0, 9로 각각 호출하세요.


//            void static Main()
//        {





//            void PrintSign(int n)
//            {
//                if (n > 0)
//                {
//                    Console.WriteLine("양수");
//                }
//                else if (n < 0)
//                {
//                    Console.WriteLine("음수");
//                }
//                else
//                {
//                    Console.WriteLine("0");
//                }
//            }


//            // TODO F04) int Clamp01(int n): 0 미만이면 0, 1 초과면 1, 그 외 그대로 반환.
//            // TODO M4) Main에서 -1,0,1,2 각각의 결과를 출력하세요.

//            // TODO F05) int Clamp(int value,int min,int max):
//            //           value를 [min,max]로 보정해 반환 (단, min>max면 min 반환).
//            // TODO M5) Main에서 value=15,min=0,max=10을 호출해 결과 출력.

//            // TODO F06) bool IsTeenager(int age): 13~19면 true, 아니면 false.
//            // TODO M6) Main에서 age=13,19,20으로 호출해 결과 출력.

//            // TODO F07) string GradeKr(int score): 90↑A, 80↑B, 70↑C, 60↑D, 그 외 F.
//            // TODO M7) Main에서 score 변수로 호출해 결과 출력.

//            // TODO F08) int Max3(int a,int b,int c): 세 값의 최댓값 반환.
//            // TODO F09) int Min3(int a,int b,int c): 세 값의 최솟값 반환.
//            // TODO M8) Main에서 (3,9,6)으로 호출해 각각 결과 출력.

//            // TODO F10) int Abs(int x): 절댓값 반환.
//            // TODO M9) Main에서 -12로 호출해 결과 출력.

//            // TODO F11) void SwapIfGreater(ref int a, ref int b): a>b면 두 값을 교환.
//            // TODO M10) Main에서 a,b를 넘겨 호출 후 결과 출력.

//            // TODO F12) void Toggle(ref bool flag): flag 토글 (true<->false).
//            // TODO M11) Main에서 flag 넘겨 호출 후 결과 출력.

//            // TODO F13) string JoinName(string first,string last): "last first" 반환.
//            // TODO M12) Main에서 ("Younghoon","Kim")으로 호출해 결과 출력.

//            // TODO F14) void SafeDivide(int a,int b): b==0이면 경고문, 아니면 몫/나머지 출력.
//            // TODO M13) Main에서 (10,0), (10,3) 두 번 호출.

//            // TODO F15) void SetLevelTitle(int level,out string title):
//            //           1~3 Beginner, 4~6 Intermediate, 7~9 Advanced, 그 외 Unknown.
//            // TODO M14) Main에서 level 변수로 호출 후 title 출력.

//            // TODO F16) bool IsLeapYear(int year):
//            //           400으로 나눠떨어지면 윤년,
//            //           100으로 나눠떨어지면 평년,
//            //           4로 나눠떨어지면 윤년,
//            //           그 외 평년.
//            // TODO M15) Main에서 year 변수로 호출 후 결과 출력.

//            // TODO F17) void ApplyDiscount(ref int price,bool isMember,bool isHoliday):
//            //           회원이면 -1000, 휴일이면 추가 -500, 총 -1500까지 가능. 0 밑으로 안내려가게.
//            // TODO M16,M17) Main에서 두 가지 경우 호출 후 price 출력.

//            // TODO F18) void NextEven(ref int n):
//            //           n이 홀수면 n+1, 짝수면 n+2.
//            // TODO M18) Main에서 n=7로 호출 후 출력.

//            // TODO F19) void SetStatus(int hp,out string status):
//            //           hp>=70 Alive, 40~69 Wounded, 1~39 Critical, hp<=0 Dead.
//            // TODO M19) Main에서 hp로 호출 후 status 출력.

//            // TODO F20) bool IsVowel(char c): 'a','e','i','o','u'면 true.
//            // TODO M20) Main에서 ch로 호출 후 결과 출력.

//            // TODO F21) int Compare(int a,int b): a<b -1, a==b 0, a>b 1.
//            // TODO M21) Main에서 (a,b) 호출 후 결과 출력.

//            // TODO F22) void NormalizeScore(ref int score):
//            //           0 미만이면 0, 100 초과면 100으로 보정.
//            // TODO M22) Main에서 score로 호출 후 결과 출력.

//            // TODO F23) string EvenOddString(int n): 짝수면 "Even", 홀수면 "Odd".
//            // TODO M23) Main에서 14,15 각각 호출 후 출력.

//            Console.WriteLine("=== If-only 연습 종료 ===");
//        }

//        // ⚠️ 위의 함수들은 제공되지 않습니다. (직접 선언하고 구현해야 합니다!)
//    }