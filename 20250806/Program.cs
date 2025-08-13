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

class Player
{
    

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp < 0) hp = 0;
    }

    public void Heal(int amount)
    {
        hp += amount;
        if (hp > 100) hp = 100;
    }

    public int GetHp() => hp;
}

class Knight : Player
{

    private int hp = 100;
    public static int count = 0;
    public int id;

    public Knight()
    {
        hp = 10;
        id = count++;
    }

    public void SecretFunction()
    {
        // 굉장히 중요한 기능
        // 타이밍이 중요
    }
}

class SuperKnight  : Knight
{
    public SuperKnight()
    {
        hp = 10;
        id = count++;
    }
}

class Program
{
    static void Main()
    {
        Knight knight = new Knight();
        knight.hp = 0;

        Knight.count = 10;

        knight.SecretFunction();

        Console.Clear();

        
    }
}

