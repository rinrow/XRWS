using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float _jerkLength;
    [SerializeField] private float _jerkSpeed;
    [SerializeField] private float _jerkHitHarmTime;

    private bool _canMove = true;
    private bool _isJerking = false;
    private Connection _connection;
    private bool _isStopJerking = false;

    //Инициализация компонентов
    //Подписка на события (observer)
    private void Start()
    {
        _connection = GetComponent<Connection>();

        _connection.TranslatePosCmdRecieved += delta =>
        {
            if (_canMove)
                _connection.RpcTranslatePosition(delta);
        };

        _connection.JerkCmdRecieved += currentPos => StartCoroutine(Jerk(currentPos));

        _connection.Hitted += (player) =>
        {
            if (player._isJerking)
            {
                player._isStopJerking = true;

                _connection.RpcChangeColor(Color.green);
                _canMove = false;
                StartCoroutine(UndoHitHarmsAfterSeconds());
            }
        };

        _connection.NeedLogIn += (login, password) => Authorization.Instance.LogIn(login, password, _connection);
        _connection.NeedRegister += (login, password) => Authorization.Instance.Register(login, password, _connection);
    }

    //Процесс рывкаю Плавное перемещение игрока по оси z
    private IEnumerator Jerk(Vector3 currentPos)
    {
        var delta = 0f;
        var targetPos = currentPos + Vector3.forward * _jerkLength;
        _isJerking = true;
        _canMove = false;
        while (delta < 1/_jerkSpeed)
        {
            if (_isStopJerking) break;

            delta += Time.deltaTime * _jerkSpeed;
            _connection.RpcSetPosition(Vector3.Lerp(currentPos, targetPos, delta));
            yield return null;
        }
        _canMove = true;
        _isJerking = false;
        _isStopJerking = false;
    }

    //Отмена всех побочных эффектов от удара рывком
    private IEnumerator UndoHitHarmsAfterSeconds()
    {
        yield return new WaitForSeconds(_jerkHitHarmTime);
        _canMove = true;
        _connection.RpcChangeColor(Color.white);
    }
}
