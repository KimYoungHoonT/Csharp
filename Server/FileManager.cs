using System.Text.Json;

namespace ChunsikServer {
    internal class FileManager {
        /// <summary>
        /// 파일 생성경로를 설정. 생성위치는 program.cs가 있는 폴더 아래 data폴더.
        /// </summary>
        /// <param name="fileName">최종 파일명(확장자x)</param>
        /// <returns>완전한 경로</returns>
        string FindPath(string fileName) {
            string path = AppContext.BaseDirectory;
            // path = exe가 있는 경로 *\bin\Debug\net9.0\
            DirectoryInfo di = Directory.GetParent(path).Parent.Parent.Parent;
            // di = *\
            path = di.FullName;
            // path = di = *\
            path = Path.Combine(path, "data\\");
            // path = *\data\
            path = Path.Combine(path, fileName) + ".json";
            // path = *\data\fileName.json
            return path;
        }

        /// <summary>
        /// 파일 및 경로 확인. 없다면 생성.
        /// </summary>
        /// <param name="fileName">점검할 파일명(확장자x)</param>
        /// <returns>완전한 경로</returns>
        string EnsureFileExists(string fileName) {
            // 일단 경로설정
            string filePath = FindPath(fileName);
            // 폴더 경로만 추출
            string directoryPath = Path.GetDirectoryName(filePath);
            // 폴더 경로를 점검하고 없으면 생성
            Directory.CreateDirectory(directoryPath);
            // 파일 생성
            if (!File.Exists(filePath)) File.WriteAllText(filePath, string.Empty);

            return filePath;
        }

        /// <summary>
        /// fileName(확장자x)의 .json파일에서 파일을 읽어서 T형식의 List로 반환 
        /// </summary>
        /// <typeparam name="T">json에서 읽어드린 데이터 클래스 형식</typeparam>
        /// <param name="fileName">읽을 파일명(확장자x)</param>
        /// <returns>T형식의 데이터 List</returns>
        public List<T> ReadJsonData<T> (string fileName) {
            // 파일 경로 확인
            string path = EnsureFileExists(fileName);

            // json파일을 읽어옴
            string jsonString = File.ReadAllText(path);

            // 파일을 읽어올 객체 생성
            List<T> dataList = new List<T>();

            // jsonString이 null도 아니고, 비어있지도 않을 때
            if (!string.IsNullOrEmpty(jsonString)) {
                // 역직렬화, json파일을 ClientInfo로 변환해서 clientList에 넣기
                dataList = JsonSerializer.Deserialize<List<T>>(jsonString);
            }

            return dataList;
        }

        /// <summary>
        /// T형식의 List를 fileName(확장자x)이름의 .json로 저장
        /// </summary>
        /// <typeparam name="T">json에 저장할 데이터 클래스 형식</typeparam>
        /// <param name="dataList">저장할 T형식의 데이터 List</param>
        /// <param name="fileName">저장할 파일명(확장자x)</param>
        public void WriteJsonData<T> (List<T> dataList, string fileName) {
            try {
                // 파일 경로 확인
                string path = EnsureFileExists(fileName);

                // json 파일 저장을 할 때 쓸 옵션설정 (들여쓰기 적용하기)
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

                // clientList를 json형식으로 변환
                string jsonString = JsonSerializer.Serialize(dataList, options);

                // 기존의 파일을 덮어씀
                File.WriteAllText(path, jsonString);
            }
            catch (Exception ex) {
                Console.WriteLine($"{Thread.CurrentThread.Name}) Err! 저장 오류 : {ex.Message}");
            }
        }
    }

    /// <summary>
    /// [Index, Id, Password, Hint] Client의 정보를 담는 클래스
    /// </summary>
    class ClientInfo {
        // 프로퍼티를 사용한 이유는 json 파일을 만드는 과정에서
        // System.Text.Json 라이브러리의 JsonSerializer.Serialize를 사용하면
        // public 프로퍼티만 JSON으로 변환해주기 때문에 사용함
        public int Index { get; set; }
        public string? Id { get; set; }
        public string? Password { get; set; }
        public string? Hint { get; set; }

        public ClientInfo(int index, string id, string password, string hint) {
            this.Index = index;
            this.Id = id;
            this.Password = password;
            this.Hint = hint;
        }
    }
}