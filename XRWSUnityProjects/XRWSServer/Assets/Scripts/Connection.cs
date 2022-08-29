using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class Connection : NetworkBehaviour
{
    public static Connection Instance;

    public event Action OnJerkButtonPressed;
    public event Action<string, string> OnNeedCheckData;

    //������ �� �� ����� ������� ����� �� ������
    [Command]
    public void CmdJerk()
    {
        OnJerkButtonPressed?.Invoke();
    }

    //������� �������� ������� ������������ �� �������
    [ClientRpc]
    public void RpcChangePosition(Vector3 target)
    {

    }

    //�����������
    [Command]
    public void CmdEnter(string name, string password)
    {
        //��������� � �� � ��
        //��������� ��� �����
        //�������� ���� ����
        OnNeedCheckData?.Invoke(name, password);
    }

    //�������� ����� ����������� �� ������� ����� 
    [TargetRpc]
    public void TargetChangeSceneToMain()
    {

    }

    //������� �������� ����
    [ClientRpc]
    public void RpcChangeColor(Color targetColor)
    {

    }
}
