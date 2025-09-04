
//using System.Collections.Generic;
//using System.Drawing;
//using System.Numerics;
//using UnityEngine;

//class Pos
//{
//    public Pos(int y, int x) { Y = y; X = x; }

//    public int Y;
//    public int X;
//}

//public class Player : MonoBehaviour
//{
//    public int PosY { get; set; }
//    public int PosX { get; set; }

//    private Board _board;
//    private bool _isBoardCreated = false;

//    enum Dir
//    {
//        Up = 0,
//        Left = 1,
//        Down = 2,
//        Right = 3,
//    }

//    int _dir = (int)Dir.Up; // 0

//    List<Pos> _points = new List<Pos>();

//    public void Initialze(int posY, int posX, Board board)
//    {
//        _isBoardCreated = false;

//        PosY = posY;
//        PosX = posX;
//        _board = board;

//        transform.position = new Vector3(posX, 0, -posY);
//        _points.Clear();
//        _lastIndex = 0;

//        #region 우수법
//        // 우수법 - (미로를 탈출하기 위한) 오른손 법칙
//        // 우수법 알고리즘 룰
//        // 1. 현재 바라보고 있는 방향의 오른쪽 방향으로 갈수 있는지 확인
//        //   ㄴ> 갈 수 있다면 오른쪽방향으로 회전하고 앞으로 한칸전진
//        // 2. 현재 바라보고 있는 방향으로 갈수 있는지 확인
//        //   ㄴ> 갈 수 있다면 앞으로 한칸전진
//        // 3. 만약 오른쪽으로도, 앞으로도 갈 수 없다면
//        //   ㄴ> 오른쪽 방향으로 회전

//        // 내가 바라보는 방향 기준 앞방향 타일을 확인 하기 위한 좌표
//        int[] _frontY = new int[] { -1, 0, 1, 0 };
//        int[] _frontX = new int[] { 0, -1, 0, 1 };

//        // 내가 바라보는 방향 기준 오른쪽 타일을 확인 하기위한 좌표
//        int[] _rightY = new int[] { 0, -1, 0, 1 };
//        int[] _rightX = new int[] { 1, 0, -1, 0 };

//        _points.Add(new Pos(PosY, PosX));

//        // 목적지 계산전 까지 계속실행
//        while (PosY != board.DestY || PosX != board.DestX)
//        {
//            // 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인

//            // 현재 내가 바라 보고 있는 방향기준, 오른쪽 의 타일을 확인해야하니까
//            if (board.Tile[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
//            {
//                #region 
//                // 오른쪽 방향으로 90도 회전
//                // 모듈러 연산(modular arithmetic)을 이용한 원형 인덱스(circular index) 패턴
//                // 모듈러 연산 = 나머지 연산 %을 사용해서 값의 범위를 고정하는 수학적 기법.
//                // 원형 인덱스 = 음수나 범위를 벗어난 인덱스가 나오지 않도록 끝에 도달하면 다시 처음으로 돌아가는 구조
//                #endregion

//                _dir = (_dir - 1 + 4) % 4;
//              
//                #region
//                //   [ ]
//                //[ ] P [*] 
//                //   [^]

//                //switch (_dir)
//                //{
//                //    case (int)Dir.Up:
//                //        _dir = (int)Dir.Right;
//                //        break;
//                //    case (int)Dir.Left:
//                //        _dir = (int)Dir.Up;
//                //        break;
//                //    case (int)Dir.Down:
//                //        _dir = (int)Dir.Left;
//                //        break;
//                //    case (int)Dir.Right:
//                //        _dir = (int)Dir.Down;
//                //        break;
//                //}


//                // X: 1, Y: 1
//                // 내가 바라보는 방향으로 앞으로 한보 전진
//                //   [ ]
//                //[ ] P [*] 
//                //   [ ]


//                #endregion

//                PosY = PosY + _frontY[_dir];
//                PosX = PosX + _frontX[_dir];

//                _points.Add(new Pos(PosY, PosX));
//            }
//            // 2. 현재 바라보는 방향을 기준으로 전진할 수 있는지 확인
//            else if (board.Tile[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
//            {
//                // 앞으로 한보 전진
//                PosY = PosY + _frontY[_dir];
//                PosX = PosX + _frontX[_dir];

//                _points.Add(new Pos(PosY, PosX));
//            }
//            // 3. 내 오른쪽, 내 앞 모두 벽이 있다면
//            else
//            {
//                // 왼쪽 방향으로 90도 회전 후 턴 넘기기
//                _dir = (_dir + 1 + 4) % 4;
//            }
//        }
//        #endregion


//        _isBoardCreated = true;
//    }

//    private const float MOVE_TICK = 0.1f;
//    private float _sumTick = 0;
//    private int _lastIndex = 0;

//    private void Update()
//    {
//        if (_lastIndex >= _points.Count)
//            return;

//        if (_isBoardCreated == false)
//            return;

//        _sumTick += Time.deltaTime;
//        if (_sumTick < MOVE_TICK)
//            return;

//        _sumTick = 0;

//        PosY = _points[_lastIndex].Y;
//        PosX = _points[_lastIndex].X;
//        _lastIndex++;

//        transform.position = new Vector3(PosX, 0, -PosY);
//    }

//}


//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    public SliderController _sliderController;
//    [SerializeField] private Button _createMazeButton;
//    [SerializeField] private TMP_Text _sizeText;

//    [SerializeField] private Board _board;
//    [SerializeField] private Player _player;

//    private void Start()
//    {
//        _sliderController.SliderValueChange += SetSlideValue;
//        _createMazeButton.onClick.AddListener(CreateMaze);
//    }

//    private void SetSlideValue(float val)
//    {
//        _sizeText.text = val.ToString();
//        _board.Size = (int)val;
//    }

//    private void CameraSetting()
//    {
//        Camera mainCamera = Camera.main;
//        mainCamera.transform.position = new Vector3(_board.Size / 2, _board.Size, -_board.Size / 2);
//        mainCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
//        mainCamera.clearFlags = CameraClearFlags.SolidColor;
//        mainCamera.backgroundColor = Color.black;
//    }

//    private void CreateMaze()
//    {
//        CameraSetting();

//        _board.Initialze();
//        _board.Spawn();

//        _player.Initialze(1, 1, _board);
//    }
//}


//using System;
//using UnityEngine;
//using UnityEngine.UI;

//public class SliderController : MonoBehaviour
//{
//    public Action<float> SliderValueChange;

//    private void Start()
//    {
//        Slider slider = gameObject.GetComponent<Slider>();
//        slider.onValueChanged.AddListener(SlideChange);

//        slider.wholeNumbers = true;
//        slider.minValue = 3;
//        slider.maxValue = 51;
//    }

//    void SlideChange(float value)
//    {
//        if (value % 2 == 0)
//            value++;

//        SliderValueChange.Invoke(value);
//    }
//}
