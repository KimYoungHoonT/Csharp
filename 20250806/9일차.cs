//using System.Runtime.CompilerServices;
//using System.Security.Cryptography;

//namespace TextRPG
//{
//    public enum CreatureType
//    {
//        None, Player, Monster
//    }


//    class Creature
//    {
//        protected CreatureType creatureType;
//        protected int hp = 0;
//        protected int atk = 0;
//        protected Creature(CreatureType creatureType)
//        {
//            this.creatureType = creatureType;
//        }
//        public void SetStat(int hp, int atk)
//        {
//            this.hp = hp;
//            this.atk = atk;
//        }
//        public int GetHp() { return hp; }
//        public int GetAtk() { return atk; }
//        public bool IsDead()
//        {
//            return hp <= 0;
//        }
//        public void OnDamaged(int damage)
//        {
//            hp -= damage;
//            if (hp <= 0)
//                hp = 0;
//        }
//    }

//    public enum PlayerType
//    {
//        None, Knight, Archer, Mage
//    }

//    class Player : Creature
//    {
//        protected PlayerType playerType = PlayerType.None;
//        protected Player(PlayerType playerType) : base(CreatureType.Player)
//        {
//            this.playerType = playerType;
//        }
//    }


//    class Knight : Player
//    {
//        public Knight() : base(PlayerType.Knight)
//        {
//            SetStat(10, 10);
//        }
//    }
//    class Archer : Player
//    {
//        public Archer() : base(PlayerType.Archer)
//        {
//            SetStat(75, 12);
//        }
//    }
//    class Mage : Player
//    {
//        public Mage() : base(PlayerType.Mage)
//        {
//            SetStat(50, 15);
//        }
//    }

//    public enum MonsterType
//    {
//        None, Slime, Orc, Skeleton
//    }

//    class Monster : Creature
//    {
//        protected MonsterType type = MonsterType.None;
//        public Monster(MonsterType monsterType) : base(CreatureType.Monster)
//        {
//            this.type = monsterType;
//        }


//        public MonsterType GetMonsterType()
//        {
//            return type;
//        }

//    }

//    class Slime : Monster
//    {
//        public Slime() : base(MonsterType.Slime)
//        {
//            SetStat(10, 1);
//        }
//    }
//    class Orc : Monster
//    {
//        public Orc() : base(MonsterType.Orc)
//        {
//            SetStat(20, 2);
//        }
//    }
//    class Skeleton : Monster
//    {
//        public Skeleton() : base(MonsterType.Skeleton)
//        {
//            SetStat(15, 5);
//        }
//    }

//    public enum GameMode
//    {
//        Lobby,
//        Town,
//        Field
//    }

//    class Game
//    {
//        private GameMode mode = GameMode.Lobby;
//        private Player player;
//        private Monster monster;
//        private Random rand = new Random();
//        public void Process()
//        {
//            switch (mode)
//            {
//                case GameMode.Lobby:
//                    ProcessLobby();
//                    break;
//                case GameMode.Town:
//                    ProcessTown();
//                    break;
//                case GameMode.Field:
//                    ProcessField();
//                    break;
//            }
//        }

//        private void ProcessLobby()
//        {
//            Console.WriteLine("직업 선택좀");
//            Console.WriteLine("1 기사");
//            Console.WriteLine("2 궁수");
//            Console.WriteLine("3 법사");

//            string input = Console.ReadLine();

//            switch (input)
//            {
//                case "1":
//                    player = new Knight();
//                    mode = GameMode.Town;
//                    break;
//                case "2":
//                    player = new Archer();
//                    mode = GameMode.Town;
//                    break;
//                case "3":
//                    player = new Mage();
//                    mode = GameMode.Town;
//                    break;
//            }
//        }

//        private void ProcessTown()
//        {
//            Console.WriteLine("마을에 입장했습니다.");
//            Console.WriteLine("[1] 필드로 가기");
//            Console.WriteLine("[2] 로비로 돌아가기");

//            string input = Console.ReadLine();

//            switch (input)
//            {
//                case "1":
//                    mode = GameMode.Field;
//                    break;
//                case "2":
//                    mode = GameMode.Lobby;
//                    break;
//            }
//        }

//        private void ProcessField()
//        {
//            Console.WriteLine("필드에 입장했습니다.");
//            Console.WriteLine("[1] 싸우기");
//            Console.WriteLine("[2] 일정 확률로 마을로 도망가기");

//            CreateRandomMonster();

//            string input = Console.ReadLine();
//            switch(input)
//            {
//                case "1":
//                    ProcessFight();
//                    break;
//                case "2":
//                    TryEscape();
//                    break;
//                default:
//                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
//                    break;
//            }
//        }

//        private void TryEscape()
//        {
//            int val = rand.Next(0, 100);
//            if (val < 33)
//            {
//                Console.WriteLine("탈주 성공");
//                mode = GameMode.Town;
//            }
//            else
//            {
//                Console.WriteLine("도망실패");
//                ProcessFight();
//            }
//        }

//        private void ProcessFight()
//        {
//            while (true)
//            {
//                int damage = player.GetAtk();
//                monster.OnDamaged(damage);
//                if (monster.IsDead())
//                {
//                    Console.WriteLine("승리했습니다!");
//                    Console.WriteLine($"남은 HP: {player.GetHp()}");
//                    break;
//                }

//                damage = monster.GetAtk();
//                player.OnDamaged(damage);
//                if (player.IsDead())
//                {
//                    Console.WriteLine("패배했습니다...");
//                    mode = GameMode.Lobby;
//                    break;
//                }
//            }
//        }

//        private void CreateRandomMonster()
//        {
//            int randValue = rand.Next(0, 3);
//            switch(randValue)
//            {
//                case 0:
//                    monster = new Slime();
//                    Console.WriteLine("슬라임 생성");
//                    break;
//                case 1:
//                    monster = new Orc();
//                    Console.WriteLine("오크 생성");
//                    break;
//                case 2:
//                    monster = new Skeleton();
//                    Console.WriteLine("스켈레톤 생성");
//                    break;
//            }
//        }

//    }


//    class Program
//    {
//        static void Main()
//        {
//            Game game = new Game();
//            while (true) { game.Process(); }
//        }
//    }
//}