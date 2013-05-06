/* 
 * File:   main.cpp
 * Author: Thomas Wojnar
 */

#include <cstdlib>
#include <iostream>
#include <winsock2.h>
#include <Windows.h>

#pragma comment(lib, "ws2_32.lib")

using namespace std;

int main() {
    long chk;
    WSADATA wsaData;
    
    chk = WSAStartup(MAKEWORD(2, 0), &wsaData);
    if(chk == 0)
        cout << "Meow! WSAStartup() Successful" << endl;
    else
        cout << "error at WSAStartup" << WSAGetLastError() << endl;
    
    
    SOCKET listmeow;
    listmeow = socket(AF_INET, SOCK_STREAM, 0);
    if(listmeow != INVALID_SOCKET)
        cout << "Meow! socket() Successful" << endl;
    else
        cout << "error at socket " << WSAGetLastError() << endl;
    
    sockaddr_in info;
    info.sin_addr.S_un.S_addr = inet_addr("67.202.15.69");
    info.sin_family = AF_INET;
    info.sin_port = htons(45444);
    
    chk = connect(listmeow, (sockaddr*)(&info), sizeof(info));
    if(chk == 0)
        cout << "Meow! connect() Successful " << endl;
    else
        cout << "error at connect " << WSAGetLastError() << endl;
    
    
    cout << "Enter the input command, enter EXIT to end" << endl;
    char input1[128];
    cin.getline(input1, 128, '~'); // "INIT TooMuchRecursion" *INIT is case sensitive, the team is not, enter '~' to stop input
    cout << input1 << endl;
    
    while(strcmp(input1, "EXIT") != 0){
    
    send(listmeow, input1, sizeof(input1), 0);
    char buffer[128];
    memset(&buffer[0], 0, sizeof(buffer));
    recv(listmeow, buffer, sizeof(buffer), 0);
    cout << buffer << endl;
    
    if(strcmp(buffer, "END") == 0)
        break;
    
    memset(&input1[0], 0, sizeof(input1));
    cout << "Enter the input command, enter EXIT to end" << endl;
    cin.getline(input1, 128, '~');
    cout << input1 << endl;
    }
    
    shutdown(listmeow, chk);
    closesocket(listmeow);
    WSACleanup();
    cout << "server exited" << endl;
}