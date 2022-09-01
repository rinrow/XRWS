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

    //������� ����������� ������ 
    [ClientRpc]
    public void RpcTranslatePosition(Vector3 delta)
    {
        OnNeedTranslatePos?.Invoke(delta);
    }

    //������� ���������� ����� ������� ������ 
    [ClientRpc]
    public void RpcSetPosition(Vector3 target)
    {
        OnNeedSetPos?.Invoke(target);
    }

    //������� �������� ���� 
    [ClientRpc]
    public void RpcChangeColor(Color target)
    {
        OnNeedChangeColor?.Invoke(target);
    }

    //������� ��������� �����
    [ClientRpc]
    public void RpcLoadScene(string sceneName)
    {
        OnNeedLoadScene?.Invoke(sceneName);
    }

    //������ �� ������������� ������ 
    [Command]
    public void CmdTranslatePosition(Vector3 delta)
    {
        
    }

    //������ �� �����
    [Command]
    public void CmdJerk(Vector3 pos)
    {

    }

    //������ "��������� ����" ������ �� ����� �� ����� �����
    [Command]
    public void CmdOnHit(PlayerController player)
    {

    }

    //�������� ������ � ������ � �������� ����� 
    [Command]
    public void CmdLogIn(string login, string passwrod)
    {

    }

    //�������� ������ � ������ � �������� ������������������
    [Command]
    public void CmdRegister(string login, string passwrod)
    {

    }
}
