using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    [SerializeField] private InputField _nameField;
    [SerializeField] private InputField _passwordField;

    //��� ������� ������ ����������������
    //������ ���������� ������ ��������� ����� � ������ �� ������
    public void OnEnterButtonClick()
    {
        var localPlayer = FindObjectsOfType<PlayerController>()
            .Where(p => p.isLocalPlayer)
            .FirstOrDefault();

        localPlayer.Enter(_nameField.text, _passwordField.text);
    }
}
