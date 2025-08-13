//using System;
//using System.Xml.Linq;

//class Character
//{
//    // TODO: 이름, 체력, 공격력 필드 만들기
//    public string name;
//    public int hp;
//    public int atk;
//    // TODO: 생성자 만들기 (이름, 체력, 공격력 초기화)
//    public Character(string name, int hp, int atk)
//    {
//        this.name = name;
//        this.hp = hp;
//        this.atk = atk;
//    }
//    // TODO: Attack(Character target) 함수 만들기
//    public void Attack(Character target)
//    {
//        target.hp -= atk;

//    }
//    // TODO: IsDead 속성(HP <= 0이면 true) 만들기
//    public bool IsDead { get; set; }
//}

//class Player : Character// TODO: Character를 상속해서 만드세요
//{
//    // TODO: 경험치 필드 만들기
//    public int exp;
//    // TODO: 생성자 만들기
//    public Player(string name, int hp, int atk, int exp) : base(name, hp, atk)
//    {
//        exp = 0;
//    }
//    // TODO: GainExp(int amount) 함수 만들기
//    public void GainExp(int amount)
//    {
//        exp += amount;
//    }
//}

//class Monster : Character // TODO: Character를 상속해서 만드세요
//{
//    // TODO: 랜덤 HP(20~50), ATK(2~6) 생성하는 생성자 만들기
//    public Monster(string name) : base(name, new Random().Next(20, 51), new Random().Next(2, 7))
//    {

//    }
//    public void MonsterDead(Player player)
//    {
//        if (this.IsDead)
//        {
//            this.hp = 0;
//            player.GainExp(10);
//            Console.WriteLine($"{player.name} 공격 -> {this.name} HP : {this.hp}");
//            Console.WriteLine($"{this.name} 처치! 경험치+10");
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // TODO: 플레이어 생성
//        Player p1 = new Player("용사", 30, 15, 0);

//        //   1) 몬스터 생성
//        Monster mon1 = new Monster("고블린");
//        Monster mon2 = new Monster("슬라임");
//        Console.WriteLine($"몬스터 등장! {mon1.name} (HP {mon1.hp} ATK {mon1.atk})");
//        // TODO: while문으로 게임 반복
//        while (!p1.IsDead)
//        {

//            while (!mon1.IsDead)
//            {

//                p1.Attack(mon1);
//                if (mon1.hp < 0)
//                {
//                    mon1.IsDead = true;
//                    mon1.MonsterDead(p1);
//                    continue;
//                }
//                Console.WriteLine($"{p1.name} 공격 -> {mon1.name} HP : {mon1.hp}");
//                mon1.Attack(p1);
//                if (p1.hp < 0)
//                {
//                    p1.IsDead = true;
//                    p1.hp = 0;
//                    Console.WriteLine($"{p1}이 사망했습니다.");
//                    return;
//                }
//                Console.WriteLine($"{mon1.name} 공격 -> {p1.name} HP : {p1.hp}");
//            }
//            Console.Write("계속 싸우시겠습니까? : (y/n)");
//            string input = Console.ReadLine();
//            switch (input)
//            {
//                case "y":
//                    {
//                        Console.WriteLine($"몬스터 등장! {mon2.name} (HP {mon2.hp} ATK {mon2.atk})");
//                        while (!mon2.IsDead)
//                        {
//                            p1.Attack(mon2);
//                            if (mon2.hp < 0)
//                            {
//                                mon2.IsDead = true;
//                                mon2.MonsterDead(mon2, p1);
//                                continue;
//                            }
//                            Console.WriteLine($"{p1.name} 공격 -> {mon2.name} HP : {mon2.hp}");
//                            mon2.Attack(p1);
//                            Console.WriteLine($"{mon2.name} 반격 -> {p1.name} HP : {p1.hp}");
//                            if (p1.hp < 0)
//                            {
//                                p1.IsDead = true;
//                                p1.hp = 0;
//                                Console.WriteLine($"{p1}이 사망했습니다.");
//                                return;
//                            }


//                        }
//                        break;
//                    }
//                case "n":
//                    {
//                        p1.IsDead = true;
//                        Console.WriteLine("수고하셨습니다.");
//                        break;
//                    }
//            }
//        }

//    }
//    //   2) for문으로 전투 진행 (플레이어 선공 → 몬스터 반격)
//    //   3) if로 승리/패배 판정
//    //   4) 승리 시 경험치 +10
//    //   5) 계속할지 입력 받기
//}