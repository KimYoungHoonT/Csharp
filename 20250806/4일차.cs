//////static int Add(int a, int b)
//////{
//////    return a + b;
//////}

//////// A값만 받아서 +5 해서 뱉어주는 함수를 만들어야한다.
//////static int Add(int b)
//////{
//////    return a + 5;
//////}
////////[  ADD(1,2)  ADD(1)  ]
////////[  ADD(1,2) ] [ ADD(1)  ]
//////static void Main(string[] args)
//////{
//////    // 오버로딩
//////    // 오버로딩 = 다중 정의
//////    // 하나의 이름을 다중으로 정의한다.
//////    // 오버로딩 = "함수 이름 재사용"
//////    int a = 1;
//////    int b = 2;

//////    int result = Add(a, b);
//////    int result2 = Add(b);

//////    Console.WriteLine(result);
//////}

//////class Program
//////{
//////    static int Add(int a, int b, int c = 0, int d = 0, int e = 0)
//////    {
//////        Console.WriteLine(a);
//////        Console.WriteLine(b);
//////        Console.WriteLine(c);
//////        Console.WriteLine(d);
//////        Console.WriteLine(e);

//////        return 0;
//////    }

//////    static void Main(string[] args)
//////    {
//////        int a = 1;
//////        int b = 2;
//////        int c = 3;

//////        int result = Add(a, b, e: c, c: 2);
//////    }
//////}

//////using System;

//////namespace CSharp
//////{
//////    class Program
//////    {
//////        static int SumBetween(int a, int b)
//////        {
//////            int sum = 0;

//////            for (int i = a; i <= b; i++)
//////            {
//////                sum += i;
//////            }

//////            return sum;
//////        }

//////        static void Main(string[] args)
//////        {
//////            // 1 + 2 + 3 + 4 + 5 + 6 = 21
//////            int result = SumBetween(1, 6);
//////            Console.WriteLine($"결과: {result}");
//////        }
//////    }
//////}

//////namespace CSharp
//////{
//////    class Program
//////    {
//////        enum ClassType  <- 정수형식  
//////        {
//////            None = 9,
//////            Knight,
//////            Mage = 5,
//////            Rogue
//////        }

//////        struct Player
//////        {
//////            public int hp;
//////            public int atk;
///
///               void Test() {  } 
//////        }

//////        static ClassType ClassChoice()
//////        {
//////            Console.WriteLine("직업을 선택하세요!");
//////            Console.WriteLine("[1] 기사");
//////            Console.WriteLine("[2] 마법사");
//////            Console.WriteLine("[3] 도둑");

//////            ClassType choice = ClassType.None;
//////            string input = Console.ReadLine();

//////            switch (input)
//////            {
//////                case "1":
//////                    choice = ClassType.Knight;
//////                    break;
//////                case "2":
//////                    choice = ClassType.Mage;
//////                    break;
//////                case "3":
//////                    choice = ClassType.Rogue;
//////                    break;
//////            }

//////            return choice;
//////        }

//////        static void CreatePlayer(ClassType choice, out Player player)
//////        {
//////            // 기사(100/10), 마법사(50/15), 도둑(75/12)
//////            switch (choice)
//////            {
//////                case ClassType.Knight:
//////                    player.hp = 100;
//////                    player.atk = 10;
//////                    break;
//////                case ClassType.Mage:
//////                    player.hp = 50;
//////                    player.atk = 15;
//////                    break;
//////                case ClassType.Rogue:
//////                    player.hp = 75;
//////                    player.atk = 12;
//////                    break;
//////                default:
//////                    player.hp = 0;
//////                    player.atk = 0;
//////                    break;
//////            }
//////        }

//////        static void Main(string[] args)
//////        {
//////            ClassType choice = ClassType.None;

//////            while (true)
//////            {
//////                choice = ClassChoice();
//////                if (choice != ClassType.None)
//////                {
//////                    Player player;
//////                    ClassType classType = ClassType.None;

//////                    // hp 셋팅
//////                    CreatePlayer(choice, out player);


//////                    Console.WriteLine($"HP {player.hp}, ATK {player.atk}");
//////                }
//////            }
//////        }
//////    }
//////}


//////// struct 구조체
//////// - 변수들을 하나의 덩어리로 묶어서 뭉쳐서 사용할때 사용함
