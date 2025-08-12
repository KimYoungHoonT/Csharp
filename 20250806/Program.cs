
//문제1.
//class A
//{
//    public void Act() { Console.WriteLine("A.Act"); }
//}

//class B : A
//{
//    public void Act(int x) // (L1) ← 시그니처 다름 (override 아님, 오버로드)
//    {
//        Console.WriteLine($"B.Act({x})");
//    }
//}

//----메인함수-- -
//A obj = new B();
//obj.Act();        // 무엇이 출력될까?
//// obj.Act(10);   // 이 줄을 주석 해제하면 컴파일 가능한가? 안되면 왜 안되는지?


//문제2.
//class A
//{
//    public A(string name) { Console.WriteLine($"A:{name}"); }
//}

//class B : A
//{
//    public B() : A()
//    {
//        Console.WriteLine("B");
//    }
//}

//----메인함수-- -
//A a = new B(); // 컴파일 가능한가?



//문제3.
//class A
//{
//    public void Hello() { Console.WriteLine("A.Hello"); }
//}

//class B : A
//{
//    public override void Hello()
//    {
//        Console.WriteLine("B.Hello");
//    }
//}

//----메인함수-- -
//new B().Hello(); // 컴파일 가능?



//문제4.
//class A
//{
//    public virtual void Go() { Console.WriteLine("A"); }
//}

//class B : A
//{
//    public virtual void Go() { Console.WriteLine("B"); }
//}

//----메인함수-- -
//new B().Go(); // 출력결과는?


//문제5.
//class Player
//{
//    public virtual void Attack()
//    {
//        Console.WriteLine("Player.Attack");
//    }
//}

//class Knight : Player
//{
//    public override void Attack()
//    {
//        Console.WriteLine("Knight.Attack");
//    }
//}
//class Mage : Player
//{
//    public void Cast()
//    {
//        Console.WriteLine("Mage.Cast");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Player p = new Knight();
//        Mage m = p as Mage;
//        Console.WriteLine(m == null ? "NULL" : "NOT NULL");
//        m.Cast();
//    }
//}
//// 출력 결과는?
//// 문제 없이 돌아가나?



//class Program
//{
//    static void Main()
//    {
//        int o1 = 5;
//        int i1 = o1 is int;      // 결과는?
//        int i2 = o1 as int;    // 결과는?


//        Console.WriteLine(i2.HasValue ? i2.Value.ToString() : "null");
//    }
//}
