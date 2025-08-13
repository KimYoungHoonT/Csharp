// 접근지정자(접근제한자)
// public, protected, private

// public - 가장 개방적인 형태
// private - 가장 비개방적인(안전한) 형태
// protected - 상속받은 애들만 가능

// 은닉성 개념의 캡술화
// 기능 + 데이터를 묶는 개념의 캡슐화 -> 중요하지 않다
// 목적: 관련된 데이터와 그 데이터를 다루는 메서드를 한 클래스 안에 묶어서 하나의 “기능 단위”로 만들기

// 캡슐화 (은닉성)
// 보안레벨 == 은닉성

// 자동차
//  ㄴ> 핸들조작, 페달 조작, 차문 조작
//    ㄴ> 전기장치, 엔진, 연료분사장치 

// 프라이빗, 프로텍티드, 퍼블릭 상관없이 메모리에는 등재됨

// Knight 객체 생성시 메모리구조
// [Player] 
// { int hp }
// [Knight]
// { }

// 이런식으로 메모리에는 로드 되나 실제 클래스 내부로직에서 hp를 호출하지 못하는것뿐
// 그래서 public int Get() {return hp;} 이런식으로 열려진 함수가 있다면
// [Player]  메모리에서 가져와서 그 값을 알려줌

//class Player
//{
//    private int a;

//    public void TakeDamage(int amount)
//    {
//        hp -= amount;
//        if (hp < 0) hp = 0;
//    }

//    public void Heal(int amount)
//    {
//        hp += amount;
//        if (hp > 100) hp = 100;
//    }

//    public int GetHp() => hp;
//}

//class Knight : Player
//{

//    private int hp = 100;
//    public static int count = 0;
//    public int id;

//    public Knight()
//    {
//        hp = 10;
//        id = count++;
//    }

//    public void SecretFunction()
//    {
//        // 굉장히 중요한 기능
//        // 타이밍이 중요
//    }
//}

//class SuperKnight  : Knight
//{
//    public SuperKnight()
//    {
//        hp = 10;
//        id = count++;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Knight knight = new Knight();
//        knight.hp = 0;

//        Knight.count = 10;

//        knight.SecretFunction();

//        Console.Clear();


//    }
//}

//class A
//{
//    public void Act() { Console.WriteLine("A.Act"); }
//}

//class B : A
//{
//    public void Act(int x) // (L1) 시그니처 다름 → override 아님, 오버로드
//    {
//        Console.WriteLine($"B.Act({x})");
//    }

//    public void Test(int x) // (L1) 시그니처 다름 → override 아님, 오버로드
//    {
//        Console.WriteLine($"B.Act({x})");
//    }
//}
//class Player
//{
//    protected int hp = 100;
//}

//class Knight : Player
//{
//    public void HitMe(int dmg)
//    {
//        hp -= dmg;               // (L1) ← 여기 접근 가능?
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Knight k = new Knight();
//        k.HitMe(30);
//        Console.WriteLine(k.hp); // (L2) ← 여기 접근 가능?
//    }
//}

// 다형성(Polymorphism) - 여러가지 형태를 가지는 성질
// OOP 의 다형성 - 같은 이름의 메서드나 인터페이스를 통해 여러 다른 형태를 구현하는것

// 감독 (부모클래스)
//   ㄴ> 촬영지침 (가상메서드)
//       { 안녕하세요 라며 인사 하는 장면 }

// 배우 (자식클래스)
//   ㄴ> 촬영지침 (가상메서드)
//       { (밝게웃으며) 안녕하세요! ^^ }

//class Player
//{
//    public int hp;
//    public int mp;

//    public virture  void Move()
//    {
//        Console.WriteLine("플레이어 이동!");
//    }
//}

//class Knight : Player
//{
//    public override void Move()
//    {
//        Console.WriteLine("플레이어 이동!");
//    }
//}

//class SuperKnight : Knight
//{

//}

//// 오버로딩 : 함수 이름 재사용
//// 오버라이딩 : 부모 메서드 재정의

//class Mage : Player
//{
//    pr override void Move()
//    {
//        Console.WriteLine("날라서 이동!");
//    }
//}

//class Program
//{
//    static void Test (Player p)
//    {
//        p.Move();
//    }

//    static void Main()
//    {
//        Player super = new SuperKnight(); 
//        super.Move();
//        //Knight knight = new Knight();
//        //Mage mage = new Mage();

//        //knight.Move();
//        //mage.Move();

//    }
//}

//[스택]
//[힙]
//player ────────────────▶  ┌───────-----┐
// (Player 타입 참조변수)                    │ Knight 객체(실체) │
//                                           │--------------     │
//                                           │  Player.Move()    │  ← A에서 상속받은 메서드
//                                           │  Knight.Move()    │  ← B에서 새로 정의한 메서드
//                                           └──────-----─┘

//class Player
//{
//    public virtual void Move()
//    {
//        Console.WriteLine("Player.Move");
//    }
//}

//class Knight : Player
//{
//    public override void Move()
//    {
//        Console.WriteLine("Knight.Move(enter)");
//        base.Move();
//        Console.WriteLine("Knight.Move(exit)");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Player p = new Knight();
//        p.Move();
//    }
//}

// 추상 : 공통된 속성과 기능을 하나로 묶고
// 상속 : 묶은 기능에대해 자식클래스들이 넘겨 받으며
// 다형 : 넘겨받은 기능을 재정의하여 성질을 다분화 하고
// 캡슐 : 자식 또는 외부에 숨겨야할 내용들에 대해 보호수준을 설정한다

//class Program
//{

//    static void Main()
//    {
//        string name = "Hong gilDong";

//        // 1. 조회 / 찾기
//        bool found = name.Contains("s");
//        int index = name.IndexOf("z");


//        // 2. 변형
//        string nameLower = name.ToLower(); // 모두 소문자로 바꾸기
//        string nameUpper = name.ToUpper(); // 모두 대문자로 바꾸기  

//        string nameRe = name.Replace('g', 'l'); // 글자를 다른 글자로 치환

//        name = name + "Power";


//        // 3. 분할
//        string[] strings = name.Split(new char[] { ' ' });
//        string nameSub = name.Substring(1, 9);

//    }
//}


// 문자열 문제!
// 메인함수 호출부를 보고 CheckId 함수를 만들어주세요!

// 입력으로 새 아이디(newId)와 기존 아이디(oldId)가 주어진다.
// 두 아이디를 대소문자 구분 없이 비교해서 같으면 "중복" 출력, 다르면 "사용 가능" 출력

// 조건
// 공백은 무조건 문자열 안에 0개 또는 1개만 들어온다고 가정
// 사용할 수 있는 문자열 함수: Contains, IndexOf, ToLower, ToUpper, Replace

// 메인함수 호출
// Console.WriteLine(CheckId("Hong GilDong", "hong gildong"));
// Console.WriteLine(CheckId("Kim", "lee"));

// 출력예시
// 중복
// 사용 가능

// 화살표 함수 - 이름 있는 메서드 짧게쓰기
using System.Diagnostics;

public class Player
{
    private int hp = 100;

    // 일반 메서드
    public int GetHp()
    {
        return hp;
    }

    // 화살표 표기 메서드 (짧은 버전) 람다식
    //public int GetHpArrow() 
    //{ 
    //    return hp; 
    //}

    public void Test() => Console.WriteLine("");

    public int GetHpArrow() => hp;

    // 프로퍼티에도 가능
    public string Status => hp > 0 ? "Alive" : "Dead";
}


public class UIManager
{
    public Button startButton;

    void Start()
    {
        // 람다식: 매개변수 없음, 한 줄 실행
        startButton.onClick.AddListener(() => Debug.Log("게임 시작!"));

        // 람다식: 매개변수 있음
        System.Action<string> showMsg = msg => Debug.Log("메시지: " + msg);
        showMsg("Hello Unity");
    }
}

// 화살표 함수 => 이미만들어져있는 이름 있는 함수를 간편하게 사용할떄
// 람다 함수 => 이름 없이 함수를 만들어 쓰고싶을때 
