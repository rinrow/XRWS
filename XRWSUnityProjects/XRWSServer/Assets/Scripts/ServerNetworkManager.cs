using Mirror;
using UnityEngine;

public class ServerNetworkManager : NetworkManager
{
    //��� ������� ���������� �������� ������
    private void OnEnable()
    {
        StartServer();
    }
}
