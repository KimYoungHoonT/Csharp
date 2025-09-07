using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Tree
{
    // 트리 - (계층적인 구조를 갖는 데이터)를 표현 하기 위한 자료 구조
    // 트리는 무조건 단방향으로 뻗음
    // 부모에 해당하는 아이는 딱 하나만 있어야 함
    // 트리는 재귀 적인 속성을 갖고 있다.
    // 트리의 연산은 재귀함수가 애용됨

    // 트리는 제공되는 자료구조가 없음 -> 직접구현

    // 그래프는 정적인 상황에서 사용
    // 트리는 데이터의 변화가 자주 일어날떄 사용한다.
    // 트리는 현실 세계에서 동적으로 변하는 데이터를 다루기위한 자료구조다

    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Program
    {
        static TreeNode<String> MakeTree()
        {
            TreeNode<String> root = new TreeNode<string>() { Data = "A" };
            {
                TreeNode<String> nodeB = new TreeNode<string>() { Data = "B" };
                {
                    TreeNode<String> nodeD = new TreeNode<string>() { Data = "D" };
                    {
                        nodeD.Children.Add(new TreeNode<string>() { Data = "H" });
                        nodeD.Children.Add(new TreeNode<string>() { Data = "I" });
                    }
                    TreeNode<String> nodeE = new TreeNode<string>() { Data = "E" };

                    nodeB.Children.Add(nodeD);
                    nodeB.Children.Add(nodeE);
                }
                TreeNode<String> nodeC = new TreeNode<string>() { Data = "C" };
                {
                    nodeC.Children.Add(new TreeNode<string>() { Data = "F" });
                    nodeC.Children.Add(new TreeNode<string>() { Data = "G" });
                }

                root.Children.Add(nodeB);
                root.Children.Add(nodeC);
            }

            return root;
        }

        // 트리 순회 - 문제
        static void Print(TreeNode<String> root)
        {
            // 현재 노드의 데이터 출력
            Console.WriteLine(root.Data);

            // 그걸 자식에게도 떠맡김
            foreach (var child in root.Children)
                Print(child);
        }

        // GetHight()
        static int GetHeight(TreeNode<string> root) // 코딩테스트 문제
        {
            int height = 0;

            // 넘겨받은 트리의 높이를 구하시오!
            foreach (var child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                //if (height < newHeight)
                //    height = newHeight;
                height = Math.Max(height, newHeight);
            }

            return height;
        }


        static void Main()
        {
            TreeNode<String> root = MakeTree();
            // Print(MakeTree());
            Console.WriteLine(GetHeight(root));
        }
    }
}
