/*
※ 데이터 구조
[1byte] 데이터의 종류 (ex. 1 = 로그인 데이터)
[1byte] 세부작업에 대한 명령데이터
[2byte] 데이터A의 길이
[*byte] ~ 데이터A = Id ~
[2byte] 데이터B의 길이
[*byte] ~ 데이터B = Password ~
[2byte] 데이터C의 길이
[*byte] ~ 데이터C = Hint ~

workStatus
10 => / 로그인 시도
<= 17 / 비밀번호 틀림
<= 18 / 아이디 없음
<= 19 / 로그인 성공 
20 => / 아이디 찾기
<= 28 / 아이디 없음
<= 29 / 아이디 확인
30 => / 아이디 생성
<= 35 / 아이디 길이 초과
<= 36 / 비밀번호 길이 초과
<= 37 / 힌트 길이 초과
<= 38 / 아이디 중복
<= 39 / 아이디 생성 성공

<=255 / 작업속성 오류
*/

using System.Net.Sockets;

namespace ChunsikServer {
    internal class LoginService {

        public void LoginFlow(NetworkStream stream, byte workStatus, byte[] data1, byte[] data2, byte[] data3) {
            // 해당하는 작업을 호출
            switch (workStatus) {
                case 10:
                    TryLogin(stream, data1, data2);
                    break;
                case 20:
                    FindId(stream, data1);
                    break;
                case 30:
                    AddClient(stream, data1, data2, data3);
                    break;
                default:
                    SendErrMsg(stream, 255, "작업속성 오류!");
                    break;
            }
        }

        /// <summary>
        /// 로그인 시도(10) return 로그인 성공(19), 아이디 없음(18), 비밀번호 틀림(17)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        void TryLogin(NetworkStream stream, byte[] data1, byte[] data2) {
            // 선언부 및 데이터 확인
            FileManager fm = new FileManager();
            List<ClientInfo> clientList = new List<ClientInfo>();
            string inputId = System.Text.Encoding.UTF8.GetString(data1);
            string inputPassword = System.Text.Encoding.UTF8.GetString(data2);
            clientList = fm.ReadJsonData<ClientInfo>("Client");

            // clientList.FirstOrDefault는 조건에 맞는 첫번째 인자를 찾는 메서드
            // 람다식, client.Id == inputId 인 client를 찾아라
            ClientInfo foundClient = clientList.FirstOrDefault(client => client.Id == inputId);

            if (foundClient != null) {
                // 비밀번호 확인
                if (foundClient.Password == inputPassword) {
                    PacketMaker pm = new PacketMaker();
                    byte[] dataA = BitConverter.GetBytes(foundClient.Index); // 클라이언트의 인덱스만 보냄
                    byte[] packet = pm.MakeData1Packet(1, 19, dataA);
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine($"{Thread.CurrentThread.Name}) -> 로그인 성공 Client Index (발신)");
                }
                else SendErrMsg(stream, 17, "비밀번호 틀림");
            }
            else SendErrMsg(stream, 18, "아이디 없음");

        }

        /// <summary>
        /// 아이디 찾기(20) return 아이디 확인(19), 아이디 없음(18)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data1"></param>
        void FindId(NetworkStream stream, byte[] data1) {
            // 선언부 및 데이터 확인
            FileManager fm = new FileManager();
            List<ClientInfo> clientList = new List<ClientInfo>();
            string inputId = System.Text.Encoding.UTF8.GetString(data1);

            // 데이터 검사
            clientList = fm.ReadJsonData<ClientInfo>("Client");
            ClientInfo foundClient = clientList.FirstOrDefault(client => client.Id == inputId);

            // 일치하는 아이디가 있다면 힌트 보냄
            if (foundClient != null) {
                    PacketMaker pm = new PacketMaker();
                    byte[] packet = pm.MakeMessagePacket(1, 29, foundClient.Hint);
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine($"{Thread.CurrentThread.Name}) -> 아이디 확인 Client Hint (발신)");
            }
            else SendErrMsg(stream, 28, "아이디 없음");
        }

        /// <summary>
        /// 아이디 생성(30) return 아이디 생성 성공(39), 아이디 중복(38), 힌트 길이 초과(37),
        /// 비밀번호 길이 초과(36), 아이디 길이 초과(35)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="data3"></param>
        void AddClient(NetworkStream stream, byte[] data1, byte[] data2, byte[] data3) {
            // 선언부 및 데이터 확인
            FileManager fm = new FileManager();
            List<ClientInfo> clientList = new List<ClientInfo>();
            string inputId = System.Text.Encoding.UTF8.GetString(data1);
            string inputPassword = System.Text.Encoding.UTF8.GetString(data2);
            string inputHint = System.Text.Encoding.UTF8.GetString(data3);

            // 데이터 길이 체크
            if (inputId.Length > 12) SendErrMsg(stream, 35, "아이디 길이 초과");
            else if (inputPassword.Length > 12) SendErrMsg(stream, 36, "비밀번호 길이 초과");
            else if (inputHint.Length > 20) SendErrMsg(stream, 37, "힌트 길이 초과");
            
            else { // 아이디 중복 체크
                clientList = fm.ReadJsonData<ClientInfo>("Client");
                ClientInfo foundClient = clientList.FirstOrDefault(client => client.Id == inputId);

                // 아이디 생성 로직
                if (foundClient == null) {
                    PacketMaker pm = new PacketMaker();

                    // 새로 만들 아이디의 인덱스
                    int newIndex = 1; 
                    if (clientList.Count > 0) {
                        newIndex = clientList.Last().Index + 1;
                    }

                    // 새로 만들 아이디 객체 생성 > 리스트 추가 > 저장
                    ClientInfo newClient = new ClientInfo(newIndex, inputId, inputPassword, inputHint);
                    clientList.Add(newClient);
                    fm.WriteJsonData<ClientInfo>(clientList, "Client");

                    // 생성한 아이디에 대한 인덱스 발송
                    byte[] dataA = BitConverter.GetBytes(newClient.Index);
                    byte[] packet = pm.MakeData1Packet(1, 39, dataA);
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine($"{Thread.CurrentThread.Name}) -> 아이디 생성! Client Index (발신)");
                }
                else SendErrMsg(stream, 38, "아이디 중복");
            }
        }

        /// <summary>
        /// [stream, 에러코드, "내용"] 에러 메세지를 작성해 클라이언트에게 보냅니다. 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="workStatus">에러코드</param>
        /// <param name="message">"내용"</param>
        void SendErrMsg(NetworkStream stream, byte workStatus, string message) {
            PacketMaker pm = new PacketMaker();
            string errorMessage = "[Err] " + message;
            byte[] packet = pm.MakeMessagePacket(1, workStatus, errorMessage);
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine($"{Thread.CurrentThread.Name}) -> {errorMessage} (발신)");
        }
    }
}