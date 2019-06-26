基于P2P的局域网即时通信系统
=

### 已知技术参数和设计要求
1．掌握P2P原理。\
2．实现一个图形用户界面局域网内的消息系统。\
3．功能：建立一个局域网内的简单的P2P消息系统，程序既是服务器又是客户，服务器端口（自拟服务器端口号并选定）。\
  3.1用户注册及对等方列表的获取：对等方A启动后，用户设置自己的信息（用户名，所在组）；扫描网段中在线的对等方（服务器端口打开），向所有在线对等方的服务端   口发送消息，接收方接收到消息后，把对等方A加入到自己的用户列表中，并发应答消息；对等方A把回应消息的其它对等方加入用户列表。双方交换的消息格式自己根据需   要定义，至少包括用户名、IP地址。\
  3.2发送消息和文件：用户在列表中选择用户，与用户建立TCP连接，发送文件或消息。\
4．用户界面：界面上包括对等方列表；消息显示列表；消息输入框；文件传输进程显示及操作按钮或菜单。\

