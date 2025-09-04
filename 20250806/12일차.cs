//namespace Delegate
//{
//    똑같다, 다만 언어차원에서 이미 지정한 차이가 있다.
//    Action 보이드
//    Func 반환형식 있는거
//    콜백위해 사용한다.

//    // delegate = 대리자
//    // 함수 자체를 인자로 넘겨주는 방식이 가능하게 함
//    // 즉, 함수를 타입화 시켜줌 -> int 라는 타입 = [정수형식]을 int 라는 이름으로 부름
//    // 함수의 원형 (시그니처)
//    // delegate void OnClicked() 라는 애는 [void를 반환하고 매개변수가 없는 타입]을 OnClicked 라고 부르겠다는것

//    // Event 
//    // delegate의 아무대서 호출되는 부분을 랩핑을 통해서 아무대서나 호출되지 않게 막는것

//    // Action
//    // void 반환 즉 아무것도 반환하지 않는 델리게이트에 대해서 C#에서 미리 선언해둔것
//    // delegate void action(int a, float b);   => Action<int, float> action;
// Action<(매개변수)> 액션이름;
// 액션이름 += 같은 함수타입의 함수;

//    // Func
//    // void가 아닌 반환이 존재하는 델리게이트에 대해서 C#에서 미리 선언해둔것
//    // delegate int Test(string a, float b);  => Func<string, float, int> func;
// Func<(매개변수),반환타입> 펑크이름;
// 펑크이름 += 같은 함수타입의 함수;

//    class A
//    {
//        public delegate int delegate1();
//        public event delegate1 eventDelegate;
//        public event delegate1 eventDelegate;
//        Action action;
//        public void Test(OnClicked onClick)
//        {

//            onClick();

//            eventDelegate.Invoke();
//        }

//    }

//class Program
//{
//    static int Test(delegate1 d)
//    {
//        d();
//        return 0;
//    }

//    static void Main()
//    {
//        A a = new A();
//        delegate1 d = new delegate1(Test2);
//        d += Test3;
//        a.action += test();

//        a.Test(d);
//         a.eventDelegate();        X <- 이벤트로 랩핑 해놓으면 델리게이트 선언부에서만 호출 가능
//         a.eventDelegate.Invoke(); X <- 이벤트로 랩핑 해놓으면 델리게이트 선언부에서만 호출 가능

//    }
//}
//}


////namespace Event
////{
////    class Program
////    {
////        static void Main()
////        {

////        }
////    }
////}


////namespace Action
////{
////    class Program
////    {
////        static void Main()
////        {

////        }
////    }
////}


////문제 1 
////다음 코드를 실행했을 때 콘솔 출력과 result 값은 무엇인가?
////class Program
////{
////    delegate int OnClicked();

////    static int Test()
////    {
////        Console.WriteLine("C# 은 너무 재밌어");
////        return 1;
////    }

////    static int ButtonEvent(OnClicked clickedFunc)
////    {
////        // UI 처리 로직 가정…
////        return clickedFunc();
////    }

////    static void Main()
////    {
////        OnClicked d = new OnClicked(Test);
////        int result = ButtonEvent(d);
////        Console.WriteLine("result = " + result);
////    }
////}



////문제2
////다음 조건을 만족하는 코드를 작성하세요.
////1. Enemy 클래스 내부에 델리게이트 OnDie를 정의한다.
//class Enemy
//{
//    // -> 시그니처: void(string killerName, int reward)
//    public delegate void OnDie(string KillerName, int reward);

//    //2.Enemy 클래스는 다음 멤버를 가진다.
//    // -> string Name, int Hp, int Reward, OnDie dieCallback(private)
//    public string Name;
//    public int Hp;
//    public int Reward;
//    private OnDie dieCallback;

//    //3.생성자 Enemy(string name, int hp, int reward, OnDie onDieCallback)에서 모든 필드를 초기화한다.
//    public Enemy(string name, int hp, int reward, OnDie onDieCallback)
//    {
//        Name = name;
//        Hp = hp;
//        Reward = reward;
//        dieCallback = onDieCallback;
//    }

//    //4. void TakeDamage(int amount, string attacker) 함수를 정의한다.
//    public void TakeDamage(int amount, string attacker)
//    {
//        // -> Hp에서 amount만큼 감소시키고 "[{Name}] HP: {Hp}"를 출력한다.
//        Hp -= amount;
//        Console.WriteLine("[" + Name + "] HP: " + Hp);
//        // -> Hp가 0 이하가 되면 "[{Name}] 처치!"를 출력하고,
//        if (Hp <= 0)
//        {
//            Console.WriteLine("[" + Name + "] 처치!");
//            // -> dieCallback이 null이 아니면 dieCallback(attacker, Reward)를 호출한다.
//            if (dieCallback != null)
//            {
//                dieCallback(attacker, Reward);
//            }
//        }
//    }
//}
//////5. Program 클래스에 
//class Program
//{
//    // 콜백 메서드 static void OnEnemyDie(string killerName, int reward)를 구현한다.
//    static void OnEnemyDie(string killerName, int reward)
//    {
//        // -> "{killerName}이(가) +{reward} 점수를 획득"
//        Console.WriteLine(killerName + "이(가) +" + reward + " 점수를 획득");
//        // -> "[효과음] 처치 사운드 재생"
//        Console.WriteLine("[효과음] 처치 사운드 재생");
//        // -> 가 출력되도록 구현한다.

//    }

//    static void Main()
//    {
//        ////6. Main()에서 다음 순서로 호출 한다.
//        //// -> Enemy slime = new Enemy("Slime", 20, 100, OnEnemyDie);
//        Enemy slime = new Enemy("Slime", 20, 100, OnEnemyDie);

//        //// -> slime.TakeDamage(5, "Knight"); 
//        slime.TakeDamage(5, "Arthur");   // 처치 아님

//        //// -> slime.TakeDamage(20, "Knight");
//        slime.TakeDamage(20, "Arthur");  // 처치, 콜백 실행

//        ////출력 예시
//        ////[Slime] HP: 15
//        ////[Slime] HP: -5
//        ////[Slime] 처치!
//        ////Knight이(가) + 100 점수를 획득
//        ////[효과음] 처치 사운드 재생
//        ///
//    }
//}


// Action = void 형식의 델리게이트를 미리 언어차원에서 선언해둔것
// 매개변수를 최대 16개까지 받을수 있다.
// 외부에서도 이 액션에 대해서 Invoke를 통해서 호출해줄수 있다.

//class Player
//{

//}

//class Mage : Player
//{
//    public void Attack()
//    {

//    }
//}

//class Knight : Player 
//{ 

//}

//class TestException : Exception
//{

//}

//class Program
//{


//    static void Main()
//    {
//        //int[] arr = new int[1];

//        //int a = 10;
//        //int b = a / 0;

//        try
//        {
//            Player p = new Knight();
//            Mage m = (Mage)p;
//            m.Attack();
//        }
//        catch (Exception e)
//        {

//        }

//    }
//}


// delegate 핵심은 = 함수의 타입화

//class Program
//{
//    // lambda = 일회용 함수 만드는 방법
//    delegate void On();

//    // 반환값이 없는 미리 만들어둔 델리게이트
//    Action action;

//    // 반환값이 있는 미리 만들어둔 델리게이트
//    Func<int, int> func;

//    public class Item
//    {
//        public enum ItemType
//        {
//            Weapon,
//            Armor,
//            Amulet,
//            Ring
//        }

//        public enum Rariry
//        {
//            Normal,
//            Uncommon,
//            Rare
//        }

//        public ItemType itemType;
//        public Rariry rariry;
//    }

//    public static List<Item> _items = new List<Item>();
//    delegate bool ItemSelector(Item item);

//    static Item FindItem(ItemSelector selector)
//    {
//        foreach (Item item in _items)
//        {
//            if (selector(item))
//                return item;
//        }
//        return null;
//    }

//    // 식 본문 멤버(Expression-bodied member)
//    // public void Test() => Console.WriteLine("");

//    // 람다연산자, 람다 오퍼레이터
//    // FindItem((Item item) => item.itemType == ItemType.Weapon );

//    // delegate를 직접 선언하지 않아도, 이미 다 만들어놨음
//    //  -> 반환타입이 있는경우 : Func
//    //  -> 반환타입이 없는경우 : Action

//    //static void Main()
//    //{
//    //    _items.Add(new Item() { itemType = Item.ItemType.Weapon, rariry = Item.Rariry.Normal });
//    //    _items.Add(new Item() { itemType = Item.ItemType.Armor, rariry = Item.Rariry.Uncommon });
//    //    _items.Add(new Item() { itemType = Item.ItemType.Ring, rariry = Item.Rariry.Rare });

//    //    Item weapon = FindItem(delegate (Item item)
//    //    {
//    //        return item.itemType == ItemType.Weapon;
//    //    }
//    //    );

//    //    무명메서드 - 이름없는 함수

//    //    Item armor = FindItem(delegate (Item item) { return item.itemType == ItemType.Armor; });
//    //    Item ring = FindItem(delegate (Item item) { return item.itemType == ItemType.Ring; });

//    //    FindItem((Item item) => item.itemType == ItemType.Weapon);
//    //}
//}
