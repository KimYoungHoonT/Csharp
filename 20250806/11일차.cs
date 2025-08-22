//namespace Generic_일반화
//{
//    // 배열 = 고정된 크기의 데이터를 순서대로 저장
//    // 리스트 = 배열과 비슷한데 크기가 자유롭게 늘어나고 줄어드는 더 유연한 구조
//    // 딕셔너리 = 키(Key)와 값(Value) 쌍을 사용해서 데이터를 더 빠르고 쉽게 꺼낼 수 있는 구조

//    // 인벤토리 - 리스트, 
//    // 아이템 정보 - 딕셔너리, 
//    // 맵의 오브젝트 ID - 배열

//    // List<int>
//    // Dictionary<int, string>

//    // Generic(일반화) - 타입을 나중에 결정하는 설계도
//    // 장점
//    // 1. 타입별로 중복되는 코드를 만들 필요 없음
//    // 2. Object 처럼 박싱/언박싱이 필요 없으니 성능 향상
//    // 3. 잘못된 타입을 넣으려 하면 컴파일 시점에서 에러 잡아줌

//    // T - 관례 Type 약자 템플릿의 약자
//    // T 라는게 결과적으로 런타임에 우리가 지정해준 형식으로 치환됨

// class MyList<T> where T : new()
// class MyList<T> where T : class // T는 반드시 참조 형식의 데이터 타입만 가능하다
//class MyList<T> where T : class// T는 반드시 값 형식의 데이터 타입만 가능하다
//{
//    T[] arr = new T[10];

//    public T GetItem(int index)
//    {
//        return arr[index];
//    }

//    struct a
//    {

//    }

//    public void Test()
//    {
//        T test = new T();
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        MyList<Monster> list = new MyList<Monster>();
//    }
//}

//class Monster
//{
//    Monster(int a)
//    {

//    }
//}


//    class MyIntList
//    {
//        int[] arr = new int[10];
//    }

//    class MyfloatList
//    {
//        float[] arr = new float[10];
//    }

//    class MystringList
//    {
//        string[] arr = new string[10];
//    }

//    class MyboolList
//    {
//        bool[] arr = new bool[10];
//    }

//    class MyObjectList
//    {
//        // 하지마라!!!
//        public object[] arr = new object[10];
//    }

//    class Program
//    {
//        static public void Test<T>(T value)
//        {
//            Console.WriteLine($"입력된 값 : {value}");
//        }

//        static void Main()
//        {
//            // object = C# 모~~~~든 타입의 조상 클래스
//            object a = 3; // 박싱: 스택 → 힙
//            int number = (int)a;  // 언박싱: 힙 → 스택

//            // 하지마라
//            MyObjectList myList = new MyObjectList();
//            myList.arr[0] = 3;              // 박싱
//            int value = (int)myList.arr[0]; // 언박싱

//            // var = 타입을 추론
//            // bool a = false;
//            var test1 = 3;         // 컴파일러: "3은 int니까 test는 int구나"
//            var text2 = "Hello";     // 컴파일러: "이건 string이네"

//            MyList<int> myIntList = new MyList<int>();       // int 전용 리스트
//            MyList<string> myStringList = new MyList<string>(); // string 전용 리스트
//            MyList<Monster> myMonsterList = new MyList<Monster>(); // Monster 전용 리스트

//            int test3 = myIntList.GetItem(1);

//            Test(3);          // int 타입으로 호출 하면서 추론
//            Test("Hello"); // string 타입으로 호출 하면서 추론
//            Test(3.14f);    // float 타입으로 호출 하면서 추론

//            Test<int>(3);          // int 타입으로 호출
//            Test<string>("Hello"); // string 타입으로 호출
//            Test<float>(3.14f);    // float 타입으로 호출
//        }
//    }
//}



// 문제
// 인벤토리 라는 이름의 제네릭 클래스를 만들고, 아래 3개의 함수를 구현하세요.

// T[] arr = new T[10]; <----  XXXXXXX
// List<T> arr = new List<T>(); <---- OOOOO

//  int Count() → 현재 인벤토리에 들어있는 아이템 개수를 반환
//  void Add(T item) → 인벤토리에 아이템을 추가
//  T Get(int index) → 인벤토리에서 해당 위치(index)의 아이템을 가져오기

//  그리고 Main 함수에서 아래와 같이 사용해 보세요.
//  Inventory<int>를 만들어 10, 20을 추가한 뒤, 개수와 인덱스 1의 값을 출력
//  Inventory<string>을 만들어 "Sword", "Potion"을 추가한 뒤, 개수와 인덱스 0의 값을 출력

//class Inventory<T>
//{
//    List<T> arr = new List<T>();

//    public int Count()
//    {
//        return arr.Count;
//    }

//    public void Add(T item)
//    {
//        arr.Add(item);
//    }

//    public T Get(int index)
//    {
//        return arr[index];
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Inventory<int> intInv = new Inventory<int>();
//        intInv.Add(10);
//        intInv.Add(20);
//        Console.WriteLine($"Count:Int={intInv.Count()}");
//        Console.WriteLine($"Item:Int[1]={intInv.Get(1)}");

//        Inventory<string> strInv = new Inventory<string>();
//        strInv.Add("Sword");
//        strInv.Add("Potion");
//        Console.WriteLine($"Count:String={strInv.Count()}");
//        Console.WriteLine($"Item:String[0]={strInv.Get(0)}");
//    }
//}

// 출력결과
//  Count:Int = 2
//  Item: Int[1] = 20
//  Count: String = 2
//  Item: String[0] = Sword


//namespace Abstract
//{
//    // 추상클래스 : 상속 구조에서 특정 기능을 반드시 구현하도록 강제 할 수 있음
//    // 하나이상의 추상함수를 갖고있는 클래스
//    // 추상클래스는 미완성 클래스 이기에 객체를 생성할 수 없음

//    // 추상 클래스 Monster 만들기
//    abstract class Monster
//    {
//        // - 이동 기능을 하는 일반 메서드 하나 작성
//        //  > 콘솔에 "몬스터가 한 칸 이동합니다." 출력
//        public void Move()
//        {
//            Console.WriteLine("몬스터가 한 칸 이동합니다.");
//        }

//        // - 공격 기능을 하는 추상 메서드 하나 작성
//        //  > 자식 클래스에서 반드시 구현하도록 할 것
//        abstract public void Attack();
//    }
//    // 자식 클래스 구현
//    // Orc 클래스 (Monster 상속)


//    class Orc : Monster
//    {
//        // 공격 시 "오크가 몽둥이로 공격!" 출력
//        public override void Attack()
//        {
//            Console.WriteLine("오크가 몽둥이로 공격!");
//        }
//    }
//    // Skeleton 클래스 (Monster 상속)

//    class Skeleton : Monster
//    {
//        // 공격 시 "스켈레톤이 화살을 발사!" 출력
//        public override void Attack()
//        {
//            Console.WriteLine("스켈레톤이 화살을 발사!");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Monster monster = new Orc();

//            Orc orc = new Orc();
//            Skeleton skeleton = new Skeleton();

//            orc.Move();
//            orc.Attack();

//            skeleton.Move();
//            skeleton.Attack();
//        }
//    }
//}



// 문제1




// Main에서
// Orc, Skeleton 객체를 각각 생성
// 각 객체의 이동 메서드 호출 후, 공격 메서드 호출

// [출력예시]
// 몬스터가 한 칸 이동합니다.
// 오크가 몽둥이로 공격!
// 몬스터가 한 칸 이동합니다.
// 스켈레톤이 화살을 발사!


//using Abstract;

//namespace Interface
//{
//    // 구분        | 추상 클래스                            | 인터페이스
//    // ----------- | ------------------------------------- | ----------------------
//    // 상속 가능 수 | 1개만 가능                             | 여러 개 가능               
//    // 필드/상태    | 가질 수 있음                           | 가질 수 없음               
//    // 메서드 구현  | 구현된 메서드 + 추상 메서드 혼합 가능    | 구현 불가 (C# 8 전 기준)     
//    // 목적         | **상속 계층**에서 기본 기능 공유 + 강제 | **행동 계약** 강제 (구현만)    
//    // 유연성       | 낮음 (단일 상속)                       | 높음 (다중 구현)            

//    interface IElement
//    {
//        void ElementalAttack();
//    }

//    abstract class Monster
//    {
//        public void Move()
//        {
//            Console.WriteLine("몬스터가 한 칸 이동합니다.");
//        }

//        abstract public void Attack();
//    }

//    // C# 다중상속 금지
//    // 죽음의 다이아몬드 상속

//    //      Monster
//    //      /    \
//    //     Orc   Element
//    //      \     /
//    //     ElementalOrc (다중상속)

//    class FireOrc : Monster, IElement
//    {
//        public override void Attack()
//        {

//        }

//        public void ElementalAttack()
//        {

//        }
//    }

//    class Skeleton : Monster
//    {
//        public override void Attack()
//        {
//            Console.WriteLine("스켈레톤이 화살을 발사!");
//        }
//    }


//    class Program
//    {
//        static void Main()
//        {

//        }
//    }
//}

//using Property;

//namespace Property
//{
//    class Knight
//    {
//        public int Hp { get; private set; }
//    }  // 공개된 필드 → 외부에서 바로 접근 가능

//    //public void SetHp(int hp)
//    //{
//    //    this.hp = hp;
//    //}
//    //public int GetHp()
//    //{
//    //    return hp;
//    //}
//}


//class Program
//{
//    static void Main()
//    {
//        Knight knight = new Knight();
//        int hp = knight.Hp;
//        knight.Hp = 100;  // 외부에서 직접 수정 가능
//    }
//}
//}