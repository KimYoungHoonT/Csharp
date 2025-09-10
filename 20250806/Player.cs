
using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static Board;

class Pos
{
    public Pos(int y, int x) { Y = y; X = x; }

    public int Y;
    public int X;
}

public class Player : MonoBehaviour
{
    public int PosY { get; set; }
    public int PosX { get; set; }

    private Board _board;
    private bool _isBoardCreated = false;

    enum Dir
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3,
    }

    int _dir = (int)Dir.Up; // 0

    List<Pos> _points = new List<Pos>();

    public void Initialze(int posY, int posX, Board board)
    {
        PosY = posY;
        PosX = posX;
        _board = board;

        transform.position = new Vector3(posX, 0, -posY);

        _points.Clear();
        _lastIndex = 0;

        AStar();

        _isBoardCreated = true;
    }

    // 스트럭트로 만든 이유
    // 1. 값형식 이라 힙 할당 / GC 부담이 없음
    // class는 참조 형식이라 new 할때마다 힙(heap) 에 객체가 생기고, GC가 관리해야 함
    // struct는 값 형식이라 스택(stack) 이나 배열 내부에 바로 저장 됨
    // 즉, 우선순위 큐에서 엄청 많은 노드를 Push/Pop 할때 GC Alloc 이 줄고 성능이 좋아질 수 있음.

    // 2. 크기가 작은 데이터 묶음이기 때문에 struct 가 적절
    // PQNode가 담고 있는 필드가 몇개 안될거고
    // struct 가 딱 그런 변수들의 묶음 덩어리용으로 쓰임
    // .net의 디자인 가이드에도 구조체가 16바이 이내라면 클래스(객체)보다 성능상 유리하나 나와있음.

    struct PQNode : IComparable<PQNode>
    {
        public int F;
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode other)
        {
            if (F == other.F)
                return 0;

            return F < other.F ? 1 : -1;
        }
    }

    void AStar()
    {
        int[] dY = new int[] { -1, 0, 1, 0 };
        int[] dX = new int[] { 0, -1, 0, 1 };
        int[] cost = new int[] { 1, 1, 1, 1 };

        // 점수 매기기
        // F = G + H
        // F = 최종점수 (작을 수록 좋음, 경로에 따라 달라짐)
        // G = 시작점에서 해당 좌표까지 이동하는데 드는 비용(작을 수록 좋음, 경로에 따라 달라짐)
        // H = 목적지에서 얼마나 가까운지 (작을수록 좋음, 고정)
        // [][][][][][][]
        // S       []  []
        // [][][]  []  []
        //              G
        // [][][][][][][]

        //[ ][ ][ ][ ][ ]
        //[ ][ ] * [ ][ ]
        //[ ] *  P  * [ ]
        //[ ][ ] * [ ][ ]
        //[ ][ ][ ][ ][ ]

        // (y, x) 이미 방문했는지 여부 ( 방문 = closed 상태)
        bool[,] closed = new bool[_board.Size, _board.Size]; // CloseList
        // (y, x) 가는 길을 한번 이라도 발견 했는지
        // 발견 X => MaxValue
        // 발견 O => F = G + H
        int[,] open = new int[_board.Size, _board.Size]; // OpenList
        for (int y = 0; y < _board.Size; y++)
        {
            for (int x = 0; x < _board.Size; x++)
            {
                open[y, x] = Int32.MaxValue;
            }
        }

        Pos[,] parent = new Pos[_board.Size, _board.Size];

        // 오픈리스트에 있는 정보들 중에서, 가장 좋은 후보를 빠르게 뽑아오기 위한 우선순위 큐
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

        // 시작점 발견 (예약 진행)
        open[PosY, PosX] = /*G = 0*/ /*H =*/ Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
        pq.Push(new PQNode()
        {
            F = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX),
            G = 0,
            Y = PosY,
            X = PosX
        });
        parent[PosY, PosX] = new Pos(PosY, PosX);

        while (pq.Count > 0)
        {
            // 제일 좋은 후보 찾기
            PQNode node = pq.Pop();

            // 동일한 좌표를 여러 결로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed) 된 경우 스킵

            // 우리가 만든 PriorityQueue는 DecreaseKey 가 없는 단순 Push/Pop 임
            // 같은 큐에 같은 키가 들어왔을때 최적키만 남기고 더 나쁜 키는 버리는 기능이 없음
            // 중복 되는 키가 생길수도 있고 그걸 방지하기 위한 코드
            if (closed[node.Y, node.X])
                continue;

            // 방문 한다
            closed[node.Y, node.X] = true;
            // 목적지에 도착하면 바로 종료
            if (node.Y == _board.DestY && node.X == _board.DestX)
                break;

            // 상하좌우 등 이동할 수 있는 좌표인지 확인해서 예약(open) 한다.
            for (int i = 0; i < 4; i++)
            {
                int nextY = node.Y + dY[i];
                int nextX = node.X + dX[i];

                // 유효범위 벗어나면 스킵
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                // 벽으로 막혀있으면 스킵(연결 끊기면 스킵)
                if (_board.Tile[nextY, nextX] == TileType.Wall)
                    continue;

                // 이미 방문했으면 스킵
                if (closed[nextY, nextX] == true)
                    continue;

                // 비용 계산
                int g = node.G + cost[i];
                int h = Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX);

                // 다른 경록에서 다 빠른 길 이미 찾았으면 스킵
                if (open[nextY, nextX] < g + h)
                    continue;

                // 예약 진행
                open[nextY, nextX] = g + h;
                // 큐에 삽입
                pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });
                parent[nextY, nextX] = new Pos(node.Y, node.X);
            }
        }

        CalcPathFromParent(parent);
    }

    void BFS()
    {
        int[] deltaY = new int[] { -1, 0, 1, 0 };
        int[] deltaX = new int[] { 0, -1, 0, 1 };

        bool[,] found = new bool[_board.Size, _board.Size];
        Pos[,] parent = new Pos[_board.Size, _board.Size];

        Queue<Pos> queue = new Queue<Pos>();
        queue.Enqueue(new Pos(PosY, PosX));
        found[PosY, PosX] = true;
        parent[PosY, PosX] = new Pos(PosY, PosX);

        while (queue.Count > 0)
        {
            Pos pos = queue.Dequeue();
            int nowY = pos.Y;
            int nowX = pos.X;

            for (int i = 0; i < 4; i++)
            {
                int nextY = nowY + deltaY[i];
                int nextX = nowX + deltaX[i];

                // 범위를 초과하지 않게 막기
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                    continue;

                // 체크 하려는 점이 갈수 있는 점인지
                if (_board.Tile[nextY, nextX] == TileType.Wall)
                    continue;

                // 이미 찾은점인지 확인
                if (found[nextY, nextX] == true)
                    continue;

                queue.Enqueue(new Pos(nextY, nextX));
                found[nextY, nextX] = true;
                parent[nextY, nextX] = new Pos(nowY, nowX);
            }
        }

        CalcPathFromParent(parent);
    }

    void CalcPathFromParent(Pos[,] parent)
    {
        int y = _board.DestY;
        int x = _board.DestX;

        while (parent[y, x].Y != y || parent[y, x].X != x)
        {
            // [0] => 목적지
            // [1] => 목적지 부모
            // ...
            // [마지막인덱스] => 최초 지점
            _points.Add(new Pos(y, x));

            Pos pos = parent[y, x];
            y = pos.Y;
            x = pos.X;
        }

        _points.Add(new Pos(y, x)); // 최초지점 수동 추가
        // [0] => 최초 지점
        // [1] => 최초 지점 다음
        // ...
        // [마지막인덱스] => 목적지
        _points.Reverse();
    }


    void RightHand()
    {
        int[] _frontY = new int[] { -1, 0, 1, 0 };
        int[] _frontX = new int[] { 0, -1, 0, 1 };

        int[] _rightY = new int[] { 0, -1, 0, 1 };
        int[] _rightX = new int[] { 1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        while (PosY != _board.DestY || PosX != _board.DestX)
        {

            if (_board.Tile[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
            {
                _dir = (_dir - 1 + 4) % 4;

                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            else if (_board.Tile[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
            {
                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            else
            {
                _dir = (_dir + 1 + 4) % 4;
            }
        }
    }

    private const float MOVE_TICK = 0.1f;
    private float _sumTick = 0;
    private int _lastIndex = 0;

    private void Update()
    {
        if (_lastIndex >= _points.Count)
            return;

        if (_isBoardCreated == false)
            return;

        _sumTick += Time.deltaTime;
        if (_sumTick < MOVE_TICK)
            return;

        _sumTick = 0;

        PosY = _points[_lastIndex].Y;
        PosX = _points[_lastIndex].X;
        _lastIndex++;

        transform.position = new Vector3(PosX, 0, -PosY);
    }

}
