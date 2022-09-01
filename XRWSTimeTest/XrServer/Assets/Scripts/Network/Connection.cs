using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Connection : NetworkBehaviour
{
    public event Action<Vector3> TranslatePosCmdRecieved;
    public event Action<Vector3> JerkCmdRecieved;
    public event Action<PlayerController> Hitted;
    public event Action<string, string> NeedLogIn;
    public event Action<string, string> NeedRegister;

    //Команда передвинуть игрока 
    [ClientRpc]
    public void RpcTranslatePosition(Vector3 delta) { }

    //Команда установить новую позицию игроку 
    [ClientRpc]
    public void RpcSetPosition(Vector3 target) { }

    //Команда имзенить цвет 
    [ClientRpc]
    public void RpcChangeColor(Color target) { }

    //Загрузка сцены
    [ClientRpc]
    public void RpcLoadScene(string sceneName) { }

    //Запрос на передввижение игрока 
    [Command]
    public void CmdTranslatePosition(Vector3 delta)
    {
        TranslatePosCmdRecieved?.Invoke(delta);
    }

    //Запрос на рывок
    [Command]
    public void CmdJerk(Vector3 pos)
    {
        JerkCmdRecieved?.Invoke(pos);
    }

    //Запрос "причинить вред" игроку от удара во время рывка
    [Command]
    public void CmdOnHit(PlayerController player)
    {
        Hitted?.Invoke(player);
    }

    //Отправка логина и пароля с запросом войти 
    [Command]
    public void CmdLogIn(string login, string passwrod)
    {
        NeedLogIn?.Invoke(login, passwrod);
    }

    //Отправка логина и пароля с запросом зарегестрироваться
    [Command]
    public void CmdRegister(string login, string passwrod)
    {
        NeedRegister?.Invoke(login, passwrod);
    }
}
