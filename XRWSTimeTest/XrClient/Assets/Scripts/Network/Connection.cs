using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Connection : NetworkBehaviour
{
    public event Action<Vector3> OnNeedTranslatePos;
    public event Action<Vector3> OnNeedSetPos;
    public event Action<Color> OnNeedChangeColor;
    public event Action<string> OnNeedLoadScene;

    //Команда передвинуть игрока 
    [ClientRpc]
    public void RpcTranslatePosition(Vector3 delta)
    {
        OnNeedTranslatePos?.Invoke(delta);
    }

    //Команда установить новую позицию игроку 
    [ClientRpc]
    public void RpcSetPosition(Vector3 target)
    {
        OnNeedSetPos?.Invoke(target);
    }

    //Команда изменить цвет 
    [ClientRpc]
    public void RpcChangeColor(Color target)
    {
        OnNeedChangeColor?.Invoke(target);
    }

    //Команда загрузить сцену
    [ClientRpc]
    public void RpcLoadScene(string sceneName)
    {
        OnNeedLoadScene?.Invoke(sceneName);
    }

    //Запрос на передввижение игрока 
    [Command]
    public void CmdTranslatePosition(Vector3 delta)
    {
        
    }

    //Запрос на рывок
    [Command]
    public void CmdJerk(Vector3 pos)
    {

    }

    //Запрос "причинить вред" игроку от удара во время рывка
    [Command]
    public void CmdOnHit(PlayerController player)
    {

    }

    //Отправка логина и пароля с запросом войти 
    [Command]
    public void CmdLogIn(string login, string passwrod)
    {

    }

    //Отправка логина и пароля с запросом зарегестрироваться
    [Command]
    public void CmdRegister(string login, string passwrod)
    {

    }
}
