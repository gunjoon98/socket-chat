# socket-chat
WinForm 기반의 채팅 프로그램입니다. 채팅방은 하나만 지원합니다.   
서버는 비동기 소켓 함수로 멀티 쓰레드 서버와 같은 동작을 하도록 구현합니다.

## Usage

#### 서버 실행 방법
Server 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
ServAddress 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정합니다.   
빌드를 하고 Server 실행파일을 실행합니다.

#### 클라이언트 실행 방법
Client 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
ServAddres 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정합니다.   
빌드를 하고 Client 실행파일을 실행합니다.   

#### 빠른 실행 방법
1.socket-chat/Server/bin/Debug/Server.exe 실행   
2.socket-chat/Client/bin/Debug/Client.exe 실행   
loop back 주소로 설정되어 있으며 같은 컴퓨터에서 서버와 클라이언트 실행이 가능합니다.

## Usage Example
<img width="300" height="600" src="https://user-images.githubusercontent.com/48176143/171321302-00508313-8f10-43be-9268-3e5bd0bd42a5.PNG">
<img width="300" height="450" src="https://user-images.githubusercontent.com/48176143/171321651-11b0ee13-f1fc-4fdb-a932-9a6a748df6e4.png">
<img width="700" height="450" src="https://user-images.githubusercontent.com/48176143/171321779-c471212a-370c-45af-9843-c83708652ba4.png">
<img width="400" height="400" src="https://user-images.githubusercontent.com/48176143/171321997-f3506ddb-084b-4df4-acef-1e9cb2de7f78.png">
<img width="400" height="400" src="https://user-images.githubusercontent.com/48176143/171322161-9f3bf948-6b72-4fd9-aac0-3005e63bc590.PNG">

## Async Socket
<img width="750" height="600" src="https://user-images.githubusercontent.com/48176143/171337748-62623b69-91d3-48da-863d-7cf1a300f3f7.PNG">

연결 요청 시 sub-thread에서 연결 요청을 처리하고 다른 연결 요청을 처리하기 위한 BeginAccept 함수를 호출합니다.   
소켓 데이터 수신 시 sub-thread에서 수신 작업을 처리하고 수신을 계속하기 위해 BeginRecive 함수를 호출합니다.   
따라서 sub-thread에서 반복적으로 sub-thread를 생성시켜 연결 요청과 수신 작업을 수행하도록 합니다.
test
