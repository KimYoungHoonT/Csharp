//////// 입력은 무조건 1, 2, 3중에 하나만 하는것으로 가정
//////// if-else 사용해서 만들기

//////// 직업을 고르세요.
//////// 1. 전사, 2. 법사, 3. 도둑

////////===============================
////////     [직업을 선택하세요]
////////===============================
//////// 1. 전사, 2. 법사, 3. 도둑
////////===============================
////////번호를 입력하세요 : 2
////////법사를 선택하셨습니다.

//////Console.WriteLine("===============================");
//////Console.WriteLine("     [직업을 선택하세요]");
//////Console.WriteLine("===============================");
//////Console.WriteLine("1. 전사, 2. 법사, 3. 도둑, 4. 마법소녀");
//////Console.WriteLine("===============================");
//////Console.Write("번호를 입력하세요 : ");
//////string input = Console.ReadLine();

////if (input == "1")
////{
////    Console.WriteLine("전사를 선택하셨습니다.");
////}
////else if (input == "2")
////{
////    Console.WriteLine("법사를 선택하셨습니다.");
////}
////else if (input == "3")
////{
////    Console.WriteLine("도둑을 선택하셨습니다.");
////}
////else
////{
////    Console.WriteLine("마법소녀을 선택하셨습니다.");
////}

//////// 삼항연산자
//////// 축소판 if문 보급형 if문
//////int number = 29;
//////string numberType;

////if ((number % 2) == 0)
////    numberType = "짝";
////else
////    numberType = "홀";

////                                참    거짓
////numberType = number % 2 == 0 ? "짝" : "홀";

/////*
////using System;

////namespace CSharp
////{
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            Console.WriteLine("========================================");
////            Console.WriteLine("가위 바위 보 게임 (1:가위, 2:바위, 3:보)");
////            Console.WriteLine("========================================");

////            // 컴퓨터 선택
////            Random rand = new Random();
////            int comChoice = rand.Next(1, 4);

////            // 컴퓨터의 선택 출력
////            int input = int.Parse(Console.ReadLine());


////            int, string, enum
////            switch (comChoice) 
////            {
////                case 1:
////                    Console.WriteLine("컴퓨터는 가위를 냈습니다.");
////                    break;
////                case 2:
////                    Console.WriteLine("컴퓨터는 바위를 냈습니다.");
////                    break;
////                case 3:
////                    Console.WriteLine("컴퓨터는 보를 냈습니다.");
////                    break;
////                default:  //<- else
////                    Console.WriteLine("컴퓨터는 보를 냈습니다.");
////                    break;
////            }

////            // 결과 판단
////            if (input == 1)
////            {
////                if (comChoice == 1)
////                    Console.WriteLine("비겼습니다!");
////                else if (comChoice == 2)
////                    Console.WriteLine("컴퓨터가 이겼습니다!");
////                else if (comChoice == 3)
////                    Console.WriteLine("당신이 이겼습니다!");
////            }
////            else if (input == 2)
////            {
////                if (comChoice == 1)
////                    Console.WriteLine("당신이 이겼습니다!");
////                else if (comChoice == 2)
////                    Console.WriteLine("비겼습니다!");
////                else if (comChoice == 3)
////                    Console.WriteLine("컴퓨터가 이겼습니다!");
////            }
////            else if (input == 3)
////            {
////                if (comChoice == 1)
////                    Console.WriteLine("컴퓨터가 이겼습니다!");
////                else if (comChoice == 2)
////                    Console.WriteLine("당신이 이겼습니다!");
////                else if (comChoice == 3)
////                    Console.WriteLine("비겼습니다!");
////            }
////            else
////            {
////                Console.WriteLine("잘못된 입력입니다. 1~3 중 하나만 입력해주세요.");
////            }
////        }
////    }
////}



////int count = 5;

////while (true)
////{
////    Console.WriteLine("Hello World");
////    count -= 1;
////    
///     // break;
///     continu;
///     Console.WriteLine("Hello World");
////}

////do
////{
////    Console.WriteLine("Hello World");
////} while (false);

//// 스코프는 범위를 찝어 주는거다.
////int a = 10;

//// int a = 0;
////{
////   int b = 10;
///     a += b;
////}
/// 
/// {
///     int b = 10;
/// }
////a = 10;

////int i = 0;
////while (i < 10)
////{

////    i++;
////}

/////*
////    for (int i = 0; true ; ++i)
////    {
////        반복할 코드
////    } 
////*/


////for (int j = 5; true ; j--) // 조건이 비워져있으면 true
////{
////    Console.WriteLine("Hello world");
////}

////// 조건변경에서 후위연산하나 전위연산 하나 아무런 차이 없음

////// 1. 초기화
////// 2. 조건
////// 3. 명령 코드 실행
////// 4. 조건변경
////// 5. 조건
////// 3. 명령 코드 실행
////// 4. 조건변경
////// 5. 조건

//// 함수가 실행전엔 메모리에 잡히지 않음
//// 함수가 실행되면 스택메모리 메모리가 잡힙
//// 스택 메모리 99  + 1 함수가 끝나면 사라진다

//int Test(int a, int b)
//{
        
//}

// Test(10, 10);

/////*
//// [Stack 메모리]
////┌─────────────┐
////│ Test() 프레임 │ ← Test 함수 안에서 만든 a, b 복사본
////├─────────────┤
////│ Main() 프레임│ ← Main 함수의 a (원본)
////└─────────────┘

////   함수가 실행될때 스택 메모리에 메모리 등재
////   함수 종료 되면 메모리에서 해제

//// */


////// 메모리구조
//// 코드영역
//// 데이터 영역
//// 힙 !!!!!!!!!!!!  // 배열 // 클래스 객체 = new A();
//// 스택 <- 함수 int float enum !!!!!! A a = new A()주소
//// 스택 0120323 값 참조형식 0xF1001FDDf null 주소없음

////// 말이 어려워서 잘 안외우니까 꼭 외워라
////// 값 전달 - 값을 복사해서 전달한다   

/////*
//// // 이 함수는 a 와 b의 값을 서로 뒤바꾸는 함수


////        // ref 써서 만들어 보세요.
////        static void Swap(ref int x , out int y)
////        {
////            int temp = x = 99;
////            x = y;
////            y = temp;
////        }

////        // ref 로 변수 전달하려면 초기화 되어 있어야 함!!!!
////        static void Main(string[] args)
////        {
////            int x = 99;
////            int y = 1;

////            Swap(ref x, out y);
///
////            Console.WriteLine(x); // 1
////            Console.WriteLine(y); // 99
////        }
//// */

////// ==== 값전달! = 값 복사     ===   짝퉁 가짜   값
////// ==== 참조전달! = 주소 공유 ===    진퉁 진짜 바구니 자체

////// 변수 만들면 RAM에 올라간다.
////// RAM 각각의 주소가 있다고했습니다.

////// ref! -> 주소공유 실제 변수를 전달 해준다

//////class Program
//////{

//////                             [ref] [out] [일반매개변수(값형식)]
////// 주소공유 방식?               [ O ] [ O ] [ 값 전달(복사)]
////// 함수 안에서 읽기 가능?        [ O ] [ X ] [ O ]
////// 함수 호출전 반드시 초기화?    [ O ] [ X ] [ O ]
////// 함수 내에서 반드시 값쓰기?    [ x ] [ O ] [ x ]

//////    //out - 보통 다중 반환할떄 사용한다.
//////    static void OpenSRankBox(out int gold, out int exp, out string item, ref int a, int b)
//////    {
//////        int temp = a; // 안전성의 법칙 읽어올순 있으나 함수로 넘어오기전에 초기화 
//////        temp = gold; // 안정성의 규칙 out 은 못읽어옴
//////        gold = 100;
//////        exp = 50;
//////        item = "포션";
//////    }

//////    static void Main(string[] args)
//////    {
//////        int myGold;
//////        int myExp;
//////        string myItem;
//////        int a = 100;
//////        int b;

//////        OpenSRankBox(out myGold, out myExp, out myItem, ref a, b);

//////        Console.WriteLine($"골드 획득: {myGold}");
//////        Console.WriteLine($"경험치 획득: {myExp}");
//////        Console.WriteLine($"아이템 획득: {myItem}");
//////    }
//////}