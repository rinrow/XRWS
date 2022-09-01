using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Connection))]
public class SceneLoader : MonoBehaviour
{
    private Connection _connection;

    //������������ ����
    //�������� �� �������
    private void Start()
    {
        _connection = GetComponent<Connection>();

        _connection.OnNeedLoadScene += name => ClientNetworkManager.Instance.ServerChangeScene(name);
    }
}
