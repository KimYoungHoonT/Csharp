//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _20250806
//{

//    internal class _24일차
//    {
//        // 9, 32, 5, 8, 2, 0, 75
//        // n = 6
//        // i=0 → (6-1)=5번 비교
//        // i=1 → (6-2)=4번 비교
//        // i=2 → (6-3)=3번 비교
//        // i=3 → (6-4)=2번 비교
//        // i=4 → (6-5)=1번 비교
//        // 총합: 5 + 4 + 3 + 2 + 1 = 15회

//        // n(n-1) / 2 
//        // n²/2 - n/2
//        // O(n²)

//        // 최소값을 찾아서 맨앞으로 보내기
//        static List<int> SelectionSort(List<int> numbers)
//        {
//            for (int i = 0; i < numbers.Count - 1; i++)
//            {
//                int minIndex = i; // 시작시 0번째 위치를 최소값으로 가정
//                // [   ][   ][   ][   ][   ] 
//                for (int j = i + 1; j < numbers.Count; j++)
//                {
//                    // [ 최소값   ][ i  ][   ][   ][   ] 
//                    //               ^m              ^j            
//                    if (numbers[minIndex] >= numbers[j])
//                        minIndex = j; // 더 작은 값을 발견하면 위치를 갱신합니다.
//                }

//                // i번째 값과 최솟값의 위치를 바꿉니다.
//                int temp = numbers[i];
//                numbers[i] = numbers[minIndex];
//                numbers[minIndex] = temp;
//            }
//            return numbers;
//        }





//        // [10, 14, 13,                     29,            37]
//        static List<int> BubbleSort(List<int> numbers)
//        {
//            for (int i = 0; i < numbers.Count - 1; i++)
//            {
//                for (int j = 1; j < numbers.Count - 1 - 1; j++)
//                {
//                    if (numbers[1] > numbers[1 + 1])
//                    {
//                        // 두 값을 교환
//                        int temp = numbers[j];
//                        numbers[j] = numbers[j + 1];
//                        numbers[j + 1] = temp;
//                    }
//                }
//            }
//            return numbers;
//        }

//        // (n-1) + (n-2) + … + 1 = n(n-1)/2
//        // O(n²)
//        // 자기 옆과 비교해서 점점 최대값 뒤로보내기

//        // 선택 정렬: 교환은 적지만 비교가 많음.
//        // 버블 정렬: 비교와 교환이 동시에 많이 발생.
//        // 평균 시간 복잡도 : O(n²)
//        // 실무에서는 안씀, 학습용 알고리즘

//        static void Main()
//        {
//            List<int> numbers = new List<int> { 9, 32, 5, 8, 2, 0, 75 };
//            SelectionSort(numbers);
//        }
//    }
//}


// 카운팅스타 (counting str) -> 문자열
//class Program
//{
//    static void Main()
//    {
//        int[] count = new int[26];

//        string str = Console.ReadLine();
//        foreach (int a in str)
//        {
//            count[a - 'a']++;
//        }

//        foreach (int a in count)
//            Console.Write($"{a} ");
//    }
//}


// 카운팅배열 (counting arr) -> 배열
//class Program
//{
//    static void Main(string[] args)
//    {
//        int A, B, C, start, end;
//        int ret = 0;
//        int[] count = new int[101];

//        string[] input = Console.ReadLine().Split();
//        A = int.Parse(input[0]);
//        B = int.Parse(input[1]);
//        C = int.Parse(input[2]);

//        for (int i = 0; i < 3; i++)
//        {
//            input = Console.ReadLine().Split();
//            start = int.Parse(input[0]);
//            end = int.Parse(input[1]);

//            for (int j = start; j < end; j++)
//            {
//                count[j]++;
//            }
//            // [0][1][2][3][4][5][6][7][8]...[99][100]
//            //     +  +  +  +  +
//            //           +  +
//            //        +  +  +  +  +  +
//            //  0  1  2  3  3  2  1  1
//        }

//        for (int j = 1; j <= 100; j++)
//        {
//            if (count[j] > 0)
//            {
//                if (count[j] == 1)
//                    ret += A;
//                else if (count[j] == 2)
//                    ret += B * 2;
//                else if (count[j] == 3)
//                    ret += C * 3;
//            }
//            // [1][2][3][4][5][6][7][8] ... [97][98][99]
//            //  +  +  +  +  +  
//            //        +  +  
//            //     +  +  +  +  +  +  
//            //  5  6  3  3  6  5  5
//            //   11    6     11   5
//            //      17          16
//            //            33     
//        }

//        Console.WriteLine(ret);
//    }
//} 