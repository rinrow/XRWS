using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float _jerkLength;
    [SerializeField] private float _jerkSpeed;

    private bool _isJerking;
    private bool _canJerk;
    private Connection _connection;

    //инициализация полей
    //подписка на события (observer)
    private void OnEnable()
    {
        _canJerk = true;
        _connection = GetComponent<Connection>();
        _connection.OnJerkButtonPressed += () =>
            {
                if (!_isJerking && _canJerk)
                    StartCoroutine(DoJerk());
            };
        _connection.OnNeedCheckData += (login, password) => _connection.TargetChangeSceneToMain();
    }

    //Рывок
    //Каждый кадр отправление команды поменять позицию игроку
    private IEnumerator DoJerk()
    {
        _isJerking = true;
        var delta = 0f;
        var targetPos = transform.position + transform.forward * _jerkLength;
        var previousPos = transform.position;

        while (delta * _jerkSpeed <= 1)
        {
            yield return null;

            delta += Time.deltaTime;
            _connection.RpcChangePosition(Vector3.Lerp(previousPos, targetPos, delta * _jerkSpeed));
        }
        _isJerking = false;
    }

    //Отменв всех "побочных эффектов" столкновения
    private IEnumerator UndoOnHitting(PlayerController player)
    {
        yield return new WaitForSeconds(5);
        player._connection.RpcChangeColor(Color.white);
        player._canJerk = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
            OnHitting(player);
    }

    //Вызывается при столкноыении
    private void OnHitting(PlayerController controller)
    {
        if (_isJerking)
        {
            controller._connection.RpcChangeColor(Color.red);
            controller._canJerk = false;

            StartCoroutine(UndoOnHitting(controller));
        }
    }
}
