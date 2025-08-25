/*
제미나이로 만든 테스트용 클라이언트
*/
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestClient {
    internal class Program {
        private static TcpClient client;
        private static NetworkStream stream;

        static void Main(string[] args) {
            try {
                // 1. 서버에 접속
                client = new TcpClient("127.0.0.1", 33377);
                stream = client.GetStream();
                Console.WriteLine("## 서버에 성공적으로 접속했습니다!");

                // 2. 서버로부터 메시지를 수신할 별도의 스레드 시작
                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // 3. 사용자 입력을 받아 서버에 요청을 보낼 메인 루프
                bool isRunning = true;
                while (isRunning) {
                    Console.WriteLine("\n--- [ Chun-sik Server Test Client ] ---");
                    Console.WriteLine("1. 로그인 시도 (workStatus: 10)");
                    Console.WriteLine("2. 계정 생성 (workStatus: 30)");
                    Console.WriteLine("3. ID로 힌트 찾기 (workStatus: 20)");
                    Console.WriteLine("Q. 프로그램 종료");
                    Console.Write("입력: ");
                    string choice = Console.ReadLine();

                    switch (choice.ToUpper()) {
                        case "1":
                            HandleLogin();
                            break;
                        case "2":
                            HandleAddClient();
                            break;
                        case "3":
                            HandleFindId();
                            break;
                        case "Q":
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("## 잘못된 입력입니다.");
                            break;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"## 오류 발생: {ex.Message}");
            }
            finally {
                if (stream != null) stream.Close();
                if (client != null) client.Close();
                Console.WriteLine("## 서버와의 연결을 종료합니다.");
            }
        }

        // 로그인 요청 처리
        static void HandleLogin() {
            Console.Write(" > ID: ");
            string id = Console.ReadLine();
            Console.Write(" > Password: ");
            string pw = Console.ReadLine();

            byte[] idBytes = Encoding.UTF8.GetBytes(id);
            byte[] pwBytes = Encoding.UTF8.GetBytes(pw);

            byte[] packet = CreatePacket(1, 10, new List<byte[]> { idBytes, pwBytes });
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine("=> 로그인 요청을 보냈습니다.");
        }

        // 계정 생성 요청 처리
        static void HandleAddClient() {
            Console.Write(" > 생성할 ID (최대 12자): ");
            string id = Console.ReadLine();
            Console.Write(" > 생성할 Password (최대 12자): ");
            string pw = Console.ReadLine();
            Console.Write(" > 비밀번호 힌트 (최대 20자): ");
            string hint = Console.ReadLine();

            byte[] idBytes = Encoding.UTF8.GetBytes(id);
            byte[] pwBytes = Encoding.UTF8.GetBytes(pw);
            byte[] hintBytes = Encoding.UTF8.GetBytes(hint);

            byte[] packet = CreatePacket(1, 30, new List<byte[]> { idBytes, pwBytes, hintBytes });
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine("=> 계정 생성 요청을 보냈습니다.");
        }

        // ID로 힌트 찾기 요청 처리
        static void HandleFindId() {
            Console.Write(" > 힌트를 찾을 ID: ");
            string id = Console.ReadLine();
            byte[] idBytes = Encoding.UTF8.GetBytes(id);

            byte[] packet = CreatePacket(1, 20, new List<byte[]> { idBytes });
            stream.Write(packet, 0, packet.Length);
            Console.WriteLine("=> ID 힌트 찾기 요청을 보냈습니다.");
        }


        // 서버로부터 메시지를 수신하는 스레드
        static void ReceiveMessages() {
            List<byte> mainBuffer = new List<byte>();
            byte[] readBuffer = new byte[1024];
            int bytesRead;

            try {
                while ((bytesRead = stream.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                    for (int i = 0; i < bytesRead; i++)
                        mainBuffer.Add(readBuffer[i]);

                    while (true) {
                        if (mainBuffer.Count < 2) break;
                        ushort bodyLength = BitConverter.ToUInt16(mainBuffer.GetRange(0, 2).ToArray(), 0);
                        if (mainBuffer.Count < 2 + bodyLength) break;

                        byte[] packetBody = mainBuffer.GetRange(2, bodyLength).ToArray();
                        mainBuffer.RemoveRange(0, 2 + bodyLength);

                        // 받은 패킷 본문을 처리
                        ProcessPacketBody(packetBody);
                    }
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
        }

        // 수신된 패킷 본문을 해석해서 출력
        static void ProcessPacketBody(byte[] body) {
            byte dataIndex = body[0];
            byte workStatus = body[1];

            // 데이터 파싱 (메시지나 데이터가 포함된 경우)
            string message = "";
            int dataPayload = 0;

            if (body.Length > 4) // 데이터 페이로드가 있는 패킷인지 확인
            {
                ushort dataLength = BitConverter.ToUInt16(body, 2);
                if (workStatus == 19 || workStatus == 39) // 로그인/생성 성공 시 Index 데이터
                {
                    if (dataLength == 4) // int 크기 확인
                        dataPayload = BitConverter.ToInt32(body, 4);
                }
                else // 그 외에는 string 메시지로 간주
                {
                    message = Encoding.UTF8.GetString(body, 4, dataLength);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\n<= [서버 응답] ");
            Console.ResetColor();

            // workStatus에 따라 적절한 메시지 출력
            switch (workStatus) {
                // 로그인 결과
                case 17: Console.WriteLine("비밀번호가 틀렸습니다."); break;
                case 18: Console.WriteLine("존재하지 않는 ID입니다."); break;
                case 19: Console.WriteLine($"로그인 성공! (유저 고유번호: {dataPayload})"); break;
                // ID 찾기 결과
                case 28: Console.WriteLine("존재하지 않는 ID입니다."); break;
                case 29: Console.WriteLine($"ID 확인! (힌트: {message})"); break;
                // 계정 생성 결과
                case 35: Console.WriteLine("계정 생성 실패: ID가 너무 깁니다 (최대 12자)."); break;
                case 36: Console.WriteLine("계정 생성 실패: 비밀번호가 너무 깁니다 (최대 12자)."); break;
                case 37: Console.WriteLine("계정 생성 실패: 힌트가 너무 깁니다 (최대 20자)."); break;
                case 38: Console.WriteLine("계정 생성 실패: 이미 존재하는 ID입니다."); break;
                case 39: Console.WriteLine($"계정 생성 성공! (유저 고유번호: {dataPayload})"); break;
                // 공통 오류
                case 255: Console.WriteLine($"서버 오류 발생: {message}"); break;
                default: Console.WriteLine($"알 수 없는 작업 코드 수신: {workStatus}"); break;
            }
            Console.Write("입력: ");
        }

        // 서버로 보낼 최종 패킷을 조립하는 범용 메서드
        static byte[] CreatePacket(byte dataIndex, byte workStatus, List<byte[]> dataChunks) {
            // 1. 패킷 바디의 전체 크기 계산
            int bodyLength = 2; // dataIndex, workStatus
            foreach (var chunk in dataChunks) {
                bodyLength += 2; // 데이터 길이 정보 (2바이트)
                bodyLength += chunk.Length; // 실제 데이터
            }

            byte[] packetBody = new byte[bodyLength];
            packetBody[0] = dataIndex;
            packetBody[1] = workStatus;

            // 2. 바디에 데이터 차곡차곡 복사
            int offset = 2;
            foreach (var chunk in dataChunks) {
                // 데이터 길이 복사
                Array.Copy(BitConverter.GetBytes((ushort)chunk.Length), 0, packetBody, offset, 2);
                offset += 2;
                // 실제 데이터 복사
                Array.Copy(chunk, 0, packetBody, offset, chunk.Length);
                offset += chunk.Length;
            }

            // 3. 패킷 헤더(바디 길이) 생성 및 최종 패킷 조립
            byte[] packetHeader = BitConverter.GetBytes((ushort)packetBody.Length);
            byte[] finalPacket = new byte[2 + packetBody.Length];
            Array.Copy(packetHeader, 0, finalPacket, 0, 2);
            Array.Copy(packetBody, 0, finalPacket, 2, packetBody.Length);

            return finalPacket;
        }
    }
}