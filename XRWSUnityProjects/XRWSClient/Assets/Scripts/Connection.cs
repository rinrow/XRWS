using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class Connection : NetworkBehaviour
{
    public event Action<Vector3> OnNeedChangePosition;
    public event Action<Color> OnNeedChangeColor;
    public event Action OnNeedChangeScene;

    //������ �� �� ����� ������� ����� �� ������
    [Command]
    public void CmdJerk()
    {
    }

    //�����������
    [Command]
    public void CmdEnter(string name, string password)
    {
    }

    //������� �������� ������� ������������ �� �������
    [ClientRpc]
    public void RpcChangePosition(Vector3 target)
    {
        OnNeedChangePosition?.Invoke(target);
    }

    //������� �������� ����
    [ClientRpc]
    public void RpcChangeColor(Color targetColor)
    {
        OnNeedChangeColor?.Invoke(targetColor);
    }

    //�������� ����� ����������� �� ������� ����� 
    [TargetRpc]
    public void TargetChangeSceneToMain()
    {
        OnNeedChangeScene?.Invoke();
    }
}
