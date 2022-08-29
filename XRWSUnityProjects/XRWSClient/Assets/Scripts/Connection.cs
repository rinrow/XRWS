using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class Connection : NetworkBehaviour
{
    public event Action<Vector3> OnNeedChangePosition;
    public event Action<Color> OnNeedChangeColor;
    public event Action OnNeedChangeScene;

    //Запрос на то чтобы сделать рывок от игрока
    [Command]
    public void CmdJerk()
    {
    }

    //Авторизация
    [Command]
    public void CmdEnter(string name, string password)
    {
    }

    //Команда поменять позицию отправляется от сервера
    [ClientRpc]
    public void RpcChangePosition(Vector3 target)
    {
        OnNeedChangePosition?.Invoke(target);
    }

    //Команда поменять цвет
    [ClientRpc]
    public void RpcChangeColor(Color targetColor)
    {
        OnNeedChangeColor?.Invoke(targetColor);
    }

    //Поменять сцену авторизации на главную сцену 
    [TargetRpc]
    public void TargetChangeSceneToMain()
    {
        OnNeedChangeScene?.Invoke();
    }
}
