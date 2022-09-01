using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    [SerializeField] private InputField _loginField;
    [SerializeField] private InputField _passwordField;

    private Connection _localPlayerConnection;
    private bool _isConnectionInitted = false;
    //������� ��� ������� �� ����� � ����� ��� ������� ����������
    private void InitLocalPlayerConnection()
    {
        if (_isConnectionInitted) return;

        var players = FindObjectsOfType<Connection>();

        foreach (var connection in players)
        {
            if (!connection.isLocalPlayer)
                continue;
            _localPlayerConnection = connection;
            break;
        }
        if (_localPlayerConnection != null)
            _isConnectionInitted = true;
    }

    //���������� ��� ������� ������ "�����"
    public void LogIn()
    {
        InitLocalPlayerConnection();

        _localPlayerConnection.CmdLogIn(_loginField.text, _passwordField.text);
    }

    //���������� ��� ������� ������ "������������������"
    public void Register()
    {
        InitLocalPlayerConnection();

        _localPlayerConnection.CmdRegister(_loginField.text, _passwordField.text);
    }
}
