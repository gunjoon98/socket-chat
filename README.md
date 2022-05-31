# socket-chat
WinForm 기반의 채팅 프로그램입니다. 채팅방은 하나만 지원합니다.   
서버는 비동기 소켓 함수로 멀티 쓰레드 서버와 같은 동작을 하도록 구현했습니다.

## Usage

#### 서버 실행 방법
Server 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
ServAddress 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정해줍니다.   
빌드를 하고 Server 실행파일을 실행합니다.

#### 클라이언트 실행 방법
Client 프로젝트의 ServAddress.cs 파일을 열어줍니다.   
ServAddres 클래스의 멤버변수 ip를 서버 컴퓨터의 ip주소로 설정해줍니다.   
같은 컴퓨터에서 서버와 클라이언트 실행이 가능합니다.   
빌드를 하고 Client 실행파일을 실행합니다.
