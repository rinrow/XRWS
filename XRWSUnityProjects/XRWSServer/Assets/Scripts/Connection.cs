using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class Connection : NetworkBehaviour
{
    public static Connection Instance;

    public event Action OnJerkButtonPressed;
    public event Action<string, string> OnNeedCheckData;

    //Запрос на то чтобы сделать рывок от игрока
    [Command]
    public void CmdJerk()
    {
        OnJerkButtonPressed?.Invoke();
    }

    //Команда поменять позицию отправляется от сервера
    [ClientRpc]
    public void RpcChangePosition(Vector3 target)
    {

    }

    //Авторизация
    [Command]
    public void CmdEnter(string name, string password)
    {
        //отправить в бд и тд
        //проверили все четко
        //зарегали если надо
        OnNeedCheckData?.Invoke(name, password);
    }

    //Поменять сцену авторизации на главную сцену 
    [TargetRpc]
    public void TargetChangeSceneToMain()
    {

    }

    //Команда поменять цвет
    [ClientRpc]
    public void RpcChangeColor(Color targetColor)
    {

    }
}
