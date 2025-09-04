//// 오늘의 강의 순서
//// 2. 딕셔너리, 해시셋 에 대하여
//// 3. 딕셔너리와 해시셋이 사용하는 헤시테이블 기능이란?
///
//SortedDictionary => 이진트리
//SortedSet => 이진트리

//using System.Numerics;

//class Monster
//{
//    public int id;
//    public Monster(int id)
//    {
//        this.id = id;
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {
//        List<Monster> monsters  = new List<Monster>();
//        monsters.Add(new Monster(2));
//        monsters.Add(new Monster(2));
//        monsters.Add(new Monster(7));
//        monsters.Add(new Monster(4));
//        monsters.Add(new Monster(23123));

//        Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
//        dic.Add(23123, new Monster(23123));
//        dic.Add(23123, new Monster(23123));
//        dic.Add(23123, new Monster(23123));
//        dic.Add(23123, new Monster(23123));
//        dic.Add(23123, new Monster(23123));

//        HashSet<Monster> list = new HashSet<Monster>(); // 중복되는 데이터는 넣을수 없다
//        list.Add(new Monster(1)); // -> 벨류가 즉 키 값


//        // 해시테이블 => 실제로 자료형 있었음
//        // 1. 키값입력(헤시셋의 경우 값이 곧 키) 
//        // 2. 키값을 GetHashCode() 함수로 해시화 (숫자화) 
//        // 3. 버킷이 모자르면 생성하는데 로드팩터 0.7을 유지하며, 그 값이 2의 거듭제곱보다 작다면 2의 거듭제곱 값으로 만들어줌
//        //                             (만약 요소가 60개가 있다면 => 86개가 로드팩터이나 2의 거듭제곱중 86보다 큰 128로 만들어짐)
//                                             60(요소) / 0.7(로드팩터) => 85.71428571428571(필요버킷수)
//        // 4. 2.에서 만들어놓은 숫자화 값을 버킷의 개수로 나머지 연산함
//        // 5. 나머지연산한 값이 버킷의 인덱스 번호임

//        // *: 컬리전이 생기면 같은 버킷에 여러개의 요소가 연결된 형태로 들어가게됨

//        //            딕셔너리                                    |   해시셋 
//        // 저장요소 | Key, Value                                  |   Value
//        // 내부구조 | Entry { hashCode, Next, Key, Value }        | Entry { hashCode, Next, Value }
//        // 값 접근  | dict[key] -> Value 반환                     | set.Contains(Value=>Key) 만 가능
//        // 사용 목적| 키로 값 빠르게 조회                          | 중복없는 리스트, 특정 원소 존재 여부
//        // 단점     | 현재는 저장한 순으로 정렬되나 언제 바뀔지 모름 | 정렬 안됨


//  어떠한 특정 수를 받아서, 0~ 그 수까지
//  랜덤하게 그 수만큼의 배열에 각각 넣어주세요.
// 어떤 특정한 수 : n
// 랜덤으로 0 ~ n 까지를 생성하는데
// 배열도 n의 크기로 만들어서 저장되게 해주세요.


//    struct Entry
//    {
//        public int hashCode;  // 키의 해시코드
//        public int next;      // 같은 버킷 안에서 "다음 엔트리"가 있는 배열 인덱스
//        public TKey key;
//        public TValue value;
//    }

//    private struct Entry
//    {
//        internal int hashCode;    // 요소의 해시
//        internal int next;        // 충돌 체인의 다음 인덱스
//        internal T value;         // 저장된 값
//    }
//}