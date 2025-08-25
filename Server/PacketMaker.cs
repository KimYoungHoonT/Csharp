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
    internal class PacketMaker {

        /// <summary>
        /// [데이터 인덱스, 작업 속성, 메세지]를 담은 패킷을 생성
        /// </summary>
        /// <param name="dataIndex">데이터 인덱스</param>
        /// <param name="workStatus">작업 속성</param>
        /// <param name="errorMessage">에러 메시지</param>
        /// <returns>패킷</returns>
        public byte[] MakeMessagePacket(byte dataIndex, byte workStatus, string message) {
            // 패킷 바디 생성
            byte[] payload = Encoding.UTF8.GetBytes(message);
            byte[] packetBody = new byte[4 + payload.Length];
            packetBody[0] = dataIndex;
            packetBody[1] = workStatus;
            byte[] packetLength = BitConverter.GetBytes((ushort)payload.Length);
            Array.Copy(packetLength, 0, packetBody, 2, 2);
            Array.Copy(payload, 0, packetBody, 4, payload.Length);

            // 패킷 헤드 생성
            byte[] packetHeader = BitConverter.GetBytes((ushort)packetBody.Length);

            // 패킷 생성
            byte[] packet = new byte[2 + packetBody.Length];
            Array.Copy(packetHeader, 0, packet, 0, packetHeader.Length);
            Array.Copy(packetBody, 0, packet, 2, packetBody.Length);

            return packet;
        }


        public byte[] MakeData1Packet(byte dataIndex, byte workStatus, byte[] data1) {
            // 패킷 바디 생성
            byte[] packetBody = new byte[4 + data1.Length];
            packetBody[0] = dataIndex;
            packetBody[1] = workStatus;
            byte[] packetLength = BitConverter.GetBytes((ushort)data1.Length);
            Array.Copy(packetLength, 0, packetBody, 2, 2);
            Array.Copy(data1, 0, packetBody, 4, data1.Length);

            // 패킷 헤드 생성
            byte[] packetHeader = BitConverter.GetBytes((ushort)packetBody.Length);

            // 패킷 생성
            byte[] packet = new byte[2 + packetBody.Length];
            Array.Copy(packetHeader, 0, packet, 0, packetHeader.Length);
            Array.Copy(packetBody, 0, packet, 2, packetBody.Length);

            return packet;
        }
    }
}