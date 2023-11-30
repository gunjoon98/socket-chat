# 개요
간단한 채팅 프로그램입니다.
로그인 후 채팅방에 접속해 다른 사용자와 채팅, 파일 업로드, 다운로드를 할 수 있습니다.

## Usage

#### 서버 실행 방법
- Server 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
- ServAddress 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정합니다.   
- 빌드를 하고 Server 실행파일을 실행합니다.

#### 클라이언트 실행 방법
- Client 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
- ServAddres 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정합니다.   
- 빌드를 하고 Client 실행파일을 실행합니다.   

#### 빠른 실행 방법
1. socket-chat/Server/bin/Debug/Server.exe 실행   
2. socket-chat/Client/bin/Debug/Client.exe 실행   
3. loop back 주소로 설정되어 있으며 같은 컴퓨터에서 서버와 클라이언트 실행이 가능합니다.

## Usage Example
<img width="300" height="600" src="https://user-images.githubusercontent.com/48176143/171321302-00508313-8f10-43be-9268-3e5bd0bd42a5.PNG">
<img width="300" height="450" src="https://user-images.githubusercontent.com/48176143/171321651-11b0ee13-f1fc-4fdb-a932-9a6a748df6e4.png">
<img width="700" height="450" src="https://user-images.githubusercontent.com/48176143/171321779-c471212a-370c-45af-9843-c83708652ba4.png">
<img width="400" height="400" src="https://user-images.githubusercontent.com/48176143/171321997-f3506ddb-084b-4df4-acef-1e9cb2de7f78.png">
<img width="400" height="400" src="https://user-images.githubusercontent.com/48176143/171322161-9f3bf948-6b72-4fd9-aac0-3005e63bc590.PNG">

## 설명

- 서버와 클라이언트는 C#으로 구현, 멀티스레드 구조, 채팅과 파일 통신은 소켓으로 구현
- 클라이언트의 UI가 통신에 영향을 받지 않도록 UI 이벤트 스레드와 통신 스레드를 분리
- 간접적으로 스레드를 다루기 위해 소켓 비동기 함수 사용
  
## 프로토콜 설계
![Untitled](https://github.com/gunjoon98/socket-chat/assets/48176143/5e2a19c5-9941-49a8-8dd9-2c1272625ea7)

## Async Socket
- 연결 요청 시 sub-thread에서 연결 요청을 처리하고 다른 연결 요청을 처리하기 위한 BeginAccept 함수를 호출합니다.   
- 소켓 데이터 수신 시 sub-thread에서 수신 작업을 처리하고 수신을 계속하기 위해 BeginRecive 함수를 호출합니다.   
- 따라서 sub-thread에서 반복적으로 sub-thread를 생성시켜 연결 요청과 수신 작업을 수행하도록 합니다.
