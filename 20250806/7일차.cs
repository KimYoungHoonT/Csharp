/*

namespace _20250806
{
    // OOP 의 4가지 특성
    // 추상화 : 공통 속성을 하나의 개념으로 묶는 것
    // 캡슐화 : 내부 정보를 숨기고 외부엔 필요한 기능만 제공
    // 상속 : 기존 클래스를 물려받아 코드 재사용
    // 다형성 : 같은 함수를 다양한 행동을 할 수 있게 함

    // OOP 의 4가지 특징은 "클래스" 안에서 돌아감
    // int a = 10; <- 단순한 변수는 객체가 아님

    // 추상화 : 설계의 시작점
    // 1. 여러 설계도간의 공통점을 추려냄
    // 2. 추려낸 공통점을 하나의 상위 개념으로 정리
    // 3***. 추상 클래스나 인터페이스 표현
    // ex) Knight, Mage, Archer -> Player

    // 상속 : 공통된 구조를 재사용
    // 추상화로 정의된 베이스 클래스를 기반으로, 하위 클래스가 물려받아 사용
    // ex) Knight, Mage, Archer -> Player

    // 다형성 : 같은 이름, 다른행동
    // 상속을 받은 여러 클래스들이 같은 메서드를 각자 다르게 구현할 수 있음

    // 캡슐화 : 안전하고 통제된 사용, 보안 레벨
    // 내부 로직이나 데이터를 외부에는 숨김
    // 공개된 메서드를 통해서 접근 할수 있게 함


    // [1] 추상화: 공통 속성과 기능을 정의한 추상 클래스
    abstract class Player
    {
        // [4] 캡슐화: 내부 데이터는 외부에서 직접 접근 불가능
        private int hp;
        private int mp;

        public void Test(int a)
        {
            hp = a;
        }

        public void Attack()
        {
            Console.WriteLine("공격!");
        }

        public void Defend()
        {
            Console.WriteLine("방어!");
        }

        // [3] 다형성: 하위 클래스에서 다르게 구현할 메서드
        public abstract void UseSpecialSkill();

        // [4] 캡슐화: 공개된 메서드를 통해서만 접근
        public void TakeDamage(int amount)
        {
            hp -= amount;
            Console.WriteLine($"[피해] {amount} 만큼 피해를 입음! 현재 HP: {hp}");
        }
    }

    // [2] 상속: Player 추상 클래스 상속받음
    class Knight : Player
    {
        // [3] 다형성: 스킬 다르게 구현
        public override void UseSpecialSkill()
        {
            Console.WriteLine("방패치기!");
        }
    }

    // [2] 상속: Player 추상 클래스 상속받음
    class Mage : Player
    {
        // [3] 다형성: 스킬 다르게 구현
        public override void UseSpecialSkill()
        {
            Console.WriteLine("파이어볼!");
        }
    }

    // [2] 상속: Player 추상 클래스 상속받음
    class Archer : Player
    {
        // [3] 다형성: 스킬 다르게 구현
        public override void UseSpecialSkill()
        {
            Console.WriteLine("화살 연사!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // [클래스 기반 객체 생성] - OOP는 클래스 설계가 출발점
            Knight knight = new Knight();
            Mage mage = new Mage();
            Archer archer = new Archer();

            // [기능 사용] - 추상 클래스에서 정의된 메서드
            knight.Attack();
            mage.Defend();
            archer.Defend();
            archer.TakeDamage(20); // 캡슐화된 속성 접근

            // [다형성] - 같은 메서드 이름이지만 다른 동작
            knight.UseSpecialSkill();   // -> 방패치기!
            mage.UseSpecialSkill();     // -> 파이어볼!
            archer.UseSpecialSkill();   // -> 화살 연사!
        }
    }
}


    // OOP는 단지 기능이 많은 코드를 짜는 게 아니라, 변화에 강하고, 유지보수하기 쉽고, 협업하기 좋은 구조

    // 절차지향에서 불편했던 점	            ->  객체지향에서는 이렇게 해결됨
    // ------------------------------------------------------------------------------------------
    // 똑같은 코드를 여러 번 써야 함	    ->  공통 속성을 상위 클래스에 넣고, 상속으로 재사용 가능
    // 기능이 많아질수록 코드가 길어짐	    ->  객체 단위로 쪼개고, 각 객체가 자기 일만 처리하게 만듦
    // 수정할 때 모든 함수에 영향감	        ->  캡슐화 덕분에 클래스 내부만 바꾸면 됨
    // 코드를 읽기 어려워짐	                ->  객체 단위로 구조화되어 가독성 향상
    // 확장하거나 새로운 기능 넣기 어려움	->  기존 클래스 건드리지 않고 새 객체만 만들면 됨 (확장성)

    // 추상화(Abstraction) -> 클래스는 현실을 코드로 모델링하는 도구
    // 복잡한 걸 단순하게, 본질만 남기자
    // 공통된 것만 뽑아서 하나로 만들자

    // 핸들 돌리면 방향이 바뀌고
    // 액셀을 밟으면 앞으로 나가고

    // 구분              | 일반 클래스(`class`)               | 추상 클래스(`abstract class`)           
    // ------------------|------------------------------------|------------------------------------ 
    // 인스턴스 생성     | 가능 (`new ClassName()`)           | 불가능(`new AbstractClass()`) 
    // 메서드 구현 여부  | 모든 메서드는 구현이 되어야 함     | 일부 메서드는 미구현(추상 메서드)로 둘 수 있음
    // 목적              | 실제 기능을 가진 구체적 설계도     | 공통 설계와 규칙만 정의하는 추상적 설계도  

    // 추상클래스의 핵심 -> 강제성을 위해
    // https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members


    // 추상의 핵심
    // 공통의 내용추출, 강제성 (인터페이스, 추상클래스)


    // [Player 영역]
    // [id] [hp] [attack]     ← 부모 클래스의 필드가 먼저 생성됨
    // [Knight 영역]
    // [stun] [shield]        ← 그 뒤에 자식 클래스의 필드가 이어서 생성됨


    // 상속은 부모의 속성과 기능을 그대로 물려받아 사용

    // 부모 클래스 = 기반 클래스 = 베이스 클래스
    //class Player
    //{
    //    public int id;
    //    public int hp;
    //    public int attack;

    //    public virtual void Attack()
    //    {
    //        Console.WriteLine("공격합니다.");
    //    }
    //}

    //// 자식 클래스 = 하위 클래스 = 파생 클래스
    //class Knight : Player
    //{
    //    public override void Attack()
    //    {
    //        base.Attack();

    //        Console.WriteLine("기사의 공격합니다.");
    //    }
    //}

    //class Mage : Player
    //{
    //    public override void Attack()
    //    {
    //        Console.WriteLine("메이지의 공격합니다.");
    //    }
    //}


 //!!!!!! 핵심 !!!!!!!
     
    // OOP의 4가지 특징은 서로 연결되어 있음
    // "클래스" 에서 이 4가지 특성이 녹아있는거다 

    // 추상 -> 공통된 속성을 끌어모아 하나로 개념으로 만드는것
    //   |
    // 상속 -> 공통된 속성으로 정의한 부모 클래스를 물려받아 자식클래스에서 사용하는것

    // 상속을 왜쓰냐?
    // 추상으로 공통된 속성을 부모로 만들어 물려받아 사용하면 코드 간편화, 유연성, 확장성 확보 가능해서

    // 상속 사용 하는법
    // class 자식클래스 : 부모클래스
    // Player = 부모 클래스 / 기반 클래스
    // Knight = 자식 클래스 / 파생 클래스

    // 자식 클래스 생성자 호출전 부모 클래스 생성자 호출함

    // [Player 영역]
    // [id] [hp] [attack]     ← 부모 클래스의 필드가 먼저 생성됨
    // [Knight 영역]
    // [stun] [shield]        ← 그 뒤에 자식 클래스의 필드가 이어서 생성됨

    // base 는 부모
    // this 는 나 자신

    // 오버로딩 : 함수 이름 재사용 - 매개변수 다른게 해서 쓰는거
    // 오버라이딩 : 상속 함수 재정의 - 상속 받은거 다른게 내부 구현

    class Player
    {
        public int hp;

        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine($"Player 생성자 - HP: {hp}");
        }

        public virtual void Test()
        {
            Console.WriteLine("sss");
        }
    }

    class Knight : Player
    {
        public Knight(int hp) : base(hp)
        {
            Console.WriteLine($"HP: {hp}");
        }

        public override void Test()
        {
            Console.WriteLine("자식!");
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            //Knight knight = new Knight(10);
            //knight.hp = 10;
            //knight.Test();

            Dog dog = new Dog("강아지");
            dog.MakeSound();
            Cat cat = new Cat("고양이");
            cat.MakeSound();
            Cow cow = new Cow("소");
            cow.MakeSound();

        }
    }
}

//문제)
//	당신은 동물원 시스템을 만들고 있는 개발자입니다.
//	동물들은 공통적으로 이름을 가지고 있으며, 각자 고유한 울음소리를 냅니다.
//	부모 클래스 Animal은 부모 클래스이며, 모든 동물은 이 클래스를 상속받아야 합니다.

//	구현 조건
//	1. 클래스 Animal을 만드세요.
//	- string Name (필드 = 멤버변수) 를 가짐
//	- 생성자에서 "안녕하세요, 저는 [이름] 입니다" 출력
//	- void virtual MakeSound(); 메서드를 선언
//  - 자식 클래스는 이 클래스를 상속받아서 재정의 해주세요.

//	2. 다음 세 개의 클래스를 만들고 Animal을 상속받으세요.
//	- Dog → "멍멍!" 출력
//	- Cat → "야옹~" 출력
//	- Cow → "음머~" 출력
//	※ 각 동물의 소리는 MakeSound() 메서드 오버라이딩을 통해 구현합니다.

//	3. Main() 함수에서 각각의 동물을 생성하고, MakeSound()를 호출하세요.


//    [출력예시]
//  안녕하세요, 저는 댕댕이입니다
//	멍멍!

//	안녕하세요, 저는 나비입니다
//	야옹~

//	안녕하세요, 저는 해피카우입니다
//	음머~


class Animal
{
    public string name;

    public Animal(string name)
    {
        Console.WriteLine($"안녕하세요 저는 {name} 입니다");
    }
    public virtual void MakeSound()
    {
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine("멍멍");
    }
}
class Cat : Animal
{
    public Cat(string name) : base(name)
    {

    }
    public override void MakeSound()
    {
        Console.WriteLine("냐옹");
    }
}
class Cow : Animal
{
    public Cow(string name) : base(name)
    {

    }
    public override void MakeSound()
    {
        Console.WriteLine("음메");
    }
}

using static System.Net.Mime.MediaTypeNames;

namespace _20250806
{
    // 클래스 형식변환

    class Player
    {
        public int hp;
        public int atk;

        public void Attack()
        {

        }
    }

    // [Player]
    // [Knight]

    class Knight : Player
    {

    }

    class Mage : Player
    {
        public int mp;
    }

    class Program2
    {
        static void EnterGame(Player player)
        {
            Mage mage2 = (Mage)player;
            bool isMage = (player is Mage);
            if (isMage == true)
            {
                mage2 = (Mage)mage2;
                mage2.mp = 10;
            }

            Mage mage = (player as Mage); //(Mage)player
            if (mage != null)
            {
                mage.mp = 10;
            }
        }

        static void Main()
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            knight = null;
            // 가비지컬랙터 

            Player magePlayer = mage;
            Mage mage2 = (Mage)magePlayer;

            EnterGame(knight);
        }
    }
}


/*
   is 연산자는 형변환을 시도하고, 실패하면 null을 반환한다. (O / X)

    as 연산자는 타입이 맞는지 확인하여 true 또는 false를 반환한다. (O / X)
 */
