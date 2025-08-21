using System.Threading;

namespace 자료구조 
{
    class Player
    {

    }

    class Monster
    {
        public int hp;
    }

    class _10일차
    {
        // 배열 = 같은 종류의 데이터를 한줄로 묶어놓은 연속된 저장공간
        // 일반배열 = 고정된 배열 - 크기를 수정하지 못한다.
        // 배열은 참조 형식이다.

        // int[] a = new int[6];
        // a = new int[7];
        //정리 : 아예 새로운 배열을 만들고 변수의 참조를 변경, 기존 배열은 메모리 어딘가에 남아있다가 나중에 삭제됨

        // int, flaot, bool = 값 그자체 저장됨 = 값형식 배열
        // class, array = 힙영역에 생성 그 주소가 스택에 저장됨 = 참조형식 배열

        // foreach 는 읽기 전용 반복문이다.
        // 엘리먼트는 읽기전용이라 변경이 불가하다
        // 값형식은 엘리먼트 자체에 값이 들어가있어 변경불가
        // 참조형식은 엘리먼트가 주소이기에 그걸 타고 들어가서 내부 필드에 접근하여 내부 필드는 값의 변경이 가능하다.
        // 단순 조회, 출력, 합계, 검색 최적
        // 그래서 데이터를 읽기만 할때는 foreach 유용하다 
        // 배열의 요소를 수정해야할때는 for 문을 사용

        static void Main()
        {
            int[] c = new int[6] { 10, 20, 30, 40, 50, 60 };
            //int[] c = new int[] { 10, 20, 30, 40, 50, 60 };
            //int[] c = { 10, 20, 30, 40, 50, 60 };
            // b[10][20][30][40][50][60]

            int[] array = new int[6]; // 배열 만들기 공간설정 // a[0][0][0][0][0][0]
            array[0/*인덱스*/] = 1; // 값 쓰기
            int b = array[0/*인덱스*/]; // 값 읽기

            // foreach 는 읽기전용
            // foreach 받아온 개별 엘리먼트는 수정을 할 수 없음
            foreach (int item in array)
            {
                // item = 10; X
                int temp = item;
                Console.WriteLine(item);
            }

            Monster[] monsters = new Monster[3]; // heap [Monster][null][null]
                                                 //          ^            
            monsters[0] = new Monster();         // heep [Monster]

            foreach (Monster monster in monsters)
            {
                // monster = new Monster  엘리먼트 자체는 수정불가 
                monster.hp = 10; // 엘리먼트의 내부 필드는 수정 가능
            }

            for (int i = 0; i < 6; i++)
            {
                array[i] = i;
            }
        }
    }
}
