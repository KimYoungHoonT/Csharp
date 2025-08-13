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

class Player
{
    private int hp = 100;

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

