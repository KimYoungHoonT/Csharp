// Q1. 출력 결과는?
Console.Write("두부 {0}개 사오기", 1, 2);
Console.WriteLine();
Console.WriteLine("두부 {1}개 ~ {0}개 사오기", 1, 2);

// Q2. 2진수 100을 a 변수에, 16진수 100을 b 에 넣어주세요
int a = ????;   // 2진수 리터럴
int b = ????;          // 16진수 리터럴

// Q3. 줄바꿈과 관련된 출력 결과는?
Console.Write("C# 너무쉽다\n즐겁다\n행복하다");


// Q4. 문자열 보간(String interpolation)의 결과는?
string item = "마늘";
int count = 3;
Console.WriteLine($"두부 2개, {item} {count}통");

// Q5. 명시적 형변환(overflow) 결과로 올바른것은?
int high = 222222222;
short low = (short)high;
// A. 에러가 발생한다. B. low 에 2222 까지 4자리만 저장된다. C. 오버플로우가 발생하여 이상한 값이 저장된다

// Q6. 아래 코드처럼 형변환 되는것을 무슨 형변환이라 하는지?
short low2 = 1;
int high2 = low2;

// Q7. float 과 double 의 정밀도 는?
// float = ??자리
// double = ?? ~ ??자리

// Q8. string → int 파싱 결과는?
string name = "4";
int p = int.Parse(name);
Console.WriteLine(p + 1);

// Q9. 아래 출력 결과는?
int hp = 100;
int monsterAttack = 99;
hp -= monsterAttack;
Console.WriteLine(hp);

// Q10. 전위/후위 증감연산 하여 출력결과 예측 하시오
int mp = 100;
Console.WriteLine(++mp); 
Console.WriteLine(mp++);  
Console.WriteLine(mp);

// Q11. 아래 if-else 문을 switch 문으로 바꾸시오
// 번호는 무조건 1, 2, 3 중 하나만 입력된다고 가정
string input = "2"; // 가정값
if (input == "1")
{
    Console.WriteLine("전사를 선택하셨습니다.");
}
else if (input == "2")
{
    Console.WriteLine("법사를 선택하셨습니다.");
}
else if (input == "3")
{
    Console.WriteLine("도둑을 선택하셨습니다.");
}

// Q12. 출력결과가 짝? 홀? (주의 : 코드를 잘 읽어보시오)
int number = 29;
string numberType = number % 2 != 0 ? "짝" : "홀";
Console.WriteLine(numberType);

// Q13. while문을 사용해 아래처럼 Hello World 5번 출력하기
// Hello World
// Hello World
// Hello World
// Hello World
// Hello World

// Q14. for문을 이용해 아래처럼 1부터 5까지 출력하기
// 1
// 2
// 3
// 4
// 5

// Q.15 ref 키워드를 사용하여 두변수의 값을 바꾸는 함수 만들기
static void Swap(/*이부분을 완성해주세요*/)
{
    /*이부분을 완성해주세요*/
}

int a = 1;
int b = 2;
Swap(/*이부분을 완성해주세요*/);

// Q17. out을 사용하여 다중 반환 값 받는 함수 만들기
static void OpenSRankBox(/*이부분을 완성해주세요*/)
{
    gold = 100;
    exp = 50;
    item = "포션";
}

int myGold;
int myExp;
string myItem;
OpenSRankBox(/*이부분을 완성해주세요*/);

// Q18. 아래 함수를 오버로딩 해서 매개변수 하나를 받아 + 5를 해서 리턴하는 함수를 만들어라
static int Add(int a, int b)
{
    return a + b;
}

// Q19. 선택적 매개변수 + 이름있는 인자: 출력 결과는?
static int Add(int a, int b, int c = 0, int d = 0, int e = 0)
{
    Console.WriteLine(a);
    Console.WriteLine(b);
    Console.WriteLine(c);
    Console.WriteLine(d);
    Console.WriteLine(e);
    return 0;
}

int a19 = 1;
int b19 = 2;
int c19 = 3;

// e: c19, c: 2 순서로 전달됨(이름있는 인자 우선)
Add(a19, b19, e: c19, c: 2);

// Q20. 구간 합 함수: 아래 코드의 출력 결과는?
static int SumBetween(int a, int b)
{
    int sum = 0;
    for (int i = a; i <= b; i++)
    {
        sum += i;
    }
    return sum;
}

int result20 = SumBetween(1, 6);
Console.WriteLine($"결과: {result20}");

// Q21. enum의 실제 정수값: 아래 출력 결과는?
// (기본형은 int, 지정 안된 값은 이전 값 + 1)
enum ClassType
{
    None = 8,
    Knight,    // 9
    Mage = 5,
    Rogue      // 6
}

Console.WriteLine((int)ClassType.None);
Console.WriteLine((int)ClassType.Knight);
Console.WriteLine((int)ClassType.Mage);
Console.WriteLine((int)ClassType.Rogue);

// Q22. 아래 Todo 를 완성해 주세요. 
// Todo : Player 라는 구조체를 만들고 그안에 int hp, int atk 변수를 퍼블릭으로 선언해주세요.
static void CreatePlayer(ClassType choice, out Player player)
{
    switch (choice)
    {
        case ClassType.Knight:
            {
                player.hp = 100;
                player.atk = 10;
                break;
            }
        case ClassType.Mage:
            {
                player.hp = 50;
                player.atk = 15;
                break;
            }
        case ClassType.Rogue:
            {
                player.hp = 75;
                player.atk = 12;
                break;
            }
        default:
            {
                player.hp = 0;
                player.atk = 0;
                break;
            }
    }
}

// Q23. 값 형식 전달 — 출력 결과는?
void AddTen(int x)
{
    x += 10;
}

int a23 = 5;
AddTen(a23);
Console.WriteLine(a23);

// Q24. 참조 형식 전달 — 출력 결과는?
class Player
{
    public int hp;
    public int str;
}

void Heal(Player p)
{
    p.hp += 10;
}

Player p24 = new Player(); // hp는 기본값 0
Heal(p24);
Console.WriteLine(p24.hp);

// Q25. 구조체 — 출력 결과는?
struct Point
{
    public int x;
    public int y;
}

Point pa = new Point { x = 1, y = 2 };
Point pb = pa;   
pb.x = 99;

Console.WriteLine($"{pa.x} {pa.y}");
Console.WriteLine($"{pb.x} {pb.y}");


// Q26. Knight 클래스 생성자 체이닝(public Knight(int hp) : this() <= 요거) 구현
// [요구사항]
// 1) Knight 클래스에 hp, atk 필드를 선언하세요.
// 2) 기본 생성자에서 "기본 생성자 호출"을 출력하고, hp=50, atk=5로 초기화하세요.
// 3) hp만 받는 생성자에서 this()를 호출하고, 자신의 구현부에는 hp를 전달받은 값으로 변경하세요.
// 4) hp, atk를 모두 받는 생성자에서 this(hp)를 호출하고 자신의 구현부에는 atk을 전달받은 값으로 변경하세요.
// 5) Main()에서 (200, 10)으로 생성자를 호출하고 hp, atk 출력하세요.
//
// [예시 실행 결과]
// 기본 생성자 호출
// HP: 200, ATK: 10

// Q27. Wizard 클래스 + 마법 시전 기능 구현
// [요구사항]
// 1) mp(int), intelligence(int) 필드를 가진 Wizard 클래스를 만드세요.
// 2) 기본 생성자에서 mp=100, intelligence=30으로 초기화하세요.
// 3) MagicType enum을 정의하고 Fireball=1, Icebolt=2, Heal=3 값을 주세요,
// 4) CastSpell(MagicType magic) 메서드를 구현하세요.
//    -각 마법의 소모 마나는 Fireball = 20, Icebolt = 15, Heal = 10입니다.
//    - 마나가 충분하면 차감하고 "{마법이름} 시전! 마나가 {소모량} 줄어듭니다." 출력
//    - 부족하면 "{마법이름} 시전 실패! 마나가 부족합니다." 출력
// 5) Main()에서 Fireball, Heal 순으로 시전 후 남은 마나를 출력하세요.
//
// [예시 실행 결과]
// Fireball 시전! 마나가 20 줄어듭니다.
// Heal 시전! 마나가 10 줄어듭니다.
// 남은 마나: 70

// Q28. Archer 클래스 생성자 오버로딩 구현
// [요구사항]
// 1) hp(int), dexterity(int) 필드를 가진 Archer 클래스를 만드세요.
// 2) 기본 생성자에서 hp=70, dexterity=30으로 초기화하세요.
// 3) 매개변수 생성자에서 전달받은 hp, dex로 초기화하세요.
// 4) Main()에서 기본 생성자와 매개변수 생성자를 각각 호출하고 값을 출력하세요.
//
// [예시 실행 결과]
// 기본 궁수: HP 70, DEX 30
// 커스텀 궁수: HP 90, DEX 45

// Q38. [구현] is / as / 캐스팅 안전 처리
// [요구사항]
// 1) Player, Knight : Player, Mage : Player 정의 (빈 본문 OK).
// 2) class Program(Main 함수가 있는 클래스) 에 static void EnterGame(Player p):
//    - p가 Mage면 as로 안전 캐스팅 후 mp(필드) = 10 설정, "Mage 입장" 출력.
//    - 아니면 "Mage 아님" 출력.
// 3) Main()에서 아래와 같이 함수에 객체 전달하여 출력하는 코드 작성
//    - EnterGame(new Knight());
//    - EnterGame(new Mage());

// Q39. [판단] is/as 개념 퀴즈 (주어진 진술의 O/X)
// ===== 문제 =====
// 1) is 연산자는 형변환을 시도하고, 실패하면 null을 반환한다. (O / X)
// 2) as 연산자는 타입이 맞는지 확인하여 true 또는 false를 반환한다. (O / X)
// 3) as 연산자는 값타입의 형식만 사용 가능하다 (O / X)

// Q40. 아래 의 결과는?
class A
{
    public void Act()
    {
        Console.WriteLine("A.Act");
    }
}

class B : A
{
    public void Act(int x) // 오버로드(시그니처 다름), 오버라이드 아님
    {
        Console.WriteLine($"B.Act({x})");
    }
}

class Program40
{
    static void Main()
    {
        A obj = new B();
        obj.Act();  // <= 출력결과를 적어주세요
        // obj.Act(10); // <= 이 줄 주석 해제 시 컴파일? (가능/불가)
    }
}

// Q41. 문제있는 코드 고치기
// 에러가 발생하는 부분이 한줄 있습니다. 해당줄을 수정하라면? 답안 한줄 작성
class A
{
    public A(string name)
    {
        Console.WriteLine($"A:{name}");
    }
}

class B : A
{
    public B()
    {
        Console.WriteLine("B");
    }
}

class Program41
{
    static void Main()
    {
        // A41 a = new B41(); // 컴파일 가능?
    }
}

// Q42. 함수 재선언 충돌 문제
class A
{
    public void Go()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public void Go()
    {
        Console.WriteLine("B");
    }
}

class Program
{
    static void Main()
    {
        A a = new B();
        a.Go();
    }
}
// 메인함수의 a.Go 함수가 "B" 룰 출력하기 위해선 어떻게 수정해야 하는가?

// Q46. [판단+수정] protected 접근 가시성
// [문제]
// 아래 코드에서 (L1) 에러 있음 없음?
// (L2) 의 Todo 부분에 외부에서 hp를 읽을 수 있도록 함수 작성
// "안전한" 방법(퍼블릭 함수 == Getter 메서드)을 추가 하세요.
class Player
{
    protected int hp = 100;

    // (L2)Todo : 안전한 외부 공개 함수 작성
}

class Knight : Player   
{
    public void HitMe(int dmg)
    {
        hp -= dmg;   // (L1) ← 여기 접근 가능?
    }
}

class Program
{
    static void Main()
    {
        Knight k = new Knight();
        k.HitMe(30);
        Console.WriteLine(/*L2 에서 만든 함수 호출 하여 hp 출력되게 하기*/);
    }
}

// Q47. 다형성 — TODO 버전
// 요구사항:
// 1) Player 클래스를 만들고 Attack() 함수를 "가상 메서드"로 선언하고,
//    기본 구현에서 Console.WriteLine("Player.Attack"); 을 출력하세요.
// 2) Knight 클래스 와 Mage 클래스를 Player 를 상속받게 만들고 Knight.Attack, Mage.Attack를 "오버라이드"하여
//    각각 Console.WriteLine("Knight.Attack");, Console.WriteLine("Mage.Attack"); 을 출력하세요.
// 3) Main에서는 부모 타입(Player) 변수로 자식 인스턴스를 Knight 1개 Mage 1개 생성하여 담아주고
//    각각 Attack 함수를 호출해 주세요.

// 예상 출력:
// Knight.Attack
// Mage.Attack

// Q48. static과 인스턴스 식별자
// 1) Player 클래스를 만들고, Knight 클래스를 Player에서 상속받으세요.
// 2) Knight에 멤버변수 id 를 선언해주세요.
// 3) Knight가 생성될 때마다 그 생성 번호가 id에 부여되도록 하세요.
// 4) Main에서 Knight를 3번 생성하고 각 id를 출력하세요.
// 5) 예상 출력
//    1
//    2
//    3