namespace _20250806
{
    class Program
    {
        // 열거자(Enumerator) 
        // 어떤 데이터 집합을 순서대로 하나씩 탐색하는 기능
        // IEnumerable 인터페이스
        // IEnumerator 인터페이스
        // foreach -> 위의 두가지 인터페이스 개념위에 구축되어있음

        /*
                      [컬렉션] ──▶ GetEnumerator()
                         │
                         ▼
                ┌───────────────────┐
                │  Enumerator 객체   │
                │───────────────────│
                │ + MoveNext()      │
                │ + Current         │
                └───────────────────┘
                         │
                         ▼
                foreach 루프 실행

         Start
           │
           ▼
        [컬렉션]
           │  GetEnumerator()
           ▼
        Enumerator 생성
           │
           ▼
        while (MoveNext())
           │
           ├─ true ─▶ Current 읽기 ─▶ 루프 본문 실행 ─┐
           │                                          │
           └─ false ──────────────────────────────────┘
           │
           ▼
           End
        */

        // 배열은 연속된 저장공간에 할당
        //   []      []      []      []      [] 
        // 0x1000  0x1004  0x1008  0x1012  0x1016

        // indexer this[int index]

        // arr[7]
        // element_address = base_address + (index* sizeof(T))
        // 사용자에게는 노출 하지 않고 컴파일/JIT 이 알아서 처리를 해줍니다. 

        // Head ──▶ [10 | next] ──▶ [20 | next] ──▶ [30 | null]

        /*
         Start → node = head
            │
            ▼
            MoveNext()
            │ true
            ▼
            Current = node.Value (10)
            node = node.Next
            │
            ▼
            MoveNext()
            │ true
            ▼
            Current = node.Value (20)
            node = node.Next
            │
            ▼
            MoveNext()
            │ true
            ▼
            Current = node.Value (30)
            node = node.Next (null)
            │
            ▼
            MoveNext()
            │ false
            ▼
            End
         */

        // 유니티 
        // IEnumorator Test()
        // {
        //    yield => 내부에서 IEnumerator와 IEnumerable 인터페이스 자동구현 코드 생성
        //    
        //    return new waitForSecond(3);
        //    Consoloe.WriteLine("sdsdsd");
        // }


        // IEnumorator MoveRight()
        // {
        //    // 오른쪽 으로만 이동하는 코드
        // }

        // void MoveUp()
        // {
        //    // 위쪽 으로만 이동하는 코드
        // }

        // [프레임루프]
        //    |
        //    ㄴ StartCourutine(MoveRight) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
        //    ㄴ StartCourutine(MoveUp) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
        //    ㄴ 다른 코루틴 있는지 확인?

        // 코루틴 => 하나의 쓰레드에서 처리되는거다!

        static void Main()
        {
            
        }
    }
}
