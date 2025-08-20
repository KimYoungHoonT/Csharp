using TRPG;

namespace TRPG
{
    // TODO : PlayerType 이라는 이넘을 만들어주세요.
    //  > 이넘안에 None, Knight, Archer, Mage 를 0,1,2,3 값을 갖도록 만들어주세요.

    // TODO : 플레이어 클래스를 만들어 주세요.
    //  > PlayerType 타입의 멤버변수를 playerType 만들고 기본값으로 None 을 대입해주세요.
    //  > int 타입의 멤버변수를 hp 만들고 0 을 대입해주세요.
    //  > int 타입의 멤버변수를 atk 만들고 0 을 대입해주세요.
    //  > 매개변수로 PlayerType을 한개 받는 생성자를 만들어주세요
    //    > 내부에선 playerType 필드를 매개변수의 playerType 으로 대체하는 코드를 넣어주세요. 
    //  > 체력/공격력 세팅용 SetStat(int hp, int atk) 메서드를 만들어 주세요.
    //  > 현재 hp/atk 값을 읽는 GetHp(), GetAtk() 메서드를 만들어 주세요.
    //  > 사망 여부를 반환하는 IsDead() 메서드를 만들어 주세요. (hp <= 0 이면 true)
    //  > 피해를 적용하는 OnDamaged(int damage) 메서드를 만들어 주세요.
    //    > hp에서 damage 를 빼고, 0 미만이면 0으로 보정하세요.
    class Player
    {
        // TODO : 멤버변수 선언

        // TODO : 생성자

        // TODO : SetStat

        // TODO : GetHp

        // TODO : GetAtk

        // TODO : IsDead

        // TODO : OnDamaged
    }

    // TODO : Knight 클래스를 만들어 주세요.
    //  > Player 를 상속받습니다.
    //  > 매개변수 없는 생성자를 만들고, base(PlayerType.Knight) 를 호출하세요.
    //  > 생성자 안에서 SetStat(100, 10) 으로 스탯을 설정하세요.
    class Knight : Player
    {
        // TODO : Knight 생성자
    }

    // TODO : Archer 클래스를 만들어 주세요.
    //  > Player 를 상속받습니다.
    //  > 매개변수 없는 생성자를 만들고, base(PlayerType.Archer) 를 호출하세요.
    //  > 생성자 안에서 SetStat(75, 12) 으로 스탯을 설정하세요.
    class Archer : Player
    {
        // TODO : Archer 생성자
    }

    // TODO : Mage 클래스를 만들어 주세요.
    //  > Player 를 상속받습니다.
    //  > 매개변수 없는 생성자를 만들고, base(PlayerType.Mage) 를 호출하세요.
    //  > 생성자 안에서 SetStat(50, 15) 으로 스탯을 설정하세요.
    class Mage : Player
    {
        // TODO : Mage 생성자
    }
}

namespace TRPG
{
    // TODO : MonsterType 이라는 이넘을 만들어 주세요.
    //  > None, Slime, Orc, Skeleton을 0, 1, 2, 3 값으로 갖도록 작성하세요.


    // TODO : Monster 클래스를 만들어 주세요.
    //  > MonsterType 타입의 멤버변수 type을 만들고 기본값 None 대입
    //  > int hp, int atk 멤버변수 추가하고 기본값 0 대입
    //  > MonsterType 1개를 받는 protected 생성자 만들기
    //    > 매개변수 값을 type 필드에 대입
    //  > SetStat(int hp, int atk) 메서드 만들기
    //  > GetMonsterType() 메서드 만들기 (type 반환)
    //  > GetHp(), GetAtk() 메서드 만들기
    //  > OnDamaged(int damage) 메서드 만들기 (hp에서 damage 빼고 0 미만이면 0)
    class Monster
    {
        // TODO : 멤버변수 선언

        // TODO : 생성자

        // TODO : SetStat

        // TODO : GetMonsterType

        // TODO : GetHp

        // TODO : GetAtk

        // TODO : OnDamaged
    }

    // TODO : Slime 클래스를 만들어 주세요.
    //  > Monster 상속
    //  > 생성자에서 base(MonsterType.Slime) 호출
    //  > SetStat(10, 1) 호출
    class Slime : Monster
    {
        // TODO : Slime 생성자
    }

    // TODO : Orc 클래스를 만들어 주세요.
    //  > Monster 상속
    //  > 생성자에서 base(MonsterType.Orc) 호출
    //  > SetStat(20, 2) 호출
    class Orc : Monster
    {
        // TODO : Orc 생성자
    }

    // TODO : Skeleton 클래스를 만들어 주세요.
    //  > Monster 상속
    //  > 생성자에서 base(MonsterType.Skeleton) 호출
    //  > SetStat(15, 5) 호출
    class Skeleton : Monster
    {
        // TODO : Skeleton 생성자
    }
}


namespace Other
{
    // TODO: CreatureType 이라는 enum을 만들어주세요.
    //  > None, Player, Monster 를 0, 1, 2 값으로 갖도록 해주세요.


    // TODO: Creature 라는 클래스를 만들어주세요.
    //  > CreatureType 타입의 creatureType 멤버변수를 만들어주세요.
    //  > int 타입의 hp, atk 멤버변수를 만들어주세요 (기본값 0).
    //  > creatureType을 매개변수로 받는 protected 생성자를 만들어주세요.
    //  > SetStat(int hp, int atk) 메서드를 만들어 hp와 atk를 설정하게 해주세요.
    //  > GetHp(), GetAtk() 메서드를 만들어 각각 hp와 atk를 반환하게 해주세요.
    //  > IsDead() 메서드를 만들어 hp가 0 이하이면 true를 반환하게 해주세요.
    //  > OnDamaged(int damage) 메서드를 만들어 hp를 damage만큼 감소시키고, 0 이하가 되면 0으로 설정되게 해주세요.
}

namespace Other
{
    // TODO: PlayerType 이라는 enum을 만들어주세요.
    //  > None, Knight, Archer, Mage 를 0, 1, 2, 3 값으로 갖도록 해주세요.


    // TODO: Player 클래스를 Creature로부터 상속받아 만들어주세요.
    //  > PlayerType 타입의 playerType 멤버변수를 만들고 기본값을 None으로 설정해주세요.
    //  > PlayerType을 매개변수로 받는 protected 생성자를 만들고,
    //    creatureType을 CreatureType.Player로 설정한 뒤 playerType을 대입해주세요.

    // TODO: Knight, Archer, Mage 클래스를 Player로부터 상속받아 만들어주세요.
    //  > 각 생성자에서 base()로 해당 PlayerType을 넘기고,
    //    SetStat()을 사용해 Knight(100,10), Archer(75,12), Mage(50,15)로 설정해주세요.
}

namespace Other
{
    // TODO: MonsterType 이라는 enum을 만들어주세요.
    //  > None, Slime, Orc, Skeleton 를 0, 1, 2, 3 값으로 갖도록 해주세요.


    // TODO: Monster 클래스를 Creature로부터 상속받아 만들어주세요.
    //  > MonsterType 타입의 type 멤버변수를 만들고 기본값을 None으로 설정해주세요.
    //  > MonsterType을 매개변수로 받는 protected 생성자를 만들고,
    //    creatureType을 CreatureType.Monster로 설정한 뒤 type을 대입해주세요.
    //  > GetMonsterType() 메서드를 만들어 type을 반환하게 해주세요.

    // TODO: Slime, Orc, Skeleton 클래스를 Monster로부터 상속받아 만들어주세요.
    //  > 각 생성자에서 base()로 해당 MonsterType을 넘기고,
    //    SetStat()을 사용해 Slime(10,1), Orc(20,2), Skeleton(15,5)로 설정해주세요.
}

namespace Other
{
    class Program
    {
        static void Main()
        {
            // TODO: Knight 플레이어를 생성해서 Player 변수에 담아주세요.
            // TODO: Orc 몬스터를 생성해서 Monster 변수에 담아주세요.
            // TODO: 플레이어의 공격력을 가져와서 monster.OnDamaged()로 몬스터에게 피해를 주는 코드를 작성해주세요.

            // Console.WriteLine($"몬스터의 남은 HP: {monster.GetHp()}");
        }
    }
}


// 최종 출력물
// 몬스터의 남은 HP: 10
