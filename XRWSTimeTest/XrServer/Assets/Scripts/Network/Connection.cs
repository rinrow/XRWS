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

    //������� ����������� ������ 
    [ClientRpc]
    public void RpcTranslatePosition(Vector3 delta) { }

    //������� ���������� ����� ������� ������ 
    [ClientRpc]
    public void RpcSetPosition(Vector3 target) { }

    //������� �������� ���� 
    [ClientRpc]
    public void RpcChangeColor(Color target) { }

    //�������� �����
    [ClientRpc]
    public void RpcLoadScene(string sceneName) { }

    //������ �� ������������� ������ 
    [Command]
    public void CmdTranslatePosition(Vector3 delta)
    {
        TranslatePosCmdRecieved?.Invoke(delta);
    }

    //������ �� �����
    [Command]
    public void CmdJerk(Vector3 pos)
    {
        JerkCmdRecieved?.Invoke(pos);
    }

    //������ "��������� ����" ������ �� ����� �� ����� �����
    [Command]
    public void CmdOnHit(PlayerController player)
    {
        Hitted?.Invoke(player);
    }

    //�������� ������ � ������ � �������� ����� 
    [Command]
    public void CmdLogIn(string login, string passwrod)
    {
        NeedLogIn?.Invoke(login, passwrod);
    }

    //�������� ������ � ������ � �������� ������������������
    [Command]
    public void CmdRegister(string login, string passwrod)
    {
        NeedRegister?.Invoke(login, passwrod);
    }
}
