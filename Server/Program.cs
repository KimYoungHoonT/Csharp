using System.Net;
using System.Net.Sockets;
using System.Text;
/*
※ 패킷의 구조
[2byte] 패킷 헤더 = 패킷 바디의 길이
[*byte] ~ 이하 패킷 바디 ~

※ 패킷 바디의 구조
[1byte] 데이터의 종류 (ex. 0 = 에코 메시지, 1 = 로그인 데이터, 255 = 오류 메시지)
[1byte] 세부작업에 대한 명령데이터 0b11111111
[2byte] 데이터A의 길이
[*byte] ~ 데이터A ~
[2byte] 데이터B의 길이
[*byte] ~ 데이터B ~
[2byte] 데이터C의 길이
[*byte] ~ 데이터C ~
~ 이하 데이터가 끝날때까지 반복 ~
*/
namespace ChunsikServer {
    internal class Program {
        // 선언부
        static public int threadCount = 0; // 생성한 쓰레드의 수
        static public bool[] threadController = new bool[10]; // 컨트롤러
        static bool programController = true; // 프로그램 전체 컨트롤을 위한 변수

        // 쓰레드를 관리하는 객체를 생성함
        static ThreadHandler threadHandler = new ThreadHandler();

        // 클라이언트의 접속을 감시하는 객체 생성
        static public TcpListener listener = new TcpListener(IPAddress.Any, 33377);

        static void Main(string[] args) {
            Console.WriteLine("※ 프로그램 이름 : ChunsikServer / 프레임워크 : .net 9.0 / 최대 접속가능한 클라이언트 수 : 9");
            Console.WriteLine("※ 명령어 : q = 프로그램 종료, 1~9 = 해당 클라이언트와 연결끊기");

            // 시스템을 관리하는 시스템 쓰레드 생성
            threadHandler.SystemThread();

            // 메인 메서드는 각 쓰레드들을 종료하는 컨트롤만 한다.
            while (programController) {
                ConsoleKeyInfo inputKey = Console.ReadKey(true); // 메인 쓰레드의 블로킹 포인트
                switch (inputKey.Key) {
                    case ConsoleKey.D1: {
                        threadController[1] = false;
                        break;
                    }
                    case ConsoleKey.D2: {
                        threadController[2] = false;
                        break;
                    }
                    case ConsoleKey.D3: {
                        threadController[3] = false;
                        break;
                    }
                    case ConsoleKey.D4: {
                        threadController[4] = false;
                        break;
                    }
                    case ConsoleKey.D5: {
                        threadController[5] = false;
                        break;
                    }
                    case ConsoleKey.D6: {
                        threadController[6] = false;
                        break;
                    }
                    case ConsoleKey.D7: {
                        threadController[7] = false;
                        break;
                    }
                    case ConsoleKey.D8: {
                        threadController[8] = false;
                        break;
                    }
                    case ConsoleKey.D9: {
                        threadController[9] = false;
                        break;
                    }
                }
                // 프로그램의 '안전한' 종료 루틴
                if (inputKey.Key == ConsoleKey.Q) {
                    Array.Fill(threadController, false); // 모든 쓰레드에게 작업을 중지하라는 신호
                    listener.Stop(); // 시스템 쓰레드의 블로킹을 해제함
                    programController = false; // Main 루프도 종료
                }
            }
        }
    }

    // 쓰레드를 관리하는 클래스
    class ThreadHandler {
        // 다른 클래스들에게 보낼 데이터 선언
        byte dataIndex;
        byte workStatus;
        byte[]? data1, data2, data3, data4, data5, data6, data7, data8, data9;

        // 시스템 쓰레드를 생성하는 메서드
        public void SystemThread() {
            Thread systemThread = new Thread(MakeThread);
            systemThread.Name = $"Chunsik-{Program.threadCount.ToString()}";
            Console.WriteLine($"Sys) 시스템 쓰레드를 생성했습니다! [{systemThread.Name}]");
            Program.threadCount++; // 시스템 쓰레드는 '춘식-0'이다.
            Program.threadController[0] = true; // 시스템 쓰레드에 대한 컨트롤러
            systemThread.Start();
        }
        // 시스템 쓰레드가 쓰레드를 생성하는 메서드
        public void MakeThread() {
            // 클라이언트의 접속을 감시 시작
            Console.WriteLine("Sys) 서버가 시작되었습니다.");
            Program.listener.Start();

            try {
                while (Program.threadController[0]) {
                    // 클라이언트 접속을 확인할때까지 대기
                    Console.WriteLine("Sys) 클라이언트의 접속을 기다리는중");
                    TcpClient client = Program.listener.AcceptTcpClient(); // 시스템 쓰레드의 블로킹 포인트

                    Console.WriteLine("Sys) 새로운 클라이언트가 접속했습니다!");

                    // 클라이언트의 정보를 확인하기 위한 작업
                    // IPEndPoint는 아이피주소를 담는 타입
                    // .Client.RemoteEndPoint로 TcpClient객체의 아이피주소를 받아옴
                    IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine($"Sys) 클라이언트 아이피 주소 : {clientEndPoint?.Address} : {clientEndPoint?.Port}");

                    // 이 쓰레드는 방금 들어온 클라이언트를 전담한다.
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Name = $"Chunsik-{Program.threadCount.ToString()}";
                    Console.WriteLine($"Sys) 클라이언트 전담 쓰레드 생성! [{clientThread.Name}]");

                    // 쓰레드 컨트롤 버튼 활성화
                    // 클라이언트 카운트 추가
                    // 쓰레드 일 시작
                    Program.threadController[Program.threadCount] = true;
                    Program.threadCount++;
                    clientThread.Start();
                }
            }
            catch (SocketException) { } // listener.Stop()으로 생기는 오류
            finally {
                Console.WriteLine("Sys) 시스템 쓰레드를 종료합니다.");
            }
        }

        void HandleClient(TcpClient client) {
            // 선언부
            // mainBuffer = 데이터를 모을 저장소
            // subBuffer = 실제 받을 데이터의 임시저장소
            // byteLength = 받을 데이터의 길이
            // stream = 클라이언트와의 데이터 교신 통로(?)
            List<byte> mainBuffer = new List<byte>();
            byte[] subBuffer = new byte[1024];
            int bytesLength;
            NetworkStream stream = client.GetStream();

            // threadIndex = 쓰레드의 번호
            string[] tmpArr = Thread.CurrentThread.Name.Split('-');
            int threadIndex = int.Parse(tmpArr[1]);

            LaborInspector laborInspector = new LaborInspector();

            try {
                // 각 클라이언트 쓰레드들의 블로킹 포인트, 반복문의 조건은 데이터를 받거나, 쓰레드를 끄거나
                while ((bytesLength = stream.Read(subBuffer, 0, subBuffer.Length)) > 0 && Program.threadController[threadIndex]) {
                    // 데이터를 받으면 일단 메인버퍼에 전부 때려박음
                    for (int i = 0; i < bytesLength; i++) mainBuffer.Add(subBuffer[i]);

                    // 한방에 큰 데이터가 들어올 수 있으니 반복처리
                    while (true) {
                        // 메인버퍼가 헤더(2바이트)보다 작으면 반복 종료
                        if (mainBuffer.Count < 2) break;

                        // 패킷 헤더 읽음
                        byte[] packetHeader = mainBuffer.GetRange(0, 2).ToArray();
                        ushort packetLength = BitConverter.ToUInt16(packetHeader, 0);

                        // 메인버퍼가 헤더+패킷길이 보다 작으면 반복 종료
                        if (mainBuffer.Count < 2 + packetLength) break;

                        // 패킷 바디 읽음
                        byte[] packetBody = mainBuffer.GetRange(2, packetLength).ToArray();

                        // 읽은 패킷을 메인버퍼에서 삭제
                        mainBuffer.RemoveRange(0, 2 + packetLength);

                        // 데이터 분석
                        ProcessData(packetBody);

                        // 작업 시작
                        laborInspector.SuperviseWork(stream, dataIndex, workStatus, data1, data2, data3, data4, data5, data6, data7, data8, data9);
                    }
                }
            }
            catch (IOException) {
                Console.WriteLine($"{Thread.CurrentThread?.Name}) 클라이언트와의 접속이 끊겼습니다.");
            }
            finally {
                stream.Close();
                client.Close();
                Console.WriteLine($"{Thread.CurrentThread?.Name}) 쓰레드를 종료합니다.");
            }
        }

        void ProcessData(byte[] data) {
            // 다른 클래스들에게 보낼 데이터 초기화
            data1 = data2 = data3 = data4 = data5 = data6 = data7 = data8 = data9 = null;

            // 데이터 인덱스, 워크플랜 분류
            dataIndex = data[0];
            workStatus = data[1];

            // 데이터 카운트
            int dataCount = 1;

            // 데이터를 전부 쪼갤때까지 반복처리
            for (int i = 2; i < data.Length;) {
                // 데이터 헤더 읽음
                byte[] dataHeader = new byte[2];
                Array.Copy(data, i, dataHeader, 0, 2);
                ushort dataLength = BitConverter.ToUInt16(dataHeader, 0);

                // 데이터를 집어넣음
                switch (dataCount) {
                    case 1: {
                        data1 = new byte[dataLength];
                        Array.Copy(data, i + 2, data1, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 2: {
                        data2 = new byte[dataLength];
                        Array.Copy(data, i + 2, data2, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 3: {
                        data3 = new byte[dataLength];
                        Array.Copy(data, i + 2, data3, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 4: {
                        data4 = new byte[dataLength];
                        Array.Copy(data, i + 2, data4, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 5: {
                        data5 = new byte[dataLength];
                        Array.Copy(data, i + 2, data5, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 6: {
                        data6 = new byte[dataLength];
                        Array.Copy(data, i + 2, data6, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 7: {
                        data7 = new byte[dataLength];
                        Array.Copy(data, i + 2, data7, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 8: {
                        data8 = new byte[dataLength];
                        Array.Copy(data, i + 2, data8, 0, dataLength);
                        dataCount++;
                        break;
                    }
                    case 9: {
                        data9 = new byte[dataLength];
                        Array.Copy(data, i + 2, data9, 0, dataLength);
                        dataCount++;
                        break;
                    }
                }

                // 9개 이상의 데이터는 그냥 날림
                if (dataCount == 10) break;

                // 데이터 헤더 + 데이터 바디 길이만큼 i 증가..
                i += 2 + dataLength;
            }
        }
    }
    class LaborInspector {
        public void SuperviseWork(NetworkStream stream, byte dataIndex, byte workStatus, byte[] data1, byte[] data2,
            byte[] data3, byte[] data4, byte[] data5, byte[] data6, byte[] data7, byte[] data8, byte[] data9) {

            switch (dataIndex) {
                case 0: // dataIndex 0 번은 테스트를 위한 에코메시지
                    NetworkTestEcho(stream, data1);
                    break;
                case 1: // 1번 LoginService
                    LoginService ls = new LoginService();
                    ls.LoginFlow(stream, workStatus, data1, data2, data3);
                    break;
                case 2: // 2번 BattleService 예정
                    SendErrorMessage(stream);
                    break;
                case 3: // 3번 SaveService 예정
                    SendErrorMessage(stream);
                    break;
                default: // 정의되지 않은 모든 요청에 대해 에러 메시지 전송
                    SendErrorMessage(stream);
                    break;
            }
        }

        private void SendErrorMessage(NetworkStream stream) {
            // 에러 메시지를 보낼 패킷 제작
            PacketMaker pm = new PacketMaker();
            byte[] packet = pm.MakeMessagePacket(255, 255, "[Err] 데이터 인덱스 오류!");

            // 메시지 발송
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine($"{Thread.CurrentThread.Name}) -> [Err] 데이터 인덱스 오류! (발신)");
        }
        private void NetworkTestEcho(NetworkStream stream, byte[] data1) {
            // 에코 메시지 수신
            string message = Encoding.UTF8.GetString(data1);
            Console.WriteLine($"{Thread.CurrentThread.Name}) <- [Echo] {message} (수신)");

            // 에코 메시지 패킷 제작
            PacketMaker pm = new PacketMaker();
            byte[] packet = pm.MakeMessagePacket(0, 0, message);

            // 메시지 발송
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine($"{Thread.CurrentThread.Name}) -> [Echo] {message} (발신)");
        }
    }
}