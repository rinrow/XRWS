using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Connection))]
public class SceneLoader : MonoBehaviour
{
    private Connection _connection;

    //Инициализаця поля
    //Подписка на событие
    private void Start()
    {
        _connection = GetComponent<Connection>();

        _connection.OnNeedLoadScene += name => ClientNetworkManager.Instance.ServerChangeScene(name);
    }
}
