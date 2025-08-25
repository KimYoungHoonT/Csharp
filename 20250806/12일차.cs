//namespace Delegate
//{
//    // delegate = 대리자
//    // 콜백을 가능하게 해주는 도구
//    // 함수 자체를 인자로 넘겨주는 방식

//    // 퀵서비스 
//       // 연락처 넘김
//    // 도착하면 연락함

//    // 함수를 매게변수로 넘겨주는 방식

//class Program
//{
//    // delegate -> 형식은 형식인데, 함수 자체를 인자로 넘겨주는 형식
//    // 반환 : int , 입력 : void
//    // OnClicked 이 delegate 형식의 이름
//    delegate int OnClick();
//    delegate void OnClick2();

//    // UI - Button button;
//    // button.onClick.AddListener( )

//    // int = 정수 형식
//    // OnClick = 인트 반환하고 매개변수 안받는 형식

//    // [ 60, 30, 20, 10, 40, 50 ]

//    //  static List<int> Sort(/*비교하는함수 비교*/)
//    //  {
//    //      // 어떠한 행동
//    //      결과값 = /*비교*/
//    //// 어떠한 행동
//    //      return 결과값;
//    //  }

//    static void ButtonEvent(OnClick onClick)
//    {
//        // UI 로직

//        /*함수 받음*/
//        onClick.Invoke();
//    }

//    static int Test()
//    {
//        Console.WriteLine("이건 넘겨주는 함수야");
//        return 0;
//    }

//    static int Test2()
//    {
//        Console.WriteLine("이건 넘겨주는 2번째 함수야");
//        return 0;
//    }

//    static void Attack()
//    {
//        // 플레이어 공격
//        // 점프
//        // 화장실 가기
//    }

//    static void Main()
//    {
//        OnClick onClick = new OnClick(Test);
//        onClick += Test2;

//        ButtonEvent(onClick);
//    }
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

class InputManager
{
    public Action<int, int> Action;

    public void Update()
    {
        Action.Invoke(10, 20);
    }
}

class Program
{
    static void Test(int a, int b)
    {
        Console.WriteLine("C# 은 너무나 행복하고 즐겁다! 웃음이 절로난다 하하하");
    }

    static void Main()
    {
        InputManager inputManager = new InputManager();
        inputManager.Action += Test;

        inputManager.Action.Invoke(10, 20);

        // inputManager.InputKey.Invoke();

        while (true)
        {
            inputManager.Update();
        }
    }
}
