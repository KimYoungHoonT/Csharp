////// 생성자(Constructor)
////class Knight
////{
////    public int hp;
////    public int atk;

////    // 기본생성자
////    //public Knight()
////    //{
////    //    Knight 타입의 객체를 힙에 생성
////    //    힙 메모리
////    //    [0000 0000 0000 0000 0000 0000 0000 0000][0000 0000 0000 0000 0000 0000 0000 0000]
////    //    hp = 0;
////    //    atk = 0;
////    //    return Knight 타입의 객체
////    //}

////    public Knight()
////    {
////        Console.WriteLine("응애 나 기본생성자");
////    }

////    public Knight(int hp, int atk) : this(10) // 함수 이름 재사용
////    {
////        this.hp = hp;
////        this.atk = atk;
////    }

////    public Knight(int hp) : this() // 함수 이름 재사용
////    {
////        Console.WriteLine("응애 나 커스텀 생성자");
////    }
////}
////class Program
////{
////    static void Main(string[] args)
////    {
////        // 매개변수가 있는 생성자 호출
////        Knight strongKnight = new Knight(200, 10);

////        Console.WriteLine($"강한 기사: HP {strongKnight.hp}, ATK {strongKnight.atk}");

////        /*
////         출력값 :
////         응애 나 기본생성자
////         응애 나 커스텀 생성자
////         강한 기사: HP 100, ATK 10
////         */
////    }
////}
////}

///*
// namespace CSharp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Wizard wizard = new Wizard();
//            Console.WriteLine($"마법사의 MP: {wizard.mp}, 지능: {wizard.intelligence}");

//            Archer archer = new Archer();
//            Console.WriteLine($"기본 궁수 : HP {archer.hp}, 민첩성 {archer.dexterity}");
//            archer = new Archer(90, 45);
//            Console.WriteLine($"커스텀 궁수 : HP {archer.hp}, 민첩성 {archer.dexterity}");

//            Paladin paladin = new Paladin(150, 30);
//            Console.WriteLine($"성기사 : 체력 {paladin.hp}, 공격 {paladin.atk}, 방어 {paladin.def}");

//            Wizard wizard1 = new Wizard();
//            wizard1.CastSpell(MagicType.Fireball);
//            wizard1.CastSpell(MagicType.Heal);

//            Console.WriteLine($"남은마나 : {wizard1.mp}");
//        }
//    }
//}
//class Archer
//{
//    public int hp;
//    public int dexterity;

//    public Archer()
//    {
//        hp = 70;
//        dexterity = 30;
//    }

//    public Archer(int hp, int dex)
//    {
//        this.hp = hp;
//        this.dexterity = dex;
//    }
//}

//class Paladin
//{
//    public int hp;
//    public int atk;
//    public int def;

//    public Paladin()
//    {
//        def = 5;
//        Console.WriteLine("기본 생성자 호출");
//    }

//    public Paladin(int hp, int atk) : this()
//    {
//        this.hp = hp;
//        this.atk = atk;
//        Console.WriteLine("커스텀 생성자 호출");
//    }
//}

//enum MagicType
//{
//    Fireball = 1,
//    Icebolt = 2,
//    Heal = 3
//}

//class Wizard
//{
//    public int mp;
//    public int intelligence;

//    public Wizard()
//    {
//        mp = 100;
//        intelligence = 30;
//    }

//    public void CastSpell(MagicType magicType)
//    {
//        int cost = 0;
//        string spellName = "";

//        switch (magicType)
//        {
//            case MagicType.Fireball:
//                cost = 20;
//                spellName = "Fireball";
//                break;
//            case MagicType.Icebolt:
//                cost = 15;
//                spellName = "Icebolt";
//                break;
//            case MagicType.Heal:
//                cost = 10;
//                spellName = "Heal";
//                break;
//        }

//        if (mp >= cost)
//        {
//            mp -= cost;
//            Console.WriteLine($"{spellName} 시전! 마나가 {cost} 줄어듭니다.");
//        }
//        else
//        {
//            Console.WriteLine($"{spellName} 시전 실패! 마나가 부족합니다.");
//        }
//    }
//}

//// =======================================
//// 1. Wizard 클래스를 만들어 다음 조건을 만족하세요:
//// 
//// - 멤버 변수: mp, intelligence (둘 다 int형)
//// - 기본생성자에서 각각 50, 20으로 초기화
//// - Main()에서 Wizard 객체를 생성하고 두 값을 출력
////
//// [실행 결과]
//// 마법사의 MP: 50, 지능: 20
//// =======================================
//// =======================================
//// 2. Archer 클래스를 만들어 다음 조건을 만족하세요:
////
//// - 멤버 변수: hp, dexterity
//// - 기본 생성자: hp = 70, dexterity = 30
//// - 매개변수 생성자: 외부에서 전달받은 값으로 초기화 (90, 45)
//// - Main()에서 두 가지 생성자로 객체를 생성하고 각각 출력
////
//// [실행 결과]
//// 기본 궁수: HP 70, 민첩성 30
//// 커스텀 궁수: HP 90, 민첩성 45
//// =======================================
//// =======================================
//// 4. Paladin 클래스에서 생성자 체이닝을 사용하세요:
////
//// - 멤버 변수: hp, atk, def
//// - 기본 생성자: def = 5, "기본 생성자 호출" 출력
//// - 매개변수 생성자: hp, atk를 받아서 설정 + this()로 기본 생성자 호출
////
//// [실행 결과]
//// 기본 생성자 호출
//// 커스텀 생성자 호출
//// 성기사 - HP: 150, ATK: 30, DEF: 5
//// =======================================
//// =======================================
//// 7. Wizard 클래스와 MagicType 열거형(enum)을 활용하세요:
////
//// - Wizard 클래스에는 mp(마나)와 intelligence(지능)가 있음
//// - 생성자에서 mp = 100, intelligence = 30으로 초기화
////
//// - MagicType 이라는 enum을 정의:
////   Fireball = 1 (MP 20 소모)
////   Icebolt = 2 (MP 15 소모)
////   Heal = 3 (MP 10 소모)
////
//// - CastSpell(MagicType magic) 메서드 작성:
////   마법 종류에 따라 마나를 차감하고 Console에 어떤 마법을 썼는지 출력
////   마나가 부족하면 “마나가 부족합니다.” 출력
////
//// - Main()에서 Fireball, Heal 순서로 시전하세요.
////
//// [실행 결과]
//// Fireball 시전! 마나가 20 줄어듭니다.
//// Heal 시전! 마나가 10 줄어듭니다.
//// 남은 마나: 70
//// =======================================
// */



/*
    // 필드 (멤버변수) , 지역 변수
    class Knight
    {
        // 필드(=멤버변수)
        // Knight에 포함된 데이터
        public int hp;
        public int atk;
        public string name;

        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values

        void Test()
        {
            // 지역 변수
            hp = 0;
            int a;

            {
                // 지역 변수
                int b = 0;
            }
        }

        public void Attack(int damage)
        {
            int result = hp - damage;
            Console.WriteLine($"{damage}만큼의 피해를 입었습니다.");
        }

        // 구분		    |	필드(Field)								    | 지역 변수(Local Variable)
        //--------------|-----------------------------------------------|-----------------------------------
        // 선언 위치	|	클래스 안쪽						            | 메서드, 생성자, 코드 블록 안
        // 생명 주기	|	객체 생성 → 객체 소멸까지 유지				| 메서드 실행 → 메서드 종료 시 사라짐
        // 접근 범위	|	클래스 내부 전체							| 해당 블록 내부에서만 사용 가능
        // 초기화	    |	자동 초기화됨 (int는 0, bool은 false 등)	| 반드시 직접 초기화해야 함 (안 하면 에러)
        //--------------|-----------------------------------------------|-----------------------------------
    }



    class Program
    {
        static void Main(string[] args)
        {
            // 지역변수
            int a = 0;


            Knight knight = new Knight();
            Knight knight1 = new Knight();
            Knight knight2 = new Knight();
            Knight knight3 = new Knight();

            // knight  [hp][atk][name]
            //         [hp][atk][name]
            // knight2 [hp][atk][name]
            // knight3 [hp][atk][name]

            // 가비지컬랙터 -> 연결이 안되어있는 아무도 사용하지않는 객체를 삭제 시켜버림
        }
    }
}
 
 */

/*
 namespace CSharp
{
    // 멤버 함수, 지역 함수
    class Knight
    {
        public int hp;
        public int atk;
        public string name;


        public Knight()
        {

        }

        // 멤버 함수
        public void Test()
        {
            hp = 0;
        }

        // 멤버 함수
        public void Attack(int damage)
        {
            int a = 0;

            hp = 0;
            // 지역함수
            void Test2() //접근 지정자 붙일수 없음 : 퍼블릭, 프라이빗, 프로텍티드
            {
                int result = hp - damage;
                //
                //
                //
                a = 0;
            }

            Test2();
            Test2();
            Test2();
            Test2();

            Console.WriteLine($"{damage}만큼의 피해를 입었습니다.");
        }


        //				멤버 함수(Member Method)			|	지역 함수 (Local Function)
        //----------|---------------------------------------|--------------------------------------------------
        //선언 위치 |	클래스 안쪽				            |	함수(메서드) 안쪽
        //호출 방법 |	객체명.함수명()으로 호출		    |	선언된 함수 안에서만 함수명()으로 호출
        //접근 범위 |	클래스 전체의 필드에 접근 가능   	|	선언된 함수와 그 함수의 모든 변수에 접근 가능
        //사용 목적 |	객체의 기능을 정의하고 외부에 제공	|	특정 함수 내의 복잡한 로직을 분리하여 가독성을 높임
        //----------|---------------------------------------|---------------------------------------------------

    }



    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.Attack(10);
            
        }
    }
}



// =======================================
// [문제]
// Knight와 Monster 클래스를 정의하고,
// 필드, 지역 변수, 멤버 함수, 지역 함수의 차이를 이해하고 사용하세요.
//
// [요구사항]
// 1. Monster 클래스에는 name(string), hp(int)를 필드로 선언하세요.
// 2. Knight 클래스에는 name(string), atk(int)를 필드로 선언하고,
//    Attack(Monster target)이라는 멤버 함수를 정의하세요.
// 
// 3. Attack 함수 내부에 지역 함수 DamageLog(int damage)를 만들어,
//    Console에 “{몬스터 이름}에게 {데미지}의 피해를 입힘”을 출력하세요.
// 
// 4. Attack 함수에서는 지역 변수 damage(int)를 선언하고,
//    Knight의 atk 값을 대입한 후,
//    Monster의 hp를 감소시키고, 지역 함수로 로그를 출력하세요.
//
// 5. Main()에서 Knight와 Monster 객체를 생성하고,
//    Knight가 Monster를 공격하도록 하세요.
//
// [실행 결과 예시]
// 아서가 고블린에게 30의 피해를 입힘
// 고블린의 남은 체력: 70
// =======================================

class Monster
{
    public string name;   // 필드
    public int hp;        // 필드
}

class Knight
{
    public string name;   // 필드
    public int atk;       // 필드

    // 멤버 함수
    public void Attack(Monster target)
    {
        int damage = atk;  // 지역 변수

        // 지역 함수
        void DamageLog(int dmg)
        {
            Console.WriteLine($"{name}가 {target.name}에게 {dmg}의 피해를 입힘");
        }

        target.hp -= damage;
        DamageLog(damage);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 객체 생성
        Knight knight = new Knight();
        knight.name = "아서";
        knight.atk = 30;

        Monster monster = new Monster();
        monster.name = "고블린";
        monster.hp = 100;

        // 공격
        knight.Attack(monster);

        // 몬스터 상태 출력
        Console.WriteLine($"{monster.name}의 남은 체력: {monster.hp}");
    }
}

 */


/*
 using System.Runtime.CompilerServices;

namespace CSharp
{
    // 게임, 소설 = 설정집
    // 주인공 : 남자답게 생김, 검술 MAX

    // 소설
    // 주인공이 길을 떠낫다.  생명을 불어 넣는다.
    // 객체 생성

    class Knight // 설계도 
    {
        // 공통으로 사용하는 변수
        // 왜 공통으로 사용하냐 
        static public int count = 0; 

        public int hp;
        public int id;

        public Knight()
        {
            count++;
        }
    }

    class Util
    {
        public int a;

        // 객체에 종속적이지 않음
        static public void Test()
        {
            // 객체에 종속적이지 않은 변수는 사용할 수 없음 :
            // ex) a = 0; X  <- 왜냐면 얘는 객체에 종속적임

            Console.WriteLine("기능!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 객체에 종속
            Util util = new Util();
            Util.Test();

            Knight knight1 = new Knight();
            Knight knight2 = new Knight();
            Knight knight3 = new Knight();
            Knight knight4 = new Knight();
                        Console.WriteLine(Knight.count);
        }
    }
}
 */

//static은 클래스 단위로 딱 1개만 존재하는 공유 데이터
/*
        구분	                            설명	                    비유
-------------------------------------------------------------------------------------------------
        객체(멤버) 필드 (int hp)	        객체마다 따로 있음	        붕어빵 속 팥
        객체(멤버) 함수 (void Attack())	    객체가 있어야 호출 가능	    붕어빵이 움직이는 기능
        static 변수 (static int count)	    클래스에 단 하나	        붕어빵 틀에 붙은 카운터
        static 함수 (static void Reset())	클래스 이름으로 호출	    틀 자체를 초기화하는 버튼
 */

//class GameManager
//{
//    // static 변수로 오직 하나의 인스턴스를 저장
//    private static GameManager instance;

//    public static GameManager Instance()
//    {
//        // 아직 없으면 만들고, 있으면 그대로 반환
//            if (instance == null)
//                instance = new GameManager();

//            return instance;
//    }

//    public int score;

//    // 생성자를 private으로 막아서 외부에서 new 못 하게
//    private GameManager()
//    {
//        score = 0;
//        Console.WriteLine("GameManager가 생성되었습니다.");
//    }

//    public void AddScore(int value)
//    {
//        score += value;
//        Console.WriteLine($"현재 점수: {score}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        GameManager.Instance().AddScore(10);
//        GameManager.Instance().AddScore(20);

//        // GameManager.Instance = new GameManager(); ❌ new 불가
//    }
//}
