//namespace MyLinkedList
//{
//    // 오늘의 강의 순서
//    // 1. 고급문법 처음부터 끝까지 복습
//    // 2. 어제 만든 리스트 만들기 (되도록 안보고) 그치만 보고 만들어도 GPT 써되 됨
//    // 3. 연결리스트 재 구현(강사가)
//    // 4. 연결리스트 구현 (학생이)
//    // 5. 딕셔너리, 해시셋 에 대하여
//    // 6. 딕셔너리와 해시셋이 사용하는 헤시테이블 기능이란?



//    class MyLinkedList
//    {

//    }

//    class Program
//    {
//        static void Main()
//        {

//        }
//    }
//}


class Program
{
    static void Main(string[] args)
    {
        int[] a = { 1, 2, 3, 4, 5, 6 };
        int[] b = { 7, 7, 73, 74, 75, 76 };

        List<int> list = new List<int>();
        list.AddRange(b);
        list.AddRange(a);

    }
}