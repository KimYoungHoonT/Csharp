//class Util
//{
//    public static List<int> GetRandomNumbers(int n)
//    {
//        var rand = Random.Shared; 
//        var set = new HashSet<int>();

//        while (set.Count < n)
//        {
//            set.Add(rand.Next(0, n));
//        }

//        return set.ToList();
//    }
//}

//class Program
//{
//    static List<int> SelectionSort(List<int> numbers)
//    {
//        for (int i = 0; i < numbers.Count - 1; i++)
//        {
//            int minIndex = i;
//            for (int j = i + 1; j < numbers.Count; j++)
//            {
//                if (numbers[minIndex] >= numbers[j])
//                    minIndex = j;
//            }
            
//            int temp = numbers[i];
//            numbers[i] = numbers[minIndex];
//            numbers[minIndex] = temp;

//        }
//        return numbers;
//    }


//    static void Main()
//    {
        

//        List<int> sorted = SelectionSort(Util.GetRandomNumbers(10));

//        foreach (int item in sorted)
//            Console.WriteLine(item);
//    }
//}