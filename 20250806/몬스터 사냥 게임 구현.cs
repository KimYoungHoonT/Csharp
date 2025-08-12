class Character
{
    public string Name;
    public int Hp;
    public int Atk;

    public Character(string name, int hp, int atk)
    {
        Name = name;
        Hp = hp;
        Atk = atk;
    }

    public virtual void Attack(Character target)
    {
        target.Hp -= Atk;
        if (target.Hp < 0) target.Hp = 0;
    }

    public bool IsDead()
    {
        return Hp <= 0;
    }
}

class Player : Character // Character를 상속
{
    public int Exp = 0;

    public Player(string name, int hp, int atk) : base(name, hp, atk) { }

    public void GainExp(int amount)
    {
        Exp += amount;
    }
}

class Monster : Character // Character를 상속
{
    static Random _rand = new Random();

    public Monster(string name)
        : base(name, _rand.Next(20, 51), _rand.Next(2, 7)) { }
}

class Program
{
    static void Main()
    {
        Player player = new Player("용사", hp: 35, atk: 8);
        Console.WriteLine("=== 몬스터 사냥 콘솔 게임 ===");

        while (player.Hp > 0) // 게임 반복
        {
            Monster m = new Monster(RandomName());
            Console.WriteLine($"\n몬스터 등장! {m.Name} (HP:{m.Hp}, ATK:{m.Atk})");

            // 전투 시작
            for (; !player.IsDead() && !m.IsDead();) // <- for문을 while처럼 사용
            {
                // 플레이어 공격
                player.Attack(m);
                Console.WriteLine($" {player.Name} 공격 → {m.Name} HP:{m.Hp}");

                if (m.IsDead()) break; // 승리

                // 몬스터 반격
                m.Attack(player);
                Console.WriteLine($" {m.Name} 반격 → {player.Name} HP:{player.Hp}");
            }

            if (player.IsDead())
            {
                Console.WriteLine(" 플레이어가 쓰러졌습니다. 게임 종료!");
                break;
            }
            else
            {
                Console.WriteLine($"✅ {m.Name} 처치! 경험치 +10");
                player.GainExp(10);
                Console.WriteLine($"현재 EXP: {player.Exp}");
            }

            Console.Write("계속 싸우시겠습니까? (y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower();
            if (input != "y") break;
        }

        Console.WriteLine("\n수고하셨습니다!");
    }

    static string RandomName()
    {
        string[] names = { "슬라임", "고블린", "늑대", "박쥐" };
        return names[new Random().Next(names.Length)];
    }
}