using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private Connection _connection;
    private Material _currentMaterial;
    
    //Инициализация компонентов
    //Не удалять при переходе на другую сцену
    //Подписка на события (observer)
    //Если не локальный игрок удаляем камеру присоедененную к не локальному игроку
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _connection = GetComponent<Connection>();
        _currentMaterial = GetComponent<MeshRenderer>().material;

        _connection.OnNeedSetPos += pos => transform.position = pos;
        _connection.OnNeedTranslatePos += delta => transform.Translate(delta);
        _connection.OnNeedChangeColor += color => _currentMaterial.color = color;

        if (!isLocalPlayer)
            transform.GetComponentInChildren<Camera>().enabled = false;
    }

    //Управление локальным игроком
    //Запрос на передвижение игрока 
    //Запрос на рывок
    private void Update()
    {
        if (!isLocalPlayer) return;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _connection.CmdTranslatePosition(Vector3.right * horizontal * _speed * Time.deltaTime);
        _connection.CmdTranslatePosition(Vector3.forward * vertical * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            _connection.CmdJerk(transform.position);
    }

    //При столкновении с другим игроком отправка запроса на сервер
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
            _connection.CmdOnHit(player);
    }
}
