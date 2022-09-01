using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authorization : MonoBehaviour
{
    public static Authorization Instance { get; set; }

    //Singlateon
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //Проверка введенных данных при входе
    public void LogIn(string login, string password, Connection connection)
    {
        //if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            connection.RpcLoadScene("Game");
    }

    //Проверка введенных данных при регестрации
    public void Register(string login, string password, Connection connection)
    {
        //if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            connection.RpcLoadScene("Game");
    }
}
